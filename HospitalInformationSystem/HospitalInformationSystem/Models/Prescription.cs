namespace HospitalInformationSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrescriptionID { get; set; }

        [Required]
        public int VisitID { get; set; }

        [Required]
        public int DoctorID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        public DateTime PrescriptionDate { get; set; }

        [MaxLength(200)]
        public string Frequency { get; set; }

        [Required]
        [MaxLength(50)]
        public string Route { get; set; }

        [MaxLength(200)]
        public string Medications { get; set; }

        public decimal? Dosage { get; set; }

        [MaxLength(1)]
        public string Unit { get; set; }

        public decimal? PerUnit { get; set; }

        [MaxLength(1)]
        public string DosagePerUse { get; set; }

        public string Notes { get; set; }

        public DateTime CreateTime { get; set; }


        public string CreateOperator { get; set; }


        public DateTime UpdaterTime { get; set; }


        public string UpdaterOperator { get; set; }

        public string IsActive { get; set; }
    }

}
