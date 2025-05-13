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
    class QA : BaseHandler
    {
        public override bool Handle(Task1 task, User user)
        {
            if (task.Status.GetType() == typeof(StatusQA)&& user.Role==Role.QA)
            {
                task.Status.CompletionOfTheStage();
                return true;
            }
           //Console.WriteLine("QA can not change state");
            return false;
        }
    }
}
