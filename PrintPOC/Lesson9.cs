using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPOC
{
    public class Lesson9 : Lesson8
    {
        public Lesson9(PrintingSystem ps, Bitmap img) : base(ps, img) { }

        protected override void CreateRow(BrickGraphics graph)
        {
            // Set the number of iterations for row creation. 
            int c = 230;

            for (int i = 0; i < 50; i++)
            {

                // Set the background color using RGB. 
                bkImageColor = Color.FromArgb(c, c, c + 20);

                base.CreateRow(graph);
                c = c - 4 > 0 ? c - 4 : c;
            }
        }

        protected override void CreateMarginalHeader(BrickGraphics graph)
        {
            // Set the format string for a page info brick. 
            string format = "Page {0} of {1}";

            // Set font to the default font. 
            graph.Font = graph.DefaultFont;

            // Set the background color to Transparent. 
            graph.BackColor = Color.Transparent;

            // Set the rectangle for drawing. 
            RectangleF r = new RectangleF(0, 0, 0, graph.Font.Height);

            // Add a page info brick without borders that displays 
            // the current page number and the total number of pages. 
            PageInfoBrick brick = graph.DrawPageInfo(PageInfo.NumberOfTotal, format,
               Color.Black, r, BorderSide.None);

            // Set brick alignment. 
            brick.Alignment = BrickAlignment.Far;

            // Enable auto width for a brick. 
            brick.AutoWidth = true;

            // Add a page info brick without borders  
            // that displays the date and time. 
            brick = graph.DrawPageInfo(PageInfo.DateTime, "", Color.Black, r, BorderSide.None);

            // Set brick alignment. 
            brick.Alignment = BrickAlignment.Near;

            // Enable auto width for a brick. 
            brick.AutoWidth = true;
        }
    }

}
