﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
    public partial class records
    {
        private static readonly records _instance = new records();

        public records() { }
        public static records Instance
        {
            get { return _instance; }
        }
        private List<User> data = new List<User>() {
            new User { FirstName="pierce",LastName="1gaudette",gender="male",sDateOfBirth="11/15/2012",FavoriteColor="blue" },
            new User { FirstName="jimmy",LastName="g",gender="male",sDateOfBirth="04/25/1971",FavoriteColor="red" } };

        public List<User> userList
        {
            get
            {
                return data;
            }
        }


    }
}