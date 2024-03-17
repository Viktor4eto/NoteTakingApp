using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace NoteTakingApp
{
    public partial class Form1 : Form
    {

        private SqlConnection sqlCon;
        private List<Note> notes = new List<Note>();
        private List<string> titles = new List<string>();
        private Note currNote = new Note();
        public Form1()
        {
            InitializeComponent();
            try
            {
                sqlCon = new SqlConnection(@"Data Source=(localdb)\local; Initial Catalog=NoteDB; Integrated Security=True;");
                sqlCon.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadNotes();
        }

        private void onClose(object sender, FormClosedEventArgs e)
        {
            this.sqlCon.Close();
        }

        private void loadNotes()
        {
            this.titles.Clear();
            this.notes.Clear();

            string notesQuery = "SELECT * FROM Notes ORDER BY Timestamp DESC";

            SqlCommand cmd = new SqlCommand(notesQuery, this.sqlCon);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Note n = new Note();
                n.id = (int)reader[0];
                n.title = reader[1].ToString();
                n.content = reader[2].ToString();
                n.timestamp = (DateTime)reader[3];

                this.notes.Add(n);
                this.titles.Add(n.title);
            }
            reader.Close();
            cmd.Dispose();

            selector.DataSource = null;
            selector.DataSource = this.titles;
        }

        private void loadCurrentNote(object sender, EventArgs e)
        {
            DateTime lastEdited = new DateTime();
            for (int i = 0; i < this.notes.Count; i++)
            {
                if (this.notes[i].title == selector.Text)
                {
                    this.currNote = this.notes[i];
                    currentNote.Text = this.notes[i].content;
                    lastEdited = this.notes[i].timestamp;
                }
            }

            edited.Text = lastEdited.ToString();
        }

        private void clickDelete(object sender, EventArgs e)
        {
            if (this.currNote != null)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to delete this note?", "Delete Note", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes )
            {
                
                    string notesQuery = "DELETE FROM Notes WHERE NoteID = @id";

                    SqlCommand cmd = new SqlCommand(notesQuery, this.sqlCon);
                    cmd.Parameters.AddWithValue("@id", this.currNote.id);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                    this.notes.Remove(this.currNote);
                    this.titles.Remove(this.currNote.title);

                    selector.DataSource = null;
                    selector.DataSource = this.titles;

                    currentNote.Text = "";
                    edited.Text = "";

                    loadCurrentNote(null, null);
               }



            }
            else
            {
                selector.SelectedIndex = 0;
            }
        }

        private void clickNewNote(object sender, EventArgs e)
        {
            this.currNote = null;
            currentNote.Text = "";
            selector.SelectedIndex = -1;
            edited.Text = "";
        }

        private void clickSave(object sender, EventArgs e)
        {
            string title = currentNote.Lines.Length > 0 ? currentNote.Lines[0] : "none";
            string content = currentNote.Text;
            DateTime timestamp = DateTime.Now;


            if (this.currNote != null)
            {
                string updateQuery = "UPDATE Notes SET Title = @Title, Content = @Content, Timestamp = @Timestamp WHERE NoteID = @ID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Content", content);
                    cmd.Parameters.AddWithValue("@Timestamp", timestamp);
                    cmd.Parameters.AddWithValue("@ID", currNote.id);

                    if (sqlCon.State != ConnectionState.Open)
                        sqlCon.Open();

                    cmd.ExecuteNonQuery();


                    this.titles.Remove(this.currNote.title);
                    this.notes.Remove(this.currNote);

                    this.currNote.title = title;
                    this.currNote.content = content;
                    this.currNote.timestamp = timestamp;

                    loadNotes();

                    edited.Text = timestamp.ToString();
                    selector.SelectedItem = title;

                }

                edited.Text = timestamp.ToString();
            }
            else
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(currentNote.Text))
                    {
                        MessageBox.Show("Note content cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    string insertQuery = "INSERT INTO Notes (Title, Content, Timestamp) VALUES (@Title, @Content, @Timestamp)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Content", content);
                        cmd.Parameters.AddWithValue("@Timestamp", timestamp);

                        if (sqlCon.State != ConnectionState.Open)
                            sqlCon.Open();

                        cmd.ExecuteNonQuery();


                    }

                    int newId = -1;
                    string query = "SELECT MAX(NoteID) FROM Notes";

                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        if (sqlCon.State != ConnectionState.Open)
                            sqlCon.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            newId = Convert.ToInt32(result);
                        }

                    }
                    this.currNote = new Note();
                    this.currNote.title = title;
                    this.currNote.content = content;
                    this.currNote.timestamp = timestamp;
                    this.currNote.id = newId;

                    loadNotes();


                    edited.Text = timestamp.ToString();

                    selector.SelectedItem = title;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }




        public class Note()
        {
            public int id { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public DateTime timestamp { get; set; }

        }
    }

