namespace MVPdemo
{
    partial class 利用者View
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridView = new DataGridView();
            Panel操作 = new Panel();
            Buttonキャンセル = new Button();
            Button保存 = new Button();
            Button削除 = new Button();
            TextBox誕生日 = new TextBox();
            label4 = new Label();
            TextBox住所 = new TextBox();
            label3 = new Label();
            TextBox利用者名 = new TextBox();
            label2 = new Label();
            TextBoxID = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            Button追加 = new Button();
            ((System.ComponentModel.ISupportInitialize)DataGridView).BeginInit();
            Panel操作.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // DataGridView
            // 
            DataGridView.AllowUserToAddRows = false;
            DataGridView.AllowUserToDeleteRows = false;
            DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView.Dock = DockStyle.Fill;
            DataGridView.Location = new Point(0, 39);
            DataGridView.Name = "DataGridView";
            DataGridView.ReadOnly = true;
            DataGridView.Size = new Size(474, 548);
            DataGridView.TabIndex = 1;
            // 
            // Panel操作
            // 
            Panel操作.Controls.Add(Buttonキャンセル);
            Panel操作.Controls.Add(Button保存);
            Panel操作.Controls.Add(Button削除);
            Panel操作.Controls.Add(TextBox誕生日);
            Panel操作.Controls.Add(label4);
            Panel操作.Controls.Add(TextBox住所);
            Panel操作.Controls.Add(label3);
            Panel操作.Controls.Add(TextBox利用者名);
            Panel操作.Controls.Add(label2);
            Panel操作.Controls.Add(TextBoxID);
            Panel操作.Controls.Add(label1);
            Panel操作.Dock = DockStyle.Right;
            Panel操作.Location = new Point(474, 0);
            Panel操作.Name = "Panel操作";
            Panel操作.Size = new Size(505, 587);
            Panel操作.TabIndex = 2;
            // 
            // Buttonキャンセル
            // 
            Buttonキャンセル.BackColor = Color.Gray;
            Buttonキャンセル.FlatAppearance.BorderSize = 0;
            Buttonキャンセル.FlatStyle = FlatStyle.Flat;
            Buttonキャンセル.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            Buttonキャンセル.ForeColor = Color.White;
            Buttonキャンセル.Location = new Point(388, 391);
            Buttonキャンセル.Name = "Buttonキャンセル";
            Buttonキャンセル.Size = new Size(75, 23);
            Buttonキャンセル.TabIndex = 13;
            Buttonキャンセル.Text = "キャンセル";
            Buttonキャンセル.UseVisualStyleBackColor = false;
            // 
            // Button保存
            // 
            Button保存.BackColor = Color.FromArgb(0, 192, 0);
            Button保存.FlatAppearance.BorderSize = 0;
            Button保存.FlatStyle = FlatStyle.Flat;
            Button保存.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            Button保存.ForeColor = Color.White;
            Button保存.Location = new Point(272, 391);
            Button保存.Name = "Button保存";
            Button保存.Size = new Size(75, 23);
            Button保存.TabIndex = 12;
            Button保存.Text = "保存";
            Button保存.UseVisualStyleBackColor = false;
            // 
            // Button削除
            // 
            Button削除.BackColor = Color.Red;
            Button削除.FlatAppearance.BorderSize = 0;
            Button削除.FlatStyle = FlatStyle.Flat;
            Button削除.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            Button削除.ForeColor = Color.White;
            Button削除.Location = new Point(31, 391);
            Button削除.Name = "Button削除";
            Button削除.Size = new Size(75, 23);
            Button削除.TabIndex = 11;
            Button削除.Text = "削除";
            Button削除.UseVisualStyleBackColor = false;
            // 
            // TextBox誕生日
            // 
            TextBox誕生日.Location = new Point(101, 185);
            TextBox誕生日.Name = "TextBox誕生日";
            TextBox誕生日.Size = new Size(100, 23);
            TextBox誕生日.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 188);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 6;
            label4.Text = "誕生日";
            // 
            // TextBox住所
            // 
            TextBox住所.Location = new Point(101, 133);
            TextBox住所.Name = "TextBox住所";
            TextBox住所.Size = new Size(381, 23);
            TextBox住所.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 136);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 4;
            label3.Text = "住所";
            // 
            // TextBox利用者名
            // 
            TextBox利用者名.Location = new Point(101, 83);
            TextBox利用者名.Name = "TextBox利用者名";
            TextBox利用者名.Size = new Size(278, 23);
            TextBox利用者名.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 86);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 2;
            label2.Text = "利用者名";
            // 
            // TextBoxID
            // 
            TextBoxID.Location = new Point(101, 35);
            TextBoxID.Name = "TextBoxID";
            TextBoxID.ReadOnly = true;
            TextBoxID.Size = new Size(100, 23);
            TextBoxID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 38);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // panel1
            // 
            panel1.Controls.Add(Button追加);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 39);
            panel1.TabIndex = 3;
            // 
            // Button追加
            // 
            Button追加.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Button追加.BackColor = Color.RoyalBlue;
            Button追加.FlatAppearance.BorderSize = 0;
            Button追加.FlatStyle = FlatStyle.Flat;
            Button追加.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            Button追加.ForeColor = Color.White;
            Button追加.Location = new Point(393, 8);
            Button追加.Name = "Button追加";
            Button追加.Size = new Size(75, 23);
            Button追加.TabIndex = 11;
            Button追加.Text = "追加";
            Button追加.UseVisualStyleBackColor = false;
            // 
            // 利用者一覧View
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 587);
            Controls.Add(DataGridView);
            Controls.Add(panel1);
            Controls.Add(Panel操作);
            Name = "利用者一覧View";
            Text = "一覧";
            ((System.ComponentModel.ISupportInitialize)DataGridView).EndInit();
            Panel操作.ResumeLayout(false);
            Panel操作.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private DataGridView DataGridView;
        private Panel Panel操作;
        private TextBox TextBox誕生日;
        private Label label4;
        private TextBox TextBox住所;
        private Label label3;
        private TextBox TextBox利用者名;
        private Label label2;
        private TextBox TextBoxID;
        private Label label1;
        private Button Buttonキャンセル;
        private Button Button保存;
        private Button Button削除;
        private Panel panel1;
        private Button Button追加;
    }
}
