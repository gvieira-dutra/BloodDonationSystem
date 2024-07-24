using BloodDonationSystem.Application.DTO;

namespace BloodDonationSystem.Application.Interfaces
{
    public interface IDonor
    {
        public List<Donor> GetAll();
        public Donor GetOne(int id);
        public DonorDTO Post(DonorInputModel donor);
    }
}
