namespace RPGSKELETON
{
    partial class UI
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EXPlabel = new System.Windows.Forms.Label();
            this.HPlabel = new System.Windows.Forms.Label();
            this.Goldlabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "HP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gold:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Exp:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Level:";
            // 
            // EXPlabel
            // 
            this.EXPlabel.AutoSize = true;
            this.EXPlabel.Location = new System.Drawing.Point(110, 74);
            this.EXPlabel.Name = "EXPlabel";
            this.EXPlabel.Size = new System.Drawing.Size(59, 20);
            this.EXPlabel.TabIndex = 4;
            this.EXPlabel.Text = "<EXP>";
            // 
            // HPlabel
            // 
            this.HPlabel.AutoSize = true;
            this.HPlabel.Location = new System.Drawing.Point(110, 19);
            this.HPlabel.Name = "HPlabel";
            this.HPlabel.Size = new System.Drawing.Size(91, 20);
            this.HPlabel.TabIndex = 5;
            this.HPlabel.Text = "<HitPoints>";
            // 
            // Goldlabel
            // 
            this.Goldlabel.AutoSize = true;
            this.Goldlabel.Location = new System.Drawing.Point(110, 48);
            this.Goldlabel.Name = "Goldlabel";
            this.Goldlabel.Size = new System.Drawing.Size(61, 20);
            this.Goldlabel.TabIndex = 6;
            this.Goldlabel.Text = "<Gold>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(110, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "<Level>";
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 634);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Goldlabel);
            this.Controls.Add(this.HPlabel);
            this.Controls.Add(this.EXPlabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UI";
            this.Text = "RPG";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label EXPlabel;
        private System.Windows.Forms.Label HPlabel;
        private System.Windows.Forms.Label Goldlabel;
        private System.Windows.Forms.Label label8;
    }
}

