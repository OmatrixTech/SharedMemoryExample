using CommonLib;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Windows;

namespace SharedMemoryWriter
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
            using (MemoryMappedViewAccessor accessor = memoryMappedFile.CreateViewAccessor())
            {
                // Write data to shared memory
                byte[] buffer = Encoding.ASCII.GetBytes(TxtBxMessage.Text);
                accessor.WriteArray(0, buffer, 0, buffer.Length);
                TxtBlckInformation.Text = "Data written to shared memory";
            }
        }
    }
}