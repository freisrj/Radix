using Radix.Domain.Models.Entities.Radix;
using Radix.Domain.Services.Contracts.Entities;
using Radix.Domain.Services.Contracts.Infra.Data.Repositories;
using Radix.Domain.Services.Contracts.Infra.Data.UoW;
using Radix.Domain.Services.Imp.Entities.Base;
using System.Threading.Tasks;

namespace Radix.Domain.Services.Imp.Entities
{
    public class LojaEntityService : BaseService, ILojaEntityService
    {
        private readonly ILojaRepository _lojaRepository;

        public LojaEntityService(IUnitOfWork unitOfWork, ILojaRepository lojaRepository) : base(unitOfWork) { _lojaRepository = lojaRepository; }

        public async Task<Loja> ObterLojaComCartao(int id) => await _lojaRepository.ObterLojaComCartao(id);
        public async Task<Loja> ObterLojaComTransacoes(int id) => await _lojaRepository.ObterLojaComTransacoes(id);
    }
}
