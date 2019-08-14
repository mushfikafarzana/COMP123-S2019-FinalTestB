using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

/*
 * Student Name: Mushfika Farzana
 * Student ID: 301051702
 * Description: This is the Character Generator Form - the main form of the application
  */

namespace COMP123_S2019_FinalTestB.Views
{
    public partial class CharacterGeneratorForm : MasterForm
    {
        string[] FirstNameList;
        string[] LastNameList;
        Random random = new Random();
        public CharacterGeneratorForm()
        {
            InitializeComponent();
        }

        // method that load first name and last names
        private void LoadNames()
        {
            FirstNameList = File.ReadAllLines("..\\..\\Data\\firstNames.txt");
            LastNameList = File.ReadAllLines("..\\..\\Data\\lastNames.txt");
        }

        // method that randomly generate names
        private void GenerateNames()
        {
            Program.character.FirstName = FirstNameList[random.Next(FirstNameList.Length)];
            Program.character.LastName = LastNameList[random.Next(LastNameList.Length)];

            FirstNameDataLabel.Text = Program.character.FirstName;
            LastNameDataLabel.Text = Program.character.LastName;
        }
        /// <summary>
        /// this is the event handler for the Back button Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex --;
            }
        }


        /// <summary>
        /// this is the event handler for the Next button Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1)
            {
                MainTabControl.SelectedIndex ++;
            }
        }

        /// <summary>
        /// this is the event handler for the CharacterGeneratorForm Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterGeneratorForm_Load(object sender, EventArgs e)
        {
            LoadNames();
            GenerateNames();
        }

        /// <summary>
        /// this is the event handler for the GenerateNameButton's Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNameButton_Click(object sender, EventArgs e)
        {
            GenerateNames();
            Program.character.FirstName = FirstNameDataLabel.Text;
            Program.character.LastName = LastNameDataLabel.Text;
        }

        /// <summary>
        /// this is the event handler for the aboutToolStripMenuItem Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.aboutBox.ShowDialog();
        }

        /// <summary>
        /// this is the event handler for the helpToolStripMenuItem Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Program.aboutBox.ShowDialog();
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       
    }
}
