using StaffManagement.Application.Features.Commands.Employee.CreateEmployee;
using StaffManagement.Application.Features.Commands.Employee.DeleteEmployee;
using StaffManagement.Application.Features.Commands.Employee.UpdateEmployee;
using StaffManagement.Application.Features.Queries.Employee.GetAll;
using StaffManagement.Application.Features.Queries.Employee.GetById;

namespace StaffManagement.API.Controllers
{
    /// <summary>
    /// The API controller for managing employees.
    /// </summary>
    public class EmployeesController : BaseApiController
    {
        /// <summary>
        /// Retrieves a paginated and filtered list of employees.
        /// </summary>
        /// <param name="pagingParams">The pagination parameters, including page number and page size.</param>
        /// <param name="filterParams">The filter parameters for employee search (e.g., name, surname, department).</param>
        /// <returns>A paginated and filtered list of employees with a status code of 200 (OK).</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingParams pagingParams, [FromQuery] EmployeeFilterParams filterParams)
        {
            return Ok(await Mediator.Send(new GetAllEmployeesQueryRequest(filterParams, pagingParams)));
        }

        /// <summary>
        /// Retrieves a specific employee by their ID.
        /// </summary>
        /// <param name="id">The unique ID of the employee.</param>
        /// <returns>The employee details with a status code of 200 (OK) if found, or 404 (Not Found) if the employee does not exist.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetEmployeeByIdQueryRequest(id)));
        }

        /// <summary>
        /// Creates a new employee.
        /// </summary>
        /// <param name="request">The employee data for creation.</param>
        /// <returns>A success response with a status code of 201 (Created) if successful, or an error response if the creation fails.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommandRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        /// <summary>
        /// Updates an existing employee.
        /// </summary>
        /// <param name="id">The unique ID of the employee to update.</param>
        /// <param name="request">The updated employee data.</param>
        /// <returns>A success response with a status code of 204 (No Content) if the update is successful, 
        /// or 400 (Bad Request) if the provided ID does not match the request ID, or 404 (Not Found) if the employee does not exist.</returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeCommandRequest request)
        {
            if (request.Id != id) return BadRequest("Id not match");

            return Ok(await Mediator.Send(request));
        }

        /// <summary>
        /// Deletes an existing employee.
        /// </summary>
        /// <param name="request">The employee deletion request, containing the employee ID to be deleted.</param>
        /// <returns>A success response with a status code of 204 (No Content) if the deletion is successful, or an error response if it fails.</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteEmployeeCommandRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
