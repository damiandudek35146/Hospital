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
        private static readonly Strategy loginStrategy;
        public static void Start()
        { 
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hospital Menagment System 1.0.1");
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Strategy loginStrategy;
                int optionpanel = GetUserOption(new List<string> { "Doctor Panel", "Patient Panel" });
                switch (optionpanel)
                {
                    case 1: loginStrategy = new DoctorStartegy(); break;
                    case 2: loginStrategy = new PatientStrategy(); break;
                    default: throw new ArgumentOutOfRangeException();
                }
                int optionlogin = GetUserOption(new List<string> { "Login", "Register" });
                switch (optionlogin)
                {
                    case 1: loginStrategy.Login(); break;
                    case 2: loginStrategy.Register(); break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
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
                    if (question.Contains("ssword"))
                    {
                        str = HidenPassword(question);
                    }
                    else if (question.Contains("*"))
                    {
                        str = Required(question);
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
        private static string Required(string question)
        {
            string str = String.Empty;
            while (String.IsNullOrEmpty(str))
            {
                Console.Clear();
                Console.WriteLine(question);
                str = Console.ReadLine();
            }
            return str;
        }
        private static string HidenPassword(string question)
        {
            string str = String.Empty;
            Console.Clear();
            Console.WriteLine(question);
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    str += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if(str.Length>0)
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    Console.Write("\b");
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return str.TrimEnd('\r');
        }
    }
}
