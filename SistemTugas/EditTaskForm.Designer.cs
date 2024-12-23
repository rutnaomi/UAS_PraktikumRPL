namespace SistemTugas
{
    partial class EditTaskForm
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
            txtTaskName = new TextBox();
            dtpDueDate = new DateTimePicker();
            cbPriority = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(275, 70);
            label1.Name = "label1";
            label1.Size = new Size(154, 38);
            label1.TabIndex = 0;
            label1.Text = "EDIT TASK";
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(298, 147);
            txtTaskName.Multiline = true;
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(271, 44);
            txtTaskName.TabIndex = 1;
            txtTaskName.TextChanged += txtTaskName_TextChanged;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(298, 235);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(271, 27);
            dtpDueDate.TabIndex = 2;
            // 
            // cbPriority
            // 
            cbPriority.FormattingEnabled = true;
            cbPriority.Items.AddRange(new object[] { "Tinggi", "Sedang", "Rendah" });
            cbPriority.Location = new Point(298, 312);
            cbPriority.Name = "cbPriority";
            cbPriority.Size = new Size(271, 28);
            cbPriority.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(206, 389);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(121, 42);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save Changes";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(378, 389);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(121, 42);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(131, 148);
            label2.Name = "label2";
            label2.Size = new Size(108, 23);
            label2.TabIndex = 6;
            label2.Text = "Nama Tugas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(131, 235);
            label3.Name = "label3";
            label3.Size = new Size(126, 23);
            label3.TabIndex = 7;
            label3.Text = "Tenggat Tugas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(131, 312);
            label4.Name = "label4";
            label4.Size = new Size(77, 23);
            label4.TabIndex = 8;
            label4.Text = "Prioritas";
            // 
            // EditTaskForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.download__12_;
            ClientSize = new Size(704, 487);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbPriority);
            Controls.Add(dtpDueDate);
            Controls.Add(txtTaskName);
            Controls.Add(label1);
            Name = "EditTaskForm";
            Text = "EditTaskForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTaskName;
        private DateTimePicker dtpDueDate;
        private ComboBox cbPriority;
        private Button btnSave;
        private Button btnCancel;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}