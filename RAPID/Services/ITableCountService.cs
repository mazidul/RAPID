using RAPID.DTOs.Generic;

namespace RAPID.Services;

public interface ITableCountService
{
    Task<TableCountDto?> GetCountsAsync(string modelName);
}
