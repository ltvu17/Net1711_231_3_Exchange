﻿using Microsoft.AspNetCore.Mvc;

namespace ExchangeWebApp.Models
{
    public class ProductDTO 
    {
        public int Id { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

    public int Status { get; set; } = 1;

    public int StudentId { get; set; } = 2;

        public DateTime CreateOn { get; set; } = new DateTime();

    public DateTime ReportTime { get; set; }

    public double? Rate { get; set; }

    public string Title { get; set; }

    public string? ContentPost { get; set; }

    public double Price { get; set; }

    public string ApproveBy { get; set; }

    public DateTime? ApproveDate { get; set; }

    public int CategoryId { get; set; }
    }
}
