using Hospital.Domain.Entities;
using Hospital.Service.Application;
using System.Text;
using Hospital.Service.Controllers;
using Hospital.UI.Decorator;

namespace Hospital.UI
{
    // Subsystem for patient, it inherits from the component and implements its methods
    public class PatientSystem : IComponent
    {
        public Patient Patient { get; set; }
        private readonly IPatientController _patientController;
        private readonly ITreatmentController _treatmentController;
        public PatientSystem(Patient patient, IPatientController patientController, ITreatmentController treatmentController)
        {
            Patient = patient;
            if (Patient.ContactInfo is null)
            {
                Patient.ContactInfo = new ContactInfo();
            }
            _patientController = patientController;
            _treatmentController = treatmentController;
        }
        public string GetSummary()
        {
            Patient = _patientController.Get(Patient.Id).Result;
            Patient.Treatments = _treatmentController.GetByPatientId(Patient.Id).Result;
            var healthy = Patient.Healthy ? "Yes" : "No";
            StringBuilder summary = new StringBuilder();
            summary.Append($"Login: {Patient.Login}\n");
            summary.Append($"First Name: {Patient.FirstName}\nLast Name: {Patient.LastName}\nId Card Number: {Patient.IdCardNumber}\n");
            if (Patient.ContactInfo is not null)
            {
                summary.Append($"Contact informations: \tEmail: {Patient.ContactInfo.Email}\t Phone: {Patient.ContactInfo.PhoneNumber}\n");
            }
            else
            {
                summary.Append($"Contact informations:\n");
            }
            summary.Append($"Healthy: {healthy}\n");
            StringBuilder treatments = new StringBuilder();
            foreach (var item in Patient.Treatments)
            {
                treatments.Append($"{item.Name}, ");
            }
            summary.Append($"Operations: {treatments}");
            if (Patient.Bed is not null)
            {
                summary.Append($"\nLocalisation: \t Room: {Patient.Bed.RoomNumber}\tBed: {Patient.Bed.BedNumber}\n");
            }
            else
            {
                summary.Append($"\nLocalisation: ");
            }
            return summary.ToString();
        }

        public void EditProfile()
        {
            Patient = _patientController.Get(Patient.Id).Result;
            var questions = new List<string> { "New First Name", "New Last Name", "New Id Contact Number", "New Email", "New Phone number" };
            var answers = UserInterface.GetUserInput(questions);
            // Filling oryginator with data
            Originator oryginator = new Originator();
            oryginator.FirstName = Patient.FirstName;
            oryginator.LastName = Patient.LastName;
            oryginator.IdCardNumber = Patient.IdCardNumber;
            if (Patient.ContactInfo is null)
            {
                Patient.ContactInfo = new ContactInfo();
                oryginator.PhoneNumber = "";
                oryginator.Email = "";
            }
            else
            {
                oryginator.PhoneNumber = Patient.ContactInfo.PhoneNumber;
                oryginator.Email = Patient.ContactInfo.Email;
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
        }

        private void SaveEditedData(Originator oryginator)
        {
            Console.WriteLine("Saving data...");
            Patient.FirstName = oryginator.FirstName;
            Patient.LastName = oryginator.LastName;
            Patient.IdCardNumber = oryginator.IdCardNumber;
            if (Patient.ContactInfo is not null)
            {
                Patient.ContactInfo.PhoneNumber = oryginator.PhoneNumber;
                Patient.ContactInfo.Email = oryginator.Email;
            }
            _patientController.Update(Patient);
        }

        private void ResoreData(Originator oryginator, Caretaker caretaker)
        {
            Console.WriteLine("Restoring data...");
            // Data recovery from memento
            oryginator.SetMemento(caretaker.Memento);
            Patient.FirstName = oryginator.FirstName;
            Patient.LastName = oryginator.LastName;
            Patient.IdCardNumber = oryginator.IdCardNumber;
            if (Patient.ContactInfo is not null)
            {
                Patient.ContactInfo.PhoneNumber = oryginator.PhoneNumber;
                Patient.ContactInfo.Email = oryginator.Email;
            }
            _patientController.Update(Patient);
        }
        public void PlannedTreatments()
        {
            Patient.Treatments = _treatmentController.GetInFutureByPatientId(Patient.Id).Result;
            Console.Clear();
            Console.WriteLine("Planned treatments:");
            foreach (var item in Patient.Treatments)
            {
                Console.WriteLine($"\t{Patient.Treatments.ToList().IndexOf(item)+1}.\n\t Name: {item.Name}\n\t Description:" +
                    $" {item.Description}\n\t Duration In Hours: {item.DurationInHours}\n\t Room: {item.Bed.RoomNumber}\n\t" +
                    $" Bed:{item.Bed.BedNumber}\n\t Doctor: {item.Doctor.FirstName} {item.Doctor.LastName}\n\t When: {item.StartsAt.Date} \n");
            }
            if (Patient.Treatments.Count == 0)
            {
                Console.WriteLine("You have not any planned treatments\n");
            }
        }

        public void TreatmentsHistory()
        {
            Patient.Treatments = _treatmentController.GetInPastByPatientId(Patient.Id).Result;
            Console.Clear();
            Console.WriteLine("History of treatments:");
            foreach (var item in Patient.Treatments)
            {
                Console.WriteLine($"\t{Patient.Treatments.ToList().IndexOf(item) + 1}.\n\t Name: {item.Name}\n\t Description:" +
                    $" {item.Description}\n\t Duration In Hours: {item.DurationInHours}\n\t Room: {item.Bed.RoomNumber}\n\t" +
                    $" Bed:{item.Bed.BedNumber}\n\t Doctor: {item.Doctor.FirstName} {item.Doctor.LastName}\n\t When: {item.StartsAt.Date} \n");
            }
            if (Patient.Treatments.Count == 0)
            {
                Console.WriteLine("You have not any history\n");
            }
        }
    }
    
}