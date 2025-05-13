using FinallProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallProject.ChainOfResponsibility
{
   public class BaseHandler
    {
        private BaseHandler _next;

        public void SetNext(BaseHandler next)
        {
            _next = next;
        }

        public virtual bool Handle(Task1 task, User user)
        {
            if (_next != null)
            {
                return _next.Handle(task, user);
                
              }
            return false;
        }
    }
}
