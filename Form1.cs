using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AudirvanaPlaylistSorter {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        void ErrorMsgBox(string ex) {
            MessageBox.Show(ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        DataTable SQLite(string Query, int CommandTimeout = -1, string ErrorText = "Default") {
            var oSQL = v.oConn.CreateCommand();
            oSQL.CommandText = Query;
            if (CommandTimeout > 0) {
                oSQL.CommandTimeout = CommandTimeout;
            }
            DataSet DS = new DataSet();
            SQLiteDataAdapter DA = new SQLiteDataAdapter(oSQL);
            try {
                DA.Fill(DS);
            } catch (Exception ex) {
                if (ErrorText == "Default") {
                    ErrorMsgBox(ex.ToString());
                } else {
                    ErrorMsgBox(ErrorText);
                }
                return null;
            }
            return DS.Tables[0];
        }

        void Form1_Load(object sender, EventArgs e) {
            // Create RegKey if not exist
            do {
                v.RegKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AudirvanaPlaylistSorter", true);
                if (v.RegKey == null) {
                    Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AudirvanaPlaylistSorter");
                }
            } while (v.RegKey == null);
            // Set window size
            this.Size = new System.Drawing.Size(Convert.ToInt32(v.RegKey.GetValue(v.RegPathWindowWidth)),
                Convert.ToInt32(v.RegKey.GetValue(v.RegPathWindowHeight)));
            v.sPathDatabase = Convert.ToString(v.RegKey.GetValue(v.RegPathDatabase));
            if (File.Exists(v.sPathDatabase) == false) {
                SelectDatabasePath(false);
            }
            SetDatabasePath();
            v.oConn = new SQLiteConnection();
            v.oConn.ConnectionString = "Data Source=" + v.sPathDatabase;
            try {
                v.oConn.Open();
            } catch (Exception ex) {
                ErrorMsgBox(ex.ToString());
            }
            try {
                v.oConn.EnableExtensions(true);
            } catch (Exception ex) {
                ErrorMsgBox(ex.ToString());
            }
            try {
                v.oConn.LoadExtension("SQLite.Interop.dll", "sqlite3_fts5_init");
            } catch (Exception ex) {
                ErrorMsgBox(ex.ToString());
            }
            var DS = SQLite("SELECT title FROM PLAYLISTS WHERE predicate IS NULL;", 5, "Couldn't query playlists! Please close Audirvana.");
            if (DS == null) {
                this.Close();
                return;
            }
            foreach (DataRow Row in DS.Rows) {
                clsPlaylists.Items.Add(Row["title"].ToString());
            }
        }

        void SelectDatabasePath(bool SetDatabasePathYN = true) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select Audirvana database file";
            openFileDialog1.Filter = "sqlite files (*.sqlite)|*.sqlite";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                v.sPathDatabase = openFileDialog1.FileName;
            }
            openFileDialog1.Dispose();
            if (SetDatabasePathYN == true) {
                SetDatabasePath();
            }
        }

        void SetDatabasePath() {
            v.RegKey.SetValue(v.RegPathDatabase, v.sPathDatabase);
            txtPathDatabase.Text = v.sPathDatabase;
        }

        string GetAudirvanaInnerJoins() {
            string sSQL;
            sSQL = "FROM TRACKS" + v.nl;
            sSQL += "INNER JOIN PLAYLISTS_TRACKS ON TRACKS.track_id = PLAYLISTS_TRACKS.track_id" + v.nl;
            sSQL += "INNER JOIN ALBUMS ON TRACKS.album_id = ALBUMS.album_id" + v.nl;
            sSQL += "INNER JOIN TRACKS_ARTISTS ON TRACKS.track_id = TRACKS_ARTISTS.track_id" + v.nl;
            sSQL += "INNER JOIN ARTISTS ON TRACKS_ARTISTS.artist_id = ARTISTS.artist_id" + v.nl;
            return sSQL;
        }

        void SortPlaylists(string Playlist) {
            string sSQL;
            int c, RecordCount, LastRecord = 999000;
            var oSQL = v.oConn.CreateCommand();
            var DS = SQLite("SELECT playlist_id FROM PLAYLISTS WHERE title = '" + Playlist + "';");
            string PlaylistID = DS.Rows[0]["playlist_id"].ToString();
            DS.Clear();
            foreach (string String in new string[] { "The ", "A " }) {
                oSQL.CommandText = "UPDATE ARTISTS SET sort_name = SUBSTR(name, " + (String.Length + 1) + ") WHERE name LIKE '" + String + "%';";
                oSQL.ExecuteNonQuery();
            }
            sSQL = "SELECT TRACKS.track_id, PLAYLISTS_TRACKS.position" + v.nl;
            sSQL += GetAudirvanaInnerJoins() + v.nl;
            sSQL += "WHERE PLAYLISTS_TRACKS.playlist_id = " + PlaylistID + v.nl;
            sSQL += "ORDER BY UPPER(ARTISTS.sort_name), UPPER(ALBUMS.title);";
            DS = SQLite(sSQL);
            RecordCount = DS.Rows.Count;
            // Get highest position in playlist
            sSQL = "SELECT MAX(PLAYLISTS_TRACKS.position)" + v.nl;
            sSQL += GetAudirvanaInnerJoins() + v.nl;
            sSQL += "WHERE PLAYLISTS_TRACKS.playlist_id = " + PlaylistID + v.nl;
            sSQL += "ORDER BY UPPER(ARTISTS.sort_name), UPPER(ALBUMS.title);";
            var DS2 = SQLite(sSQL);
            try {
                LastRecord = Convert.ToInt32(DS2.Rows[0][0]) + 5;
            } catch (Exception ex) {
                ErrorMsgBox(ex.ToString());
            }
            DS2.Clear();
            foreach (int Number in new int[] { LastRecord, 0 }) {
                c = Number;
                for (int i = 0; i < RecordCount; i++) {
                    c++;
                    sSQL = "UPDATE PLAYLISTS_TRACKS SET position = " + c + " ";
                    sSQL += "WHERE track_id = " + DS.Rows[i]["track_id"] + " AND playlist_id = " + PlaylistID + ";";
                    oSQL.CommandText = sSQL;
                    try {
                        oSQL.ExecuteNonQuery();
                    } catch (Exception ex) {
                        ErrorMsgBox(ex.ToString());
                    }
                }
            }
            DS.Clear();
        }

        void LockUI(bool Enabled) {
            clsPlaylists.Enabled = Enabled;
            btnSort.Enabled = Enabled;
            btnSelectAll.Enabled = Enabled;
            btnSelectNone.Enabled = Enabled;
            btnSelectDatabasePath.Enabled = Enabled;
            btnCancel.Enabled = !Enabled;
            btnCancel.Visible = !Enabled;
            txtPathDatabase.Enabled = Enabled;
        }

        async void btnSort_Click(object sender, EventArgs e) {
            clsPlaylists.SelectedIndex = -1;
            progressBar1.Style = ProgressBarStyle.Marquee;
            LockUI(false);
            v.Stop = false;
            int iPlaylistCount = clsPlaylists.Items.Count;
            for (int i = 0; i < iPlaylistCount; i++) {
                if (clsPlaylists.GetItemChecked(i) == true && v.Stop == false) {
                    clsPlaylists.SetSelected(i, true);
                    await Task.Run(() => SortPlaylists(clsPlaylists.Items[i].ToString()));
                    clsPlaylists.SetItemChecked(i, false);
                }
            }
            clsPlaylists.SelectedIndex = -1;
            progressBar1.Style = ProgressBarStyle.Blocks;
            LockUI(true);
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            v.oConn.Close();
            v.oConn.Dispose();
            // Save window size
            switch (WindowState) {
                case FormWindowState.Normal:
                    v.RegKey.SetValue(v.RegPathWindowWidth, Size.Width.ToString());
                    v.RegKey.SetValue(v.RegPathWindowHeight, Size.Height.ToString());
                    break;
                default:
                    v.RegKey.SetValue(v.RegPathWindowWidth, RestoreBounds.Size.Width);
                    v.RegKey.SetValue(v.RegPathWindowHeight, RestoreBounds.Size.Height);
                    break;
            }
        }

        void btnSelectAll_Click(object sender, EventArgs e) {
            for (int i = 0; i <= (clsPlaylists.Items.Count - 1); i++) {
                clsPlaylists.SetItemCheckState(i, CheckState.Checked);
            }
        }

        void btnSelectNone_Click(object sender, EventArgs e) {
            for (int i = 0; i <= (clsPlaylists.Items.Count - 1); i++) {
                clsPlaylists.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        void button1_Click(object sender, EventArgs e) {
            SelectDatabasePath();
        }

        void btnCancel_Click(object sender, EventArgs e) {
            btnCancel.Enabled = false;
            v.Stop = true;
        }
    }

    public static class v {
        // General
        public static string nl = Environment.NewLine;
        public static string sPathDatabase;
        public static bool Stop;
        // SQLite
        public static SQLiteConnection oConn;
        // Registry
        public static RegistryKey RegKey;
        public static string RegPathDatabase = "PathDatabase";
        public static string RegPathWindowWidth = "WindowWidth";
        public static string RegPathWindowHeight = "WindowHeight";
    }

}
