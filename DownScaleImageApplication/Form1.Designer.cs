namespace DownScaleImageApplication
{
    partial class Form1
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
            panel1 = new Panel();
            SelectImg = new Button();
            DownSizeBtn = new Button();
            ScalingInput = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            timeNoParallel = new Label();
            label2 = new Label();
            TimeParallel = new Label();
            panel3 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(SelectImg);
            panel1.Controls.Add(DownSizeBtn);
            panel1.Controls.Add(ScalingInput);
            panel1.Location = new Point(11, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(342, 95);
            panel1.TabIndex = 0;
            // 
            // SelectImg
            // 
            SelectImg.Location = new Point(3, 49);
            SelectImg.Name = "SelectImg";
            SelectImg.Size = new Size(331, 37);
            SelectImg.TabIndex = 0;
            SelectImg.Text = "Select img";
            SelectImg.UseVisualStyleBackColor = true;
            SelectImg.Click += SelectImg_Click;
            // 
            // DownSizeBtn
            // 
            DownSizeBtn.Location = new Point(216, 9);
            DownSizeBtn.Name = "DownSizeBtn";
            DownSizeBtn.Size = new Size(117, 34);
            DownSizeBtn.TabIndex = 1;
            DownSizeBtn.Text = "Scale";
            DownSizeBtn.UseVisualStyleBackColor = true;
            DownSizeBtn.Click += DownSizeBtn_Click;
            // 
            // ScalingInput
            // 
            ScalingInput.Location = new Point(6, 11);
            ScalingInput.Name = "ScalingInput";
            ScalingInput.Size = new Size(194, 27);
            ScalingInput.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(8, 106);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(460, 390);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(477, 106);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(460, 390);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 14);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 4;
            label1.Text = "Time standart scale:";
            // 
            // timeNoParallel
            // 
            timeNoParallel.AutoSize = true;
            timeNoParallel.Location = new Point(163, 18);
            timeNoParallel.Name = "timeNoParallel";
            timeNoParallel.Size = new Size(17, 20);
            timeNoParallel.TabIndex = 5;
            timeNoParallel.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 53);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 6;
            label2.Text = "Time Parallel:";
            // 
            // TimeParallel
            // 
            TimeParallel.AutoSize = true;
            TimeParallel.Location = new Point(163, 56);
            TimeParallel.Name = "TimeParallel";
            TimeParallel.Size = new Size(17, 20);
            TimeParallel.TabIndex = 7;
            TimeParallel.Text = "0";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(TimeParallel);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(timeNoParallel);
            panel3.Location = new Point(359, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(265, 95);
            panel3.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 505);
            Controls.Add(panel3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Down sizing app";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button DownSizeBtn;
        private TextBox ScalingInput;
        private PictureBox pictureBox1;
        private Button SelectImg;
        private PictureBox pictureBox2;
        private Label label1;
        private Label timeNoParallel;
        private Label label2;
        private Label TimeParallel;
        private Panel panel3;
    }
}
