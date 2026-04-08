using Microsoft.AspNetCore.Mvc;
using testproject.DTOs.Requests;
using testproject.DTOs.Responses;
using testproject.Services.Implementations;

namespace testproject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployesController : ControllerBase
{
    private readonly EmployeServiceImp _employeService;

    public EmployesController(EmployeServiceImp employeService)
    {
        _employeService = employeService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateEmployeResponse>> Create([FromBody] CreateEmployeRequest request)
    {
        var employe = await _employeService.CreateEmployee(request);
        return CreatedAtAction(nameof(GetById), new { id = employe.Id }, new CreateEmployeResponse
        {
            Employe = employe
        });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetEmployeByIdResponse>> GetById(int id)
    {
        try
        {
            var employe = await _employeService.GetEmployeeById(id);
            return Ok(new GetEmployeByIdResponse { Employe = employe });
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public async Task<ActionResult<GetAllEmployesResponse>> GetAll()
    {
        var employes = await _employeService.GetAllEmployees();
        return Ok(new GetAllEmployesResponse { Employes = employes });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<UpdateEmployeResponse>> Update(int id, [FromBody] UpdateEmployeRequest request)
    {
        try
        {
            var employe = await _employeService.UpdateEmployee(id, request);
            return Ok(new UpdateEmployeResponse { Employe = employe });
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _employeService.DeleteEmployee(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
