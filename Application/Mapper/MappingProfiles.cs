using Application.Functions.Categories.Commands;
using Application.Functions.Categories.Queries.GetCategoryList;
using Application.Functions.Categories.Queries.GetCategoryListWithPosts;
using Application.Functions.Posts.Commands.CreatePost;
using Application.Functions.Posts.Commands.UpdatePost;
using Application.Functions.Posts.Queries.GetPostDitail;
using Application.Functions.Posts.Queries.GetPostsList;
using Application.Functions.Webinars.Commands.CreateWebinar;
using Application.Functions.Webinars.Queries.GetWebinar;
using Application.Functions.Webinars.Queries.GetWebinarListByDate;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Post, PostViewModel>().ReverseMap();
		CreateMap<Post, PostDetailViewModel>().ReverseMap();
		CreateMap<Category, CategoryDto>();

		CreateMap<Category, CategoryPostListViewModel>();
		CreateMap<Category, CategoryPostDto>();
		CreateMap<Category, CategoryView>();

		CreateMap<Post, CreatePostCommand>().ReverseMap();
		CreateMap<Post, UpdatePostCommand>().ReverseMap();

		CreateMap<Category, CreateCategoryCommand>().ReverseMap();

		CreateMap<Webinar, WebinarViewModel>().ReverseMap();
		CreateMap<Webinar, WebinarsByDateViewModel>().ReverseMap();
		CreateMap<Webinar, CreateWebinarCommand>();
	}
}
