using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using AdvancedSiebelLogScanner.Properties;
using LiteDB;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

namespace AdvancedSiebelLogScanner
{

    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private ListViewColumnSorter lvwColumnSorter;
        string Notepad = Settings.Default.Notepad.ToString();
        string MongoInt = Settings.Default.MongoInt.ToString();
        public Form1()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listViewPerf.ListViewItemSorter = lvwColumnSorter;
            metroTextBox8.Text = Notepad;
            metroTabControl1.SelectTab("metroTabPage6");
            metroToggle1.Checked = (MongoInt == "True") ? true : false;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Siebel Log|*.log";
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            metroTextBox1.Text = filename;
            if (filename != "")
            {
                StreamReader logDetail = new StreamReader(filename);
                string logLine1 = logDetail.ReadLine();
                try
                {
                    int tab11 = idxofn(logLine1, ' ', 11);
                    int tab12 = idxofn(logLine1, ' ', 12);
                    int tab13 = idxofn(logLine1, ' ', 13);
                    int tab14 = idxofn(logLine1, ' ', 14);

                    metroTextBox2.Text = logLine1.Substring(checked(logLine1.IndexOf(" ")), 20).Trim();
                    metroTextBox3.Text = logLine1.Substring(idxofn(logLine1, ' ', 3), 20).Trim();
                    metroTextBox4.Text = logLine1.Substring(tab11, (tab12 - tab11)).Trim();
                    metroTextBox5.Text = logLine1.Substring(tab12, (tab13 - tab12)).Trim();
                    metroTextBox6.Text = logLine1.Substring(tab13, (tab14 - tab13)).Trim();
                    metroTextBox7.Text = logLine1.Substring(idxofn(logLine1, ' ', 16)).Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    logDetail = null;
                    logLine1 = null;
                }
            }
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text != "")
            {
            listViewError.Items.Clear();
            listViewEvtcxt.Items.Clear();
            listViewExecSQL.Items.Clear();
            listViewPerf.Items.Clear();
            listViewWF.Items.Clear();
            listViewTBUI.Items.Clear();
            LogAnalyze();
            }
        }
        public void LogAnalyze()
        {
            Application.UseWaitCursor = true;
            bool ValidLog = false;
            string filename = openFileDialog1.FileName;
            StreamReader sr = new StreamReader(filename);
            string str1 = sr.ReadLine();
            DateTime dateTime = new DateTime();
            int linecnt = 0;
            int linenbr = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            string str10 = "";
            string str11 = "";
            string str12 = "";
            string str13 = "";
            string str14 = "";
            string str15 = "";
            string str16 = "";
            string str17 = "";
            bool selectsql = false;
            bool isSQL = false;
            bool isBind = false;
            try
            {
            if (checked(str1.IndexOf(".log")) > 0)
            {
                ValidLog = true;
                linecnt = 1;
            }
            while ((str1 != null) && (ValidLog == true))
            {
                num1 = str1.IndexOf("\t");
                {
                    if (str1.IndexOf("Bind variable") > 0)
                    {
                        isSQL = false;
                        isBind = true;
                        str2 = str1.Substring(checked(str1.LastIndexOf(":") + 1)).Trim();
                        str4 = string.Concat(str4, str2, Environment.NewLine);
                    }
                    if (str1.IndexOf("SQL Statement") > 0 && isBind == true)
                    {
                        ListViewItem item = new ListViewItem(new[] { str3, str15, str6, str4, Convert.ToString(linenbr) });
                        listViewExecSQL.Items.Add(item);
                        str14 = str6;
                        isBind = false;
                        str6 = "";
                        str4 = "";
                        str3 = "";
                    }

                    if (isSQL)
                    {
                        if (str1.IndexOf("WHERE") > 0 && selectsql == true)
                        {
                            str15 = str6.Substring(checked(str6.LastIndexOf(".") + 1)).Trim();
                            str15 = str15.Substring(0, str15.IndexOf(" "));
                        }
                        str6 = string.Concat(str6, str1.TrimEnd(new char[0]), Environment.NewLine); //reads sql
                        if (str1.IndexOf("INSERT INTO SIEBEL.") > 0 && selectsql == false)
                        {
                            str15 = str6.Substring(checked(str6.LastIndexOf(".") + 1)).Trim();
                            str15 = str15.Substring(0, str15.IndexOf(" ("));
                        }
                        if (str1.IndexOf("UPDATE SIEBEL.") > 0 && selectsql == false)
                        {
                            str15 = str6.Substring(checked(str6.LastIndexOf(".") + 1)).Trim();
                            str15 = str15.Substring(0, str15.IndexOf("SET"));
                        }
                    }
                    if (str1.IndexOf("SELECT statement with ID") > 0 || str1.IndexOf("INSERT/UPDATE statement with ID") > 0)
                    {
                        isSQL = true;
                        linenbr = linecnt;
                        str3 = str1.Substring(checked(str1.LastIndexOf(":") + 1)).Trim();
                        if (str1.IndexOf("SELECT statement with ID") > 0)
                        {
                            selectsql = true;
                        }
                        else
                        {
                            selectsql = false;
                        }
                    }
                    if (str1.IndexOf("SQL Statement") > 0)
                    {
                        linenbr = linecnt;
                        num5 = str1.LastIndexOf(":");
                        num3 = str1.IndexOf("SQL Statement");
                        str7 = str1.Substring((num3), num5 - num3).Trim();
                        str8 = str1.Substring(checked(num5 + 1), checked(checked(str1.IndexOf(".") + 4) - num5));
                        ListViewItem item = new ListViewItem(new[] { str7, str14, str8, Convert.ToString(linenbr) });
                        listViewPerf.Items.Add(item);
                    }
                    if (num1 > 0 && (str1.Substring(checked(num1 + 1)).StartsWith("Error")))
                    {
                        num4 = str1.IndexOf("SBL");
                        if (num4 > 0)
                        {
                            str9 = str1.Substring(checked(num4), 13).Trim(); ///error code
                            str10 = str1.Substring(checked(checked(num4 + 13) + 1)).Trim(); ///error description
                            num2 = idxofn(str1, '\t', 4) + 1;//index of date
                            if (num2 > 0 && DateTime.TryParseExact(str1.Substring(num2, 19), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                            {
                                str11 = dateTime.ToString("dd-MMM-yy HH:mm:ss");
                            }
                            str12 = "WARNING";
                            if (str1.Substring(checked(num1 + 1)).StartsWith("Error"))
                            {
                                str12 = "ERROR";
                            }
                            linenbr = linecnt;
                            ListViewItem item = new ListViewItem(new[] { str11, str12, str9, str10, Convert.ToString(linenbr) });
                            listViewError.Items.Add(item);
                        }
                    }
                    //Getting the Task details
                    if (str1.IndexOf("Task engine requested to navigate to next step:") > 0)
                    {
                        num2 = idxofn(str1, '\t', 4) + 1;//index of date
                        if (num2 > 0 && DateTime.TryParseExact(str1.Substring(num2, 19), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                        {
                            str11 = dateTime.ToString("dd-MMM-yy HH:mm:ss");
                        }
                        num6 = str1.IndexOf(": '") + 3;
                        num7 = str1.LastIndexOf("'");
                        str13 = str1.Substring(checked(num6), num7 - num6).Trim();
                        linenbr = linecnt;
                        ListViewItem item = new ListViewItem(new[] { str13, str11, Convert.ToString(linenbr) });
                        listViewTBUI.Items.Add(item);
                    }
                    //Getting the Workflow details
                    if (str1.IndexOf("Instantiating process definition") > 0)
                    {
                        num8 = str1.IndexOf("'") + 1;
                        num9 = str1.LastIndexOf("'");
                        str16 = str1.Substring(checked(num8), num9 - num8).Trim();
                    }
                    if (str1.IndexOf("Instantiating step definition") > 0)
                    {
                        num2 = idxofn(str1, '\t', 4) + 1;//index of date
                        if (num2 > 0 && DateTime.TryParseExact(str1.Substring(num2, 19), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                        {
                            str11 = dateTime.ToString("dd-MMM-yy HH:mm:ss");
                        }
                        num8 = str1.IndexOf("'") + 1;
                        num9 = str1.LastIndexOf("'");
                        str17 = str1.Substring(checked(num8), num9 - num8).Trim();
                        linenbr = linecnt;
                        ListViewItem item = new ListViewItem(new[] { str16, str17, str11, Convert.ToString(linenbr) });
                        listViewWF.Items.Add(item);
                    }
                    //EventContext Logging
                    if (str1.IndexOf("EventContext") == 0)
                    {
                        str9 = str1.Substring(checked(str1.IndexOf("EvtCtx") + 6), checked(idxofn(str1, '\t', 2)) - checked(str1.IndexOf("EvtCtx")) - 6).Trim();
                        str10 = str1.Substring(checked(str1.LastIndexOf("\t") + 1)).Trim();
                        num2 = idxofn(str1, '\t', 4) + 1;//index of date
                        if (num2 > 0 && DateTime.TryParseExact(str1.Substring(num2, 19), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                        {
                            str11 = dateTime.ToString("dd-MMM-yy HH:mm:ss");
                        }
                        linenbr = linecnt;
                        ListViewItem item = new ListViewItem(new[] { str9, str10, str11, Convert.ToString(linenbr) });
                        listViewEvtcxt.Items.Add(item);
                    }
                }
                str1 = sr.ReadLine();
                linecnt = linecnt + 1;
            }
            }
            catch(Exception maEx)
            {
                MessageBox.Show(maEx.ToString());
            }
            finally
            {
                linecnt = 0;linenbr = 0;num1 = 0;num2 = 0;num3 = 0;num4 = 0;num5 = 0;num6 = 0;num7 = 0;num8 = 0;num9 = 0;
                str2 = "";str3 = "";str4 = "";str6 = "";str7 = "";str8 = "";str9 = "";str10 = "";str11 = "";str12 = "";str13 = "";
                str14 = "";str15 = "";str16 = "";str17 = "";selectsql = false;isSQL = false;isBind = false; 
            }
            Application.UseWaitCursor = false;
        }

        private int idxofn(string Sstr1, char Schar, int Sv2 = 0)
        {
            if (Sv2 <= 0)
                throw new ArgumentException("Can not find the zeroth index of substring in string. Must start with 1");
            int offset = Sstr1.IndexOf(Schar);
            for (int i = 1; i < Sv2; i++)
            {
                if (offset == -1) return -1;
                offset = Sstr1.IndexOf(Schar, offset + 1);
            }
            return offset;
        }
        private void listViewPerf_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listViewPerf.Sort();
        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            openFileDialog2.FileName = "Notepad++*";
            openFileDialog2.Filter = "Notepad++|*.exe";
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                Notepad = openFileDialog2.FileName;
                metroTextBox8.Text = Notepad;
                Settings.Default.Notepad = Notepad;
                Settings.Default.Save();
            }
        }
        private void OpenNotepad(string line)
        {
            Notepad = Settings.Default.Notepad.ToString();
            if (Notepad == "")
            {
                MessageBox.Show("Set Notepad++.exe path in File Select Tab");
            }
            else
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                proc.StartInfo.FileName = "notepad++";
                proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(Notepad);
                proc.StartInfo.Arguments = " -n" + line + " " + metroTextBox1.Text + "";
                proc.Start();
            }
        }
        private void contextMenuStripExecSQL_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = listViewExecSQL.SelectedItems.Count <= 0;
        }
        private void copySQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listViewExecSQL.SelectedItems[0].SubItems[2].Text);
        }

        private void copyBindVariableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listViewExecSQL.SelectedItems[0].SubItems[3].Text);
        }
        private void openInNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNotepad((listViewExecSQL.SelectedItems[0].SubItems[4].Text));
        }
        //Context Events on ListViewPerf
        private void contextMenuStripPerf_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = listViewPerf.SelectedItems.Count <= 0;
        }
        private void copySQLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listViewPerf.SelectedItems[0].SubItems[1].Text);
        }

        private void openInNotepadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenNotepad(listViewPerf.SelectedItems[0].SubItems[3].Text);
        }

        private void contextMenuStripError_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = listViewError.SelectedItems.Count <= 0;
        }

        private void openInNotepadToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenNotepad(listViewError.SelectedItems[0].SubItems[4].Text);
        }

        private void contextMenuStripTBUI_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = listViewTBUI.SelectedItems.Count <= 0;
        }

        private void openInNotepadToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OpenNotepad(listViewTBUI.SelectedItems[0].SubItems[2].Text);
        }

        private void contextMenuStripWF_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = listViewWF.SelectedItems.Count <= 0;
        }

        private void openInNotepadToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            OpenNotepad(listViewWF.SelectedItems[0].SubItems[3].Text);
        }

        private void contextMenuStripEvtCxt_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = listViewEvtcxt.SelectedItems.Count <= 0;
        }

        private void openInNotepadToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            OpenNotepad(listViewEvtcxt.SelectedItems[0].SubItems[3].Text);
        }

        private void listViewError_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewError.SelectedItems.Count > 0)
            {
                var errorCode = listViewError.SelectedItems[0].SubItems[2].Text;
                var errorDesc = listViewError.SelectedItems[0].SubItems[3].Text;
                metroTextBox9.Text = errorCode.ToString();
                metroTextBox10.Text = errorDesc.ToString();
                var db = new LiteDatabase(@"Filename=ErrorMsg.db; Connection=shared");
                var collection = db.GetCollection<ErrorMsg>("ErrorMsg");
                var Rec = collection.FindById(errorCode);
                if (Rec != null)
                {
                    metroTextBox11.Text = Rec.Solution;
                }
                else
                {
                    metroTextBox11.Text = "No Solution Documented Yet";
                }
            }
        }

        //Load local data
        private void metroButton4_Click(object sender, EventArgs e)
        {
                openLoadDef.FileName = "";
                openLoadDef.ShowDialog();
                string errordef = openLoadDef.FileName;

                if (errordef != "")
                {
                    List<LiteDB.BsonDocument> docs = new List<LiteDB.BsonDocument>();
                    StreamReader r = new StreamReader(errordef);
                    var json = r.ReadToEnd();
                    var jsonObj = JsonSerializer.DeserializeArray(json);
                    using (var db = new LiteDatabase("ErrorMsg.db"))
                    try
                    {
                        {
                            db.DropCollection("ErrorMsg");
                            var ErrO = db.GetCollection<ErrorMsg>("ErrorMsg");
                            docs = jsonObj.Select(x => x.AsDocument).ToList();
                            db.GetCollection("ErrorMsg").InsertBulk(docs);
                            ErrO.EnsureIndex("_id");
                        }
                    }
                    catch(Exception ex) {
                        MessageBox.Show(ex.ToString()) ;
                    }
                    finally
                    {
                        json = null;
                        jsonObj = null;
                    }
 
                }
            MessageBox.Show("Error Definations Updated :) ");
        }


        private void metroLabel9_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChangedAsync(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                checkBox1.Text = "Save";
                metroTextBox11.ReadOnly = false;
                metroTextBox11.BackColor = System.Drawing.Color.Beige;
            }
            else
            {
                checkBox1.Text = "Edit";
                metroTextBox11.ReadOnly = true;
                if (metroTextBox9.Text.ToString() != "")
                {
                    UpdateDatabase.updateLiteDb(metroTextBox9.Text.ToString(), metroTextBox10.Text.ToString(), metroTextBox11.Text.ToString());
                    if (metroToggle1.Checked)
                    UpdateDatabase.updateMongoDbAsync(metroTextBox9.Text.ToString(), metroTextBox11.Text.ToString());
                }
            }
            

        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.MongoInt = metroToggle1.Checked.ToString();
            Settings.Default.Save();
        }
    }
}
