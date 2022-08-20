using Application.Functions.Posts.Queries.GetPostDitail;
using Application.Functions.Posts.Queries.GetPostsList;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Post, PostViewModel>().ReverseMap();
	}
}
