using DnD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DnD_DM_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    
    public partial class MainWindow : Window
    {
        ObservableCollection<Hero> heros;
        public static List<DnD.Inventory> lista = new List<DnD.Inventory> { new DnD.Inventory(SomeThings.list2(), "Box1"), new DnD.Inventory(SomeThings.list(), "Box2"), new DnD.Inventory(SomeThings.list(), "Box3") };
        public MainWindow()
        {
            InitializeComponent();
            heros = new ObservableCollection<Hero>();
            Hero rogue = new Hero{ Name = "Naeli", Size = CreatureSize.Medium, Speed = 10, MaxHealthPoints = 11, CurrentHealthPoints = 11 };
            Hero warrior = new Hero{ Name = "Finto", Size = CreatureSize.Medium, Speed = 9, MaxHealthPoints = 15, CurrentHealthPoints = 15 };
            heros.Add(rogue);
            heros.Add(warrior);
            this.DataContext = heros;
        }

        private void Box3_Click(object sender, RoutedEventArgs e)
        {
            EquipmentWindow eqw = new EquipmentWindow(lista[2], lista);
            eqw.Show();
        }

        private void Box2_Click(object sender, RoutedEventArgs e)
        {
            EquipmentWindow eqw = new EquipmentWindow(lista[1], lista);
            eqw.Show();
        }

        private void Box1_Click(object sender, RoutedEventArgs e)
        {
            EquipmentWindow eqw = new EquipmentWindow(lista[0],lista);
            eqw.Show();
        }

        private void RandomBox_Click(object sender, RoutedEventArgs e)
        {
#warning blah
            EquipmentWindow eqw = new EquipmentWindow(lista[1], lista);
            eqw.Show();
        }
    }
}
