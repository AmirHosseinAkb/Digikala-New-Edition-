using _01_Framework.Infrastructure;
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

        public User GetUserForLogin(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User GetUserById(long id)
        {
            return _context.Users.SingleOrDefault(u => u.UserId==id);
        }

        public long GetUserWalletBalance(long userId)
        {
            var deposit=_context.Transactions.Where(t => t.UserId == userId && t.TypeId==TransactionTypes.Deposit && t.IsSucceeded).Sum(t => t.Amount);
            var withdraw=_context.Transactions.Where(t => t.UserId == userId && t.TypeId==TransactionTypes.Withdraw && t.IsSucceeded).Sum(t => t.Amount);
            return deposit - withdraw;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
