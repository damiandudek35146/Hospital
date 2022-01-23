using Hospital.Domain.Entities;
using Hospital.Service.Application;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Hospital.UI
{
    // This is a specific implementation for patient strategy
    public class PatientStrategy : Strategy
    {
        private readonly IPatientController _patientController;
        public PatientStrategy(IPatientController patientController)
        {
            _patientController = patientController;
        }
        /// <summary>
        /// Retrives login and passsword from console, then try to get user from database to run patient system.
        /// </summary>
        public override void Login()
        {
            var questions = new List<string> { "Login*", "Password*" };
            var loginData = UserInterface.GetUserInput(questions);
            var patient = _patientController.Login(loginData["Login"], loginData["Password"]).Result;
            if (patient.Login != null)
            {
                SystemFasade = new Facade();
                SystemFasade.RunPatientSystem(patient);
            }
            else
            {
                Console.WriteLine("\nWrong login or password..");
                Console.ReadKey();
            }
        }
    }
}
