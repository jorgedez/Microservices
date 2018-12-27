namespace Microservices.WebMVC.Services
{
    using Microservices.WebMVC.Models;
    using System.Threading.Tasks;

    public interface ILocationService
    {
        Task CreateOrUpdateUserLocation(LocationDTO location);
    }
}
