using Hospital.DataLayer;
using Hospital.DataLayer.Repositories;
using Hospital.Domain.Entities;
using Hospital.Domain.Enums;
using Hospital.Service;
using Hospital.Service.Application;
using Hospital.Service.Interfaces;
using Hospital.Service.Models;
using Hospital.UI.Extensions;
using System.Reflection;

namespace Hospital.UI
{
    public static class UserInterface
    {
        private static readonly IDoctorService doctorService = new DoctorService();
        private static readonly ILogin loginService = new Login();
        public static bool LoginSucces()
        {
            throw new NotImplementedException();
        }
        public static void Start()
        {
            Console.WriteLine("Hospital Menagment System 1.0.1");
            int option = GetUserOption(new List<string> { "Login", "Register" });
            switch (option)
            {
                case 1: LoginPanel(); break;
                case 2: RegisterPanel(); break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
        private static void LoginPanel()
        {
            var loginData = GetLoginDetails();
            Doctor doctor;
            try
            {
                doctor = loginService.LoginDoctor(loginData.login, loginData.password).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nWrong login or password..");
                Console.ReadKey();
            }
        }

        private static void RegisterPanel()
        {
            var questions = new List<string> { "FirstName*", "LastName*", "Login*", "Password*", "IdCardNumber*" };
            var registerData = GetUserInput(questions);
            var doctor = new Doctor();
            foreach (var item in registerData)
            {
                doctor.GetType().GetProperty(item.Key).SetValue(doctor,item.Value,null);
            }
            try
            {
                doctorService.InsertDoctor(doctor);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nSomething went wrong..");
                Console.ReadKey();
            }
        }

        private static (string firstName, string lastName, string login, string password, string idCardNumber) GetRegisterDetails()
        {
            string firstName = String.Empty;
            string lastName = String.Empty;
            string login = String.Empty;
            string password = String.Empty;
            string idCardNumber = String.Empty;

            while (String.IsNullOrEmpty(firstName))
            {
                Console.Clear();
                Console.WriteLine("First Name* : ");
                firstName = Console.ReadLine();
            }
            while (String.IsNullOrEmpty(lastName))
            {
                Console.Clear();
                Console.WriteLine("Last Name* : ");
                lastName = Console.ReadLine();
            }
            while (String.IsNullOrEmpty(login))
            {
                Console.Clear();
                Console.WriteLine("Login* : ");
                login = Console.ReadLine();
            }
            while (String.IsNullOrEmpty(password))
            {
                Console.Clear();
                Console.WriteLine("Password* : ");
                password = Console.ReadLine();
            }
            while (String.IsNullOrEmpty(idCardNumber))
            {
                Console.Clear();
                Console.WriteLine("ID Card Number*(15 max) : ");
                idCardNumber = Console.ReadLine();
            }
            return (firstName, lastName, login, password, idCardNumber);
        }
        public static Dictionary<string, string> GetUserInput(List<string> questions)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            Console.Clear();
            while (dictionary.Count != questions.Count)
            {
                foreach (string question in questions)
                {
                    var str = String.Empty;
                    if (question.Contains("*"))
                    {
                        while(String.IsNullOrEmpty(str))
                        {
                            Console.Clear();
                            Console.WriteLine(question);
                            str = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(question);
                        str = Console.ReadLine();
                    }
                    dictionary.Add(question.TrimEnd('*'), str);
                }
            }
            return dictionary;
        }
        public static int GetUserOption(List<string> options)
        {
            int answer = 0;
            while (answer <= 0 || answer > options.Count)
            {
                Console.Clear();
                foreach (var option in options)
                {
                    Console.WriteLine($"{options.IndexOf(option) + 1}. {option}");
                }
                var str = Console.ReadLine();
                if (str.IsNumber())
                {
                    answer = Convert.ToInt32(str);
                }
            }
            return answer;
        }

        private static (string login, string password) GetLoginDetails()
        {
            var login = String.Empty;
            var password = String.Empty;

            while (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(password))
            {
                Console.Clear();
                Console.WriteLine("Login: ");
                login = Console.ReadLine();
                if (String.IsNullOrEmpty(login))
                {
                    continue;
                }
                Console.WriteLine("Password: ");
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("\b");
                    }
                }
                while (key.Key != ConsoleKey.Enter);
                break;
            }
            return (login, password.TrimEnd('\r'));
        }


        public static void Hello()
        {
            var patient = new Patient
            {
                FirstName = "Damian",
                LastName = "Dudek",
                Login = "ddudek",
                Password = "zaq1@WSX",
                IdCardNumber = "1234567890"
            };
            ///Strategia do wyboru domunikatu na interfejsie urzytkownika.
            //// Metoda wytwórcza do tworzenia poszczególnych obiektów.
            Console.WriteLine("Dodano pacjenta");
        }

    }
}
