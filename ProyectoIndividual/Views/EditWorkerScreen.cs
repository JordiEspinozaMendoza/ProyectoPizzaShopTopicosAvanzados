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
    public partial class EditWorkerScreen : Form
    {
        Select select = new Select();
        Update update = new Update();
        Delete delete = new Delete();
        public EditWorkerScreen()
        {
            InitializeComponent();
            GetAllUnits();
            GetAllWorkers();
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
        public void GetAllWorkers()
        {
            try
            {
                List<List<Object>> employees = select.SelectStatement("Employee", 2);

                foreach (var item in employees)
                {
                    comboBoxID.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
                }
                dataGridView1.DataSource = select.SelectStatementDatatable("Employee");
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
                List<Object> employee = select.SelectOneStatement("Employee", $"_idEmployee = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}", 7);
                textBoxName.Text = employee[1].ToString();
                textBoxLastName.Text = employee[2].ToString();
                textBoxEmail.Text = employee[3].ToString();
                textBoxPhone.Text = employee[4].ToString();
                textBoxAge.Text = employee[5].ToString();
                foreach (var item in comboBoxBranch.Items)
                {
                    if (int.Parse(((ListItem)item).Value.ToString()) == (int)employee[6])
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
                update.UpdateStatement("Employee", "" +
                    $"firstName = '{textBoxName.Text}'," +
                    $"lastName = '{textBoxLastName.Text}'," +
                    $"email = '{textBoxEmail.Text}'," +
                    $"phone = {int.Parse(textBoxPhone.Text)}," +
                    $"age = {int.Parse(textBoxAge.Text)}," +
                    $"_idBranch = {int.Parse(((ListItem)comboBoxBranch.SelectedItem).Value.ToString())}",
                    $"_idEmployee = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                MessageBox.Show("Empleado actualizado correctamente");
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
            GetAllWorkers();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                delete.DeleteStatement("Employee", $"_idEmployee = {int.Parse(((ListItem)comboBoxID.SelectedItem).Value.ToString())}");
                MessageBox.Show("Empleado eliminado correctamente");
                Reset();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
