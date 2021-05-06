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
    public partial class EditClientScreen : Form
    {
        Select select = new Select();
        Update update = new Update();
        Delete delete = new Delete();
        public EditClientScreen()
        {
            InitializeComponent();
            GetAllUnits();
            GetAllClients();
        }
        public void GetAllUnits()
        {
            try
            {
                List<List<Object>> units = select.SelectStatement("Branch", 2);

                foreach (var item in units)
                {
                    comboBoxBranch.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public void GetAllClients()
        {
            try
            {
                List<List<Object>> clients = select.SelectStatement("Client", 2);

                foreach (var item in clients)
                {
                    comboBoxID.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
                }
                dataGridView1.DataSource = select.SelectStatementDatatable("Client");

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
                List<Object> client = select.SelectOneStatement("Client", $"_idClient = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}", 7);
                textBoxName.Text = client[1].ToString();
                textBoxLastName.Text = client[2].ToString();
                textBoxEmail.Text = client[3].ToString();
                textBoxPhone.Text = client[4].ToString();
                textBoxAge.Text = client[5].ToString();
                foreach (var item in comboBoxBranch.Items)
                {
                    if (int.Parse(((ListItem)item).Value.ToString()) == (int)client[6])
                    {
                        comboBoxBranch.SelectedItem = item;
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
                update.UpdateStatement("Client", "" +
                    $"firstName = '{textBoxName.Text}'," +
                    $"lastName = '{textBoxLastName.Text}'," +
                    $"email = '{textBoxEmail.Text}'," +
                    $"phone = {int.Parse(textBoxPhone.Text)}," +
                    $"age = {int.Parse(textBoxAge.Text)}," +
                    $"_idBranch = {int.Parse(((ListItem)comboBoxBranch.SelectedItem).Value.ToString())}", $"_idClient = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                MessageBox.Show("Cliente actualizado correctamente");
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
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxPhone.Text = "";
            textBoxAge.Text = "";
            comboBoxBranch.SelectedItem = null;
            comboBoxID.SelectedItem = null;

            comboBoxID.Items.Clear();
            GetAllClients();
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                delete.DeleteStatement("Client", $"_idClient = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                MessageBox.Show("Cliente eliminado correctamente");
                Reset();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
