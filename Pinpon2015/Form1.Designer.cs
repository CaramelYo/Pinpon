namespace Pingpon20215
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.board = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.PictureBox();
            this.NPC = new System.Windows.Forms.Label();
            this.lblNotification = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.Black;
            this.board.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.board.Location = new System.Drawing.Point(125, 257);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(109, 23);
            this.board.TabIndex = 4;
            this.board.Text = "YOU";
            this.board.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.board.MouseDown += new System.Windows.Forms.MouseEventHandler(this.P_MouseDown);
            this.board.MouseMove += new System.Windows.Forms.MouseEventHandler(this.P_MouseMove);
            // 
            // ball
            // 
            this.ball.Image = global::Pinpon2015.Properties.Resources.ball;
            this.ball.Location = new System.Drawing.Point(162, 87);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(32, 32);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ball.TabIndex = 3;
            this.ball.TabStop = false;
            // 
            // NPC
            // 
            this.NPC.BackColor = System.Drawing.Color.Black;
            this.NPC.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NPC.Location = new System.Drawing.Point(103, 7);
            this.NPC.Name = "NPC";
            this.NPC.Size = new System.Drawing.Size(109, 23);
            this.NPC.TabIndex = 5;
            this.NPC.Text = "NPC";
            this.NPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.Location = new System.Drawing.Point(125, 172);
            this.lblNotification.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(101, 12);
            this.lblNotification.TabIndex = 6;
            this.lblNotification.Text = "按住滑板開始遊戲";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(343, 313);
            this.Controls.Add(this.lblNotification);
            this.Controls.Add(this.NPC);
            this.Controls.Add(this.board);
            this.Controls.Add(this.ball);
            this.Name = "Form1";
            this.Text = "乒乓球";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label board;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Label NPC;
        private System.Windows.Forms.Label lblNotification;
    }
}

