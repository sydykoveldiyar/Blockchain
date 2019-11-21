using Data;
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

namespace DesktopApp
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

        private Chain _chain = new Chain();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var block in _chain.Blocks)
            {
                lbBlock.Items.Add(block);
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            lbBlock.Items.Clear();

            _chain.Add(tbData.Text, tbUser.Text);
            foreach (var block in _chain.Blocks)
            {
                lbBlock.Items.Add(block);
            }
        }
    }
}
