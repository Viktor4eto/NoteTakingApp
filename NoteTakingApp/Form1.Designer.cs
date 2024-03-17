namespace NoteTakingApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            currentNote = new RichTextBox();
            selector = new ComboBox();
            newNote = new Button();
            delete = new Button();
            save = new Button();
            label1 = new Label();
            edited = new Label();
            SuspendLayout();
            // 
            // currentNote
            // 
            currentNote.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            currentNote.BackColor = Color.Azure;
            currentNote.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            currentNote.ForeColor = Color.Black;
            currentNote.Location = new Point(3, 42);
            currentNote.Name = "currentNote";
            currentNote.Size = new Size(794, 404);
            currentNote.TabIndex = 0;
            currentNote.Text = "";
            // 
            // selector
            // 
            selector.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            selector.FormattingEnabled = true;
            selector.Location = new Point(3, 8);
            selector.Name = "selector";
            selector.Size = new Size(320, 28);
            selector.TabIndex = 1;
            selector.SelectedIndexChanged += loadCurrentNote;
            selector.TextUpdate += loadCurrentNote;
            // 
            // newNote
            // 
            newNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            newNote.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            newNote.Location = new Point(657, 8);
            newNote.Name = "newNote";
            newNote.Size = new Size(140, 27);
            newNote.TabIndex = 2;
            newNote.Text = "New Note";
            newNote.UseVisualStyleBackColor = true;
            newNote.Click += clickNewNote;
            // 
            // delete
            // 
            delete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            delete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            delete.Location = new Point(341, 8);
            delete.Name = "delete";
            delete.Size = new Size(140, 27);
            delete.TabIndex = 3;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            delete.Click += clickDelete;
            // 
            // save
            // 
            save.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            save.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            save.Location = new Point(499, 8);
            save.Name = "save";
            save.Size = new Size(140, 27);
            save.TabIndex = 4;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += clickSave;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 449);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 5;
            label1.Text = "Last Edited: ";
            // 
            // edited
            // 
            edited.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            edited.AutoSize = true;
            edited.Location = new Point(85, 449);
            edited.Name = "edited";
            edited.Size = new Size(0, 20);
            edited.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(800, 471);
            Controls.Add(edited);
            Controls.Add(label1);
            Controls.Add(save);
            Controls.Add(delete);
            Controls.Add(newNote);
            Controls.Add(selector);
            Controls.Add(currentNote);
            MinimumSize = new Size(818, 518);
            Name = "Form1";
            Text = "Notes";
            FormClosed += onClose;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripComboBox toolStripComboBox1;
        private Panel panel1;
        private RadioButton radioButton1;
        private RichTextBox currentNote;
        private ComboBox selector;
        private Button newNote;
        private Button delete;
        private Button save;
        private Label label1;
        private Label edited;
    }
}
