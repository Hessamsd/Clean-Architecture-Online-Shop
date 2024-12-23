﻿using System.Reflection.PortableExecutable;

namespace ShopManagement.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Picture { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public string CreationDate { get; set; }
    }
}
