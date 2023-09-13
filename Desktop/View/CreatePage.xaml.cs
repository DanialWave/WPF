using Desktop.Model;
using Desktop.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop.View
{
    /// <summary>
    /// Логика взаимодействия для CreatePage.xaml
    /// </summary>
    public partial class CreatePage : Page
    {
        private string _name;
        public CreatePage(string name = "")
        {
            InitializeComponent();
            _name = name;
        }
        private void CreateTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                if (Category.Text != "")
                {
                    if (Description.Text != "")
                    {
                        if (DatePicker.Text != "")
                        {
                            if (Time.Text != "")
                            {
                                var task = new TaskModel
                                {
                                    Id = 0,
                                    Title = Name.Text,
                                    Category = Category.Text,
                                    Content = Description.Text,
                                    Date = DatePicker.Text,
                                    Time = Time.Text,
                                    IsChecked = false,
                                    BackgroundColor = Brushes.White,
                                    ColorBorder = Brushes.Blue
                                };

                                TasksRepository.AddTask(task);
                                var mainPage = new MainPage(_name);
                                NavigationService.Navigate(mainPage);
                            }
                            else
                            {
                                MessageBox.Show("Неправильный формат ввода времени");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неправильный формат ввода даты");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Поле описания пустое");
                    }
                }
                else
                {
                    MessageBox.Show("Поле категории пустое");
                }
            }
            else
            {
                MessageBox.Show("Поле названия задачи пустое");
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            var page = new MainPage();
            NavigationService.Navigate(page);
        }
    }
}
