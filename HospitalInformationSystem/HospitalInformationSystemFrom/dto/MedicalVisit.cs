using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MedicalVisit
{
    public int VisitID { get; set; }

    public int AppointmentID { get; set; }

    public int PatientID { get; set; }

    public int DoctorID { get; set; }

    public DateTime VisitDate { get; set; }

    public TimeSpan VisitTime { get; set; }

    public string Status { get; set; }

    public string DiagnosisID { get; set; }

    public DateTime CreateTime { get; set; } = DateTime.Now;

    public string CreateOperator { get; set; } = "管理员";

    public DateTime UpdaterTime { get; set; } = DateTime.Now;

    public string UpdaterOperator { get; set; } = "管理员";

    public string IsActive { get; set; } = "1";
}

