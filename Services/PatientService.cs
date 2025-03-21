using System.Collections.Generic;
using System.Threading.Tasks;
using PatientDemographyAPI.Models;
using PatientDemographyAPI.Repositories.Interfaces;
using PatientDemographyAPI.Services.Interfaces;
namespace PatientDemographyAPI.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await _patientRepository.GetAll();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _patientRepository.GetById(id);
        }

        // public async Task<Patient> AddPatient(Patient patient)
        // {
        //     return await _patientRepository.Add(patient);
        // }

        // public async Task<Patient> UpdatePatient(Patient patient)
        // {
        //     return await _patientRepository.Update(patient);
        // }

        // public async Task<bool> DeletePatient(int id)
        // {
        //     return await _patientRepository.Delete(id);
        // }
    }
}