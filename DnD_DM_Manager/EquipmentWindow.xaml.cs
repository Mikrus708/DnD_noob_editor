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
        public double TotalWeight
        {
            get { return 12.73; }
        }
        public EquipmentWindow()
        {
            InitializeComponent();

#warning usuń to gówno
            lista = SomeThings.list();


            DataContext = lista;
            //DataContext = SomeThings.list();
        }

        public EquipmentWindow(List<Item> eq)
        {
            InitializeComponent();


# warning usuń to gówno
            lista = SomeThings.list();


            DataContext = lista;
        }

        private void Add_New_Item (object sender, RoutedEventArgs e)
        {
            Color c = new Color();
            c.A = 255;
            Random R = new Random();
            c.B = (byte)R.Next(0, 255);
            c.G = (byte)R.Next(0, 255);
            c.R = (byte)R.Next(0, 255);
            (sender as Button).Background = new SolidColorBrush(c);
        }

        private void Button_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

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
            ret.Add(new Item("Trawa", 20, "Family Rzepiński", "cat"));
            ret.Add(new Item("Bieda", 20, "Family", "bron"));
            ret.Add(new Item("Kamień", 50, "Family Remiszewski"));
            ret.Add(new Item("Kula do kręgli", 120, "sth", "superItem"));
            ret.Add(new Item("Kapusta", 40, "blah"));
            ret.Add(new Item("Półtoraręczny telefon", 5520));
            ret.Add(new Item("Szklanka z wódką ", 320, "fdfd"));
            ret.Add(new Item("Drzewo", 12320));
            return ret;
        }
    }
}
