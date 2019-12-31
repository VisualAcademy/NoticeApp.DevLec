using System;
using System.Threading.Tasks;

namespace NoticeApp.Models
{
    /// <summary>
    /// [4] Repository Interface
    /// </summary>
    public interface INoticeRepositoryAsync : ICrudRepositoryAsync<Notice>
    {
        Task<Tuple<int, int>> GetStatus(int parentId);
        Task<bool> DeleteAllByParentId(int parentId); 
    }
}
