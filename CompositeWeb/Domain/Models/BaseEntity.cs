using System.ComponentModel.DataAnnotations;

namespace CompositeWeb.Domain.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
}