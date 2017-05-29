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
        private DnD.Equipment.Item _item;
        private ItemFormMode _ifm;
        public NewItemForm(ref DnD.Equipment.Item it, ItemFormMode ifm)
        {
            InitializeComponent();
            _item = it;
            _ifm = ifm;
            if(ifm == ItemFormMode.Edit || ifm == ItemFormMode.Show)
            {
                NameBox.Text = it.Name;
                ValueBox.Text = it.Value.ToString();
                WeightBox.Text = it.Weight.ToString();
                DescBox.Text = it.Description;
            }
            this.Height = 270;
            
        }

        public NewItemForm(ref DnD.Equipment.Weapon it, ItemFormMode ifm)
        {
            InitializeComponent();
            _item = it;
            _ifm = ifm;
            if (ifm == ItemFormMode.Edit || ifm == ItemFormMode.Show)
            {
                NameBox.Text = it.Name;
                ValueBox.Text = it.Value.ToString();
                WeightBox.Text = it.Weight.ToString();
                DescBox.Text = it.Description;
            }
            this.Height = 400;
            this.Title = "Dodaj nową broń";
        }

        public NewItemForm(ref DnD.Equipment.Armor it, ItemFormMode ifm)
        {
            InitializeComponent();
            _item = it;
            _ifm = ifm;
            if (ifm == ItemFormMode.Edit || ifm == ItemFormMode.Show)
            {
                NameBox.Text = it.Name;
                ValueBox.Text = it.Value.ToString();
                WeightBox.Text = it.Weight.ToString();
                DescBox.Text = it.Description;
            }
            this.Height = 400;
            this.Title = "Dodaj nowy pancerz";
            Value_Box1.Visibility = Visibility.Visible;
            Value_Box2.Visibility = Visibility.Visible;
            Value_Label1.Visibility = Visibility.Visible;
            Value_Label1.Content = "KP: ";
            Value_Label2.Visibility = Visibility.Visible;
            Value_Label2.Content = "Niepowodzenie: ";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string name = NameBox.Text;
            decimal value;
            decimal weight;
            string desc = DescBox.Text;
            if(decimal.TryParse(ValueBox.Text, out value)==false)
            {
                MessageBox.Show("Value is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.DialogResult = false;
                this.Close();
            }
            if (decimal.TryParse(WeightBox.Text, out weight) == false)
            {
                MessageBox.Show("Weight is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.DialogResult = false;
                this.Close();
            }
            _item.Name = name;
            _item.Weight = weight;
            _item.Value = value;
            _item.Description = desc;
            this.DialogResult = true;
            this.Close();
        }
    }

    public enum ItemFormMode
    {
        Add,
        Edit,
        Show
    }
}

