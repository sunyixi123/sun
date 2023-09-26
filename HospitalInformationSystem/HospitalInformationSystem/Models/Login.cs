using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HospitalInformationSystem.Models
{
    public class Login
    {
        [Key]
        public int UserID { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(255), DefaultValue("111111")]
        public string Password { get; set; }

        public DateTime? LastLogin { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        [Required, StringLength(50)]
        public string CreateOperator { get; set; }

        [Required]
        public DateTime UpdaterTime { get; set; }

        [Required, StringLength(50)]
        public string UpdaterOperator { get; set; }

        [DefaultValue(1)]
        public char IsActive { get; set; }
    }
}
