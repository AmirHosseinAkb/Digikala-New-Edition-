namespace _01_Framework.Infrastructure
{
    public class NeedsPermissionAttribute:Attribute
    {
        public int PermissionId { get; set; }

        public NeedsPermissionAttribute(int permissionId)
        {
            PermissionId = permissionId;
        }
    }
}
