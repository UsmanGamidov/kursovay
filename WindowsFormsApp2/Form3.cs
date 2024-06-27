using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Database1.mdf;Integrated Security=True";

        public Form3()
        {
            InitializeComponent();

            // Подписываемся на событие Load формы
            this.Load += new EventHandler(Form3_Load);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            // Проверяем видимость DataGridView
            if (!dataGridView1.Visible)
            {
                dataGridView1.Visible = true;
            }

            // Создаем подключение к базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Turi";

                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    connection.Open();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        // Устанавливаем источник данных для DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show(
                            "Таблица Turi не содержит данных.",
                            "Информация",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ошибка при получении данных: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}
