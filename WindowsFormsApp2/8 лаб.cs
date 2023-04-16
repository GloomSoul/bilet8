using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class EmployeeSearchForm1 : System.Windows.Forms.Form
    {
        private readonly Employee[] employees;

        public EmployeeSearchForm1()
        {
            InitializeComponent();

            // Создание массива сотрудников и заполнение его данными
            employees = new Employee[]
            {
                new Employee { Name = "Иван", Surname = "Иванов", Position = "Менеджер", HireDate = new DateTime(2020, 1, 1) },
                new Employee { Name = "Петр", Surname = "Петров", Position = "Программист", HireDate = new DateTime(2021, 5, 1) },
                new Employee { Name = "Сергей", Surname = "Сергеев", Position = "Дизайнер", HireDate = new DateTime(2019, 8, 1) },
            };
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string surname = surnameTextBox.Text;
            string position = positionTextBox.Text;
            DateTime hireDate = hireDateTimePicker.Value;

            Employee[] results;

            if (!string.IsNullOrEmpty(surname))
            {
                results = EmployeeHelper.FindBySurname(employees, surname);
            }
            else if (!string.IsNullOrEmpty(position))
            {
                results = EmployeeHelper.FindByPosition(employees, position);
            }
            else if (hireDate != DateTime.MinValue) // проверка на изменение значения DateTimePicker
            {
                results = EmployeeHelper.FindByHireDate(employees, hireDate);
            }
            else
            {
                results = new Employee[0];
            }

            resultsListBox.Items.Clear();

            foreach (Employee employee in results)
            {
                resultsListBox.Items.Add($"{employee.Surname} {employee.Name}, {employee.Position}, {employee.HireDate.ToShortDateString()}");
            }
        }


        private void surnameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private void positionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton_Click(sender, e);
                e.Handled = true;
            }
        }

        private void hireDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton_Click(sender, e);
                e.Handled = true;
            }
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
    }

    public static class EmployeeHelper
    {
        public static Employee[] FindBySurname(Employee[] employees, string surname)
        {
            return employees.Where(e => e.Surname == surname).ToArray();
        }

        public static Employee[] FindByPosition(Employee[] employees, string position)
        {
            return employees.Where(e => e.Position == position).ToArray();
        }

        public static Employee[] FindByHireDate(Employee[] employees, DateTime hireDate)
        {
            return employees.Where(e => e.HireDate == hireDate).ToArray();
        }
    }
}