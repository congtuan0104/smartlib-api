namespace SmartLibApi.Models.Response;

public class BaseResponse
{
    public int StatusCode { get; set; } = 0;
    
    // nội dung thông báo kết quả hoặc lỗi hiển thị trên client
    public string? Message { get; set; }
    
    public dynamic? Data { get; set; }
    
    // nội dung thông báo lỗi cho dev
    public dynamic? Errors { get; set; }
}

public class Pagination
{
    public int TotalItems { get; set; }
    
    public int PageSize { get; set; }
    
    public int CurrentPage { get; set; }
    
    public int TotalPages { get; set; }
}

public class PaginationResponse : BaseResponse
{ 
    public Pagination Pagination { get; set; }
}