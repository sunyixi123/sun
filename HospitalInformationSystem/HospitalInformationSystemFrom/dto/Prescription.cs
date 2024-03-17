using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystemFrom
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }

        public int VisitID { get; set; }

        public int DoctorID { get; set; }

        public int PatientID { get; set; }

        public DateTime PrescriptionDate { get; set; }

        public string Frequency { get; set; }

        public string Route { get; set; }

        public string Medications { get; set; }

        public decimal? Dosage { get; set; }

        public string Unit { get; set; }

        public decimal? PerUnit { get; set; }

        public string DosagePerUse { get; set; }

        public string Notes { get; set; }
        public DateTime CreateTime { get; set; }


        public string CreateOperator { get; set; }


        public DateTime UpdaterTime { get; set; }


        public string UpdaterOperator { get; set; }

        public string IsActive { get; set; }
    }
}
