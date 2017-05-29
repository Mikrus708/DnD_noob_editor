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
    /// Interaction logic for MoneyShare.xaml
    /// </summary>
    public partial class MoneyShare : Window
    {
        public MoneyArgs MoneyArguments { get; set; }
        public MoneyShare(MoneyArgs ma)
        {
            InitializeComponent();
            MoneyArguments = ma;
        }
        private void DivideActive_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            MoneyArguments.Amount[DnD.CoinType.Copper] = int.Parse(CopCh.Text);
            MoneyArguments.Amount[DnD.CoinType.Silver] = int.Parse(SilCh.Text);
            MoneyArguments.Amount[DnD.CoinType.Gold] = int.Parse(GolCh.Text);
            MoneyArguments.Amount[DnD.CoinType.Platinium] = int.Parse(PlaCh.Text);
            MoneyArguments.Mode = ShareMode.Divide;
            this.Close();
        }
        private void TextChanged_Ch(object sender, TextChangedEventArgs e)
        {
            int change;
            TextBox tb = sender as TextBox;
            if (tb.Text == "-") change = 0;
            if (int.TryParse(tb.Text, out change) == false)
            {
                tb.Text = System.Text.RegularExpressions.Regex.Replace(tb.Text, "[^0-9]", "");
                tb.Select(tb.Text.Length, 0);
                return;
            }
            //RefreshWV();
        }
        private void RefreshWV()
        {
            WeightLabel.Content = ((int.Parse(CopCh.Text) + int.Parse(SilCh.Text) + int.Parse(GolCh.Text) + int.Parse(PlaCh.Text)) * 0.01).ToString();
            ValueLabel.Content = (int.Parse(CopCh.Text) * 0.01 + int.Parse(SilCh.Text) * 0.1 + int.Parse(GolCh.Text) + int.Parse(PlaCh.Text) * 10).ToString();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nothing will happen");
            this.DialogResult = false;
            this.Close();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
    }

    public class MoneyArgs
    {
        public ShareMode Mode { get; set; }
        public DnD.Pouch Amount { get; set; }
        public HeroStatus Status { get; set; }

        public MoneyArgs()
        {
            Mode = ShareMode.ToAll;
            Status = HeroStatus.All;
            Amount = new DnD.Pouch();
        }
    }

    public enum ShareMode
    {
        Divide,
        ToAll
    }
    public enum HeroStatus
    {
        Active,
        Inactive,
        All
    }
}
