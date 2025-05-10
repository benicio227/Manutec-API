using Manutec.Application.Models;
using Manutec.Core.Entities;
using MediatR;

namespace Manutec.Application.Commands.WorkShopEntity;
public class InsertWorkShopCommand : IRequest<WorkShopViewModel>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public WorkShop ToEntity()
    {
        return new WorkShop(Name, Email, Phone);
    }
}
