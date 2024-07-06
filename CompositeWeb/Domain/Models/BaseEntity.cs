using System.ComponentModel.DataAnnotations;

namespace CompositeWeb.Domain.Models;

public abstract class BaseEntity
{
    [Key] public Guid Id { get; set; }
}