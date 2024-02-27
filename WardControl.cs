using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace WPF_Shema_26_02_2024
{
    public  class WardControl
    {
        // имя шкафа
        public  string wardName = "yu";
        // координаты шкафа
        public string wardXcoor = "65.44";
        // номер модуля
        public List <string> modulNumberA ;
        // координаты модуля
        public string modulXcoor = "45.66";

        public override string ToString() => 
              " Имя шкафа: " 
            + wardName + "_" 
            + " Координата шкафа: " 
            + wardXcoor + "_"
            + " Номер модуля: "
            + modulNumberA + "_"
            + " Координата модуля: "
            + modulXcoor ;
        public static string NumberModulToString( List<string> modulNumberA)
        {
            string result = "";
            foreach (var modul in modulNumberA) 
            { result += modul.ToString(); }
            return result;
        }
    }
}
