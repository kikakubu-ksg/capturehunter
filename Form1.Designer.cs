namespace capturehunter
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_ref = new System.Windows.Forms.Button();
            this.groupBox_file = new System.Windows.Forms.GroupBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.groupBox_size = new System.Windows.Forms.GroupBox();
            this.textBox_height = new System.Windows.Forms.TextBox();
            this.textBox_width = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Y = new System.Windows.Forms.TextBox();
            this.textBox_X = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_area = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_second = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_capture = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.バージョンToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_file.SuspendLayout();
            this.groupBox_size.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(6, 18);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(271, 25);
            this.textBox_path.TabIndex = 1;
            // 
            // button_ref
            // 
            this.button_ref.Location = new System.Drawing.Point(283, 18);
            this.button_ref.Name = "button_ref";
            this.button_ref.Size = new System.Drawing.Size(41, 23);
            this.button_ref.TabIndex = 2;
            this.button_ref.Text = "参照";
            this.button_ref.UseVisualStyleBackColor = true;
            this.button_ref.Click += new System.EventHandler(this.button_ref_Click);
            // 
            // groupBox_file
            // 
            this.groupBox_file.Controls.Add(this.button_clear);
            this.groupBox_file.Controls.Add(this.textBox_path);
            this.groupBox_file.Controls.Add(this.button_ref);
            this.groupBox_file.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox_file.Location = new System.Drawing.Point(13, 31);
            this.groupBox_file.Name = "groupBox_file";
            this.groupBox_file.Size = new System.Drawing.Size(336, 77);
            this.groupBox_file.TabIndex = 3;
            this.groupBox_file.TabStop = false;
            this.groupBox_file.Text = "挿入先ファイル";
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(233, 48);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(91, 23);
            this.button_clear.TabIndex = 3;
            this.button_clear.Text = "データ消去";
            this.button_clear.UseVisualStyleBackColor = true;
            // 
            // groupBox_size
            // 
            this.groupBox_size.Controls.Add(this.textBox_height);
            this.groupBox_size.Controls.Add(this.textBox_width);
            this.groupBox_size.Controls.Add(this.label3);
            this.groupBox_size.Controls.Add(this.label4);
            this.groupBox_size.Controls.Add(this.textBox_Y);
            this.groupBox_size.Controls.Add(this.textBox_X);
            this.groupBox_size.Controls.Add(this.label2);
            this.groupBox_size.Controls.Add(this.label1);
            this.groupBox_size.Controls.Add(this.button_area);
            this.groupBox_size.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox_size.Location = new System.Drawing.Point(13, 114);
            this.groupBox_size.Name = "groupBox_size";
            this.groupBox_size.Size = new System.Drawing.Size(336, 68);
            this.groupBox_size.TabIndex = 4;
            this.groupBox_size.TabStop = false;
            this.groupBox_size.Text = "位置とサイズ";
            // 
            // textBox_height
            // 
            this.textBox_height.Location = new System.Drawing.Point(116, 40);
            this.textBox_height.Name = "textBox_height";
            this.textBox_height.Size = new System.Drawing.Size(38, 25);
            this.textBox_height.TabIndex = 8;
            this.textBox_height.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_height_Validating);
            // 
            // textBox_width
            // 
            this.textBox_width.Location = new System.Drawing.Point(31, 40);
            this.textBox_width.Name = "textBox_width";
            this.textBox_width.Size = new System.Drawing.Size(38, 25);
            this.textBox_width.TabIndex = 7;
            this.textBox_width.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_width_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "高さ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "幅";
            // 
            // textBox_Y
            // 
            this.textBox_Y.Location = new System.Drawing.Point(116, 16);
            this.textBox_Y.Name = "textBox_Y";
            this.textBox_Y.Size = new System.Drawing.Size(38, 25);
            this.textBox_Y.TabIndex = 4;
            this.textBox_Y.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_Y_Validating);
            // 
            // textBox_X
            // 
            this.textBox_X.Location = new System.Drawing.Point(31, 16);
            this.textBox_X.Name = "textBox_X";
            this.textBox_X.Size = new System.Drawing.Size(38, 25);
            this.textBox_X.TabIndex = 3;
            this.textBox_X.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_X_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "X";
            // 
            // button_area
            // 
            this.button_area.Location = new System.Drawing.Point(233, 16);
            this.button_area.Name = "button_area";
            this.button_area.Size = new System.Drawing.Size(91, 43);
            this.button_area.TabIndex = 0;
            this.button_area.Text = "範囲選択";
            this.button_area.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_second);
            this.groupBox1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(13, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 49);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "連続キャプチャ";
            // 
            // textBox_second
            // 
            this.textBox_second.Location = new System.Drawing.Point(6, 19);
            this.textBox_second.Name = "textBox_second";
            this.textBox_second.Size = new System.Drawing.Size(63, 25);
            this.textBox_second.TabIndex = 0;
            this.textBox_second.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_second_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "秒ごと";
            // 
            // button_start
            // 
            this.button_start.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_start.Location = new System.Drawing.Point(356, 29);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(113, 94);
            this.button_start.TabIndex = 6;
            this.button_start.Text = "連キャプ開始";
            this.button_start.UseVisualStyleBackColor = true;
            // 
            // button_capture
            // 
            this.button_capture.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_capture.Location = new System.Drawing.Point(356, 138);
            this.button_capture.Name = "button_capture";
            this.button_capture.Size = new System.Drawing.Size(113, 94);
            this.button_capture.TabIndex = 7;
            this.button_capture.Text = "即キャプ";
            this.button_capture.UseVisualStyleBackColor = true;
            this.button_capture.Click += new System.EventHandler(this.button_capture_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.バージョンToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(481, 26);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // バージョンToolStripMenuItem
            // 
            this.バージョンToolStripMenuItem.Name = "バージョンToolStripMenuItem";
            this.バージョンToolStripMenuItem.Size = new System.Drawing.Size(80, 22);
            this.バージョンToolStripMenuItem.Text = "バージョン";
            this.バージョンToolStripMenuItem.Click += new System.EventHandler(this.バージョンToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(481, 249);
            this.Controls.Add(this.button_capture);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_size);
            this.Controls.Add(this.groupBox_file);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "キャプはん";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_file.ResumeLayout(false);
            this.groupBox_file.PerformLayout();
            this.groupBox_size.ResumeLayout(false);
            this.groupBox_size.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_ref;
        private System.Windows.Forms.GroupBox groupBox_file;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.GroupBox groupBox_size;
        private System.Windows.Forms.TextBox textBox_Y;
        private System.Windows.Forms.TextBox textBox_X;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_area;
        private System.Windows.Forms.TextBox textBox_height;
        private System.Windows.Forms.TextBox textBox_width;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_second;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_capture;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem バージョンToolStripMenuItem;
    }
}

