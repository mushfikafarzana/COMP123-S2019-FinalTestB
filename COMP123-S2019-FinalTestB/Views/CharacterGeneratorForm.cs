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
        string[] InventoryList;
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

            CharacterNameTextBox.Text = FirstName + " " + LastName;
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
            LoadInventory();
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
        /// this is the event handler for the GenerateAbilitiesButton's Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {
            int strength = random.Next(3, 18);
            Program.character.Strength = strength.ToString();
            StrengthDataLabel.Text = Program.character.Strength;
            int dexterity = random.Next(3, 18);
            Program.character.Dexterity = dexterity.ToString();
            DexterityDataLabel.Text = Program.character.Dexterity;
            int constitution = random.Next(3, 18);
            Program.character.Constitution = constitution.ToString();
            ConstitutionDataLabel.Text = Program.character.Constitution;
            int intelligence = random.Next(3, 18);
            Program.character.Intelligence = intelligence.ToString();
            IntelligenceDataLabel.Text = Program.character.Intelligence;
            int wisdom = random.Next(3, 18);
            Program.character.Wisdom = wisdom.ToString();
            WisdomDataLabel.Text = Program.character.Wisdom;
            int charisma = random.Next(3, 18);
            Program.character.Charisma = charisma.ToString();
            CharismaDataLabel.Text = Program.character.Charisma;
        }

        // this method loads inventory 
        public void LoadInventory()
        {
            InventoryList = File.ReadAllLines("..\\..\\Data\\inventory.txt");
        }

        // method that randomly generate inventory
        private void GenerateRandomInventory()
        {
            List<string> InventoryList;
            InventoryList = new List<string>(File.ReadAllLines("inventory.txt"));
            string firstItem = InventoryList[random.Next(InventoryList.Count)];
            string secondItem = InventoryList[random.Next(InventoryList.Count)];
            string thirdItem = InventoryList[random.Next(InventoryList.Count)];
            string fourthItem = InventoryList[random.Next(InventoryList.Count)];
            inventory1Label.Text = firstItem;
            inventory2Label.Text = secondItem;
            inventory3Label.Text = thirdItem;
            inventory4Label.Text = fourthItem;

        }

        /// <summary>
        /// this is the event handler for the GenerateInventoryButton's Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateInventoryButton_Click(object sender, EventArgs e)
        {
            GenerateRandomInventory();
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

        /// <summary>
        /// This is the shared event handler for the openToolStripMenuItem and saveMenuStripButton click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharaterSheetOpenFileDialog.FileName = "character.txt";
            CharaterSheetOpenFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharaterSheetOpenFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";
            var result = CharaterSheetOpenFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                try
                {
                    // Open the  streawm for reading
                    using (StreamReader inputStream = new StreamReader(
                        File.Open(CharaterSheetOpenFileDialog.FileName, FileMode.Open)))
                    {
                        // read from the file
                        Program.character.FirstName = inputStream.ReadLine();
                        Program.character.LastName = inputStream.ReadLine();
                        Program.character.Strength = inputStream.ReadLine();
                        Program.character.Dexterity = inputStream.ReadLine();
                        Program.character.Constitution = inputStream.ReadLine();
                        Program.character.Intelligence = inputStream.ReadLine();
                        Program.character.Wisdom = inputStream.ReadLine();
                        Program.character.Charisma = inputStream.ReadLine();

                        // cleanup
                        inputStream.Close();
                        inputStream.Dispose();


                    }
                    FirstNameDataLabel.Text = Program.character.FirstName;
                    LastNameDataLabel.Text = Program.character.LastName;
                    StrengthDataLabel.Text = Program.character.Strength;
                    DexterityDataLabel.Text = Program.character.Dexterity;
                    ConstitutionDataLabel.Text = Program.character.Constitution;
                    IntelligenceDataLabel.Text = Program.character.Intelligence;
                    WisdomDataLabel.Text = Program.character.Wisdom;
                    CharismaDataLabel.Text = Program.character.Charisma;
                    NextButton_Click(sender, e);
                }
                catch (IOException exception)
                {

                    MessageBox.Show("ERROR: " + exception.Message, "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException exception)
                {
                    MessageBox.Show("ERROR: " + exception.Message + "\n\nPlease select the appropriate file type", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }

    /// <summary>
    /// This is the shared event handler for the SaveToolStripMenuItem and saveMenuStripButton click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CharaterSheetSaveFileDialog.FileName = "character.txt";
            CharaterSheetSaveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            CharaterSheetSaveFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";


            var result = CharaterSheetSaveFileDialog.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                using (StreamWriter outputStream = new StreamWriter(
                    File.Open(CharaterSheetSaveFileDialog.FileName, FileMode.Create)))
                {

                    outputStream.WriteLine(Program.character.FirstName);
                    outputStream.WriteLine(Program.character.LastName);
                    outputStream.WriteLine(Program.character.Strength);
                    outputStream.WriteLine(Program.character.Dexterity);
                    outputStream.WriteLine(Program.character.Constitution);
                    outputStream.WriteLine(Program.character.Intelligence);
                    outputStream.WriteLine(Program.character.Wisdom);
                    outputStream.WriteLine(Program.character.Charisma);
                    outputStream.Close();
                    outputStream.Dispose();
                    MessageBox.Show("File Saved...", "Saving File...",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        /// <summary>
        /// This method generate random characters names based on names list from files
        /// </summary>
    }

    

        
    }
}
