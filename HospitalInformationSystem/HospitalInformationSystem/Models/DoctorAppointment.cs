using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DoctorAppointment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AppointmentID { get; set; }

    public int PatientID { get; set; }

    public int ScheduleID { get; set; }

    public int DoctorID { get; set; }

    [Required]
    public DateTime AppointmentDate { get; set; }

    [Required]
    public TimeSpan AppointmentTime { get; set; }

    [Required]
    public string Status { get; set; }

    public string Notes { get; set; }

    [Required]
    public DateTime CreateTime { get; set; } = DateTime.Now;

    [Required]
    [MaxLength(50)]
    public string CreateOperator { get; set; } = "管理员";

    [Required]
    public DateTime UpdaterTime { get; set; }=DateTime.Now;

    [Required]
    [MaxLength(50)]
    public string UpdaterOperator { get; set; } = "管理员";

    [Required]
    public string IsActive { get; set; } = "1";
}
