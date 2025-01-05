using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

// Refection
using System.Reflection;
using System.Runtime.InteropServices;

// printing
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Printing;

namespace FileInfo
{
    /// <summary>
    /// A collection of ListView helper functions such as:
    ///     Export
    ///     Reflection
    ///     Remove, Find and AnyItem
    ///     Print 
    /// 
    /// Author: Dennis Lang 2009
    /// https://landenlabs.com/
    /// 
    /// </summary>
    class ListViewExt
    {
        /// <summary>
        /// Export ListView as CSV
        /// </summary>
        /// <param name="listView">ListView to export</param>
        /// <returns>Filename if okay, else empty string on error</returns>
        static public string Export(ListView listView)
        {
            if (listView == null || listView.Items.Count == 0)
                return string.Empty;

            SaveFileDialog exportFileDialog = new SaveFileDialog();
            exportFileDialog.DefaultExt = "csv";
            exportFileDialog.Filter = "CSV|*.csv|Any|*.*";
            exportFileDialog.Title = "Export List";

            if (exportFileDialog.ShowDialog() == DialogResult.OK)
            {
                String filePath = exportFileDialog.FileName;
                TextWriter writer = new StreamWriter(filePath);

                string txtLine = string.Empty;
                foreach (ColumnHeader ch in listView.Columns)
                {
                    if (txtLine.Length != 0)
                        txtLine += ",";
                    txtLine += ch.Text + " ";
                }
                writer.WriteLine(txtLine);

                foreach (ListViewItem item in listView.Items)
                {
                    txtLine = string.Empty;
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        if (txtLine.Length != 0)
                            txtLine += ",";
                        txtLine += subItem.Text.Replace(',', ';');
                        txtLine += " "; // add space incase blank fields
                    }

                    writer.WriteLine(txtLine);
                }

                writer.Close();

                return filePath;
            }

            return string.Empty;
        }

        /// <summary>
        /// Add elements of dictionary to listview.
        /// </summary>
        /// <param name="dict">input dictionary</param>
        /// <param name="listView">view to add to </param>
        /// <param name="f0">first column value</param>
        /// <param name="bgColor">background color</param>
        /// <returns></returns>
        public static int AddToList(Dictionary<string, object> dict, ListView listView, string f0, Color bgColor)
        {
            int addCnt = 0;
            foreach (string key in dict.Keys)
            {
                object val = dict[key];
                if (val != null)
                {
                    ListViewItem item = listView.Items.Add(f0);
                    item.BackColor = bgColor;
                    addCnt++;

                    item.SubItems.Add(key.ToString());
                    item.SubItems.Add(val.ToString());
                    item.SubItems.Add(string.Empty);
                    item.SubItems.Add(val.ToString());
                }
            }

            return addCnt;
        }

        /// <summary>
        /// Update listView, column 0=f0, 1=name, 2=orgValue, 3=change, 4=nowValue
        /// </summary>
        /// <param name="dict">Input dictionary</param>
        /// <param name="listView">list to update</param>
        /// <param name="f0">first column, used to find match</param>
        /// <param name="bgColor">background color (not used)</param>
        /// <returns></returns>
        public static int UpdList(Dictionary<string, object> dict, ListView listView, string f0, Color bgColor)
        {
            int updCnt = 0;
            foreach (string key in dict.Keys)
            {
                ListViewItem item = ListViewExt.FindItem(f0, key.ToString(), listView);

                object val = dict[key];
                string valStr = val.ToString();
                item.SubItems[4].Text = valStr;

                if (val != null)
                {
                    updCnt++;

                    if (val is UInt16)
                    {
                        int chg = (int)(UInt16)val - int.Parse(item.SubItems[2].Text);
                        item.SubItems[3].Text = chg.ToString();
                    }
                    else if (val is UInt32)
                    {
                        long chg = (long)(UInt32)val - long.Parse(item.SubItems[2].Text);
                        item.SubItems[3].Text = chg.ToString();
                    }
                    else
                    {
                        // unsupported type
                    }
                }
            }

            return updCnt;
        }

        /// <summary>
        /// Use reflection to extract info from object and add to listView
        /// Column 0=f0, 1=objName, 2=objValue, 3=empty, 4=empty or objValue
        /// </summary>
        /// <param name="obj">obj to reflect</param>
        /// <param name="chgColumn">true updates column 4</param>
        /// <param name="listView">List to populate</param>
        /// <param name="f0">first column value</param>
        /// <param name="bgColor">background color</param>
        /// <returns># objects added</returns>
        public static int ReflectToList(object obj, bool chgColumn, ListView listView, string f0, Color bgColor)
        {
            int addCnt = 0;
            Type objectType = obj.GetType();
            PropertyInfo[] props = objectType.GetProperties();
            foreach (PropertyInfo pinfo in props)
            {
                ListViewItem item = listView.Items.Add(f0);
                item.SubItems.Add(pinfo.Name);

                try
                {
                    object objValue = pinfo.GetValue(obj, null);
                    if (objValue != null && objValue.GetType().IsNestedPublic)
                    {
                        addCnt += ReflectToList(objValue, chgColumn, listView, f0 + "[]", bgColor);
                    }
                    else
                    {
                        string objValStr = objValue == null ? string.Empty : objValue.ToString();
                        item.SubItems.Add(objValStr);
                        item.SubItems.Add(string.Empty);
                        item.SubItems.Add(chgColumn ? objValStr : string.Empty);
                        item.BackColor = bgColor;
                        // SetStyle(item);
                        addCnt++;
                    }
                }
                catch
                {
                    listView.Items.Remove(item);
                }
            }

            FieldInfo[] fldInfoList = objectType.GetFields();
            foreach (FieldInfo fld in fldInfoList)
            {
                object fldObj = fld.GetValue(obj);
                if (fldObj != null)
                {
                    Type t = fldObj.GetType();
                    if (t.IsNestedPublic)
                    {
                        addCnt += ReflectToList(fldObj, chgColumn, listView, f0 + "[]", bgColor);
                    }
                    else
                    {
                        string fldStr = fldObj.ToString();

                        ListViewItem item = listView.Items.Add(f0);
                        item.SubItems.Add(fld.Name);
                        item.SubItems.Add(fldStr);
                        item.SubItems.Add(string.Empty);
                        item.SubItems.Add(chgColumn ? fldStr : string.Empty);
                        item.BackColor = bgColor;
                        // SetStyle(item);
                        addCnt++;
                    }
                }
            }

            return addCnt;
        }


        /// <summary>
        /// Use reflect to extract info from object, find match in listView and update change column and value.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="doUpd">true updates list, false removes items with f0 from list</param>
        /// <param name="listView">list to update</param>
        /// <param name="f0">first column value</param>
        /// <param name="bgColor">background color (not used)</param>
        public static  void ReflectUpdList(object obj, bool doUpd, ListView listView, string f0, Color bgColor)
        {
            if (doUpd)
            {
                Type objectType = obj.GetType();
                PropertyInfo[] props = objectType.GetProperties();
                foreach (PropertyInfo pinfo in props)
                {
                    ListViewItem item = ListViewExt.FindItem(f0, pinfo.Name, listView);
                    if (item != null)
                    {
                        try
                        {
                            object objValue = pinfo.GetValue(obj, null);

                            if (objValue != null && objValue.GetType().IsNestedPublic)
                            {
                                ReflectUpdList(objValue, true, listView, f0 + "[]", bgColor);
                            }
                            else
                            {
                                string typName = pinfo.PropertyType.Name;

                                if (typName == "Int32")
                                {
                                    Int32 o = Int32.Parse(item.SubItems[2].Text);
                                    Int32 n = (Int32)objValue;
                                    string str = (n - o).ToString();
                                    if (item.SubItems[3].Text != str)
                                        item.SubItems[3].Text = str;
                                }
                                else if (typName == "UInt32")
                                {
                                    UInt32 o = UInt32.Parse(item.SubItems[2].Text);
                                    UInt32 n = (UInt32)objValue;
                                    string str = (n - o).ToString();
                                    if (item.SubItems[3].Text != str)
                                        item.SubItems[3].Text = str;
                                }
                                else if (typName == "Int64")
                                {
                                    Int64 o = Int64.Parse(item.SubItems[2].Text);
                                    Int64 n = (Int64)objValue;
                                    string str = (n - o).ToString();
                                    if (item.SubItems[3].Text != str)
                                        item.SubItems[3].Text = str;
                                }
                                else
                                {
                                    // item.SubItems[3].Text = typName;
                                    // item.SubItems[3].Text = (pinfo.GetValue(obj, null).ToString());
                                }

                                string str4 = objValue.ToString();
                                if (item.SubItems.Count > 3 && item.SubItems[4].Text != str4)
                                    item.SubItems[4].Text = str4;
                                // SetStyle(item);
                            }
                        }
                        catch { }
                    }
                }

                FieldInfo[] fldInfoList = objectType.GetFields();
                foreach (FieldInfo fld in fldInfoList)
                {
                    object fldObj = fld.GetValue(obj);
                    if (fldObj != null)
                    {
                        Type t = fldObj.GetType();
                        if (t.IsNestedPublic)
                        {
                            ReflectUpdList(fldObj, true, listView, f0 + "[]", bgColor);
                        }
                        else
                        {
                            string fldStr = fldObj.ToString();

                            ListViewItem item = ListViewExt.FindItem(f0, fld.Name, listView);
                             if (item != null)
                             {
                                 // ListViewItem item = listView.Items.Add(f0);
                                 // item.SubItems[1].Text = (fld.Name);
                                 // item.SubItems[2].Text = fldStr;
                                 string typeName = fld.FieldType.Name;
                                 if (typeName == "Int32")
                                 {
                                     Int32 o = Int32.Parse(item.SubItems[2].Text);
                                     Int32 n = (Int32)fldObj;
                                     string str = (n - o).ToString();
                                     if (item.SubItems[3].Text != str)
                                         item.SubItems[3].Text = str;
                                 }
                                 else if (typeName == "UInt16")
                                 {
                                     UInt16 o = UInt16.Parse(item.SubItems[2].Text);
                                     UInt16 n = (UInt16)fldObj;
                                     string str = (n - o).ToString();
                                     if (item.SubItems[3].Text != str)
                                         item.SubItems[3].Text = str;
                                 }
                                 else if (typeName == "UInt32")
                                 {
                                     UInt32 o = UInt32.Parse(item.SubItems[2].Text);
                                     UInt32 n = (UInt32)fldObj;
                                     string str = (n - o).ToString();
                                     if (item.SubItems[3].Text != str)
                                         item.SubItems[3].Text = str;
                                 }
                                 else
                                 {
                                     item.SubItems[3].Text = typeName;
                                 }


                                 item.SubItems[4].Text = fldStr;    // latest
                                 item.BackColor = bgColor;
                                 // SetStyle(item);
                             }
                        }
                    }
                }


            }
            else
            {
                RemoveItems(f0, listView);
            }
        }

        /// <summary>
        /// Remove items which start with key.
        /// </summary>
        public static void RemoveItems(string key, ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Text.StartsWith(key))
                    listView.Items.Remove(item);
            }
        }

        /// <summary>
        /// Return true if any item starts with key.
        /// </summary>
        public static bool AnyItems(string key, ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Text.StartsWith(key))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Find item which starts with key and has f1 in column 1
        /// </summary>
        public static ListViewItem FindItem(string key, string f1, ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Text.StartsWith(key) && item.SubItems[1].Text == f1)
                    return item;
            }

            return null;
        }
    }


    //
    // Derived from work done by Author: Matteo D'Avena 
    // http://www.codeguru.com/csharp/csharp/cs_controls/custom/article.php/c10613/
    //

	public class PrintListView 
	{
		// Print fields
		private PrintDocument m_printDoc    = new PrintDocument();
        private PageSetupDialog m_setupDlg  = new PageSetupDialog();
        private PrintPreviewDialog m_previewDlg = new PrintPreviewDialog();
        private PrintDialog m_printDlg      = new PrintDialog();

		private int m_nPageNumber=1;
		private int m_nStartRow=0;
		private int m_nStartCol=0;

		private bool m_bPrintSel=false;
		private bool m_bFitToPage=false;

        private float m_fListWidth = 0.0f;
        private float m_fListHeight = 0.0f;
		private float[] m_arColsWidth;

        private float m_fDpiX;
        private float m_fDpiY;

        private ListView m_listView;
        private string m_title;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#region Properties
		/// <summary>
		///		Gets or sets whether to fit the list width on a single page
		/// </summary>
		/// <value>
		///		<c>True</c> if you want to scale the list width so it will fit on a single page.
		/// </value>
		/// <remarks>
		///		If you choose false (the default value), and the list width exceeds the page width, the list
		///		will be broken in multiple page.
		/// </remarks>
		public bool FitToPage
		{
			get {return m_bFitToPage;}
			set {m_bFitToPage=value;}
		}

		#endregion

		public PrintListView()
		{
            m_printDoc.DocumentName = "FileInfo";
            m_setupDlg.Document     = m_printDoc;
            m_previewDlg.Document   = m_printDoc;
            m_printDlg.Document     = m_printDoc;

            m_setupDlg.PageSettings.Landscape = false;
			m_printDoc.BeginPrint += new PrintEventHandler(OnBeginPrint);
			m_printDoc.PrintPage += new PrintPageEventHandler(OnPrintPage);
		}

		/// <summary>
		///		Show the standard page setup dialog box that lets the user specify
		///		margins, page orientation, page sources, and paper sizes.
		/// </summary>
		public void PageSetup()
		{
            m_setupDlg.ShowDialog();
		}

		/// <summary>
		///		Show the standard print preview dialog box.
		/// </summary>
		public DialogResult PrintPreview(IWin32Window owner, ListView listView, string title)
		{
            m_listView    = listView;
            m_title       = title;
			m_nPageNumber = 1;
			m_bPrintSel	  = false;
            m_bFitToPage  |= m_setupDlg.PageSettings.Landscape; // always fit width in landscape mode

            m_previewDlg.Width = m_setupDlg.PageSettings.Landscape ? 1000 : 600;
            m_previewDlg.Height = 600;

            return m_previewDlg.ShowDialog();
		}

		/// <summary>
		///		Start the print process.
		/// </summary>
        public void Print(IWin32Window owner, ListView listView, string title)
		{
            m_listView = listView;
            m_title = title;
            m_nPageNumber = 1;
            m_bPrintSel = false;
            m_bFitToPage |= m_setupDlg.PageSettings.Landscape;  // always fit width in landscape mode

            m_printDlg.UseEXDialog = true;
            m_printDlg.AllowSomePages = true;
            m_printDlg.AllowCurrentPage = true;
            m_printDlg.AllowPrintToFile = true;
            m_printDlg.ShowHelp = true;
            m_printDlg.ShowNetwork = true;
            m_printDlg.AllowSelection = false; //  m_listView.SelectedItems.Count > 0;

			// Show the standard print dialog box, that lets the user select a printer
			// and change the settings for that printer.
            if (m_printDlg.ShowDialog() == DialogResult.OK)
			{
                m_bPrintSel = (m_printDlg.PrinterSettings.PrintRange == PrintRange.Selection);
				m_nPageNumber = 1;

				// Start print
				m_printDoc.Print();
			}
		}

		#region Events Handlers
		private void OnBeginPrint(object sender, PrintEventArgs e)
		{
			PreparePrint();
		}

		private void OnPrintPage(object sender, PrintPageEventArgs e)
		{
			int nNumItems = GetItemsCount();  // Number of items to print

			if (nNumItems == 0 || m_nStartRow >= nNumItems)
			{
				e.HasMorePages = false;
				return;
			}

			int nNextStartCol = 0; 			  // First column exeeding the page width
			float x = 0.0f;					  // Current horizontal coordinate
			float y = 0.0f;					  // Current vertical coordinate
			float cx = 4.0f;                  // The horizontal space, in hundredths of an inch,
			                                  //   of the padding between items text and
			                                  //   their cell boundaries.
			float fScale = 1.0f;              // Scale factor when fit to page is enabled
			float fRowHeight = 0.0f;		  // The height of the current row
			float fColWidth  = 0.0f;		  // The width of the current column

			RectangleF rectFull;			  // The full available space
			RectangleF rectBody;			  // Area for the list items

			bool bUnprintable = false;

			Graphics g = e.Graphics;

			if (g.VisibleClipBounds.X < 0)	// Print preview
			{
				rectFull = e.MarginBounds;

				// Convert to hundredths of an inch
				rectFull = new RectangleF(rectFull.X/m_fDpiX *100.0f,
					    rectFull.Y/m_fDpiX *100.0f,
					    rectFull.Width/m_fDpiX *100.0f,
					    rectFull.Height/m_fDpiX *100.0f);
			}
			else  // Print
			{
				// Printable area (approximately) of the page, taking into account the user margins
				rectFull = new RectangleF(
					e.MarginBounds.Left - (e.PageBounds.Width  - g.VisibleClipBounds.Width)/2,
					e.MarginBounds.Top  - (e.PageBounds.Height - g.VisibleClipBounds.Height)/2,
					e.MarginBounds.Width,
					e.MarginBounds.Height);
			}


			// Display title at top
			StringFormat sfmt = new StringFormat();
			sfmt.Alignment = StringAlignment.Center;

            // Font hdrFont = new Font(m_listView.Font.FontFamily, m_listView.Font.SizeInPoints * 1.5f);
            Font hdrFont = new Font(m_listView.Font, FontStyle.Bold);
            g.DrawString(m_title, hdrFont, Brushes.Black, rectFull, sfmt);

			// Display page number at bottom
			sfmt.LineAlignment = StringAlignment.Far;
            string pageStr = string.Format("{0}    Page {1}",
                DateTime.Now.ToShortDateString(), m_nPageNumber);
			g.DrawString(pageStr, m_listView.Font, Brushes.Black, rectFull, sfmt);

            rectBody = RectangleF.Inflate(rectFull, 0, -4 * hdrFont.GetHeight(g));

			if (m_nStartCol==0 && m_bFitToPage &&
                (m_fListWidth > rectBody.Width || m_fListHeight > rectBody.Height))
			{
				// Calculate scale factor
                float fScaleWidth = rectBody.Width / m_fListWidth;
                float fScaleHeight = rectBody.Height / m_fListHeight;
                // fScale = Math.Min(fScaleWidth, fScaleHeight);
                fScale = fScaleWidth;
			}

			// Scale the printable area
			rectFull = new RectangleF(rectFull.X/fScale, 
			        rectFull.Y/fScale,
			        rectFull.Width/fScale, 
			        rectFull.Height/fScale);

			rectBody = new RectangleF(rectBody.X/fScale, 
                    rectBody.Y/fScale,
                    rectBody.Width/fScale, 
                    rectBody.Height/fScale);

			// Setting scale factor and unit of measure
			g.ScaleTransform(fScale, fScale);
			g.PageUnit = GraphicsUnit.Inch;
			g.PageScale = 0.01f;

			// Start print
			nNextStartCol=0;
			y = rectBody.Top;

			// ----- Columns headers -----
			Brush brushHeader = new SolidBrush(Color.LightGray);
			Font fontHeader = new Font(m_listView.Font, FontStyle.Bold);
			fRowHeight = fontHeader.GetHeight(g)*3.0f;
			x = rectBody.Left;

            for (int i = m_nStartCol; i < m_listView.Columns.Count; i++)
            {
                if (m_arColsWidth[i] >= rectBody.Width)
                    m_arColsWidth[i] = rectBody.Width - 1;
            }

            for (int i = m_nStartCol; i < m_listView.Columns.Count; i++)
			{
				ColumnHeader ch = m_listView.Columns[i];
				fColWidth = m_arColsWidth[i];

				if ( (x + fColWidth) <= rectBody.Right)
				{
					// Rectangle
					g.FillRectangle(brushHeader, x, y, fColWidth, fRowHeight);
					g.DrawRectangle(Pens.Black, x, y, fColWidth, fRowHeight);

					// Text
					StringFormat sf = new StringFormat();
					if (ch.TextAlign == HorizontalAlignment.Left)
						sf.Alignment = StringAlignment.Near;
					else if (ch.TextAlign == HorizontalAlignment.Center)
						sf.Alignment = StringAlignment.Center;
					else
						sf.Alignment = StringAlignment.Far;

					sf.LineAlignment = StringAlignment.Center;
					sf.FormatFlags = StringFormatFlags.NoWrap;
					sf.Trimming = StringTrimming.EllipsisCharacter;

					RectangleF rectText = new RectangleF(x+cx, y, fColWidth-1-2*cx, fRowHeight);
					g.DrawString(ch.Text, fontHeader, Brushes.Black, rectText, sf);
					x += fColWidth;
				}
				else
				{
					if (i==m_nStartCol)
						bUnprintable=true;

					nNextStartCol=i;
					break;
				}
			}
			y += fRowHeight;

			// ----- Rows ------
			int nRow = m_nStartRow;
			bool bEndOfPage = false;
			while (!bEndOfPage && nRow<nNumItems)
			{
				ListViewItem item = GetItem(nRow);

				fRowHeight = item.Bounds.Height/m_fDpiX *100.0f + 5.0f;

				if (y+fRowHeight>rectBody.Bottom)
				{
					bEndOfPage=true;
				}
				else
				{
					x = rectBody.Left;

					for (int i = m_nStartCol; i < m_listView.Columns.Count; i++)
					{
						ColumnHeader ch = m_listView.Columns[i];
						fColWidth = m_arColsWidth[i];

						if ( (x + fColWidth) <= rectBody.Right)
						{
							// Rectangle
							g.DrawRectangle(Pens.Black, x, y, fColWidth, fRowHeight);

							// Text
							StringFormat sf = new StringFormat();
							if (ch.TextAlign == HorizontalAlignment.Left)
								sf.Alignment = StringAlignment.Near;
							else if (ch.TextAlign == HorizontalAlignment.Center)
								sf.Alignment = StringAlignment.Center;
							else
								sf.Alignment = StringAlignment.Far;

							sf.LineAlignment = StringAlignment.Center;
							sf.FormatFlags = StringFormatFlags.NoWrap;
							sf.Trimming = StringTrimming.EllipsisCharacter;

							// Text
                            if (i < item.SubItems.Count)
                            {
							    string strText = item.SubItems[i].Text;
							    Font font = item.SubItems[0].Font;

							    RectangleF rectText = new RectangleF(x+cx, y, fColWidth-1-2*cx, fRowHeight);

                                // Brushes.Black
                                Brush brush = new SolidBrush(item.SubItems[0].ForeColor);
							    g.DrawString(strText, font, brush, rectText, sf);
                            }
							x += fColWidth;
						}
						else
						{
							nNextStartCol=i;
							break;
						}
					}

					y += fRowHeight;
					nRow++;
				}
			}

			if (nNextStartCol==0)
				m_nStartRow = nRow;

			m_nStartCol = nNextStartCol;

			m_nPageNumber++;

			e.HasMorePages = (!bUnprintable && (m_nStartRow > 0 && m_nStartRow < nNumItems) ||
                    m_nStartCol > 0);

			if (!e.HasMorePages)
			{
				m_nPageNumber=1;
				m_nStartRow=0;
				m_nStartCol=0;
			}

			brushHeader.Dispose();
		}
		#endregion

		private int GetItemsCount()
		{
			return m_bPrintSel ? m_listView.SelectedItems.Count : m_listView.Items.Count;
		}

		private ListViewItem GetItem(int index)
		{
			return m_bPrintSel ? m_listView.SelectedItems[index] : m_listView.Items[index];
		}

		private void PreparePrint()
		{
			// Gets the list width and the columns width in units of hundredths of an inch.
            this.m_fListWidth = 0.0f;
            this.m_fListHeight = 0.0f;
			this.m_arColsWidth = new float[m_listView.Columns.Count];

			Graphics g = m_listView.CreateGraphics();
            float fRowHeight = m_listView.Font.GetHeight(g) * 1.6f;  // row + separator
            m_fDpiX = g.DpiX;
            m_fDpiY = g.DpiY;
            g.Dispose();

            int itemHeight = (m_listView.Items.Count > 0) ?
                itemHeight = m_listView.Items[0].Bounds.Height : 20;

			for (int i=0; i < m_listView.Columns.Count; i++)
			{
				ColumnHeader ch = m_listView.Columns[i];
				float fWidth = ch.Width / m_fDpiX * 100 + 1; // Column width + separator
				m_fListWidth += fWidth;
				m_arColsWidth[i] = fWidth;
            }
            m_fListWidth += 1; // separator


            // Height is row height * (rows + header)
            m_fListHeight = fRowHeight * (m_listView.Items.Count + 1); 
		}

	}



}


