using DevExpress.XtraPrinting;
using System;
using System.Drawing;
using System.Linq;

namespace PrintPOC
{
    public class Lesson2 : Lesson1
    {
        internal int top = 0;
        internal Rectangle r = new Rectangle(0, 0, 150, 50);
        internal string caption = "Hello World!";

        public Lesson2(PrintingSystem ps) : base(ps) { }

        protected override void BeforeCreate()
        {
            base.BeforeCreate();
            if (this.PrintingSystem != null)
            {
                BrickGraphics g = this.PrintingSystem.Graph;

                // Set the background color to White. 
                g.BackColor = Color.White;

                // Set the border color to Black. 
                g.BorderColor = Color.Black;

                // Set the font to the default font. 
                g.Font = g.DefaultFont;

                // Set the line alignment. 
                g.StringFormat = g.StringFormat.ChangeLineAlignment(StringAlignment.Near);
            }
        }

        // Add a text brick without borders containing the "Hello World!" text. 
        protected override void CreateDetail(BrickGraphics graph)
        {
            graph.DrawString(caption, Color.Black, r, BorderSide.None);
        }
    }

}
