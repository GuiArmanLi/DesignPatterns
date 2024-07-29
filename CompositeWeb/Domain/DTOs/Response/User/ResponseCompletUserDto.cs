﻿namespace CompositeWeb.Domain.DTOs.Response.User;

public record ResponseCompletUserDto(
    Guid Id,
    string Name,
    string Email,
    bool IsAccountEnabled,
    DateOnly DateOfBirth,
    bool IsAdult,
    List<Guid> FavoriteBooksId)
{
}