using Core.Entities;

namespace Core.Repositories.Interfaces;

public interface IConsultingRepository
{
    public Result Consult(string cnpj);
}
