﻿using Application.Common;
using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureWithEFRegistration.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(EFContext dbContext) : base(dbContext)
    { }

    public async Task<List<Category>> GetCategoriesWithPost(SearchCategoryOptions searchCategory)
    {
        var allCategories = await _dbContext.Categories.Include(p => p.Posts).ToListAsync();

        if (searchCategory == SearchCategoryOptions.FirstBestAllTheTime)
        {

            foreach (var c in allCategories)
            {
                Post max = null;
                foreach (var p in c.Posts)
                {
                    if (max == null)
                    {
                        max = p;
                        break;
                    }

                    if (max.Rate < p.Rate)
                        max = p;

                }
                c.Posts = new List<Post>();
                if (max != null)
                    c.Posts.Add(max);
            }

            return allCategories;
        }
        else if (searchCategory == SearchCategoryOptions.FirstBestThisMonth)
        {
            DateTime d = DateTime.Now;

            allCategories = allCategories.Where(c =>
            c.Posts.Any(p => (p.Date.Month == d.Month && d.Year == p.Date.Year)))
                .ToList();

            foreach (var c in allCategories)
            {
                Post max = null;
                foreach (var p in c.Posts)
                {
                    if (max == null)
                    {
                        max = p;
                        break;
                    }

                    if (max.Rate < p.Rate)
                        max = p;
                }
                c.Posts = new List<Post>();
                if (max != null)
                    c.Posts.Add(max);
            }
            return allCategories;
        }

        return allCategories;
    }
}
