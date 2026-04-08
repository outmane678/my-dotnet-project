using testproject.DTOs.Requests;
using testproject.Models.Dto;

namespace testproject.Services.Interfaces;

public interface IEmployeService
{
    Task<EmployeDto> CreateEmployee(CreateEmployeRequest request);
    Task<EmployeDto> GetEmployeeById(int id);
    Task<List<EmployeDto>> GetAllEmployees();
    Task<EmployeDto> UpdateEmployee(int id, UpdateEmployeRequest request);
    Task DeleteEmployee(int id);
}