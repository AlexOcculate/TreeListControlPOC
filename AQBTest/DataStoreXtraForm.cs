namespace AQBTest
{
   public partial class DataStoreXtraForm : DevExpress.XtraEditors.XtraForm
   {
      private DataStoreCollection dsColl;

      public DataStoreXtraForm()
      {
         InitializeComponent( );
      }

      public DataStoreXtraForm( DataStoreCollection dsColl )
         : this( )
      {
         this.dsColl = dsColl ?? throw new System.ArgumentNullException( nameof( dsColl ) );
         this.gridControl1.DataSource = this.dsColl.List;
         //
         this.ConfigImages( );
         this.ConfigToolTipController( );
         this.ConfigGridControl( );
         this.CustomDrawEmptyForeground( );
      }

      private DevExpress.Utils.ToolTipController tpCtlr;

      private void ConfigToolTipController()
      {
         // Create and initialize the tooltip controller. 
         this.tpCtlr = new DevExpress.Utils.ToolTipController( );
         this.tpCtlr.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
         this.tpCtlr.InitialDelay = 1000;
         this.tpCtlr.ShowBeak = true;
         this.tpCtlr.ShowShadow = true;
         //// Bind the created tooltip controller to the Grid Control. 
         this.gridControl1.ToolTipController = this.tpCtlr;

         this.tpCtlr.GetActiveObjectInfo += this.TpCtlr_GetActiveObjectInfo;
         //this.tpCtlr.BeforeShow += this.TpCtlr_BeforeShow;
      }

      private void TpCtlr_GetActiveObjectInfo( object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e )
      {
         if( e.SelectedControl != this.gridControl1 ) return;
         DevExpress.XtraGrid.Views.Grid.GridView view
            = this.gridControl1.GetViewAt( e.ControlMousePosition )
            as DevExpress.XtraGrid.Views.Grid.GridView;
         if( view == null ) return;
         DevExpress.Utils.ToolTipControlInfo info = null;
         DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = view.CalcHitInfo( e.ControlMousePosition );
         //if( hi.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator )
         if( hi.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell )
         {
            if( hi.RowHandle == -2147483646 )
            {
               return;
            }
            object o = hi.HitTest.ToString( ) + hi.RowHandle.ToString( );
            string text = "Row " + hi.RowHandle.ToString( );
            DevExpress.Utils.SuperToolTip stt = new DevExpress.Utils.SuperToolTip( );
            stt.AllowHtmlText = DevExpress.Utils.DefaultBoolean.Default;
            stt.FixedTooltipWidth = false;
            stt.MaxWidth = 400;
            stt.DistanceBetweenItems = 10;
            DevExpress.Utils.SuperToolTipSetupArgs args = new DevExpress.Utils.SuperToolTipSetupArgs( );
            args.AllowHtmlText = DevExpress.Utils.DefaultBoolean.Default;
            args.ShowFooterSeparator = true;
            {
               //var pnCellValue = view.GetRowCellValue( hi.RowHandle, MetadataItemFQN.OBJECT_FIELDNAME );
               //var ptypeCellValue = view.GetRowCellValue( hi.RowHandle, MetadataItemFQN.PARENT_TYPE_FIELDNAME );
               //var fqnCellValue = view.GetRowCellValue( hi.RowHandle, MetadataItemFQN.NAMEFULLQUALIFIED_FIELDNAME );
               //var nCellValue = view.GetRowCellValue( hi.RowHandle, MetadataItemFQN.FIELD_FIELDNAME );
               //var typeCellValue = view.GetRowCellValue( hi.RowHandle, MetadataItemFQN.TYPE_FIELDNAME );
               //
               //args.Title.Text = typeCellValue?.ToString( ) + ": " + nCellValue?.ToString( );
               //args.Contents.ImageOptions.Alignment = DevExpress.Utils.ToolTipImageAlignment.Default;
               //args.Contents.Text = fqnCellValue?.ToString( );
               //args.Footer.Text = ptypeCellValue?.ToString( ) + ": " + pnCellValue?.ToString( );
               //if( typeCellValue.ToString( ) == "Field" )
               //{
               //   //args.Title.ImageOptions.Image = fld_noaction_gray_img16x16;
               //   //args.Contents.ImageOptions.Image = fld_noaction_gray_img64x64;
               //   //args.Footer.ImageOptions.Image = tbl_noaction_red_img16x16;
               //}
               //else if( typeCellValue.ToString( ) == "Table" )
               //{
               //   //args.Title.ImageOptions.Image = tbl_noaction_red_img16x16;
               //   //args.Contents.ImageOptions.Image = tbl_noaction_red_img64x64;
               //   //args.Footer.ImageOptions.Image = sch_noaction_red_img16x16;
               //}
               //else if( typeCellValue.ToString( ) == "View" )
               //{
               //   //args.Title.ImageOptions.Image = vw_noaction_red_img16x16;
               //   //args.Contents.ImageOptions.Image = vw_noaction_red_img64x64;
               //   //args.Footer.ImageOptions.Image = sch_noaction_red_img16x16;
               //}
               //else if( typeCellValue.ToString( ) == "ForeignKey" )
               //{
               //   //args.Title.ImageOptions.Image = fk_noaction_gray_img16x16;
               //   //args.Contents.ImageOptions.Image = fk_noaction_gray_img64x64;
               //   //args.Footer.ImageOptions.Image = tbl_noaction_red_img16x16;
               //}
               //else if( typeCellValue.ToString( ) == "Procedure" )
               //{
               //   //args.Title.ImageOptions.Image = proc_noaction_blue_img16x16;
               //   //args.Contents.ImageOptions.Image = proc_noaction_blue_img64x64;
               //   //args.Footer.ImageOptions.Image = sch_noaction_red_img16x16;
               //}
               //else if( typeCellValue.ToString( ) == "Synonym" )
               //{
               //   //args.Title.ImageOptions.Image = syn_noaction_yellow_img16x16;
               //   //args.Contents.ImageOptions.Image = syn_noaction_yellow_img64x64;
               //   //args.Footer.ImageOptions.Image = sch_noaction_red_img16x16;
               //}
               //else if( typeCellValue.ToString( ) == "Schema" )
               //{
               //   //args.Title.ImageOptions.Image = sch_noaction_red_img16x16;
               //   //args.Contents.ImageOptions.Image = sch_noaction_red_img64x64;
               //   //args.Footer.ImageOptions.Image = db_noaction_red_img16x16;
               //}
               //else if( typeCellValue.ToString( ) == "Database" )
               //{
               //   //args.Title.ImageOptions.Image = db_noaction_red_img16x16;
               //   //args.Contents.ImageOptions.Image = db_noaction_red_img64x64;
               //   //args.Footer.ImageOptions.Image = db_noaction_red_img16x16;
               //}
            }
            stt.Setup( args );
            info = new DevExpress.Utils.ToolTipControlInfo( o, text );
            info.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            info.SuperTip = stt;
         }
         if( info != null )
            e.Info = info;
      }

      private void tooltipController_HyperlinkClick( object sender, DevExpress.Utils.HyperlinkClickEventArgs e )
      {
         //System.Diagnostics.Process process = new System.Diagnostics.Process( );
         //process.StartInfo.FileName = (e.Link);
         //process.StartInfo.Verb = "open";
         //process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
         //try
         //{
         //   process.Start( );
         //}
         //catch { }
      }

      private void ConfigGridControl()
      {
         this.gridView1.ShowLoadingPanel( );
         ((System.ComponentModel.ISupportInitialize) (this.gridControl1)).BeginInit( );
         ((System.ComponentModel.ISupportInitialize) (this.gridView1)).BeginInit( );
         {
            //gridControl1.ForceInitialize( );
            this.gridView1.OptionsBehavior.ReadOnly = false;
            //
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler( this.gridView1_InitNewRow );
            //
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            //
            this.gridView1.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            this.gridView1.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.None;
            this.gridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowCsvFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowHtmlFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowRtfFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowTxtFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.ShowProgress = DevExpress.Export.ProgressMode.Automatic;
            //
            this.gridView1.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsMenu.ShowAutoFilterRowItem = true;
            this.gridView1.OptionsMenu.ShowConditionalFormattingItem = true;
            this.gridView1.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
            this.gridView1.OptionsMenu.ShowFooterItem = true;
            this.gridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsMenu.ShowSplitItem = true;
            //
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            this.gridView1.OptionsSelection.MultiSelect = true;
            //
            this.gridView1.Columns[ DataStore.CREATION_TS_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ DataStore.ID_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ DataStore.PARENT_ID_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ DataStore.NAME_FIELDNAME ].Visible = true;
            this.gridView1.Columns[ DataStore.DESCRIPTION_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ DataStore.PREVIEW_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ DataStore.IS_ACTIVE_FIELDNAME ].Visible = true;
            this.gridView1.Columns[ DataStore.METADATA_PROVIDER_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ DataStore.SYNTAX_PROVIDER_FIELDNAME ].Visible = true;
            this.gridView1.Columns[ DataStore.LOAD_DEFAULT_DATABASE_ONLY_FIELDNAME ].Visible = true;
            this.gridView1.Columns[ DataStore.LOAD_SYSTEM_OBJECTS_FIELDNAME ].Visible = true;
            this.gridView1.Columns[ DataStore.WITH_FIELDS_FIELDNAME ].Visible = true;
            this.gridView1.Columns[ DataStore.CONNECTION_STRING_FIELDNAME ].Visible = true;
            this.gridView1.Columns[ DataStore.AQB_QB_XML_FILENAME_FIELDNAME ].Visible = false;
            this.gridView1.Columns[ DataStore.MI_FQN_XML_FILENAME_FIELDNAME ].Visible = false;
            //
            this.gridView1.Columns[ DataStore.CREATION_TS_FIELDNAME ].Caption = DataStore.CREATION_TS_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.ID_FIELDNAME ].Caption = DataStore.ID_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.PARENT_ID_FIELDNAME ].Caption = DataStore.PARENT_ID_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.NAME_FIELDNAME ].Caption = DataStore.NAME_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.DESCRIPTION_FIELDNAME ].Caption = DataStore.DESCRIPTION_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.PREVIEW_FIELDNAME ].Caption = DataStore.PREVIEW_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.IS_ACTIVE_FIELDNAME ].Caption = DataStore.IS_ACTIVE_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.IS_PULL_REMOTELY_FIELDNAME ].Caption = DataStore.IS_PULL_REMOTELY_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.METADATA_PROVIDER_FIELDNAME ].Caption = DataStore.METADATA_PROVIDER_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.SYNTAX_PROVIDER_FIELDNAME ].Caption = DataStore.SYNTAX_PROVIDER_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.LOAD_DEFAULT_DATABASE_ONLY_FIELDNAME ].Caption = DataStore.LOAD_DEFAULT_DATABASE_ONLY_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.LOAD_SYSTEM_OBJECTS_FIELDNAME ].Caption = DataStore.LOAD_SYSTEM_OBJECTS_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.WITH_FIELDS_FIELDNAME ].Caption = DataStore.WITH_FIELDS_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.CONNECTION_STRING_FIELDNAME ].Caption = DataStore.CONNECTION_STRING_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.AQB_QB_XML_FILENAME_FIELDNAME ].Caption = DataStore.AQB_QB_XML_FILENAME_DISPLAYNAME;
            this.gridView1.Columns[ DataStore.MI_FQN_XML_FILENAME_FIELDNAME ].Caption = DataStore.MI_FQN_XML_FILENAME_DISPLAYNAME;
            //
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler( this.gridView1_RowCellStyle );
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler( this.gridView1_CustomDrawCell );
            //
         }
         ((System.ComponentModel.ISupportInitialize) (this.gridControl1)).EndInit( );
         ((System.ComponentModel.ISupportInitialize) (this.gridView1)).EndInit( );
         // this.gridView1.ShowEditForm( );
         // this.gridView1.HideEditForm( );
         this.gridView1.HideLoadingPanel( );
         {
            //DevExpress.XtraPrinting.CsvExportOptions o = new DevExpress.XtraPrinting.CsvExportOptions( ",", System.Text.Encoding.UTF8, DevExpress.XtraPrinting.TextExportMode.Value, true, false );
            //this.gridControl1.ExportToCsv( "", o );
         }
         foreach( DevExpress.XtraGrid.Columns.GridColumn gvc in this.gridView1.Columns )
         {
            gvc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
      }

      private void ConfigImages()
      {
         //{ // IMAGES and SVG
         //   db_noaction_red_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\db_red.svg" );
         //   db_noaction_red_img16x16 = db_noaction_red_svg.Render( null, 0.5 );
         //   db_noaction_red_img64x64 = db_noaction_red_svg.Render( null, 2.0 );
         //   //
         //   sch_noaction_red_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\sch_red.svg" );
         //   sch_noaction_red_img16x16 = sch_noaction_red_svg.Render( null, 0.5 );
         //   sch_noaction_red_img64x64 = sch_noaction_red_svg.Render( null, 2.0 );
         //   //
         //   syn_noaction_yellow_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\syn_yellow.svg" );
         //   syn_noaction_yellow_img16x16 = syn_noaction_yellow_svg.Render( null, 0.5 );
         //   syn_noaction_yellow_img64x64 = syn_noaction_yellow_svg.Render( null, 2.0 );
         //   //
         //   tbl_noaction_red_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\tbl_red.svg" );
         //   tbl_noaction_red_img16x16 = tbl_noaction_red_svg.Render( null, 0.5 );
         //   tbl_noaction_red_img64x64 = tbl_noaction_red_svg.Render( null, 2.0 );
         //   //
         //   vw_noaction_red_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\vw_red.svg" );
         //   vw_noaction_red_img16x16 = vw_noaction_red_svg.Render( null, 0.5 );
         //   vw_noaction_red_img64x64 = vw_noaction_red_svg.Render( null, 2.0 );
         //   //
         //   fk_noaction_gray_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\fk_gray.svg" );
         //   fk_noaction_gray_img16x16 = fk_noaction_gray_svg.Render( null, 0.5 );
         //   fk_noaction_gray_img64x64 = fk_noaction_gray_svg.Render( null, 2.0 );
         //   //
         //   proc_noaction_blue_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\proc_blue.svg" );
         //   proc_noaction_blue_img16x16 = proc_noaction_blue_svg.Render( null, 0.5 );
         //   proc_noaction_blue_img64x64 = proc_noaction_blue_svg.Render( null, 2.0 );
         //   //
         //   fld_noaction_gray_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\fld_gray.svg" );
         //   fld_noaction_gray_img16x16 = fld_noaction_gray_svg.Render( null, 0.5 );
         //   fld_noaction_gray_img64x64 = fld_noaction_gray_svg.Render( null, 2.0 );
         //   //fld_noaction_red_img = DevExpress.Images.ImageResourceCache.Default.GetImage( "devav/view/sales_16x16.png" );
         //}
      }

      private void gridView1_InitNewRow( object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e )
      {
         DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
         var o = this.dsColl.NewTemplate( );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.CREATION_TS_FIELDNAME ], o.CreationTS );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.ID_FIELDNAME ], o.ID );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.PARENT_ID_FIELDNAME ], o.ParentID );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.NAME_FIELDNAME ], o.Name );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.DESCRIPTION_FIELDNAME ], o.Description );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.PREVIEW_FIELDNAME ], o.Preview );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.IS_ACTIVE_FIELDNAME ], o.IsActive );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.IS_PULL_REMOTELY_FIELDNAME ], o.IsToPullRemotely );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.METADATA_PROVIDER_FIELDNAME ], o.MetadataProvider );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.SYNTAX_PROVIDER_FIELDNAME ], o.SyntaxProvider );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.LOAD_DEFAULT_DATABASE_ONLY_FIELDNAME ], o.LoadDefaultDatabaseOnly );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.LOAD_SYSTEM_OBJECTS_FIELDNAME ], o.LoadSystemObjects );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.WITH_FIELDS_FIELDNAME ], o.WithFields );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.CONNECTION_STRING_FIELDNAME ], o.ConnectionString );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.AQB_QB_XML_FILENAME_FIELDNAME ], o.AqbQbFilename );
         gv.SetRowCellValue( e.RowHandle, gv.Columns[ DataStore.MI_FQN_XML_FILENAME_FIELDNAME ], o.MiFqnFilename );
      }

      private void gridView1_RowCellStyle( object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e )
      {
         DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
         if( view == null ) return;

         object cellValue = e.CellValue;
         if( cellValue == null )
         {
            e.Appearance.BackColor = System.Drawing.Color.LightYellow; //.NavajoWhite;
            return;
         }
         if( cellValue is string )
         {
            if( string.IsNullOrWhiteSpace( cellValue as string ) )
            {
               if( (cellValue as string) == string.Empty )
               {
                  e.Appearance.BackColor = System.Drawing.Color.NavajoWhite;
                  return;
               }
               // WhiteSpace 
               e.Appearance.BackColor = System.Drawing.Color.MistyRose;
               return;
            }
         }
         if( e.Column.FieldName == MetadataItemFQN.TYPE_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
         if( e.Column.FieldName == MetadataItemFQN.PARENT_TYPE_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
         if( e.Column.FieldName == MetadataItemFQN.SYNTAX_PROVIDER_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
         if( e.Column.FieldName == MetadataItemFQN.METADATA_PROVIDER_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
         if( e.Column.FieldName == MetadataItemFQN.FIELD_TYPE_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
         if( e.Column.FieldName == MetadataItemFQN.CARDINALYTY_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
         if( e.Column.FieldName == MetadataItemFQN.FIELDSCOUNT_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
         if( e.Column.FieldName == MetadataItemFQN.REFERENCED_CARDINALYTY_NAME_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
         if( e.Column.FieldName == MetadataItemFQN.REFERENCED_FIELDS_COUNT_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
         if( e.Column.FieldName == MetadataItemFQN.REFERENCED_FIELDS_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
         if( e.Column.FieldName == MetadataItemFQN.SERVER_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
         if( e.Column.FieldName == MetadataItemFQN.DATABASE_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }
         if( e.Column.FieldName == MetadataItemFQN.SCHEMA_FIELDNAME )
         {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         }

         //if( e.RowHandle != view.FocusedRowHandle &&
         //   ((e.RowHandle % 2 == 0 && e.Column.VisibleIndex % 2 == 1) ||
         //   (e.Column.VisibleIndex % 2 == 0 && e.RowHandle % 2 == 1)) )
         //{
         //}

      }

      private void gridView1_CustomDrawCell( object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e )
      {
         if( e.RowHandle != DevExpress.XtraGrid.GridControl.NewItemRowHandle )
         {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo gci = e.Cell as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo;
            DevExpress.XtraEditors.ViewInfo.TextEditViewInfo info = gci.ViewInfo as DevExpress.XtraEditors.ViewInfo.TextEditViewInfo;
            if( info == null )
               return;
            info.ContextImageAlignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            //
            if( e.Column.FieldName == MetadataItemFQN.TYPE_FIELDNAME || e.Column.FieldName == MetadataItemFQN.PARENT_TYPE_FIELDNAME )
            {
               if( e.CellValue == null )
               {
                  e.Appearance.BackColor = System.Drawing.Color.LightYellow; //.NavajoWhite;
                  return;
               }
               //if( e.CellValue.ToString( ) == "Field" )
               //{
               //   info.ContextImage = fld_noaction_gray_img16x16;
               //   info.CalcViewInfo( );
               //   return;
               //}
               //else if( e.CellValue.ToString( ) == "Table" )
               //{
               //   info.ContextImage = tbl_noaction_red_img16x16;
               //   info.CalcViewInfo( );
               //   return;
               //}
               //else if( e.CellValue.ToString( ) == "View" )
               //{
               //   info.ContextImage = vw_noaction_red_img16x16;
               //   info.CalcViewInfo( );
               //   return;
               //}
               //if( e.CellValue.ToString( ) == "ForeignKey" )
               //{
               //   info.ContextImage = fk_noaction_gray_img16x16;
               //   info.CalcViewInfo( );
               //   return;
               //}
               //if( e.CellValue.ToString( ) == "Procedure" )
               //{
               //   info.ContextImage = proc_noaction_blue_img16x16;
               //   info.CalcViewInfo( );
               //   return;
               //}
               //else if( e.CellValue.ToString( ) == "Synonym" )
               //{
               //   info.ContextImage = syn_noaction_yellow_img16x16;
               //   info.CalcViewInfo( );
               //   return;
               //}
               //else if( e.CellValue.ToString( ) == "Schema" )
               //{
               //   info.ContextImage = sch_noaction_red_img16x16;
               //   info.CalcViewInfo( );
               //   return;
               //}
               //else if( e.CellValue.ToString( ) == "Database" )
               //{
               //   info.ContextImage = db_noaction_red_img16x16;
               //   info.CalcViewInfo( );
               //   return;
               //}
               return;
            }
         }
      }

      private void CustomDrawEmptyForeground()
      {
         string searchName = string.Empty;
         // gridView.ActiveFilterCriteria = new DevExpress.Data.Filtering.BinaryOperator( "Category_Name", searchName );

         // Initialize variables used to paint View's empty space in a custom manner 
         System.Drawing.Font noMatchesFoundTextFont = new System.Drawing.Font( "Tahoma", 10 );
         System.Drawing.Font trySearchingAgainTextFont = new System.Drawing.Font( "Tahoma", 15, System.Drawing.FontStyle.Underline );
         System.Drawing.Font trySearchingAgainTextFontBold = new System.Drawing.Font( trySearchingAgainTextFont, System.Drawing.FontStyle.Underline | System.Drawing.FontStyle.Bold );
         System.Drawing.SolidBrush linkBrush = new System.Drawing.SolidBrush( DevExpress.Skins.EditorsSkins.GetSkin( DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel ).Colors[ "HyperLinkTextColor" ] );
         string noMatchesFoundText = "No matches found";
         string trySearchingAgainText = "Try searching again";
         System.Drawing.Rectangle noMatchesFoundBounds = System.Drawing.Rectangle.Empty;
         System.Drawing.Rectangle trySearchingAgainBounds = System.Drawing.Rectangle.Empty;
         bool trySearchingAgainBoundsContainCursor = false;
         int offset = 10;

         //Handle this event to paint View's empty space in a custom manner 
         this.gridView1.CustomDrawEmptyForeground += ( s, e ) =>
         {
            e.DefaultDraw( );
            e.Appearance.Options.UseFont = true;
            e.Appearance.Font = noMatchesFoundTextFont;
            //Draw the noMatchesFoundText string 
            System.Drawing.Size size = e.Appearance.CalcTextSize( e.Cache, noMatchesFoundText, e.Bounds.Width ).ToSize( );
            int x = (e.Bounds.Width - size.Width) / 2;
            int y = e.Bounds.Y + offset;
            noMatchesFoundBounds = new System.Drawing.Rectangle( new System.Drawing.Point( x, y ), size );
            e.Appearance.DrawString( e.Cache, noMatchesFoundText, noMatchesFoundBounds );
            //Draw the trySearchingAgain link 
            e.Appearance.Font = trySearchingAgainBoundsContainCursor ? trySearchingAgainTextFontBold : trySearchingAgainTextFont;
            size = e.Appearance.CalcTextSize( e.Cache, trySearchingAgainText, e.Bounds.Width ).ToSize( );
            x = noMatchesFoundBounds.X - (size.Width - noMatchesFoundBounds.Width) / 2;
            y = noMatchesFoundBounds.Bottom + offset;
            size.Width += offset;
            trySearchingAgainBounds = new System.Drawing.Rectangle( new System.Drawing.Point( x, y ), size );
            e.Appearance.DrawString( e.Cache, trySearchingAgainText, trySearchingAgainBounds, linkBrush );
         };

         this.gridView1.MouseMove += ( s, e ) =>
         {
            trySearchingAgainBoundsContainCursor = trySearchingAgainBounds.Contains( e.Location );
            this.gridControl1.Cursor = trySearchingAgainBoundsContainCursor ? System.Windows.Forms.Cursors.Hand : System.Windows.Forms.Cursors.Default;
            this.gridView1.InvalidateRect( trySearchingAgainBounds );
         };

         this.gridView1.MouseDown += ( s, e ) =>
         {
            if( trySearchingAgainBoundsContainCursor )
            {
               searchName = DevExpress.XtraEditors.XtraInputBox.Show( string.Format( "Enter {0}", "Name" ), string.Format( "Enter {0} dialog", "Name" ), searchName );
               // gridView.ActiveFilterCriteria = new DevExpress.Data.Filtering.BinaryOperator( "Category_Name", searchName );
            }
         };
      }
   }
}