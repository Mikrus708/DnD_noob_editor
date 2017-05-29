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
using System.Windows.Shapes;

namespace DnD_DM_Manager
{
    /// <summary>
    /// Interaction logic for RandomRewardChoosingWindow.xaml
    /// </summary>
    public partial class RandomRewardChoosingWindow : Window
    {
        private static int _llr;
        public RandomRewardChoosingWindow()
        {
            InitializeComponent();
            _llr = 0;
        }

        public static int LastRewardLevel()
        {
            return _llr;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            _llr = MainGrid.Children.IndexOf(sender as Button) + 1;
            if (_llr > 11) return;

            this.DialogResult = true;
            this.Close();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }
    }
}
