﻿namespace ClickCounter
{
    partial class ClickCounterView
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClickCounterView));
            this.btnStopLogger = new System.Windows.Forms.Button();
            this.btnStartLogger = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRight = new System.Windows.Forms.TextBox();
            this.tbLeft = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbAutostart = new System.Windows.Forms.CheckBox();
            this.btnResetClicks = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMinimize = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStopLogger
            // 
            this.btnStopLogger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopLogger.Location = new System.Drawing.Point(19, 47);
            this.btnStopLogger.Name = "btnStopLogger";
            this.btnStopLogger.Size = new System.Drawing.Size(113, 42);
            this.btnStopLogger.TabIndex = 0;
            this.btnStopLogger.Text = "Stop Logger";
            this.btnStopLogger.UseVisualStyleBackColor = false;
            this.btnStopLogger.Click += new System.EventHandler(this.btnStopLogger_Click);
            // 
            // btnStartLogger
            // 
            this.btnStartLogger.BackColor = System.Drawing.SystemColors.Control;
            this.btnStartLogger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartLogger.Location = new System.Drawing.Point(19, 111);
            this.btnStartLogger.Name = "btnStartLogger";
            this.btnStartLogger.Size = new System.Drawing.Size(113, 42);
            this.btnStartLogger.TabIndex = 1;
            this.btnStartLogger.Text = "Start Logger";
            this.btnStartLogger.UseVisualStyleBackColor = false;
            this.btnStartLogger.Click += new System.EventHandler(this.btnStartLogger_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Starts the logger, to count clicks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stops the logger";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Current clicks:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Right:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Left:";
            // 
            // tbRight
            // 
            this.tbRight.Location = new System.Drawing.Point(79, 220);
            this.tbRight.Name = "tbRight";
            this.tbRight.ReadOnly = true;
            this.tbRight.Size = new System.Drawing.Size(130, 20);
            this.tbRight.TabIndex = 7;
            this.tbRight.Text = "0";
            // 
            // tbLeft
            // 
            this.tbLeft.Location = new System.Drawing.Point(79, 255);
            this.tbLeft.Name = "tbLeft";
            this.tbLeft.ReadOnly = true;
            this.tbLeft.Size = new System.Drawing.Size(130, 20);
            this.tbLeft.TabIndex = 8;
            this.tbLeft.Text = "0";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(138, 160);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(242, 20);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Current status: Not running...";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(304, 208);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(69, 42);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbAutostart
            // 
            this.cbAutostart.AutoSize = true;
            this.cbAutostart.Location = new System.Drawing.Point(304, 60);
            this.cbAutostart.Name = "cbAutostart";
            this.cbAutostart.Size = new System.Drawing.Size(134, 17);
            this.cbAutostart.TabIndex = 11;
            this.cbAutostart.Text = "Autostart with windows";
            this.cbAutostart.UseVisualStyleBackColor = true;
            this.cbAutostart.CheckedChanged += new System.EventHandler(this.cbAutostart_CheckedChanged);
            // 
            // btnResetClicks
            // 
            this.btnResetClicks.BackColor = System.Drawing.SystemColors.Control;
            this.btnResetClicks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetClicks.Location = new System.Drawing.Point(304, 256);
            this.btnResetClicks.Name = "btnResetClicks";
            this.btnResetClicks.Size = new System.Drawing.Size(69, 31);
            this.btnResetClicks.TabIndex = 12;
            this.btnResetClicks.Text = "Reset";
            this.btnResetClicks.UseVisualStyleBackColor = false;
            this.btnResetClicks.Click += new System.EventHandler(this.btnResetClicks_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.lblMinimize);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblClose);
            this.panel1.Location = new System.Drawing.Point(0, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 38);
            this.panel1.TabIndex = 13;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClose.ForeColor = System.Drawing.Color.Maroon;
            this.lblClose.Location = new System.Drawing.Point(416, 9);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(22, 22);
            this.lblClose.TabIndex = 0;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.DragOver += new System.Windows.Forms.DragEventHandler(this.lblClose_DragOver);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "ClickCounter - View";
            // 
            // lblMinimize
            // 
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimize.ForeColor = System.Drawing.Color.Maroon;
            this.lblMinimize.Location = new System.Drawing.Point(381, -7);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(38, 42);
            this.lblMinimize.TabIndex = 2;
            this.lblMinimize.Text = "--";
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
            this.lblMinimize.MouseEnter += new System.EventHandler(this.lblMinimize_MouseEnter);
            this.lblMinimize.MouseLeave += new System.EventHandler(this.lblMinimize_MouseLeave);
            // 
            // ClickCounterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(456, 313);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnResetClicks);
            this.Controls.Add(this.cbAutostart);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tbLeft);
            this.Controls.Add(this.tbRight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartLogger);
            this.Controls.Add(this.btnStopLogger);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(456, 313);
            this.MinimumSize = new System.Drawing.Size(456, 313);
            this.Name = "ClickCounterView";
            this.Text = "Clickcounter View";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ClickCounterView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStopLogger;
        private System.Windows.Forms.Button btnStartLogger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRight;
        private System.Windows.Forms.TextBox tbLeft;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox cbAutostart;
        private System.Windows.Forms.Button btnResetClicks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMinimize;
    }
}

