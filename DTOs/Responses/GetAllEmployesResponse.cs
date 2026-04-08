using testproject.Models.Dto;

namespace testproject.DTOs.Responses;

public class GetAllEmployesResponse
{
    public List<EmployeDto> Employes { get; set; } = [];
}
