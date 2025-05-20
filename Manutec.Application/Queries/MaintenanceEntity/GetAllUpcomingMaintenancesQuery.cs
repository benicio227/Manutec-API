using Manutec.Application.Models;
using Manutec.Application.Models.MaintenanceModel;
using MediatR;

namespace Manutec.Application.Queries.MaintenanceEntity;
public class GetAllUpcomingMaintenancesQuery : IRequest<ResultViewModel<List<UpcomingMaintenanceViewModel>>>
{
    public int WorkShopId {  get; set; }
}
