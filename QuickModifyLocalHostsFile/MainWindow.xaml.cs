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
using QuickModifyLocalHostsFile.file;

namespace QuickModifyLocalHostsFile
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBox.Text = HostsFileHandler.GetInstance().GetHostsAllString();
        }

        private void CommandBinding_Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            HostsFileHandler.GetInstance().WriteHostsFile(TextBox.Text);
            if (HostsFileHandler.GetInstance().GetHostsAllString() == TextBox.Text)
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }

        private void TextBox_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            bool handle = (Keyboard.Modifiers & ModifierKeys.Control) > 0;
            if (!handle)
            {
                return;
            }
            double size = TextBox.FontSize;
            if (e.Delta > 0)
            {
                size++;
            }
            else
            {
                size--;
                if (size <= 0)
                {
                    size = 1;
                }
            }
            TextBox.FontSize = size;
        }
    }
}
