using Manutec.Core.Entities;

namespace Manutec.Application.Models.WorkShopModel
{
    public class WorkShopViewModelId
    {
        public WorkShopViewModelId(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public static WorkShopViewModelId FromEntity(WorkShop workshop)
        {
            return new WorkShopViewModelId(workshop.Id);
        }
    }
}
