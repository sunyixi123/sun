using System;


public class DoctorAppointment
{

    public int AppointmentID { get; set; }

    public int PatientID { get; set; }

    public int ScheduleID { get; set; }

    public int DoctorID { get; set; }

    public DateTime AppointmentDate { get; set; }

    public TimeSpan AppointmentTime { get; set; }

    public string Status { get; set; }

    public string Notes { get; set; }

    public DateTime CreateTime { get; set; }

    public string CreateOperator { get; set; }

    public DateTime UpdaterTime { get; set; }

    public string UpdaterOperator { get; set; }

    public string IsActive { get; set; }
}
