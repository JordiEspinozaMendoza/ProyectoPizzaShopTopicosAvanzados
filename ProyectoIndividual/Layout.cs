using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using ProyectoIndividual.Views;
using System.Data.SqlClient;

namespace ProyectoIndividual
{
    public partial class Layout : Form
    {
        private IconButton currentButton;
        private Panel leftBorderPanel;
        private Form actualChildForm;
        private SqlConnection connection;


        public Layout()
        {
            InitializeComponent();
            leftBorderPanel = new Panel();
            leftBorderPanel.Size = new Size(8, 50);
            mainPanel.Controls.Add(leftBorderPanel);
            CloseSubMenus();

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        #region CloseSubmenus

        private void CloseSubMenus()
        {
            panelWorkers.Visible = false;
            panelMenu.Visible = false;
            panelClients.Visible = false;
            panelMenu.Visible = false;
            panelIngredients.Visible = false;
            panelUnity.Visible = false;
            panelMenuItem.Visible = false;
        }

        private void buttonConsults_Click(object sender, EventArgs e)
        {

        }
        private void homeButton_Click(object sender, EventArgs e)
        {
            CloseSubMenus();
            ActivateButton(sender);
            //OpenChildForm(new HomeScreen());
        }

        private void buttonUnity_Click(object sender, EventArgs e)
        {
            CloseSubMenus();
            ActivateButton(sender);
           // OpenChildForm(new Unity());
        }
        private void buttonPatients_Click(object sender, EventArgs e)
        {
            if (panelClients.Visible)
            {
                panelClients.Visible = false;
                ResetButton();
            }
            else
            {
                CloseSubMenus();
                panelClients.Visible = true;
                ActivateButton(sender);
            }
        }

        private void buttonDoctors_Click(object sender, EventArgs e)
        {
            if (panelMenu.Visible)
            {
                panelMenu.Visible = false;
                ResetButton();
            }
            else
            {
                CloseSubMenus();
                panelMenu.Visible = true;
                ActivateButton(sender);
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Methods
        private void ActivateButton(object button)
        {
            if (button != null)
            {
                DisableButton();
                currentButton = (IconButton)button;
                currentButton.BackColor = Color.FromArgb(242, 92, 5);


                leftBorderPanel.BackColor = Color.White;
                leftBorderPanel.Location = new Point(0, currentButton.Location.Y);
                leftBorderPanel.Visible = true;
                leftBorderPanel.BringToFront();

            }
        }
        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(191, 38, 4);
                currentButton.ForeColor = Color.White;
                currentButton.IconColor = Color.White;
            }
        }
        private void ResetButton()
        {
            if (leftBorderPanel.Visible)
            {
                leftBorderPanel.Visible = false;
                currentButton.BackColor = Color.FromArgb(191, 38, 4);
            }
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void OpenChildForm(Form childForm)
        {
            if (actualChildForm != null)
            {
                actualChildForm.Close();
            }
            actualChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.BackColor = Color.FromArgb(247, 248, 251);

            panelChildForm.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();

        }

        #endregion


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection("Data source=DESKTOP-6QMNAK5;Initial Catalog=Dental Clark;integrated security=true");
            connection.Open();
            MessageBox.Show("Conexión exitosa");
            connection.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonWorkers_Click(object sender, EventArgs e)
        {
            if (panelWorkers.Visible)
            {
                panelWorkers.Visible = false;
                ResetButton();
            }
            else
            {
                CloseSubMenus();
                panelWorkers.Visible = true;
                ActivateButton(sender);
            }
        }

        private void buttonUnity_Click_1(object sender, EventArgs e)
        {
            if (panelUnity.Visible)
            {
                panelUnity.Visible = false;
                ResetButton();
            }
            else
            {
                CloseSubMenus();
                panelUnity.Visible = true;
                ActivateButton(sender);
            }
        }

        private void buttonIngredients_Click(object sender, EventArgs e)
        {
            if (panelIngredients.Visible)
            {
                panelIngredients.Visible = false;
                ResetButton();
            }
            else
            {
                CloseSubMenus();
                panelIngredients.Visible = true;
                ActivateButton(sender);
            }
        }

        private void buttonMenuItem_Click(object sender, EventArgs e)
        {
            if (panelMenuItem.Visible)
            {
                panelMenuItem.Visible = false;
                ResetButton();
            }
            else
            {
                CloseSubMenus();
                panelMenuItem.Visible = true;
                ActivateButton(sender);
            }
        }

        private void buttonClients_Click(object sender, EventArgs e)
        {
            if (panelClients.Visible)
            {
                panelClients.Visible = false;
                ResetButton();
            }
            else
            {
                CloseSubMenus();
                panelClients.Visible = true;
                ActivateButton(sender);
            }

        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            if (panelMenu.Visible)
            {
                panelMenu.Visible = false;
                ResetButton();
            }
            else
            {
                CloseSubMenus();
                panelMenu.Visible = true;
                ActivateButton(sender);
            }
        }
        #region openChildForms
        private void buttonAllWorkers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ListWorkersScreen());
        }

        private void buttonRegisterWorker_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RegisterWorkerScreen());
        }

        private void buttonEditWorker_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EditWorkerScreen());
        }

        private void buttonAllClients_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ListClientsScreen());
        }

        private void buttonRegisterClient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RegisterClientScreen());
        }

        private void buttonEditClient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EditClientScreen());
        }

        private void buttonAllMenus_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ListMenusScreen());

        }

        private void buttonRegisterMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RegisterMenuScreen());

        }

        private void buttonEditMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EditMenuScreen());

        }

        private void buttonAllUnits_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ListUnitsScreen());

        }

        private void buttonRegisterUnit_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RegisterUnitScreen());

        }

        private void buttonEditUnit_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EditUnitScreen());

        }

        private void buttonAllIngredients_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ListIngredientsScreen());

        }

        private void buttonRegisterIngredient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RegisterIngredientScreen());
        }

        private void buttonEditIngredient_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EditIngredientScreen());

        }

        private void buttonAllMenuItems_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ListMenuItemsScreen());

        }

        private void buttonRegisterMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new RegisterMenuItemScreen());

        }

        private void buttonEditMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EditMenuItemScreen());

        }
        #endregion

        private void homeButton_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Home());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;


        }
    }
}