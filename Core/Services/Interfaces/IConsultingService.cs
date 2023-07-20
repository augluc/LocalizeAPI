using Core.Entities;

namespace Core.Services.Interfaces
{
    public interface IConsultingService
    {
        public Task<Result> Consult(string cnpj);
    }
}
