﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.RoleAgg
{
    public class Permission
    {
        public long PermissionId { get; set; }
        public string PermissionTitle { get; set; }
        public int PermissionCode { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }


        protected Permission()
        {
            
        }

        public Permission(string permissionTitle,int permissionCode)
        {
            PermissionTitle = permissionTitle;
            PermissionCode= permissionCode;
        }
    }
}