using Hospital.Domain.Entities;
using Hospital.Service.Application;
namespace Hospital.UI
{
    // This is a specific implementation for patient strategy
    public class DoctorStartegy : Strategy
    {
        private readonly IDoctorController _doctorController;
        public DoctorStartegy(IDoctorController doctorController)
        {
            _doctorController = doctorController;
        }
        /// <summary>
        /// Retrives login and passsword from console, then try to get user from database, then runs doctor system.
        /// </summary>
        public override void Login()
        {
            var questions = new List<string> { "Login*", "Password*" };
            var loginData = UserInterface.GetUserInput(questions);
            var doctor = _doctorController.Login(loginData["Login"], loginData["Password"]).Result;
            if (doctor.Login != null)
            {
                SystemFasade = new Facade();
                SystemFasade.RunDoctorSystem(doctor);
            }
            else
            {
                Console.WriteLine("\nWrong login or password..");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Retrives register data from console, then try to add user to database, then runs doctor system.
        /// </summary>
        public override void Register()
        {
            var questions = new List<string> { "FirstName*", "LastName*", "Login*", "Password*", "IdCardNumber*" };
            var registerData = UserInterface.GetUserInput(questions);
            var doctor = new Doctor();
            foreach (var item in registerData)
            {
                doctor.GetType().GetProperty(item.Key).SetValue(doctor, item.Value, null);
            }
            var success = _doctorController.Register(doctor).Result;
            if (success)
            {
                SystemFasade = new Facade();
                SystemFasade.RunDoctorSystem(doctor);
            }
            else
            {
                Console.WriteLine("\nSomething went wrong..");
                Console.ReadKey();
            }
        }
    }
}
