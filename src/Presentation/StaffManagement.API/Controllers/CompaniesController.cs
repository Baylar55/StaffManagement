using StaffManagement.Application.Features.Commands.Company.CreateCompany;
using StaffManagement.Application.Features.Commands.Company.DeleteCompany;
using StaffManagement.Application.Features.Commands.Company.UpdateCompany;
using StaffManagement.Application.Features.Queries.Company.GetAll;
using StaffManagement.Application.Features.Queries.Company.GetById;

namespace StaffManagement.API.Controllers
{
    /// <summary>
    /// The API controller for managing companies.
    /// </summary>
    public class CompaniesController : BaseApiController
    {
        /// <summary>
        /// Retrieves a paginated list of all companies.
        /// </summary>
        /// <param name="pagingParams">The pagination parameters, including page number and page size.</param>
        /// <returns>A paginated list of companies</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PagingParams pagingParams)
        {
            return Ok(await Mediator.Send(new GetAllCompanyQueryRequest(pagingParams)));
        }

        /// <summary>
        /// Retrieves a specific company by its ID.
        /// </summary>
        /// <param name="id">The unique ID of the company.</param>
        /// <returns>The company details with a status code of 200 (OK) if found, or 404 (Not Found) if the company does not exist.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCompanyByIdQueryRequest(id)));
        }

        /// <summary>
        /// Creates a new company.
        /// </summary>
        /// <param name="request">The company data for creation.</param>
        /// <returns>A success response with a status code of 201 (Created) if successful, or an error response if the creation fails.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommandRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        /// <summary>
        /// Updates an existing company.
        /// </summary>
        /// <param name="id">The unique ID of the company to update.</param>
        /// <param name="request">The updated company data.</param>
        /// <returns>A success response with a status code of 204 (No Content) if the update is successful, 
        /// or 400 (Bad Request) if the provided ID does not match the request ID, or 404 (Not Found) if the company does not exist.</returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCompanyCommandRequest request)
        {
            if (request.Id != id) return BadRequest("Id not match");

            return Ok(await Mediator.Send(request));
        }

        /// <summary>
        /// Deletes an existing company.
        /// </summary>
        /// <param name="request">The company deletion request, containing the company ID to be deleted.</param>
        /// <returns>A success response with a status code of 204 (No Content) if the deletion is successful, or an error response if it fails.</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteCompanyCommandRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }

}
