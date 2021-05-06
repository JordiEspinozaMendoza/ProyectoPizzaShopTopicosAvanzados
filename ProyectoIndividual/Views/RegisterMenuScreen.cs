using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoIndividual.Actions;

namespace ProyectoIndividual.Views
{
    public partial class RegisterMenuScreen : Form
    {
        Select select = new Select();
        Register register = new Register();

        public RegisterMenuScreen()
        {
            InitializeComponent();
            GetAllMenuItems();
        }
        public void GetAllMenuItems()
        {
            try
            {
                List<List<Object>> items = select.SelectStatement("MenuItem", 2);

                foreach (var item in items)
                {
                    listBoxItems.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
                }

                //var value = ((ListItem)listbox.SelectedItem).Value;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void buttonRegisterMenu_Click(object sender, EventArgs e)
        {
            try
            {
                register.RegisterStatement("Menu", "name", $"'{textBoxName.Text}'");
                try
                {
                    int lastItem = (int)select.SelectLast("Menu", "_idMenu");
                    try
                    {
                        foreach (var item in listBoxItems.SelectedItems)
                        {
                            register.RegisterStatement("MenuItemDetails", "_idMenu, _idMenuItem", $"{lastItem}, {(int)((ListItem)item).Value}");
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
                catch (Exception err)
                {

                    MessageBox.Show(err.Message);

                }
                MessageBox.Show("Menu registrado correctamente");
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }
    }
}
