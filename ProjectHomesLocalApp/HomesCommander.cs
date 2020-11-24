using ProjectHomesLocalApp.Modles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing.Text;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ProjectHomesLocalApp.Modules
{
    class HomesCommander
    {
        private readonly string userInputOne;
        private readonly string userInputTwo;

        private string cleanInputOne;
        private string cleanInputTwo;

        private ProgressBar formProgressBar;

        private string results;


        public HomesCommander(string _userInputOne , string _userInputTwo , ProgressBar progressBar)
        {
            this.userInputOne = _userInputOne;
            this.userInputTwo = _userInputTwo;
            this.formProgressBar = progressBar;
        }
        public string getResults()
        {
            return this.results;
        }
        public void doProcessing()
        {
            //Prep
            TextCleaner textCleaner = new TextCleaner();
            cleanInputOne = textCleaner.cleanText(userInputOne);
            cleanInputTwo = textCleaner.cleanText(userInputTwo);
            textCleaner = null;

            //Split sentences up
               accountModel account1 = new accountModel();
               accountModel account2 = new accountModel();

                //Regex.Split(cleanInputOne, @"?<=[\.!\?]\s+");

                account1.text = cleanInputOne.Split('.');
                account2.text = cleanInputTwo.Split('.');

                //Calculations

                locationChecker.calculateRegion(account1);
                locationChecker.calculateRegion(account2);
                SpellingChecker.SpellChecker(account1);
                SpellingChecker.SpellChecker(account2);


            //OverSimplified AI
            results = $"Account One\n Regions: \nAmerica: {account1.AmericanCount} \nAustralia: {account1.AustralianCount}\nBritish: {account1.BritishCount}\nCanada: {account1.CanadianCount}\nSpelling: {account1.Spelling}\n {System.DateTime.Now.ToString("G")} \n\n";
            results += $"\nAccount Two\n Regions: \nAmerica: {account2.AmericanCount} \nAustralia: {account2.AustralianCount}\nBritish: {account2.BritishCount}\nCanada: {account2.CanadianCount}\nSpelling: {account2.Spelling}\n {System.DateTime.Now.ToString("G")}";

            //Go  though each. cnt tollerance.
            int tolerance = 1;
            if(account1.AmericanCount > account2.AmericanCount + tolerance || account1.AmericanCount < account2.AmericanCount - tolerance)
            {
                results += "\nAccounts Are Diffrent.\n";
            }
            else if (account1.AustralianCount > account2.AmericanCount + tolerance || account1.AmericanCount < account2.AmericanCount - tolerance)
            {
                results += "\nAccounts Are Diffrent.\n";
            }
            else if (account1.BritishCount > account2.BritishCount + tolerance || account1.BritishCount < account2.BritishCount - tolerance)
            {
                results += "\nAccounts Are Diffrent.\n";
            }
            else if (account1.CanadianCount > account2.CanadianCount + tolerance || account1.CanadianCount < account2.CanadianCount - tolerance)
            {
                results += "\nAccounts Are Diffrent.\n";
            }
            else
            {
                results += "\nAccounts Are The Same.\n";
            }

            return;
        }


    }
}
