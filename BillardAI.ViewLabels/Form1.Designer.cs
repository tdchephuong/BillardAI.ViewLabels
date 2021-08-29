
namespace BillardAI.ViewLabels
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
            this.components = new System.ComponentModel.Container();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.imgs = new System.Windows.Forms.ImageList(this.components);
            this.pnPickture = new System.Windows.Forms.Panel();
            this.picViewer = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ckShowLine = new System.Windows.Forms.CheckBox();
            this.lblLabelName = new System.Windows.Forms.Label();
            this.lblImageName = new System.Windows.Forms.Label();
            this.txtHidden = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.datagrd = new System.Windows.Forms.DataGridView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.pnPickture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picViewer)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrd)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(10, 25);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(616, 27);
            this.txtPath.TabIndex = 0;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(632, 24);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(57, 29);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "...";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // imgs
            // 
            this.imgs.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgs.ImageSize = new System.Drawing.Size(16, 16);
            this.imgs.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnPickture
            // 
            this.pnPickture.Controls.Add(this.picViewer);
            this.pnPickture.Controls.Add(this.panel3);
            this.pnPickture.Controls.Add(this.txtHidden);
            this.pnPickture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPickture.Location = new System.Drawing.Point(4, 0);
            this.pnPickture.Name = "pnPickture";
            this.pnPickture.Size = new System.Drawing.Size(872, 723);
            this.pnPickture.TabIndex = 3;
            // 
            // picViewer
            // 
            this.picViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picViewer.Location = new System.Drawing.Point(0, 116);
            this.picViewer.Name = "picViewer";
            this.picViewer.Size = new System.Drawing.Size(872, 607);
            this.picViewer.TabIndex = 4;
            this.picViewer.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.ckShowLine);
            this.panel3.Controls.Add(this.lblLabelName);
            this.panel3.Controls.Add(this.lblImageName);
            this.panel3.Controls.Add(this.txtPath);
            this.panel3.Controls.Add(this.btnFind);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(872, 116);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Show Line : ";
            // 
            // ckShowLine
            // 
            this.ckShowLine.AutoSize = true;
            this.ckShowLine.Checked = true;
            this.ckShowLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckShowLine.Location = new System.Drawing.Point(613, 63);
            this.ckShowLine.Name = "ckShowLine";
            this.ckShowLine.Size = new System.Drawing.Size(18, 17);
            this.ckShowLine.TabIndex = 4;
            this.ckShowLine.UseVisualStyleBackColor = true;
            this.ckShowLine.CheckedChanged += new System.EventHandler(this.ckShowLine_CheckedChanged);
            // 
            // lblLabelName
            // 
            this.lblLabelName.AutoSize = true;
            this.lblLabelName.Location = new System.Drawing.Point(10, 89);
            this.lblLabelName.Name = "lblLabelName";
            this.lblLabelName.Size = new System.Drawing.Size(50, 20);
            this.lblLabelName.TabIndex = 3;
            this.lblLabelName.Text = "label1";
            // 
            // lblImageName
            // 
            this.lblImageName.AutoSize = true;
            this.lblImageName.Location = new System.Drawing.Point(10, 59);
            this.lblImageName.Name = "lblImageName";
            this.lblImageName.Size = new System.Drawing.Size(62, 20);
            this.lblImageName.TabIndex = 2;
            this.lblImageName.Text = "image : ";
            // 
            // txtHidden
            // 
            this.txtHidden.Location = new System.Drawing.Point(954, 25);
            this.txtHidden.Name = "txtHidden";
            this.txtHidden.Size = new System.Drawing.Size(34, 27);
            this.txtHidden.TabIndex = 2;
            this.txtHidden.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 723);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.datagrd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(886, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 723);
            this.panel2.TabIndex = 7;
            // 
            // datagrd
            // 
            this.datagrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrd.Location = new System.Drawing.Point(126, 250);
            this.datagrd.Name = "datagrd";
            this.datagrd.RowHeadersWidth = 51;
            this.datagrd.RowTemplate.Height = 29;
            this.datagrd.Size = new System.Drawing.Size(220, 473);
            this.datagrd.TabIndex = 0;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.Desktop;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(876, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(10, 723);
            this.splitter2.TabIndex = 8;
            this.splitter2.TabStop = false;
            this.splitter2.ClientSizeChanged += new System.EventHandler(this.splitter2_ClientSizeChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1545, 723);
            this.Controls.Add(this.pnPickture);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.pnPickture.ResumeLayout(false);
            this.pnPickture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picViewer)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagrd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ImageList imgs;
        private System.Windows.Forms.Panel pnPickture;
        
        private System.Windows.Forms.TextBox txtHidden;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.DataGridView datagrd;
        private System.Windows.Forms.PictureBox picViewer;
        private System.Windows.Forms.Label lblImageName;
        private System.Windows.Forms.Label lblLabelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckShowLine;
    }
}

