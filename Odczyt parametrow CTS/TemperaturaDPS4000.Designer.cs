namespace Odczyt_parametrow_CTS
{
    partial class TemperaturaDPS4000
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
            this.zedGraphTemperatura = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Temperatura";
            // 
            // zedGraphTemperatura
            // 
            this.zedGraphTemperatura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphTemperatura.Location = new System.Drawing.Point(12, 24);
            this.zedGraphTemperatura.Name = "zedGraphTemperatura";
            this.zedGraphTemperatura.ScrollGrace = 0;
            this.zedGraphTemperatura.ScrollMaxX = 0;
            this.zedGraphTemperatura.ScrollMaxY = 0;
            this.zedGraphTemperatura.ScrollMaxY2 = 0;
            this.zedGraphTemperatura.ScrollMinX = 0;
            this.zedGraphTemperatura.ScrollMinY = 0;
            this.zedGraphTemperatura.ScrollMinY2 = 0;
            this.zedGraphTemperatura.Size = new System.Drawing.Size(610, 191);
            this.zedGraphTemperatura.TabIndex = 3;
            // 
            // TemperaturaDPS4000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 225);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraphTemperatura);
            this.Name = "TemperaturaDPS4000";
            this.Text = "Temperatura punktu rosy S4000";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl zedGraphTemperatura;
    }
}