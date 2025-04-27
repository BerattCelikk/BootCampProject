using BootCampProject.Repositories;
using BootCampProject.Entities;
using BootCampProject.Core;

namespace Business
{
    public class InstructorService
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        
        public async Task AddInstructorAsync(Instructor instructor)
        {
            await _instructorRepository.AddAsync(instructor);
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
        {
            return await _instructorRepository.GetAllAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            return await _instructorRepository.GetByIdAsync(id);
        }

        public async Task UpdateInstructorAsync(Instructor instructor)
        {
            await _instructorRepository.UpdateAsync(instructor);
        }

        public async Task DeleteInstructorAsync(int id)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            if (instructor != null)
            {
                await _instructorRepository.DeleteAsync(instructor);
            }
        }
    }
}
