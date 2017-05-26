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
using DnD;
using DnD.Equipment;

namespace DnD_DM_Manager
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EquipmentWindow : Window 
    {
        List<Item> lista;

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

        public EquipmentWindow()
        {
            InitializeComponent();

            lista = SomeThings.list();
            _inv = new Inventory(lista, null);

            DataContext = this;
            //DataContext = SomeThings.list();
        }

        
        
#warning jakiś fajny pomysł na przesyłanie między ekwipunkami poza drag&dropem? Nie chce mi się nad nim na razie pracować;
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
            MainGrid.DragEnter += MainGrid_DragEnter;
            MainGrid.Drop += MainGrid_Drop;
        }

        private void MainGrid_Drop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(typeof(ListViewItem[]));
            ListViewItem[] items = data as ListViewItem[];
            // data ok?
            if (items != null)
                // now loop over the array..
                foreach (ListViewItem lvi in items)
                {
                    // do stuff.. here we can check where we come from:
                    MainGrid.Items.Add(lvi.Content + " coming from " + lvi.Name);
                }
        }

        private void MainGrid_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem[]))) e.Effects = DragDropEffects.Move;
        }

        private void Add_New_Item (object sender, RoutedEventArgs e)
        {
            Item it = new Item("");
            NewItemForm wnd = new NewItemForm(ref it, ItemFormMode.Add);
            if(wnd.ShowDialog() == true)
                _inv.AddItem(it);

        }

        private void Edit_Item(object sender, RoutedEventArgs e)
        {
            if (TabPanel.SelectedIndex == 0)
            {
                Item sel = MainGrid.SelectedItem as Item;
                NewItemForm wnd = new NewItemForm(ref sel, ItemFormMode.Edit);
                wnd.ShowDialog();
                MainGrid.Items.Refresh();
            }
            else if (TabPanel.SelectedIndex == 1)
            {
                Item sel = MainList.SelectedItem as Item;
                NewItemForm wnd = new NewItemForm(ref sel, ItemFormMode.Edit);
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
            //foreach (Item i in MainGrid.SelectedItems)
            //_inv.RemoveItem(i);
            //_inv.Bag.Remove(i);
            else if (TabPanel.SelectedIndex == 1)
            {
                lim = MainList.SelectedItems.Count;
                for (int i = 0; i < lim; ++i)
                    _inv.RemoveItem(MainList.SelectedItems[0] as Item);
            }


            //MainGrid.Items.Refresh();
            //MainList.Items.Refresh();
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
            //foreach (Item i in MainGrid.SelectedItems)
            //_inv.RemoveItem(i);
            //_inv.Bag.Remove(i);
            else if (TabPanel.SelectedIndex == 1)
            {
                lim = MainList.SelectedItems.Count;
                for (int i = 0; i < lim; ++i)
                {
                    To.AddItem(MainList.SelectedItems[0] as Item);
                    _inv.RemoveItem(MainList.SelectedItems[0] as Item);
                }
            }



            //MainGrid.Items.Refresh();
            //MainList.Items.Refresh();
        }


    }

    public static class SomeThings
    {
        public static List<Item> list()
        {
            var ret = new List<Item>();
            ret.Add(new Item("Śmieć", 20, "Family Rzepiński", "cat"));
            ret.Add(new Item("Śmieć", 20, "Family", "bron"));
            ret.Add(new Item("Kamień", 50, "Family Remiszewski"));
            ret.Add(new Item("Kabanos", 120, "sth", "superItem"));
            ret.Add(new Item("Kapusta", 40, "blah"));
            ret.Add(new Item("Zbroja z kaktusa", 5520));
            ret.Add(new Item("Wódka ze szklanką ", 320, "fdfd"));
            ret.Add(new Item("Drzewo", 12320));
            return ret;
        }

        public static List<Item> list2()
        {
            var ret = new List<Item>();
            ret.Add(new Item("Trawa", 40, "Family Rzepiński", "cat"));
            ret.Add(new Item("Bieda", -100, "Family", "bron"));
            ret.Add(new Item("Kamień", 0, "Family Remiszewski"));
            ret.Add(new Item("Kula do kręgli", 150, "sth", "superItem"));
            ret.Add(new Item("Kapusta", 30, "blah"));
            ret.Add(new Item("Półtoraręczny telefon", 5000));
            ret.Add(new Item("Szklanka z wódką ", 700, "fdfd"));
            ret.Add(new Item("Drzewo", 1));
            return ret;
        }
    }
}
