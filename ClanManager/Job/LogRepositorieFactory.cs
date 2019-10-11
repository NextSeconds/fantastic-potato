using Quartz.Impl.AdoJobStore;
using Quartz.Impl.AdoJobStore.Common;

namespace ClanManager.Job
{
    public class LogRepositorieFactory
    {
        public static ILogRepositorie CreateLogRepositorie(string driverDelegateType, IDbProvider dbProvider)
        {

            if (driverDelegateType == typeof(SqlServerDelegate).AssemblyQualifiedName)
            {
                return new LogRepositorieSQLServer(dbProvider);
            }
            else
            {
                return null;
            }
        }
    }
}