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
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WorkAc
{
    public partial class MainForm : Form
    {
        EditForm editForm = new EditForm();

        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlCommandBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;

        public MainForm()
        {
            InitializeComponent();
        }

        public string connectionString = "";

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Hide();
        }

        private void ExitProg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void LightMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = SystemColors.ControlLightLight;
            ForeColor = SystemColors.ControlText;
        }

        private void DarkMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = SystemColors.ControlDarkDark;
            ForeColor = SystemColors.ControlLightLight;
        }

        private void SearchMenu_Click(object sender, EventArgs e)
        {
            SearchPanel.Visible = true;
            SearchBox.Text = "Поиск";
            SearchBox.ForeColor = SystemColors.InactiveCaption;
        }

        private void SearchBox_Enter(object sender, EventArgs e)
        {
            if (SearchBox.Text == "Поиск")
            {
                SearchBox.Text = "";
                SearchBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void SearchBox_Leave(object sender, EventArgs e)
        {
            if (SearchBox.Text.Trim() == "")
            {
                SearchBox.Text = "Поиск";
                SearchBox.ForeColor = SystemColors.InactiveCaption;
            }
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            SearchPanel.Visible = false;
            SearchBox.Clear();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string script = @"SELECT        personal_data.id AS Код, img.file_name AS Фото, REPLACE(REPLACE(REPLACE(personal_data.surname, ' ', ' #'), '# ', ''), '#', '') + ' ' + REPLACE(REPLACE(REPLACE(personal_data.name, ' ', ' #'), '# ', ''), '#', '') 
                         + ' ' + REPLACE(REPLACE(REPLACE(personal_data.middle_name, ' ', ' #'), '# ', ''), '#', '') AS ФИО, personal_data.birthday AS [Дата рождения], gender.title_gender AS Пол, personal_data.inn AS ИНН, 
                         passport_data.seria + ' ' + passport_data.num + ' ' + REPLACE(REPLACE(REPLACE(passport_data.who_issued, ' ', ' #'), '# ', ''), '#', '') + ' ' + CAST(passport_data.when_issued AS char(10)) 
                         AS [Паспортные данные (серия, номер, кем, когда выдан)], personal_data.snils AS СНИЛС, personal_data.polis AS ПОЛИС
FROM            personal_data INNER JOIN
                         img ON personal_data.id_photo = img.id INNER JOIN
                         passport_data ON personal_data.id_passport = passport_data.id INNER JOIN
                         gender ON personal_data.id_gender = gender.id";
            sqlConnection.Open();
            LoadData(script);
            sqlConnection.Close();
            (dataGridView.DataSource as DataTable).DefaultView.RowFilter = $"ФИО LIKE '%{SearchBox.Text}%'";
        }

        private void AddRecord_Click(object sender, EventArgs e)
        {
            editForm.Show();
        }

        private void closeSearch_Click(object sender, EventArgs e)
        {
            SearchPanel.Visible = false;
            SearchBox.Clear();
        }

        private void DataGridView_DoubleClick(object sender, EventArgs e)
        {
            editForm.Show();
        }

        private void aboutProg_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string script = @"SELECT        personal_data.id AS Код, img.file_name AS Фото, REPLACE(REPLACE(REPLACE(personal_data.surname, ' ', ' #'), '# ', ''), '#', '') + ' ' + REPLACE(REPLACE(REPLACE(personal_data.name, ' ', ' #'), '# ', ''), '#', '') 
                         + ' ' + REPLACE(REPLACE(REPLACE(personal_data.middle_name, ' ', ' #'), '# ', ''), '#', '') AS ФИО, personal_data.birthday AS [Дата рождения], gender.title_gender AS Пол, personal_data.inn AS ИНН, 
                         passport_data.seria + ' ' + passport_data.num + ' ' + REPLACE(REPLACE(REPLACE(passport_data.who_issued, ' ', ' #'), '# ', ''), '#', '') + ' ' + CAST(passport_data.when_issued AS char(10)) 
                         AS [Паспортные данные (серия, номер, кем, когда выдан)], personal_data.snils AS СНИЛС, personal_data.polis AS ПОЛИС
FROM            personal_data INNER JOIN
                         img ON personal_data.id_photo = img.id INNER JOIN
                         passport_data ON personal_data.id_passport = passport_data.id INNER JOIN
                         gender ON personal_data.id_gender = gender.id";
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["local_acc_db"].ConnectionString);
            sqlConnection.Open();
            LoadData(script);
            sqlConnection.Close();
        }
        
        private void Export_Data_To_Excel(DataGridView DGV, string filename)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();

            for (int i = 1; i < DGV.Columns.Count + 1; i++)
            {
                excelApp.Cells[1, i] = DGV.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i <= DGV.Rows.Count - 2; i++)
            {
                for (int j = 0; j <= DGV.Columns.Count - 1; j++)
                {
                    excelApp.Cells[i + 2, j + 1] = DGV[j, i].Value.ToString();
                }
            }

            excelApp.Columns.AutoFit();
            workbook.SaveAs(filename);
            excelApp.Visible = true;            
        }

        private void exportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Книга Excel (*.xlsx)|*.xlsx";

            sfd.FileName = selectTable.Text + ".xlsx";
            if (dataGridView.Rows.Count >= 0)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Export_Data_To_Excel(dataGridView, sfd.FileName);
                }
                else
                {
                    MessageBox.Show("Операция экспорта в формат Excel Book отменена!");
                }
            }
            else
            {
                MessageBox.Show("Данные в указанной таблице отсутствуют!");
            }

        }

        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            int RowCount = DGV.Rows.Count;
            int ColumnCount = DGV.Columns.Count;
            Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

            //Добавление строк
            int r = 0;
            for (int c = 0; c <= ColumnCount - 1; c++)
            {
                for (r = 0; r <= RowCount - 1; r++)
                {
                    DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                } //Конец строки
            } //Конец колонок

            Word.Document oDoc = new Word.Document();


            //Ориентация страницы
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


            dynamic oRange = oDoc.Content.Application.Selection.Range;
            string oTemp = "";
            for (r = 0; r <= RowCount - 1; r++)
            {
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oTemp = oTemp + DataArray[r, c] + "\t";

                }
            }

            //Формат таблицы
            oRange.Text = oTemp;

            object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
            object ApplyBorders = true;
            object AutoFit = true;
            object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

            oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                  Type.Missing, Type.Missing, ref ApplyBorders,
                                  Type.Missing, Type.Missing, Type.Missing,
                                  Type.Missing, Type.Missing, Type.Missing,
                                  Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

            oRange.Select();

            oDoc.Application.Selection.Tables[1].Select();
            oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
            oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
            oDoc.Application.Selection.Tables[1].Rows[1].Select();
            oDoc.Application.Selection.InsertRowsAbove(1);
            oDoc.Application.Selection.Tables[1].Rows[1].Select();

            //Стиль строки заголовка
            oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
            oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Colibri";
            oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 11;

            //Строка заголовка
            for (int c = 0; c <= ColumnCount - 1; c++)
            {
                oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
            }

            //Стиль таблицы 
            //oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
            oDoc.Application.Selection.Tables[1].Rows[1].Select();
            oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            //Текст заголовка
            foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
            {
                Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                headerRange.Text = selectTable.Text;
                headerRange.Font.Size = 16;
                headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }

            //Сохранение файла
            oDoc.SaveAs2(filename);

            //Показать word-файл
            oDoc.Application.Visible = true;
        }

        private void exportWord_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = selectTable.Text + ".docx";
            if (dataGridView.Rows.Count > 0)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Export_Data_To_Word(dataGridView, sfd.FileName);
                }
                else
                {
                    MessageBox.Show("Операция экспорта в формат Word Document отменена!");
                }
            } else
            {
                MessageBox.Show("Данные в указанной таблице отсутствуют!");
            }
            
        }

        private void Export_Data_To_PDF(DataGridView DGV, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfTable = new PdfPTable(DGV.Columns.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            iTextSharp.text.Font textFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

            foreach(DataGridViewColumn column in DGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, textFont));
                cell.BackgroundColor = new BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            foreach (DataGridViewRow row in DGV.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), textFont));
                }
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".pdf";
            sfd.FileName = selectTable.Text + ".pdf";

            if (dataGridView.Rows.Count >= 0)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfdoc, stream);
                        pdfdoc.Open();
                        pdfdoc.Add(pdfTable);
                        pdfdoc.Close();
                        stream.Close();
                    }                       
                }
                else
                {
                    MessageBox.Show("Операция экспорта в формат PDF отменена!");
                }
            }
            else
            {
                MessageBox.Show("Данные в указанной таблице отсутствуют!");
            }

        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            Export_Data_To_PDF(dataGridView, selectTable.Text);
        }

        private void addressMenu_Click(object sender, EventArgs e)
        {

        }

        private void selectTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selData = selectTable.SelectedItem.ToString();
            if (selData == "Персональные данные")
            {
                string script = @"SELECT        personal_data.id AS Код, img.file_name AS Фото, REPLACE(REPLACE(REPLACE(personal_data.surname, ' ', ' #'), '# ', ''), '#', '') + ' ' + REPLACE(REPLACE(REPLACE(personal_data.name, ' ', ' #'), '# ', ''), '#', '') 
                         + ' ' + REPLACE(REPLACE(REPLACE(personal_data.middle_name, ' ', ' #'), '# ', ''), '#', '') AS ФИО, personal_data.birthday AS [Дата рождения], gender.title_gender AS Пол, personal_data.inn AS ИНН, 
                         passport_data.seria + ' ' + passport_data.num + ' ' + REPLACE(REPLACE(REPLACE(passport_data.who_issued, ' ', ' #'), '# ', ''), '#', '') + ' ' + CAST(passport_data.when_issued AS char(10)) 
                         AS [Паспортные данные (серия, номер, кем, когда выдан)], personal_data.snils AS СНИЛС, personal_data.polis AS ПОЛИС
FROM            personal_data INNER JOIN
                         img ON personal_data.id_photo = img.id INNER JOIN
                         passport_data ON personal_data.id_passport = passport_data.id INNER JOIN
                         gender ON personal_data.id_gender = gender.id";
                LoadData(script);
                labelDgv.Text = "Персональные данные сотрудников";
            }
            if (selData == "Служебные данные")
            {

                string script = @"SELECT        service_data.id AS Код, REPLACE(REPLACE(REPLACE(personal_data.surname, ' ', ' #'), '# ', ''), '#', '') + ' ' + REPLACE(REPLACE(REPLACE(personal_data.name, ' ', ' #'), '# ', ''), '#', '') 
                         + ' ' + REPLACE(REPLACE(REPLACE(personal_data.middle_name, ' ', ' #'), '# ', ''), '#', '') AS ФИО, REPLACE(REPLACE(REPLACE(country.title_country, ' ', ' #'), '# ', ''), '#', '') 
                         + ', ' + REPLACE(REPLACE(REPLACE(region.title_region, ' ', ' #'), '# ', ''), '#', '') + ', ' + REPLACE(REPLACE(REPLACE(city.title_city, ' ', ' #'), '# ', ''), '#', '') + ', ' + REPLACE(REPLACE(REPLACE(street.title_street, ' ', ' #'), '# ', ''), '#', 
                         '') AS [Адрес (Страна, Регион, Город, Улица)], REPLACE(REPLACE(REPLACE(CAST(education.title_edu AS nchar(20)), ' ', ' #'), '# ', ''), '#', '') + ' ' + CAST(education.date_begin AS char(10)) + ' - ' + CAST(education.date_end AS char(10)) 
                         AS [Образовательное учреждение (начало - конец)], job_position.title_position AS Должность, department.title_depart AS Отдел, department.cab_depart AS Кабинет, department.tel_depart AS Телефон
FROM            service_data INNER JOIN
                         address ON service_data.id_address = address.id INNER JOIN
                         city ON address.id_city = city.id INNER JOIN
                         country ON address.id_country = country.id INNER JOIN
                         department ON service_data.id_department = department.id INNER JOIN
                         education ON service_data.id_education = education.id INNER JOIN
                         job_position ON service_data.id_job_position = job_position.id INNER JOIN
                         region ON address.id_region = region.id INNER JOIN
                         street ON address.id_street = street.id INNER JOIN
                         personal_data ON service_data.id = personal_data.id";
                LoadData(script);
                labelDgv.Text = "Служебные данные сотрудников";

            }
            if (selData == "Паспортные данные")
            {
                dataGridView.Columns.Clear();
                dataGridView.AutoGenerateColumns = true;
                dataGridView.DataSource = dataSet;
                dataGridView.DataMember = "passport_data";
                labelDgv.Text = "Паспортные данные сотрудников";
            }
        }

        private void guideMenu_Click(object sender, EventArgs e)
        {
            GuideForm guideForm = new GuideForm();
            guideForm.Show();
        }
    }
}
