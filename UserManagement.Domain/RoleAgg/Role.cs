using UserManagement.Domain.UserAgg;

namespace UserManagement.Domain.RoleAgg
{
    public class Role
    {
        public long RoleId { get; private set; }
        public string RoleTitle { get; private set; }

        public List<User> Users { get; private set; }
        public List<Permission> Permissions { get; set; }

        protected Role()
        {
            
        }

        public Role(string roleTitle)
        {
            RoleTitle=roleTitle;
        }

        public Role(long roleId, string roleTitle)
        {
            RoleId = roleId;
            RoleTitle=roleTitle;
        }
    }
}
