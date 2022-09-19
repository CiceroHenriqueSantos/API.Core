namespace API.CoreSystem.Manager.Domain.API
{
    public class PagedResult<T>
    {
        public PagedResult()
        {
            Data = new List<T>();
        }

        public PagedResult(int recordCount, int currentPage, int recordsPerPage, List<T> data)
        {
            RecordCount = recordCount;
            CurrentPage = currentPage;
            RecordsPerPage = recordsPerPage;
            Data = data;
        }

        public int RecordCount { get; set; }
        public int CurrentPage { get; set; }
        public int RecordsPerPage { get; set; }
        public int TotalPages => Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(RecordCount) / RecordsPerPage));
        public List<T> Data { get; set; }
        public PagedResult<U> As<U>(List<U> data)
        {
            return new PagedResult<U>(this.RecordCount, this.CurrentPage, this.RecordsPerPage, data);
        }
    }
}
