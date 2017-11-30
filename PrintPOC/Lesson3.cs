using DevExpress.XtraPrinting;
using System;
using System.Drawing;
using System.Linq;

namespace PrintPOC
{
    public class Lesson3 : Lesson2
    {
        public Lesson3(PrintingSystem ps) : base(ps) { }

        // Set the background color to Deep Sky Blue. 
        protected override void CreateDetail(BrickGraphics graph)
        {
            graph.BackColor = Color.DeepSkyBlue;

            // Set the border color to Midnight Blue. 
            graph.BorderColor = Color.MidnightBlue;

            // Add a text brick with all borders and the "Hello World!" text. 
            graph.DrawString(caption, Color.DarkBlue, r, BorderSide.All);
        }
    }
}
