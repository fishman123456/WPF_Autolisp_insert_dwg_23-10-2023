using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.IO;
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                string sbor = Number_String.file_block_ins() + TextBox_increment_name.Text + Number_String.file_block_ins_two();
                File.WriteAllText(saveFileDialog.FileName, sbor);
                saveFileDialog.InitialDirectory = @"F:\Проекты\_Чегдомын отделение флотации Главный корпус";
                saveFileDialog.Filter = "Text file (*.lsp)|*.lsp";
            }


            // метод для создания файла

        }

    }
}
