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

            using (var connection = DBHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO tugas (pengguna_id, nama_tugas, tenggat_tugas, prioritas, status)" + "VALUES (@UserId, @Nama, @Tenggat, @Prioritas, 'Belum')";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserId", Session.UserId);
                        cmd.Parameters.AddWithValue("@Nama", namaTugas);
                        cmd.Parameters.AddWithValue("@Tenggat", tenggatWaktu);
                        cmd.Parameters.AddWithValue("@Prioritas", prioritas);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tugas berhasil ditambahkan! Jangan Lupa Dikerjakan Ya!!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
