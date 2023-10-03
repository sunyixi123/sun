using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DoctorSchedule
{
    [Key]
    public int ScheduleID { get; set; }

    [Required]
    public int DoctorID { get; set; }

    [Required]
    public DateTime ScheduleDate { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }

    public int MaxAppointmentCount { get; set; }

    [Required]
    [MaxLength(100)]
    public string Department { get; set; }

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
