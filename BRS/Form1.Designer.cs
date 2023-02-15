namespace BRS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttoncheck = new System.Windows.Forms.Button();
            this.buttonprint = new System.Windows.Forms.Button();
            this.autodruck = new System.Windows.Forms.CheckBox();
            this.button_einstellung = new System.Windows.Forms.Button();
            this.richTextBox_BuchName = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "BARCODE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(73, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Barcode Eingeben";
            this.textBox1.Size = new System.Drawing.Size(145, 29);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.Location = new System.Drawing.Point(9, 210);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(249, 176);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // buttoncheck
            // 
            this.buttoncheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttoncheck.Image = ((System.Drawing.Image)(resources.GetObject("buttoncheck.Image")));
            this.buttoncheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttoncheck.Location = new System.Drawing.Point(73, 72);
            this.buttoncheck.Name = "buttoncheck";
            this.buttoncheck.Size = new System.Drawing.Size(145, 38);
            this.buttoncheck.TabIndex = 3;
            this.buttoncheck.Text = "Check";
            this.buttoncheck.UseVisualStyleBackColor = true;
            this.buttoncheck.Click += new System.EventHandler(this.buttoncheck_Click);
            // 
            // buttonprint
            // 
            this.buttonprint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonprint.Image = ((System.Drawing.Image)(resources.GetObject("buttonprint.Image")));
            this.buttonprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonprint.Location = new System.Drawing.Point(9, 411);
            this.buttonprint.Name = "buttonprint";
            this.buttonprint.Size = new System.Drawing.Size(117, 39);
            this.buttonprint.TabIndex = 4;
            this.buttonprint.Text = "Print";
            this.buttonprint.UseVisualStyleBackColor = true;
            this.buttonprint.Click += new System.EventHandler(this.buttonprint_Click);
            // 
            // autodruck
            // 
            this.autodruck.AutoSize = true;
            this.autodruck.Location = new System.Drawing.Point(73, 130);
            this.autodruck.Name = "autodruck";
            this.autodruck.Size = new System.Drawing.Size(141, 19);
            this.autodruck.TabIndex = 5;
            this.autodruck.Text = "Automatisch Drucken";
            this.autodruck.UseVisualStyleBackColor = true;
            this.autodruck.CheckedChanged += new System.EventHandler(this.autodruck_CheckedChanged);
            // 
            // button_einstellung
            // 
            this.button_einstellung.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_einstellung.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_einstellung.Location = new System.Drawing.Point(141, 411);
            this.button_einstellung.Name = "button_einstellung";
            this.button_einstellung.Size = new System.Drawing.Size(117, 39);
            this.button_einstellung.TabIndex = 6;
            this.button_einstellung.Text = "Druckeinstellungen";
            this.button_einstellung.UseVisualStyleBackColor = true;
            this.button_einstellung.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox_BuchName
            // 
            this.richTextBox_BuchName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox_BuchName.Location = new System.Drawing.Point(9, 155);
            this.richTextBox_BuchName.Name = "richTextBox_BuchName";
            this.richTextBox_BuchName.ReadOnly = true;
            this.richTextBox_BuchName.Size = new System.Drawing.Size(249, 53);
            this.richTextBox_BuchName.TabIndex = 7;
            this.richTextBox_BuchName.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 471);
            this.Controls.Add(this.richTextBox_BuchName);
            this.Controls.Add(this.button_einstellung);
            this.Controls.Add(this.autodruck);
            this.Controls.Add(this.buttonprint);
            this.Controls.Add(this.buttoncheck);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Signature Print";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
        private Button buttoncheck;
        private Button buttonprint;
        private CheckBox autodruck;
        private Button button_einstellung;
        private RichTextBox richTextBox_BuchName;
    }
}