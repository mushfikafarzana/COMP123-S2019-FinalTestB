﻿using COMP123_S2019_FinalTestB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2019_FinalTestB
{
    static class Program
    {
        //public static MasterForm masterForm;
        public static CharacterGeneratorForm characterForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //masterForm = new MasterForm();

            characterForm = new CharacterGeneratorForm();

            Application.Run(characterForm);
        }
    }
}
