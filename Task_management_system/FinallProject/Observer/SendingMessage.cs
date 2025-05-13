using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallProject.Observer;

public class SendingMessage
{
    private List<IMessage> messages = new List<IMessage>();

    public void AddToList(IMessage message)
    {
        messages.Add(message);
    }

    public void RemoveFromList(IMessage message)
    { 
        messages.Remove(message);
    }

    public void SendMessages(string eventData)
    {
        foreach (IMessage message in messages)
        {
            message.GetEvent(eventData);
        }
    }
}
