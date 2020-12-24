using AutoMapper;
using PillsPiston.BL.Contracts;
using PillsPiston.BL.Interface;
using PillsPiston.Core.Enums;
using PillsPiston.Core.Exceptions.Profile;
using PillsPiston.DAL.Entities;
using PillsPiston.DAL.Interfaces;
using System.Threading.Tasks;

namespace PillsPiston.BL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public ProfileService(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Cell> RenameCell(string cellId, string name)
        {
            Cell cell = await this.repository.GetAsync<Cell>(true, c => c.Id.Equals(cellId));
            cell.Name = name;
            await this.repository.UpdateAsync(cell);
            return cell;
        }

        public async Task AcceptWatchRequest(string watcherId, string subjectId)
        {
            Relationship relationship = await this.repository.GetAsync<Relationship>(true, r => r.WatcherId.Equals(watcherId) && r.SubjectId.Equals(subjectId) && (r.RelationshipStatus == RelationshipStatusesEnum.Requested || r.RelationshipStatus == RelationshipStatusesEnum.Stopped));
            if(relationship == null)
            {
                throw new RelationshipNotFoundException();
            }
            else
            {
                relationship.RelationshipStatus = RelationshipStatusesEnum.Accepted;
            }

            await this.repository.UpdateAsync(relationship);
        }

        public async Task RejectWatchRequest(string watcherId, string subjectId)
        {
            Relationship relationship = await this.repository.GetAsync<Relationship>(true, r => r.WatcherId.Equals(watcherId) && r.SubjectId.Equals(subjectId) && (r.RelationshipStatus == RelationshipStatusesEnum.Requested));
            if (relationship == null)
            {
                throw new RelationshipNotFoundException();
            }
            else
            {
                relationship.RelationshipStatus = RelationshipStatusesEnum.Declined;
            }

            await this.repository.UpdateAsync(relationship);
        }

        public async Task StopWatchRequest(string watcherId, string subjectId)
        {
            Relationship relationship = await this.repository.GetAsync<Relationship>(true, r => r.WatcherId.Equals(watcherId) && r.SubjectId.Equals(subjectId) && (r.RelationshipStatus == RelationshipStatusesEnum.Accepted));
            if (relationship == null)
            {
                throw new RelationshipNotFoundException();
            }
            else
            {
                relationship.RelationshipStatus = RelationshipStatusesEnum.Stopped;
            }

            await this.repository.UpdateAsync(relationship);

        }

        public async Task<Relationship> SendWatchRequest(string watcherId, string subjectId)
        {
            Relationship relationship = new Relationship
            {
                WatcherId = watcherId,
                SubjectId = subjectId,
                RelationshipStatus = RelationshipStatusesEnum.Requested
            };
            return await this.repository.AddAsync(relationship);
        }

        public Task<Adoption> NewAdoption(AdoptionContract contract)
        {
            Adoption adoption = this.mapper.Map<Adoption>(contract);
            return repository.AddAsync(adoption);
        }

        public async Task DeleteAdoption(int id)
        {
            Adoption adoption = await repository.GetAsync<Adoption>(true, a => a.Id == id);
            await repository.DeleteAsync(adoption);
        }
    }
}
