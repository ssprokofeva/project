namespace project
{
    partial class NewExhibition
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
            this.txtExhibitionName = new System.Windows.Forms.TextBox();
            this.dtpExhibition = new System.Windows.Forms.DateTimePicker();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.btnSaveNew = new System.Windows.Forms.Button();
            this.btnCancelNew = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Юбилейная дата:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Обложка:";
            // 
            // txtExhibitionName
            // 
            this.txtExhibitionName.Location = new System.Drawing.Point(275, 56);
            this.txtExhibitionName.Name = "txtExhibitionName";
            this.txtExhibitionName.Size = new System.Drawing.Size(100, 20);
            this.txtExhibitionName.TabIndex = 3;
            // 
            // dtpExhibition
            // 
            this.dtpExhibition.Location = new System.Drawing.Point(275, 115);
            this.dtpExhibition.Name = "dtpExhibition";
            this.dtpExhibition.Size = new System.Drawing.Size(200, 20);
            this.dtpExhibition.TabIndex = 4;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(275, 165);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(83, 48);
            this.btnSelectImage.TabIndex = 5;
            this.btnSelectImage.Text = "Выбрать файл ";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Location = new System.Drawing.Point(163, 257);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(75, 23);
            this.btnSaveNew.TabIndex = 6;
            this.btnSaveNew.Text = "Сохранить ";
            this.btnSaveNew.UseVisualStyleBackColor = true;
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // btnCancelNew
            // 
            this.btnCancelNew.Location = new System.Drawing.Point(400, 257);
            this.btnCancelNew.Name = "btnCancelNew";
            this.btnCancelNew.Size = new System.Drawing.Size(75, 23);
            this.btnCancelNew.TabIndex = 7;
            this.btnCancelNew.Text = "Отменить ";
            this.btnCancelNew.UseVisualStyleBackColor = true;
            this.btnCancelNew.Click += new System.EventHandler(this.btnCancelNew_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // NewExhibition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelNew);
            this.Controls.Add(this.btnSaveNew);
            this.Controls.Add(this.btnSelectImage);
            this.Controls.Add(this.dtpExhibition);
            this.Controls.Add(this.txtExhibitionName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewExhibition";
            this.Text = "Новая выставка ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExhibitionName;
        private System.Windows.Forms.DateTimePicker dtpExhibition;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Button btnSaveNew;
        private System.Windows.Forms.Button btnCancelNew;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}