using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinallProject.Enums;
using FinallProject.Observer;

namespace FinallProject.Models;

public class User : IMessage
{
    public string Name { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }

    public void GetEvent(string eventData)
    {
        Console.WriteLine($"hi {Name}, {eventData} was happend");
    }

    public User(string name, string email, Role role)
    {
        Name = name;
        Email = email;
        Role = role;
    }
    public User() { }

    public string ToString()
    {
        return "name: "+ Name + " email: " + Email + " role: "+ Role + " ";
    }
}
