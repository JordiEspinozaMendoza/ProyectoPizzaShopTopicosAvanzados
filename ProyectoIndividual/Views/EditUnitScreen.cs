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
    public partial class EditUnitScreen : Form
    {
        Select select = new Select();
        Update update = new Update();
        Delete delete = new Delete();
        public EditUnitScreen()
        {
            InitializeComponent();
            GetAllUnits();
            GetAllMenus();
        }
        public void GetAllUnits()
        {
            try
            {
                List<List<Object>> units = select.SelectStatement("Branch", 2);

                foreach (var item in units)
                {
                    comboBoxID.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
                }
                dataGridView1.DataSource = select.SelectStatementDatatable("Branch");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public void GetAllMenus()
        {
            try
            {
                List<List<Object>> menus = select.SelectStatement("Menu", 2);

                foreach (var item in menus)
                {
                    comboBoxMenu.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
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
                List<Object> branch = select.SelectOneStatement("Branch", $"_idBranch = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}", 4);
                textBoxAddress.Text = branch[1].ToString();
                textBoxPhone.Text = branch[2].ToString();
                foreach (var item in comboBoxMenu.Items)
                {
                    if (int.Parse(((ListItem)item).Value.ToString()) == (int)branch[3])
                    {
                        comboBoxMenu.SelectedItem = item;
                    }
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
                update.UpdateStatement("Branch", "" +
                    $"address = '{textBoxAddress.Text}'," +
                    $"phone = {int.Parse(textBoxPhone.Text)}," +
                    $"_idMenu = {int.Parse(((ListItem)comboBoxMenu.SelectedItem).Value.ToString())}", $"_idBranch = {int.Parse(((ListItem)comboBoxMenu.SelectedItem).Value.ToString())}");
                MessageBox.Show("Sucursal actualizada correctamente");
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
                delete.DeleteStatement("Branch", $"_idBranch = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                MessageBox.Show("Sucursal eliminada correctamente");
                Reset();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
        public void Reset()
        {
            textBoxAddress.Text = "";
            textBoxPhone.Text = "";
            comboBoxMenu.SelectedItem = null;
            comboBoxID.SelectedItem = null;

            comboBoxID.Items.Clear();
            GetAllUnits();
        }
    }
}
