using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WorkAc
{
    public partial class GuideForm : Form
    {
        public GuideForm()
        {
            InitializeComponent();
        }

        private SqlConnection sqlConnection = null;        
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlCommand command = null;

        // фУНКЦИЯ ЗАГРУЗКИ ТАБЛИЦЫ
        private void LoadData(string script)
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter(script, sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
                dataGridView.AutoGenerateColumns = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //  ЗАГРУЗКА ТАБЛИЦЫ ПРИ ЗАГРУЗКЕ ФОРМЫ
        private void guideForm_Load(object sender, EventArgs e)
        {
            string script = @"SELECT title_country AS Страна FROM country ORDER BY title_country";
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["local_acc_db"].ConnectionString);
            sqlConnection.Open();
            LoadData(script);
            sqlConnection.Close();
        }

        private void updtBtn_Click(object sender, EventArgs e)
        {
            edtPanel.Visible = true;
        }

        // ДОБАВЛЕНИЕ ЗАПИСИ В ТАБЛИЦУ
        private void insertData(string script, SqlCommand command)
        {
                if (countryBox.Text != "")
                {                                        
                    LoadData(script);
                    messageTextBox.Text += "Добавлена " + command.ExecuteNonQuery().ToString() + " запись\n";                                    
                    countryBox.Clear();
                }
                else
                {
                    MessageBox.Show("Введите данные!");
                }
        }

        private void insrtBtn_Click(object sender, EventArgs e)
        {

            int slctTbl = tableСomboBox.SelectedIndex;
            string script = null;
            string scriptReload = null;

            switch (slctTbl)
            {
                case 0:
                    script = @"SELECT title_country FROM country";
                    command = new SqlCommand($"INSERT INTO country(title_country) VALUES('{countryBox.Text}')", sqlConnection);
                    sqlConnection.Open();
                    insertData(script, command);
                    sqlConnection.Close();
                    scriptReload = @"SELECT title_country AS Страна FROM country ORDER BY title_country";
                    sqlConnection.Open();
                    LoadData(scriptReload);
                    sqlConnection.Close();
                    break;
                case 1:
                    script = @"SELECT title_region FROM region";
                    command = new SqlCommand($"INSERT INTO region(title_region) VALUES('{countryBox.Text}')", sqlConnection);
                    sqlConnection.Open();
                    insertData(script, command);
                    sqlConnection.Close();
                    scriptReload = @"SELECT title_region AS Страна FROM region ORDER BY title_region";
                    sqlConnection.Open();
                    LoadData(scriptReload);
                    sqlConnection.Close();
                    break;
                case 2:
                    script = @"SELECT title_city FROM city";
                    command = new SqlCommand($"INSERT INTO city(title_city) VALUES('{countryBox.Text}')", sqlConnection);
                    sqlConnection.Open();
                    insertData(script, command);
                    sqlConnection.Close();
                    scriptReload = @"SELECT title_city AS Город FROM city ORDER BY title_city";
                    sqlConnection.Open();
                    LoadData(scriptReload);
                    sqlConnection.Close();
                    break;
                case 3:
                    script = @"SELECT title_street FROM street";
                    command = new SqlCommand($"INSERT INTO street(title_street) VALUES('{countryBox.Text}')", sqlConnection);
                    sqlConnection.Open();
                    insertData(script, command);
                    sqlConnection.Close();
                    scriptReload = @"SELECT title_street AS Улица FROM street ORDER BY title_street";
                    sqlConnection.Open();
                    LoadData(scriptReload);
                    sqlConnection.Close();
                    break;
                default:
                    script = @"SELECT title_country AS Страна FROM country ORDER BY title_country";
                    command = new SqlCommand($"INSERT INTO country(title_country) VALUES('{countryBox.Text}')", sqlConnection);
                    sqlConnection.Open();
                    insertData(script, command);
                    sqlConnection.Close();
                    scriptReload = @"SELECT title_country AS Страна FROM country ORDER BY title_country";
                    sqlConnection.Open();
                    LoadData(scriptReload);
                    sqlConnection.Close();
                    break;
            }
            

        }

        private void clsBtn_Click(object sender, EventArgs e)
        {
            edtPanel.Visible = false;
        }

        
        private void tableСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            int slctTbl = tableСomboBox.SelectedIndex;
            string script = null;

            switch (slctTbl)
            {
                case 0:
                    script = @"SELECT title_country AS Страна FROM country ORDER BY title_country";
                    sqlConnection.Open();
                    LoadData(script);
                    sqlConnection.Close();
                    grpBox.Text = "Страны";
                    countryCaption.Text = "Страна";
                    break;
                case 1:
                    script = @"SELECT title_region AS Регион FROM region ORDER BY title_region";
                    sqlConnection.Open();
                    LoadData(script);
                    sqlConnection.Close();
                    grpBox.Text = "Регионы";
                    countryCaption.Text = "Регион";
                    break;
                case 2:
                    script = @"SELECT title_city AS Город FROM city ORDER BY title_city";
                    sqlConnection.Open();
                    LoadData(script);
                    sqlConnection.Close();
                    grpBox.Text = "Города";
                    countryCaption.Text = "Город";
                    break;
                case 3:
                    script = @"SELECT title_street AS Улица FROM street ORDER BY title_street";
                    sqlConnection.Open();
                    LoadData(script);
                    sqlConnection.Close();
                    grpBox.Text = "Улицы";
                    countryCaption.Text = "Улица";
                    break;
                default:
                    script = @"SELECT title_country AS Страна FROM country ORDER BY title_country";
                    sqlConnection.Open();
                    LoadData(script);
                    sqlConnection.Close();
                    grpBox.Text = "Страны";
                    countryCaption.Text = "Страна";
                    break;
            }

        }            

    }
}
