using System;
using System.Collections.Generic;
using System.Globalization;
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
using DnD;
using DnD.Equipment;

namespace DnD_DM_Manager
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EquipmentWindow : Window
    {

        private static bool messageshown = false;

        private Inventory _inv;
        private List<Inventory> _otherInventories = new List<Inventory>();



        public List<Inventory> ComboList
        {
            get { return _otherInventories; }
        }

        public Inventory Inventory
        {
            get { return _inv; }
        }





        public EquipmentWindow(Inventory inv, List<Inventory> allInventories)
        {
            InitializeComponent();
            _otherInventories.AddRange(allInventories);
            _otherInventories.Remove(inv);
            _inv = inv;
            //ComboList = new List<string>();
            //foreach (var x in _otherInventories)
            //    ComboList.Add(x.Name);
            Title = inv.ToString();
            this.DataContext = this;
            sta.DataContext = Inventory;
            this.KeyDown += EquipmentWindow_KeyDown;
            MainGrid.MouseDoubleClick += MainGrid_MouseDoubleClick;
            MainList.MouseDoubleClick += MainGrid_MouseDoubleClick;
            RefreshCoins();
        }

        private void MainGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit_Item(TabPanel.SelectedContent, null);
        }

        private void EquipmentWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                Remove_Item(TabPanel.SelectedContent, null);
            }
        }

        private void Add_New_Item(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            UnclickAddButton();
            Item it = new Item();
            NewItemForm wnd = new NewItemForm(it);
            wnd.Owner = this;
            if (wnd.ShowDialog() == true)
                _inv.AddItem(it);
        }
        private void Add_New_Weapon(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            UnclickAddButton();
            Weapon it = new Weapon();
            NewItemForm wnd = new NewItemForm(it);
            wnd.Owner = this;
            if (wnd.ShowDialog() == true)
                _inv.AddItem(it);
        }
        private void Add_New_Armour(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            UnclickAddButton();
            Armor it = new Armor();
            NewItemForm wnd = new NewItemForm(it);
            wnd.Owner = this;
            if (wnd.ShowDialog() == true)
                _inv.AddItem(it);
        }

        private void Edit_Item(object sender, RoutedEventArgs e)
        {
            if (TabPanel.SelectedIndex == 0)
            {
                if (MainGrid.SelectedItems.Count != 1) { MessageBox.Show("Musisz wybrać dokładnie jeden przedmiot do edycj.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error); return; }
                dynamic sel = MainGrid.SelectedItem;
                NewItemForm wnd = new NewItemForm(sel);
                wnd.Owner = this;
                wnd.ShowDialog();
                MainGrid.Items.Refresh();
            }
            else if (TabPanel.SelectedIndex == 1)
            {
                if (MainList.SelectedItems.Count != 1) { MessageBox.Show("Musisz wybrać dokładnie jeden przedmiot do edycj.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error); return; }
                dynamic sel = MainList.SelectedItem;
                NewItemForm wnd = new NewItemForm(sel);
                wnd.Owner = this;
                wnd.ShowDialog();
                MainList.Items.Refresh();
            }
            _inv.NotifyChanges();
        }
        private void Remove_Item(object sender, RoutedEventArgs e)
        {
            int lim = 0;
            if (TabPanel.SelectedIndex == 0)
            {
                lim = MainGrid.SelectedItems.Count;
                for (int i = 0; i < lim; ++i)
                    _inv.RemoveItem(MainGrid.SelectedItems[0] as Item);
            }
            else if (TabPanel.SelectedIndex == 1)
            {
                lim = MainList.SelectedItems.Count;
                for (int i = 0; i < lim; ++i)
                    _inv.RemoveItem(MainList.SelectedItems[0] as Item);
            }
        }
        private void Give_Item(object sender, RoutedEventArgs e)
        {
            Inventory To = ComboInv.SelectedItem as Inventory;

            int lim = 0;
            if (TabPanel.SelectedIndex == 0)
            {
                lim = MainGrid.SelectedItems.Count;
                for (int i = 0; i < lim; ++i)
                {
                    To.AddItem(MainGrid.SelectedItems[0] as Item);
                    _inv.RemoveItem(MainGrid.SelectedItems[0] as Item);
                }
            }
            else if (TabPanel.SelectedIndex == 1)
            {
                lim = MainList.SelectedItems.Count;
                for (int i = 0; i < lim; ++i)
                {
                    To.AddItem(MainList.SelectedItems[0] as Item);
                    _inv.RemoveItem(MainList.SelectedItems[0] as Item);
                }
            }
        }

        private void Money_Click(object sender, RoutedEventArgs e)
        {
            MoneyEdit me = new MoneyEdit(_inv.Pouch);
            me.Owner = this;
            me.ShowDialog();

            RefreshCoins();
        }
        private void Show_Add_Options(object sender, RoutedEventArgs e)
        {
            //if (messageshown == false) { MessageBox.Show("na razie dziala biednie", "", MessageBoxButton.OK, MessageBoxImage.Information); messageshown = true; }

            Add_Label.Visibility = Visibility.Hidden;
            AddWeapon_Button.Visibility = Visibility.Visible;
            AddItem_Button.Visibility = Visibility.Visible;
            AddArmour_Button.Visibility = Visibility.Visible;
            AddNothing_Button.Visibility = Visibility.Visible;
        }

        private void UnclickAddButton()
        {
            Add_Label.Visibility = Visibility.Visible;
            AddWeapon_Button.Visibility = Visibility.Hidden;
            AddItem_Button.Visibility = Visibility.Hidden;
            AddArmour_Button.Visibility = Visibility.Hidden;
            AddNothing_Button.Visibility = Visibility.Hidden;
        }

        private void RefreshCoins()
        {
            //smLabel.Content = _inv.Pouch[CoinType.Copper].ToString();
            //ssLabel.Content = _inv.Pouch[CoinType.Silver].ToString();
            //szLabel.Content = _inv.Pouch[CoinType.Gold].ToString();
            //spLabel.Content = _inv.Pouch[CoinType.Platinium].ToString();
        }


    }
    public class ItemToImageSource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Weapon)
                return new BitmapImage(new Uri($@"pack://application:,,,/resources/placeholders/Weapon.png"));
            else if (value is Armor)
                return new BitmapImage(new Uri($@"pack://application:,,,/resources/placeholders/Armor.png"));
            return new BitmapImage(new Uri($@"pack://application:,,,/resources/placeholders/Item.png"));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public static class SomeThings
    {
        public static List<Item> list()
        {
            var ret = new List<Item>();
            ret.Add(new Item { Name = "Śmieć", Value = 20, Family = "Family Rzepiński", Category = "cat" });
            ret.Add(new Item { Name = "Śmieć", Value = 20, Family = "Family", Category = "bron" });
            ret.Add(new Item { Name = "Kamień", Value = 50, Family = "Family Remiszewski" });
            ret.Add(new Item { Name = "Kabanos", Value = 120, Family = "sth", Category = "superItem" });
            ret.Add(new Item { Name = "Kapusta", Value = 40, Family = "blah" });
            ret.Add(new Item { Name = "Zbroja z kaktusa", Value = 5520 });
            ret.Add(new Item { Name = "Wódka ze szklanką ", Value = 320, Family = "fdfd" });
            ret.Add(new Item { Name = "Drzewo", Value = 12320 });
            return ret;
        }

        public static List<Item> list2()
        {
            var ret = new List<Item>();
            ret.Add(new Item { Name = "Trawa", Value = 40, Family = "Family Rzepiński", Category = "cat" });
            ret.Add(new Item { Name = "Bieda", Value = -100, Family = "Family", Category = "bron" });
            ret.Add(new Item { Name = "Kamień", Value = 0, Family = "Family Remiszewski" });
            ret.Add(new Item { Name = "Kula do kręgli", Value = 150, Family = "sth", Category = "superItem" });
            ret.Add(new Item { Name = "Kapusta", Value = 30, Family = "blah" });
            ret.Add(new Item { Name = "Półtoraręczny telefon", Value = 5000 });
            ret.Add(new Item { Name = "Szklanka z wódką ", Value = 700, Family = "fdfd" });
            ret.Add(new Item { Name = "Drzewo", Value = 1 });
            return ret;
        }
    }
}
