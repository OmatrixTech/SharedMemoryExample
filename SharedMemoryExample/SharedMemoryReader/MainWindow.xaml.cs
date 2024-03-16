using CommonLib;
using System.IO.MemoryMappedFiles;
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

namespace SharedMemoryReader
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MemoryMappedFile memoryMappedFile = CommonHelper.GetInstance().memoryMappedFile;
            using (MemoryMappedViewAccessor accessor = memoryMappedFile.CreateViewAccessor())// Create a memory-mapped view accessor
            {
                // Read data from shared memory
                byte[] buffer = new byte[10000];
                accessor.ReadArray(0, buffer, 0, buffer.Length);
                string message = Encoding.ASCII.GetString(buffer).Trim('\0');
                TxtbxMessageReceived.Text = message;
            }
        }
    }
}