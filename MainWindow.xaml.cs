using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Shema_26_02_2024
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // список для хранения обьектов
        List<string> list = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            

            // создаём массив decimal для сравнения
            decimal[] mass_mod;
            mass_mod = new decimal[300];

            // строка по которой будем разбивать текстбокс
            // расделителем может служить один символ, поэтому строку создаём, т е массив символов
            string[] separator = { "\n", "\r" };

            // добавляем данные в список из текстбокса textbox_Y_coor -13-07-2023
            int i = 0;
            int a = 0;
            int j = 0;
            // начало т.е первый лист
            int last = 0;
            // приращение, второй лист, третий лист м т.д 
            int future = 700;

            // разделяем по строкам текстбокс с именами модулей контроллера
            string[] mass_mod_coor = TextBox_mod_xcoor.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] mass_mod_number = TextBox_mod_number.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] mass_ward_name = TextBox_ward_name.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] mass_ward_xcoor = TextBox_ward_xcoor.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            // переделываем стринговский массив в тип double
            //int dictCount = 0;
            try
            {
                // цикл для перевода децимал в инт
                foreach (string item in mass_mod_coor)
                {
                    // добавляем элемент в массив
                    mass_mod[a] = decimal.Parse(item);
                    a++;
                }
                // цикл для заполнения обьектов
                foreach (string item in mass_mod_number)
                {
                    WardControl ward = new WardControl();
                    while (mass_mod[j] <= 1700 && mass_mod[j]>0)
                    {
                            ward.modulNumberA.Add( mass_mod_number[j]);
                        j++;
                    }
                    ward.modulXcoor = mass_mod_coor[i];
                    ward.wardName = mass_ward_name[i];
                    ward.wardXcoor = mass_ward_xcoor[i];
                     
                    list.Add(ward.ToString() + ward.NumberModulToString() );
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
            finally
            {

            }
        }


        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string saveStr = string.Empty;
            // заполняем строку для сохранения
            foreach (var item in list)
            {
                saveStr += item.ToString()+"\n";
            }
            // сохраняем в csv
            SaveCSV saveCsv = new SaveCSV();
            saveCsv.saveCSV(saveStr);
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            // закрываем окно
            this.Close();
            // закрываем приложение
            System.Windows.Application.Current.Shutdown();
        }

        private void TextBox_mod_xcoor_TextChanged(object sender, TextChangedEventArgs e)
        {
            // замена точек на запятые
            string str = TextBox_mod_xcoor.Text;
            if (str.Contains("."))
            {
                string s = str.Replace(".", ",");
                TextBox_mod_xcoor.Clear();
                TextBox_mod_xcoor.AppendText(str.Replace(".", ","));
            }
        }

        private void TextBox_ward_xcoor_TextChanged(object sender, TextChangedEventArgs e)
        {
            // замена точек на запятые
            string str = TextBox_ward_xcoor.Text;
            if (str.Contains("."))
            {
                string s = str.Replace(".", ",");
                TextBox_ward_xcoor.Clear();
                TextBox_ward_xcoor.AppendText(str.Replace(".", ","));
            }
        }
    }
}