using FinallProject.Enums;
using FinallProject.Models;
using FinallProject.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallProject.ChainOfResponsibility
{
    class Developer : BaseHandler
    {
        public override bool Handle(Task1 task, User user)
        {
            if (task.Status.GetType() == typeof(StatusToDo)&& user.Role==Role.Developer)
            {
                task.Status.CompletionOfTheStage();
                return true;
            }
           // Console.WriteLine("developer can not change state");
            return base.Handle(task, user);
        }
    }
}
