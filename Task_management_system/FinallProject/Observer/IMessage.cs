using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallProject.Observer
{
    public interface IMessage
    {
        public void GetEvent(string eventData);
    }
}
