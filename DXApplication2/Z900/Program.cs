using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using Z900.Model;

namespace Z900
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         BonusSkins.Register();
         SkinManager.EnableFormSkins();
         Application.Run(new NavigationControllerForm());
      }
   }
}
