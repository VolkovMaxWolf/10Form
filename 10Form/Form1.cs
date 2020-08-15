using System;
using System.IO;
using System.Windows.Forms;

namespace _10Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("C:\\temp"))
            {
                Directory.CreateDirectory("C:\\temp");
            }
            Directory.CreateDirectory("C:\\temp\\K1");
            Directory.CreateDirectory("C:\\temp\\K2");

            StreamWriter sw = new StreamWriter("C:\\temp\\K1\\t1.txt");
            sw.Write("Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");
            sw.Close();

            sw = new StreamWriter("C:\\temp\\K1\\t2.txt");
            sw.Write("Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");
            sw.Close();

            sw = new StreamWriter("C:\\temp\\K2\\t3.txt");
            StreamReader sr = new StreamReader("C:\\temp\\K1\\t1.txt");
            sw.WriteLine(sr.ReadToEnd());
            sr.Close();
            sr = new StreamReader("C:\\temp\\K1\\t2.txt");
            sw.WriteLine(sr.ReadToEnd());
            sr.Close();
            sw.Close();

            DirectoryInfo directoryInfK1 = new DirectoryInfo("C:\\temp\\K1");
            DirectoryInfo directoryInfK2 = new DirectoryInfo("C:\\temp\\K2");

            FileInfo[] fileInf = directoryInfK1.GetFiles();
            foreach (FileInfo fI in fileInf)
            {
                textBox1.AppendText("Конечный путь: " + fI.FullName.ToString() + " Атрибуты: " + fI.Attributes.ToString() + " Время создания: " + fI.CreationTimeUtc.ToString());
                textBox1.AppendText(Environment.NewLine);
            }
            fileInf = directoryInfK2.GetFiles();
            foreach (FileInfo fI in fileInf)
            {
                textBox2.AppendText("Конечный путь: " + fI.FullName.ToString() + " Атрибуты: " + fI.Attributes.ToString() + " Время создания: " + fI.CreationTimeUtc.ToString());
                textBox2.AppendText(Environment.NewLine);
            }
            Console.WriteLine("--------------------");
            
            File.Move("C:\\temp\\K1\\t2.txt", "C:\\temp\\K2\\t2.txt");
            
            File.Copy("C:\\temp\\K1\\t1.txt", "C:\\temp\\K2\\t1.txt");
            
            Directory.Move("C:\\temp\\K2", "C:\\temp\\ALL");
            Directory.Delete("C:\\temp\\K1", true);
            
            DirectoryInfo directoryInfo = new DirectoryInfo("C:\\temp\\ALL");
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            foreach (FileInfo fI in fileInfo)
            {
                textBox3.AppendText("Конечный путь: " + fI.FullName.ToString() + " Атрибуты: " + fI.Attributes.ToString() + " Время создания: " + fI.CreationTimeUtc.ToString());
                textBox3.AppendText(Environment.NewLine);
            }

        }
    }
}
