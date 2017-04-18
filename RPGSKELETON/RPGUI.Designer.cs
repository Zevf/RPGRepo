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
            this.LevelLable = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxWeapons = new System.Windows.Forms.ComboBox();
            this.comboBoxPotions = new System.Windows.Forms.ComboBox();
            this.buttonUseWeapon = new System.Windows.Forms.Button();
            this.buttonSouth = new System.Windows.Forms.Button();
            this.buttonUsePotion = new System.Windows.Forms.Button();
            this.buttonWest = new System.Windows.Forms.Button();
            this.buttonNorth = new System.Windows.Forms.Button();
            this.buttonEast = new System.Windows.Forms.Button();
            this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
            this.richTextBoxLocal = new System.Windows.Forms.RichTextBox();
            this.dataGridViewInventory = new System.Windows.Forms.DataGridView();
            this.dataGridViewQuest = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuest)).BeginInit();
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
            // LevelLable
            // 
            this.LevelLable.AutoSize = true;
            this.LevelLable.Location = new System.Drawing.Point(110, 100);
            this.LevelLable.Name = "LevelLable";
            this.LevelLable.Size = new System.Drawing.Size(64, 20);
            this.LevelLable.TabIndex = 7;
            this.LevelLable.Text = "<Level>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(729, 511);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Select Action";
            // 
            // comboBoxWeapons
            // 
            this.comboBoxWeapons.FormattingEnabled = true;
            this.comboBoxWeapons.Location = new System.Drawing.Point(493, 559);
            this.comboBoxWeapons.Name = "comboBoxWeapons";
            this.comboBoxWeapons.Size = new System.Drawing.Size(121, 28);
            this.comboBoxWeapons.TabIndex = 9;
            // 
            // comboBoxPotions
            // 
            this.comboBoxPotions.FormattingEnabled = true;
            this.comboBoxPotions.Location = new System.Drawing.Point(493, 593);
            this.comboBoxPotions.Name = "comboBoxPotions";
            this.comboBoxPotions.Size = new System.Drawing.Size(121, 28);
            this.comboBoxPotions.TabIndex = 10;
            // 
            // buttonUseWeapon
            // 
            this.buttonUseWeapon.Location = new System.Drawing.Point(744, 544);
            this.buttonUseWeapon.Name = "buttonUseWeapon";
            this.buttonUseWeapon.Size = new System.Drawing.Size(75, 31);
            this.buttonUseWeapon.TabIndex = 11;
            this.buttonUseWeapon.Text = "Swing!";
            this.buttonUseWeapon.UseVisualStyleBackColor = true;
            this.buttonUseWeapon.Click += new System.EventHandler(this.buttonUseWeapon_Click);
            // 
            // buttonSouth
            // 
            this.buttonSouth.Location = new System.Drawing.Point(620, 488);
            this.buttonSouth.Name = "buttonSouth";
            this.buttonSouth.Size = new System.Drawing.Size(75, 31);
            this.buttonSouth.TabIndex = 12;
            this.buttonSouth.Text = "South";
            this.buttonSouth.UseVisualStyleBackColor = true;
            this.buttonSouth.Click += new System.EventHandler(this.buttonSouth_Click);
            // 
            // buttonUsePotion
            // 
            this.buttonUsePotion.Location = new System.Drawing.Point(744, 593);
            this.buttonUsePotion.Name = "buttonUsePotion";
            this.buttonUsePotion.Size = new System.Drawing.Size(75, 31);
            this.buttonUsePotion.TabIndex = 13;
            this.buttonUsePotion.Text = "Potion";
            this.buttonUsePotion.UseVisualStyleBackColor = true;
            this.buttonUsePotion.Click += new System.EventHandler(this.buttonUsePotion_Click);
            // 
            // buttonWest
            // 
            this.buttonWest.Location = new System.Drawing.Point(539, 463);
            this.buttonWest.Name = "buttonWest";
            this.buttonWest.Size = new System.Drawing.Size(75, 31);
            this.buttonWest.TabIndex = 14;
            this.buttonWest.Text = "West";
            this.buttonWest.UseVisualStyleBackColor = true;
            this.buttonWest.Click += new System.EventHandler(this.buttonWest_Click);
            // 
            // buttonNorth
            // 
            this.buttonNorth.Location = new System.Drawing.Point(620, 442);
            this.buttonNorth.Name = "buttonNorth";
            this.buttonNorth.Size = new System.Drawing.Size(75, 31);
            this.buttonNorth.TabIndex = 15;
            this.buttonNorth.Text = "North";
            this.buttonNorth.UseVisualStyleBackColor = true;
            this.buttonNorth.Click += new System.EventHandler(this.buttonNorth_Click);
            // 
            // buttonEast
            // 
            this.buttonEast.Location = new System.Drawing.Point(701, 463);
            this.buttonEast.Name = "buttonEast";
            this.buttonEast.Size = new System.Drawing.Size(75, 31);
            this.buttonEast.TabIndex = 16;
            this.buttonEast.Text = "East";
            this.buttonEast.UseVisualStyleBackColor = true;
            this.buttonEast.Click += new System.EventHandler(this.buttonEast_Click);
            // 
            // richTextBoxMessage
            // 
            this.richTextBoxMessage.Location = new System.Drawing.Point(471, 130);
            this.richTextBoxMessage.Name = "richTextBoxMessage";
            this.richTextBoxMessage.Size = new System.Drawing.Size(360, 286);
            this.richTextBoxMessage.TabIndex = 17;
            this.richTextBoxMessage.Text = "";
            // 
            // richTextBoxLocal
            // 
            this.richTextBoxLocal.Location = new System.Drawing.Point(471, 19);
            this.richTextBoxLocal.Name = "richTextBoxLocal";
            this.richTextBoxLocal.Size = new System.Drawing.Size(360, 105);
            this.richTextBoxLocal.TabIndex = 18;
            this.richTextBoxLocal.Text = "";
            // 
            // dataGridViewInventory
            // 
            this.dataGridViewInventory.AllowUserToAddRows = false;
            this.dataGridViewInventory.AllowUserToDeleteRows = false;
            this.dataGridViewInventory.AllowUserToResizeRows = false;
            this.dataGridViewInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewInventory.Enabled = false;
            this.dataGridViewInventory.Location = new System.Drawing.Point(16, 130);
            this.dataGridViewInventory.MultiSelect = false;
            this.dataGridViewInventory.Name = "dataGridViewInventory";
            this.dataGridViewInventory.ReadOnly = true;
            this.dataGridViewInventory.RowHeadersVisible = false;
            this.dataGridViewInventory.RowTemplate.Height = 28;
            this.dataGridViewInventory.Size = new System.Drawing.Size(392, 309);
            this.dataGridViewInventory.TabIndex = 19;
            // 
            // dataGridViewQuest
            // 
            this.dataGridViewQuest.AllowUserToAddRows = false;
            this.dataGridViewQuest.AllowUserToDeleteRows = false;
            this.dataGridViewQuest.AllowUserToResizeRows = false;
            this.dataGridViewQuest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuest.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewQuest.Enabled = false;
            this.dataGridViewQuest.Location = new System.Drawing.Point(16, 446);
            this.dataGridViewQuest.MultiSelect = false;
            this.dataGridViewQuest.Name = "dataGridViewQuest";
            this.dataGridViewQuest.ReadOnly = true;
            this.dataGridViewQuest.RowHeadersVisible = false;
            this.dataGridViewQuest.RowTemplate.Height = 28;
            this.dataGridViewQuest.Size = new System.Drawing.Size(392, 189);
            this.dataGridViewQuest.TabIndex = 20;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 634);
            this.Controls.Add(this.dataGridViewQuest);
            this.Controls.Add(this.dataGridViewInventory);
            this.Controls.Add(this.richTextBoxLocal);
            this.Controls.Add(this.richTextBoxMessage);
            this.Controls.Add(this.buttonEast);
            this.Controls.Add(this.buttonNorth);
            this.Controls.Add(this.buttonWest);
            this.Controls.Add(this.buttonUsePotion);
            this.Controls.Add(this.buttonSouth);
            this.Controls.Add(this.buttonUseWeapon);
            this.Controls.Add(this.comboBoxPotions);
            this.Controls.Add(this.comboBoxWeapons);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LevelLable);
            this.Controls.Add(this.Goldlabel);
            this.Controls.Add(this.HPlabel);
            this.Controls.Add(this.EXPlabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UI";
            this.Text = "RPG";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuest)).EndInit();
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
        private System.Windows.Forms.Label LevelLable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxWeapons;
        private System.Windows.Forms.ComboBox comboBoxPotions;
        private System.Windows.Forms.Button buttonUseWeapon;
        private System.Windows.Forms.Button buttonSouth;
        private System.Windows.Forms.Button buttonUsePotion;
        private System.Windows.Forms.Button buttonWest;
        private System.Windows.Forms.Button buttonNorth;
        private System.Windows.Forms.Button buttonEast;
        private System.Windows.Forms.RichTextBox richTextBoxMessage;
        private System.Windows.Forms.RichTextBox richTextBoxLocal;
        private System.Windows.Forms.DataGridView dataGridViewInventory;
        private System.Windows.Forms.DataGridView dataGridViewQuest;
    }
}

