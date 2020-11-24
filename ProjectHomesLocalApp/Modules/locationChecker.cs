using Dapper;
using ProjectHomesLocalApp.Modles;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace ProjectHomesLocalApp.Modules
{
    class locationChecker
    {
       public static accountModel calculateRegion(accountModel account)
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

                        var regionList = cnn.Query<regionModel>("SELECT ID , Word , File From WordsList WHERE Word = '"+word+"'");

                            foreach(var region in regionList)
                            {
                                if (region.File.Contains("australian") && !region.File.Contains("variant"))
                                {
                                    account.AustralianCount += 1;
                                }
                                if (region.File.Contains("british") && !region.File.Contains("variant"))
                                {
                                    account.BritishCount += 1;
                                }
                                if (region.File.Contains("american") && !region.File.Contains("variant"))
                                {
                                    account.AmericanCount += 1;
                                }
                                if (region.File.Contains("canadian") && !region.File.Contains("variant"))
                                {
                                    account.CanadianCount += 1;
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
