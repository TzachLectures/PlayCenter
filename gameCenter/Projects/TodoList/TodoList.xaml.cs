using gameCenter.Projects.TodoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace gameCenter.Projects.TodoList
{
    /// <summary>
    /// Interaction logic for TodoList.xaml
    /// </summary>
    public partial class TodoList : Window
    {
        private TodoListModel _todoList;

        public TodoList()
        {
            InitializeComponent();
            InitializeTasks();

        }

        //InitializeTasks -> 
        //1. create new TodoListModel
        //2. add 2 static tasks
        //3. listTasks.ItemsSource = _todoList.Tasks;

        private void InitializeTasks()
        {
            _todoList = new TodoListModel();
            _todoList.AddNewTask(new TodoTask(1, "To do homework"));
            _todoList.AddNewTask(new TodoTask(2, "Complete the project"));
            listTasks.ItemsSource = _todoList.Tasks;
        }

        //OnTaskToggled
        //get the task (and task id) from the checkBox.DataContext (the DataContext is actually the TodoTask object)
        //excute the toggle function from the model
        private void OnTaskToggled(object sender, RoutedEventArgs e)
        {
          if(sender is CheckBox checkBox && checkBox.DataContext is TodoTask task)
            {
                _todoList.ToggleTaskIsComplete(task.Id);
            }
        }


        //OnTextBlockMouseLeftButtonDown
        //hide the textBlock
        //show the text Box & save button
        //show the textBlock.Text in the task description

        private void OnTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          if(e.ClickCount == 2)
            {
                //get the elements
                TextBlock textBlock = sender as TextBlock;
                StackPanel parent = textBlock.Parent as StackPanel;
                TextBox editTextBox = parent.FindName("editTaskDescription") as TextBox;
                Button btnSave= parent.FindName("btnSave") as Button;
                //hide the textBlock
                textBlock.Visibility = Visibility.Collapsed;
                //show the text Box & save button
                editTextBox.Visibility= Visibility.Visible;
                btnSave.Visibility=Visibility.Visible;
                //show int the TextBox.Text the task description
                editTextBox.Text = textBlock.Text;
            }
        }

        private void OnSaveEdit(object sender, RoutedEventArgs e)
        {
            //get the elements
            Button btnSave = sender as Button;
            StackPanel parent = btnSave.Parent as StackPanel;
            TextBox editTextBox = parent.FindName("editTaskDescription") as TextBox;
            TextBlock textBlock = parent.FindName("txtTaskDescription") as TextBlock;
            TodoTask task = textBlock.DataContext as TodoTask;

            //Hide the TextBox
            editTextBox.Visibility = Visibility.Collapsed;
            //Hide the save button
            btnSave.Visibility = Visibility.Collapsed;
            //Show the TextBlock
            textBlock.Visibility = Visibility.Visible;

            //take the TextBox.Text and put in the TextBlock.Text
            textBlock.Text = editTextBox.Text;
            _todoList.UpdateTask(task.Id, editTextBox.Text);
        }


        private void OnAddTask(object sender, RoutedEventArgs e)
        {
            //if txtNewTask.Text!=null || empty string
            if (!string.IsNullOrWhiteSpace(txtNewTask.Text))
            {
                //Create the new Task 
                TodoTask newTask = new TodoTask(_todoList.Tasks.Count + 1, txtNewTask.Text);
                _todoList.AddNewTask(newTask);
                txtNewTask.Clear();
            }

        }
    }
}


