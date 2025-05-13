using FinallProject.Memento;
using FinallProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallProject.State
{
    public class StatusToDo : IStatus
    {
        public StatusToDo(TaskHistory statusTask) : base(statusTask)
        {
        }

        public override void CompletionOfTheStage()
        {
            _statusTask.ChangeState(new StatusInProgress(_statusTask));
            Console.WriteLine("move from to do to in progress");
        }
    }
}
