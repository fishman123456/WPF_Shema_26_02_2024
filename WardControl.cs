using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace WPF_Shema_26_02_2024
{
    public class WardControl
    {
        // имя шкафа
        public string wardName = "yu";
        // координаты шкафа
        public string wardXcoor = "65.44";
        // номер модуля
        public List<string> modulNumberA = new List<string>();
        // координаты модуля
        public string modulXcoor = "45.66";

        //// удаление дубликатов
        //public List<string> removeDuplicates(List<string> list)
        //{
        //    List<string> distinct = new List<string>() ;
        //    return   distinct = list.Distinct().ToList();
        //}
        public override string ToString() =>
             wardName;
        //+ "_" 
        //+ " Координата шкафа: " 
        //+ wardXcoor + "_"
        //+ " Номер модуля: "
        //+ modulNumberA + "_"
        //+ " Координата модуля: "
        //+ modulXcoor ;
        public string NumberModulToString()
        {
            // удаляем дубликаты
            List<string> strings = new List<string>();
            strings = modulNumberA.Distinct().ToList();
            // делаем заполнение стринга из списка
            StringBuilder result = new StringBuilder();
            
            int item = 0;
            foreach (var modul in strings)
            {
                result.Append( modul.ToString());
              
                // добавляем запятую
                if (strings.Count-1 != item)
                {
                    result.Append( ", ");
                }
                item++;
            }
            return " (" + result + ")";
        }
    }
}
