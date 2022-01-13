using Hospital.DataLayer;
using Hospital.DataLayer.Repositories;
using Hospital.Domain.Entities;
using Hospital.Service;
using Hospital.UI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI
{
    public static class UserInterface
    {
        private static IPatientService _userService;
        public static bool LoginSucces()
        {
            throw new NotImplementedException();
        }
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hospital Menagment System 1.0.1");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.Write("");
                string input = String.Empty;
                input = Console.ReadLine();
                var response = input.IsNumberInRange(1, 2);
                if (response.isNumber)
                {
                    switch (response.number)
                    {
                        case 1: LoginPanel(); break;
                        case 2: RegisterPanel(); break;
                        default: throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        private static void RegisterPanel()
        {
            throw new NotImplementedException();
        }

        private static void LoginPanel()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Log in");
                Console.WriteLine("Login: ");
                var login = Console.ReadLine();
                if(String.IsNullOrEmpty(login))
                {
                    continue;
                }
                Console.WriteLine("Password: ");
                var password = String.Empty;
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);

                    // Backspace Should Not Work
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("\b");
                    }
                    if (key.Key == ConsoleKey.Enter)
                    {
                        password = password.Replace("\r", "");
                    }
                }
                while (key.Key != ConsoleKey.Enter);
                break;
            }
        }

        public static void Hello()
        {
            var patient  = new Patient
            {
                FirstName = "Damian",
                LastName = "Dudek",
                Login = "ddudek",
                Password = "zaq1@WSX",
                IdCardNumber = "1234567890"
            };
            ///Strategia do wyboru domunikatu na interfejsie urzytkownika.
            //// Metoda wytwórcza do tworzenia poszczególnych obiektów.
            _userService = new PatientService();
            _userService.InsertPatient(patient);
            Console.WriteLine("Dodano pacjenta");
        }
      
    }
}
