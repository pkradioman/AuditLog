using System.Collections.Generic;
using ServiceStack;
using MyApp.Domain;

namespace MyApp.ServiceModel
{
    [Route("/groups/query", "GET")]
    public class GroupQuery : QueryDb<GroupModel>
    {
    }

    [Route("/groups", "GET")]
    public class GroupList : IReturn<List<GroupModel>>
    {
    }

    [Route("/groups", "POST")]
    public class GroupAdd : IReturn<GroupModel>
    {
        public string Name { get; set; }
    }

    [Route("/groups", "PUT")]
    public class GroupUpdate : IReturn<GroupResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    [Route("/groups/{Id}", "DELETE")]
    public class GroupDelete : IReturn<GroupResponse>
    {
        public string Id { get; set; }
    }

    public class GroupResponse
    {
        public string Result { get; set; }
    }



}
