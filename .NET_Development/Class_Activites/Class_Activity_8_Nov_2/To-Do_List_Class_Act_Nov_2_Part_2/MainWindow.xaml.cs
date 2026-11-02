using System.Windows;

namespace To_Do_List_Class_Act_Nov_2_Part_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class TodoItem
    {
        public string Title { get; set; } = "";
        public int Completion { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Each TodoItem represents one task.
            // Title stores the task name, while Completion stores a percentage from 0 to 100.
            List<TodoItem> items = new List<TodoItem>
            {
                new TodoItem
                {
                    Title = "C# Project",
                    Completion = 0
                },
                new TodoItem
                {
                    Title = "C# Lab 6",
                    Completion = 20
                },
                new TodoItem
                {
                    Title = "C# Course",
                    Completion = 75
                }
            };

            icTodoList.ItemsSource = items;
        }
    }
}