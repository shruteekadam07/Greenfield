using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDIWindowsApp.Entities
{
    public class Line:Shape
    {
        public Point StartPoint {  get; set; }
        public Point EndPoint { get; set; }
        public Line() { }
        public Line(Point startPoint, Point endPoint,Color c,int thickness )
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.Thickness = thickness;
            this.Color = c;
        }

        public override void Draw(Graphics g)
        {

        }
    }
}
