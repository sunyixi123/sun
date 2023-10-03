
using System;
using System.ComponentModel;

namespace HospitalInformationSystemFrom
{
    public class Login
    {
        
        public int UserID { get; set; }

        
        public string Username { get; set; }


        public string Password { get; set; }

        public DateTime? LastLogin { get; set; }


        public DateTime CreateTime { get; set; }


        public string CreateOperator { get; set; }


        public DateTime UpdaterTime { get; set; }


        public string UpdaterOperator { get; set; }

        public string IsActive { get; set; }
    }
}
