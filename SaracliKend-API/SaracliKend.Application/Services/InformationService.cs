using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaracliKend.Application.Models;
using SaracliKend.Application.Services.Contracts;
using SaracliKend.Core.Repositories;
using SaracliKend.Domain.Entities;
using SaracliKend.Domain.Enums;

namespace SaracliKend.Application.Services
{
    public class InformationService : CrudService<InformationVM, Information, IInformationRepository>, IInformationService
    {
        public InformationService(IMapper mapper, IInformationRepository informationRepository) : base(informationRepository, mapper)
        {
        }

        public async Task<InformationVM> GetInformation(InformationType informationType)
        {
            var entity = await EntityDal.GetAll().Include(x => x.Images).FirstOrDefaultAsync(x => x.InformationType == informationType);
            var informationModel = Mapper.Map<InformationVM>(entity);
            return informationModel;
        }

        public async Task UpdateInformation(InformationVM model)
        {
            var entity = Mapper.Map<Information>(model);

            entity.Images = new List<InformationImage>();
            foreach (var image in model.Images)
            {
                entity.Images.Add(new InformationImage { InformationId = model.Id, Path = image });
            }

            if(model?.Images?.Count > 0)
                await EntityDal.RemoveImages(entity);
            else
                await EntityDal.UpdateAsync(entity);
        }

        public async Task CreateInformation(InformationVM model)
        {
            var entity = Mapper.Map<Information>(model);

            entity.Images = new List<InformationImage>();
            foreach (var image in model.Images)
            {
                entity.Images.Add(new InformationImage { InformationId = model.Id, Path = image });
            }

            await EntityDal.CreateAsync(entity);
        }
    }
}
