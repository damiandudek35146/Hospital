using Hospital.Domain.Entities;
using Hospital.Service.Application;
using Hospital.Service.Controllers;
using Hospital.UI.Decorators;

namespace Hospital.UI
{
    // This is a facade of two systems, its allows to run specific subsystem for logged user
    public class Facade
    {
        DoctorSystem doctorSystem;
        PatientSystem patientSystem;
        public void RunPatientSystem(Patient patient)
        {
            patientSystem = new PatientSystem(patient, new PatientController(), new TreatmentController());
            PatientContinueDecorator patientContinueDecorator = new PatientContinueDecorator();
            patientContinueDecorator.SetComponent(patientSystem);

            var questions = new List<string> { "Edit profile", "Planned treatments", "History of treatments", "Logout" };
            var logout = false;
            while (!logout)
            {
                Console.Clear();
                var summary = patientSystem.GetSummary();
                var menuOption = UserInterface.GetUserOption(questions, "=====Account Summary=====\n" + summary);
                switch (menuOption)
                {
                    case 1: patientContinueDecorator.EditProfile(); break;
                    case 2: patientContinueDecorator.PlannedTreatments(); break;
                    case 3: patientContinueDecorator.TreatmentsHistory(); break;
                    case 4: logout = true; break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
        public void RunDoctorSystem(Doctor doctor)
        {
            doctorSystem = new DoctorSystem(doctor, new DoctorController(), new TreatmentController(), new PatientController(),
                           new BedController(), new SpecialisationController());
            var questions = new List<string> { "Edit profile", "Patient menagment", "Palnned operations",
                "History of operations","Add Specialisation","Remove specialisation","Register new patient","Delete all patients", "Logout" };
            var logout = false;
            while (!logout)
            {
                var summary = doctorSystem.GetSummary();
                var menuOption = UserInterface.GetUserOption(questions, summary);
                switch (menuOption)
                {
                    case 1: doctorSystem.EditProfile(); break;
                    case 2: doctorSystem.PatientMenagment(); break;
                    case 3: doctorSystem.PlannedOperationsAll(); break;
                    case 4: doctorSystem.OperationsHistoryAll(); break;
                    case 5: doctorSystem.AddSpecialisation(); break;
                    case 6: doctorSystem.RemoveSpecialisation(); break;
                    case 7: doctorSystem.RegisterNewPatient(); break;
                    case 8: doctorSystem.DeleteAllPatients(); break;
                    case 9: logout = true; break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
        public virtual void ShowSummaryDoctor() { }
        public virtual void ShowSummaryPatient() { }
    }
}