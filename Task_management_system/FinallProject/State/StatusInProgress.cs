using FinallProject.Memento;
using FinallProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallProject.State
{
    public class StatusInProgress : IStatus
    {
        public StatusInProgress(TaskHistory statusTask) : base(statusTask)
        {
        }

        public override void CompletionOfTheStage()
        {

            _statusTask.ChangeState(new StatusCodeReview(_statusTask));
            Console.WriteLine("move from in progress to code review");

        }
    }
}
