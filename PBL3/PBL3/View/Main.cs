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
    public partial class Main : Form
    {
        public int UserID { get; set; }
        public Main(int userID)
        {
            InitializeComponent();
            UserID = userID;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            HomeButton_Click(sender, e);
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            // Reset the color of all buttons
            ResetButtonColors();

            // Set the color of the clicked button
            HomeButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            NotifiactionControl notiControl = new NotifiactionControl();
            notiControl.Dock = DockStyle.Fill;
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
            ChildrenControl childrenControl = new ChildrenControl();
            childrenControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(childrenControl);
        }
        private void VolunteerButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            VolunteerButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            VolunteerControl volunteerControl = new VolunteerControl();
            volunteerControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(volunteerControl);
        }

        private void EquipmentButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            EquipmentButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            EquipmentControl equipmentControl = new EquipmentControl();
            equipmentControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(equipmentControl);
        }

        private void CharityButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            CharityButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            CharityControl charityControl = new CharityControl();
            charityControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(charityControl);
        }
        private void ActivityButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            ActivityButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            ActivityControl activityControl = new ActivityControl();
            activityControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(activityControl);
        }
        private void AdoptionButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            AdoptionButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            AdoptionControl adoptionControl = new AdoptionControl(UserID);
            adoptionControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(adoptionControl);
        }

        private void IntroducetionButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            IntroducetionButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            IntroductionControl introControl = new IntroductionControl(UserID);
            introControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(introControl);
        }
        private void FeedbackButton_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            FeedbackButton.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            FeedblackControl feedControl = new FeedblackControl(this.UserID);
            feedControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(feedControl);
        }
        private void StatisticsBT_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            StatisticsBT.BackColor = Color.WhiteSmoke;

            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Dispose();
            }
            StatisticsControl statisticsControl = new StatisticsControl();
            statisticsControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(statisticsControl);
        }
        private void FinancialBT_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            FinancialBT.BackColor = Color.WhiteSmoke;

            if(panel1.Controls.Count > 0)
            {

            panel1.Controls[0].Dispose();
            }
            FinancialControl financialControl = new FinancialControl();
            financialControl.Dock = DockStyle.Fill;
            panel1 .Controls.Add(financialControl);
        }
        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void ResetButtonColors()
        {
            HomeButton.BackColor = SystemColors.ButtonHighlight;
            ChildrenButton.BackColor = SystemColors.ButtonHighlight;
            VolunteerButton.BackColor = SystemColors.ButtonHighlight;
            EquipmentButton.BackColor = SystemColors.ButtonHighlight;
            CharityButton.BackColor = SystemColors.ButtonHighlight;
            ActivityButton.BackColor = SystemColors.ButtonHighlight;
            AdoptionButton.BackColor = SystemColors.ButtonHighlight;
            IntroducetionButton.BackColor = SystemColors.ButtonHighlight;
            FeedbackButton.BackColor = SystemColors.ButtonHighlight;
            StatisticsBT.BackColor = SystemColors.ButtonHighlight;
            FinancialBT.BackColor = SystemColors.ButtonHighlight;
        }
        public void ShowUserControl(UserControl userControl)
        {
            panel1.Controls.Clear();
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Add(userControl);
        }
    }
}
