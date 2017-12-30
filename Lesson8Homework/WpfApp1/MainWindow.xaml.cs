using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void xmlAddressReader_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // получает список файлов типа ЦСВ и все какие может перегоняет в ХМЛ
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);


                foreach (string address in files)
                {
                    if (!ConvertController.Convert(address))
                        MessageBox.Show(String.Format($"Не удалось сконвертировать файл:\n{address}"));
                    else
                        MessageBox.Show(String.Format($"Файл сконвертирован:\n{address}"));
                }
            }
        }
    }
}
