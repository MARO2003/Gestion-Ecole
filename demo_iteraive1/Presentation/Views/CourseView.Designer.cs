namespace demo_iteraive1.Presentation.Views
{
    partial class CourseView
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
            tableView = new DataGridView();
            btnReload = new Button();
            btnSave = new Button();
            btnQuitter = new Button();
            ((System.ComponentModel.ISupportInitialize)tableView).BeginInit();
            SuspendLayout();
            // 
            // tableView
            // 
            tableView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableView.Location = new Point(22, 29);
            tableView.Name = "tableView";
            tableView.RowHeadersWidth = 51;
            tableView.RowTemplate.Height = 29;
            tableView.Size = new Size(756, 345);
            tableView.TabIndex = 7;
            // 
            // btnReload
            // 
            btnReload.Anchor = AnchorStyles.Bottom;
            btnReload.Location = new Point(195, 393);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(115, 29);
            btnReload.TabIndex = 6;
            btnReload.Text = "Charger";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom;
            btnSave.Location = new Point(316, 393);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(115, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Sauvegarder";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnQuitter
            // 
            btnQuitter.Anchor = AnchorStyles.Bottom;
            btnQuitter.Location = new Point(437, 393);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(94, 29);
            btnQuitter.TabIndex = 4;
            btnQuitter.Text = "Quitter";
            btnQuitter.UseVisualStyleBackColor = true;
            btnQuitter.Click += btnQuitter_Click;
            // 
            // CourseView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableView);
            Controls.Add(btnReload);
            Controls.Add(btnSave);
            Controls.Add(btnQuitter);
            Name = "CourseView";
            Text = "CourseView";
            ((System.ComponentModel.ISupportInitialize)tableView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tableView;
        private Button btnReload;
        private Button btnSave;
        private Button btnQuitter;
    }
}