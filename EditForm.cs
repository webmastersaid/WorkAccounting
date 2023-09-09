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
using System.IO;

namespace WorkAc
{
    public partial class EditForm : Form
    {

        private SqlConnection sqlConnection = null;
        private SqlCommand command = null;
        private SqlDataAdapter dataAdapter = null;
        private DataTable dataTable = null;

        public EditForm()
        {
            InitializeComponent();
        }

        private void HideBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void insertImgData(SqlConnection connection)
        {
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = @"INSERT INTO img VALUES (@FileName, @Title, @ImageData)";
            command.Parameters.Add("@FileName", SqlDbType.VarChar, 50);
            command.Parameters.Add("@Title", SqlDbType.VarChar, 50);
            command.Parameters.Add("@ImageData", SqlDbType.Image, 1000000);

            // путь к файлу для загрузки
            string filename = imgPathBox.Text;
            // заголовок файла
            string title = "logo";
            // получаем короткое имя файла для сохранения в бд
            string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1); // logo.jpg | logo.png

            // массив для хранения бинарных данных файла
            byte[] imageData;
            using (System.IO.FileStream fs = new System.IO.FileStream(filename, FileMode.Open))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }

            // передаем данные в команду через параметры
            command.Parameters["@FileName"].Value = shortFileName;
            command.Parameters["@Title"].Value = title;
            command.Parameters["@ImageData"].Value = imageData;
            command.ExecuteNonQuery();
        }

        private void inserAddressData(SqlConnection connection, int country, int region, int city, int street, int house, int flat)
        {
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = @"INSERT INTO address VALUES (@country, @region, @city, @street, @house, @flat)";

            command.Parameters.Add("@country", SqlDbType.Int);
            command.Parameters.Add("@region", SqlDbType.Int);
            command.Parameters.Add("@city", SqlDbType.Int);
            command.Parameters.Add("@street", SqlDbType.Int);
            command.Parameters.Add("@house", SqlDbType.Int);
            command.Parameters.Add("@flat", SqlDbType.Int);

            command.Parameters["@country"].Value = country;
            command.Parameters["@region"].Value = region;
            command.Parameters["@city"].Value = city;
            command.Parameters["@street"].Value = street;
            command.Parameters["@house"].Value = house;
            command.Parameters["@flat"].Value = flat;
            command.ExecuteNonQuery();
        }

        private void SaveImg_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            
            sqlConnection.Close();
        }

        private void ChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "image files (*.jpeg)|*.jpeg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                imgPathBox.Text = openFileDialog1.FileName;
            }
        }

        /*private void personal_dataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.personal_dataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet);

        }*/

        private void LoadData(string script)
        {
            try
            {                
                dataAdapter = new SqlDataAdapter(script, sqlConnection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet.education". При необходимости она может быть перемещена или удалена.
            this.educationTableAdapter.Fill(this.dataSet.education);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet.gender". При необходимости она может быть перемещена или удалена.
            this.genderTableAdapter.Fill(this.dataSet.gender);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet.img". При необходимости она может быть перемещена или удалена.
            this.imgTableAdapter.Fill(this.dataSet.img);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet.department". При необходимости она может быть перемещена или удалена.
            this.departmentTableAdapter.Fill(this.dataSet.department);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet.promotion". При необходимости она может быть перемещена или удалена.
            this.promotionTableAdapter.Fill(this.dataSet.promotion);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet.job_position". При необходимости она может быть перемещена или удалена.
            this.job_positionTableAdapter.Fill(this.dataSet.job_position);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet.street". При необходимости она может быть перемещена или удалена.
            this.streetTableAdapter.Fill(this.dataSet.street);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet.city". При необходимости она может быть перемещена или удалена.
            this.cityTableAdapter.Fill(this.dataSet.city);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet.region". При необходимости она может быть перемещена или удалена.
            this.regionTableAdapter.Fill(this.dataSet.region);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet.country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.dataSet.country);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet.country". При необходимости она может быть перемещена или удалена.
            this.countryTableAdapter.Fill(this.dataSet.country);

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["local_acc_db"].ConnectionString);

        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            serviceBox.Enabled = true;
            personalBox.Enabled = false;
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            personalBox.Enabled = true;
            serviceBox.Enabled = false;
        }
    }
}
