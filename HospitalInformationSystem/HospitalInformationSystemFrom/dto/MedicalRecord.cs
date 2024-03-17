using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystemFrom
{
    public class MedicalRecord
    {

        public int RecordID { get; set; }

        public int VisitID { get; set; }

        public int PatientID { get; set; }
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
