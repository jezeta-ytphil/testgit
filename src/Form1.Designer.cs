namespace AddProjV2
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.tb = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCompress = new System.Windows.Forms.Button();
            this.btnDecompress = new System.Windows.Forms.Button();
            this.btnZip = new System.Windows.Forms.Button();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnIP = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(79, 21);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb
            // 
            this.tb.AllowDrop = true;
            this.tb.Location = new System.Drawing.Point(53, 12);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(100, 19);
            this.tb.TabIndex = 1;
            this.tb.DragDrop += new System.Windows.Forms.DragEventHandler(this.tb_DragDrop);
            this.tb.DragEnter += new System.Windows.Forms.DragEventHandler(this.tb_DragEnter);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(106, 37);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 21);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(12, 64);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(79, 21);
            this.btnCompress.TabIndex = 3;
            this.btnCompress.Text = "Compress";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // btnDecompress
            // 
            this.btnDecompress.Location = new System.Drawing.Point(106, 64);
            this.btnDecompress.Name = "btnDecompress";
            this.btnDecompress.Size = new System.Drawing.Size(79, 21);
            this.btnDecompress.TabIndex = 4;
            this.btnDecompress.Text = "Decompress";
            this.btnDecompress.UseVisualStyleBackColor = true;
            this.btnDecompress.Click += new System.EventHandler(this.btnDecompress_Click);
            // 
            // btnZip
            // 
            this.btnZip.Location = new System.Drawing.Point(12, 91);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(79, 21);
            this.btnZip.TabIndex = 5;
            this.btnZip.Text = "Zip";
            this.btnZip.UseVisualStyleBackColor = true;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(106, 91);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(79, 21);
            this.btnExtract.TabIndex = 6;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            // 
            // btnIP
            // 
            this.btnIP.Location = new System.Drawing.Point(12, 123);
            this.btnIP.Name = "btnIP";
            this.btnIP.Size = new System.Drawing.Size(79, 21);
            this.btnIP.TabIndex = 7;
            this.btnIP.Text = "Show IP";
            this.btnIP.UseVisualStyleBackColor = true;
            this.btnIP.Click += new System.EventHandler(this.btnIP_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(106, 123);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(79, 21);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 156);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnIP);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.btnZip);
            this.Controls.Add(this.btnDecompress);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.btnAdd);
            this.MaximumSize = new System.Drawing.Size(215, 195);
            this.MinimumSize = new System.Drawing.Size(215, 195);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Button btnDecompress;
        private System.Windows.Forms.Button btnZip;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnIP;
        private System.Windows.Forms.Button btnTest;
    }
}

