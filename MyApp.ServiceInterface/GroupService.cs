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

namespace MyApp.ServiceInterface
{
    public class GroupServices : Service
    {
        private readonly IList<GroupModel> repo;
        public GroupServices(IList<GroupModel> repo)
        {
            this.repo = repo;
        }

        public object Get(GroupList request)
        {
            var result = repo;
            return result;

            /*
            //1. Returning a custom Status and Description with Response DTO body:
            var responseDto = ...;
            return new HttpResult(responseDto, HttpStatusCode.Conflict)
            {
                StatusDescription = "Computer says no",
            };

            //2. Throw a HttpError:
            throw new HttpError(HttpStatusCode.Conflict, "Some Error Message");

            //3. Return a HttpError:
            return new HttpError(HttpStatusCode.Conflict, "Some Error Message");

            //4. Modify the Request's IHttpResponse
            base.Response.StatusCode = (int)HttpStatusCode.Redirect;
            base.Response.AddHeader("Location", "http://path/to/new/uri");
            base.Response.EndRequest(); //Short-circuits Request Pipeline
            */
        }

        public object Post(GroupAdd request)
        {
            var model = request.ConvertTo<GroupModel>();
            model.Id = ShortId.Generate(true, false, 10);
            repo.Add(model);
            return new HttpResult(model, "application/json", HttpStatusCode.Created);
        }

        public object Delete(GroupDelete request)
        {
            var model = repo.First(m => m.Id == request.Id);
            repo.Remove(model);
            return new HttpResult(model, "application/json", HttpStatusCode.OK);
        }

    }
}
