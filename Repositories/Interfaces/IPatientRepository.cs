using PatientDemographyAPI.Models;


namespace PatientDemographyAPI.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAll();
        Task<Patient> GetById(int id);
        // Task Add(Patient patient);
        // Task Update(Patient patient);
        // Task Delete(int id);
    }
}