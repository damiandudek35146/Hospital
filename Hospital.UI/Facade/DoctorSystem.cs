using Hospital.Domain.Entities;
using Hospital.Service.Application;
using Hospital.Service.Controllers;
using Hospital.Service.Controllers.Interfaces;
using System.Text;

namespace Hospital.UI
{
    // Subsystem for doctor
    public class DoctorSystem
    {
        public Doctor Doctor { get; set; }
        public List<Patient> Patients { get; set; }
        public Patient CurrentPatient { get; set; }
        private readonly IDoctorController _doctorController;
        private readonly ITreatmentController _treatmentController;
        private readonly IPatientController _patientController;
        private readonly IBedController _bedController;
        private readonly ISpecialisationController _specialisationController;
        static object locker = new object();

        public DoctorSystem(Doctor doctor, IDoctorController doctorController, ITreatmentController treatmentController, IPatientController patientController,
            IBedController bedController, ISpecialisationController specialisationController)
        {
            this.Doctor = doctor;
            Doctor.ContactInfo = new ContactInfo();
            Patients = new List<Patient>();
            _doctorController = doctorController;
            _patientController = patientController;
            _treatmentController = treatmentController;
            _bedController = bedController;
            _specialisationController = specialisationController;
        }
        public string GetSummary()
        {
            initDoctor();
            StringBuilder summary = new StringBuilder();
            summary.Append("=====Account Summary=====\n");
            summary.Append($"Login: {Doctor.Login}\n");
            summary.Append($"First Name: {Doctor.FirstName}\nLast Name: {Doctor.LastName}\nId Card Number: {Doctor.IdCardNumber}\n");
            if (Doctor.ContactInfo is not null)
            {
                summary.Append($"Contact informations: \tEmail: {Doctor.ContactInfo.Email}\t Phone: {Doctor.ContactInfo.PhoneNumber}\n");
            }
            else
            {
                summary.Append($"Contact informations:\n");
            }
            StringBuilder specialisations = new StringBuilder();
            foreach (var item in Doctor.Specialisations)
            {
                specialisations.Append($"{item.Name}, ");
            }
            summary.Append($"Your specialisations: {specialisations}\n");

            StringBuilder treatments = new StringBuilder();
            foreach (var item in Doctor.Treatments)
            {
                treatments.Append($"{item.Name}, ");
            }
            summary.Append($"Your operations: {treatments}");

            return summary.ToString();
        }

        public void DeleteAllPatients()
        {
            //Parallelization of tasks
            Task<List<Patient>> allPatients = Task.Factory.StartNew(() => GetAllPatients());
            var deleteTask = Task.Factory.ContinueWhenAny<bool>(new Task[] { allPatients }, (list) =>
            {
                bool success = false;
                //Parallelization of data
                Parallel.ForEach(allPatients.Result, patient =>
                {
                    success = _patientController.Delete(patient).Result;
                });
                return success;
            });
            if(deleteTask.Result)
            {
                Console.WriteLine("All patients were removed");
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Something went wrong..");
                Console.ReadKey();
            }
        }
        private List<Patient> GetAllPatients()
        {
            return _patientController.GetAll().Result;
        }

  
        private void initDoctor()
        {
            Doctor = _doctorController.Get(Doctor.Id).Result;
        }

        public void EditProfile()
        {
            var questions = new List<string> { "New First Name", "New Last Name", "New Id Contact Number", "New Email", "New Phone number" };
            var answers = UserInterface.GetUserInput(questions);
            // Filling oryginator with data
            Originator oryginator = new Originator();
            oryginator.FirstName = Doctor.FirstName;
            oryginator.LastName = Doctor.LastName;
            oryginator.IdCardNumber = Doctor.IdCardNumber;
            if (Doctor.ContactInfo is not null)
            {
                oryginator.PhoneNumber = Doctor.ContactInfo.PhoneNumber;
                oryginator.Email = Doctor.ContactInfo.Email;
            }
            else
            {
                oryginator.PhoneNumber = "";
                oryginator.Email = "";
            }
            //Creating a snapshot
            Caretaker caretaker = new Caretaker();
            caretaker.Memento = oryginator.CreateMemento();

            oryginator.FirstName = answers["New First Name"];
            oryginator.LastName = answers["New Last Name"];
            oryginator.IdCardNumber = answers["New Id Contact Number"];
            oryginator.PhoneNumber = answers["New Phone number"];
            oryginator.Email = answers["New Email"];

            var menuOption = UserInterface.GetUserOption(new List<string> { "Save", "Restore" }, "Save new data or restore");
            switch (menuOption)
            {
                case 1: SaveEditedData(oryginator); break;
                case 2: ResoreData(oryginator, caretaker); break;
                default: throw new ArgumentOutOfRangeException();
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        private void SaveEditedData(Originator oryginator)
        {
            if (Doctor.ContactInfo is null)
            {
                Doctor.ContactInfo = new ContactInfo();
            }
            Console.WriteLine("Saving data...");
            Doctor.FirstName = oryginator.FirstName;
            Doctor.LastName = oryginator.LastName;
            Doctor.IdCardNumber = oryginator.IdCardNumber;
            Doctor.ContactInfo.PhoneNumber = oryginator.PhoneNumber;
            Doctor.ContactInfo.Email = oryginator.Email;
            _doctorController.Update(Doctor);
        }

        private void ResoreData(Originator oryginator, Caretaker caretaker)
        {
            Console.WriteLine("Restoring data...");
            // Data recovery from memento
            oryginator.SetMemento(caretaker.Memento);
            Doctor.FirstName = oryginator.FirstName;
            Doctor.LastName = oryginator.LastName;
            Doctor.IdCardNumber = oryginator.IdCardNumber;
            if (Doctor.ContactInfo is not null)
            {
                Doctor.ContactInfo.PhoneNumber = oryginator.PhoneNumber;
                Doctor.ContactInfo.Email = oryginator.Email;
            }
            _doctorController.Update(Doctor);
        }
        private Patient? SelectPatient()
        {
            Patients = _patientController.GetAll().Result;
            var patientsToShow = new List<string>();
            foreach (var item in Patients)
            {
                patientsToShow.Add($"{item.FirstName} {item.LastName}");
            }
            if(patientsToShow.Count > 0)
            {
                var menuOption = UserInterface.GetUserOption(patientsToShow, "Select patient to menage:");
                return Patients.ElementAt(menuOption - 1);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There's no patients");
                Console.WriteLine("Select 7. to register new patient");
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                return new Patient();
            }
            
        }
        public void PatientMenagment()
        {
            Patient patient = SelectPatient();
            if (patient.Login != null)
            {
                CurrentPatient = _patientController.Get(patient.Id).Result;
                PatientSystem patientSystem = new PatientSystem(patient, new PatientController(), new TreatmentController());
                var questions = new List<string> { "Add operation", "Planned operations", "Operations history"
                ,"Discharge from hospital","Change bed","Back" };
                var back = false;
                while (!back)
                {
                    var summary = patientSystem.GetSummary();
                    var menuOption = UserInterface.GetUserOption(questions, "=====Patient menagment=====\n" + summary);
                    switch (menuOption)
                    {
                        case 1: AddTreatment(); break;
                        case 2: PlannedOperations(); break;
                        case 3: OperationsHistory(); break;
                        case 4: DischargeFromHospital(); break;
                        case 5: ChangeBed(); break;
                        case 6: back = true; break;
                        default: throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        private void ChangeBed()
        {
            var questions = new List<string> { "Room number (1-100)", "Bed number (1-5)" };
            var answers = UserInterface.GetUserInput(questions);
            var bed = _bedController.Get(int.Parse(answers["Room number (1-100)"]), int.Parse(answers["Bed number (1-5)"])).Result;
            CurrentPatient.Bed = null;
            CurrentPatient.BedId = 0;
            if (bed.RoomNumber == 0 || bed.BedNumber == 0)
            {
                Console.WriteLine("Something went wrong..");
                Console.ReadKey();
            }
            else
            {
                CurrentPatient.Bed = bed;
                CurrentPatient.BedId = bed.Id;
                _patientController.Update(CurrentPatient);
                Console.WriteLine("Bed changed succefully");
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
        }

        private void DischargeFromHospital()
        {
            Patient pat = _patientController.Get(CurrentPatient.Id).Result;
            pat.Healthy = true;
            _patientController.Update(pat);
            Console.WriteLine("Status Changed");
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }
        private void OperationsHistory()
        {
            CurrentPatient.Treatments = _treatmentController.GetInPastByPatientId(CurrentPatient.Id).Result;
            Console.Clear();
            Console.WriteLine("History of treatments:");
            foreach (var item in CurrentPatient.Treatments)
            {
                Console.WriteLine($"\t{CurrentPatient.Treatments.ToList().IndexOf(item) + 1}.\n\t Name: {item.Name}\n\t Description:" +
                    $" {item.Description}\n\t Duration In Hours: {item.DurationInHours}\n\t Room: {item.Bed.RoomNumber}\n\t" +
                    $" Bed:{item.Bed.BedNumber}\n\t Doctor: {item.Doctor.FirstName} {item.Doctor.LastName}\n\t When: {item.StartsAt.Date} \n");
            }
            if (CurrentPatient.Treatments.Count == 0)
            {
                Console.WriteLine("You have not any history\n");
            }

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        private void PlannedOperations()
        {
            CurrentPatient.Treatments = _treatmentController.GetInFutureByPatientId(CurrentPatient.Id).Result;
            Console.Clear();
            Console.WriteLine("Planned treatments:");
            foreach (var item in CurrentPatient.Treatments)
            {
                Console.WriteLine($"\t{CurrentPatient.Treatments.ToList().IndexOf(item) + 1}.\n\t Name: {item.Name}\n\t Description:" +
                    $" {item.Description}\n\t Duration In Hours: {item.DurationInHours}\n\t Room: {item.Bed.RoomNumber}\n\t" +
                    $" Bed:{item.Bed.BedNumber}\n\t Doctor: {item.Doctor.FirstName} {item.Doctor.LastName}\n\t When: {item.StartsAt.Date} \n");
            }
            if (CurrentPatient.Treatments.Count == 0)
            {
                Console.WriteLine("You have not any planned treatments\n");
            }

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        private void AddTreatment()
        {
            var questions = new List<string> { "Name*", "Description*", "DurationInHours*", "Room number (1-100)", "Bed number (1-5)", "StartsAt*" };
            var registerData = UserInterface.GetUserInput(questions);
            Director director = new Director();
            Builder builder = new TreatmentBuilder(registerData,CurrentPatient, Doctor, new BedController());
            director.Construct(builder);
            var treatment = builder.GetResult();

            var success = _treatmentController.Add(treatment).Result;
            if (!success)
            {
                Console.WriteLine("\nSomething went wrong..");
                Console.ReadKey();
            }
            Console.WriteLine("New treatment has been added");
            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        internal void PlannedOperationsAll()
        {
            Doctor.Treatments = _treatmentController.GetInFutureByDoctorId(Doctor.Id).Result;
            Console.Clear();
            Console.WriteLine("Planned treatments:");
            foreach (var item in Doctor.Treatments)
            {
                Console.WriteLine($"\t{Doctor.Treatments.ToList().IndexOf(item) + 1}.\n\t Name: {item.Name}\n\t Description:" +
                    $" {item.Description}\n\t Duration In Hours: {item.DurationInHours}\n\t Room: {item.Bed.RoomNumber}\n\t" +
                    $" Bed:{item.Bed.BedNumber}\n\t Patient: {item.Patient.FirstName} {item.Patient.LastName}\n\t When: {item.StartsAt.Date} \n");
            }
            if (Doctor.Treatments.Count == 0)
            {
                Console.WriteLine("You have not any planned treatments\n");
            }

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        internal void OperationsHistoryAll()
        {
            Doctor.Treatments = _treatmentController.GetInPastByDoctorId(Doctor.Id).Result;
            Console.Clear();
            Console.WriteLine("History of treatments:");
            foreach (var item in Doctor.Treatments)
            {
                Console.WriteLine($"\t{Doctor.Treatments.ToList().IndexOf(item) + 1}.\n\t Name: {item.Name}\n\t Description:" +
                    $" {item.Description}\n\t Duration In Hours: {item.DurationInHours}\n\t Room: {item.Bed.RoomNumber}\n\t" +
                    $" Bed:{item.Bed.BedNumber}\n\t Patient: {item.Patient.FirstName} {item.Patient.LastName}\n\t When: {item.StartsAt.Date} \n");
            }
            if (Doctor.Treatments.Count == 0)
            {
                Console.WriteLine("You have not any history\n");
            }

            Console.WriteLine("Press any key to continue..");
            Console.ReadKey();
        }

        internal void AddSpecialisation()
        {
            var allSpecialistaions = _specialisationController.GetAll().Result.ToList();
            var specialisationsToShow = allSpecialistaions.Where(x => !Doctor.Specialisations.Any(y => y.Name == x.Name)).ToList();

            var questions = new List<string>();
            foreach (var item in specialisationsToShow)
            {
                questions.Add(item.Name);
            }
            if(specialisationsToShow.Count!=0)
            {
                var menuOption = UserInterface.GetUserOption(questions, "Add a new specialization");
                var newSpec = specialisationsToShow.ElementAt(menuOption - 1);
                var success = _doctorController.AddSpecialisation(Doctor, newSpec).Result;
                if (success)
                {
                    Console.WriteLine("Specialization added correctly");
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You have all specialisations :)");
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
        }

        internal void RemoveSpecialisation()
        {
            var questions = new List<string>();
            foreach (var item in Doctor.Specialisations)
            {
                questions.Add(item.Name);
            }

            if (questions.Count != 0)
            {
                var menuOption = UserInterface.GetUserOption(questions, "Select specialisation to delete");
                var success = _doctorController.RemoveSpecialisation(Doctor, Doctor.Specialisations.ElementAt(menuOption-1)).Result;
                if (success)
                {
                    Console.WriteLine("Specialization deleted correctly");
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Something went wrong.");
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You have no specialisations to delete");
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
        }

        internal void RegisterNewPatient()
        {
            var questions = new List<string> { "FirstName*", "LastName*", "Login*", "Password*", "IdCardNumber*" };
            var registerData = UserInterface.GetUserInput(questions);
            var patient = new Patient();
            foreach (var item in registerData)
            {
                patient.GetType().GetProperty(item.Key).SetValue(patient, item.Value, null);
            }

            var success = _patientController.Register(patient).Result;
            if (success)
            {
                Console.WriteLine("\nPatient registered correctly");
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nSomething went wrong..");
                Console.ReadKey();
            }
        }
    }
}
