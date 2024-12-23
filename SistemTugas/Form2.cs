using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            dgvTasks.CurrentCellDirtyStateChanged += dgvTasks_CurrentCellDirtyStateChanged;
            dgvTasks.CellContentClick += dgvTasks_CellContentClick;
        }

        private void LoadTasks()
        {
            using (var connection = DBHelper.GetConnection())
            {
                connection.Open();
                try
                {
                    string query = "SELECT id, nama_tugas, tenggat_waktu, prioritas, status FROM tugas WHERE pengguna_id = @UserId";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@UserId", Session.UserId);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvTasks.DataSource = dt;

                    if (!dgvTasks.Columns.Contains("Status"))
                    {
                        DataGridViewCheckBoxColumn statusColumn = new DataGridViewCheckBoxColumn
                        {
                            Name = "Status",
                            HeaderText = "Selesai",
                            DataPropertyName = "status",
                            TrueValue = 1,
                            FalseValue = 0
                        };
                        dgvTasks.Columns.Add(statusColumn);
                        dgvTasks.Columns["id"].Visible = false;
                    }

                    AddActionButtons();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void AddActionButtons()
        {
            if (!dgvTasks.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dgvTasks.Columns.Add(editColumn);
            }

            if (!dgvTasks.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Hapus",
                    Text = "Hapus",
                    UseColumnTextForButtonValue = true
                };
                dgvTasks.Columns.Add(deleteColumn);
            }
        }

        private void dgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvTasks.Columns["Edit"].Index)
                {
                    int taskId = Convert.ToInt32(dgvTasks.Rows[e.RowIndex].Cells["id"].Value);
                    string taskName = dgvTasks.Rows[e.RowIndex].Cells["nama_tugas"].Value.ToString();
                    DateTime dueDate = Convert.ToDateTime(dgvTasks.Rows[e.RowIndex].Cells["tenggat_waktu"].Value);
                    string priority = dgvTasks.Rows[e.RowIndex].Cells["prioritas"].Value.ToString();

                    EditTaskForm editForm = new EditTaskForm(taskId, taskName, dueDate, priority);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadTasks(); // Memuat ulang tugas setelah perubahan
                    }
                }
                else if (e.ColumnIndex == dgvTasks.Columns["Delete"].Index)
                {
                    int taskId = Convert.ToInt32(dgvTasks.Rows[e.RowIndex].Cells["id"].Value);

                    DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus tugas ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        using (var connection = DBHelper.GetConnection())
                        {
                            connection.Open();
                            string query = "DELETE FROM tugas WHERE id = @TaskId";
                            using (var cmd = new MySqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@TaskId", taskId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        LoadTasks();
                        MessageBox.Show("Tugas berhasil dihapus.");
                    }
                }
            }
        }

        private void dgvTasks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTasks.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                int taskId = Convert.ToInt32(dgvTasks.Rows[e.RowIndex].Cells["id"].Value);
                bool isCompleted = Convert.ToBoolean(dgvTasks.Rows[e.RowIndex].Cells["Status"].Value);

                UpdateTaskStatus(taskId, isCompleted);
            }
        }

        private void UpdateTaskStatus(int taskId, bool isCompleted)
        {
            using (var connection = DBHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE tugas SET status = @Status WHERE id = @TaskId";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Status", isCompleted ? 1 : 0);
                        cmd.Parameters.AddWithValue("@TaskId", taskId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void dgvTasks_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTasks.IsCurrentCellDirty)
            {
                dgvTasks.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (Session.UserId != 0) 
            {
                MessageBox.Show("Anda belum login. Silakan login terlebih dahulu.");
                return; // Jangan lanjutkan membuka form AddTaskForm jika belum login
            }

            AddTaskForm addTaskForm = new AddTaskForm();
            addTaskForm.ShowDialog();

            LoadTasks();
        }
    }
}
