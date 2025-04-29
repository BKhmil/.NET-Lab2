namespace Lab2
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
            button_start = new Button();
            numericUpDown_counter = new NumericUpDown();
            textBox_notify = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_counter).BeginInit();
            SuspendLayout();
            // 
            // button_start
            // 
            button_start.Location = new Point(286, 495);
            button_start.Name = "button_start";
            button_start.Size = new Size(110, 41);
            button_start.TabIndex = 0;
            button_start.Text = "Start processes";
            button_start.UseVisualStyleBackColor = true;
            button_start.Click += startProcesses_Click;
            // 
            // numericUpDown_counter
            // 
            numericUpDown_counter.Location = new Point(286, 431);
            numericUpDown_counter.Name = "numericUpDown_counter";
            numericUpDown_counter.Size = new Size(120, 23);
            numericUpDown_counter.TabIndex = 1;
            numericUpDown_counter.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // textBox_notify
            // 
            textBox_notify.Font = new Font("Segoe UI", 14F);
            textBox_notify.Location = new Point(147, 226);
            textBox_notify.Name = "textBox_notify";
            textBox_notify.Size = new Size(490, 32);
            textBox_notify.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 567);
            Controls.Add(textBox_notify);
            Controls.Add(numericUpDown_counter);
            Controls.Add(button_start);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown_counter).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_start;
        private NumericUpDown numericUpDown_counter;
        private TextBox textBox_notify;
    }
}
