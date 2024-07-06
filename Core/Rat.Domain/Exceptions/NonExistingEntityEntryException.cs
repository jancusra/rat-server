using Rat.Domain.Responses;

namespace Rat.Domain.Exceptions
{
    /// <summary>
    /// Exception for not existing entity entry
    /// </summary>
    public partial class NonExistingEntityEntryException : BaseResponseException
    {
        public NonExistingEntityEntryException(string entityName)
            : base(new ResponseState { Code = 11002, Message = $"Entity entry for {entityName} not exists.", HttpStatusCode = 404 })
        {
        }
    }
}
