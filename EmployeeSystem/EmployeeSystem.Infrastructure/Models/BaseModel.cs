using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.Infrastructure.Models;

abstract class BaseModel
{
    [Key]
    public int Id { get; init; }

}
