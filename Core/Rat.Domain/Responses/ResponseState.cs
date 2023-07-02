namespace Rat.Domain.Responses
{
    public struct ResponseState
    {
        public int Code { get; set; }

        public int HttpStatusCode { get; set; }

        public string Message { get; set; }
    }
}
