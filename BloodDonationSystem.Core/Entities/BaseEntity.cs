
namespace BloodDonationSystem.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
