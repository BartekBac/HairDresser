using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Helpers
{
    public class Urls
    {
        public const string Base = "http://localhost:4200";
        public const string AuthPage = Base + "/auth";
        public const string ClientPage = Base + "/client";
        public const string ClientAddSalonPage = ClientPage + "/add-salon";
        public const string SalonPage = Base + "/salon";
        public const string WorkerPage = Base + "/worker";
    }
    public class Credentials
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public Credentials(string login, string passowrd)
        {
            Login = login;
            Password = passowrd;
        }
    }
    public static class Constants
    {
        public static Credentials ClientCredentials = new Credentials("client5", "client5");
        public static Credentials SalonCredentials = new Credentials("salon5", "salon5");
        public static Credentials WorkerCredentials = new Credentials("worker51", "worker51");
    }
}
