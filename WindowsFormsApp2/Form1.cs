using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO Rabotniki (login, password, rol, FIO) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}')", sqlConnection);
            
            sqlConnection.Open();

            MessageBox.Show(command.ExecuteNonQuery().ToString());

            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT login, password FROM Rabotniki WHERE login = @login";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@login", textBox5.Text);

                    sqlConnection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string dbPassword = reader["password"].ToString();
                            if (dbPassword == textBox6.Text)
                            {
                                OpenForm2();
                            }
                            else
                            {
                                MessageBox.Show("Пароль неверен.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Login не найден.");
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
        private void OpenForm2()
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

    }
}
