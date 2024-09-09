
namespace Infrastructure.Seeding
{
    public class BookingRoomSeeding
    {
        public static IEnumerable<object> SeedData()
        {
            return new List<object>
            {
                new
                {
                    BookingsId = new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"),
                    RoomsId = new Guid("a98b8a9d-4c5a-4a90-a2d2-5f1441b93db6")
                },
                new
                {
                    BookingsId = new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"),
                    RoomsId = new Guid("4e1cb3d9-bc3b-4997-a3d5-0c56cf17fe7a")
                },
                new
                {
                    BookingsId = new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"),
                    RoomsId = new Guid("c6898b7e-ee09-4b36-8b20-22e8c2a63e29")
                }
            };
        }
    }
}
