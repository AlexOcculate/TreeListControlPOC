using DevExpress.XtraPrinting;
using System;
using System.Drawing;
using System.Linq;

namespace PrintPOC
{
    public class Lesson5 : Lesson4
    {
        public Lesson5(PrintingSystem ps) : base(ps) { }

        protected override void CreateDetail(BrickGraphics graph)
        {
            // Center the text string. 
            graph.StringFormat = graph.StringFormat.ChangeLineAlignment(StringAlignment.Center);

            base.CreateDetail(graph);
            CreateRow(graph);
        }

        protected virtual void CreateRow(BrickGraphics graph)
        {
            // Set the brick font name to 'Arial', set the size to '14', and set the bold attribute. 
            graph.Font = new Font("Arial", 14, FontStyle.Bold);

            // Add a text brick with all borders to a specific location  
            // containing the "Good-bye!" text in blue font. 
            graph.DrawString("Good-bye!", Color.Blue,
                new Rectangle(0, top += 50, 150, 50), BorderSide.All);
        }
    }

}
