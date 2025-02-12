public class TodoList
{
    private List<Task> _tasks = new List<Task>(); // Stores the list of tasks
    private int _selectedTaskIndex = 0; // Tracks the currently selected task

    public Task CurrentTask => _tasks[_selectedTaskIndex]; // Gets the currently selected task

    public int Length => _tasks.Count; // Returns the total number of tasks

    // Swaps two tasks at the specified indices
    // Assumes valid indices since it's only called from methods that perform bounds checking
    public void SwapTasksAt(int i, int j)
    {
        Task temp = _tasks[i];
        _tasks[i] = _tasks[j];
        _tasks[j] = temp;
    }

    // Wraps the selected index around if it goes out of bounds
    private void WrappedIndex(int i)
    {
        if (i < 0)
        {
            _selectedTaskIndex = _tasks.Count - 1;
        }
        else if (i >= _tasks.Count)
        {
            _selectedTaskIndex = 0;
        }
        else
        {
            _selectedTaskIndex = i;
        }
    }

    // Returns the index of the previous task
    private int PreviousIndex() => _selectedTaskIndex - 1;

    // Returns the index of the next task
    private int NextIndex() => _selectedTaskIndex + 1;

    // Selects the previous task, wrapping around if necessary
    public void SelectPrevious() => WrappedIndex(PreviousIndex());

    // Selects the next task, wrapping around if necessary
    public void SelectNext() => WrappedIndex(NextIndex());

    // Swaps the currently selected task with the previous one
    public void SwapWithPrevious()
    {
        if (_selectedTaskIndex > 0)
        {
            SwapTasksAt(_selectedTaskIndex, PreviousIndex());
            SelectPrevious();
        }
    }

    // Swaps the currently selected task with the next one if possible
    // Future improvement: Implement a better selection mechanism for swapping
    public void SwapWithNext()
    {
        if (_selectedTaskIndex < _tasks.Count - 1)
        {
            SwapTasksAt(_selectedTaskIndex, NextIndex());
            SelectNext();
        }
    }

    // Inserts a new task with the given title
    public void Insert(string title) => _tasks.Add(new Task(title));

    // Updates the title of the currently selected task
    public void UpdateSelectedTitle(string title)
    {
        if (_tasks.Count > 0)
        {
            _tasks[_selectedTaskIndex].SetTitle(title);
        }
    }

    // Deletes the currently selected task, adjusting the selected index if needed
    public void DeleteSelected()
    {
        if (_tasks.Count > 0)
        {
            _tasks.RemoveAt(_selectedTaskIndex);
            if (_selectedTaskIndex >= _tasks.Count)
            {
                _selectedTaskIndex = _tasks.Count - 1;
            }
        }
    }

    // Retrieves the task at the given index
    public Task GetTask(int i) => _tasks[i];
}
