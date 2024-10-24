namespace StaffManagement.Application.Common.Responses
{
    public class PaginatedResponse<T>
    {
        public IReadOnlyList<T> Data { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public PaginatedResponse(IReadOnlyList<T> data, int totalCount, int pageIndex, int pageSize)
        {
            Data = data;
            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
