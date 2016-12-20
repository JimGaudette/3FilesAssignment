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



        public void post()
        {

        }

        public string get() {

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            return json;
        }
        public string get(string sortFieldName) {
            var outdata = data.OrderBy(sortFieldName);
            
            string json = JsonConvert.SerializeObject(outdata, Formatting.Indented);
            return json;
        }


    }
}