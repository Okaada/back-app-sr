using back_app_sr.Domain.Models;
using back_app_sr.Infra.Context;
using back_app_sr.Infra.Repository.Interfaces;

namespace back_app_sr.Infra.Repository.Service;

public class AdditionalRepository : Repository<AdditionalModel>, IAdditionalRepository
{
    public AdditionalRepository(ApplicationContext context) : base(context)
    {
    }
}