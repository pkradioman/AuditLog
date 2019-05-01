using System.Collections.Generic;
using ServiceStack;
using MyApp.Domain;
using MyApp.ServiceStack.Permission;

namespace MyApp.ServiceModel
{
    [Route("/resources", "GET")]
    public class ResourceQuery : QueryDb<ResourceModel>
    {
    }

    

    
}
