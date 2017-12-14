using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Linq;
using Z900.Model;

namespace Z900
{
   public partial class NavigationControllerForm : DevExpress.XtraBars.Ribbon.RibbonForm
   {
      private XtraUserControl employeesUserControl;
      private XtraUserControl customersUserControl;
      private XtraUserControl dataStoresUserControl;
      private XtraUserControl configPathsUserControl;
      private ConfigPathCollection cpColl;
      public NavigationControllerForm()
      {
         InitializeComponent();
      }
      private void NavigationControllerForm_Load(object sender, EventArgs e)
      {
         this.cpColl = ConfigPathCollection.Load();
         this.RecreateUserControls();
      }

      private void NavigationControllerForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
      {
         this.cpColl?.Save();
      }

      private void NavigationControllerForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
      {

      }
      private void accordionControl_SelectedElementChanged(object sender, SelectedElementChangedEventArgs e)
      {
         if (e.Element == null) return;
         //XtraUserControl userControl = e.Element.Text == "Employees" ? employeesUserControl : customersUserControl;
         //tabbedView.AddDocument(userControl);
         //tabbedView.ActivateDocument(userControl);
         XtraUserControl uc; ;
         if (e.Element == this.dataStoresAccordionControlElement)
         {
            uc = this.dataStoresUserControl;
            //this.dataStoresUserControl.Focus();
         }
         else if (e.Element == this.configPathsAccordionControlElement)
         {
            uc = this.configPathsUserControl;
         }
         else if (e.Element == this.employeesAccordionControlElement)
         {
            uc = this.employeesUserControl;
         }
         else if (e.Element == this.customersAccordionControlElement)
         {
            uc = this.customersUserControl;
         }
         else
         {
            return;
         }
         this.tabbedView.AddDocument(uc);
         this.tabbedView.ActivateDocument(uc);
         RibbonControl mergedRibbon = this.ribbonControl.MergedRibbon;
         if (mergedRibbon == null)
            return;
         this.ribbonControl.SelectedPage = mergedRibbon.Pages["Home"];
      }
      private void barButtonNavigation_ItemClick(object sender, ItemClickEventArgs e)
      {
         //int barItemIndex = barSubItemNavigation.ItemLinks.IndexOf(e.Link);
         //accordionControl.SelectedElement = mainAccordionGroup.Elements[barItemIndex];
         BarItem item = e.Item;
         if (item == this.dataStoresBarButtonItem)
         {
            accordionControl.SelectedElement = this.dataStoresAccordionControlElement;
         }
         else if (item == this.configPathsBarButtonItem)
         {
            accordionControl.SelectedElement = this.configPathsAccordionControlElement;
         }
         else if (item == this.employeesBarButtonItem)
         {
            accordionControl.SelectedElement = this.employeesAccordionControlElement;
         }
         else if (item == this.customersBarButtonItem)
         {
            accordionControl.SelectedElement = this.customersAccordionControlElement;
         }
      }
      private void tabbedView_DocumentClosed(object sender, DocumentEventArgs e)
      {
         RecreateUserControls(e);
         SetAccordionSelectedElement(e);
      }
      private void SetAccordionSelectedElement(DocumentEventArgs e)
      {
         if (tabbedView.Documents.Count == 0)
         {
            accordionControl.SelectedElement = null;
            return;
         }
         //if (e.Document.Caption == "Employees")
         //{
         //    accordionControl.SelectedElement = customersAccordionControlElement;
         //}
         //else
         //{
         //    accordionControl.SelectedElement = employeesAccordionControlElement;
         //}
      }
      private void RecreateUserControls(DocumentEventArgs e = null)
      {
         if (e == null || e.Document.Caption == "DataStores")
         {
            this.dataStoresUserControl = CreateDataStoreUserControl("DataStores");
         }
         if (e == null || e.Document.Caption == "Paths")
         {
            this.configPathsUserControl = this.CreateConfigPathsUserControl("Paths");
         }
         if (e == null || e.Document.Caption == "Employees")
         {
            this.employeesUserControl = CreateUserControl("Employees");
         }
         if (e == null || e.Document.Caption == "Customers")
         {
            this.customersUserControl = CreateUserControl("Customers");
         }
         if (e == null)
         {
            this.accordionControl.SelectedElement = this.dataStoresAccordionControlElement;
         }
      }
      private XtraUserControl CreateDataStoreUserControl(string text)
      {
         XtraUserControl result = new DataStoreCollectionXUC();
         result.Name = text.ToLower() + "UserControl";
         result.Text = text;
         LabelControl label = new LabelControl();
         label.Parent = result;
         label.Appearance.Font = new Font("Tahoma", 25.25F);
         label.Appearance.ForeColor = Color.Gray;
         label.Dock = System.Windows.Forms.DockStyle.Fill;
         label.AutoSizeMode = LabelAutoSizeMode.None;
         label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         label.Text = text;
         return result;
      }
      private XtraUserControl CreateConfigPathsUserControl(string text)
      {
         XtraUserControl result = new ConfigPathsCollectionXUC(this.cpColl);
         result.Name = text.ToLower() + "UserControl";
         result.Text = text;
         LabelControl label = new LabelControl();
         label.Parent = result;
         label.Appearance.Font = new Font("Tahoma", 25.25F);
         label.Appearance.ForeColor = Color.Gray;
         label.Dock = System.Windows.Forms.DockStyle.Fill;
         label.AutoSizeMode = LabelAutoSizeMode.None;
         label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         label.Text = text;
         return result;
      }
      private XtraUserControl CreateUserControl(string text)
      {
         XtraUserControl result = new XtraUserControl();
         result.Name = text.ToLower() + "UserControl";
         result.Text = text;
         LabelControl label = new LabelControl();
         label.Parent = result;
         label.Appearance.Font = new Font("Tahoma", 25.25F);
         label.Appearance.ForeColor = Color.Gray;
         label.Dock = System.Windows.Forms.DockStyle.Fill;
         label.AutoSizeMode = LabelAutoSizeMode.None;
         label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         label.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         label.Text = text;
         return result;
      }
   }
}