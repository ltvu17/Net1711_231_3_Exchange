using ExchangeBusiness;
using ExchangeBusiness.Models;
using ExchangeData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExchangeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentBusiness _business;

        public StudentController()
        {
            _business = new StudentBusiness();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _business.GetAll();

            if (result.Status > 0)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpGet]
        [Route("GetAllOnLoad")]
        public async Task<IActionResult> GetAllOnLoad()
        {
            var result = await _business.GetAll();
            List<Student>? stulist = result.Data as List<Student>;

            var today = DateTime.Now;
            var firstDayOfCurrentMonth = new DateTime(today.Year, today.Month, 1);
            var firstDayOfNextMonth = firstDayOfCurrentMonth.AddMonths(1);
            var lastDayOfCurrentMonth = firstDayOfNextMonth.AddDays(-1);

            OnLoadDTO onLoadDTO =  new OnLoadDTO()
            {
                studentList = stulist,
                total_user = stulist.Count(),
                total_active = stulist.Count( u => u.Status == 1),
                total_Inactive = stulist.Count(u => u.Status == 0),
                new_user_inmonth = stulist.Count( u => u.CreatedDate >= firstDayOfCurrentMonth && u.CreatedDate<= lastDayOfCurrentMonth)
            };
            return Ok(onLoadDTO);
        }

        [HttpGet]
        [Route("GetStudent")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _business.GetByID(id);

            if (result.Status > 0)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpPost]
        [Route("CreateStudents")]
        public async Task<IActionResult> CreateStudents(StudentDTO Student)
        {
            var result = await _business.CreateStudent(Student);

            if (result.Status > 0)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

        [HttpPut]
        [Route("UpdateStudents")]
        public async Task<IActionResult> UpdateStudents(StudentDTO Student)
        {
            var result = await _business.UpdateStudent(Student);

            if (result.Status > 0)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }


        [HttpDelete]
        [Route("DeleteStudents")]
        public async Task<IActionResult> DeleteStudents(int id)
        {
            var result = await _business.DeleteStudent(id);

            if (result.Status > 0)
            {
                return Ok(result.Data);
            }
            else
            {
                return NotFound(result.Message);
            }
        }

    }
}