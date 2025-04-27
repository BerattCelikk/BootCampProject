using BootCampProject.Repositories;
using BootCampProject.Entities;
using BootCampProject.Core;

namespace Business
{
    public class ApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantService(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task AddApplicantAsync(Applicant applicant)
        {
            await _applicantRepository.AddAsync(applicant);
        }

        public async Task<IEnumerable<Applicant>> GetAllApplicantsAsync()
        {
            return await _applicantRepository.GetAllAsync();
        }

        public async Task<Applicant> GetApplicantByIdAsync(int id)
        {
            return await _applicantRepository.GetByIdAsync(id);
        }

        
        public async Task UpdateApplicantAsync(Applicant applicant)
        {
            await _applicantRepository.UpdateAsync(applicant);
        }

        public async Task DeleteApplicantAsync(int id)
        {
            var applicant = await _applicantRepository.GetByIdAsync(id);
            if (applicant != null)
            {
                await _applicantRepository.DeleteAsync(applicant);
            }
        }
    }
}
