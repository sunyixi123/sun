using System;

public class DoctorSchedule
{
    public int ScheduleID { get; set; }
    public int DoctorID { get; set; }
    public DateTime ScheduleDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int MaxAppointmentCount { get; set; }
    public string Department { get; set; }
    public DateTime CreateTime { get; set; }
    public string CreateOperator { get; set; }
    public DateTime UpdaterTime { get; set; }
    public string UpdaterOperator { get; set; }
    public string IsActive { get; set; }
}
