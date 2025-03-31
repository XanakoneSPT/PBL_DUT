using PBL3.View.UC;
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
    public partial class CustomerForm : Form
    {
        public int UserID { get; set; }

        public CustomerForm(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void CustomerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            HomeButton_Click(sender, e);
        }
        private void ProfileButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            ProfileButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }

            ProfileControl profileControl = new ProfileControl
            {
                UserID = this.UserID,
                Dock = DockStyle.Fill
            };

            panel1.Controls.Add(profileControl);
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            HomeButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            NotifiactionControl notiControl = new NotifiactionControl
            {
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(notiControl);
        }

        private void ChildrenButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            ChildrenButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            ChildrenControl childrenControl = new ChildrenControl
            {
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(childrenControl);
            childrenControl.SetButtonVisibility(false);
        }

        private void CharityButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            CharityButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            CharityControl charirtyControl = new CharityControl
            {
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(charirtyControl);
            charirtyControl.SetButtonVisibility(false);
        }

        private void ActivityButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            ActivityButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            ActivityControl activityControl = new ActivityControl
            {
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(activityControl);
            activityControl.SetButtonVisibility(false);
        }

        private void AdoptionButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            AdoptionButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            AdoptionControl adoptControl = new AdoptionControl(UserID)
            {
                Dock = DockStyle.Fill,
                IsOpenedFromCustomerForm = true
            };
            panel1.Controls.Add(adoptControl);
            adoptControl.SetButtonVisibility(false);
        }
        private void IntroducetionButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            IntroducetionButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            IntroductionControl introControl = new IntroductionControl(UserID)
            {
                Dock = DockStyle.Fill,
                IsOpenedFromCustomerForm = true
            };
            panel1.Controls.Add(introControl);
            introControl.SetButtonVisibility(false);
        }

        private void FeedbackButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            FeedbackButton.BackColor = Color.WhiteSmoke;
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            FeedblackControl feedControl = new FeedblackControl(UserID)
            {
                IsOpenedFromCustomerForm = true,
                Dock = DockStyle.Fill
            };
            panel1.Controls.Add(feedControl);
            feedControl.SetButtonVisibility(false);
        }

        private void ResetButtonColors()
        {
            HomeButton.BackColor = SystemColors.ButtonHighlight;
            ProfileButton.BackColor = SystemColors.ButtonHighlight;
            ChildrenButton.BackColor = SystemColors.ButtonHighlight;
            CharityButton.BackColor = SystemColors.ButtonHighlight;
            ActivityButton.BackColor = SystemColors.ButtonHighlight;
            AdoptionButton.BackColor = SystemColors.ButtonHighlight;
            IntroducetionButton.BackColor = SystemColors.ButtonHighlight;
            FeedbackButton.BackColor = SystemColors.ButtonHighlight;
        }
    }
}
