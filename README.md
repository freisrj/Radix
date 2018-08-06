# Teste Radix

```
Projeto de teste da Radix para processo de seleção
```

## Sobre o desenvolvimento do sistema

```
- .Net Core
- Banco de Dados LocalDb
- DDD
- Api Rest
- Testes (Não está contemplando tudo)
- Code First
- Injeção de dependência
```

## Regras

```
- Transações apenas com Cartão de Crédito
- Bandeiras Visa e MasterCard
- Acesso à Cielo e Stone para efetuar Transações
- Cada empresa (Loja) pode ter ou não solicitação a antifraude
- Cada empresa (Loja) relacionará cada bandeira sa cada uma das adquirentes
- Configuração das empresas -> adquirentes devem estar na base de dados 
```

## Validações

```
- Requests com validações
- Dados de entradas com validações
```

## Integrações

```
- Integração com Stone e Cielo
- Dados de retorno no response com sucesso e erro (falha) do cliente.
- Integração de antifraude não implementada
```

## Testes

```
- Não contempla todos os testes
```

## Chamada API

```
- Há duas APIs desenvolvidas: (Post) Transação / (Get) Consulda de Transação
- Utilizei o Postman para chamadas das APIs
```

## Base de dados

```
- Base de dados consta tabelas para armazenar dados de transação e das configurações das lojas
- Criado um seed para alimentar a base com os dados da loja e suas configurações
- Há um cadastro de apenas 4 Clientes.
  * 2 trabalhando com master e visa e os outros 2 com apenas um deles
```

## Build

```
- Build com Visual Studio 2017
```

## Request (Json) - Transação

```
- [Post]
- Url: {Localhost}/api/transaction/create/sale

Json
{ 
	"lojaId" : 1,
	"bandeiraCartao" : 2,
	"Nome" : "Cliente Loja",
	"transacaoCartaoCredito" : [
		{
			"valor" : 1110,
			"parcelas" : 1,
			"descricao" : "123456789ABCD",
			"cartaoCredito" : {
				"numeroCartao" : "5287648493373533",
				"nomeImpressoCartao" : "Jon Snow",
				"mesExpiracao" : "07",
				"anoExpiracao" : "2019",
				"codigoSeguranca" : 462
			}
		}
	]
}
```

## Request (Json) - Consulta Transação

```
- [Get]
- Url: http://localhost:5000/api/transaction/search/transaction/{id}
```

## Autor

```
Luiz Paulo Rodrigues
```
