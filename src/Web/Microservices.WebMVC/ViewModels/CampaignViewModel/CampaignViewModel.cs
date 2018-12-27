namespace Microservices.WebMVC.ViewModels
{
    using Microservices.WebMVC.ViewModels.Annotations;
    using Microservices.WebMVC.ViewModels.Pagination;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CampaignViewModel
    {
        public IEnumerable<CampaignItem> CampaignItems { get; set; }
        public PaginationInfo PaginationInfo { get; set; }

        [LongitudeCoordinate, Required]
        public double Lon { get; set; } = -122.315752;
        [LatitudeCoordinate, Required]
        public double Lat { get; set; } = 47.604610;
    }
}
