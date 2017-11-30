using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPOC
{
    public class Lesson8 : Lesson7
    {
        public Lesson8(PrintingSystem ps, Bitmap img) : base(ps, img) { }

        protected override void CreateDetailHeader(BrickGraphics graph)
        {
            // Center the text string horizontally and vertically. 
            graph.StringFormat = new BrickStringFormat(StringAlignment.Center, StringAlignment.Center);

            // Set the brick font name to 'Comic Sans MS' and set the size to '12'. 
            graph.Font = new Font("Comic Sans MS", 12);

            // Set the background color to 'Light Green'. 
            graph.BackColor = Color.LightGreen;

            // Add a text brick with all borders displayed to a specific location  
            // containing the "I" text string with Green font. 
            graph.DrawString("I", Color.Green, new Rectangle(0, 0, 150, 25), BorderSide.All);

            // Add a text brick with all borders displayed to a specific location  
            // containing the "love" text string with Green font. 
            graph.DrawString("love", Color.Green, new Rectangle(150, 0, 50, 25), BorderSide.All);

            // Add a text brick with all borders displayed to a specific location  
            // containing the "you" text string with Green font. 
            graph.DrawString("you", Color.Green, new Rectangle(200, 0, 50, 25), BorderSide.All);

            // Set the line alignment. 
            graph.StringFormat = graph.StringFormat.ChangeAlignment(StringAlignment.Near);
        }
    }

}
