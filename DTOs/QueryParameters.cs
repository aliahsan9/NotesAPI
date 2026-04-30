namespace NotesAPI.DTOs
{
    public class QueryParameters
    {
        private const int MaximumPageSize = 50;

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaximumPageSize ? MaximumPageSize : value;

        }
        public string SearchTerm { get; set; } = string.Empty;
        public string SortBy { get; set; } = "CreatedAt";
        public bool IsDecending { get; set; } = true;
    }
}
