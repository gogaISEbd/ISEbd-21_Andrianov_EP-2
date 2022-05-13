
namespace CarRepairShopView
{
    partial class FormReplenishmentWareHouse
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
            this.labelWareHouse = new System.Windows.Forms.Label();
            this.labelIngredient = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.comboBoxWareHouse = new System.Windows.Forms.ComboBox();
            this.comboBoxIngredient = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWareHouse
            // 
            this.labelWareHouse.AutoSize = true;
            this.labelWareHouse.Location = new System.Drawing.Point(26, 31);
            this.labelWareHouse.Name = "labelWareHouse";
            this.labelWareHouse.Size = new System.Drawing.Size(43, 15);
            this.labelWareHouse.TabIndex = 0;
            this.labelWareHouse.Text = "Склад:";
            // 
            // labelIngredient
            // 
            this.labelIngredient.AutoSize = true;
            this.labelIngredient.Location = new System.Drawing.Point(24, 79);
            this.labelIngredient.Name = "labelIngredient";
            this.labelIngredient.Size = new System.Drawing.Size(75, 15);
            this.labelIngredient.TabIndex = 1;
            this.labelIngredient.Text = "Компонент:";
           
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(26, 125);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(75, 15);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Количество:";
            // 
            // comboBoxWareHouse
            // 
            this.comboBoxWareHouse.FormattingEnabled = true;
            this.comboBoxWareHouse.Location = new System.Drawing.Point(154, 31);
            this.comboBoxWareHouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxWareHouse.Name = "comboBoxWareHouse";
            this.comboBoxWareHouse.Size = new System.Drawing.Size(246, 23);
            this.comboBoxWareHouse.TabIndex = 3;
            // 
            // comboBoxIngredient
            // 
            this.comboBoxIngredient.FormattingEnabled = true;
            this.comboBoxIngredient.Location = new System.Drawing.Point(154, 79);
            this.comboBoxIngredient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxIngredient.Name = "comboBoxIngredient";
            this.comboBoxIngredient.Size = new System.Drawing.Size(246, 23);
            this.comboBoxIngredient.TabIndex = 4;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(154, 123);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(246, 23);
            this.textBoxCount.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(154, 162);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(118, 22);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(288, 161);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(111, 22);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormReplenishmentWareHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 193);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxIngredient);
            this.Controls.Add(this.comboBoxWareHouse);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelIngredient);
            this.Controls.Add(this.labelWareHouse);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormReplenishmentWareHouse";
            this.Text = "Пополнение склада";
            this.Load += new System.EventHandler(this.FormReplenishmentWareHouse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelWareHouse;

        private System.Windows.Forms.Label labelIngredient;

        private System.Windows.Forms.Label labelCount;

        private System.Windows.Forms.ComboBox comboBoxWareHouse;

        private System.Windows.Forms.ComboBox comboBoxIngredient;

        private System.Windows.Forms.TextBox textBoxCount;

        private System.Windows.Forms.Button buttonSave;

        private System.Windows.Forms.Button buttonCancel;
    }

    #endregion
}
