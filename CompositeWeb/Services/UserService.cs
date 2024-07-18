using CompositeWeb.Data.Repositories.Interfaces;
using CompositeWeb.Domain.DTOs;
using CompositeWeb.Services.Interfaces;

namespace CompositeWeb.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<UserService> _logger;

    public UserService(IUserRepository userRepository, ILogger<UserService> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public Task<List<ResponseUserDTO>> FindAllUsers()
    {
        return Task.FromResult(_userRepository.FindAllUsersAsync().Result.Select(user => new ResponseUserDTO()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            DateOfBirth = user.DateOfBirth,
            IsAdult = user.IsAdult,
            IsAccountEnabled = user.IsAccountEnabled,
            FavoriteBookId = user.FavoriteBookId
        }).ToList());
    }

    public async Task<ResponseUserDTO?> FindByIdAsync(Guid id)
    {
        return await _userRepository.FindByIdAsync(id) ??
               throw new ArgumentNullException($"{nameof(id)} invalid");
    }

    public async Task<ResponseUserDTO?> FindUserByProperty(RequestUserDtoRegister request)
    {
        return await _userRepository.FindUserByPropertyAsync(request) ??
               throw new ArgumentNullException($"{nameof(request)} invalid");
    }

    public async Task<ResponseUserDTO?> RegisterUserAsync(RequestUserDtoRegister request)
    {
        return await _userRepository.RegisterUser(request) ??
               throw new ArgumentNullException($"{nameof(request)} invalid");
    }

    public async Task<ResponseUserDTO?> UpdateUser(Guid id, RequestUserDtoUpdate request)
    {
        return await _userRepository.UpdateUser(id, request) ??
               throw new ArgumentNullException($"{nameof(request)} invalid");
    }


    // public async Task<ResponseUserDTO?> UpdateUserPartialAsync(Guid id, RequestUserDTO request)
    // {
    //     _userRepository.UpdateUserPartialAsync(id, request);
    //     return null;
    // }

    public async Task<ResponseUserDTO?> DisableAccount(Guid id)
    {
        return await _userRepository.DisableAccountAsync(id) ??
               throw new ArgumentNullException($"{nameof(id)} invalid");
    }


    public async Task<ResponseUserDTO?> DeleteUserAsync(Guid id)
    {
        // return await _userRepository.DeleteUserAsync(id) ??
        // throw new ArgumentNullException($"{nameof(id)} invalid");
        return new ResponseUserDTO();
    }
}