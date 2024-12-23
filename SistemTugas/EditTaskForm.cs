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

namespace SistemTugas
{
    public partial class EditTaskForm : Form
    {
        public EditTaskForm()
        {
            InitializeComponent();
        }

        public EditTaskForm(int taskId, string taskName, DateTime dueDate, string priority)
        {
            InitializeComponent();

            // Simpan nilai parameter ke variabel lokal
            this.TaskId = taskId;
            txtTaskName.Text = taskName;
            dtpDueDate.Value = dueDate;
            cbPriority.SelectedItem = priority;
        }

        // Tambahkan variabel untuk menampung TaskId
        private int TaskId;


        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newTaskName = txtTaskName.Text;
            DateTime newDueDate = dtpDueDate.Value;
            string newPriority = cbPriority.SelectedItem.ToString();

            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();
                string query = "UPDATE tugas SET nama_tugas = @TaskName, tenggat_waktu = @DueDate, prioritas = @Priority WHERE id = @TaskId";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TaskName", newTaskName);
                    cmd.Parameters.AddWithValue("@DueDate", newDueDate);
                    cmd.Parameters.AddWithValue("@Priority", newPriority);
                    cmd.Parameters.AddWithValue("@TaskId", TaskId);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Tugas berhasil diperbarui!");
            this.DialogResult = DialogResult.OK; // Untuk kasih tahu parent form nya
            this.Close();
        }

        private void txtTaskName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
