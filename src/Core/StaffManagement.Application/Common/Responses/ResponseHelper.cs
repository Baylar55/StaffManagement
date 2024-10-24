namespace StaffManagement.Application.Common.Responses
{
    public static class ResponseHelper
    {
        public static Response<T> CreateErrorResponse<T>(string errorMessage, StatusCode statusCode)
        {
            return new Response<T>
            {
                IsSuccessful = false,
                Errors = new List<string> { errorMessage },
                Status = statusCode
            };
        }
    }
}
