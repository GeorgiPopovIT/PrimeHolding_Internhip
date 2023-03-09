using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.Infrastructure.Models;

public abstract class BaseModel
{
    [Key]
    public int Id { get; init; }

}
