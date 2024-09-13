﻿using PracticeProject.Model.CustomerAndProducts;

namespace PracticeProject.Core.DashboardClasses.Interface
{
    public interface ITopSellingProducts
    {
        List<TopSellingProductResponseModel> GetTopFiveSellingProduct(int year);
    }
}