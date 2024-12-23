using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace SistemTugas
{
    public partial class AddTaskForm : Form
    {
        public AddTaskForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string namaTugas = txtNamaTugas.Text;
            DateTime tenggatWaktu = dtpTenggatWaktu.Value;
            string prioritas = cmbPrioritas.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(namaTugas) || string.IsNullOrEmpty(prioritas))
            {
                MessageBox.Show("Semua field harus diisi.");
                return;
            }

            int penggunaId = Session.UserId; 

            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "INSERT INTO tugas (nama_tugas, tenggat_waktu, prioritas, status, pengguna_id) " +
                                   "VALUES (@Nama, @Tenggat, @Prioritas, 0, @UserId)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nama", namaTugas);
                        cmd.Parameters.AddWithValue("@Tenggat", tenggatWaktu.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@Prioritas", prioritas);
                        cmd.Parameters.AddWithValue("@UserId", penggunaId);

                        MessageBox.Show($"Debug Info: Query is running with UserId = {penggunaId}");
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tugas berhasil ditambahkan!");
                        this.Close();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("MySQL Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }
    }
}
