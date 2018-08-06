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

## Response - Transação
Status 200 (Poucas vezes consegui efetuar transação com cartão Visa. O do exemplo é MasterCard)
```
{
    "retorno": {
        "id": 1,
        "nome": "Loja A",
        "cartoes": [
            {
                "id": 1,
                "bandeira": 1,
                "adquirente": 2,
                "antiFraude": true,
                "lojaId": 1
            },
            {
                "id": 2,
                "bandeira": 2,
                "adquirente": 1,
                "antiFraude": true,
                "lojaId": 1
            }
        ],
        "registroTransacaoCielo": null,
        "registroTransacaoStone": [
            {
                "orderReference": "2018861987",
                "acquirerMessage": "Simulator|Transação de simulação autorizada com sucesso",
                "authorizationCode": "508314",
                "transactionIdentifier": "45444",
                "transactionKey": "30d3db10-5d60-4ec7-b3fd-2398b0361a41",
                "uniqueSequentialNumber": "791697"
            }
        ]
    },
    "mensagem": null
}
```

Status 400 (Possíveis retornos)
``` 
Json
{
    "retorno": null,
    "mensagem": "Não foi possível efeturar a transação. Erro: 57 - Card Expired"
}
---
{
    "retorno": null,
    "mensagem": "Não foi possível efeturar a transação. Erro: 78 - Blocked Card"
}
```


## Response - Transação

- Quanto há registros

```
{
    "retorno": {
        "id": 1,
        "nome": "Loja A",
        "cartoes": null,
        "registroTransacaoCielo": [],
        "registroTransacaoStone": [
            {
                "orderReference": "2018861987",
                "acquirerMessage": "Simulator|Transação de simulação autorizada com sucesso",
                "authorizationCode": "508314",
                "transactionIdentifier": "45444",
                "transactionKey": "30d3db10-5d60-4ec7-b3fd-2398b0361a41",
                "uniqueSequentialNumber": "791697"
            },
            {
                "orderReference": "2018882768",
                "acquirerMessage": "Simulator|Transação de simulação autorizada com sucesso",
                "authorizationCode": "349423",
                "transactionIdentifier": "215297",
                "transactionKey": "453fdf13-0230-483b-bdc5-cd578fc403b7",
                "uniqueSequentialNumber": "214198"
            }
        ]
    },
    "mensagem": null
}
```

- Quando não há registros

```

{
    "retorno": {
        "id": 2,
        "nome": "Loja B",
        "cartoes": null,
        "registroTransacaoCielo": [],
        "registroTransacaoStone": []
    },
    "mensagem": null
}

```

## Urls de consulta

```
- Gerador de número de cartão de crédito
	* https://www.4devs.com.br/gerador_de_numero_cartao_credito
```

## Outras informações

- Alguns modelos de entidades foram feitos de acordo com os dados disponibilizados pela Cielo e Stone
- Não tratei problemas relacionados a timeout

## Autor

```
Luiz Paulo Rodrigues
```
