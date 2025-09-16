namespace RAPID.DTOs.Generic;

public class TableCountDto
{
    public int Total { get; set; }
    public int Active { get; set; }
    public int Inactive { get; set; }
    public int Draft { get; set; }
    public int Updated { get; set; }
    public int Deleted { get; set; }
}
