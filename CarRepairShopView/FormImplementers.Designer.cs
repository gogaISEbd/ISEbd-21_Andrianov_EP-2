
namespace CarRepairShopView
{
    partial class FormImplementers
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
            this.buttonUpdateImplementer = new System.Windows.Forms.Button();
            this.buttonDeleteImplementer = new System.Windows.Forms.Button();
            this.buttonEditImplementer = new System.Windows.Forms.Button();
            this.buttonAddImplementer = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonUpdateImplementer
            // 
            this.buttonUpdateImplementer.Location = new System.Drawing.Point(487, 186);
            this.buttonUpdateImplementer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdateImplementer.Name = "buttonUpdateImplementer";
            this.buttonUpdateImplementer.Size = new System.Drawing.Size(110, 31);
            this.buttonUpdateImplementer.TabIndex = 14;
            this.buttonUpdateImplementer.Text = "Обновить";
            this.buttonUpdateImplementer.UseVisualStyleBackColor = true;
            this.buttonUpdateImplementer.Click += new System.EventHandler(this.buttonUpdateImplementer_Click);
            // 
            // buttonDeleteImplementer
            // 
            this.buttonDeleteImplementer.Location = new System.Drawing.Point(488, 127);
            this.buttonDeleteImplementer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDeleteImplementer.Name = "buttonDeleteImplementer";
            this.buttonDeleteImplementer.Size = new System.Drawing.Size(110, 31);
            this.buttonDeleteImplementer.TabIndex = 13;
            this.buttonDeleteImplementer.Text = "Удалить";
            this.buttonDeleteImplementer.UseVisualStyleBackColor = true;
            this.buttonDeleteImplementer.Click += new System.EventHandler(this.buttonDeleteImplementer_Click);
            // 
            // buttonEditImplementer
            // 
            this.buttonEditImplementer.Location = new System.Drawing.Point(487, 64);
            this.buttonEditImplementer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEditImplementer.Name = "buttonEditImplementer";
            this.buttonEditImplementer.Size = new System.Drawing.Size(110, 31);
            this.buttonEditImplementer.TabIndex = 12;
            this.buttonEditImplementer.Text = "Изменить";
            this.buttonEditImplementer.UseVisualStyleBackColor = true;
            this.buttonEditImplementer.Click += new System.EventHandler(this.buttonEditImplementer_Click);
            // 
            // buttonAddImplementer
            // 
            this.buttonAddImplementer.Location = new System.Drawing.Point(488, 11);
            this.buttonAddImplementer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddImplementer.Name = "buttonAddImplementer";
            this.buttonAddImplementer.Size = new System.Drawing.Size(110, 31);
            this.buttonAddImplementer.TabIndex = 11;
            this.buttonAddImplementer.Text = "Добавить";
            this.buttonAddImplementer.UseVisualStyleBackColor = true;
            this.buttonAddImplementer.Click += new System.EventHandler(this.buttonAddImplementer_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView.Location = new System.Drawing.Point(12, 11);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(469, 340);
            this.dataGridView.TabIndex = 10;
            // 
            // FormImplementers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 358);
            this.Controls.Add(this.buttonUpdateImplementer);
            this.Controls.Add(this.buttonDeleteImplementer);
            this.Controls.Add(this.buttonEditImplementer);
            this.Controls.Add(this.buttonAddImplementer);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormImplementers";
            this.Text = "Исполнители";
            this.Load += new System.EventHandler(this.FormImplementers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonUpdateImplementer;
        private System.Windows.Forms.Button buttonDeleteImplementer;
        private System.Windows.Forms.Button buttonEditImplementer;
        private System.Windows.Forms.Button buttonAddImplementer;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}