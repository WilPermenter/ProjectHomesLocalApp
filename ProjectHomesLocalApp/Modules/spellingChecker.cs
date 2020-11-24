using Dapper;
using ProjectHomesLocalApp.Modles;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace ProjectHomesLocalApp.Modules
{
    class SpellingChecker
    {
       public static accountModel SpellChecker(accountModel account)
        {

            using (System.Data.IDbConnection cnn = new SQLiteConnection("Data Source= DictionaryFull.db;Version=3;"))
            {
                foreach(var sentince in account.text)
                {
                    string [] words = sentince.Split(' ');
                    foreach(var word in words)
                    {
                        if (!word.Contains("'"))
                        {
                            var WordList = cnn.Query<regionModel>("SELECT ID , Word , File From WordsList WHERE Word = '"+word+"'");
                            foreach (var w in WordList)
                            {
                                if(!w.ToString().ToLower().Contains(word.ToString().ToLower()))
                                {
                                    account.Spelling += 1;
                                }
                            }

                        }
                    }

                }
            }

            return account;
        }



    }
}
