public class Task
{
    private string title = "empty"; // Stores the task title, default is "empty"
    
    // Property to get or set the task title
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    
    private CompletionStatus _status; // Stores the task completion status
    
    // Property to get or set the task status
    public CompletionStatus Status
    {
        get { return _status; }
        set { _status = value; }
    }

    // Constructor to initialize a task with a given title, default status is NotDone
    public Task(string title)
    {
        this.title = title;
        _status = CompletionStatus.NotDone;
    }

    // Method to update the task title
    public void SetTitle(string title)
    {
        this.title = title;
    }

    // Method to toggle the task status between Done and NotDone
    public void ToggleStatus()
    {
        if (_status == CompletionStatus.NotDone)
        {
            _status = CompletionStatus.Done;
        }
        else
        {
            _status = CompletionStatus.NotDone;
        }
    }
}

// Enum to define possible completion statuses for a task
public enum CompletionStatus
{
    NotDone,
    Done
}
