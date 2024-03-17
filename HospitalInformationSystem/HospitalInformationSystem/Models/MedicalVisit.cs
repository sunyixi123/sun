namespace HospitalInformationSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MedicalVisit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VisitID { get; set; }

        [Required]
        public int AppointmentID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        public int DoctorID { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        [Required]
        public TimeSpan VisitTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [MaxLength(100)]
        public string DiagnosisID { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string CreateOperator { get; set; }

        [Required]
        public DateTime UpdaterTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string UpdaterOperator { get; set; }

        [Required]
        [MaxLength(1)]
        public string IsActive { get; set; }
    }

}
