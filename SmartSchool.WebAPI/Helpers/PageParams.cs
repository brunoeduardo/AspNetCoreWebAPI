namespace SmartSchool.WebAPI.Helpers
{
    public class PageParams
    {
        public const int MaxPageSIze = 50;

        public int PageNumber { get; set; } = 1;

        private int pageSize = 10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSIze) ? MaxPageSIze : value; }
        }

        public int? Registration { get; set; } = null;
        public string Name { get; set; } = string.Empty;
        public int? Active { get; set; } = null;
    }
}