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
    public partial class EditMenuScreen : Form
    {
        Select select = new Select();
        Update update = new Update();
        Delete delete = new Delete();
        Register register = new Register();
        public EditMenuScreen()
        {
            InitializeComponent();
            GetAllMenus();
            GetAllMenuItems();
        }
        public void GetAllMenus()
        {
            try
            {
                List<List<Object>> employees = select.SelectStatement("Menu", 2);

                foreach (var item in employees)
                {
                    comboBoxID.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
                }
                dataGridView1.DataSource = select.SelectStatementDatatable("Menu");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public void GetAllMenuItems()
        {
            try
            {
                List<List<Object>> employees = select.SelectStatement("MenuItem", 2);

                foreach (var item in employees)
                {
                    listBoxItems.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
                }
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
                List<Object> menu = select.SelectOneStatement("Menu", $"_idMenu = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}", 2);
                textBoxName.Text = menu[1].ToString();

                listBoxItems.ClearSelected();

                List<List<Object>> selectedItems = select.SelectStatement("MenuItemDetails", 2, $"_idMenu = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                List<List<Object>> menuItems = select.SelectStatement("MenuItem", 2);
                try
                {
                    int index = 0;
                    foreach (var A in menuItems)
                    {
                        foreach (var B in selectedItems)
                        {
                            if ((int)A[0] == (int)B[0])
                            {
                                listBoxItems.SelectedIndices.Add(index);
                            }
                        }
                        index++;
                    }
                }
                catch (Exception)
                { }
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
                delete.DeleteStatement("Menu", $"_idMenu = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                delete.DeleteStatement("MenuItemDetails", $"_idMenu = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                MessageBox.Show("Menu eliminado correctamente");
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
            listBoxItems.ClearSelected();
            comboBoxID.SelectedItem = null;

            comboBoxID.Items.Clear();
            GetAllMenus();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                update.UpdateStatement("Menu",
                    $"name = '{textBoxName.Text}'",
                    $"_idMenu = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");

                delete.DeleteStatement("MenuItemDetails", $"_idMenu = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                try
                {
                    foreach (var item in listBoxItems.SelectedItems)
                    {
                        register.RegisterStatement("MenuItemDetails", "_idMenu, _idMenuItem", $"{int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}, {(int)((ListItem)item).Value}");
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
    }
}
