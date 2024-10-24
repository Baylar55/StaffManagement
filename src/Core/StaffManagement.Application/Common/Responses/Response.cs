namespace StaffManagement.Application.Common.Responses
{
    public class Response
    {
        public Response()
        {
            Errors = new List<string>();
        }
        public StatusCode Status { get; set; } = StatusCode.Success;
        public bool IsSuccessful { get; set; } = true;
        public List<string> Errors { get; set; }
    }

    public class Response<T> : Response
    {
        public T Data { get; set; }
    }

    public enum StatusCode
    {
        Success = 200,
        Created = 201,
        NoContent = 204,
        NotFound = 404,
        BadRequest = 400,
        Unauthorized = 401,
        Conflict = 409,
    }
}
