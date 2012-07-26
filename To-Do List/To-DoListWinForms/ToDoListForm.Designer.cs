namespace To_DoListWinForms
{
    partial class ToDoListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toDoItemsGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridContenxtMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.createItemButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.showAllButton = new System.Windows.Forms.RadioButton();
            this.showPendingButton = new System.Windows.Forms.RadioButton();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.deadlinePicker = new System.Windows.Forms.DateTimePicker();
            this.descriptionTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.toDoItemsGridView)).BeginInit();
            this.gridContenxtMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toDoItemsGridView
            // 
            this.toDoItemsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toDoItemsGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.toDoItemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.toDoItemsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Title,
            this.Deadline,
            this.Status});
            this.toDoItemsGridView.ContextMenuStrip = this.gridContenxtMenu;
            this.toDoItemsGridView.Location = new System.Drawing.Point(12, 285);
            this.toDoItemsGridView.Name = "toDoItemsGridView";
            this.toDoItemsGridView.Size = new System.Drawing.Size(565, 323);
            this.toDoItemsGridView.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            // 
            // Deadline
            // 
            this.Deadline.DataPropertyName = "Deadline";
            this.Deadline.HeaderText = "DeadLine";
            this.Deadline.Name = "Deadline";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // gridContenxtMenu
            // 
            this.gridContenxtMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteMenuItem,
            this.doneMenuItem});
            this.gridContenxtMenu.Name = "gridContenxtMenu";
            this.gridContenxtMenu.Size = new System.Drawing.Size(108, 48);
            this.gridContenxtMenu.Opening += new System.ComponentModel.CancelEventHandler(this.gridContenxtMenu_Opening);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteMenuItem.Text = "Delete";
            this.deleteMenuItem.Click += new System.EventHandler(this.DeleteItems);
            // 
            // doneMenuItem
            // 
            this.doneMenuItem.Name = "doneMenuItem";
            this.doneMenuItem.Size = new System.Drawing.Size(107, 22);
            this.doneMenuItem.Text = "Done";
            this.doneMenuItem.Click += new System.EventHandler(this.CompleteItems);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title";
            // 
            // createItemButton
            // 
            this.createItemButton.Location = new System.Drawing.Point(128, 190);
            this.createItemButton.Name = "createItemButton";
            this.createItemButton.Size = new System.Drawing.Size(116, 23);
            this.createItemButton.TabIndex = 2;
            this.createItemButton.Text = "Create New Item";
            this.createItemButton.UseVisualStyleBackColor = true;
            this.createItemButton.Click += new System.EventHandler(this.CreateItem);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(253, 190);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetText);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // showAllButton
            // 
            this.showAllButton.AutoSize = true;
            this.showAllButton.Location = new System.Drawing.Point(34, 252);
            this.showAllButton.Name = "showAllButton";
            this.showAllButton.Size = new System.Drawing.Size(66, 17);
            this.showAllButton.TabIndex = 5;
            this.showAllButton.Text = "Show All";
            this.showAllButton.UseVisualStyleBackColor = true;
            this.showAllButton.CheckedChanged += new System.EventHandler(this.ShowAllItems);
            // 
            // showPendingButton
            // 
            this.showPendingButton.AutoSize = true;
            this.showPendingButton.Checked = true;
            this.showPendingButton.Location = new System.Drawing.Point(128, 252);
            this.showPendingButton.Name = "showPendingButton";
            this.showPendingButton.Size = new System.Drawing.Size(94, 17);
            this.showPendingButton.TabIndex = 6;
            this.showPendingButton.TabStop = true;
            this.showPendingButton.Text = "Show Pending";
            this.showPendingButton.UseVisualStyleBackColor = true;
            this.showPendingButton.CheckedChanged += new System.EventHandler(this.ShowPendingItems);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(128, 28);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(272, 20);
            this.titleTextBox.TabIndex = 8;
            // 
            // deadlinePicker
            // 
            this.deadlinePicker.Location = new System.Drawing.Point(128, 142);
            this.deadlinePicker.MinDate = new System.DateTime(2012, 7, 21, 0, 0, 0, 0);
            this.deadlinePicker.Name = "deadlinePicker";
            this.deadlinePicker.Size = new System.Drawing.Size(200, 20);
            this.deadlinePicker.TabIndex = 9;
            // 
            // descriptionTextbox
            // 
            this.descriptionTextbox.AccessibleDescription = "";
            this.descriptionTextbox.Location = new System.Drawing.Point(128, 64);
            this.descriptionTextbox.Multiline = true;
            this.descriptionTextbox.Name = "descriptionTextbox";
            this.descriptionTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextbox.Size = new System.Drawing.Size(420, 62);
            this.descriptionTextbox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Deadline";
            // 
            // titleError
            // 
            this.titleError.AutoSize = true;
            this.titleError.ForeColor = System.Drawing.Color.Red;
            this.titleError.Location = new System.Drawing.Point(418, 31);
            this.titleError.Name = "titleError";
            this.titleError.Size = new System.Drawing.Size(0, 13);
            this.titleError.TabIndex = 12;
            // 
            // ToDoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 620);
            this.Controls.Add(this.titleError);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descriptionTextbox);
            this.Controls.Add(this.deadlinePicker);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.showPendingButton);
            this.Controls.Add(this.showAllButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.createItemButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toDoItemsGridView);
            this.Name = "ToDoListForm";
            this.Text = "To-Do List";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.toDoItemsGridView)).EndInit();
            this.gridContenxtMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView toDoItemsGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createItemButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton showAllButton;
        private System.Windows.Forms.RadioButton showPendingButton;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.DateTimePicker deadlinePicker;
        private System.Windows.Forms.TextBox descriptionTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label titleError;
        private System.Windows.Forms.ContextMenuStrip gridContenxtMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doneMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deadline;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}

