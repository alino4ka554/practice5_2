using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice5_2
{
    public partial class Form1 : Form
    {
        private Smartphone smart;
        public Smartphone Smart
        { 
            get
            {
                return smart;
            }
            set
            {
                smart = value;
            }
        }
        public Form1()
        {
            Smart = new Smartphone("Xiaomi", "Redmi", 2050, 8, 6, RAM_type.DDR4, 256, OS.Android, 8695452175525633);
            
            InitializeComponent();
            printSmart(Smart);
        }

        public void printSmart(Smartphone smart) 
        {
            this.textBox1.Text = $"{Smart.Firm} {Smart.Model}";
            this.textBox2.Text = $"{Smart.HzValue}";
            this.textBox3.Text = $"{Smart.Core}";
            this.textBox4.Text = $"{Smart.RAMSize}";
            this.textBox5.Text = $"{Smart.RAMType.ToString()}";
            this.textBox6.Text = $"{Smart.SecondaryMemory / 1024}";
            this.label13.Text = $"Выбранная ОС: {Smart.OperatingSystem.ToString()}";
            this.textBox7.Text = $"{Smart.IMEI}";
            this.label14.Text = $"Свободного места хватит для\n   установки {Smart.average_num_apps_for_free_mem()} приложений";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string appName = textBox8.Text;
                int appSize = Convert.ToInt32(textBox9.Text);
                Smart.InstallApp(appName, appSize);
                Smart.ExamAppPrint(); //проверка на наличие приложений на смартфоне
                Console.WriteLine("Список установленных приложений:");
                string apps = $"- {appName} ({appSize} Мб)";
                listBox2.Items.Add(apps);
                printSmart(Smart);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string appName = textBox8.Text;
                int appSize = 0;
                foreach (var app in Smart.apps)
                {
                    if (app.Key == appName) appSize = Convert.ToInt32(app.Value);
                }
                if (Smart.DeleteApp(appName) == true)
                {
                    string apps = $"- {appName} ({appSize} Мб)";
                    listBox2.Items.Remove(apps);
                }
                printSmart(Smart);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Smart.hard_reset() == true)
                {
                    listBox2.Items.Clear();
                    printSmart(Smart);
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = listBox1.SelectedItem.ToString();
            Smart.OperatingSystem = (OS)Enum.Parse(typeof(OS), type);
            printSmart(Smart);
        }
    }
}

