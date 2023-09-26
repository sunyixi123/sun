namespace HospitalInformationSystemFrom
{
    using System;


    public class UserInfo
    {
  
        public int UserID { get; set; }


        public string Name { get; set; }


        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }


        public string Address { get; set; }


        public string PhoneNumber { get; set; }

        public string Email { get; set; }


        public string RoleID { get; set; }

        public DateTime CreateTime { get; set; }


        public string CreateOperator { get; set; }

        public DateTime UpdaterTime { get; set; }

        public string UpdaterOperator { get; set; }

        public char IsActive { get; set; }
    }

}
