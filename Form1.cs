using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace FileManager
{
    public partial class Form1 : Form
    {
        public int count =0;
        public Form1()
        {
            InitializeComponent();

            string name;
            bool end = true;
            //do
            //{
            //    name = Console.ReadLine();

            //    switch (name)
            //    {
            //        case "Help":
            //            Console.WriteLine("Info -Выводит список файлов в каталоге\nCD-Переход в каталог\nDel-Удаление файла по имени\nDelM-Удаление файла по маске\nCrea-Создание файла\nCopy-Копирование файла");
            //            break;
            //        case "Info":
            //            List<string> q = new List<string>();
            //            Console.WriteLine("Введите путь каталога");
            //            string p = Console.ReadLine();
            //            int s = 0;
            //            DirectoryInfo dir = new DirectoryInfo(p);
            //            foreach (var item in dir.GetFiles())
            //            {
            //                q.Add(item.Name);
            //                s++;
            //            }
            //            bool flag = true;
            //            while (flag)
            //            {
            //                flag = false;
            //                for (int k = 0; k < s - 1; ++k)
            //                    if (q[k].CompareTo(q[k + 1]) > 0)
            //                    {
            //                        string buf = q[k];
            //                        q[k] = q[k + 1];
            //                        q[k + 1] = buf;
            //                        flag = true;
            //                    }
            //            }
            //            for (int k = 0; k < s; ++k)
            //                Console.WriteLine("{0} ", q[k]);
            //            break;


            //        case "CD":
            //            string filePath = "E:\\Новая папка\\Новая папка\\Новая папка";
            //            string directoryName;
            //            int i = 0;

            //            while (filePath != null)
            //            {
            //                directoryName = Path.GetDirectoryName(filePath);
            //                Console.WriteLine("GetDirectoryName('{0}') returns '{1}'",
            //                    filePath, directoryName);
            //                filePath = directoryName;
            //                if (i == 1)
            //                {
            //                    filePath = directoryName + @"\";
            //                }
            //                i++;
            //            }
            //            break;

            //        case "Del":
            //            string DeleteThis;
            //            string pyt;
            //            Console.WriteLine("Введите имя");
            //            DeleteThis = Console.ReadLine();
            //            Console.WriteLine("Введите путь");
            //            pyt = Console.ReadLine();
            //            string[] Files = Directory.GetFiles(pyt);

            //            foreach (string file in Files)
            //            {
            //                if (file.ToUpper().Contains(DeleteThis.ToUpper()))
            //                {
            //                    File.Delete(file);
            //                }
            //            }
            //            break;

            //        case "DelM":
            //            string DeleteThis1;
            //            string pyt1;
            //            Console.WriteLine("Введите маску");
            //            DeleteThis1 = Console.ReadLine();
            //            Console.WriteLine("Введите путь");
            //            pyt1 = Console.ReadLine();
            //            string[] files = Directory.GetFiles(pyt1, DeleteThis1);
            //            Console.WriteLine("Всего файлов {0}.", files.Length);
            //            foreach (string f in files)
            //            {
            //                Console.WriteLine(f);
            //                File.Delete(f);
            //            }

            //            break;

            //        case "Crea":
            //            string pyt2;
            //            Console.WriteLine("Введите путь куда создать и имя файла");
            //            pyt2 = Console.ReadLine();
            //            File.Create(pyt2);
            //            break;

            //        case "Copy":
            //            Console.WriteLine("Введите путь копируемого файла");
            //            string pathToFile = Console.ReadLine();
            //            Console.WriteLine("Введите путь куда копировать");
            //            string pathToFile1 = Console.ReadLine();
            //            File.Copy(pathToFile, pathToFile1, true);
            //            break;
            //        case "Exit":
            //            end = false;
            //            break;

            //        default:
            //            Console.WriteLine("Введена не правильная команда");
            //            break;
            //    }
            //} while (end != false);
            listView1.SmallImageList = imageList1;
        }


        private void Open_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            if (count == 0)
            {
                string path = textBox1.Text;
                if (path.EndsWith(".exe") || path.EndsWith(".txt") || path.EndsWith(".jpeg") || path.EndsWith(".png") || path.EndsWith(".jpg"))
                {

                    System.Diagnostics.Process.Start(path);
                    string text = textBox1.Text;
                    text = text.Substring(0, text.LastIndexOf(@"\"));
                    text += @"\";
                    textBox1.Text = text;
                    Open_Click(sender, e);
                }
                if ( path.EndsWith(@"\")) 
                {
                    
                    // получаем все файлы
                    string[] files = Directory.GetFiles(path);
                    string[] folders = Directory.GetDirectories(path);
                    // перебор полученных файлов
                    foreach (string file in files)
                    {
                        ListViewItem lvi = new ListViewItem();
                        // установка названия файла
                        lvi.Text = file.Remove(0, file.LastIndexOf('\\') + 1);
                        lvi.ImageIndex = 1; // установка картинки для файла
                                            // добавляем элемент в ListView
                        listView1.Items.Add(lvi);
                    }
                    foreach (string folder in folders)
                    {
                        ListViewItem lvi = new ListViewItem();
                        // установка названия файла
                        lvi.Text = folder.Remove(0, folder.LastIndexOf('\\') + 1);
                        lvi.ImageIndex = 0; // установка картинки для файла
                                            // добавляем элемент в ListView
                        listView1.Items.Add(lvi);
                    }
                    button1.Enabled = false;
                }
                else
                {
                    textBox1.Text += @"\";
                    Open_Click(sender, e);
                }
                
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
        private void listView1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
        private void ItemActive(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].ImageIndex == 0)
            {
                textBox1.Text += listView1.SelectedItems[0].Text;

            }
            if (listView1.SelectedItems[0].ImageIndex == 1)
            {
                textBox1.Text += listView1.SelectedItems[0].Text;
            }
        }

        private void CD_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            text = text.Substring(0, text.LastIndexOf(@"\"));
            text = text.Substring(0, text.LastIndexOf(@"\"));
            text += @"\";
            textBox1.Text = text;
            Open_Click(sender, e);
        }
    }
}
