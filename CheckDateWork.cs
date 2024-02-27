using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Shema_26_02_2024
{
    // класс для проверки текущей даты
    public static class CheckDateWork
    {
        public static void CheckDate()
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Parse("31/03/2024");
            Window w1 = new Window();

            if (dt1.Date > dt2.Date)
            {
                MessageBox.Show("Your Application is Expire");
                // Выход из проложения добавил 12-07-2023. Чтобы порядок был....
                Application.Current.Shutdown();
                //w1.Close();
            }
            else
            {

                // MessageBox.Show("Работайте до   " + dt2.ToString());
            }

        }
    }
}
