namespace Lab_11
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.formBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ContextMenuStrip = this.contextMenuStrip1;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Інформація: це Форма А, з неї можна потрапити на форми B, C та D";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formBToolStripMenuItem,
            this.formCToolStripMenuItem,
            this.formDToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 70);
            // 
            // formBToolStripMenuItem
            // 
            this.formBToolStripMenuItem.Name = "formBToolStripMenuItem";
            this.formBToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.formBToolStripMenuItem.Text = "FormB";
            this.formBToolStripMenuItem.Click += new System.EventHandler(this.formBToolStripMenuItem_Click);
            // 
            // formCToolStripMenuItem
            // 
            this.formCToolStripMenuItem.Name = "formCToolStripMenuItem";
            this.formCToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.formCToolStripMenuItem.Text = "FormC";
            this.formCToolStripMenuItem.Click += new System.EventHandler(this.formCToolStripMenuItem_Click);
            // 
            // formDToolStripMenuItem
            // 
            this.formDToolStripMenuItem.Name = "formDToolStripMenuItem";
            this.formDToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.formDToolStripMenuItem.Text = "FormD";
            this.formDToolStripMenuItem.Click += new System.EventHandler(this.formDToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "FormА";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formDToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label1;
    }
}

