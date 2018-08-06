using FluentAssertions;
using NSubstitute;
using Radix.Domain.HttpServices;
using Radix.Domain.Models.Entities.Radix;
using Radix.Domain.Models.EnumTypes;
using Radix.Domain.Services.Contracts.Entities;
using Radix.Domain.Services.Contracts.Infra.Data.UoW;
using Radix.Domain.Services.Contracts.ServiceClient;
using Radix.Domain.Services.Imp.Tasks;
using Radix.Tests.ModelTests;
using Xunit;

namespace Radix.Tests
{
    public class RadixTests
    {
        private const int LOJA_INVALIDA = 10;
        private const CreditCardBrandEnum BANDEIRA_CARTAO_INVALIDO = CreditCardBrandEnum.Amex;


        private readonly IServiceClient _serviceClient;
        private readonly ILojaEntityService _lojaEntityService;
        private readonly IUnitOfWork _unitOfWork;
        public RadixTests()
        {
            _serviceClient = Substitute.For<IServiceClient>();
            _lojaEntityService = Substitute.For<ILojaEntityService>();
            _unitOfWork = Substitute.For<IUnitOfWork>();

            _serviceClient.TransacitonAsync(Models.CieloRequest()).Returns(Models.CieloResponse());
        }

        private bool ValidadarDadosDeEntrada(HttpResult<Loja> loja, CreditCardBrandEnum bandeira)
        {
            TransactionServiceTask transaction = new TransactionServiceTask(_unitOfWork, _serviceClient, _lojaEntityService);
            return transaction.ValidadarDadosDeEntrada(loja, bandeira);
        }        

        [Fact]
        public void Bandeira_Invalida()
        {
            bool validacao = ValidadarDadosDeEntrada(new HttpResult<Loja>(), BANDEIRA_CARTAO_INVALIDO);
            validacao.Should().BeFalse();
        } 
    }
}
