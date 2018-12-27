namespace Microservices.WebMVC.Services
{
    using Microservices.WebMVC.ViewModels;
    using System.Threading.Tasks;

    public interface ICampaignService
    {
        Task<Campaign> GetCampaigns(int pageSize, int pageIndex);

        Task<CampaignItem> GetCampaignById(int id);
    }
}
