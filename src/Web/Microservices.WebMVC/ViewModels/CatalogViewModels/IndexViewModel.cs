namespace Microservices.WebMVC.ViewModels.CatalogViewModels
{
    using Microservices.WebMVC.ViewModels.Pagination;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<CatalogItem> CatalogItems { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public int? BrandFilterApplied { get; set; }
        public int? TypesFilterApplied { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
