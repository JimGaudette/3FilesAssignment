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


            //GET /records/
            var fieldName = RESTString.Substring(13).ToLower();
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
            var inputRecord=RESTString.Substring(14);
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

        public string get() {

            string json = JsonConvert.SerializeObject(data);
            return json;
        }
        public string get(string sortFieldName) {
            var outdata = data.OrderBy(sortFieldName);
            
            string json = JsonConvert.SerializeObject(outdata);
            return json;
        }


    }
}