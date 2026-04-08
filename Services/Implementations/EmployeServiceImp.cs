using Microsoft.EntityFrameworkCore;
using testproject.Data;
using testproject.DTOs.Requests;
using testproject.Models;
using testproject.Models.Dto;
using testproject.Services.Interfaces;

namespace testproject.Services.Implementations;

public class EmployeServiceImp : IEmployeService
{
    private readonly AppDbContext _context;

    public EmployeServiceImp(AppDbContext context)
    {
        _context = context;
    }

    public async Task<EmployeDto> CreateEmployee(CreateEmployeRequest request)
    {
        var employee = new Employe
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            HireDate = request.HireDate,
            Position = request.Position
        };

        await _context.Employes.AddAsync(employee);
        await _context.SaveChangesAsync();

        return ToDto(employee);
    }

    public async Task<EmployeDto> GetEmployeeById(int id)
    {
        var employee = await _context.Employes.FirstOrDefaultAsync(e => e.Id == id)
            ?? throw new KeyNotFoundException($"Employe avec Id {id} introuvable.");

        return ToDto(employee);
    }

    public async Task<List<EmployeDto>> GetAllEmployees()
    {
        return await _context.Employes
            .Select(e => new EmployeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Phone = e.Phone,
                HireDate = e.HireDate,
                Position = e.Position
            })
            .ToListAsync();
    }

    public async Task<EmployeDto> UpdateEmployee(int id, UpdateEmployeRequest request)
    {
        var employee = await _context.Employes.FirstOrDefaultAsync(e => e.Id == id)
            ?? throw new KeyNotFoundException($"Employe avec Id {id} introuvable.");

        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Email = request.Email;
        employee.Phone = request.Phone;
        employee.HireDate = request.HireDate;
        employee.Position = request.Position;

        await _context.SaveChangesAsync();

        return ToDto(employee);
    }

    public async Task DeleteEmployee(int id)
    {
        var employee = await _context.Employes.FirstOrDefaultAsync(e => e.Id == id)
            ?? throw new KeyNotFoundException($"Employe avec Id {id} introuvable.");

        _context.Employes.Remove(employee);
        await _context.SaveChangesAsync();
    }

    private static EmployeDto ToDto(Employe employee)
    {
        return new EmployeDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Phone = employee.Phone,
            HireDate = employee.HireDate,
            Position = employee.Position
        };
    }
}