using System.Threading.Tasks;

namespace ClanManager.Job
{
    public interface ILogRepositorie
    {
        Task<bool> RemoveErrLogAsync(string jobGroup, string jobName);
    }
}