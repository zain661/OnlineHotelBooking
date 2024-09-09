using HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace HotelBooking.Infrastructure.Repositories
{
    public class UserRepo: IUserRepo
    {
        private readonly HotelBookingDbContext _context; //Dependency Injection: private readonly HotelBookingDbContext _context; This declares a private readonly field of type HotelBookingDbContext.The readonly keyword ensures that this field can only be set once, in the constructor Dependency Injection (DI) is used here to inject an instance of HotelBookingDbContext when creating an instance of UserRepo.
        private readonly IConfiguration configuration;

        public UserRepo(HotelBookingDbContext context, IConfiguration configuration) {
            _context = context;
            this.configuration = configuration;
        }
        public async Task SaveRefreshTokenAsync(Guid userId, string refreshToken, DateTime expiryTime)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new ArgumentException("User not found");

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = expiryTime;
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetRefreshTokenAsync(Guid userId)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            return user?.RefreshToken;
        }

        public async Task RemoveRefreshTokenAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new ArgumentException("User not found");

            user.RefreshToken = null;
            user.RefreshTokenExpiryTime = null; // Set to null for nullable DateTime
            await _context.SaveChangesAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
                   await _context.Users.AddAsync(user); //This uses Entity Framework Core (an ORM) to add a new User entity to the Users DbSet.The Add method marks the entity as added to the context.In modern ASP.NET Core applications, it is generally recommended to use asynchronous methods (like AddAsync) to maintain scalability and responsiveness, especially when dealing with I/O-bound operations.
                   await _context.SaveChangesAsync(); //This asynchronously saves all changes made in the context to the database.The SaveChangesAsync method is an asynchronous operation that commits the transaction.
                   return user;
        }

        public async Task DeleteUserAsync(User user)
        {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);








            /*This uses LINQ to query the Users DbSet and find the first user whose Email property matches the provided email.FirstOrDefaultAsync is an asynchronous LINQ method that returns the first element of a sequence or a default value if no such element is found.
                    //.AsNoTracking() improves performance because it tells EF Core not to track the entities, which is useful when you don’t need to update them.
                    /*
                     * When to Use .AsNoTracking()
        //Read-Only Queries:

        //Use .AsNoTracking() for queries where you are only reading data and do not need to update the entities. This can significantly improve performance and reduce memory usage.
        //Large Data Sets:

        //For queries that return large data sets, .AsNoTracking() helps to reduce the overhead of tracking many entities, which can otherwise consume a lot of memory and slow down the query execution.
        //Stateless Operations:

        //In scenarios where you are performing stateless operations, such as in web APIs where each request is independent, using .AsNoTracking() can be beneficial.*/
        }




        public async Task<User> GetUserByIdAsync(Guid id)
        {
                    //return await _context.Users.AsNoTracking().FindAsync(id); The FindAsync method is designed to use the tracking mechanism of Entity Framework Core to locate an entity by its primary key. When using AsNoTracking, you instruct EF Core not to track the entities, which conflicts with the purpose of FindAsync.
                    return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }



        public async Task UpdateUserAsync(User user)
        {
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
        }

       
        
    }
}

/*
 Key Differences
Migrations:

Focus on schema changes.
Commands: Add-Migration, Update-Database.
Create and apply changes to the structure of the database tables.
One-time operations triggered by developer actions.
Tracking:

Focus on data changes at runtime.
Commands: SaveChanges, SaveChangesAsync.
Automatically detect changes to entity instances and generate SQL commands to update the database.
Continuous process during the application's runtime.
 
 
 */
