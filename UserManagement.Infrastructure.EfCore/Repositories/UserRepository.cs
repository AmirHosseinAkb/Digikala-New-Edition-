using UserManagement.Domain.UserAgg;

namespace UserManagement.Infrastructure.EfCore.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly AccountContext _context;

        public UserRepository(AccountContext context)
        {
            _context = context;
        }
        public bool IsExistByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistByPhoneNumber(string phoneNumber)
        {
            return _context.Users.Any(u => u.PhoneNumber == phoneNumber.Replace(" ", ""));
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetByActivationCode(string activationCode)
        {
            return _context.Users.SingleOrDefault(u => u.ActivationCode == activationCode);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
