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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            // список для хранения обьектов
            List<string> list = new List<string>();

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
            int last = 0;
            int future = 700;

            // разделяем по строкам текстбокс с именами модулей контроллера
            string[] mass_mod_coor = TextBox_mod_xcoor.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] mass_mod_number = TextBox_mod_number.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] mass_ward_name = TextBox_ward_name.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] mass_ward_xcoor = TextBox_ward_xcoor.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            // создаём словарь ключ - порядковый элемент 0 - 700, 700 - 1400,
            //             значение - количество модулей 1,2,3,4,5
            var modulDict = new Dictionary<int,int>();

            // переделываем стринговский массив в тип double
            int dictCount = 0;
            foreach (string item in mass_mod_coor)
            {
                // добавляем элемент в массив
                mass_mod[a] = decimal.Parse(item);
                // преобразуем  массив в инт для сравнения
                int dictIf = Convert.ToInt32(mass_mod[a]);
                // пробегаем по массиву и считаем сколько модулей на листе  по 700
                while ((dictIf > last) && (dictIf < future))
                {
                    modulDict[a] = dictCount;
                    dictCount++;
                    a++;
                }
                last = future;
                future += 700;
               
            }

            try
            {
               
               
                    foreach (string s in mass_mod_coor)
                    {
                        WardControl wardControl = new WardControl();
                        wardControl.modulNumberA = mass_mod_number[i];
                        wardControl.modulNumberB = mass_mod_number[i];
                        wardControl.modulNumberC = mass_mod_number[i];
                        wardControl.modulNumberD = mass_mod_number[i];
                        wardControl.modulNumberE = mass_mod_number[i];
                        wardControl.modulXcoor = mass_mod_coor[i];
                        wardControl.wardName = mass_ward_name[i];
                        wardControl.wardXcoor = mass_ward_xcoor[i];
                        list.Add(wardControl.ToString());
                        i++;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            // сохраняем в csv
            SaveCSV saveCsv = new SaveCSV();
            saveCsv.saveCSV("dghdfg");
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