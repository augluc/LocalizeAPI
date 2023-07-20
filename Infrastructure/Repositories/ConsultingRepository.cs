using Core.Entities;
using Core.Repositories.Interfaces;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class ConsultingRepository : IConsultingRepository
{
    private ConsultingContext _context;

    public ConsultingRepository(ConsultingContext context)
    {
        _context = context;
    }

    public Result Consult(string cnpj)
    {
        throw new NotImplementedException();
    }
}
