using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace WPF_Autolisp_insert_dwg_23_10_2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        // метод для записи в файл lisp
        private void Button_Add_Number_Click(object sender, RoutedEventArgs e)
        {

            // старая строка для сборки
            //string sbor = Number_String.file_block_ins()+Number_String.file_block_ins_one() +
            //    TextBox_increment_name.Text+Number_String.file_block_ins_two()+
            //    Number_String.file_block_ins_three();


            string sbor = Number_String.file_block_ins();

            // создаём списки для textbox для первого - добавим в имя файла, для второго добавим приращение по координате x
            string[] separator = { "\n", "\r" };
            List<string> addfname = TextBox_increment_name.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> addicrx = TextBox_increment_x_tostring.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();
            // пришлось ещё и список для строк добавить
           List <string> foriach = new List<string>();
            int i = 0;
            // перебираем содержимое текстбоксов
            foreach (var item in addfname)
            {
                foriach.Add($"{Number_String.file_block_ins_one()}{item}{Number_String.file_block_ins_one_two()}" +
                    $"{addicrx[i].ToString()}{Number_String.file_block_ins_two()}");
                foriach.Add("\n");
                i++;    
            }

            foreach (var item in foriach)
            {
                sbor += item;
            }
            sbor += Number_String.file_block_ins_three();

            // диалог сохранения файла lisp
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "LSP Files(*.lsp)|*.lsp|All(*.*)|*";
            dialog.RestoreDirectory = true;
            dialog.InitialDirectory = dialog.FileName;
            //SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == true)
            {
                string path = dialog.FileName;
                StreamWriter sw = new StreamWriter(path, false);
                using (sw)
                {

                    sw.Write(sbor);
                }
            }
            sbor = "";
        }

        // кнопка добавления в текстбокс приращения
        private void Button_Add_increment_Click(object sender, RoutedEventArgs e)
        {
            // расделителем может служить один символ, поэтому строку создаём, т е массив символов
            string[] separator = { "\n", "\r" };
            // добавляем данные в список из текстбокса TextBox_Lay_name 
            string[] mass_textBox_Lay_name = TextBox_increment_name.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int xincrement = 0;
            TextBox_increment_x_tostring.Clear();
            foreach (var items in mass_textBox_Lay_name)
            {
                //TextBox_increment_x.Text = "Ссылок - " + TextBox_increment_x.LineCount.ToString();

                xincrement += int.Parse(TextBox_increment_x.Text);
                TextBox_increment_x_tostring.Text += xincrement + "\n";

            }
        }
    }
}
