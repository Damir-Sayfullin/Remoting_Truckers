
namespace Truckers
{
    partial class FormLogist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogist));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_ID = new System.Windows.Forms.Label();
            this.comboBox_ID = new System.Windows.Forms.ComboBox();
            this.labelDriverID = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelCargo = new System.Windows.Forms.Label();
            this.labelWeight = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxDriverID = new System.Windows.Forms.TextBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxCargo = new System.Windows.Forms.TextBox();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.labelLine = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_ID.ForeColor = System.Drawing.Color.White;
            this.label_ID.Location = new System.Drawing.Point(65, 192);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(42, 33);
            this.label_ID.TabIndex = 4;
            this.label_ID.Text = "ID";
            // 
            // comboBox_ID
            // 
            this.comboBox_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ID.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_ID.FormattingEnabled = true;
            this.comboBox_ID.Location = new System.Drawing.Point(120, 190);
            this.comboBox_ID.Name = "comboBox_ID";
            this.comboBox_ID.Size = new System.Drawing.Size(200, 40);
            this.comboBox_ID.TabIndex = 5;
            // 
            // labelDriverID
            // 
            this.labelDriverID.AutoSize = true;
            this.labelDriverID.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDriverID.ForeColor = System.Drawing.Color.White;
            this.labelDriverID.Location = new System.Drawing.Point(40, 260);
            this.labelDriverID.Name = "labelDriverID";
            this.labelDriverID.Size = new System.Drawing.Size(166, 33);
            this.labelDriverID.TabIndex = 9;
            this.labelDriverID.Text = "ID водителя";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(40, 350);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(95, 33);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "Статус";
            // 
            // labelCargo
            // 
            this.labelCargo.AutoSize = true;
            this.labelCargo.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCargo.ForeColor = System.Drawing.Color.White;
            this.labelCargo.Location = new System.Drawing.Point(40, 440);
            this.labelCargo.Name = "labelCargo";
            this.labelCargo.Size = new System.Drawing.Size(281, 33);
            this.labelCargo.TabIndex = 11;
            this.labelCargo.Text = "Наименование груза";
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWeight.ForeColor = System.Drawing.Color.White;
            this.labelWeight.Location = new System.Drawing.Point(40, 530);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(278, 33);
            this.labelWeight.TabIndex = 12;
            this.labelWeight.Text = "Масса груза в тоннах";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFrom.ForeColor = System.Drawing.Color.White;
            this.labelFrom.Location = new System.Drawing.Point(40, 620);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(260, 33);
            this.labelFrom.TabIndex = 13;
            this.labelFrom.Text = "Пункт отправления";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTo.ForeColor = System.Drawing.Color.White;
            this.labelTo.Location = new System.Drawing.Point(40, 710);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(245, 33);
            this.labelTo.TabIndex = 14;
            this.labelTo.Text = "Пункт назначения";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 13.8F);
            this.button1.Location = new System.Drawing.Point(32, 807);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 50);
            this.button1.TabIndex = 15;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Century Gothic", 13.8F);
            this.button2.Location = new System.Drawing.Point(192, 807);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 50);
            this.button2.TabIndex = 16;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Century Gothic", 13.8F);
            this.button3.Location = new System.Drawing.Point(32, 863);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 50);
            this.button3.TabIndex = 17;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBoxDriverID
            // 
            this.textBoxDriverID.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDriverID.Location = new System.Drawing.Point(32, 300);
            this.textBoxDriverID.Name = "textBoxDriverID";
            this.textBoxDriverID.Size = new System.Drawing.Size(315, 36);
            this.textBoxDriverID.TabIndex = 18;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxStatus.Location = new System.Drawing.Point(32, 390);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(315, 36);
            this.textBoxStatus.TabIndex = 19;
            // 
            // textBoxCargo
            // 
            this.textBoxCargo.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCargo.Location = new System.Drawing.Point(32, 480);
            this.textBoxCargo.Name = "textBoxCargo";
            this.textBoxCargo.Size = new System.Drawing.Size(315, 36);
            this.textBoxCargo.TabIndex = 20;
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxWeight.Location = new System.Drawing.Point(32, 570);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(315, 36);
            this.textBoxWeight.TabIndex = 21;
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFrom.Location = new System.Drawing.Point(32, 660);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(315, 36);
            this.textBoxFrom.TabIndex = 22;
            // 
            // textBoxTo
            // 
            this.textBoxTo.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTo.Location = new System.Drawing.Point(32, 750);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(315, 36);
            this.textBoxTo.TabIndex = 23;
            // 
            // labelLine
            // 
            this.labelLine.AutoSize = true;
            this.labelLine.Font = new System.Drawing.Font("Montserrat", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLine.ForeColor = System.Drawing.Color.White;
            this.labelLine.Location = new System.Drawing.Point(-10, 120);
            this.labelLine.Name = "labelLine";
            this.labelLine.Size = new System.Drawing.Size(413, 46);
            this.labelLine.TabIndex = 24;
            this.labelLine.Text = "________Логист________";
            this.labelLine.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Century Gothic", 13.8F);
            this.button4.Location = new System.Drawing.Point(192, 863);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(155, 50);
            this.button4.TabIndex = 25;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // FormLogist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(45)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(382, 943);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.labelLine);
            this.Controls.Add(this.textBoxTo);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.textBoxCargo);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.textBoxDriverID);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.labelWeight);
            this.Controls.Add(this.labelCargo);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelDriverID);
            this.Controls.Add(this.comboBox_ID);
            this.Controls.Add(this.label_ID);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormLogist";
            this.Text = "Truckers: Логист";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.ComboBox comboBox_ID;
        private System.Windows.Forms.Label labelDriverID;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelCargo;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxDriverID;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxCargo;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.Label labelLine;
        private System.Windows.Forms.Button button4;
    }
}