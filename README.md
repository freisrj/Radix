# Teste Radix - Processo seletivo

```
Projeto de teste da Radix
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

## Testes Unitários

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
- Há disponível 13 bandeiras de cartões sendo que o sistema utiliza apenas a Visa = 1 e MasterCard = 2
```

## Build

```
- Build com Visual Studio 2017
```

## Request (Json) - Transação

```
- [Post]
- Url: {Localhost}/api/transaction/create/sale

	* Os dados de cartão são fictícios
	* Lojas cadastradas possuem o Id de 1 a 4
	* Parcelas limitei de 1 a 12
	* Bandeiras disponíveis para transação: 1 e 2 (No sistema há 13 registradas)

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
	* Lojas cadastradas possuem o Id de 1 a 4
	
- [Get]
- Url: {Localhost}/api/transaction/search/transaction/{id}
```

## Urls de consulta

```
- Gerador de número de cartão de crédito
	* https://www.4devs.com.br/gerador_de_numero_cartao_credito
```

## Outras informações

- Alguns modelos de entidades foram feitos de acordo com os dados disponibilizados pela Cielo e Stone

## Autor

```
Luiz Paulo Rodrigues
```
