using System;
using System.Windows;

namespace WPF_Autolisp_insert_dwg_23_10_2023
{
    public class Number_String
    // строка для записи в файл
    {
        private static string file_block_ins_str = "";
        private static string file_block_ins_str_one = "";
        private static string file_block_ins_str_one_two = "";
        private static string file_block_ins_str_two = "";
        private static string file_block_ins_str_three = "";
        public static void CheckDate()
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Parse("01/01/2024");
            System.Windows.Window w1 = new System.Windows.Window();

            if (dt1.Date > dt2.Date)
            {
                MessageBox.Show("Your Application is Expire");
                // Выход из проложения добавил 12-07-2023. Чтобы порядок был....
                System.Windows.Application.Current.Shutdown();
                //w1.Close();
            }
            else
            {

                MessageBox.Show("Работайте до   " + dt2.ToString());
            }

        }

        // собираем строки для файла lisp
        public static string file_block_ins()
        {
            file_block_ins_str = "";
            file_block_ins_str += "(defun C:u_83( / dic edic)";
            file_block_ins_str += "\n(vl-load-com)\n";
            return file_block_ins_str;
        }
        // первую и вторую надо зациклить по кол-ву чисел в текстбоксе
        public static string file_block_ins_one()
        {
            //  file_block_ins_str_one += @";c:\Program Files\\AutoCAD 2009\AcadLsp\St_prof\Block\001.dwg - пример" + "\n";
            //file_block_ins_str_one += "\n;начало блока"+"\n";
            file_block_ins_str_one = "";
            file_block_ins_str_one += "(command \"_.xref\" \"\" \"";
            // строка для поиска файлов для ссылок 24-10-2023
            file_block_ins_str_one += @"F:\\Проекты\\_Чегдомын отделение флотации Главный корпус\\ГЛАВНЫЙ КОРПУС\\ТХ-6 листы в модели\\";
            return file_block_ins_str_one;
        }
        // для справки
        //  (command "_.xref" "" "F:\\Проекты\\_Чегдомын отделение флотации Главный корпус\\ГЛАВНЫЙ КОРПУС\\ТХ-6 листы в модели\\2.dwg" "0,0,0" "" "" "")
        // после этой строчки вставляем данные из textboxa

        // добавляем для увеличения точки вставки по координате X
        public static string file_block_ins_one_two()
        {
            file_block_ins_str_one_two = "";
            file_block_ins_str_one_two += ".dwg\" ";
            file_block_ins_str_one_two += "\""; //координаты вставки\n";

            return file_block_ins_str_one_two;
        }
        // после этого  блока вставляем значения из текстбокса по очереди координаты по X

        // продолжаем далее....
        public static string file_block_ins_two()
        {
            file_block_ins_str_two = "";
            // file_block_ins_str_two += "\n(getpoint)\n";
            file_block_ins_str_two += ",0,0\" \"\" \"\" \"\""; //координаты вставки\n";
            file_block_ins_str_two += ")\n";

            return file_block_ins_str_two;
        }
        public static string file_block_ins_three()
        {
            file_block_ins_str_three = "";
            file_block_ins_str_three += "(princ)\n";
            file_block_ins_str_three += ")\n";
            return file_block_ins_str_three;
        }
    }

}
