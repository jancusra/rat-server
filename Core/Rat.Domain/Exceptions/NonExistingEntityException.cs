using Rat.Domain.Responses;

namespace Rat.Domain.Exceptions
{
    public partial class NonExistingEntityException : BaseResponseException
    {
        public NonExistingEntityException(string entityName)
            : base(new ResponseState { Code = 11003, Message = $"Entity {entityName} not exists.", HttpStatusCode = 404 })
        {
        }
    }
}
