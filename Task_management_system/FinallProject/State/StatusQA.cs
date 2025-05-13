using FinallProject.Memento;
using FinallProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallProject.State
{
    public class StatusQA : IStatus
    {
        public StatusQA(TaskHistory statusTask) : base(statusTask)
        {
        }

        public override void CompletionOfTheStage()
        {
            _statusTask.ChangeState(new StatusDone(_statusTask));
            Console.WriteLine("move from QA to done");

        }
    }
}
