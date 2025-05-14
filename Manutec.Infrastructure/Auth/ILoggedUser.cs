using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Manutec.Infrastructure.Auth;
public interface ILoggedUser
{
    public int WorkShopId {  get;}
    public string Email {  get;}
    public int Role {  get;}
}

public class LoggedUser : ILoggedUser
{
    private readonly IHttpContextAccessor _contextAccessor;

    public LoggedUser(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public int WorkShopId
    {
        get
        {
            var claim = _contextAccessor.HttpContext?.User?.FindFirst("WorkShopId");
            return claim is null ? throw new UnauthorizedAccessException("Usuário sem oficina.") : int.Parse(claim.Value);
        }
    }

    public string Email
    {
        get
        {
            var claim = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email);
            return claim?.Value ?? throw new UnauthorizedAccessException("Usuário sem email.");
        }
    }

    public int Role
    {
        get
        {
            var claim = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role);
            return claim is null ? throw new UnauthorizedAccessException("Usuário sem perfil.") : int.Parse(claim.Value);
        }
    }
}