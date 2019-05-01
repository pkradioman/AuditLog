using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;
//using ServiceStack.Script;
using ServiceStack.DataAnnotations;
using MyApp.ServiceModel;
using MyApp.Domain;
using ServiceStack.Configuration;
using shortid;
using System.Net;
using System.Reflection;
using MyApp.ServiceStack.Permission;

namespace MyApp.ServiceInterface
{
    //[Authenticate]
    public class PermissionService : Service
    {

        public PermissionService()
        {
        }

        public object Get(ResourceQuery request)
        {
            var bindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance;
            var types = GetType().Assembly.GetExportedTypes();
            var resourceInfos = from t in types
                                  select new
                                  {
                                      Class = t.Name,
                                      Attrs = from cattr in t.GetCustomAttributes() select cattr.GetType().Name,
                                      Methods = from m in t.GetMethods(bindingFlags)
                                                select new
                                                {
                                                    Name = m.Name,
                                                    Attrs = from mattr in m.GetCustomAttributes<RequiredPermissionExAttribute>() select new
                                                    {
                                                        Name = mattr.GetType().Name,
                                                        Props = from p in mattr.GetType().GetProperties(bindingFlags) select new
                                                        {
                                                            Name = p.Name,
                                                            Value = p.GetValue(mattr)
                                                        }
                                                        
                                                    }
                                                }
                                  };

            return resourceInfos;
        }

        

        

    }
}
