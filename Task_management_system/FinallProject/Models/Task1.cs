using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using FinallProject.Enums;
using FinallProject.Memento;
using FinallProject.Observer;
using FinallProject.State;

namespace FinallProject.Models;

public class Task1
{
    public DateTime CreationDate { get; set; }
    public string Title { get; set; } = null;
    public string Description { get; set; }
    public User Assignee { get; set; }
    public User? Reporter { get; set; }
    public IStatus? Status { get; set; } 
    public Priority? Priority { get; set; }
    public int EstimationTime { get; set; }
    private int loggedTime = 0;

    public int LoggedTime
    {
        get { return loggedTime; }
        set {
            loggedTime += value;
           // Changes("loggd time change");
        }
    }

    public List<TaskHistory>? SubTasks { get; set; }
    public SendingMessage SendingMessage { get; set; }

    //composite




    //observer
    public void Subscriber()
    {
        SendingMessage.AddToList(Assignee);
        SendingMessage.AddToList(Reporter);
    }


    public TaskHistory CreateBackUp()
    {
        List<TaskHistory> tasks = new List<TaskHistory>();
        User u1 = new User(Assignee.Name, Assignee.Email, Assignee.Role);
        User u2 = null;
        if (Reporter != null)
        { u2 = new User(Reporter.Name, Reporter.Email, Reporter.Role); }
        foreach (var item in SubTasks)
        {
            tasks.Add(item.CreateBackUp());
        }

        return new TaskHistory(new Task1()
        {

            CreationDate = CreationDate,
            Title = Title,
            Description = Description,
            Reporter = u2,
            Assignee = u1,
            Priority = Priority,
            Status = Status,
            EstimationTime = EstimationTime,
            LoggedTime = LoggedTime,
            SubTasks = tasks,
            SendingMessage = SendingMessage

        }
            );
        
    }


    public void Restore(Task1 task)
    {

        CreationDate = task.CreationDate;
        Title = task.Title;
        Description = task.Description;
        Reporter = task.Reporter;
        Assignee = task.Assignee;
        Priority = task.Priority;
        Status = task.Status;
        EstimationTime = task.EstimationTime;
        LoggedTime = task.LoggedTime;
        SubTasks = task.SubTasks;
        SendingMessage = task.SendingMessage;
    }


   public void Changes(string event1)
      {
        SendingMessage.SendMessages(event1);
      }

    public string ToString()
    {
        return "\n" +"Title: " + Title +"\n"  + "description: "+ Description + "\n" + Reporter.ToString()
            + "estimation time: "+ EstimationTime + "\n" + "logged time " + LoggedTime;
    }
}
