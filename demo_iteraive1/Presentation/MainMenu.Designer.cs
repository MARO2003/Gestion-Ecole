namespace demo_iteraive1.Presentation
{
    partial class MainMenu
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
            btnGererEtudiant = new Button();
            btnGererCour = new Button();
            btnQuitter = new Button();
            SuspendLayout();
            // 
            // btnGererEtudiant
            // 
            btnGererEtudiant.Location = new Point(65, 58);
            btnGererEtudiant.Name = "btnGererEtudiant";
            btnGererEtudiant.Size = new Size(176, 34);
            btnGererEtudiant.TabIndex = 0;
            btnGererEtudiant.Text = "Gerer les etudiants";
            btnGererEtudiant.UseVisualStyleBackColor = true;
            btnGererEtudiant.Click += btnGererEtudiant_Click;
            // 
            // btnGererCour
            // 
            btnGererCour.Location = new Point(65, 110);
            btnGererCour.Name = "btnGererCour";
            btnGererCour.Size = new Size(176, 34);
            btnGererCour.TabIndex = 1;
            btnGererCour.Text = "Gerer les cours";
            btnGererCour.UseVisualStyleBackColor = true;
            btnGererCour.Click += btnGererCour_Click;
            // 
            // btnQuitter
            // 
            btnQuitter.Location = new Point(207, 309);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(94, 29);
            btnQuitter.TabIndex = 2;
            btnQuitter.Text = "Quitter";
            btnQuitter.UseVisualStyleBackColor = true;
            btnQuitter.Click += btnQuitter_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 365);
            Controls.Add(btnQuitter);
            Controls.Add(btnGererCour);
            Controls.Add(btnGererEtudiant);
            Name = "MainMenu";
            Text = "MainMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnGererEtudiant;
        private Button btnGererCour;
        private Button btnQuitter;
    }
}