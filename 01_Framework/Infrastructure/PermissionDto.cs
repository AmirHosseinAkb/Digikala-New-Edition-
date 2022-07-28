﻿namespace _01_Framework.Infrastructure;

public class PermissionDto
{
    public string PermissionTitle { get; set; }
    public int PermissionCode { get; set; }
    public int? ParentCode { get; set; }

    public PermissionDto(string permissionTitle,int permissionCode,int? parentCode=null)
    {
        PermissionTitle=permissionTitle;
        PermissionCode = permissionCode;
        ParentCode=parentCode;
    }
}