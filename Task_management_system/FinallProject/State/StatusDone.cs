using FinallProject.Memento;
using FinallProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallProject.State
{
    public class StatusDone : IStatus
    {
        public StatusDone(TaskHistory statusTask) : base(statusTask)
        {
        }
        public override void CompletionOfTheStage()
        {
            Console.WriteLine("Task completed successfully");
        }
    }
}
