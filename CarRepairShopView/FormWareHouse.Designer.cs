
namespace CarRepairShopView
{
    partial class FormWareHouse
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelFIO = new System.Windows.Forms.Label();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.groupBoxComponents = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxComponents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название: ";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(113, 37);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(182, 23);
            this.textBoxName.TabIndex = 1;
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(20, 84);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(37, 15);
            this.labelFIO.TabIndex = 2;
            this.labelFIO.Text = "ФИО:";
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(113, 84);
            this.textBoxFIO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(182, 23);
            this.textBoxFIO.TabIndex = 3;
            // 
            // groupBoxComponents
            // 
            this.groupBoxComponents.Controls.Add(this.dataGridView);
            this.groupBoxComponents.Location = new System.Drawing.Point(323, 19);
            this.groupBoxComponents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxComponents.Name = "groupBoxComponents";
            this.groupBoxComponents.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxComponents.Size = new System.Drawing.Size(396, 254);
            this.groupBoxComponents.TabIndex = 4;
            this.groupBoxComponents.TabStop = false;
            this.groupBoxComponents.Text = "Компоненты";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.ColumnCount});
            this.dataGridView.Location = new System.Drawing.Point(0, 16);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(262, 224);
            this.dataGridView.TabIndex = 0;
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "Column1";
            this.ColumnId.MinimumWidth = 6;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            this.ColumnId.Width = 125;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Название";
            this.ColumnName.MinimumWidth = 6;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 125;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.MinimumWidth = 6;
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.ReadOnly = true;
            this.ColumnCount.Width = 125;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(20, 238);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(125, 22);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(169, 237);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(129, 22);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormWareHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 282);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxComponents);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.labelFIO);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormWareHouse";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormWareHouse_Load);
            this.groupBoxComponents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox textBoxName;

        private System.Windows.Forms.Label labelFIO;

        private System.Windows.Forms.TextBox textBoxFIO;

        private System.Windows.Forms.GroupBox groupBoxComponents;

        private System.Windows.Forms.DataGridView dataGridView;

        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;

        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;

        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;

        private System.Windows.Forms.Button buttonSave;

        private System.Windows.Forms.Button buttonCancel;

        #endregion
    }
}