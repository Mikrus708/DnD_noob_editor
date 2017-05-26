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
                ValueBox.Text = it.ValueInCopper.ToString();
                WeightBox.Text = it.Weight.ToString();
                DescBox.Text = it.Description;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string name = NameBox.Text;
            int value;
            int weight;
            string desc = DescBox.Text;
            if(int.TryParse(ValueBox.Text, out value)==false)
            {
                MessageBox.Show("Value is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.DialogResult = false;
                this.Close();
            }
            if (int.TryParse(WeightBox.Text, out weight) == false)
            {
                MessageBox.Show("Weight is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.DialogResult = false;
                this.Close();
            }
            _item.Name = name;
            _item.Weight = weight;
            _item.ValueInCopper = value;
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

