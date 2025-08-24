namespace KwikNesta.Contracts.Models
{
    public class Paginator<T>
    {
        public List<T> Items { get; set; } = new();
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int ItemCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < PageCount;

        public Paginator() { }

        public Paginator(List<T> items, int count, int pageNumber, int pageSize)
        {
            ItemCount = count;
            CurrentPage = pageNumber;
            PageCount = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
        }
    }
}