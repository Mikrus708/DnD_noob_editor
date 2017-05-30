using DnD.Classes;
using DnD.Races;
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
    /// Interaction logic for HeroForm.xaml
    /// </summary>
    public partial class HeroForm : Window
    {
        public HeroForm()
        {
            InitializeComponent();
            foreach (HeroClass h in HeroClass.AllClasses)
                cbx.Items.Add(h);
            foreach (Race r in Race.AllRaces)
                rcbox.Items.Add(r);
        }
    }
}
