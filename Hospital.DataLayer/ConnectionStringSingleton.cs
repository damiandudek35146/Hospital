namespace Hospital.DataLayer
{
    // The Singleton class declares the static method getInstance that returns the same
    // instance of its own class with connection string to database.
    public sealed class ConnectionStringSingleton
    {
        private static ConnectionStringSingleton instance;
        private ConnectionStringSingleton(){}
        public static ConnectionStringSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new ConnectionStringSingleton();
            }
            return instance;
        }
        public string ConnectionString
        {
            get 
            { 
                return @"Server=.\SQLEXPRESS;Database=Hospital;User Id=Login;Password=Password;"; 
            }
        }
    }
}
