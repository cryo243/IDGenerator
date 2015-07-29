using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGenerator.Models
{
    public class User
    {
        private long? _generatedID;
        public string dateOfBirth { get; set; }
        public string gender { get; set; }
        public string country { get; set; }
        public int race { get; set; }


        private long? _generateID()
        {
            long? value = null;
            long result;
            var strIDBuilder = this.dateOfBirth;
            strIDBuilder += (this.gender == "male") ? Convert.ToString(Utilities.GetRandomNumber(5000, 9999)) : Convert.ToString(Utilities.GetRandomNumber(0, 4999));
            strIDBuilder += (this.country == "SA") ? "0" : "1";
            strIDBuilder +=Convert.ToString(Utilities.GetRandomNumber(8, 9));
            strIDBuilder += Convert.ToString(Utilities.GetControlDigit(strIDBuilder));

            return value = long.TryParse(strIDBuilder, out result)? result:value;

        }

        public long? getGeneratedID()
        {
            if (_generatedID == null)
            {
                _generatedID = _generateID();
            }
            return _generatedID;
        }
        
    }
}