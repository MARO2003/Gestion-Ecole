namespace demo_iteraive1.Presentation.Views
{
    partial class StudentView
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
            btnQuitter = new Button();
            btnSave = new Button();
            btnReload = new Button();
            tableView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tableView).BeginInit();
            SuspendLayout();
            // 
            // btnQuitter
            // 
            btnQuitter.Anchor = AnchorStyles.Bottom;
            btnQuitter.Location = new Point(447, 409);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(94, 29);
            btnQuitter.TabIndex = 0;
            btnQuitter.Text = "Quitter";
            btnQuitter.UseVisualStyleBackColor = true;
            btnQuitter.Click += btnQuitter_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom;
            btnSave.Location = new Point(326, 409);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(115, 29);
            btnSave.TabIndex = 1;
            btnSave.Text = "Sauvegarder";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnReload
            // 
            btnReload.Anchor = AnchorStyles.Bottom;
            btnReload.Location = new Point(205, 409);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(115, 29);
            btnReload.TabIndex = 2;
            btnReload.Text = "Charger";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // tableView
            // 
            tableView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableView.Location = new Point(32, 45);
            tableView.Name = "tableView";
            tableView.RowHeadersWidth = 51;
            tableView.RowTemplate.Height = 29;
            tableView.Size = new Size(756, 345);
            tableView.TabIndex = 3;
            tableView.CellContentClick += tableView_CellContentClick;
            // 
            // StudentView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableView);
            Controls.Add(btnReload);
            Controls.Add(btnSave);
            Controls.Add(btnQuitter);
            Name = "StudentView";
            Text = "StudentView";
            ((System.ComponentModel.ISupportInitialize)tableView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnQuitter;
        private Button btnSave;
        private Button btnReload;
        private DataGridView tableView;
    }
}