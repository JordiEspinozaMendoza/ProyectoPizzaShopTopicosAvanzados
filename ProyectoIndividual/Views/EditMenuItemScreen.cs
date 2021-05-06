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
    public partial class EditMenuItemScreen : Form
    {
        Select select = new Select();
        Update update = new Update();
        Delete delete = new Delete();
        Register register = new Register();

        public EditMenuItemScreen()
        {
            InitializeComponent();
            GetAllMenuItems();
            GetAllIngredients();
        }
        public void GetAllMenuItems()
        {
            try
            {
                List<List<Object>> employees = select.SelectStatement("MenuItem", 2);

                foreach (var item in employees)
                {
                    comboBoxID.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
                }
                dataGridView1.DataSource = select.SelectStatementDatatable("MenuItem");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public void GetAllIngredients()
        {
            try
            {
                List<List<Object>> ingredient = select.SelectStatement("Ingredient", 2);

                foreach (var item in ingredient)
                {
                    listBoxIngredients.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                update.UpdateStatement("MenuItem", "" +
                    $"name = '{textBoxName.Text}'," +
                    $"description = '{textBoxDescripcion.Text}'," +
                    $"price = {int.Parse(textBoxPrice.Text)}",
                    $"_idMenuItem = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");

                delete.DeleteStatement("IngredientItemDetails", $"_idMenuItem = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                try
                {
                    foreach (var item in listBoxIngredients.SelectedItems)
                    {
                        register.RegisterStatement("IngredientItemDetails", "_idMenuItem, _idIngredient", $"{int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}, {(int)((ListItem)item).Value}");
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                MessageBox.Show("Orden actualizada correctamente");
                Reset();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                delete.DeleteStatement("MenuItem", $"_idMenuItem = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                delete.DeleteStatement("IngredientItemDetails", $"_idMenuItem = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                MessageBox.Show("Menu item eliminado correctamente");
                Reset();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {

                List<Object> menuItem = select.SelectOneStatement("MenuItem", $"_idMenuItem = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}", 4);
                textBoxName.Text = menuItem[1].ToString();
                textBoxDescripcion.Text = menuItem[2].ToString();
                textBoxPrice.Text = menuItem[3].ToString();

                listBoxIngredients.ClearSelected();
                List<List<Object>> selectedIngredients = select.SelectStatement("IngredientItemDetails", 2, $"_idMenuItem = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                List<List<Object>> ingredients = select.SelectStatement("Ingredient", 2);
                try
                {
                    int index = 0;
                    foreach (var A in ingredients)
                    {
                        foreach (var B in selectedIngredients)
                        {
                            if ((int)A[0] == (int)B[1])
                            {
                                listBoxIngredients.SelectedIndices.Add(index);
                            }
                        }
                        index++;
                    }
                }
                catch (Exception)
                {}

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void Reset()
        {
            textBoxName.Text = "";
            textBoxDescripcion.Text = "";
            textBoxPrice.Text = "";
            listBoxIngredients.ClearSelected();
            comboBoxID.SelectedItem = null;

            comboBoxID.Items.Clear();
            GetAllMenuItems();

        }
    }
}
