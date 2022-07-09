using UserManagement.Domain.UserAgg;

namespace UserManagement.Domain.RoleAgg
{
    public class Role
    {
        public long RoleId { get; private set; }
        public string RoleTitle { get; private set; }

        public List<User> Users { get; private set; }

        protected Role()
        {
            
        }

        public Role(string roleTitle)
        {
            RoleTitle=roleTitle;
        }
    }
}
