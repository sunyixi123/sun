namespace HospitalInformationSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserInfo
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(2)]
        public string RoleID { get; set; }

        public DateTime CreateTime { get; set; }

        [MaxLength(50)]
        public string CreateOperator { get; set; }

        public DateTime UpdaterTime { get; set; }

        [MaxLength(50)]
        public string UpdaterOperator { get; set; }

        public char IsActive { get; set; }
    }

}
