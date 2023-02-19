using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

namespace ConsoleOpening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        [DllImport("kernel32.dll")]

        private static extern bool FreeConsole();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenConsoleBtn_Click(object sender, RoutedEventArgs e)
        {
            AllocConsole();
            TextWriter stdOutWriter = new StreamWriter(Console.OpenStandardOutput(), Console.OutputEncoding) { AutoFlush = true };
            TextWriter stdErrWriter = new StreamWriter(Console.OpenStandardError(), Console.OutputEncoding) { AutoFlush = true };
            TextReader strInReader = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding);
            Console.SetOut(stdOutWriter);
            Console.SetError(stdErrWriter);
            Console.SetIn(strInReader);

            Console.Write("Введите текст: ");
            string text = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                //Thread.Sleep(30);
                Console.WriteLine(text + "  " + i);
            }
            Console.ReadKey();
            FreeConsole();
        }
    }
}
