namespace SistemTugas
{
    partial class AddTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNamaTugas = new TextBox();
            dtpTenggatWaktu = new DateTimePicker();
            cmbPrioritas = new ComboBox();
            btnSimpan = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(231, 53);
            label1.Name = "label1";
            label1.Size = new Size(204, 38);
            label1.TabIndex = 0;
            label1.Text = "Tambah Tugas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(87, 139);
            label2.Name = "label2";
            label2.Size = new Size(108, 23);
            label2.TabIndex = 1;
            label2.Text = "Nama Tugas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(87, 213);
            label3.Name = "label3";
            label3.Size = new Size(132, 23);
            label3.TabIndex = 2;
            label3.Text = "Tenggat Waktu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(87, 287);
            label4.Name = "label4";
            label4.Size = new Size(77, 23);
            label4.TabIndex = 3;
            label4.Text = "Prioritas";
            label4.Click += label4_Click;
            // 
            // txtNamaTugas
            // 
            txtNamaTugas.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNamaTugas.Location = new Point(284, 138);
            txtNamaTugas.Multiline = true;
            txtNamaTugas.Name = "txtNamaTugas";
            txtNamaTugas.Size = new Size(278, 34);
            txtNamaTugas.TabIndex = 4;
            // 
            // dtpTenggatWaktu
            // 
            dtpTenggatWaktu.Location = new Point(284, 213);
            dtpTenggatWaktu.Name = "dtpTenggatWaktu";
            dtpTenggatWaktu.Size = new Size(271, 27);
            dtpTenggatWaktu.TabIndex = 5;
            // 
            // cmbPrioritas
            // 
            cmbPrioritas.FormattingEnabled = true;
            cmbPrioritas.Items.AddRange(new object[] { "Tinggi", "Sedang", "Rendah" });
            cmbPrioritas.Location = new Point(284, 287);
            cmbPrioritas.Name = "cmbPrioritas";
            cmbPrioritas.Size = new Size(151, 28);
            cmbPrioritas.TabIndex = 6;
            // 
            // btnSimpan
            // 
            btnSimpan.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSimpan.Location = new Point(306, 365);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(94, 36);
            btnSimpan.TabIndex = 7;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // AddTaskForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 450);
            Controls.Add(btnSimpan);
            Controls.Add(cmbPrioritas);
            Controls.Add(dtpTenggatWaktu);
            Controls.Add(txtNamaTugas);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddTaskForm";
            Text = "AddTaskForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNamaTugas;
        private DateTimePicker dtpTenggatWaktu;
        private ComboBox cmbPrioritas;
        private Button btnSimpan;
    }
}