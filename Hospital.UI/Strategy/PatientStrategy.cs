using Hospital.Domain.Entities;
using Hospital.Service.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public class PatientStrategy : Strategy
    {
        private static readonly ILogin loginService = new Login();
        public override void Login()
        {
            var questions = new List<string> { "Login*", "Password*" };
            var loginData = UserInterface.GetUserInput(questions);
            Patient doctor;
            try
            {
                doctor = loginService.LoginPatient(loginData["Login"], loginData["Password"]).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nWrong login or password..");
                Console.ReadKey();
            }
        }

        public override void Register()
        {
            var questions = new List<string> { "FirstName*", "LastName*", "Login*", "Password*", "IdCardNumber*" };
            var registerData = UserInterface.GetUserInput(questions);
            var patient = new Patient();
            foreach (var item in registerData)
            {
                patient.GetType().GetProperty(item.Key).SetValue(patient, item.Value, null);
            }
            try
            {
                //doctorService.InsertDoctor(doctor);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nSomething went wrong..");
                Console.ReadKey();
            }
        }
    }
}
