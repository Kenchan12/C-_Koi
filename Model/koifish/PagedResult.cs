

namespace KoiFishManager.Models
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new List<T>(); // Danh sách các phần tử
        public int TotalItems { get; set; } // Tổng số bản ghi
        public int PageSize { get; set; } // Số bản ghi trên mỗi trang
        public int CurrentPage { get; set; } // Trang hiện tại
        public int TotalPages { get; set; } // Tổng số trang
    }

}
