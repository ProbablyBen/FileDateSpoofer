using System;
using System.IO;

namespace FileDateSpoofer
{
    class Program
    {

        /// <summary>
        /// Exit Codes
        ///     0 : Proper Exit
        ///     1 : Exception Thrown
        /// </summary>
        private static string filePath;

        static void Main(string[] args)
        {
            bool fileExists = false;
            do
            {
                Console.Write("Enter the file you would like to spoof: ");
                filePath = Console.ReadLine();
                fileExists = File.Exists(filePath);
            } while (!fileExists);

            while (true)
            {
                Console.WriteLine("What would you like to do to the file?");
                Console.WriteLine("1) Set creation time");
                Console.WriteLine("2) Set last accessed time");
                Console.WriteLine("3) Set last modified time");
                Console.WriteLine("4) Exit");
                Console.Write("Input: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        SetCreationTime(filePath);
                        break;
                    case "2":
                        SetLastAccessedTime(filePath);
                        break;
                    case "3":
                        SetLastModifiedTime(filePath);
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static void SetCreationTime(string path)
        {
            Console.WriteLine("Setting file creation time");
            DateTime CreationTime = GetDate();
            File.SetCreationTime(filePath, CreationTime);
            Console.WriteLine("Set the creation time to : {0}", CreationTime);
        }
        static void SetLastAccessedTime(string path)
        {
            Console.WriteLine("Setting last accessed time");
            DateTime LastAccessed = GetDate();
            File.SetLastAccessTime(filePath, LastAccessed);
            Console.WriteLine("Set the last accessed time to : {0}", LastAccessed);
        }
        static void SetLastModifiedTime(string path)
        {
            Console.WriteLine("Setting last modified time");
            DateTime LastModified = GetDate();
            File.SetLastWriteTime(filePath, GetDate());
            Console.WriteLine("Set the last modified time to : {0}", LastModified);
        }
        static DateTime GetDate()
        {
            #region Year
            bool validIntYear = false;
            int intYear;
            do
            {
                Console.Write("Year: ");
                string strYear = Console.ReadLine();
                validIntYear = int.TryParse(strYear, out intYear);
            } while (!validIntYear);
            #endregion
            #region Month
            bool validIntMonth = false;
            int intMonth;
            do
            {
                Console.Write("Month: ");
                string strMonth = Console.ReadLine();
                validIntMonth = int.TryParse(strMonth, out intMonth);
            } while (!validIntMonth);
            #endregion
            #region Day
            bool validIntDay = false;
            int intDay;
            do
            {
                Console.Write("Day: ");
                string strDay = Console.ReadLine();
                validIntDay = int.TryParse(strDay, out intDay);
            } while (!validIntDay);
            #endregion
            #region Hour
            bool validIntHour = false;
            int intHour;
            do
            {
                Console.Write("Hour: ");
                string strHour = Console.ReadLine();
                validIntHour = int.TryParse(strHour, out intHour);
            } while (!validIntHour);
            #endregion
            #region Minute
            bool validIntMinute = false;
            int intMinute;
            do
            {
                Console.Write("Minute: ");
                string strMinute = Console.ReadLine();
                validIntMinute = int.TryParse(strMinute, out intMinute);
            } while (!validIntMinute);
            #endregion
            try
            {
                Random randSecGen = new Random();
                return new DateTime(intYear, intMonth, intDay, intHour, intMinute, randSecGen.Next(0,61));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exiting in 5 seconds...");
                System.Threading.Thread.Sleep(5000);
                Environment.Exit(1);
            }
            return new DateTime();
        }
    }
}

