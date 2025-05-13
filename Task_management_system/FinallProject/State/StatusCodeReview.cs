using FinallProject.Memento;
using FinallProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallProject.State
{
    public class StatusCodeReview : IStatus
    {
        public StatusCodeReview(TaskHistory statusTask) : base(statusTask)
        {
        }

        public override void CompletionOfTheStage()
        {
            _statusTask.ChangeState(new StatusQA(_statusTask));
            Console.WriteLine("move from code review to QA");

        }
    }
}

