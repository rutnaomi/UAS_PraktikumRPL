using MySql.Data.MySqlClient;

namespace SistemTugas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            using (var connection = DBHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT id FROM pengguna WHERE email = @Email AND password = @Password";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int userId = Convert.ToInt32(result);

                            // Simpan ID pengguna untuk digunakan nanti
                            Session.UserId = userId;

                            // Buka Form Dashboard
                            DashboardForm dashboard = new DashboardForm();
                            this.Hide();
                            dashboard.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("Email atau Password salah.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
