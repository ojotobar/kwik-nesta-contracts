namespace KwikNesta.Contracts.Models
{
    public class PageQuery
    {
        private int _page = 1;
        private int _pageSize = 10;
        private int _maxPageSize = 50;

        public int Page
        {
            get => _page; 
            set => _page = value <= 0 ? _page : value;
        }

        public int PageSize 
        { 
            get => _pageSize; 
            set => _pageSize = value <= 0 ? _pageSize : 
                value > _maxPageSize ? _maxPageSize : value; 
        }
    }
}
