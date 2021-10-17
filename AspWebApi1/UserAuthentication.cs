using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspWebApi1
{
    public class UserAuthentication : IDisposable
    {
        public string ValidateUser(string username, string password)
        {
            string Name = username == "akash" ? "Valid" : "InValid";
            string Pass = password == "vidhate" ? "Valid" : "InValid";

            if (Name == "Valid" && Pass == "Valid")
                return "true";
            else
                return "false";
        }
        public void Dispose()
        {
            //Dispose();  
        }
    }
}