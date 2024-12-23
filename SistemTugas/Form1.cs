using MySql.Data.MySqlClient;

namespace SistemTugas
{
    public partial class linkRegister : Form
    {
        public linkRegister()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email dan password harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = DBHelper.GetConnection())
                {
                    connection.Open();

                    // Validasi email dan password
                    string query = "SELECT id, nama FROM pengguna WHERE email = @Email AND password = @Password";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32("id");
                                string fullName = reader.GetString("nama");

                                UserSession.UserId = userId;
                                UserSession.UserName = fullName;

                                MessageBox.Show($"Selamat datang, {fullName}!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                DashboardForm dashboard = new DashboardForm();
                                dashboard.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Email atau password salah.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkRegister_Click(object sender, EventArgs e)
        {
            //this.Hide();

            //RegisterForm registerForm = new RegisterForm();
            //registerForm.ShowDialog();

            //this.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();

            this.Show();
        }
    }
}
