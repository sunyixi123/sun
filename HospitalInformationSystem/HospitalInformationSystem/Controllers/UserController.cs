using AutoMapper;
using HospitalInformationSystem.DBContext;
using HospitalInformationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLog.Fluent;
using System.Configuration;

namespace HospitalInformationSystem.Controllers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MysqlDbContext _context;
        private readonly IMapper _mapper;

        public UserController(MysqlDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return BadRequest();
            }

            userInfo.CreateTime = DateTime.Now;
            userInfo.UpdaterTime = DateTime.Now;

            _context.UserInfo.Add(userInfo);
            _context.SaveChanges();

            return Ok(userInfo);
        }
        [HttpGet("GetUsers")]
        public List<UserInfo> GetUsers()
        {
            // 使用 EF Core 查询用户信息表
            List<UserInfo> users = _context.UserInfo.ToList();

            return users;
        }

        [HttpPost("GetLogin")]
        public bool GetLogin([FromBody] LoginRequest loginRequest)
        {
            // 使用 EF Core 查询用户信息表
            return (_context.Login.Where(t => t.Username == loginRequest.Username && t.Password == loginRequest.Password).Count() > 0);
        }

        [HttpGet("GetLogins")]
        public List<Login> GetLogins()
        {
            // 使用 EF Core 查询用户信息表
            List<Login> Logins = _context.Login.ToList();

            return Logins;
        }

        [HttpPost("setUserInfo")]
        public returnMessage setUserInfo([FromBody] UserLoginDTO UserLoginDTO)
        {
            returnMessage returnMessage = new returnMessage { isSucceed = true, errorManger = "" };

            UserInfo userInfo = _context.UserInfo.FirstOrDefault(t => t.IDNumber == UserLoginDTO.UserInfo.IDNumber);
            Login existinglogin1 = _context.Login.FirstOrDefault(t => t.Username == UserLoginDTO.Login.Username);
            UserInfo existingUserInfo1 = _context.UserInfo.FirstOrDefault(t => t.UserID == UserLoginDTO.Login.UserID);

            if (userInfo != null && existinglogin1?.UserID != userInfo.UserID)
            {
                returnMessage.isSucceed = false;
                returnMessage.errorManger = "身份证重复";
                return returnMessage;
            }

            UserInfo NewUsers = new UserInfo();
            if (existingUserInfo1 != null)
            {
                // 使用 AutoMapper 将 DTO 映射到实体对象
                _context.Entry(existingUserInfo1).State = EntityState.Detached; // 分离实体
                var mappedUserInfo = _mapper.Map(UserLoginDTO.UserInfo, existingUserInfo1);
                _context.Entry(existingUserInfo1).State = EntityState.Modified;
                // 执行更新操作
                _context.SaveChanges();

            }
            else
            {
                _context.UserInfo.Add(UserLoginDTO.UserInfo);
                try
                {
                    _context.SaveChanges();
                    // 使用 EF Core 查询用户信息表
                    NewUsers = _context.UserInfo.FirstOrDefault(t => t.IDNumber == UserLoginDTO.UserInfo.IDNumber);
                }
                catch (DbUpdateConcurrencyException)
                {
                    // 处理并发冲突
                    returnMessage.isSucceed = false;
                    returnMessage.errorManger = "用户更新失败并发冲突";
                    return returnMessage;
                }
            }

            if (existinglogin1 != null)
            {

                // 使用 AutoMapper 将 DTO 映射到实体对象
                _context.Entry(existinglogin1).State = EntityState.Detached; // 分离实体
                var mappedUserInfo = _mapper.Map(UserLoginDTO.Login, existinglogin1);
                _context.Entry(existinglogin1).State = EntityState.Modified;
                // 执行更新操作
                _context.SaveChanges();

            }
            else if (NewUsers != null)
            {
                UserLoginDTO.Login.UserID = NewUsers.UserID;
                _context.Login.Add(UserLoginDTO.Login);
            }



            try
            {
                _context.SaveChanges();
                // 处理并发冲突
                return returnMessage;
            }
            catch (DbUpdateConcurrencyException)
            {
                // 处理并发冲突
                returnMessage.isSucceed = false;
                returnMessage.errorManger = "用户更新失败并发冲突";
                return returnMessage;
            }
        }
        [HttpGet("GetDoctorSchedules")]
        public List<DoctorSchedule> GetDoctorSchedules()
        {
            // 使用 EF Core 查询用户信息表
            List<DoctorSchedule> Logins = _context.DoctorSchedule.ToList();

            return Logins;
        }
        [HttpPost("SetDoctorSchedules")]
        public returnMessage SetDoctorSchedules([FromBody] List<DoctorSchedule> DoctorSchedule)
        {

            returnMessage returnMessage = new returnMessage { isSucceed = true, errorManger = "" };
            foreach (var s in DoctorSchedule)
            {
                DoctorSchedule tempDoctorSchedules = new DoctorSchedule();
                tempDoctorSchedules = _context.DoctorSchedule.FirstOrDefault(t => t.DoctorID == s.DoctorID && t.ScheduleDate == s.ScheduleDate);
                if (tempDoctorSchedules != null)
                {
                    s.ScheduleID = tempDoctorSchedules.ScheduleID;
                    // 使用 AutoMapper 将 DTO 映射到实体对象
                    _context.Entry(tempDoctorSchedules).State = EntityState.Detached; // 分离实体
                    var mappedUserInfo = _mapper.Map(s, tempDoctorSchedules);
                    _context.Entry(tempDoctorSchedules).State = EntityState.Modified;
                }
                else
                {
                    _context.DoctorSchedule.Add(s);
                }
            }
            try
            {
                _context.SaveChanges();
                // 处理并发冲突
            }
            catch (DbUpdateConcurrencyException)
            {
                // 处理并发冲突
                returnMessage.isSucceed = false;
                returnMessage.errorManger = "排班冲突";
            }
            return returnMessage;
        }

        [HttpGet("GetDoctorAppointments")]
        public List<DoctorAppointment> GetDoctorAppointments()
        {
            // 使用 EF Core 查询用户信息表
            List<DoctorAppointment> Logins = _context.DoctorAppointment.ToList();

            return Logins;
        }

        [HttpPost("SetDoctorAppointments")]
        public returnMessage SetDoctorAppointments([FromBody] DoctorAppointment intoDoctorAppointment)
        {
            returnMessage returnMessage = new returnMessage { isSucceed = true, errorManger = "" };

            DoctorAppointment tempDoctorAppointments = _context.DoctorAppointment.FirstOrDefault(t => t.ScheduleID == intoDoctorAppointment.ScheduleID && t.PatientID == intoDoctorAppointment.PatientID);
            if (tempDoctorAppointments != null)
            {
                intoDoctorAppointment.AppointmentID= tempDoctorAppointments.AppointmentID;
                // 使用 AutoMapper 将 DTO 映射到实体对象
                _context.Entry(tempDoctorAppointments).State = EntityState.Detached; // 分离实体
                var mappedDoctorAppointment = _mapper.Map(intoDoctorAppointment, tempDoctorAppointments);
                _context.Entry(tempDoctorAppointments).State = EntityState.Modified;
            }
            else
            {
                _context.DoctorAppointment.Add(intoDoctorAppointment);
            }

            _context.DoctorSchedule.FirstOrDefault(t => t.ScheduleID == intoDoctorAppointment.ScheduleID).MaxAppointmentCount--;

            try
            {
                _context.SaveChanges();
                // 处理并发冲突
                return returnMessage;
            }
            catch (DbUpdateConcurrencyException)
            {
                // 处理并发冲突
                returnMessage.isSucceed = false;
                returnMessage.errorManger = "预约冲突";
                return returnMessage;
            }
        }

        [HttpGet("GetMedicalVisits")]
        public List<MedicalVisit> GetMedicalVisits()
        {
            // 使用 EF Core 查询用户信息表
            List<MedicalVisit> Logins = _context.MedicalVisit.ToList();

            return Logins;
        }

        [HttpPost("SetMedicalVisit")]
        public returnMessage SetMedicalVisit([FromBody] MedicalVisit intoMedicalVisit)
        {
            returnMessage returnMessage = new returnMessage { isSucceed = true, errorManger = "" };

            MedicalVisit tempMedicalVisits = _context.MedicalVisit.FirstOrDefault(t => t.AppointmentID == intoMedicalVisit.AppointmentID && t.PatientID == intoMedicalVisit.PatientID);
            if (tempMedicalVisits != null)
            {
                intoMedicalVisit.VisitID = tempMedicalVisits.VisitID;
                // 使用 AutoMapper 将 DTO 映射到实体对象
                _context.Entry(tempMedicalVisits).State = EntityState.Detached; // 分离实体
                var mappedDoctorAppointment = _mapper.Map(intoMedicalVisit, tempMedicalVisits);
                _context.Entry(tempMedicalVisits).State = EntityState.Modified;
            }
            else
            {
                _context.MedicalVisit.Add(intoMedicalVisit);
            }

            try
            {
                _context.SaveChanges();
                // 处理并发冲突
                return returnMessage;
            }
            catch (DbUpdateConcurrencyException)
            {
                // 处理并发冲突
                returnMessage.isSucceed = false;
                returnMessage.errorManger = "挂号登记失败";
                return returnMessage;
            }
        }

        [HttpGet("GetPrescriptions")]
        public List<Prescription> GetPrescriptions()
        {
            // 使用 EF Core 查询用户信息表
            List<Prescription> Logins = _context.Prescription.ToList();

            return Logins;
        }

        [HttpPost("SetPrescription")]
        public returnMessage SetPrescription([FromBody] Prescription intoPrescription)
        {
            returnMessage returnMessage = new returnMessage { isSucceed = true, errorManger = "" };

            Prescription tempPrescriptions = _context.Prescription.FirstOrDefault(t => t.PrescriptionID == intoPrescription.PrescriptionID && t.PatientID == intoPrescription.PatientID);
            if (tempPrescriptions != null)
            {
                // 使用 AutoMapper 将 DTO 映射到实体对象
                _context.Entry(tempPrescriptions).State = EntityState.Detached; // 分离实体
                var mappedDoctorAppointment = _mapper.Map(intoPrescription, tempPrescriptions);
                _context.Entry(tempPrescriptions).State = EntityState.Modified;
            }
            else
            {
                _context.Prescription.Add(intoPrescription);
            }

            try
            {
                _context.SaveChanges();
                // 处理并发冲突
                return returnMessage;
            }
            catch (DbUpdateConcurrencyException)
            {
                // 处理并发冲突
                returnMessage.isSucceed = false;
                returnMessage.errorManger = "医嘱录入失败";
                return returnMessage;
            }
        }

        [HttpGet("GetMedicalRecords")]
        public List<MedicalRecord> GetMedicalRecords()
        {
            // 使用 EF Core 查询用户信息表
            List<MedicalRecord> Logins = _context.MedicalRecord.ToList();

            return Logins;
        }

        [HttpPost("SetMedicalRecord")]
        public returnMessage SetMedicalRecord([FromBody] MedicalRecord intoMedicalRecord)
        {
            returnMessage returnMessage = new returnMessage { isSucceed = true, errorManger = "" };

            MedicalRecord tempMedicalRecords = _context.MedicalRecord.FirstOrDefault(t => t.VisitID == intoMedicalRecord.VisitID);
            if (tempMedicalRecords != null)
            {
                // 使用 AutoMapper 将 DTO 映射到实体对象
                _context.Entry(tempMedicalRecords).State = EntityState.Detached; // 分离实体
                var mappedDoctorAppointment = _mapper.Map(intoMedicalRecord, tempMedicalRecords);
                _context.Entry(tempMedicalRecords).State = EntityState.Modified;
            }
            else
            {
                _context.MedicalRecord.Add(intoMedicalRecord);
            }

            try
            {
                _context.SaveChanges();
                // 处理并发冲突
                return returnMessage;
            }
            catch (DbUpdateConcurrencyException)
            {
                // 处理并发冲突
                returnMessage.isSucceed = false;
                returnMessage.errorManger = "病历录入失败";
                return returnMessage;
            }
        }
    }
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginDTO
    {
        public UserInfo UserInfo { get; set; }
        public Login Login { get; set; }
    }

    public class returnMessage
    {
        public bool isSucceed { get; set; }
        public string errorManger { get; set; }
    }
}
