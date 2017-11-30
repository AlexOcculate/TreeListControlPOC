using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPOC
{
    public class Lesson7 : Lesson6
    {
        Bitmap img;
        internal Color bkImageColor = Color.Lavender;

        public Lesson7(PrintingSystem ps, Bitmap img) : base(null)
        {
            this.img = img;
            CreateDocument(ps);
        }

        protected override void CreateRow(BrickGraphics graph)
        {
            base.CreateRow(graph);

            // Add an empty rectangle with all borders displayed 
            // to a specific location using a Lavender background color. 
            graph.DrawRect(new Rectangle(200, top, 50, 50),
                BorderSide.All, bkImageColor, graph.BorderColor);

            if (img != null)

                // Add an image without borders  
                // to a specific location using a Transparent color. 
                graph.DrawImage(img, new Rectangle(200 + (50 - img.Width) / 2,
                    top + (50 - img.Height) / 2, img.Width, img.Height),
                    BorderSide.None, Color.Transparent);

        }
    }

}
