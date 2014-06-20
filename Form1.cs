using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Json;
using System.IO;

namespace capturehunter
{
    public partial class Form1 : Form
    {
        //private const string SCRIPTNAME_JQUERY = "jquery-1.11.1.min.js";
        //private const string SCRIPTNAME_GALLERIFFIC = "jquery.galleriffic.js";

        private const int SRCCOPY = 13369376;
        private const int CAPTUREBLT = 1073741824;

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("gdi32.dll")]
        private static extern int BitBlt(IntPtr hDestDC,
            int x,
            int y,
            int nWidth,
            int nHeight,
            IntPtr hSrcDC,
            int xSrc,
            int ySrc,
            int dwRop);

        [DllImport("user32.dll")]
        private static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd,
            ref  RECT lpRect);

        public Version VersionInstanse; // バージョン情報フォーム
        //public Setting SettingInstanse; // 設定フォーム
        //public Thread th = null;        // 本スレ取得スレッド
        //public Thread th_h = null;      // 避難所スレ取得スレッド
        //static readonly object syncObject = new object(); // 同期オブジェクト

        public Boolean boolStartFlag;   // 開始フラグ
        //public Boolean boolResExist;    // レス存在フラグ
        //public Int64 timersec = 0;      // 経過時間
        //public Int64 basetime = 0;      // 基準時刻
        //public Int64 timerdiff = 0;     // タイマー差分
        public int httptimersec = 0;    // データ取得処理クロック

        //public Int32 resnum = 0;        // 読み込み済みレス数
        //public Int32 resnum_h = 0;      // 読み込み済みレス数（避難所）
        //public Boolean boolThreadDup = false;    //スレッド重複防止
        //public Boolean boolThreadDup_h = false;  //スレッド重複防止（避難所）

        public AreaCapture AC;

        //OpenFileDialogクラスのインスタンスを作成
        OpenFileDialog ofd = new OpenFileDialog();


        // タブ色用 
        //public Boolean boolResAdded = false;     // 新着フラグ

        // default font（戻し用）
        public System.Drawing.Font basefont;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 初期設定
            AC = new AreaCapture(this);

            // フォーム作成
            this.VersionInstanse = new Version();
            //this.SettingInstanse = new Setting();

            //this.SettingInstanse.parentForm = this;

            // バージョン情報
            System.Diagnostics.FileVersionInfo ver =
                 System.Diagnostics.FileVersionInfo.GetVersionInfo(
                 System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.VersionInstanse.strVersion = ver.ProductVersion;

            // 設定値割り当て
            this.textBox_path.Text = Properties.Settings.Default.path;
            this.textBox_X.Text = Properties.Settings.Default.X;
            this.textBox_Y.Text = Properties.Settings.Default.Y;
            this.textBox_width.Text = Properties.Settings.Default.width;
            this.textBox_height.Text = Properties.Settings.Default.height;
            this.textBox_second.Text = Properties.Settings.Default.second;

            //AC.Top = Int32.Parse(this.textBox_Y.Text);
            //AC.Left = Int32.Parse(this.textBox_X.Text);
            AC.Width = Int32.Parse(this.textBox_width.Text);
            AC.Height = Int32.Parse(this.textBox_height.Text);

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            //ofd.FileName = "default.html";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            //ofd.InitialDirectory = @"C:\";
            //[ファイルの種類]ではじめに
            //「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 2;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            // 開始フラグ
            boolStartFlag = false;

            this.button_start.Text = "連キャプ\r\n開始";

            //timer1.Interval = 1000;

        }

        private void textBox_X_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!Int32.TryParse(((TextBox)sender).Text, out i))
            {
                MessageBox.Show("数字を入力してください。");
                e.Cancel = true;
            }
            
        }

        private void textBox_Y_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!Int32.TryParse(((TextBox)sender).Text, out i))
            {
                MessageBox.Show("数字を入力してください。");
                e.Cancel = true;
            }
        }

        private void textBox_width_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!Int32.TryParse(((TextBox)sender).Text, out i))
            {
                MessageBox.Show("数字を入力してください。");
                e.Cancel = true;
            }
            if (i <= 0)
            {
                MessageBox.Show("指定された範囲が不正です。");
                e.Cancel = true;
            }
        }

        private void textBox_height_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!Int32.TryParse(((TextBox)sender).Text, out i))
            {
                MessageBox.Show("数字を入力してください。");
                e.Cancel = true;
            }
            if (i <= 0)
            {
                MessageBox.Show("指定された範囲が不正です。");
                e.Cancel = true;
            }
        }

        private void textBox_second_Validating(object sender, CancelEventArgs e)
        {
            int i;
            if (!Int32.TryParse(((TextBox)sender).Text, out i))
            {
                MessageBox.Show("数字を入力してください。");
                e.Cancel = true;
            }
            if (i <= 0)
            {
                MessageBox.Show("指定された範囲が不正です。");
                e.Cancel = true;
            }
        }

        private void バージョンToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.VersionInstanse.Show();
        }

        private void button_ref_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.textBox_path.Text = ofd.FileName;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //設定値保存
                Properties.Settings.Default.path = this.textBox_path.Text;
                Properties.Settings.Default.X = this.textBox_X.Text;
                Properties.Settings.Default.Y = this.textBox_Y.Text;
                Properties.Settings.Default.width = this.textBox_width.Text;
                Properties.Settings.Default.height = this.textBox_height.Text;
                Properties.Settings.Default.second = this.textBox_second.Text;
                Properties.Settings.Default.Save();

                this.timer1.Stop();
                //if (th != null) { th.Abort(); th = null; }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button_capture_Click(object sender, EventArgs e)
        {
            myCapture();
        }

        private void myCapture() {
            if (!error_check())
            {
                return;
            }

            // 範囲指定を確定する
            Int32 X = Int32.Parse(this.textBox_X.Text);
            Int32 Y = Int32.Parse(this.textBox_Y.Text);
            Int32 width = Int32.Parse(this.textBox_width.Text);
            Int32 height = Int32.Parse(this.textBox_height.Text);

            // 保存処理
            // フォルダ取得
            string stParentName = System.IO.Path.GetDirectoryName(this.textBox_path.Text);
            // フォルダ確認・作成
            if (!System.IO.File.Exists(stParentName + "\\capture"))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(stParentName + "\\capture");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            // 現在時刻取得
            DateTime dt = System.DateTime.Now;
            string dirname = stParentName + "\\capture";
            string fname = dirname + "\\" + dt.ToString("yyyyMMdd-HHmmss-ffffff") + ".jpg";

            // キャプチャロジック
            Bitmap bmp = CaptureScreen(X, Y, width, height); ;
            try
            {
                bmp.Save(fname, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {

                MessageBox.Show("画像の保存に失敗しました。\r\n" + ex.Message);
                return;
            }
            finally { bmp.Dispose(); }

            // 埋め込み情報作成
            // 全ファイルの情報取得
            string[] capture = System.IO.Directory.GetFiles(dirname, "*.jpg", System.IO.SearchOption.AllDirectories);
            Array.Sort(capture);
            Array.Reverse(capture);

            StringBuilder sb = new StringBuilder("");
            sb.Append("capture=[");

            for (int i = 0; i < capture.Length; i++)
            {
                string str = Path.GetFileName(capture[i]);
                sb.Append("'" + str.Substring(0, 22) + "',");
            }

            sb.Append("];");

            System.IO.File.WriteAllText(this.textBox_path.Text, sb.ToString());
            //Console.WriteLine(sb.ToString());
        }

        private Boolean error_check() {
            if (this.textBox_path.Text == "") { MessageBox.Show("ファイルが指定されていません。"); return false; }
            //if (!System.IO.File.Exists(this.textBox_path.Text)) { MessageBox.Show("ファイルがありません。"); return false; }
            return true;
        }

        /// <summary>
        /// プライマリスクリーンの画像を取得する
        /// </summary>
        /// <returns>プライマリスクリーンの画像</returns>
        public static Bitmap CaptureScreen(Int32 X, Int32 Y, Int32 width, Int32 height)
        {
            //プライマリモニタのデバイスコンテキストを取得
            IntPtr disDC = GetDC(IntPtr.Zero);
            //Bitmapの作成
            Bitmap bmp = new Bitmap(width, height);
            //Graphicsの作成
            Graphics g = Graphics.FromImage(bmp);
            //Graphicsのデバイスコンテキストを取得
            IntPtr hDC = g.GetHdc();
            //Bitmapに画像をコピーする
            BitBlt(hDC, 0, 0, width, height,
                disDC, X, Y, SRCCOPY);
            //解放
            g.ReleaseHdc(hDC);
            g.Dispose();
            ReleaseDC(IntPtr.Zero, disDC);

            return bmp;
        }

        /// <summary>
        /// アクティブなウィンドウの画像を取得する
        /// </summary>
        /// <returns>アクティブなウィンドウの画像</returns>
        public static Bitmap CaptureActiveWindow()
        {
            //アクティブなウィンドウのデバイスコンテキストを取得
            IntPtr hWnd = GetForegroundWindow();
            IntPtr winDC = GetWindowDC(hWnd);
            //ウィンドウの大きさを取得
            RECT winRect = new RECT();
            GetWindowRect(hWnd, ref winRect);
            //Bitmapの作成
            Bitmap bmp = new Bitmap(winRect.right - winRect.left,
                winRect.bottom - winRect.top);
            //Graphicsの作成
            Graphics g = Graphics.FromImage(bmp);
            //Graphicsのデバイスコンテキストを取得
            IntPtr hDC = g.GetHdc();
            //Bitmapに画像をコピーする
            BitBlt(hDC, 0, 0, bmp.Width, bmp.Height,
                winDC, 0, 0, SRCCOPY);
            //解放
            g.ReleaseHdc(hDC);
            g.Dispose();
            ReleaseDC(hWnd, winDC);

            return bmp;
        }

        private void button_area_Click(object sender, EventArgs e)
        {
            
            AC.Show();
            AC.Location = new Point(Int32.Parse(this.textBox_X.Text), Int32.Parse(this.textBox_Y.Text));
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (boolStartFlag)
            {
                timer1.Stop();
                this.button_start.Text = "連キャプ\r\n開始";
                this.button_start.BackColor = SystemColors.Control;
            }
            else
            {
                timer1.Interval = 1000;
                timer1.Start();
                this.button_start.Text = "連キャプ\r\n停止";
                this.button_start.BackColor = Color.Red;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.httptimersec % Int32.Parse(this.textBox_second.Text) == 0 && boolStartFlag)
            {

                myCapture();

            }
            httptimersec++;
        }

    }
}
