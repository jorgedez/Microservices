﻿namespace Microservices.WebMVC.ViewModels
{
    using System.Collections.Generic;

    public class Catalog
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<CatalogItem> Data { get; set; }
    }
}
