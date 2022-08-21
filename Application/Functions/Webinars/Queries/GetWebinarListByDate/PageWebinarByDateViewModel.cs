﻿namespace Application.Functions.Webinars.Queries.GetWebinarListByDate;

public class PageWebinarByDateViewModel
{
    public int PageSize { get; set; }

    public int Page { get; set; }

    public int AllCount { get; set; }

    public ICollection<WebinarsByDateViewModel>? Webinars { get; set; }
}
