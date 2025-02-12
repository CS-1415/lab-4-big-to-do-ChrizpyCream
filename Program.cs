class TodoListApp
{
    private TodoList _tasks; // Stores the list of tasks
    private bool _showHelp = true; // Determines if help instructions should be displayed
    private bool _insertMode = true; // Determines if the app is in insert mode
    private bool _quit = false; // Determines if the app should exit

    // Constructor to initialize the TodoListApp with a list of tasks
    public TodoListApp(TodoList tasks)
    {
        _tasks = tasks;
    }

    // Main loop to run the application
    public void Run()
    {
        while (!_quit)
        {
            Console.Clear(); // Clear the console for better readability
            Display(); // Display tasks and help if enabled
            ProcessUserInput(); // Handle user input
        }
    }

    // Displays tasks and help menu if enabled
    public void Display()
    {
        DisplayTasks(); // Display the task list
        if (_showHelp)
        {
            DisplayHelp(); // Display help instructions
        }
    }

    // Displays a visual separator
    public void DisplayBar()
    {
        Console.WriteLine("----------------------------");
    }

    // Creates a formatted row for a task
    public string MakeRow(int i)
    {
        Task task = _tasks.GetTask(i);
        string arrow = "  "; // Default arrow spacing
        if (task == _tasks.CurrentTask) arrow = "->"; // Mark the selected task
        string check = " "; // Default unchecked task
        if (task.Status == CompletionStatus.Done) check = "X"; // Mark completed task
        return $"{arrow} [{check}] {task.Title}";
    }

    // Displays all tasks in the list
    public void DisplayTasks()
    {
        DisplayBar();
        Console.WriteLine("Tasks:");
        for (int i = 0; i < _tasks.Length; i++)
        {
            Console.WriteLine(MakeRow(i)); // Print each task formatted as a row
        }
        DisplayBar();
    }

    // Displays help/instructions for the user
    public void DisplayHelp()
    {
        Console.WriteLine(
@"Instructions:
   h: show/hide instructions
   ↕: select previous or next task (wrapping around at the top and bottom)
   ↔: reorder task (swap selected task with previous or next task)
   space: toggle completion of selected task
   e: edit title
   i: insert new tasks
   delete/backspace: delete task");
        DisplayBar();
    }

    // Prompts user to enter a task title
    private string GetTitle()
    {
        Console.WriteLine("Please enter task title (or [enter] for none): ");
        return Console.ReadLine()!; // Read user input
    }

    // Processes user input to navigate and modify the task list
    public void ProcessUserInput()
    {
        // This function is quite large; consider refactoring into a separate InputHandler class
        if (_insertMode)
        {
            string taskTitle = GetTitle(); // Get user input for a new task
            if (taskTitle.Length == 0)
            {
                _insertMode = false; // Exit insert mode if no input is given
            }
            else
            {
                _tasks.Insert(taskTitle); // Add new task to the list
            }
        }
        else
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape:
                    _quit = true; // Exit the application
                    break;
                case ConsoleKey.UpArrow:
                    _tasks.SelectPrevious(); // Move selection up
                    break;
                case ConsoleKey.DownArrow:
                    _tasks.SelectNext(); // Move selection down
                    break;
                case ConsoleKey.LeftArrow:
                    _tasks.SwapWithPrevious(); // Swap selected task with previous
                    break;
                case ConsoleKey.RightArrow:
                    _tasks.SwapWithNext(); // Swap selected task with next
                    break;
                case ConsoleKey.I:
                    _insertMode = true; // Enter insert mode
                    break;
                case ConsoleKey.E:
                    _tasks.CurrentTask.Title = GetTitle(); // Edit selected task title
                    break;
                case ConsoleKey.H:
                    _showHelp = !_showHelp; // Toggle help display
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    _tasks.CurrentTask.ToggleStatus(); // Toggle task completion
                    break;
                case ConsoleKey.Delete:
                case ConsoleKey.Backspace:
                    _tasks.DeleteSelected(); // Delete selected task
                    break;
                default:
                    break;
            }
        }
    }
}

// Main program entry point
class Program
{
    static void Main()
    {
        new TodoListApp(new TodoList()).Run(); // Initialize and start the TodoList app
    }
}
