namespace PC_State_Display_Control_Panel
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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            comboBox1 = new ComboBox();
            checkBox1 = new CheckBox();
            comboBox2 = new ComboBox();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            button3 = new Button();
            update = new Button();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            checkBox2 = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(275, 225);
            button1.Name = "button1";
            button1.Size = new Size(92, 29);
            button1.TabIndex = 0;
            button1.Text = "Apply";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(162, 29);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(161, 27);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = SystemColors.Control;
            checkBox1.Location = new Point(40, 126);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(203, 23);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Run when windows start";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(162, 73);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(161, 27);
            comboBox2.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(177, 225);
            button2.Name = "button2";
            button2.Size = new Size(92, 29);
            button2.TabIndex = 4;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(40, 29);
            label1.Name = "label1";
            label1.Size = new Size(61, 25);
            label1.TabIndex = 5;
            label1.Text = "Port :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(40, 73);
            label2.Name = "label2";
            label2.Size = new Size(116, 25);
            label2.TabIndex = 6;
            label2.Text = "Baud rate : ";
            // 
            // button3
            // 
            button3.Location = new Point(373, 225);
            button3.Name = "button3";
            button3.Size = new Size(92, 29);
            button3.TabIndex = 8;
            button3.Text = "OK";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // update
            // 
            update.Location = new Point(356, 29);
            update.Name = "update";
            update.Size = new Size(94, 27);
            update.TabIndex = 9;
            update.Text = "Update";
            update.UseVisualStyleBackColor = true;
            update.Click += update_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.ForeColor = SystemColors.Control;
            checkBox2.Location = new Point(40, 155);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(198, 23);
            checkBox2.TabIndex = 10;
            checkBox2.Text = "Auto run in background";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AcceptButton = button3;
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            CancelButton = button2;
            ClientSize = new Size(502, 266);
            Controls.Add(checkBox2);
            Controls.Add(update);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(comboBox2);
            Controls.Add(checkBox1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            MaximumSize = new Size(520, 313);
            MinimumSize = new Size(520, 313);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            SizeChanged += Form1_SizeChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox comboBox1;
        private CheckBox checkBox1;
        private ComboBox comboBox2;
        private Button button2;
        private Label label1;
        private Label label2;
        private Button button3;
        private Button update;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private CheckBox checkBox2;
    }
}