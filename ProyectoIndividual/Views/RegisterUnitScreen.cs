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
    public partial class RegisterUnitScreen : Form
    {
        Select select = new Select();
        Register register = new Register();

        public RegisterUnitScreen()
        {
            InitializeComponent();
            GetAllMenus();

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

                //var value = ((ListItem)listbox.SelectedItem).Value;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void buttonRegisterUnit_Click(object sender, EventArgs e)
        {
            try
            {
              register.RegisterStatement("Branch", "address, phone, _idMenu", $"'{textBoxAddress.Text}', {int.Parse(textBoxPhone.Text)}, {int.Parse(((ListItem)comboBoxMenu.SelectedItem).Value.ToString())}");

                MessageBox.Show("Menu registrado correctamente");
            }
            catch (Exception err)
            {

                MessageBox.Show(err.StackTrace);
            }
        }
    }
}
