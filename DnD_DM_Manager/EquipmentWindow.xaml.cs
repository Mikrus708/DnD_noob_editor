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

namespace DnD_DM_Manager
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EquipmentWindow : Window
    {
        public EquipmentWindow()
        {
            InitializeComponent();
        }

        public EquipmentWindow(List<DnD.Equipment.Item> eq)
        {
            InitializeComponent();
            //for (int i = MainGrid.RowDefinitions.Count; i < h; i++)
            //{
            //    MainGrid.RowDefinitions.Add(new RowDefinition());
            //}
            //for (int i = MainGrid.ColumnDefinitions.Count; i < w; i++)
            //{
            //    MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            //}
            DataContext = eq;
        }
    }
}
