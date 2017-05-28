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
using System.Text.RegularExpressions;

namespace DnD_DM_Manager
{
    /// <summary>
    /// Interaction logic for MoneyEdit.xaml
    /// </summary>
    public partial class MoneyEdit : Window
    {
        private DnD.Pouch _p;


        public MoneyEdit(DnD.Pouch p)
        {
            InitializeComponent();
            CopAm.Text = p[DnD.CoinType.Copper].ToString();
            SilAm.Text = p[DnD.CoinType.Silver].ToString();
            GolAm.Text = p[DnD.CoinType.Gold].ToString();
            PlaAm.Text = p[DnD.CoinType.Platinium].ToString();
            _p = p;
        }

        private void TextChanged_Ch(object sender, TextChangedEventArgs e)
        {
            if (_p == null) return;
            int change;
            TextBox tb = sender as TextBox;
            if (tb.Text == "-") change = 0;
            else if (ParseText(tb, out change) == false) return;
            int idx = MainGrid.Children.IndexOf(tb) - 1;
            (MainGrid.Children[idx] as TextBox).Text = (change + _p[(DnD.CoinType)(idx/3)]).ToString();
            RefreshWV();
        }
        private void TextChanged_Am(object sender, TextChangedEventArgs e)
        {
            if (_p == null) return;
            int amount;
            TextBox tb = sender as TextBox;
            if (tb.Text == "-") amount = 0;
            else if (ParseText(tb, out amount) == false) return;
            int idx = MainGrid.Children.IndexOf(tb) + 1;
            (MainGrid.Children[idx] as TextBox).Text = (amount - _p[(DnD.CoinType)(idx/3)]).ToString();
            RefreshWV();
        }

        private bool ParseText(TextBox tb, out int val)
        {
            if (int.TryParse(tb.Text, out val) == false)
            {
                tb.Text = Regex.Replace(tb.Text, "[^0-9]", "");
                tb.Select(tb.Text.Length, 0);
            }
            return true;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }

        private void RefreshWV()
        {
            WeightLabel.Content = ((int.Parse(CopAm.Text) + int.Parse(SilAm.Text) + int.Parse(GolAm.Text) + int.Parse(PlaAm.Text)) * 0.01).ToString();
            ValueLabel.Content = (int.Parse(CopAm.Text) * 0.01 + int.Parse(SilAm.Text) * 0.1 + int.Parse(GolAm.Text) + int.Parse(PlaAm.Text) * 10).ToString();
        }

        private void OK_Click (object sender, RoutedEventArgs e)
        {
            _p[DnD.CoinType.Copper] = int.Parse(CopAm.Text);
            _p[DnD.CoinType.Silver] = int.Parse(SilAm.Text);
            _p[DnD.CoinType.Gold] = int.Parse(GolAm.Text);
            _p[DnD.CoinType.Platinium] = int.Parse(PlaAm.Text);
            this.Close();
        }
        private void Cancel_Click (object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}
