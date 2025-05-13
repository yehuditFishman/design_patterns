using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinallProject.ChainOfResponsibility;
using FinallProject.Enums;
using FinallProject.Models;
using FinallProject.Observer;
using FinallProject.State;

namespace FinallProject.Memento;

public class TaskHistory
{
    private Task1 _task;

    public List<TaskHistory> HistoryTasks { get; set; }
    public TaskHistory(Task1 task)
    {
        _task = task;
        _task.Status = new StatusToDo(this);
        HistoryTasks = new List<TaskHistory>();
    }

    public void ChangeStatus(BaseHandler baseHandler)
    {
        HistoryTasks.Add(CreateBackUp());
        if(baseHandler.Handle(_task, _task.Assignee))
            _task.Changes("status change");
        else Console.WriteLine("you can't change status");
    }
    public void ChangeAssign(User assign)
    {
        HistoryTasks.Add(CreateBackUp());
        _task.Assignee = assign;
        _task.SendingMessage.RemoveFromList(_task.Assignee);
        _task.SendingMessage.AddToList(assign);
        _task.Changes("assign change");

    }
    public void ChangeReporter(User reporter)
    {
        HistoryTasks.Add(_task.CreateBackUp());
        _task.SendingMessage.RemoveFromList(_task.Reporter);
        _task.Reporter = reporter;
        _task.SendingMessage.AddToList(reporter);
        _task.Changes("reporter change");
    }
    public void ChangeLoggedTime(int time)
    {
        HistoryTasks.Add(CreateBackUp());
        _task.LoggedTime = time;
        _task.Changes("logged time change");
    }
    public void ChangePriority(Priority priority)
    {
        HistoryTasks.Add(_task.CreateBackUp());
        _task.Priority = priority;
        _task.Changes("priority change");
    }
    public void Undo()
    {
        var memento = HistoryTasks[HistoryTasks.Count - 1];
        HistoryTasks.RemoveAt(HistoryTasks.Count - 1);
        _task.Restore(memento._task);
    }

    public void CalculateLoggedTime()
    {
        _task.LoggedTime = InnerCalculateLoggedTime();
    }

    public void CalculateEstimationTime()
    {
        _task.EstimationTime = InnerCalculateEstimationTime();
    }
    public override string ToString()
    {
        return _task.ToString();
    }

    private int InnerCalculateEstimationTime()
    {
        int estimationTime = _task.EstimationTime;
        if (_task.SubTasks != null)
            foreach (var task in _task.SubTasks)
                estimationTime += task.InnerCalculateEstimationTime();
        return estimationTime;
    }

    public TaskHistory CreateBackUp()
    {
       return _task.CreateBackUp();
    }
    private int InnerCalculateLoggedTime()
    {
        int loggedTime = _task.LoggedTime;
        if (_task.SubTasks != null)
            foreach (var task in _task.SubTasks)
                loggedTime += task.InnerCalculateLoggedTime();
        return loggedTime;
    }
    public void ChangeState(IStatus status)
    {
        _task.Status = status;
    }
}
