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
        }

        private void LoadTasks()
        {
            using (var connection = DBHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nama_tugas, tenggat_waktu, prioritas, status FROM tugas WHERE pengguna_id = @UserId";
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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
            AddTaskForm addTaskForm = new AddTaskForm();
            addTaskForm.ShowDialog();

            LoadTasks();
        }
    }
}
