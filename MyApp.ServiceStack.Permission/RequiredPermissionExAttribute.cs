using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.ServiceStack.Permission
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class RequiredPermissionExAttribute : RequiredPermissionAttribute
    {
        public RequiredPermissionExAttribute(string resourceGroup, string resourceName)
        {
            ResourceGroup = resourceGroup;
            ResourceName = resourceName;
        }

        public string ResourceGroup { get; }
        public string ResourceName { get; }
    }
}
