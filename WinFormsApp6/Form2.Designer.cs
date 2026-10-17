namespace WinFormsApp6
{
    partial class Form2
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
            dataGridViewBooks = new DataGridView();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnBarrow = new Button();
            btnReturn = new Button();
            btnSil = new Button();
            btnSon = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBooks.Location = new Point(38, 176);
            dataGridViewBooks.MultiSelect = false;
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.RowHeadersWidth = 51;
            dataGridViewBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBooks.Size = new Size(687, 232);
            dataGridViewBooks.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(234, 71);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "KİTAP ADI ARAYINIZ.";
            txtSearch.Size = new Size(216, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(456, 69);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "ARA";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnBarrow
            // 
            btnBarrow.Location = new Point(594, 71);
            btnBarrow.Name = "btnBarrow";
            btnBarrow.Size = new Size(94, 29);
            btnBarrow.TabIndex = 3;
            btnBarrow.Text = "ÖDÜNÇ AL";
            btnBarrow.UseVisualStyleBackColor = true;
            btnBarrow.Click += btnBarrow_Click;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(594, 141);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(94, 29);
            btnReturn.TabIndex = 4;
            btnReturn.Text = "TESLİM ET";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(594, 12);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(94, 29);
            btnSil.TabIndex = 5;
            btnSil.Text = "SİL";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnSon
            // 
            btnSon.Location = new Point(694, 418);
            btnSon.Name = "btnSon";
            btnSon.Size = new Size(94, 29);
            btnSon.TabIndex = 6;
            btnSon.Text = "ÇIKIŞ YAP";
            btnSon.UseVisualStyleBackColor = true;
            btnSon.Click += btnSon_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Kitap1;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSon);
            Controls.Add(btnSil);
            Controls.Add(btnReturn);
            Controls.Add(btnBarrow);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dataGridViewBooks);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewBooks;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnBarrow;
        private Button btnReturn;
        private Button btnSil;
        private Button btnSon;
    }
}