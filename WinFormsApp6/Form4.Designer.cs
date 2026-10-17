namespace WinFormsApp6
{
    partial class Form4
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
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            btnAdd = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(234, 136);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "KİTAP ADI:";
            txtTitle.Size = new Size(195, 27);
            txtTitle.TabIndex = 0;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(234, 232);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.PlaceholderText = "YAZAR:";
            txtAuthor.Size = new Size(195, 27);
            txtAuthor.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(484, 183);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "EKLE";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cooper Black", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(52, 34);
            label1.Name = "label1";
            label1.Size = new Size(715, 54);
            label1.TabIndex = 3;
            label1.Text = "OKUMAK HERKESİN HAKKI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cooper Black", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(-5, 335);
            label2.Name = "label2";
            label2.Size = new Size(807, 50);
            label2.TabIndex = 4;
            label2.Text = "ÖNERİNİZ İÇİN TEŞEKKÜR EDERİZ.";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Kitappp;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Name = "Form4";
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private TextBox txtAuthor;
        private Button btnAdd;
        private Label label1;
        private Label label2;
    }
}