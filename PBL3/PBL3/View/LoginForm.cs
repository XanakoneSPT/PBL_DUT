using PBL3.Model.Bean;
using PBL3.Model.Dao;
using PBL3.Model.Bo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.View
{
    public partial class LoginForm : Form
    {
        private Bo_AccountModel boAccount;
        public int LoggedInUserID { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
            dbConnection dbConnection = new dbConnection();
            boAccount = new Bo_AccountModel(dbConnection);

            UserNameTextBox.KeyDown += TextBox_KeyDown;
            PasswordTextBox.KeyDown += TextBox_KeyDown;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Disable the login button and show a loading cursor
            LoginButton.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                string userType;
                int userID;
                bool isAuthenticated = boAccount.AuthenticateUserAndCheckRole(username, password, out userType, out userID);

                if (isAuthenticated)
                {
                    LoggedInUserID = userID; // Store the logged-in user's ID
                    this.Hide();
                    switch (userType)
                    {
                        case "Admin":
                            new AdminForm().ShowDialog();
                            break;
                        case "Staff":
                            new Main(userID).ShowDialog();
                            break;
                        case "Customer":
                            new CustomerForm(userID).ShowDialog();
                            break;
                        default:
                            MessageBox.Show("Unknown user type. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable the login button and reset cursor
                LoginButton.Enabled = true;
                Cursor.Current = Cursors.Default;
                // Clear password field
                PasswordTextBox.Clear();
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the pressed key is the arrow key
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up)
            {
                // Move focus to the next control
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void LoginForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Call the LoginButton_Click event
                LoginButton_Click(sender, e);
            }
        }

        // Handle form closing event
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Make sure to close the form if it's not closed yet
            if (e.CloseReason != CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Show the password
                PasswordTextBox.PasswordChar = '\0'; // '\0' means display characters normally
            }
            else
            {
                // Hide the password
                PasswordTextBox.PasswordChar = '*'; // '*' will replace each character with '*'
            }
        }
    }
}
