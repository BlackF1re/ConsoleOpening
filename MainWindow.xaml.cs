using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;

namespace ConsoleOpening
{
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
                Console.WriteLine(text + "  " + i);
            }
            Console.ReadKey();
            FreeConsole();
        }
    }
}
