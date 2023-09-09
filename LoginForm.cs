using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WorkAc
{
    public partial class LoginForm : Form
    {        
                
        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void OutBtn_Click(object sender, EventArgs e)
        {
            Close();
        }        

        MainForm mainForm = new MainForm();

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string log = logBox.Text.Trim();
            string pas = pasBox.Text.Trim();
            SqlConnection connection = new SqlConnection(@"Data Source=localhost;Initial Catalog=acc_db;Integrated Security=True");
            string query = @"select * from users where login ='" + log + "' and pass = '" + pas + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {                
                mainForm.Show();
                Hide();
            }
            else if (logBox.Text == "")
            {
                MessageBox.Show("Введите логин!", "Отказано в доступе", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (pasBox.Text == "")
            {
                MessageBox.Show("Введите пароль!", "Отказано в доступе", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!", "Отказано в доступе", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            logBox.Clear();
            pasBox.Clear();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox.Text == "Темный")
            {
                BackColor = SystemColors.ControlDarkDark;
                ForeColor = SystemColors.ControlLightLight;
                groupBox.ForeColor = SystemColors.ControlLightLight;
                mainForm.BackColor = SystemColors.ControlDarkDark;
                mainForm.ForeColor = SystemColors.ControlLightLight;
            }
            if (ComboBox.Text == "Светлый")
            {
                BackColor = SystemColors.ControlLightLight;
                ForeColor = SystemColors.ControlText;
                groupBox.ForeColor = SystemColors.ControlText;
            }
        }
    }
}
