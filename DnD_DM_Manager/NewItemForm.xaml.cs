using DnD;
using DnD.Equipment;
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
    /// Interaction logic for NewItemForm.xaml
    /// </summary>
    public partial class NewItemForm : Window
    {
        private Item _item;
        public NewItemForm(Item it)
        {
            InitializeComponent();
            _item = it;
            itemGrid.DataContext = it;
        }

        public NewItemForm(Weapon it)
        {
            InitializeComponent();
            _item = it;
            initDmgBox();
            dmgGrid.DataContext = it.Damage;
            itemGrid.DataContext = it;
            weapongGrid.DataContext = it;
            weapongGrid.Height = double.NaN;
            weapongGrid.Visibility = Visibility.Visible;
            this.Title = "Dodaj nową broń";
        }

        public NewItemForm(Armor it)
        {
            InitializeComponent();
            _item = it;
            itemGrid.DataContext = it;
            armorGrid.DataContext = it;
            armorGrid.Height = double.NaN;
            armorGrid.Visibility = Visibility.Visible;
            this.Title = "Dodaj nowy pancerz";
        }
        private void initDmgBox()
        {
            dmgBox.Items.Add("Base");
            foreach (var d in Enum.GetValues(typeof(Dice.Type)))
                dmgBox.Items.Add(d);
            dmgBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int val;
            if (int.TryParse(valBox.Text, out val))
            {
                dynamic x = dmgBox.SelectedItem;
                if (x is string)
                    (_item as Weapon).Damage.Base += 1 * val;
                else
                    (_item as Weapon).Damage.Add(x, val);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            (_item as Weapon).Damage.Clear();
        }
    }
}

