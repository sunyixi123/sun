namespace HospitalInformationSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MedicalRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordID { get; set; }

        [Required]
        public int VisitID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        public int DoctorID { get; set; }

        public string Diagnosis { get; set; }

        public string TreatmentPlan { get; set; }

        public DateTime CreateTime { get; set; }


        public string CreateOperator { get; set; }


        public DateTime UpdaterTime { get; set; }


        public string UpdaterOperator { get; set; }

        public string IsActive { get; set; }
    }

}
