using Rat.Domain.Responses;

namespace Rat.Domain.Exceptions
{
    public partial class NonExistingEntityException : BaseResponseException
    {
        public NonExistingEntityException(string entityName)
            : base(new ResponseState { Code = 11002, Message = $"Entity {entityName} not exists.", HttpStatusCode = 302 })
        {
        }
    }
}
