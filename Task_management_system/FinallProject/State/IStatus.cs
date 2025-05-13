using FinallProject.Memento;
using FinallProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallProject.State
{
    public abstract class IStatus
    {
        protected TaskHistory _statusTask;

        protected IStatus(TaskHistory statusTask)
        {
            _statusTask = statusTask;
        }

        abstract public void CompletionOfTheStage();

    }
}
