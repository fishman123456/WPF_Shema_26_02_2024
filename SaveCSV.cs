using System.IO;
using System;
using Microsoft.Win32;
using System.Windows;
using System.Text;
namespace WPF_Shema_26_02_2024

{
    public class SaveCSV
    {
        public async void saveCSV(string text)
        {
            // для русских букв в екселе подключить NUGET
            // NuGet\Install-Package System.Text.Encoding.CodePages -Version 8.0.0
            // Register the CodePages encoding provider at application startup to enable using single and double byte encodings.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // проверка по текущей дате
            CheckDateWork.CheckDate();
            // открываем диалог для сохранения файла в поток
           SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files(*.csv)|*.csv|All files(*.*)|*.*";
            // если не сохраняем то выходим
            if (saveFileDialog1.ShowDialog() == true)
            { }
                // получаем выбранный файл
                string path = saveFileDialog1.FileName;
                


            // сохраняем текст в файл
            try
            {
                // полная перезапись файла 
                using (StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding(1251)))
                {
                    // асинхронная перезапись  файла
                    await writer.WriteAsync(text);
                }
                // добавление в файл
                //using (StreamWriter writer = new StreamWriter(path, true))
                //{
                //    await writer.WriteLineAsync("Addition");
                //    await writer.WriteAsync("4,5");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

