

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Readio.Core.Exceptions;
using Readio.Core.Model.Response;
using Readio.Model.Author.Dtos.Update;
using Readio.Model.User.Dtos.Create;
using Readio.Model.User.Dtos.Global;
using Readio.Model.User.Dtos.Update;
using Readio.Model.User.Entity;
using Readio.Service.User.Abstracts;
using Readio.Service.User.Rules;
using System.Net;

namespace Readio.Service.User.Concretes;

public class UserService : IUserService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;
    public UserService(UserManager<UserEntity> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager,UserBusinessRules userBusinessRules)
    {
        _userManager = userManager;
        _mapper = mapper;
        _roleManager = roleManager;
        _userBusinessRules = userBusinessRules;
    }
    public async Task<OperationResponse<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
    {
        var user = new UserEntity { Email = createUserDto.Email, UserName = createUserDto.UserName };
        var result = await _userManager.CreateAsync(user, createUserDto.Password);

        var role = await _userManager.AddToRoleAsync(user, "user");
        if (!role.Succeeded)
        {
            throw new BusinessException(role.Errors.First().Description);
        }

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description).ToList();
            return OperationResponse<UserDto>.Fail(errors, HttpStatusCode.BadRequest);
        }
        var userAsDto = _mapper.Map<UserDto>(user);

        return OperationResponse<UserDto>.Success(userAsDto,"Kullanıcı Oluşturuldu.",HttpStatusCode.Created);
    }

    public async Task<OperationResponse> CreateUserRolesAsync(string userName, List<string> roles)
    {
        if (roles == null || !roles.Any())
        {
            throw new BusinessException("Atanacak roller belirtilmelidir.");
        }

        
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        foreach (var role in roles)
        {
            
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole { Name = role });
                if (!roleResult.Succeeded)
                {
                    throw new BusinessException($"Rol oluşturulurken hata oluştu: {role}");
                }
            }

            
            var addToRoleResult = await _userManager.AddToRoleAsync(user, role);
            if (!addToRoleResult.Succeeded)
            {
                throw new BusinessException($"Kullanıcıya rol atanırken hata oluştu: {role}");
            }
        }

        
        return OperationResponse.Success("Roller başarıyla eklendi.", HttpStatusCode.Created);
    }


    public async Task<OperationResponse> DeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.First().Description);
        }

        return OperationResponse.Success("Kullanıcı silindi.", HttpStatusCode.NoContent);
    }

    public async Task<OperationResponse<List<UserDto>>> GetAllAsync()
    {
        var users = _userManager.Users.ToList();
        if (!users.Any())
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        var userDtos = _mapper.Map<List<UserDto>>(users);
        return OperationResponse<List<UserDto>>.Success(userDtos, "Kullanıcılar listelendi.", HttpStatusCode.OK);
    }

    public async Task<OperationResponse<UserDto>> GetByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        var userDto = _mapper.Map<UserDto>(user);
        return OperationResponse<UserDto>.Success(userDto, "Kullanıcı getirildi.", HttpStatusCode.OK);
    }

    public async Task<OperationResponse<UserDto>> GetUserByNameAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
        {
            return OperationResponse<UserDto>.Fail("UserName bulunamadı", HttpStatusCode.NotFound);
        }
        var userAsDto = _mapper.Map<UserDto>(user);
        return OperationResponse<UserDto>.Success(userAsDto,"Kullanıcı gösterildi.",HttpStatusCode.OK);
    }

    public async Task<OperationResponse> UpdateAsync(string id,UpdateUserRequest request)
    {
        var user = await _userManager.FindByIdAsync(id);
        if(user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı");
        }

        user.UserName = request.UserName;
        
        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded is false)
        {
            throw new BusinessException(result.Errors.First().Description);
        }

        return OperationResponse.Success("Kullanıcı güncellendi.", HttpStatusCode.NoContent);
    }
}
