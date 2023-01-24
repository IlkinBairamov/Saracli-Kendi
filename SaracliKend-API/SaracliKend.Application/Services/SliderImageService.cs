using AutoMapper;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Core.Repositories;
using SaracliKend.Domain.Entities;

namespace SaracliKend.Application.Services;

internal class SliderImageService : CrudService<SliderViewModel, SliderImage, ISliderImageRepository>, ISliderImageService
{
    public SliderImageService(ISliderImageRepository sliderImageRepository, IMapper mapper) : base(sliderImageRepository, mapper)
    {
    }
}
