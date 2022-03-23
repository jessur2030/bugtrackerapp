﻿
namespace BugTrackerAppLibrary.DataAccess;

public interface ICategoryData
{
    Task CreateCategory(CategoryModel category);
    Task<List<CategoryModel>> GetAllCategories();
}