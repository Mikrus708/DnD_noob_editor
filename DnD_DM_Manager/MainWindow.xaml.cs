using DnD;
using DnD.Classes;
using DnD.Races;
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
        ObservableCollection<Hero> heroes;
        public static List<DnD.Inventory> lista = new List<DnD.Inventory> { new DnD.Inventory(SomeThings.list2(), null, "Skrzynia DMa #1"), new DnD.Inventory(SomeThings.list(), null, "Skrzynia DMa #2"), new DnD.Inventory(SomeThings.list(), null, "Skrzynia DMa #3")  };
        public MainWindow()
        {
            InitializeComponent();
            heroes = new ObservableCollection<Hero>();
            //Hero rogue = new Hero{ Name = "Naeli", Age=110, Class = Rouge.Instance, EyesColor=Colors.Blue.ToString(), HairColor=Colors.Brown.ToString(), Height=155, Weight=40, PlayerName="Ania", Race= Elf.Instance, Sex="Female" , Size = CreatureSize.Medium, Speed = 10, MaxHealthPoints = 11, CurrentHealthPoints = 11 };
            //rogue[HeroAttribute.Type.Strength] = 9;
            //rogue[HeroAttribute.Type.Dexterity] = 10;
            //rogue[HeroAttribute.Type.Constitution] = 11;
            //rogue[HeroAttribute.Type.Intelligence] = 12;
            //rogue[HeroAttribute.Type.Wisdom] = 13;
            //rogue[HeroAttribute.Type.Charisma] = 14;
            //for (int i=0; i<6; i++)
            //{
            //    //Grid.SetColumn()
            //}
            //Hero druid = new Hero{ Name = "Finto", Class = Druid.Instance, EyesColor = Colors.Blue.ToString(), HairColor = Colors.Brown.ToString(), Height = 170, Weight = 70, PlayerName = "Michał", Race = Human.Instance, Sex = "Male", Size = CreatureSize.Medium, Speed = 9, MaxHealthPoints = 15, CurrentHealthPoints = 15 };
            //Hero hunter = new Hero{ Name = "Arato", Class = Ranger.Instance, EyesColor = Colors.Blue.ToString(), HairColor = Colors.Brown.ToString(), Height = 165, Weight = 50, PlayerName = "Michał", Race = Elf.Instance, Sex = "Male", Size = CreatureSize.Medium, Speed = 9, MaxHealthPoints = 17, CurrentHealthPoints = 13 };
            //heroes.Add(rogue);
            //heroes.Add(druid);
            //heroes.Add(hunter);
            this.DataContext = heroes;
            loadHeroesFromFolder("../../Postacie");
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            saveHerosToFolder("../../Postacie");
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
            RandomRewardChoosingWindow rrcw = new RandomRewardChoosingWindow();
            rrcw.Owner = this;
            if (rrcw.ShowDialog() == false) return; 
            int SW = RandomRewardChoosingWindow.LastRewardLevel();
            var x = RandomReward.GenerateTreasure(SW);
            x.Name = $"Losowy skarb poziomu {SW}";
            EquipmentWindow eqw = new EquipmentWindow(x, lista);
            eqw.Show();
        }
        private void GoldExpToHeroes_Click(object sender, RoutedEventArgs e)
        {
            MoneyArgs ma = new MoneyArgs();
            MoneyShare ms = new MoneyShare(ma);
            if (ms.ShowDialog() ==false) return;
            if (ma.Mode == ShareMode.ToAll && ma.Status == HeroStatus.All) GiveMoney(ma.Amount, heroes);
            if (ma.Mode == ShareMode.ToAll && ma.Status == HeroStatus.Active) GiveMoney(ma.Amount, HeroesListView.SelectedItems.Cast<Hero>());

        }
        private void GiveMoney (Pouch p, IEnumerable<Hero> heroes)
        {
            foreach (Hero h in heroes)
            {
                h.Inventory.Pouch[CoinType.Copper] += p[CoinType.Copper];
                h.Inventory.Pouch[CoinType.Silver] += p[CoinType.Silver];
                h.Inventory.Pouch[CoinType.Gold] += p[CoinType.Gold];
                h.Inventory.Pouch[CoinType.Platinium] += p[CoinType.Platinium];
                MessageBox.Show($"{p.TotalValue} added to {h.Name}'s main inventory.");
            }
        }
        private void loadHeroesFromFolder(string FolderPath)
        {
            string[] names = null;
            try
            {
                names = System.IO.Directory.GetFiles(FolderPath, "*.xml");
            }
            catch { }
            if (names != null)
            {
                foreach (string str in names)
                {
                    Hero h = EasyXML.DeserializeXML<Hero>(str);
                    heroes.Add(h);
                }
            }
        }
        private void saveHerosToFolder(string FolderPath)
        {
            if (!System.IO.Directory.Exists(FolderPath))
                System.IO.Directory.CreateDirectory(FolderPath);
            foreach (Hero h in heroes)
            {
                EasyXML.SerializeXML(h, FolderPath + '/' + h.Name + ".xml");
            }
        }
        private void Hero_DblClick(object sender, RoutedEventArgs e)
        {
            EquipmentWindow eqw = new EquipmentWindow((HeroesListView.SelectedItem as Hero).Inventory, lista);
            eqw.Show();
        }

        private void HeroesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hero h = HeroesListView.SelectedItem as Hero;
            if (h != null)
            {
                switch (h.Class.Name)
                {
                    case "Łotrzyk":
                        HeroPicture.Source = new BitmapImage(new Uri(".\\resources\\figures\\FemaleWarrior.png", UriKind.Relative));
                        break;
                    case "Tropiciel":
                        HeroPicture.Source = new BitmapImage(new Uri(".\\resources\\figures\\Knight.png", UriKind.Relative));
                        break;
                    default:
                        HeroPicture.Source = new BitmapImage(new Uri(".\\resources\\figures\\Boar.png", UriKind.Relative));
                        break;
                }
                HeroPicture.Visibility = Visibility.Visible;
            }
            else HeroPicture.Visibility = Visibility.Hidden;
        }
    }
}
