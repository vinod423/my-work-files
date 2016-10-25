namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gpio = new System.Windows.Forms.TabPage();
            this.gpio_pins_selc = new System.Windows.Forms.CheckedListBox();
            this.analog = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.vref = new System.Windows.Forms.ComboBox();
            this.analog_volt_ref = new System.Windows.Forms.ListBox();
            this.analog_pins_selc = new System.Windows.Forms.CheckedListBox();
            this.uart = new System.Windows.Forms.TabPage();
            this.uart_ext_clck = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.int_clck = new System.Windows.Forms.CheckBox();
            this.ext_clck = new System.Windows.Forms.CheckBox();
            this.uart_pins_selc = new System.Windows.Forms.CheckedListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.generate = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.gpio.SuspendLayout();
            this.analog.SuspendLayout();
            this.uart.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.gpio);
            this.tabControl1.Controls.Add(this.analog);
            this.tabControl1.Controls.Add(this.uart);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(576, 526);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(568, 500);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gpio
            // 
            this.gpio.Controls.Add(this.gpio_pins_selc);
            this.gpio.Location = new System.Drawing.Point(4, 22);
            this.gpio.Name = "gpio";
            this.gpio.Padding = new System.Windows.Forms.Padding(3);
            this.gpio.Size = new System.Drawing.Size(568, 500);
            this.gpio.TabIndex = 1;
            this.gpio.Text = "GPIO";
            this.gpio.UseVisualStyleBackColor = true;
            // 
            // gpio_pins_selc
            // 
            this.gpio_pins_selc.FormattingEnabled = true;
            this.gpio_pins_selc.Location = new System.Drawing.Point(47, 129);
            this.gpio_pins_selc.Name = "gpio_pins_selc";
            this.gpio_pins_selc.Size = new System.Drawing.Size(247, 49);
            this.gpio_pins_selc.TabIndex = 3;
            this.gpio_pins_selc.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.gpio_pins_selc_ItemCheck);
            // 
            // analog
            // 
            this.analog.Controls.Add(this.linkLabel1);
            this.analog.Controls.Add(this.vref);
            this.analog.Controls.Add(this.analog_volt_ref);
            this.analog.Controls.Add(this.analog_pins_selc);
            this.analog.Location = new System.Drawing.Point(4, 22);
            this.analog.Name = "analog";
            this.analog.Padding = new System.Windows.Forms.Padding(3);
            this.analog.Size = new System.Drawing.Size(568, 500);
            this.analog.TabIndex = 2;
            this.analog.Text = "analog";
            this.analog.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(51, 233);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(150, 29);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Expert Mode";
            // 
            // vref
            // 
            this.vref.FormattingEnabled = true;
            this.vref.Items.AddRange(new object[] {
            "1.5",
            "2.0",
            "2.5"});
            this.vref.Location = new System.Drawing.Point(42, 93);
            this.vref.Name = "vref";
            this.vref.Size = new System.Drawing.Size(247, 21);
            this.vref.TabIndex = 3;
            this.vref.Text = "internal ref voltage";
            this.vref.Visible = false;
            this.vref.SelectedIndexChanged += new System.EventHandler(this.vref_SelectedIndexChanged);
            // 
            // analog_volt_ref
            // 
            this.analog_volt_ref.FormattingEnabled = true;
            this.analog_volt_ref.Items.AddRange(new object[] {
            "AVCC and AVSS",
            "VREF and AVSS",
            "VEREF+  buffered and AVSS",
            "VEREF+ and AVSS",
            "AVCC and VEREF-",
            "VREF and VEREF-",
            "VEREF+ Buffered  and VEREF-",
            "VEREF+ and VEREF-"});
            this.analog_volt_ref.Location = new System.Drawing.Point(42, 44);
            this.analog_volt_ref.Name = "analog_volt_ref";
            this.analog_volt_ref.Size = new System.Drawing.Size(247, 43);
            this.analog_volt_ref.TabIndex = 2;
            this.analog_volt_ref.SelectedIndexChanged += new System.EventHandler(this.analog_volt_ref_SelectedIndexChanged);
            // 
            // analog_pins_selc
            // 
            this.analog_pins_selc.FormattingEnabled = true;
            this.analog_pins_selc.Location = new System.Drawing.Point(42, 129);
            this.analog_pins_selc.Name = "analog_pins_selc";
            this.analog_pins_selc.Size = new System.Drawing.Size(247, 49);
            this.analog_pins_selc.TabIndex = 1;
            this.analog_pins_selc.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.analog_pins_selc_ItemCheck);
            // 
            // uart
            // 
            this.uart.Controls.Add(this.label3);
            this.uart.Controls.Add(this.comboBox1);
            this.uart.Controls.Add(this.uart_ext_clck);
            this.uart.Controls.Add(this.label2);
            this.uart.Controls.Add(this.int_clck);
            this.uart.Controls.Add(this.ext_clck);
            this.uart.Controls.Add(this.uart_pins_selc);
            this.uart.Location = new System.Drawing.Point(4, 22);
            this.uart.Name = "uart";
            this.uart.Padding = new System.Windows.Forms.Padding(3);
            this.uart.Size = new System.Drawing.Size(568, 500);
            this.uart.TabIndex = 3;
            this.uart.Text = "UART";
            this.uart.UseVisualStyleBackColor = true;
            // 
            // uart_ext_clck
            // 
            this.uart_ext_clck.FormattingEnabled = true;
            this.uart_ext_clck.Location = new System.Drawing.Point(45, 102);
            this.uart_ext_clck.Name = "uart_ext_clck";
            this.uart_ext_clck.Size = new System.Drawing.Size(233, 49);
            this.uart_ext_clck.TabIndex = 7;
            this.uart_ext_clck.Visible = false;
            this.uart_ext_clck.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.uart_ext_clck_ItemCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Clock selection";
            // 
            // int_clck
            // 
            this.int_clck.AutoSize = true;
            this.int_clck.Location = new System.Drawing.Point(145, 78);
            this.int_clck.Name = "int_clck";
            this.int_clck.Size = new System.Drawing.Size(61, 17);
            this.int_clck.TabIndex = 5;
            this.int_clck.Text = "Internal";
            this.int_clck.UseVisualStyleBackColor = true;
            // 
            // ext_clck
            // 
            this.ext_clck.AutoSize = true;
            this.ext_clck.Location = new System.Drawing.Point(45, 78);
            this.ext_clck.Name = "ext_clck";
            this.ext_clck.Size = new System.Drawing.Size(64, 17);
            this.ext_clck.TabIndex = 4;
            this.ext_clck.Text = "External";
            this.ext_clck.UseVisualStyleBackColor = true;
            this.ext_clck.CheckedChanged += new System.EventHandler(this.ext_clck_CheckedChanged);
            // 
            // uart_pins_selc
            // 
            this.uart_pins_selc.FormattingEnabled = true;
            this.uart_pins_selc.Location = new System.Drawing.Point(45, 197);
            this.uart_pins_selc.Name = "uart_pins_selc";
            this.uart_pins_selc.Size = new System.Drawing.Size(247, 49);
            this.uart_pins_selc.TabIndex = 3;
            this.uart_pins_selc.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.uart_pins_selc_ItemCheck);
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(568, 500);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(568, 500);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(568, 500);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(721, 42);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(332, 379);
            this.textBox1.TabIndex = 1;
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(883, 462);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(75, 23);
            this.generate.TabIndex = 2;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800"});
            this.comboBox1.Location = new System.Drawing.Point(45, 280);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "baud rate";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 551);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.gpio.ResumeLayout(false);
            this.analog.ResumeLayout(false);
            this.analog.PerformLayout();
            this.uart.ResumeLayout(false);
            this.uart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage gpio;
        private System.Windows.Forms.TabPage analog;
        private System.Windows.Forms.TabPage uart;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.CheckedListBox gpio_pins_selc;
        private System.Windows.Forms.CheckedListBox analog_pins_selc;
        private System.Windows.Forms.CheckedListBox uart_pins_selc;
        private System.Windows.Forms.ListBox analog_volt_ref;
        private System.Windows.Forms.ComboBox vref;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckedListBox uart_ext_clck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox int_clck;
        private System.Windows.Forms.CheckBox ext_clck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

