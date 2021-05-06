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
    public partial class RegisterWorkerScreen : Form
    {
        Select select = new Select();
        Register register = new Register();
        public RegisterWorkerScreen()
        {
            InitializeComponent();
            GetAllUnits();
        }
        public void GetAllUnits()
        {
            try
            {
                List<List<Object>> menus = select.SelectStatement("Branch", 2);

                foreach (var item in menus)
                {
                    comboBoxBranch.Items.Add(new ListItem { Name = item[1].ToString(), Value = item[0] });
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void buttonRegisterWorker_Click(object sender, EventArgs e)
        {
            try
            {
                register.RegisterStatement("Employee", "firstName, lastName, email, phone, age, _idBranch", $"'{textBoxName.Text}', '{textBoxLastName.Text}', '{textBoxEmail.Text}', {int.Parse(textBoxPhone.Text)}, {int.Parse(textBoxAge.Text)}, {int.Parse(((ListItem)comboBoxBranch.SelectedItem).Value.ToString())}");

                MessageBox.Show("Empleado registrado correctamente");
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }
    }
}
