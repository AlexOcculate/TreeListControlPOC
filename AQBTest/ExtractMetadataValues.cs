namespace AQBTest
{
   public class ExtractMetadataValues
   {
      private class StackItem
      {
         public ActiveQueryBuilder.Core.MetadataList list;
         public int index;
         public int parentID;
         public int grandParentID;
      }

      private static DevExpress.Utils.Svg.SvgBitmap db_noaction_red_svg;
      private static System.Drawing.Image db_noaction_red_img;
      //
      private static DevExpress.Utils.Svg.SvgBitmap sch_noaction_red_svg;
      private static System.Drawing.Image sch_noaction_red_img;
      //
      private static DevExpress.Utils.Svg.SvgBitmap syn_noaction_yellow_svg;
      private static System.Drawing.Image syn_noaction_yellow_img;
      //
      private static DevExpress.Utils.Svg.SvgBitmap tbl_noaction_red_svg;
      private static System.Drawing.Image tbl_noaction_red_img;
      //
      private static DevExpress.Utils.Svg.SvgBitmap vw_noaction_red_svg;
      private static System.Drawing.Image vw_noaction_red_img;
      //
      private static DevExpress.Utils.Svg.SvgBitmap fk_noaction_gray_svg;
      private static System.Drawing.Image fk_noaction_gray_img;
      //
      private static DevExpress.Utils.Svg.SvgBitmap proc_noaction_blue_svg;
      private static System.Drawing.Image proc_noaction_blue_img;
      //
      private static DevExpress.Utils.Svg.SvgBitmap fld_noaction_gray_svg;
      private static System.Drawing.Image fld_noaction_gray_img;

      public static void ConfigGridControl( DevExpress.XtraGrid.GridControl gc, DevExpress.XtraGrid.Views.Grid.GridView gv )
      {
         {
            // Create and initialize the tooltip controller. 
            //DevExpress.Utils.ToolTipController tpCtlr = new DevExpress.Utils.ToolTipController( );
            //tpCtlr.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            //tpCtlr.ShowBeak = true;
            //tpCtlr.ShowShadow = true;
            //// Bind the created tooltip controller to the Grid Control. 
            //gc.ToolTipController = tpCtlr;

            //tpCtlr.GetActiveObjectInfo += TpCtlr_GetActiveObjectInfo;
            //tpCtlr.BeforeShow += TpCtlr_BeforeShow;

            // Create and customize a SuperToolTip: 
            //DevExpress.Utils.SuperToolTip stp = new DevExpress.Utils.SuperToolTip( );
            //DevExpress.Utils.SuperToolTipSetupArgs args = new DevExpress.Utils.SuperToolTipSetupArgs( );
            //args.Title.Text = "Header";
            //args.Contents.Text = "This tooltip contains a hyperlink. Visit the <href=http://help.devexpress.com>DevExpress Knowledge Center</href> to learn more.";
            //args.ShowFooterSeparator = true;
            //args.Footer.Text = "Footer";
            //stp.Setup( args );
            //// Enable HTML Text Formatting for the created SuperToolTip: 
            //stp.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            ////..or enable this feature for all tooltips: 
            ////defaultTooltipController.AllowHtmlText = true; 
            //tpCtlr.AllowHtmlText = true;
            //// Respond to clicking hyperlinks in tooltips: 
            ////defaultTooltipController.HyperlinkClick += defaultTooltipController_HyperlinkClick;
            //tpCtlr.HyperlinkClick += tooltipController_HyperlinkClick;
            //tpCtlr.SetSuperTip( gc , stp ); // the whole grid!!! BAD!!!

            //DevExpress.Utils.SuperToolTipPreviewControl x = new DevExpress.Utils.SuperToolTipPreviewControl( stp );
            //x.Show( );

         }
         {
            db_noaction_red_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\db_red.svg" );
            db_noaction_red_img = db_noaction_red_svg.Render( null, 0.5 );
            //
            sch_noaction_red_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\sch_red.svg" );
            sch_noaction_red_img = sch_noaction_red_svg.Render( null, 0.5 );
            //
            syn_noaction_yellow_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\syn_yellow.svg" );
            syn_noaction_yellow_img = syn_noaction_yellow_svg.Render( null, 0.5 );
            //
            tbl_noaction_red_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\tbl_red.svg" );
            tbl_noaction_red_img = tbl_noaction_red_svg.Render( null, 0.5 );
            //
            vw_noaction_red_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\vw_red.svg" );
            vw_noaction_red_img = vw_noaction_red_svg.Render( null, 0.5 );
            //
            fk_noaction_gray_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\fk_gray.svg" );
            fk_noaction_gray_img = fk_noaction_gray_svg.Render( null, 0.5 );
            //
            proc_noaction_blue_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\proc_blue.svg" );
            proc_noaction_blue_img = proc_noaction_blue_svg.Render( null, 0.5 );
            //
            fld_noaction_gray_svg = DevExpress.Utils.Svg.SvgBitmap.FromFile( @"D:\users\user01\source\repos\TreeListControlPOC\AQBTest\images\icons\fld_gray.svg" );
            fld_noaction_gray_img = fld_noaction_gray_svg.Render( null, 0.5 );
            //fld_noaction_red_img = DevExpress.Images.ImageResourceCache.Default.GetImage( "devav/view/sales_16x16.png" );
         }
         gv.ShowLoadingPanel( );
         ((System.ComponentModel.ISupportInitialize) (gc)).BeginInit( );
         ((System.ComponentModel.ISupportInitialize) (gv)).BeginInit( );
         {
            //gridControl1.ForceInitialize( );
            gv.OptionsBehavior.ReadOnly = true;
            //
            gv.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            gv.OptionsClipboard.PasteMode = DevExpress.Export.PasteMode.None;
            gv.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.AllowCsvFormat = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.AllowHtmlFormat = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.AllowRtfFormat = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.AllowTxtFormat = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsClipboard.ShowProgress = DevExpress.Export.ProgressMode.Automatic;
            //
            gv.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.True;
            gv.OptionsMenu.ShowAutoFilterRowItem = true;
            gv.OptionsMenu.ShowConditionalFormattingItem = true;
            gv.OptionsMenu.ShowDateTimeGroupIntervalItems = true;
            gv.OptionsMenu.ShowFooterItem = true;
            gv.OptionsMenu.ShowGroupSortSummaryItems = true;
            gv.OptionsMenu.ShowGroupSummaryEditorItem = true;
            gv.OptionsMenu.ShowSplitItem = true;
            //
            gv.OptionsView.ShowFooter = true;
            gv.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            gv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            gv.OptionsSelection.MultiSelect = true;
            //
            gv.Columns[ MetadataItemFQN.METADATA_PROVIDER_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.SYNTAX_PROVIDER_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.IS_SYSTEM_FIELDNAME ].Visible = false;
            //
            gv.Columns[ MetadataItemFQN.CARDINALYTY_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.FIELDSCOUNT_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.FIELDS_FIELDNAME ].Visible = false;
            //
            gv.Columns[ MetadataItemFQN.REFERENCED_CARDINALYTY_NAME_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.REFERENCED_OBJECT_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.REFERENCED_OBJECT_NAME_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.REFERENCED_FIELDS_COUNT_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.REFERENCED_FIELDS_FIELDNAME ].Visible = false;
            //
            gv.Columns[ MetadataItemFQN.REFERENCED_OBJECT_NAME_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.SERVER_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.DATABASE_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.SCHEMA_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.OBJECT_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.NAMEQUOTED_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.ALTNAME_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.FIELD_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.EXPRESSION_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.FIELD_TYPE_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.IS_PK_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.IS_READONLY_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.DESCRIPTION_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.TAG_FIELDNAME ].Visible = false;
            gv.Columns[ MetadataItemFQN.USERDATA_FIELDNAME ].Visible = false;
            //
            gv.Columns[ MetadataItemFQN.FIELD_FIELDNAME ].Caption = MetadataItemFQN.FIELD_DISPLAYNAME;
            //
            gv.Columns[ MetadataItemFQN.CARDINALYTY_FIELDNAME ].Caption = MetadataItemFQN.CARDINALYTY_DISPLAYNAME;
            gv.Columns[ MetadataItemFQN.FIELDSCOUNT_FIELDNAME ].Caption = MetadataItemFQN.FIELDSCOUNT_DISPLAYNAME;
            gv.Columns[ MetadataItemFQN.FIELDS_FIELDNAME ].Caption = MetadataItemFQN.FIELDS_DISPLAYNAME;
            //
            gv.Columns[ MetadataItemFQN.REFERENCED_CARDINALYTY_NAME_FIELDNAME ].Caption = MetadataItemFQN.REFERENCED_CARDINALYTY_NAME_DISPLAYNAME;
            gv.Columns[ MetadataItemFQN.REFERENCED_OBJECT_FIELDNAME ].Caption = MetadataItemFQN.REFERENCED_OBJECT_DISPLAYNAME;
            gv.Columns[ MetadataItemFQN.REFERENCED_OBJECT_NAME_FIELDNAME ].Caption = MetadataItemFQN.REFERENCED_OBJECT_NAME_DISPLAYNAME;
            gv.Columns[ MetadataItemFQN.REFERENCED_FIELDS_COUNT_FIELDNAME ].Caption = MetadataItemFQN.REFERENCED_FIELDS_COUNT_DISPLAYNAME;
            gv.Columns[ MetadataItemFQN.REFERENCED_FIELDS_FIELDNAME ].Caption = MetadataItemFQN.REFERENCED_FIELDS_DISPLAYNAME;
            //
            gv.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler( gridView1_RowCellStyle );
            gv.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler( gridView1_CustomDrawCell );
         }
         ((System.ComponentModel.ISupportInitialize) (gc)).EndInit( );
         ((System.ComponentModel.ISupportInitialize) (gv)).EndInit( );
         // gv.ShowEditForm( );
         // gv.HideEditForm( );
         gv.HideLoadingPanel( );
         {
            //DevExpress.XtraPrinting.CsvExportOptions o = new DevExpress.XtraPrinting.CsvExportOptions( ",", System.Text.Encoding.UTF8, DevExpress.XtraPrinting.TextExportMode.Value, true, false );
            //gc.ExportToCsv( "", o );
         }
         //         CustomDrawEmptyForeground( gc, gv );
      }

      private static void TpCtlr_BeforeShow( object sender, DevExpress.Utils.ToolTipControllerShowEventArgs e )
      {
         // Create and customize a SuperToolTip: 
         DevExpress.Utils.SuperToolTip stp = new DevExpress.Utils.SuperToolTip( );
         DevExpress.Utils.SuperToolTipSetupArgs args = new DevExpress.Utils.SuperToolTipSetupArgs( );
         args.Title.Text = "Header";
         args.Contents.Text = "This tooltip contains a hyperlink. Visit the <href=http://help.devexpress.com>DevExpress Knowledge Center</href> to learn more.";
         args.ShowFooterSeparator = true;
         args.Footer.Text = "Footer";
         stp.Setup( args );
         // Enable HTML Text Formatting for the created SuperToolTip: 
         stp.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;

         e.SuperTip = stp;
      }

      private static void TpCtlr_GetActiveObjectInfo( object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e )
      {
         //DevExpress.Utils.ToolTipControlInfo info = null;
         ////         // Create and customize a SuperToolTip: 
         //DevExpress.Utils.SuperToolTip stp = new DevExpress.Utils.SuperToolTip( );
         //DevExpress.Utils.SuperToolTipSetupArgs args = new DevExpress.Utils.SuperToolTipSetupArgs( );
         //args.Title.Text = "Header";
         //args.Contents.Text = "This tooltip contains a hyperlink. Visit the <href=http://help.devexpress.com>DevExpress Knowledge Center</href> to learn more.";
         //args.ShowFooterSeparator = true;
         //args.Footer.Text = "Footer";
         //stp.Setup( args );
         //// Enable HTML Text Formatting for the created SuperToolTip: 
         //stp.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
         //info.SuperTip = stp;
         //////////
         //         if( e.SelectedControl != gridControl1 ) return;
         //         DevExpress.Utils.ToolTipControlInfo info = null;
         //         //Get the view at the current mouse position 
         //         DevExpress.XtraGrid.Views.Grid.GridView view = gridControl1.GetViewAt( e.ControlMousePosition ) as DevExpress.XtraGrid.Views.Grid.GridView;
         //         if( view == null ) return;
         //         //Get the view's element information that resides at the current position 
         //         DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = view.CalcHitInfo( e.ControlMousePosition );
         //         //Display a hint for row indicator cells 
         //         if( hi.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowIndicator )
         //         {
         //            //An object that uniquely identifies a row indicator cell 
         //            object o = hi.HitTest.ToString( ) + hi.RowHandle.ToString( );
         //            string text = "Row " + hi.RowHandle.ToString( );
         //            info = new DevExpress.Utils.ToolTipControlInfo( o, text );
         //         }
         //         //Supply tooltip information if applicable, otherwise preserve default tooltip (if any) 
         //         if( info != null )
         //            e.Info = info;
      }

      private static void tooltipController_HyperlinkClick( object sender, DevExpress.Utils.HyperlinkClickEventArgs e )
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

      private static void gridView1_RowCellStyle( object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e )
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
      private static void gridView1_CustomDrawCell( object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e )
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
               if( e.CellValue.ToString( ) == "Field" )
               {
                  info.ContextImage = fld_noaction_gray_img;
                  info.CalcViewInfo( );
                  return;
               }
               else if( e.CellValue.ToString( ) == "Table" )
               {
                  info.ContextImage = tbl_noaction_red_img;
                  info.CalcViewInfo( );
                  return;
               }
               else if( e.CellValue.ToString( ) == "View" )
               {
                  info.ContextImage = vw_noaction_red_img;
                  info.CalcViewInfo( );
                  return;
               }
               if( e.CellValue.ToString( ) == "ForeignKey" )
               {
                  info.ContextImage = fk_noaction_gray_img;
                  info.CalcViewInfo( );
                  return;
               }
               if( e.CellValue.ToString( ) == "Procedure" )
               {
                  info.ContextImage = proc_noaction_blue_img;
                  info.CalcViewInfo( );
                  return;
               }
               else if( e.CellValue.ToString( ) == "Synonym" )
               {
                  info.ContextImage = syn_noaction_yellow_img;
                  info.CalcViewInfo( );
                  return;
               }
               else if( e.CellValue.ToString( ) == "Schema" )
               {
                  info.ContextImage = sch_noaction_red_img;
                  info.CalcViewInfo( );
                  return;
               }
               else if( e.CellValue.ToString( ) == "Database" )
               {
                  info.ContextImage = db_noaction_red_img;
                  info.CalcViewInfo( );
                  return;
               }
               return;
            }
         }
      }

      private static void CustomDrawEmptyForeground( DevExpress.XtraGrid.GridControl gridControl, DevExpress.XtraGrid.Views.Grid.GridView gridView )
      {
         string searchName = string.Empty;
         //         gridView.ActiveFilterCriteria = new DevExpress.Data.Filtering.BinaryOperator( "Category_Name", searchName );

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
         gridView.CustomDrawEmptyForeground += ( s, e ) =>
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

         gridView.MouseMove += ( s, e ) =>
         {
            trySearchingAgainBoundsContainCursor = trySearchingAgainBounds.Contains( e.Location );
            gridControl.Cursor = trySearchingAgainBoundsContainCursor ? System.Windows.Forms.Cursors.Hand : System.Windows.Forms.Cursors.Default;
            gridView.InvalidateRect( trySearchingAgainBounds );
         };

         gridView.MouseDown += ( s, e ) =>
         {
            if( trySearchingAgainBoundsContainCursor )
            {
               searchName = DevExpress.XtraEditors.XtraInputBox.Show( string.Format( "Enter {0}", "Name" ), string.Format( "Enter {0} dialog", "Name" ), searchName );
               //               gridView.ActiveFilterCriteria = new DevExpress.Data.Filtering.BinaryOperator( "Category_Name", searchName );
            }
         };
      }

      public static void SerializeQueryBuilder(
         ActiveQueryBuilder.View.WinForms.QueryBuilder qb,
         string filename
         )
      {
         {
            string xML = qb.MetadataContainer.XML;
         }
         {
            qb.MetadataContainer.ExportToXML( filename );
         }
         //{
         //   qb.MetadataContainer.ImportFromXML( filename );
         //}
      }

      #region --- MSSQL... ---
      public static ActiveQueryBuilder.View.WinForms.QueryBuilder CreateQueryBuilderMSSQL(
         string connectionString,
         bool loadDefaultDatabaseOnly,
         bool loadSystemObjects,
         bool withFields
      )
      {
         ActiveQueryBuilder.View.WinForms.QueryBuilder qb = new ActiveQueryBuilder.View.WinForms.QueryBuilder( )
         {
            SyntaxProvider = new ActiveQueryBuilder.Core.MSSQLSyntaxProvider( ),
            MetadataProvider = new ActiveQueryBuilder.Core.MSSQLMetadataProvider( )
         };
         qb.MetadataProvider.Connection = new System.Data.SqlClient.SqlConnection( connectionString );
         {
            ActiveQueryBuilder.Core.MetadataLoadingOptions loadingOptions = qb.SQLContext.MetadataContainer.LoadingOptions;
            loadingOptions.LoadDefaultDatabaseOnly = loadDefaultDatabaseOnly;
            loadingOptions.LoadSystemObjects = loadSystemObjects;
            //loadingOptions.IncludeFilter.Types = MetadataType.Field;
            //loadingOptions.ExcludeFilter.Schemas.Add("dbo");
         }
         //qb.InitializeDatabaseSchemaTree();
         //qb.MetadataContainer.LoadAll(withFields);
         return qb;
      } // createQueryBuilder(...)
      #endregion

      #region --- SQLite... ---
      public static ActiveQueryBuilder.View.WinForms.QueryBuilder CreateQueryBuilderSQLite(
         string connectionString,
         bool loadDefaultDatabaseOnly,
         bool loadSystemObjects,
         bool withFields
      )
      {
         ActiveQueryBuilder.View.WinForms.QueryBuilder qb = new ActiveQueryBuilder.View.WinForms.QueryBuilder( )
         {
            SyntaxProvider = new ActiveQueryBuilder.Core.SQLiteSyntaxProvider( ),
            MetadataProvider = new ActiveQueryBuilder.Core.SQLiteMetadataProvider( )
         };
         qb.MetadataProvider.Connection = new System.Data.SQLite.SQLiteConnection( connectionString );
         {
            ActiveQueryBuilder.Core.MetadataLoadingOptions loadingOptions = qb.SQLContext.MetadataContainer.LoadingOptions;
            loadingOptions.LoadDefaultDatabaseOnly = loadDefaultDatabaseOnly;
            loadingOptions.LoadSystemObjects = loadSystemObjects;
            //loadingOptions.IncludeFilter.Types = MetadataType.Field;
            //loadingOptions.ExcludeFilter.Schemas.Add("dbo");
         }
         qb.InitializeDatabaseSchemaTree( );
         qb.MetadataContainer.LoadAll( withFields );
         return qb;
      } // createQueryBuilder(...)
      #endregion

      public static System.ComponentModel.BindingList<MetadataItemFQN> BuildBindingList(
         ActiveQueryBuilder.View.WinForms.QueryBuilder qb
         )
      {
         System.ComponentModel.BindingList<MetadataItemFQN> list = new System.ComponentModel.BindingList<MetadataItemFQN>( );
         using( var sqlContext = new ActiveQueryBuilder.Core.SQLContext( ) )
         {
            sqlContext.Assign( qb.SQLContext );
            //sqlContext.MetadataContainer.LoadingOptions.LoadDefaultDatabaseOnly = false;
            //sqlContext.MetadataContainer.LoadingOptions.LoadSystemObjects = false;

            using( ActiveQueryBuilder.Core.MetadataList miList = new ActiveQueryBuilder.Core.MetadataList( sqlContext.MetadataContainer ) )
            {
               miList.Load( ActiveQueryBuilder.Core.MetadataType.All, true );
               System.Collections.Generic.Stack<StackItem> stack = new System.Collections.Generic.Stack<StackItem>( );
               stack.Push( new StackItem { list = miList, index = 0, parentID = -1, grandParentID = -1 } );
               do
               {
                  StackItem si = stack.Pop( );
                  ActiveQueryBuilder.Core.MetadataList actualMIList = si.list;
                  int actualIndex = si.index;
                  int actualParentID = si.grandParentID; // IMPORTANT!!!
                  {
                     for( ; actualIndex < actualMIList.Count; actualIndex++ )
                     {
                        ExtractMetadataItem( list, actualMIList[ actualIndex ], actualParentID );
                        if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                        {
                           // Push the "next" Item...
                           stack.Push( new StackItem
                           {
                              list = actualMIList,
                              index = actualIndex + 1,
                              parentID = list[ list.Count - 1 ].ID,
                              grandParentID = actualParentID
                           } );
                           // Reset the loop to process the "actual" Item...
                           actualParentID = list[ list.Count - 1 ].ID;
                           actualMIList = actualMIList[ actualIndex ].Items;
                           actualIndex = -1;
                        }
                     } // for(;;)...
                  }
               } while( stack.Count > 0 );
            } // using()...
         } // using()...
         return list;
      } // buildBindingList(...)

      private static void ExtractMetadataItem(
         System.ComponentModel.BindingList<MetadataItemFQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         switch( mi.Type )
         {
            case ActiveQueryBuilder.Core.MetadataType.Root:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Server:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Database:
               ExtractNamespace( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Schema:
               ExtractNamespace( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Package:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Namespaces:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Table:
               ExtractTable( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.View:
               ExtractTable( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Procedure:
               ExtractProcedure( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Synonym:
               ExtractSynonym( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Objects:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Aggregate:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Parameter:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.Field:
               ExtractField( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.ForeignKey:
               ExtractForeignKey( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.ObjectMetadata:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.UserQuery:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.UserField:
               ExtractItem( list, mi, parentID );
               break;
            case ActiveQueryBuilder.Core.MetadataType.All:
               ExtractItem( list, mi, parentID );
               break;
            default:
               ExtractItem( list, mi, parentID );
               break;
         } // switch()...
      }
      private static void ExtractProcedure(
         System.ComponentModel.BindingList<MetadataItemFQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
         }
      }
      private static void ExtractSynonym(
         System.ComponentModel.BindingList<MetadataItemFQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
            o.ReferencedObject = m.ReferencedObject?.NameFull;
            //
            for( int i = 0; i < m.ReferencedObjectName.Count; i++ )
            {
               ActiveQueryBuilder.Core.MetadataQualifiedNamePart x = m.ReferencedObjectName[ i ];
               o.ReferencedObjectName += "["
               + System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), x.Type )
               + ":"
               + x.Name
               + "]"
            ;
            }
         }
      }
      private static void ExtractNamespace(
         System.ComponentModel.BindingList<MetadataItemFQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataNamespace m = mi as ActiveQueryBuilder.Core.MetadataNamespace;
         }
      }
      private static void ExtractTable(
         System.ComponentModel.BindingList<MetadataItemFQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataObject m = mi as ActiveQueryBuilder.Core.MetadataObject;
         }
      }
      private static void ExtractForeignKey(
         System.ComponentModel.BindingList<MetadataItemFQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         o.FieldType = null;
         {
            ActiveQueryBuilder.Core.MetadataForeignKey m = mi as ActiveQueryBuilder.Core.MetadataForeignKey;
            o.ReferencedObject = m.ReferencedObject.NameFull;
            //
            for( int i = 0; i < m.ReferencedObjectName.Count; i++ )
            {
               ActiveQueryBuilder.Core.MetadataQualifiedNamePart x = m.ReferencedObjectName[ i ];
               o.ReferencedObjectName += "["
               + System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), x.Type )
               + ":"
               + x.Name
               + "]"
            ;
            }
            //
            o.ReferencedFieldsCount = m.ReferencedFields.Count;
            for( int i = 0; i < m.ReferencedFields.Count; i++ )
            {
               o.ReferencedFields += "[" + m.ReferencedFields[ i ] + "]"
            ;
            }
            //
            o.ReferencedCardinality = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataForeignKeyCardinality ), m.ReferencedCardinality );
            //
            o.FieldsCount = m.Fields.Count;
            for( int i = 0; i < m.Fields.Count; i++ )
            {
               o.Fields += "[" + m.Fields[ i ] + "]"
            ;
            }
            //
            o.Cardinality = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataForeignKeyCardinality ), m.Cardinality );
         }
      }
      private static void ExtractField(
         System.ComponentModel.BindingList<MetadataItemFQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         if( mi == null ) return;
         var o = ExtractItem( list, mi, parentID );
         {
            ActiveQueryBuilder.Core.MetadataField m = mi as ActiveQueryBuilder.Core.MetadataField;
            o.Expression = m.Expression;
            o.FieldType = System.Enum.GetName( typeof( System.Data.DbType ), m.FieldType );
            o.FieldTypeName = m.FieldTypeName;
            o.IsNullable = m.Nullable;
            o.Precision = m.Precision;
            o.Scale = m.Scale;
            o.Size = m.Size;
            o.IsPK = m.PrimaryKey;
            o.IsRO = m.ReadOnly;
         }
      }
      private static MetadataItemFQN ExtractItem(
         System.ComponentModel.BindingList<MetadataItemFQN> list,
         ActiveQueryBuilder.Core.MetadataItem mi,
         int parentID
         )
      {
         var o = new MetadataItemFQN( );
         {
            o.MetadataProvider = mi.SQLContext?.MetadataProvider.Description;
            o.SyntaxProvider = mi.SQLContext?.SyntaxProvider.Description;
            o.ID = list.Count;
            o.ParentID = parentID;
            if( mi.Parent != null )
            {
               o.ParentType = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), mi.Parent.Type );
            }
            o.Type = System.Enum.GetName( typeof( ActiveQueryBuilder.Core.MetadataType ), mi.Type );
            o.IsSystem = mi.System;
            //
            // o.RootName = item.Root?.Name;
            o.Server = mi.Server?.Name;
            o.Database = mi.Database?.Name;
            o.Schema = mi.Schema?.Name;
            o.ObjectName = mi.Object?.Name;
            //
            o.NameFullQualified = mi.NameFull;
            o.NameFullQualified += mi.NameFull.EndsWith( "." ) ? "<?>" : "";
            o.NameQuoted = mi.NameQuoted;
            o.AltName = mi.AltName;
            o.Field = mi.Name != null ? mi.Name : "<?>";
            //
            //
            o.HasDefault = mi.Default;
            o.Description = mi.Description;
            o.Tag = mi.Tag;
            o.UserData = mi.UserData;
         }
         list.Add( o );
         return o;
      }
   }
}

/*

            /*
      //
      // Summary:
      //     Gets an encoding for the UTF-7 format.
      //
      // Returns:
      //     An encoding for the UTF-7 format.
      public static Encoding UTF7 { get; }
      //
      // Summary:
      //     Gets an encoding for the UTF-16 format that uses the big endian byte order.
      //
      // Returns:
      //     An encoding object for the UTF-16 format that uses the big endian byte order.
      public static Encoding BigEndianUnicode { get; }
      //
      // Summary:
      //     Gets an encoding for the UTF-16 format using the little endian byte order.
      //
      // Returns:
      //     An encoding for the UTF-16 format using the little endian byte order.
      public static Encoding Unicode { get; }
      //
      // Summary:
      //     Gets an encoding for the operating system's current ANSI code page.
      //
      // Returns:
      //     An encoding for the operating system's current ANSI code page.
      public static Encoding Default { get; }
      //
      // Summary:
      //     Gets an encoding for the ASCII (7-bit) character set.
      //
      // Returns:
      //     An encoding for the ASCII (7-bit) character set.
      public static Encoding ASCII { get; }
      //
      // Summary:
      //     Gets an encoding for the UTF-8 format.
      //
      // Returns:
      //     An encoding for the UTF-8 format.
      public static Encoding UTF8 { get; }
      //
      // Summary:
      //     Gets an encoding for the UTF-32 format using the little endian byte order.
      //
      // Returns:
      //     An encoding object for the UTF-32 format using the little endian byte order.
      public static Encoding UTF32 { get; }


            ;

public static BindingList<ColumnQN> buildBindingListMSSQL( ActiveQueryBuilder.View.WinForms.QueryBuilder qb )
      {
         BindingList<ColumnQN> listDataSource = new BindingList<ColumnQN>( );
         using( var sqlContext = new SQLContext( ) )
         {
            sqlContext.Assign( qb.SQLContext );
            //sqlContext.MetadataContainer.LoadingOptions.LoadDefaultDatabaseOnly = false;
            //sqlContext.MetadataContainer.LoadingOptions.LoadSystemObjects = false;

            using( var databasesList = new MetadataList( sqlContext.MetadataContainer ) )
            {
               databasesList.Load( MetadataType.Database, false );
               foreach( var db in databasesList )
               {
                  using( var schemasList = new MetadataList( db ) )
                  {
                     schemasList.Load( MetadataType.Schema, false );
                     foreach( var sch in schemasList )
                     {
                        using( var tablesList = new MetadataList( sch ) )
                        {
                           tablesList.Load( MetadataType.Table, false );
                           foreach( var tbl in tablesList )
                           {
                              using( var columnsList = new MetadataList( tbl ) )
                              {
                                 columnsList.Load( MetadataType.Field, false );
                                 foreach( var col in columnsList )
                                 {
                                    var colQN = new ColumnQN( db.Name, sch.Name, tbl.Name, col.Name );
                                    listDataSource.Add( colQN );
                                 }
                              }
                           }
                        }
                     }
                  }
               }
            }
         }
         return listDataSource;
      } // buildBindingList(...)

      public static BindingList<ColumnQN> buildBindingListSQLite( ActiveQueryBuilder.View.WinForms.QueryBuilder qb )
      {
         BindingList<ColumnQN> listDataSource = new BindingList<ColumnQN>( );
         using( var sqlContext = new SQLContext( ) )
         {
            sqlContext.Assign( qb.SQLContext );
            //sqlContext.MetadataContainer.LoadingOptions.LoadDefaultDatabaseOnly = false;
            //sqlContext.MetadataContainer.LoadingOptions.LoadSystemObjects = false;

            using( var databasesList = new MetadataList( sqlContext.MetadataContainer ) )
            {
               databasesList.Load( MetadataType.Database, false );
               foreach( var db in databasesList )
               {
                  //using( var schemasList = new MetadataList( db ) )
                  {
                     //schemasList.Load( MetadataType.Schema, false );
                     //foreach( var sch in schemasList )
                     {
                        //using( var tablesList = new MetadataList( sch ) )
                        using( var tablesList = new MetadataList( db ) )
                        {
                           tablesList.Load( MetadataType.Table, false );
                           foreach( var tbl in tablesList )
                           {
                              using( var columnsList = new MetadataList( tbl ) )
                              {
                                 columnsList.Load( MetadataType.Field, false );
                                 foreach( var col in columnsList )
                                 {
                                    //var colQN = new ColumnQN( db.Name, sch.Name, tbl.Name, col.Name );
                                    var colQN = new ColumnQN( db.Name, null, tbl.Name, col.Name );
                                    listDataSource.Add( colQN );
                                 }
                              }
                           }
                        }
                     }
                  }
               }
            }
         }
         return listDataSource;
      } // buildBindingList(...)

      public static BindingList<ColumnQN> buildBindingListSQLiteField( ActiveQueryBuilder.View.WinForms.QueryBuilder qb )
      {
         BindingList<ColumnQN> listDataSource = new BindingList<ColumnQN>( );
         using( var sqlContext = new SQLContext( ) )
         {
            sqlContext.Assign( qb.SQLContext );
            //sqlContext.MetadataContainer.LoadingOptions.LoadDefaultDatabaseOnly = false;
            //sqlContext.MetadataContainer.LoadingOptions.LoadSystemObjects = false;

            using( MetadataList miList = new MetadataList( sqlContext.MetadataContainer ) )
            {
               miList.Load( MetadataType.All, true );
               Stack<StackItem> a = new Stack<StackItem>( );
               a.Push( new StackItem { list = miList, index = 0 } );
               do
               {
                  StackItem si = a.Pop( );
                  MetadataList actualMIList = si.list;
                  int actualIndex = si.index;
                  for( ; actualIndex < actualMIList.Count; actualIndex++ )
                  {
                     switch( actualMIList[ actualIndex ].Type )
                     {
                        case MetadataType.Root:
                           break;
                        case MetadataType.Server:
                           break;
                        case MetadataType.Database:
                           ExtractItem( listDataSource, actualMIList[ actualIndex ] );
                           if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                           {
                              a.Push( new StackItem { list = actualMIList, index = actualIndex + 1 } );
                              actualMIList = actualMIList[ actualIndex ].Items;
                              actualIndex = -1;
                           }
                           break;
                        case MetadataType.Schema:
                           break;
                        case MetadataType.Package:
                           break;
                        case MetadataType.Namespaces:
                           break;
                        case MetadataType.Table:
                           ExtractTable( listDataSource, actualMIList[ actualIndex ] );
                           if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                           {
                              a.Push( new StackItem { list = actualMIList, index = actualIndex + 1 } );
                              actualMIList = actualMIList[ actualIndex ].Items;
                              actualIndex = -1;
                           }
                           //a.Push( new StackItem { list = actualMIList, index = actualIndex + 1 } );
                           //actualMIList = actualMIList[ actualIndex ].Items;
                           //actualIndex = -1;
                           break;
                        case MetadataType.View:
                           break;
                        case MetadataType.Procedure:
                           break;
                        case MetadataType.Synonym:
                           break;
                        case MetadataType.Objects:
                           break;
                        case MetadataType.Aggregate:
                           break;
                        case MetadataType.Parameter:
                           break;
                        case MetadataType.Field:
                           ExtractField( listDataSource, actualMIList[ actualIndex ] );
                           if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                           {
                              a.Push( new StackItem { list = actualMIList, index = actualIndex + 1 } );
                              actualMIList = actualMIList[ actualIndex ].Items;
                              actualIndex = -1;
                           }
                           break;
                        case MetadataType.ForeignKey:
                           ExtractForeignKey( listDataSource, actualMIList[ actualIndex ] );
                           if( actualMIList[ actualIndex ].Items.Count > 0 ) // branch...
                           {
                              a.Push( new StackItem { list = actualMIList, index = actualIndex + 1 } );
                              actualMIList = actualMIList[ actualIndex ].Items;
                              actualIndex = -1;
                           }
                           break;
                        case MetadataType.ObjectMetadata:
                           break;
                        case MetadataType.UserQuery:
                           break;
                        case MetadataType.UserField:
                           break;
                        case MetadataType.All:
                           break;
                        default:
                           break;
                     } // switch()...
                  } // for(;;)...
               } while( a.Count > 0 );
            } // using()...
         } // using()...
         return listDataSource;
      } // buildBindingList(...)


*/
