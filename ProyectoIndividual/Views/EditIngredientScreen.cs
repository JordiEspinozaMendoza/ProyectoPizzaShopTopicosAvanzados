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
    public partial class EditIngredientScreen : Form
    {
        Select select = new Select();
        Update update = new Update();
        Delete delete = new Delete();
        public EditIngredientScreen()
        {
            InitializeComponent();
            GetAllIngredients();
        }
        public void GetAllIngredients()
        {
            try
            {
                List<List<Object>> employees = select.SelectStatement("Ingredient", 2);

                foreach (var item in employees)
                {
                    comboBoxID.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
                }
                dataGridView1.DataSource = select.SelectStatementDatatable("Ingredient");
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
                update.UpdateStatement("Ingredient", "" +
                    $"name = '{textBoxName.Text}'," +
                    $"description = '{textBoxDescripcion.Text}'," +
                    $"countInStock = {int.Parse(textBoxStock.Text)}",
                    $"_idIngredient = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                MessageBox.Show("Ingredient actualizado correctamente");
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
                List<Object> ingredient = select.SelectOneStatement("Ingredient", $"_idIngredient = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}", 4);
                textBoxName.Text = ingredient[1].ToString();
                textBoxDescripcion.Text = ingredient[2].ToString();
                textBoxStock.Text = ingredient[3].ToString();
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
                delete.DeleteStatement("Ingredient", $"_idIngredient = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                MessageBox.Show("Ingrediente eliminado correctamente");
                Reset();
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
            textBoxStock.Text = "";
            comboBoxID.SelectedItem = null;

            comboBoxID.Items.Clear();
            GetAllIngredients();
        }
    }
}
