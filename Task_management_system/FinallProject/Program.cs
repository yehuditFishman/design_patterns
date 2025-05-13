using FinallProject.ChainOfResponsibility;
using FinallProject.Enums;
using FinallProject.Memento;
using FinallProject.Models;
using FinallProject.State;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;


User reporter = new User("Nechami","nnn@gmail.com",Role.Manager);
User assign = new User("Yehudit", "yyy@gmail.com", Role.QA);
User reporter1 = new User("Rachel", "rrr@gmail.com", Role.Developer);
User assign1 = new User("Dani", "ddd@gmail.com", Role.QA);
User reporter2 = new User("Ari", "aaa@gmail.com", Role.Manager);
User assign2 = new User("Sari", "sss@gmail.com", Role.Developer);

var taskBuilder = new BuilderTask("Implement REST API", "Create endpoints for user management", assign);
var taskBuilder1 = new BuilderTask("Fix bug in login module", "Investigate and resolve the login issue", assign1);
var taskBuilder2 = new BuilderTask("Write unit tests", "Add unit tests for the data processing functions", assign2);
var taskBuilder3 = new BuilderTask("Refactor legacy code", "Improve the readability and maintainability of the existing code", assign);
var taskBuilder4 = new BuilderTask("Update documentation", "Ensure all API endpoints are documented in the wiki", assign1);


taskBuilder.BuildEstimationTime(27);
taskBuilder.BuildReporter(reporter2);
taskBuilder.BuildPriority(Priority.High);
TaskHistory task = taskBuilder.Build();

taskBuilder1.BuildPriority(Priority.Low);
taskBuilder1.BuildEstimationTime(4);
taskBuilder1.BuildReporter(reporter1);
TaskHistory task1 = taskBuilder1.Build();

taskBuilder2.BuildPriority(Priority.High);
taskBuilder2.BuildReporter(reporter);
taskBuilder2.BuildSubTasks(task);
taskBuilder2.BuildSubTasks(task1);
TaskHistory task2 = taskBuilder2.Build();


task2.CalculateEstimationTime();
Console.WriteLine(task2);

// to  Chain Of Responsibility
var dev = new Developer();
var manager = new Manager();
var qa = new QA();

manager.SetNext(dev);
dev.SetNext(qa);


task2.ChangePriority(Priority.Low);
task1.ChangeLoggedTime(5);
Console.WriteLine("........before change reporter........");
task.ChangeLoggedTime(4);
Console.WriteLine("........after change reporter........");
task.ChangeReporter(reporter1);
Console.WriteLine(task);
task.Undo();
Console.WriteLine(task);


task2.ChangeStatus(manager);
task2.ChangeStatus(manager);


