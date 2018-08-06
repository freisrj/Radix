using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Radix.Domain.HttpServices
{
    [DataContract()]
    public class HttpResult<TResponseMessage> : IActionResult where TResponseMessage : class
    {
        public const string defaultOKMessage = "Sucesso.";
        public const string MsgErroPadrao = "Erro na camada de serviço.";

        public HttpResult() {}

        public HttpResult(TResponseMessage requestMessage) : this() =>  SetRequestMessage(requestMessage);

        public HttpResult<TResponseMessage> SetRequestMessage(object requestMessage)
        {
            if (requestMessage == null)
                throw new ArgumentNullException("O requestMessage não pode ser nulo.");

            return this;
        }

        [DataMember(Name = "retorno")]
        public TResponseMessage Response { get; set; }

        [DataMember(Name = "mensagem")]
        public string Message { get; set; }

        public bool Valid { get { return (int)HttpStatusCode < 400; } }

        public HttpResult<TResponseMessage> Set(HttpStatusCode httpStatusCode, string msg)
        {
            Message = msg;
            HttpStatusCode = httpStatusCode;

            return this;
        }

        #region Padrões de respostas Http

        /// <summary>
        /// 422 Unprocessable Entity - Utilizado para validações de negócio ou alguma informação necessária para uma ação.
        /// <c>Quando necessário uma origem para criar um carrinho e a mesma não é encontrada. Utilize esse tipo de retorno.</c>
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetToUnprocessableEntity(string msg) => Set((HttpStatusCode)422, msg);

        /// <summary>
        /// 200 OK - Utilizado para todas as situações de sucesso.
        /// </summary>
        public HttpResult<TResponseMessage> SetHttpStatusToOk(string msg = defaultOKMessage) => Set(HttpStatusCode.OK, msg);

        /// <summary>
        /// 201 Created - Utilizado para criação de registro no banco<c>Criar carrinho.</c>
        /// </summary>
        public HttpResult<TResponseMessage> SetHttpStatusToCreated(string msg = "Criado com sucesso.") => Set(HttpStatusCode.Created, msg);

        /// <summary>
        /// 202 Accepted - Utilizado para chamadas async ou adicionar algum item em fila de processamento.
        /// </summary>
        public HttpResult<TResponseMessage> SetHttpStatusToAccepted(string msg = "Em fila de processamento.") => Set(HttpStatusCode.Accepted, msg);

        /// <summary>
        /// 400 Bad Request - Utilizado para a maioria dos erros de request.
        /// <c>Campos obrigatórios no request ou erro na camada de serviço.</c>
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToBadRequest(string msg) => Set(HttpStatusCode.BadRequest, msg);

        /// <summary>
        /// 500 Internal Server Error - Utilizado para erros internos no servidor ou exceptions.
        /// <c>Utilizado principalmente pelos conectores.</c>
        /// </summary>
        public HttpResult<TResponseMessage> SetHttpStatusToInternalServerError(string msg = MsgErroPadrao) => Set(HttpStatusCode.InternalServerError, msg);

        /// <summary>
        /// 403 Forbidden - Utilizado para requisições rejeitadas pelo servidor.
        /// <c>Utilizado principalmente pelos conectores.</c>
        /// </summary>
        public HttpResult<TResponseMessage> SetHttpStatusToForbidden(string msg = "O servidor recusou a requisição.") => Set(HttpStatusCode.Forbidden, msg);

        /// <summary>
        /// 404 Not Found - Utilizado para informar rota inválida.
        /// <c>Utilizado principalmente pelos conectores.</c>
        /// </summary>
        public HttpResult<TResponseMessage> SetHttpStatusToNotFound(string msg = "Recurso não encontrado no servidor.") => Set(HttpStatusCode.NotFound, msg);

        /// <summary>
        /// 503 Service Unavailable - Utilizado para informar serviço indisponível.
        /// <c>Utilizado principalmente pelos conectores.</c>
        /// </summary>
        public HttpResult<TResponseMessage> SetHttpStatusToServiceUnavailable(string msg = "Serviço indisponível.") => Set(HttpStatusCode.ServiceUnavailable, msg);

        /// <summary>
        /// 401 Unauthorized - Utilizado para token inválido ou restrição de acesso.
        /// </summary>
        public HttpResult<TResponseMessage> SetHttpStatusToUnauthorized(string msg = "Não autorizado o acesso ao recurso.") => Set(HttpStatusCode.Unauthorized, msg);

        /// <summary>
        /// 406 NotAcceptable - Utilizado para informar que existe informações que devem ser passadas no header. 
        /// <c>CodigoOperadora obrigatório</c>
        /// </summary>    
        public HttpResult<TResponseMessage> SetHttpStatusToNotAcceptable(string msg = "Informação no header é obrigatório.") => Set(HttpStatusCode.NotAcceptable, msg);

        /// <summary>
        ///  408 RequestTimeout
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToRequestTimeout(string msg = "Tempo limite atingido no request.") => Set(HttpStatusCode.RequestTimeout, msg);

        /// <summary>
        ///  504 GatewayTimeout
        /// </summary>
        /// <param name="msg"></param>
        public HttpResult<TResponseMessage> SetHttpStatusToGatewayTimeout(string msg = "Tempo limite atingido.") => Set(HttpStatusCode.GatewayTimeout, msg);

        #endregion Padrões de respostas Http

        [IgnoreDataMember]
        public HttpStatusCode HttpStatusCode { get; private set; } = HttpStatusCode.OK;

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(this) { StatusCode = (int)HttpStatusCode };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}
