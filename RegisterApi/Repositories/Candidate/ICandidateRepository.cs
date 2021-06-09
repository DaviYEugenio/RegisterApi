using RegisterApi.Services.Candidate.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterApi.Repositories.Candidate
{
    public interface ICandidateRepository
    {
        Task AddStatus(Guid id);
        Task Save(CandidateRequestViewModel model);
        Task<bool> ValidEmail(string email);
        Task<IEnumerable<TrainingRequestViewModel>> Get();
    }
}
