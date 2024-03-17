using AutoMapper;
using HospitalInformationSystem.Controllers;
using HospitalInformationSystem.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserInfo, UserInfo>();
        CreateMap<Login, Login>();
        CreateMap<DoctorSchedule, DoctorSchedule>();
        CreateMap<DoctorAppointment, DoctorAppointment>();
        CreateMap<MedicalVisit, MedicalVisit>();
        CreateMap<Prescription, Prescription>();
        CreateMap<MedicalRecord, MedicalRecord>();
    }
}
