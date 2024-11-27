using GDIWindowsApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDIWindowsApp
{
    public partial class Form1 : Form
    {

        public Point point1;
        public Point point2;
        public int shapeflag=1 ;
        public Color penColor;
        public int thickness;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void OnFileOpen(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename = ofd.FileName;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(filename, FileMode.Create);
                bf.Deserialize(fs);
                fs.Close();
            }
        }

        private void OnFileExit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnFileSaveAs(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string filename=ofd.FileName;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs=new FileStream(filename,FileMode.OpenOrCreate);
                //bf.Serialize(fs, shapes);
                fs.Close();
            }
        }

        private void OnFormMouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("down event");
            point1 = new Point(e.X, e.Y);

        }

        private void OnFormMouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("up event");
            point2 = new Point(e.X, e.Y);
            
            Pen pen = new Pen(Color.Red);//constructor dependency injection
            //types--->constructor DI,method DI, property DI
            Graphics g = this.CreateGraphics();
            //g.DrawLine(pen,point1,point2); ///method dependency




            switch (shapeflag)
            {
                case 1:
                    g.DrawLine(pen, point1, point2);
                    break;

                case 2:
                    {
                        float width = point2.X - point1.X;
                        float height = point2.Y - point1.Y;
                        g.DrawRectangle(pen, point1.X, point1.Y, width, height);
                    }
                    break;

            }

        }

        private void OnFormMouseMove(object sender, MouseEventArgs e)
        {

        }

        private void OnShapeLine(object sender, EventArgs e)
        {
            this.shapeflag = 1;

        }

        private void OnShapeRectangle(object sender, EventArgs e)
        {
            this.shapeflag = 2;
        }

        private void OnShapeColor(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                this.penColor=dlg.Color;
            }
        }

      
    }
}
