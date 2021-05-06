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
    public partial class RegisterIngredientScreen : Form
    {
        Register register = new Register();

        public RegisterIngredientScreen()
        {
            InitializeComponent();
        }

        private void buttonRegisterConsult_Click(object sender, EventArgs e)
        {
            try
            {
                register.RegisterStatement("Ingredient", "name, description, countInStock", $"'{textBoxName.Text}', '{textBoxDescripcion.Text}', {int.Parse(textBoxStock.Text)}");
                MessageBox.Show("Ingrediente registrado correctamente");
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }
    }
}
