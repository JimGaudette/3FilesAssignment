#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using _3FilesAssignment.DataModels;
using System.Linq.Dynamic;
using Newtonsoft.Json;
#endregion

namespace _3FilesAssignment
{
   
    /// <summary>
    /// This class provides the requested REST API functionality 
    /// while it appears 
    /// </summary>
    public class RESTProcessor
    {
        private IList<UserData> data;
        public RESTProcessor(IList<UserData> userData)
        {
            data = userData;

        }

        /// <summary>
        /// this method processes rest request strings
        /// </summary>
        /// <param name="RESTString"></param>
        /// <returns></returns>
        public string ProcessRESTString(string RESTString)
        {
            string rslt = "";
            string[] parts = RESTString.Split(' ');
            if (parts[0].Trim().ToLower() == "post")
            {
                post(RESTString);
                return "";
            }

            //  the 13th character starting parse was decided as valid for now with limited implementation description.  If indeed it is to be limited to the requested implementation 
            //  then there is not a need to further 
            //GET /records/
            const int GETSTARTPARSEINDEX = 13;
            var fieldName = RESTString.Substring(GETSTARTPARSEINDEX).ToLower();
            rslt=get(fieldName);




            return rslt;
        }

        /// <summary>
        /// this method allows posting of data lines to the current datalist in memory
        /// </summary>
        /// <param name="RESTString"></param>
        private void post(string RESTString)
        {
            //POST /records
            const int POSTSTRINGSTARTINDEX = 14;
            var inputRecord=RESTString.Substring(POSTSTRINGSTARTINDEX);
            var parseChars = new char[] { ',', '|', ' ' };
            var parseChar=' ';

            foreach (var parsechar in parseChars)
            {
                if (FileProcessor.IsRecordValidWithParser(inputRecord, parsechar))
                {
                    parseChar = parsechar;
                    break;
                }
            }

            var newRecord=FileProcessor.ProcessLine(inputRecord, parseChar);
            data.Add(newRecord);      
            
        }

        private string get() {

            string json = JsonConvert.SerializeObject(data);
            return json;
        }
        private string get(string sortFieldName) {
            var outdata = data.OrderBy(sortFieldName);
            
            string json = JsonConvert.SerializeObject(outdata);
            return json;
        }


    }
}