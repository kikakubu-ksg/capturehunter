using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace capturehunter
{
    public partial class AreaCapture : Form
    {

        Form1 f1;

        public AreaCapture(Form1 f)
        {
            f1 = f;
            InitializeComponent();
        }

        private const int WM_NCHITTEST = 0x84;
        private const int NCLBUTTONDBLCLK = 0xA3;
        private const int HTERROR = (-2);
        private const int HTTRANSPARENT = (-1);
        private const int HTNOWHERE = 0;
        private const int HTCLIENT = 1;
        private const int HTCAPTION = 2;
        private const int HTSYSMENU = 3;
        private const int HTGROWBOX = 4;
        private const int HTSIZE = HTGROWBOX;
        private const int HTMENU = 5;
        private const int HTHSCROLL = 6;
        private const int HTVSCROLL = 7;
        private const int HTMINBUTTON = 8;
        private const int HTMAXBUTTON = 9;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;
        private const int HTBORDER = 18;
        private const int HTREDUCE = HTMINBUTTON;
        private const int HTZOOM = HTMAXBUTTON;
        private const int HTSIZEFIRST = HTLEFT;
        private const int HTSIZELAST = HTBOTTOMRIGHT;

        public Boolean ClientRectangleOnly
        {
            get
            {
                return this.Region != null;
            }
            set
            {
                if (value == this.ClientRectangleOnly)
                {
                    return;
                }
                if (this.Region == null)
                {
                    Rectangle r = new Rectangle();
                    r.X = this.PointToScreen(this.ClientRectangle.Location).X - this.Left;
                    r.Y = this.PointToScreen(this.ClientRectangle.Location).Y - this.Top;
                    r.Width = this.ClientRectangle.Width;
                    r.Height = this.ClientRectangle.Height;
                    this.Region = new Region(r);
                }
                else
                {
                    this.Region = null;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch(m.Msg){
                case WM_NCHITTEST:
                    Point p = this.PointToClient(new Point(m.LParam.ToInt32() % 65536, m.LParam.ToInt32() / 65536));
                    if(p.X > this.ClientRectangle.Right){break;}
                    if(p.X < this.ClientRectangle.Left){break;}
                    if(p.Y < this.ClientRectangle.Top){break;}
                    if(p.Y > this.ClientRectangle.Bottom){break;}
                    if(p.X < this.ClientRectangle.Left + 5){
                        if(p.Y < this.ClientRectangle.Top + 5){
                            m.Result = (System.IntPtr)HTTOPLEFT;
                            return;
                        }
                        if(p.Y > this.ClientRectangle.Bottom - 5 ){
                            m.Result = (System.IntPtr)HTBOTTOMLEFT;
                            return;
                        }
                        m.Result = (System.IntPtr)HTLEFT;
                        return;
                    }
                    if(p.X > this.ClientRectangle.Right - 5){
                        if(p.Y < this.ClientRectangle.Top + 5){
                            m.Result = (System.IntPtr)HTTOPRIGHT;
                            return;
                        }
                        if(p.Y > this.ClientRectangle.Bottom - 5 ){
                            m.Result = (System.IntPtr)HTBOTTOMRIGHT;
                            return;
                        }
                        m.Result = (System.IntPtr)HTRIGHT;
                        return;
                    }
                    if(p.Y < this.ClientRectangle.Top + 5 ){
                        m.Result = (System.IntPtr)HTTOP;
                        return;
                    }
                    if(p.Y > this.ClientRectangle.Bottom - 5 ){
                        m.Result = (System.IntPtr)HTBOTTOM;
                        return;
                    }
                    m.Result = (System.IntPtr)HTCAPTION;
                    return;
                case NCLBUTTONDBLCLK:
                    f1.textBox_X.Text = this.Left.ToString();
                    f1.textBox_Y.Text = this.Top.ToString();
                    f1.textBox_width.Text = this.Width.ToString();
                    f1.textBox_height.Text = this.Height.ToString();
                    this.Hide();
                    return;
                default:
                    break;
            }
            base.WndProc(ref m);
        }

        private void AreaCapture_ClientSizeChanged(object sender, EventArgs e)
        {
            if (this.ClientRectangleOnly) {
                Rectangle r = new Rectangle();
                r.X = this.PointToScreen(this.ClientRectangle.Location).X - this.Left;
                r.Y = this.PointToScreen(this.ClientRectangle.Location).Y - this.Top;
                r.Width = this.ClientRectangle.Width;
                r.Height = this.ClientRectangle.Height;
                this.Region = new Region(r);
            }
        }

        private void AreaCapture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt){
                if (this.ClientRectangleOnly){
                    this.ClientRectangleOnly = false;
                }
                else{

                this.ClientRectangleOnly = true;
                }
                e.Handled = true;
            }
            
        }

        private void AreaCapture_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("yea");
        }

    }
}
