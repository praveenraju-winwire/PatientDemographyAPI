using PatientDemographyAPI.Models;
namespace PatientDemographyAPI.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int id);
        // void AddPatient(Patient patient);
        // void UpdatePatient(Patient patient);
        // void DeletePatient(int id);
    }
}