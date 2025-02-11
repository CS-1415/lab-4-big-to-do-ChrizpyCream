﻿class TodoListApp
{
    private TodoList _tasks;
    private bool _showHelp = true;
    private bool _insertMode = true;
    private bool _quit = false;

    public TodoListApp(TodoList tasks)
    {
        _tasks = tasks;
    }

    public void Run()
    {
        while (!_quit)
        {
            Console.Clear();
            Display();
            ProcessUserInput();
        }
    }
