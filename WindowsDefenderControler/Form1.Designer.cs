﻿namespace WindowsDefenderControler
{
    partial class Main
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
            this.Start = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.Button();
            this.Srvce = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(145, 30);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(300, 75);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start / Stop";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Help
            // 
            this.Help.Location = new System.Drawing.Point(250, 212);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(90, 30);
            this.Help.TabIndex = 1;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // Srvce
            // 
            this.Srvce.AutoSize = true;
            this.Srvce.Font = new System.Drawing.Font("Nexa Rust Sans Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Srvce.ForeColor = System.Drawing.Color.Firebrick;
            this.Srvce.Location = new System.Drawing.Point(134, 129);
            this.Srvce.Name = "Srvce";
            this.Srvce.Size = new System.Drawing.Size(328, 32);
            this.Srvce.TabIndex = 2;
            this.Srvce.Text = "Service is running";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(582, 253);
            this.Controls.Add(this.Srvce);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "Windows Defender Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Label Srvce;
    }
}

