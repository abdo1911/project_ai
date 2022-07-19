using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace maze
{
    
    class acr
    {
        public int x, y;
        public Bitmap img;
    }
    class Rectangle
    {
        public int x, y, h, w,dx,dy;
    }
    class pare
    {
        public string[] p = new string[1];
        public string[] ch = new string[2];
    }
    class nodes
    {
        public string[] na= new string[1];
        public int pa;
        public int hi;
        public int dr;
    }
    public partial class Form1 : Form
    {
        Bitmap off;
        int axa, aya;
        int pathcost;



        List<acr> Lc = new List<acr>();
        List<Rectangle> Lr = new List<Rectangle>();
        List<nodes> Ln = new List<nodes>();
        List<pare> Lp = new List<pare>();
        List<Rectangle> Lrr = new List<Rectangle>();
        int fg = 0, fu = 0, fd = 0, fgg = 0, fuu = 0, fdd = 0, mg = 0, mu = 0, md = 0;

        Timer tt = new Timer();
        int ctTick = 0;
        string[] y = new string[15];
        string[] d = new string[15];
        string[] u = new string[15];
       


        public Form1()
        {
            WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            tt.Tick += Tt_Tick;
            tt.Start();

        }

        private void Tt_Tick(object sender, EventArgs e)
        {
            ctTick++;
            if (fg == 1)
            {
                moveg();
            }
            if (fu == 1)
            {
                moveu();
            }
            if (fd == 1)
            {
                moved();
            }


            DrawDubb(this.CreateGraphics());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.G)
            {
                gready();
                fg = 1;
            }
            if (e.KeyCode == Keys.D)
            {
                depth();
                fd = 1;
            }
            if (e.KeyCode == Keys.U)
            {
                Uniformcost();
                fu = 1;
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            line();
            creatacr();
            insert_nodes();
            insert_pare();
         

        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            drawscen(g2);
            g.DrawImage(off, 0, 0);
        }
        void drawscen(Graphics g)
        {
            g.Clear(Color.Black);

            for(int i = 0; i < Lr.Count; i++)
            {
                g.FillRectangle(Brushes.White, Lr[i].x, Lr[i].y, Lr[i].w, Lr[i].h);

            }
            for (int i = 0; i < Lrr.Count; i++)
            {
                g.FillRectangle(Brushes.White, Lrr[i].x, Lrr[i].y, Lrr[i].w, Lrr[i].h);

            }
            for (int i = 0; i < Lc.Count; i++)
            {
                g.DrawImage(Lc[i].img, Lc[i].x, Lc[i].y);
            }

        }
        void line()
        {
            int ax1 = 500;
            int ay1 = 250;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax1;
                pnn.y = ay1;
                pnn.w = 800;
                pnn.h = 15;
                
                Lr.Add(pnn);
            }
            int ax2 = 500;
            int ay2 = 850;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax2;
                pnn.y = ay2;
                pnn.w = 800;
                pnn.h = 15;

                Lr.Add(pnn);
            }


            int ax3 = 500;
            int ay3 = 250;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax3;
                pnn.y = ay3;
                pnn.w = 15;
                pnn.h = 600;

                Lr.Add(pnn);
            }
            int ax4 = 500+800;
            int ay4 = 250;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax4;
                pnn.y = ay4;
                pnn.w = 15;
                pnn.h = 615;

                Lr.Add(pnn);
            }

            int ax5 = 600;
            int ay5 = 250;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax5;
                pnn.y = ay5;
                pnn.w = 15;
                pnn.h = 290;

                Lr.Add(pnn);
            }

            int ax6 = 600;
            int ay6 = 650;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax6;
                pnn.y = ay6;
                pnn.w = 15;
                pnn.h = 200;

                Lr.Add(pnn);
            }

            int ax7 = 1200;
            int ay7 = 250;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax7;
                pnn.y = ay7;
                pnn.w = 15;
                pnn.h = 400;

                Lr.Add(pnn);
            }


            int ax8 = 800;
            int ay8 = 400;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax8;
                pnn.y = ay8;
                pnn.w = 200;
                pnn.h = 15;

                Lr.Add(pnn);
            }
            int ax9 = 800;
            int ay9 = 400;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax9;
                pnn.y = ay9;
                pnn.w = 15;
                pnn.h = 120;

                Lr.Add(pnn);
            }
            int ax10 = 800;
            int ay10 = 520;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax10;
                pnn.y = ay10;
                pnn.w = 200;
                pnn.h = 15;

                Lr.Add(pnn);
            }

            int ax11 = 900;
            int ay11 = 520;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax11;
                pnn.y = ay11;
                pnn.w = 15;
                pnn.h = 180;

                Lr.Add(pnn);
            }

            int ax12 = 800;
            int ay12 = 700;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax12;
                pnn.y = ay12;
                pnn.w = 200;
                pnn.h = 15;

                Lr.Add(pnn);
            }


        }

        void creatacr()
        {
            
            acr pnn = new acr();
            pnn.x = 527;
            pnn.y = 262;
            pnn.img = new Bitmap("1.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(1, 1));
            Lc.Add(pnn);

           acr pnn1 = new acr();
           pnn1.x = 820;
           pnn1.y = 450;
           pnn1.img = new Bitmap("3.bmp");
            pnn1.img.MakeTransparent(pnn.img.GetPixel(1, 1));
            Lc.Add(pnn1);
         
        }
        void insert_nodes()
        {
          
            nodes pnn1 = new nodes();
            pnn1.na[0] = "s";
            pnn1.pa = 0;
            pnn1.hi = 0;
            pnn1.dr = 0;
            Ln.Add(pnn1);
           
            nodes pnn2 = new nodes();
            pnn2.na[0] = "a";
            pnn2.pa = 10;
            pnn2.hi = 7;
            pnn2.dr = 0;
            Ln.Add(pnn2);

            nodes pnn3 = new nodes();
            pnn3.na[0] = "b";
            pnn3.pa = 10;
            pnn3.hi = 10;
            pnn3.dr = 0;
            Ln.Add(pnn3);

            nodes pnn4 = new nodes();
            pnn4.na[0] = "c";
            pnn4.pa = 2;
            pnn4.hi = 5;
            pnn4.dr = 1;
            Ln.Add(pnn4);

            nodes pnn5 = new nodes();
            pnn5.na[0] = "d";
            pnn5.pa = 3;
            pnn5.hi = 4;
            pnn5.dr = 1;
            Ln.Add(pnn5);

            nodes pnn6 = new nodes();
            pnn6.na[0] = "e";
            pnn6.pa = 4;
            pnn6.hi = 7;
            pnn6.dr = 1;
            Ln.Add(pnn6);

            nodes pnn7 = new nodes();
            pnn7.na[0] = "f";
            pnn7.pa = 5;
            pnn7.hi = 4;
            pnn7.dr = 1;
            Ln.Add(pnn7);

            nodes pnn12 = new nodes();
            pnn12.na[0] = "h";
            pnn12.pa = 5;
            pnn12.hi = 8;
            pnn12.dr = 0;
            Ln.Add(pnn12);

         

            nodes pnn8 = new nodes();
            pnn8.na[0] = "i";
            pnn8.pa = 6;
            pnn8.hi = 10;
            pnn8.dr = 0;
            Ln.Add(pnn8);

            nodes pnn9 = new nodes();
            pnn9.na[0] = "j";
            pnn9.pa = 5;
            pnn9.hi = 8;
            pnn9.dr = 0;
            Ln.Add(pnn9);

            nodes pnn10 = new nodes();
            pnn10.na[0] = "k";
            pnn10.pa = 10;
            pnn10.hi = 8;
            pnn10.dr = 0;
            Ln.Add(pnn10);

            nodes pnn11 = new nodes();
            pnn11.na[0] = "l";
            pnn11.pa = 9;
            pnn11.hi = 8;
            pnn11.dr = 0;
            Ln.Add(pnn11);

            nodes pnn13 = new nodes();
            pnn13.na[0] = "g";
            pnn13.pa = 1;
            pnn13.hi = 0;
            pnn13.dr = 0;
            Ln.Add(pnn13);







        }
        void insert_pare()
        {
            pare pnn = new pare();
            pnn.p[0] ="s";
            pnn.ch[0] = "a";
            Lp.Add(pnn);

            pare pnn2 = new pare();
            pnn2.p[0] = "a";
            pnn2.ch[0] = "b";
            Lp.Add(pnn2);

            pare pnn3 = new pare();
            pnn3.p[0] = "b";
            pnn3.ch[0] = "i";
            pnn3.ch[1] = "c";
            Lp.Add(pnn3);

            pare pnn4 = new pare();
            pnn4.p[0] = "c";
            pnn4.ch[0] = "d";
            Lp.Add(pnn4);

            pare pnn5 = new pare();
            pnn5.p[0] = "d";
            pnn5.ch[0] = "e";
            Lp.Add(pnn5);

            pare pnn6 = new pare();
            pnn6.p[0] = "e";
            pnn6.ch[0] = "f";
            Lp.Add(pnn6);

            pare pnn7 = new pare();
            pnn7.p[0] = "f";
            pnn7.ch[0] = "h";
            Lp.Add(pnn7);

            pare pnn8 = new pare();
            pnn8.p[0] = "h";
            pnn8.ch[0] = "g";
            Lp.Add(pnn8);

            pare pnn9 = new pare();
            pnn9.p[0] = "i";
            pnn9.ch[0] = "j";
            Lp.Add(pnn9);

            pare pnn10 = new pare();
            pnn10.p[0] = "j";
            pnn10.ch[0] = "k";
            Lp.Add(pnn10);

            pare pnn11 = new pare();
            pnn11.p[0] = "k";
            pnn11.ch[0] = "l";
            Lp.Add(pnn11);

            pare pnn12 = new pare();
            pnn12.p[0] = "l";
            pnn12.ch[0] = "h";
            Lp.Add(pnn12);



        }
        int gready()
        {
            string[] x=new string[15];
            int yy = 0;
          
            for(int i=0;i<Lp.Count;i++)
            {
             

                
                y[yy] = Lp[i].ch[0];
                if (Lp[i].ch[0] == "g")
                {
                    y[yy] = Lp[i].ch[0];
                    break;
                }
                if (i==2)
                {
                    string[] v = new string[2];
                    int[] vh = new int[2];
                    v[0] = Ln[3].na[0];
                    v[1] = Ln[8].na[0];
                    vh[0] = Ln[3].hi;
                    vh[1] = Ln[8].hi;
                    if (vh[0] < vh[1])
                    {
                      
                        y[yy] = v[0];
                        i = 2;
                    }
                    if (vh[1] < vh[0])
                    {
                       
                        y[yy] = v[1];
                        i = 7;
                    }
                }

                yy++;



            }
          // for(int u=0;u<yy;u++)
           //{
              //  MessageBox.Show("" + y[u]);
           //}

            if(y[2]=="c")
            {
                
                fgg = 1;
            }
            
            return(fgg);
           


        }
        int Uniformcost()
        {
            string[] x = new string[15];
       
            int yy = 0;

            for (int i = 0; i < Lp.Count; i++)
            {
               
                   pathcost += Ln[i+1].pa;

                    u[yy] = Lp[i].ch[0];

                    if (Lp[i].ch[0] == "g")
                    {
                        u[yy] = Lp[i].ch[0];
                        break;
                    }
                    if (i == 2)
                    {
                        string[] v = new string[2];
                        int[] vh = new int[2];
                        v[0] = Ln[3].na[0];
                        v[1] = Ln[8].na[0];
                        vh[0] = Ln[3].pa;
                        vh[1] = Ln[8].pa;
                        if (vh[0] < vh[1])
                        {

                            u[yy] = v[0];
                        }
                        if (vh[1] < vh[0])
                        {

                            u[yy] = v[1];

                           i = 7;
                        }
                    }

                    yy++;


            }
           // for (int t = 0; t < yy; t++)
            //{
              //  MessageBox.Show("" + u[t]);
                //MessageBox.Show("" + pathcost);
            //}
            if (u[2] == "c")
            {

                fuu = 1;
            }

            return (fuu);

        }
        int depth()
        {
            
            int dd = 0;
            string[] m = new string[1];
            for (int i = 0; i < Lp.Count; i++)
            {
                d[dd] = Lp[i].ch[0];

                if (i == 2)
                {
                    string[] v = new string[2];
                    v[0] = Lp[i].ch[0];
                    v[1] = Lp[i].ch[1];
                    for (int k = 0; k < Ln.Count; k++)
                    {

                        if (v[0] == Ln[k].na[0])
                        {
                            if (Ln[k].dr == 0)
                            {
                                d[dd] = Ln[k].na[0];
                                m[0] = d[dd];
                               
                            }
                        }
                        if(v[1]==Ln[k].na[0])
                        {
                            if (Ln[k].dr == 0)
                            {
                                d[dd] = Ln[k].na[0];
                                m[0] = d[dd];

                            }
                        }
                    }
                    i = 7;

                }
                dd++;








            }
            
            for (int t = 0; t < dd; t++)
            {
                MessageBox.Show("" + d[t]);
            }
            if (d[2] == "c")
            {

                fdd = 1;
            }

            return (fdd);
        }
        void pos()
        {
            int ax1 = 500;
            int ay1 = 430;
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = ax1;
                pnn.y = ay1;
                pnn.w = 100;
                pnn.h = 15;
                pnn.dx = 0;
                pnn.dy = 1;
                ///a
                Lrr.Add(pnn);
            }
            
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = 500;
                pnn.y = 600;
                pnn.w = 100;
                pnn.h = 15;
                pnn.dx = 0;
                pnn.dy = 1;
                //b
                Lrr.Add(pnn);
            }

            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = 650;
                pnn.y = 450;
                pnn.w = 100;
                pnn.h = 15;
                //c
                Lrr.Add(pnn);
            }

            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = 650;
                pnn.y = 300;
                pnn.w = 100;
                pnn.h = 15;
                //d
                Lrr.Add(pnn);
            }

            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = 850;
                pnn.y = 300;
                pnn.w = 100;
                pnn.h = 15;
                //e
                Lrr.Add(pnn);
            }

            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = 1050;
                pnn.y = 300;
                pnn.w = 100;
                pnn.h = 15;
                //f
                Lrr.Add(pnn);
            }
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = 1050;
                pnn.y = 450;
                pnn.w = 100;
                pnn.h = 15;
                //h
                Lrr.Add(pnn);
            }

            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = 820;
                pnn.y = 450;
                pnn.w = 100;
                pnn.h = 15;
                //g
                Lrr.Add(pnn);
            }

            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = 650;
                pnn.y = 750;
                pnn.w = 100;
                pnn.h = 15;
                //i
                Lrr.Add(pnn);
            }
            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = 850;
                pnn.y = 800;
                pnn.w = 100;
                pnn.h = 15;
                //j
                Lrr.Add(pnn);
            }

            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = 1050;
                pnn.y = 800;
                pnn.w = 100;
                pnn.h = 15;
                //k
                Lrr.Add(pnn);
            }

            for (int i = 0; i < 1; i++)
            {
                Rectangle pnn = new Rectangle();
                pnn.x = 1050;
                pnn.y = 600;
                pnn.w = 100;
                pnn.h = 15;
                //l
                Lrr.Add(pnn);
            }

        }
        void moveg()
        {
            if (mg == 0)
            {
                Lc[0].y += 3;
                if (Lc[0].x == 527 && Lc[0].y == 547)
                {

                    mg = 1;
                }

            }
            if (mg == 1)
            {
                Lc[0].x += 1;
                if (Lc[0].x == 630 && Lc[0].y == 547)
                {


                    if (fgg == 1)
                    {

                        mg = 2;
                    }
                    if(fgg==0)
                    {
                        mg = 6;
                    }


                }

            }
            if (mg == 2)
            {
                Lc[0].y -= 1;
                if (Lc[0].x == 630 && Lc[0].y == 300)
                {
                    mg = 3;
                }
            }
            if (mg == 3)
            {
                Lc[0].x += 1;
                if (Lc[0].x == 1050 && Lc[0].y == 300)
                {
                    mg = 4;
                }
            }
            if (mg == 4)
            {
                Lc[0].y += 1;
                if (Lc[0].x == 1050 && Lc[0].y == 450)
                {
                    mg = 5;
                }
            }
            if (mg == 5)
            {
                Lc[0].x -= 1;
                if (Lc[0].x == 850 && Lc[0].y == 450)
                {
                    tt.Stop();
                    MessageBox.Show("win");
                }
            }
            if (mg == 6)
            {
                Lc[0].y += 1;
                if (Lc[0].x == 630 && Lc[0].y == 750)
                {

                    mg = 7;
                }
            }

            if (mg == 7)
            {
                Lc[0].x += 1;
                if (Lc[0].x == 1015 && Lc[0].y == 750)
                {
                    mg = 8;
                }
            }
            if (mg == 8)
            {
                Lc[0].y -= 1 ;
                if (Lc[0].x == 1015 && Lc[0].y == 450)
                {
                    mg = 9;
                }
            }
            if (mg == 9)
            {
                Lc[0].x -= 1;
                if (Lc[0].x == 850 && Lc[0].y == 450)
                {
                    tt.Stop();
                    MessageBox.Show("win");
                }
            }






        }
        void moveu()
        {
            if (mu == 0)
            {
                Lc[0].y += 3;
                if (Lc[0].x == 527 && Lc[0].y == 547)
                {

                    mu = 1;
                }

            }
            if (mu == 1)
            {
                Lc[0].x += 1;
                if (Lc[0].x == 630 && Lc[0].y == 547)
                {


                    if (fuu == 1)
                    {

                        mu = 2;
                    }
                    if (fuu == 0)
                    {
                        mu = 6;
                    }


                }

            }
            if (mu == 2)
            {
                Lc[0].y -= 1;
                if (Lc[0].x == 630 && Lc[0].y == 300)
                {
                    mu = 3;
                }
            }
            if (mu == 3)
            {
                Lc[0].x += 1;
                if (Lc[0].x == 1050 && Lc[0].y == 300)
                {
                    mu = 4;
                }
            }
            if (mu == 4)
            {
                Lc[0].y += 1;
                if (Lc[0].x == 1050 && Lc[0].y == 450)
                {
                    mu = 5;
                }
            }
            if (mu == 5)
            {
                Lc[0].x -= 1;
                if (Lc[0].x == 850 && Lc[0].y == 450)
                {
                    tt.Stop();
                    MessageBox.Show("win");
                }
            }
            if (mu == 6)
            {
                Lc[0].y += 1;
                if (Lc[0].x == 630 && Lc[0].y == 750)
                {

                    mu = 7;
                }
            }

            if (mu == 7)
            {
                Lc[0].x += 1;
                if (Lc[0].x == 1015 && Lc[0].y == 750)
                {
                    mu = 8;
                }
            }
            if (mu == 8)
            {
                Lc[0].y -= 1;
                if (Lc[0].x == 1015 && Lc[0].y == 450)
                {
                    mu = 9;
                }
            }
            if (mu == 9)
            {
                Lc[0].x -= 1;
                if (Lc[0].x == 850 && Lc[0].y == 450)
                {
                    tt.Stop();
                    MessageBox.Show("win");
                }
            }



        }
        void moved()
        {
            if (md == 0)
            {
                Lc[0].y += 3;
                if (Lc[0].x == 527 && Lc[0].y == 547)
                {

                    md = 1;
                }

            }
            if (md == 1)
            {
                Lc[0].x += 1;
                if (Lc[0].x == 630 && Lc[0].y == 547)
                {


                    if (fdd == 1)
                    {

                        md = 2;
                    }
                    if (fdd == 0)
                    {
                        md = 6;
                    }


                }

            }
            if (md == 2)
            {
                Lc[0].y -= 1;
                if (Lc[0].x == 630 && Lc[0].y == 300)
                {
                    md = 3;
                }
            }
            if (md == 3)
            {
                Lc[0].x += 1;
                if (Lc[0].x == 1050 && Lc[0].y == 300)
                {
                    md = 4;
                }
            }
            if (md == 4)
            {
                Lc[0].y += 1;
                if (Lc[0].x == 1050 && Lc[0].y == 450)
                {
                    md = 5;
                }
            }
            if (md == 5)
            {
                Lc[0].x -= 1;
                if (Lc[0].x == 850 && Lc[0].y == 450)
                {
                    tt.Stop();
                    MessageBox.Show("win");
                }
            }
            if (md == 6)
            {
                Lc[0].y += 1;
                if (Lc[0].x == 630 && Lc[0].y == 750)
                {

                    md = 7;
                }
            }

            if (md == 7)
            {
                Lc[0].x += 1;
                if (Lc[0].x == 1015 && Lc[0].y == 750)
                {
                    md = 8;
                }
            }
            if (md == 8)
            {
                Lc[0].y -= 1;
                if (Lc[0].x == 1015 && Lc[0].y == 450)
                {
                    md = 9;
                }
            }
            if (md == 9)
            {
                Lc[0].x -= 1;
                if (Lc[0].x == 850 && Lc[0].y == 450)
                {
                    tt.Stop();
                    MessageBox.Show("win");
                }
            }

        }


    }

}
