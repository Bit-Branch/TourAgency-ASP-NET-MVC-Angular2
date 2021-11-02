using System.Threading.Tasks;

namespace TourAgency.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}