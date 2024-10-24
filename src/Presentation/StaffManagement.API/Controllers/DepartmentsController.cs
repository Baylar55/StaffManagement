using StaffManagement.Application.Features.Commands.Department.CreateDepartment;
using StaffManagement.Application.Features.Commands.Department.DeleteDepartment;
using StaffManagement.Application.Features.Commands.Department.UpdateDepartment;
using StaffManagement.Application.Features.Queries.Department.GetAll;
using StaffManagement.Application.Features.Queries.Department.GetById;

namespace StaffManagement.API.Controllers
{
    /// <summary>
    /// The API controller for managing departments.
    /// </summary>
    public class DepartmentsController : BaseApiController
    {
        /// <summary>
        /// Retrieves a paginated list of all departments.
        /// </summary>
        /// <param name="pagingParams">The pagination parameters, including page number and page size.</param>
        /// <returns>A paginated list of departments with a status code of 200 (OK).</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingParams pagingParams)
        {
            return Ok(await Mediator.Send(new GetAllDepartmentsQueryRequest(pagingParams)));
        }

        /// <summary>
        /// Retrieves a specific department by its ID.
        /// </summary>
        /// <param name="id">The unique ID of the department.</param>
        /// <returns>The department details with a status code of 200 (OK) if found, or 404 (Not Found) if the department does not exist.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetDepartmentByIdQueryRequest(id)));
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="request">The department data for creation.</param>
        /// <returns>A success response with a status code of 201 (Created) if successful, or an error response if the creation fails.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentCommandRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="id">The unique ID of the department to update.</param>
        /// <param name="request">The updated department data.</param>
        /// <returns>A success response with a status code of 204 (No Content) if the update is successful, 
        /// or 400 (Bad Request) if the provided ID does not match the request ID, or 404 (Not Found) if the department does not exist.</returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDepartmentCommandRequest request)
        {
            if (request.Id != id) return BadRequest("Id not match");

            return Ok(await Mediator.Send(request));
        }

        /// <summary>
        /// Deletes an existing department.
        /// </summary>
        /// <param name="request">The department deletion request, containing the department ID to be deleted.</param>
        /// <returns>A success response with a status code of 204 (No Content) if the deletion is successful, or an error response if it fails.</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteDepartmentCommandRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
