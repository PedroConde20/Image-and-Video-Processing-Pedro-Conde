namespace ProyectoFinalPDI
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
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.txtGo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonRecStart = new System.Windows.Forms.Button();
            this.buttonRecStop = new System.Windows.Forms.Button();
            this.buttonRecSave = new System.Windows.Forms.Button();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.videoSourcePlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.videoSourcePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoSourcePlayer.ForeColor = System.Drawing.Color.White;
            this.videoSourcePlayer.Location = new System.Drawing.Point(0, 0);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(489, 361);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.VideoSource = null;
            // 
            // txtGo
            // 
            this.txtGo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtGo.Location = new System.Drawing.Point(893, 441);
            this.txtGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGo.Name = "txtGo";
            this.txtGo.Size = new System.Drawing.Size(151, 54);
            this.txtGo.TabIndex = 0;
            this.txtGo.Text = "Go To WPF";
            this.txtGo.UseVisualStyleBackColor = true;
            this.txtGo.Click += new System.EventHandler(this.txtGo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(175, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(692, 388);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buttonRecStart
            // 
            this.buttonRecStart.Location = new System.Drawing.Point(16, 454);
            this.buttonRecStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRecStart.Name = "buttonRecStart";
            this.buttonRecStart.Size = new System.Drawing.Size(121, 28);
            this.buttonRecStart.TabIndex = 3;
            this.buttonRecStart.Text = "Start Camera";
            this.buttonRecStart.UseVisualStyleBackColor = true;
            this.buttonRecStart.Click += new System.EventHandler(this.buttonRecStart_Click);
            // 
            // buttonRecStop
            // 
            this.buttonRecStop.Location = new System.Drawing.Point(335, 454);
            this.buttonRecStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRecStop.Name = "buttonRecStop";
            this.buttonRecStop.Size = new System.Drawing.Size(100, 28);
            this.buttonRecStop.TabIndex = 4;
            this.buttonRecStop.Text = "Stop Camera";
            this.buttonRecStop.UseVisualStyleBackColor = true;
            this.buttonRecStop.Click += new System.EventHandler(this.buttonRecStop_Click);
            // 
            // buttonRecSave
            // 
            this.buttonRecSave.Location = new System.Drawing.Point(635, 454);
            this.buttonRecSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRecSave.Name = "buttonRecSave";
            this.buttonRecSave.Size = new System.Drawing.Size(100, 28);
            this.buttonRecSave.TabIndex = 5;
            this.buttonRecSave.Text = "Record";
            this.buttonRecSave.UseVisualStyleBackColor = true;
            this.buttonRecSave.Click += new System.EventHandler(this.buttonRecSave_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1067, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "AVI files (*.avi)|*.avi|All files (*.*)|*.*";
            this.openFileDialog.Title = "Opem movie";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.buttonRecSave);
            this.Controls.Add(this.buttonRecStop);
            this.Controls.Add(this.buttonRecStart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtGo);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.Button txtGo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonRecStart;
        private System.Windows.Forms.Button buttonRecStop;
        private System.Windows.Forms.Button buttonRecSave;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}