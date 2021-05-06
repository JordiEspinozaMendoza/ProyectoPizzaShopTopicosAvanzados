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
    public partial class RegisterMenuItemScreen : Form
    {
         Select select = new Select();
        Register register = new Register();

        public RegisterMenuItemScreen()
        {
            InitializeComponent();
            GetAllIngredients();
        }
        public void GetAllIngredients()
        {
            try
            {
                List<List<Object>> ingredients = select.SelectStatement("Ingredient", 2);

                foreach (var item in ingredients)
                {
                    listBoxIngredients.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
                }

                //var value = ((ListItem)listbox.SelectedItem).Value;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void buttonRegisterMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                register.RegisterStatement("MenuItem", "name, description, price", $"'{textBoxName.Text}', '{textBoxDescripcion.Text}', {float.Parse(textBoxPrice.Text)}");
                try
                {
                    int lastItem =  (int)select.SelectLast("MenuItem", "_idMenuItem");
                    try
                    {
                        foreach (var item in listBoxIngredients.SelectedItems)
                        {
                            register.RegisterStatement("IngredientItemDetails", "_idMenuItem, _idIngredient", $"{lastItem}, {(int)((ListItem)item).Value}");
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
                MessageBox.Show("Item de menu registrado correctamente");
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }
    }
}
