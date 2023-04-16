using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private Employee[] employees;
        public Form1()
        {
            InitializeComponent();

            employees = new Employee[] {
                new Employee("Иванов", "Директор", new DateTime(2010, 1, 1)),
                new Employee("Петров", "Менеджер", new DateTime(2015, 5, 1)),
                new Employee("Сидоров", "Разработчик", new DateTime(2020, 10, 1))
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchPosition = positionTextBox.Text;
            Employee foundEmployee = Array.Find(employees, emp => emp.Position == searchPosition);

            if (foundEmployee != null)
            {
                MessageBox.Show($"Найден сотрудник: {foundEmployee}");
            }
            else
            {
                MessageBox.Show($"Сотрудник с должностью {searchPosition} не найден.");
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string searchLastName = lastNameTextBox.Text;
            Employee foundEmployee = Array.Find(employees, emp => emp.LastName == searchLastName);

            if (foundEmployee != null)
            {
                MessageBox.Show($"Найден сотрудник: {foundEmployee}");
            }
            else
            {
                MessageBox.Show($"Сотрудник с фамилией {searchLastName} не найден.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime searchHireDate = hireDateDateTimePicker.Value.Date;
            Employee foundEmployee = Array.Find(employees, emp => emp.HireDate.Date == searchHireDate);

            if (foundEmployee != null)
            {
                MessageBox.Show($"Найден сотрудник: {foundEmployee}");
            }
            else
            {
                MessageBox.Show($"Сотрудник, принятый на работу {searchHireDate.ToShortDateString()}, не найден.");
            }
        }

        public class Employee
        {
            public string LastName { get; }
            public string Position { get; }
            public DateTime HireDate { get; }

            public Employee(string lastName, string position, DateTime hireDate)
            {
                LastName = lastName;
                Position = position;
                HireDate = hireDate;
            }

            public override string ToString()
            {
                return $"{LastName}, {Position}, {HireDate.ToShortDateString()}";
            }
        }

    }
}
