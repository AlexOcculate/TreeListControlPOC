namespace MainEntryPoint
{
   partial class MainEntryPointForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if( disposing && (components != null) )
         {
            components.Dispose( );
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer dockingContainer1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
         this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
         this.document1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
         this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
         this.ribbonMiniToolbar1 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
         this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
         this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
         this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
         this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
         this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
         this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
         this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
         this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
         this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
         this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
         this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
         this.dockPanel3 = new DevExpress.XtraBars.Docking.DockPanel();
         this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
         this.dockPanel4 = new DevExpress.XtraBars.Docking.DockPanel();
         this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
         this.dockPanel5 = new DevExpress.XtraBars.Docking.DockPanel();
         this.dockPanel5_Container = new DevExpress.XtraBars.Docking.ControlContainer();
         this.hideContainerTop = new DevExpress.XtraBars.Docking.AutoHideContainer();
         this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
         this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
         this.hideContainerLeft = new DevExpress.XtraBars.Docking.AutoHideContainer();
         ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.document1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
         this.dockPanel1.SuspendLayout();
         this.dockPanel2.SuspendLayout();
         this.dockPanel3.SuspendLayout();
         this.dockPanel4.SuspendLayout();
         this.dockPanel5.SuspendLayout();
         this.hideContainerTop.SuspendLayout();
         this.hideContainerBottom.SuspendLayout();
         this.hideContainerRight.SuspendLayout();
         this.hideContainerLeft.SuspendLayout();
         this.SuspendLayout();
         // 
         // documentGroup1
         // 
         this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.document1});
         // 
         // document1
         // 
         this.document1.Caption = "dockPanel1";
         this.document1.ControlName = "dockPanel1";
         this.document1.FloatLocation = new System.Drawing.Point(0, 0);
         this.document1.FloatSize = new System.Drawing.Size(200, 200);
         this.document1.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.True;
         this.document1.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
         this.document1.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
         // 
         // ribbonControl1
         // 
         this.ribbonControl1.ExpandCollapseItem.Id = 0;
         this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
         this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
         this.ribbonControl1.MaxItemId = 1;
         this.ribbonControl1.MiniToolbars.Add(this.ribbonMiniToolbar1);
         this.ribbonControl1.Name = "ribbonControl1";
         this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
         this.ribbonControl1.Size = new System.Drawing.Size(1081, 162);
         this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
         // 
         // ribbonPage1
         // 
         this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
         this.ribbonPage1.Name = "ribbonPage1";
         this.ribbonPage1.Text = "ribbonPage1";
         // 
         // ribbonPageGroup1
         // 
         this.ribbonPageGroup1.Name = "ribbonPageGroup1";
         this.ribbonPageGroup1.Text = "ribbonPageGroup1";
         // 
         // ribbonStatusBar1
         // 
         this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 701);
         this.ribbonStatusBar1.Name = "ribbonStatusBar1";
         this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
         this.ribbonStatusBar1.Size = new System.Drawing.Size(1081, 26);
         // 
         // defaultLookAndFeel1
         // 
         this.defaultLookAndFeel1.LookAndFeel.SkinName = "The Bezier";
         // 
         // documentManager1
         // 
         this.documentManager1.ContainerControl = this;
         this.documentManager1.MenuManager = this.ribbonControl1;
         this.documentManager1.View = this.tabbedView1;
         this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
         // 
         // tabbedView1
         // 
         this.tabbedView1.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup1});
         this.tabbedView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.document1});
         this.tabbedView1.RootContainer.Element = null;
         dockingContainer1.Element = this.documentGroup1;
         this.tabbedView1.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] {
            dockingContainer1});
         // 
         // dockManager1
         // 
         this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerTop,
            this.hideContainerBottom,
            this.hideContainerRight,
            this.hideContainerLeft});
         this.dockManager1.Form = this;
         this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
         this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
         // 
         // dockPanel1
         // 
         this.dockPanel1.Controls.Add(this.dockPanel1_Container);
         this.dockPanel1.DockedAsTabbedDocument = true;
         this.dockPanel1.ID = new System.Guid("373b4740-f9e1-40e4-bce1-c5355d3e3254");
         this.dockPanel1.Name = "dockPanel1";
         this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
         this.dockPanel1.Text = "dockPanel1";
         // 
         // dockPanel1_Container
         // 
         this.dockPanel1_Container.Location = new System.Drawing.Point(0, 0);
         this.dockPanel1_Container.Name = "dockPanel1_Container";
         this.dockPanel1_Container.Size = new System.Drawing.Size(1025, 455);
         this.dockPanel1_Container.TabIndex = 0;
         // 
         // dockPanel2
         // 
         this.dockPanel2.Controls.Add(this.dockPanel2_Container);
         this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
         this.dockPanel2.ID = new System.Guid("66175638-ffa4-49eb-affa-269efa8131ed");
         this.dockPanel2.Location = new System.Drawing.Point(0, 0);
         this.dockPanel2.Name = "dockPanel2";
         this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
         this.dockPanel2.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
         this.dockPanel2.SavedIndex = 1;
         this.dockPanel2.Size = new System.Drawing.Size(200, 489);
         this.dockPanel2.Text = "dockPanel2";
         this.dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
         // 
         // dockPanel2_Container
         // 
         this.dockPanel2_Container.Location = new System.Drawing.Point(4, 30);
         this.dockPanel2_Container.Name = "dockPanel2_Container";
         this.dockPanel2_Container.Size = new System.Drawing.Size(193, 456);
         this.dockPanel2_Container.TabIndex = 0;
         // 
         // dockPanel3
         // 
         this.dockPanel3.Controls.Add(this.dockPanel3_Container);
         this.dockPanel3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
         this.dockPanel3.ID = new System.Guid("e8b13422-dd09-478f-9b09-1d81512e8bc9");
         this.dockPanel3.Location = new System.Drawing.Point(0, 0);
         this.dockPanel3.Name = "dockPanel3";
         this.dockPanel3.OriginalSize = new System.Drawing.Size(200, 200);
         this.dockPanel3.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
         this.dockPanel3.SavedIndex = 1;
         this.dockPanel3.Size = new System.Drawing.Size(200, 489);
         this.dockPanel3.Text = "dockPanel3";
         this.dockPanel3.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
         // 
         // dockPanel3_Container
         // 
         this.dockPanel3_Container.Location = new System.Drawing.Point(3, 30);
         this.dockPanel3_Container.Name = "dockPanel3_Container";
         this.dockPanel3_Container.Size = new System.Drawing.Size(193, 456);
         this.dockPanel3_Container.TabIndex = 0;
         // 
         // dockPanel4
         // 
         this.dockPanel4.Controls.Add(this.controlContainer1);
         this.dockPanel4.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
         this.dockPanel4.FloatVertical = true;
         this.dockPanel4.ID = new System.Guid("82e03e3a-dd08-4e98-bdb8-7e0d0b28f780");
         this.dockPanel4.Location = new System.Drawing.Point(0, 0);
         this.dockPanel4.Name = "dockPanel4";
         this.dockPanel4.OriginalSize = new System.Drawing.Size(200, 200);
         this.dockPanel4.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
         this.dockPanel4.SavedIndex = 0;
         this.dockPanel4.Size = new System.Drawing.Size(1081, 200);
         this.dockPanel4.Text = "dockPanel4";
         this.dockPanel4.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
         // 
         // controlContainer1
         // 
         this.controlContainer1.Location = new System.Drawing.Point(3, 31);
         this.controlContainer1.Name = "controlContainer1";
         this.controlContainer1.Size = new System.Drawing.Size(1075, 166);
         this.controlContainer1.TabIndex = 0;
         // 
         // dockPanel5
         // 
         this.dockPanel5.Controls.Add(this.dockPanel5_Container);
         this.dockPanel5.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
         this.dockPanel5.ID = new System.Guid("820db223-b7bb-4a6d-a0b4-3bbee36bd110");
         this.dockPanel5.Location = new System.Drawing.Point(0, 0);
         this.dockPanel5.Name = "dockPanel5";
         this.dockPanel5.OriginalSize = new System.Drawing.Size(200, 200);
         this.dockPanel5.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Top;
         this.dockPanel5.SavedIndex = 4;
         this.dockPanel5.Size = new System.Drawing.Size(1081, 200);
         this.dockPanel5.Text = "dockPanel5";
         this.dockPanel5.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
         // 
         // dockPanel5_Container
         // 
         this.dockPanel5_Container.Location = new System.Drawing.Point(3, 30);
         this.dockPanel5_Container.Name = "dockPanel5_Container";
         this.dockPanel5_Container.Size = new System.Drawing.Size(1075, 166);
         this.dockPanel5_Container.TabIndex = 0;
         // 
         // hideContainerTop
         // 
         this.hideContainerTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
         this.hideContainerTop.Controls.Add(this.dockPanel5);
         this.hideContainerTop.Dock = System.Windows.Forms.DockStyle.Top;
         this.hideContainerTop.Location = new System.Drawing.Point(25, 162);
         this.hideContainerTop.Name = "hideContainerTop";
         this.hideContainerTop.Size = new System.Drawing.Size(1031, 25);
         // 
         // hideContainerBottom
         // 
         this.hideContainerBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
         this.hideContainerBottom.Controls.Add(this.dockPanel4);
         this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.hideContainerBottom.Location = new System.Drawing.Point(25, 676);
         this.hideContainerBottom.Name = "hideContainerBottom";
         this.hideContainerBottom.Size = new System.Drawing.Size(1031, 25);
         // 
         // hideContainerRight
         // 
         this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
         this.hideContainerRight.Controls.Add(this.dockPanel2);
         this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
         this.hideContainerRight.Location = new System.Drawing.Point(1056, 162);
         this.hideContainerRight.Name = "hideContainerRight";
         this.hideContainerRight.Size = new System.Drawing.Size(25, 539);
         // 
         // hideContainerLeft
         // 
         this.hideContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
         this.hideContainerLeft.Controls.Add(this.dockPanel3);
         this.hideContainerLeft.Dock = System.Windows.Forms.DockStyle.Left;
         this.hideContainerLeft.Location = new System.Drawing.Point(0, 162);
         this.hideContainerLeft.Name = "hideContainerLeft";
         this.hideContainerLeft.Size = new System.Drawing.Size(25, 539);
         // 
         // MainEntryPointForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1081, 727);
         this.Controls.Add(this.hideContainerTop);
         this.Controls.Add(this.hideContainerBottom);
         this.Controls.Add(this.hideContainerLeft);
         this.Controls.Add(this.hideContainerRight);
         this.Controls.Add(this.ribbonStatusBar1);
         this.Controls.Add(this.ribbonControl1);
         this.Name = "MainEntryPointForm";
         this.Ribbon = this.ribbonControl1;
         this.StatusBar = this.ribbonStatusBar1;
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.document1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
         this.dockPanel1.ResumeLayout(false);
         this.dockPanel2.ResumeLayout(false);
         this.dockPanel3.ResumeLayout(false);
         this.dockPanel4.ResumeLayout(false);
         this.dockPanel5.ResumeLayout(false);
         this.hideContainerTop.ResumeLayout(false);
         this.hideContainerBottom.ResumeLayout(false);
         this.hideContainerRight.ResumeLayout(false);
         this.hideContainerLeft.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
      private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
      private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
      private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
      private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
      private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar1;
      private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
      private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
      private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document document1;
      private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
      private DevExpress.XtraBars.Docking.DockManager dockManager1;
      private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
      private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
      private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
      private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
      private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
      private DevExpress.XtraBars.Docking.DockPanel dockPanel3;
      private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
      private DevExpress.XtraBars.Docking.DockPanel dockPanel4;
      private DevExpress.XtraBars.Docking.DockPanel dockPanel5;
      private DevExpress.XtraBars.Docking.ControlContainer dockPanel5_Container;
      private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerTop;
      private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerBottom;
      private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerLeft;
      private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
   }
}

