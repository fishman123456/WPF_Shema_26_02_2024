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
            mass_mod = new decimal[1000];

            // строка по которой будем разбивать текстбокс
            // расделителем может служить один символ, поэтому строку создаём, т е массив символов
            string[] separator = { "\n", "\r" };

            // разделяем по строкам текстбокс с именами модулей контроллера
            string[] mass_mod_coor = TextBox_mod_xcoor.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] mass_mod_Name = TextBox_mod_number.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] mass_ward_name = TextBox_ward_name.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] mass_ward_xcoor = TextBox_ward_xcoor.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            // переделываем стринговский массив в тип double
            //int dictCount = 0;
            try
            {
                int a = 0;
                // цикл для перевода децимал в инт
                foreach (string item in mass_mod_coor)
                {
                    // добавляем элемент в массив
                    mass_mod[a] = decimal.Parse(item);
                    a++;
                }
                // перебираем строки текстбокса номер модуля
                int j = 0;
                // Перебираем строки координаты номера модуля
                int i = 0;
                // Перебираем строки координаты, имя шкафа
                int wardnum = 0;
                // начало т.е первый лист
                int last = 200;
                // приращение, второй лист, третий лист м т.д 
                int future = 700;

                // цикл для заполнения обьектов цикл по количеству имени шкафа
                foreach (string item in mass_ward_name)
                {
                    WardControl ward = new WardControl();

                    // берем имя модуля где координаты по 700 и увеличение по 700
                    while (mass_mod[j] <= future && mass_mod[j] >= last && mass_mod[j]>0)
                    {
                        ward.modulNumberA.Add( mass_mod_Name[j]);
                        j++;
                        ward.modulXcoor =Convert.ToDouble( mass_mod_coor[i]);
                        if (ward.modulXcoor >= last) {
                            i++;
                        }
                    }
                    // добавляем в обьект имя шкафа
                    ward.wardName = mass_ward_name[wardnum];
                    ward.wardXcoor = mass_ward_xcoor[wardnum];
                    wardnum++;
                   
                    // добавляем элементы в список
                    list.Add(ward.ToString() + ward.NumberModulToString() + ";" + last + ";" + "номер листа " + wardnum);
                    // присваиваем преведущее last = future, а future увеличиваем на 700
                    last = future;
                    future += 700;
                }
            }
            catch (Exception ex)
            {
                mass_mod = null;
                MessageBox.Show(ex.ToString());
                
            }
            finally
            {

            }
        }

        private void ButtonClearList_Click(object sender, RoutedEventArgs e)
        {
           list.Clear();
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

        // функция для замены точек на запятую
        public void replasePoint(string str)
        {
            if (str.Contains("."))
            {
                string s = str.Replace(".", ",");
                TextBox_ward_xcoor.Clear();
                TextBox_ward_xcoor.AppendText(str.Replace(".", ","));
            }
        }

       
    }
}