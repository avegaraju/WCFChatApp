namespace EA.Client.EAChat.UI
{
    partial class ChatWindow
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
            this.ChatHandleGroup = new System.Windows.Forms.GroupBox();
            this.ChatHandleSetButton = new System.Windows.Forms.Button();
            this.ChatHandleTextBox = new System.Windows.Forms.TextBox();
            this.UserListGroup = new System.Windows.Forms.GroupBox();
            this.OnlineUserListBox = new System.Windows.Forms.ListBox();
            this.MessagesGroup = new System.Windows.Forms.GroupBox();
            this.MessageConsoleListBox = new System.Windows.Forms.ListBox();
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.ChatMessageTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SetPortButton = new System.Windows.Forms.Button();
            this.SetPortTextBox = new System.Windows.Forms.TextBox();
            this.ClearSelectionButton = new System.Windows.Forms.Button();
            this.ChatHandleGroup.SuspendLayout();
            this.UserListGroup.SuspendLayout();
            this.MessagesGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatHandleGroup
            // 
            this.ChatHandleGroup.Controls.Add(this.ChatHandleSetButton);
            this.ChatHandleGroup.Controls.Add(this.ChatHandleTextBox);
            this.ChatHandleGroup.Location = new System.Drawing.Point(240, 12);
            this.ChatHandleGroup.Name = "ChatHandleGroup";
            this.ChatHandleGroup.Size = new System.Drawing.Size(348, 60);
            this.ChatHandleGroup.TabIndex = 0;
            this.ChatHandleGroup.TabStop = false;
            this.ChatHandleGroup.Text = "Chat Handle";
            // 
            // ChatHandleSetButton
            // 
            this.ChatHandleSetButton.Enabled = false;
            this.ChatHandleSetButton.Location = new System.Drawing.Point(239, 16);
            this.ChatHandleSetButton.Name = "ChatHandleSetButton";
            this.ChatHandleSetButton.Size = new System.Drawing.Size(103, 32);
            this.ChatHandleSetButton.TabIndex = 2;
            this.ChatHandleSetButton.Text = "Set Handle";
            this.ChatHandleSetButton.UseVisualStyleBackColor = true;
            this.ChatHandleSetButton.Click += new System.EventHandler(this.ChatHandleSetButton_Click);
            // 
            // ChatHandleTextBox
            // 
            this.ChatHandleTextBox.Enabled = false;
            this.ChatHandleTextBox.Location = new System.Drawing.Point(18, 22);
            this.ChatHandleTextBox.Name = "ChatHandleTextBox";
            this.ChatHandleTextBox.Size = new System.Drawing.Size(215, 22);
            this.ChatHandleTextBox.TabIndex = 1;
            // 
            // UserListGroup
            // 
            this.UserListGroup.Controls.Add(this.ClearSelectionButton);
            this.UserListGroup.Controls.Add(this.OnlineUserListBox);
            this.UserListGroup.Location = new System.Drawing.Point(600, 12);
            this.UserListGroup.Name = "UserListGroup";
            this.UserListGroup.Size = new System.Drawing.Size(200, 431);
            this.UserListGroup.TabIndex = 0;
            this.UserListGroup.TabStop = false;
            this.UserListGroup.Text = "User List";
            // 
            // OnlineUserListBox
            // 
            this.OnlineUserListBox.Enabled = false;
            this.OnlineUserListBox.FormattingEnabled = true;
            this.OnlineUserListBox.ItemHeight = 16;
            this.OnlineUserListBox.Location = new System.Drawing.Point(6, 16);
            this.OnlineUserListBox.Name = "OnlineUserListBox";
            this.OnlineUserListBox.Size = new System.Drawing.Size(188, 372);
            this.OnlineUserListBox.TabIndex = 0;
            // 
            // MessagesGroup
            // 
            this.MessagesGroup.Controls.Add(this.MessageConsoleListBox);
            this.MessagesGroup.Controls.Add(this.SendMessageButton);
            this.MessagesGroup.Controls.Add(this.ChatMessageTextBox);
            this.MessagesGroup.Location = new System.Drawing.Point(35, 79);
            this.MessagesGroup.Name = "MessagesGroup";
            this.MessagesGroup.Size = new System.Drawing.Size(553, 364);
            this.MessagesGroup.TabIndex = 1;
            this.MessagesGroup.TabStop = false;
            this.MessagesGroup.Text = "Messages";
            // 
            // MessageConsoleListBox
            // 
            this.MessageConsoleListBox.Enabled = false;
            this.MessageConsoleListBox.FormattingEnabled = true;
            this.MessageConsoleListBox.ItemHeight = 16;
            this.MessageConsoleListBox.Location = new System.Drawing.Point(6, 21);
            this.MessageConsoleListBox.Name = "MessageConsoleListBox";
            this.MessageConsoleListBox.Size = new System.Drawing.Size(541, 260);
            this.MessageConsoleListBox.TabIndex = 2;
            // 
            // SendMessageButton
            // 
            this.SendMessageButton.Enabled = false;
            this.SendMessageButton.Location = new System.Drawing.Point(472, 289);
            this.SendMessageButton.Name = "SendMessageButton";
            this.SendMessageButton.Size = new System.Drawing.Size(75, 58);
            this.SendMessageButton.TabIndex = 1;
            this.SendMessageButton.Text = "Send";
            this.SendMessageButton.UseVisualStyleBackColor = true;
            this.SendMessageButton.Click += new System.EventHandler(this.SendMessageButton_Click);
            // 
            // ChatMessageTextBox
            // 
            this.ChatMessageTextBox.Enabled = false;
            this.ChatMessageTextBox.Location = new System.Drawing.Point(7, 289);
            this.ChatMessageTextBox.Multiline = true;
            this.ChatMessageTextBox.Name = "ChatMessageTextBox";
            this.ChatMessageTextBox.Size = new System.Drawing.Size(459, 58);
            this.ChatMessageTextBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SetPortButton);
            this.groupBox1.Controls.Add(this.SetPortTextBox);
            this.groupBox1.Location = new System.Drawing.Point(34, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 61);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Port";
            // 
            // SetPortButton
            // 
            this.SetPortButton.Location = new System.Drawing.Point(97, 21);
            this.SetPortButton.Name = "SetPortButton";
            this.SetPortButton.Size = new System.Drawing.Size(75, 23);
            this.SetPortButton.TabIndex = 1;
            this.SetPortButton.Text = "Set Port";
            this.SetPortButton.UseVisualStyleBackColor = true;
            this.SetPortButton.Click += new System.EventHandler(this.SetPortButton_Click);
            // 
            // SetPortTextBox
            // 
            this.SetPortTextBox.Location = new System.Drawing.Point(8, 21);
            this.SetPortTextBox.Name = "SetPortTextBox";
            this.SetPortTextBox.Size = new System.Drawing.Size(82, 22);
            this.SetPortTextBox.TabIndex = 0;
            // 
            // ClearSelectionButton
            // 
            this.ClearSelectionButton.Location = new System.Drawing.Point(6, 394);
            this.ClearSelectionButton.Name = "ClearSelectionButton";
            this.ClearSelectionButton.Size = new System.Drawing.Size(188, 31);
            this.ClearSelectionButton.TabIndex = 1;
            this.ClearSelectionButton.Text = "Clear Selection";
            this.ClearSelectionButton.UseVisualStyleBackColor = true;
            this.ClearSelectionButton.Click += new System.EventHandler(this.ClearSelectionButton_Click);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 484);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MessagesGroup);
            this.Controls.Add(this.UserListGroup);
            this.Controls.Add(this.ChatHandleGroup);
            this.Name = "ChatWindow";
            this.Text = "ChatWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatWindow_Closed);
            this.Load += new System.EventHandler(this.ChatWindow_Load);
            this.ChatHandleGroup.ResumeLayout(false);
            this.ChatHandleGroup.PerformLayout();
            this.UserListGroup.ResumeLayout(false);
            this.MessagesGroup.ResumeLayout(false);
            this.MessagesGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ChatHandleGroup;
        private System.Windows.Forms.GroupBox UserListGroup;
        private System.Windows.Forms.GroupBox MessagesGroup;
        private System.Windows.Forms.Button SendMessageButton;
        private System.Windows.Forms.TextBox ChatMessageTextBox;
        private System.Windows.Forms.Button ChatHandleSetButton;
        private System.Windows.Forms.TextBox ChatHandleTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SetPortButton;
        private System.Windows.Forms.TextBox SetPortTextBox;
        public System.Windows.Forms.ListBox OnlineUserListBox;
        private System.Windows.Forms.ListBox MessageConsoleListBox;
        private System.Windows.Forms.Button ClearSelectionButton;
    }
}

