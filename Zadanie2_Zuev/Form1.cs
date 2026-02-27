using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Zadanie2_Zuev.company;

namespace Zadanie2_Zuev
{
    public partial class Form1 : Form
    {

        List<Department> department = new List<Department>()

        {

            new Department { Name = "Отдел закупок", Reg ="Германия" },

            new Department { Name = "Отдел продаж", Reg ="Испания" },

            new Department { Name = "Отдел маркетинга", Reg ="Испания" }

        };

        List<Employ> employes = new List<Employ>()

        {

            new Employ {Name="Иванов", department =" Отдел закупок "},

            new Employ {Name="Петров", department =" Отдел закупок "},

            new Employ {Name="Сидоров", department =" Отдел продаж "},

            new Employ {Name="Лямин", department =" Отдел продаж "},

            new Employ {Name="Сидоренко", department =" Отдел маркетинга "},

            new Employ {Name="Кривоносов", department =" Отдел продаж "}

        };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var groupedByRegion = from emp in employes
                                  join dep in department on emp.department.Trim() equals dep.Name
                                  group emp by dep.Reg into regionGroup
                                  select new { Region = regionGroup.Key, Employees = regionGroup };


            listBox1.Items.Clear();
            listBox1.Items.Add($"---Сгруппированный список по регионам---");
            listBox1.Items.Add($"");
            foreach (var region in groupedByRegion)
            {

                listBox1.Items.Add($"--- {region.Region} ---");
                foreach (var emp in region.Employees)
                {
                    listBox1.Items.Add($"  {emp.Name}");
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var employeesFromIRegion = from emp in employes
                                       join dep in department on emp.department.Trim() equals dep.Name
                                       where dep.Reg.StartsWith("И")
                                       select emp.Name;


            listBox1.Items.Clear();
            listBox1.Items.Add("сотрудники, регион которых начинается на «И».");
            listBox1.Items.Add($"");
            foreach (var name in employeesFromIRegion)
            {
                listBox1.Items.Add(name);
            }
        }

        
    }
}
