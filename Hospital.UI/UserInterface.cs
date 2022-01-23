using Hospital.Service.Application;
using Hospital.UI.Extensions;
using System.Globalization;

namespace Hospital.UI
{
    public static class UserInterface
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hospital Menagment System 1.0.1");
                Console.WriteLine("Press any key to continue..");
                Console.ReadKey();
                Strategy loginStrategy;
                int optionpanel = GetUserOption(new List<string> { "Doctor Panel", "Patient Panel" }, String.Empty);
                switch (optionpanel)
                {
                    case 1: loginStrategy = new DoctorStartegy(new DoctorController()); break;
                    case 2: loginStrategy = new PatientStrategy(new PatientController()); break;
                    default: throw new ArgumentOutOfRangeException();
                }
                var menu = new List<string> { "Login", "Register" };

                if (optionpanel == 2)
                {
                    menu.Remove("Register");
                }
                int optionlogin = GetUserOption(menu, String.Empty);
                switch (optionlogin)
                {
                    case 1: loginStrategy.Login(); break;
                    case 2: loginStrategy.Register(); break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
        /// <summary>
        /// Shows a form to the user to compleate it, based on the list of parameters
        /// </summary>
        /// <returns>Key value-pair key is parameter name value is value</returns>
        public static Dictionary<string, string> GetUserInput(List<string> questions)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            Console.Clear();
            while (dictionary.Count != questions.Count)
            {
                foreach (string question in questions)
                {
                    var str = String.Empty;
                    if (question.Contains("assword"))
                    {
                        str = HidenPassword(question);
                    }
                    else if (question.Contains("CardNumber"))
                    {
                        str = Max15Characters(question);
                    }
                    else if (question.Contains("StartsAt"))
                    {
                        str = GetDate(question);
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

        private static string GetDate(string question)
        {
            string str = String.Empty;
            bool parseResult = true;
            string[] formats = { "dd/MM/yyyy hh:mm", "d/M/yyyy hh:mm", "dd/M/yyyy hh:mm", "d/MM/yyyy hh:mm",
                "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy" };
            while (String.IsNullOrEmpty(str) || !parseResult)
            {
                Console.Clear();
                if (!parseResult)
                {
                    Console.WriteLine("Wrong format");
                }
                Console.WriteLine(question+" (dd/MM/yyyy hh:mm)");
                str = Console.ReadLine();
                parseResult = DateTime.TryParseExact(str, formats, new CultureInfo("pl-PL"), DateTimeStyles.None, out DateTime dt);
            }
            return str;
        }

        /// <summary>
        /// Asks the user which menu item he wants to select
        /// </summary>
        /// <returns>Item number from menu</returns>
        public static int GetUserOption(List<string> options, string additional)
        {
            int answer = 0;
            while (answer <= 0 || answer > options.Count)
            {
                Console.Clear();
                if(additional != String.Empty)
                {
                    Console.WriteLine(additional + "\n");
                }
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
                    if (str.Length > 0)
                    {
                        str = str.Substring(0, str.Length - 1);
                    }
                    Console.Write("\b");
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return str.TrimEnd('\r');
        }
        private static string Max15Characters(string question)
        {

            string str = String.Empty;
            while (String.IsNullOrEmpty(str) || str.Length > 15)
            {
                Console.Clear();
                Console.WriteLine(question);
                str = Console.ReadLine();
            }
            return str;
        }
    }
}
