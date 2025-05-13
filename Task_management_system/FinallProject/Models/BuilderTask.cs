using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinallProject.Enums;
using FinallProject.Memento;
using FinallProject.Observer;
using FinallProject.State;

namespace FinallProject.Models;

public class BuilderTask
{
    //public DateTime CreationDate { get; set; } = DateTime.Now;
    public string Title { get; set; } = null;
    public string Description { get; set; } = null;
    public User Assignee { get; set; } = null;
    public User Reporter { get; set; } = null;
    public IStatus Status { get; set; }
    public Priority Priority { get; set; } = Priority.Medium;
    public int EstimationTime { get; set; } = 0;
    public int LoggedTime { get; set; } = 0;
    public List<TaskHistory> SubTasks { get; set; } = new List<TaskHistory>();
    SendingMessage sendingMessage { get; set; }


    public BuilderTask(string title, string description, User assign)
    {
        Title = title;
        Description = description;
        Assignee = assign;
        sendingMessage = new SendingMessage();
        sendingMessage.AddToList(assign);
    }

    public void BuildReporter(User reporter)
    {
        Reporter = reporter;
        sendingMessage.AddToList(reporter);
    }

    public void BuildPriority(Priority priority)
    {
        Priority = priority;
    }

    public void BuildEstimationTime(int estimationTime)
    {
        EstimationTime = estimationTime;
    }
    public void BuildSubTasks(TaskHistory subTask)
    {
        SubTasks.Add(subTask);
    }

    private Task1 Build1()
    {
        return new Task1()
        {
            CreationDate = DateTime.Now,
            Title = Title,
            Description = Description,
            Assignee = Assignee,
            Reporter = Reporter,
            Priority = Priority,
            EstimationTime = EstimationTime,
            SubTasks = SubTasks,
            SendingMessage = sendingMessage

        };
    }
    public TaskHistory Build() {
        return new TaskHistory(Build1());
}
}
