using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibilityDemo
{
    public class User
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public bool IsAuthenticated { get; set; }

        public List<string> Roles { get; set; }

        public User()
        {
            Id = "";
            Email = "";
            IsAuthenticated = false;
            Roles = new List<string>();
        }

        public void Login()
        {
            Id = "555-333-ffa-ca3";
            Email = "sampleuser@gmail.com";
            IsAuthenticated = true;
            Roles.Add("System User");
        }
    }
}
