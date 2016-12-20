
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using _3FilesAssignment.DataModels;



namespace _3FilesAssignment
{
    /// <summary>
    /// this class is the input file processor.  The first approach I took was to create a base class that 
    /// that performed the file interactivity and override methods to do the specific processing for the ' ', ',', and '|' files
    /// but since the processing was not different between the files other than the character used in the parsing decided one class was better.
    /// 
    /// 
    /// this class is provided with an input file name and it determines which parse character to use.  It makes the determination by reading all the 
    /// records and makes sure they all produce the expected fields.
    /// 
    /// when the user calls the processfile method the data list is returned.
    /// </summary>
    public class FileProcessor
    {
        protected string FileName = "";
        public char ParseCharacter;
        private bool ParsingCharacterSet = false;

        public FileProcessor(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        ///     this method trys to read the file with each of the possible parsing characters it stops once it can read all the
        ///     records from the file with
        ///     the assigned parsing character
        /// </summary>
        public void DetermineParseCharacter()
        {
            var testCharacters = new char[] {',', '|', ' '};
            foreach (var testchar in testCharacters)
            {
                ParseCharacter = testchar;
                if (IsFileValid())
                {
                    ParsingCharacterSet = true;
                    return;
                }
            }
            throw new Exception("File not in correct format.");
        }


        /// <summary>
        ///     this method reads each line from the file and verifies it can be parsed with the currently assigned parsing
        ///     character
        ///     it does not throw an error it just returns false if an error was encountered.
        /// </summary>
        /// <returns></returns>
        private bool IsFileValid()
        {
            var isValid = true;

            try
            {
                using (var reader = new StreamReader(FileName))
                {
                    string inputLine = "";
                    while ((inputLine = reader.ReadLine()) != null)
                    {
                        if (!IsRecordValidWithParser(inputLine, ParseCharacter))
                        {
                            isValid = false;
                            break;
                            ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// this method does the main processing of this class.  It reads the input file and parses out the fields for each record which is a line on the input file creating 
        /// a list containing instances of the data model reflecting what is in the file that was read as input
        ///  </summary>
        /// <returns> a data model userData containing a parsed representation of the file</returns>
        public IList<UserData> ProcessFile()
        {
            if (!ParsingCharacterSet) DetermineParseCharacter();
            var dataList = new List<UserData>();

            using (var reader = new StreamReader(FileName))
            {
                string inputLine = "";
                while ((inputLine = reader.ReadLine()) != null)
                {
                    dataList.Add(ProcessLine(inputLine, ParseCharacter));
                }
            }

            return dataList;
        }

      
        /// <summary>
        /// this checks to see if the current input string can be parsed to return a complete record using the current parsing character
        /// </summary>
        /// <param name="recordData"></param>
        /// <returns></returns>

        public static bool IsRecordValidWithParser(string recordData, char parsingCharacter)
        {
            int commaCount = recordData.Count(ch => ch == parsingCharacter);
            if (commaCount == 4)
                return true;
            return false;
        }

        /// <summary>
        /// this method takes a string as input and splits that string on the instances of the parsing character
        /// it creates an instances of the data model and places each of the parts split parts into the models data field
        /// </summary>
        /// <param name="recordData"></param>
        /// <returns> a data model with the data fields containing the data obtained from the file</returns>
        public static UserData ProcessLine(string recordData, char parseChar)
        {
            var parts = recordData.Split(parseChar);
            var userData = new UserData
            {
                FirstName = parts[1].Trim(),
                LastName = parts[0].Trim(),
                Gender = parts[2].Trim(),
                FavoriteColor = parts[3].Trim(),
                sDateOfBirth = parts[4].Trim()
            };
            return userData;
        }
    }
}