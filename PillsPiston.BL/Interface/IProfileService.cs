using PillsPiston.BL.Contracts;
using PillsPiston.DAL.Entities;
using System.Threading.Tasks;

namespace PillsPiston.BL.Interface
{
    public interface IProfileService
    {
        public Task<Cell> RenameCell(string cellId, string name);

        public Task<Adoption> NewAdoption(AdoptionContract contract);

        public Task DeleteAdoption(int id);

        public Task<Relationship> SendWatchRequest(string watcherId, string subjectId);

        public Task AcceptWatchRequest(string watcherId, string subjectId);

        public Task RejectWatchRequest(string watcherId, string subjectId);

        public Task StopWatchRequest(string watcherId, string subjectId);

    }
}
