using AutoMapper;
using SaracliKend.Application.Models;
using SaracliKend.Domain.Entities;
using SaracliKend.Infrastructure.Utils;
using File = SaracliKend.Domain.Entities.File;

namespace SaracliKend.Application.Mapper;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<Person, PersonModel>().ReverseMap();

		CreateMap<School, SchoolModel>().ReverseMap();

		CreateMap<SliderImage, SliderViewModel>().ReverseMap();

		CreateMap<Legend, LegendVM>().ReverseMap();

		CreateMap<News, NewsViewModel>().ReverseMap();

		CreateMap<File, FileViewModel>().ReverseMap();

		CreateMap<Information, InformationVM>()
			.ForMember(x => x.Images, y => y.MapFrom(z => z.Images.Select(d => d.Path)))
			.ReverseMap()
			.ForMember(x => x.Images, y => y.Ignore());

		CreateMap<FunnyStory, FunnyStoryVM>()
			.ForMember(x => x.Writer, y => y.MapFrom(z => MapperHelper.GetFullname(z.Writer)))
			.ReverseMap();

		CreateMap<Poetry, PoetryVM>()
			.ForMember(x => x.Writer, y => y.MapFrom(z => MapperHelper.GetFullname(z.Writer)))
			.ReverseMap();
	}
}
