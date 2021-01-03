using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace E_CommerceSystemWithRestAPI.Controllers
{
    [RoutePrefix("api/fileupload")]
    
    public class FileUploadController : ApiController
    {
        [Route("")]
        public Task<HttpResponseMessage> Post()
        {
            List<string> savefilepath = new List<string>();

            // Check whether the POST operation is MultiPart?
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string rootpath = HttpContext.Current.Server.MapPath("~/UploadFiles");
            var provider = new MultipartFileStreamProvider(rootpath);
            var task = Request.Content.ReadAsMultipartAsync(provider).
            ContinueWith<HttpResponseMessage>(t =>
            {
                if (t.IsCanceled || t.IsFaulted)
                {
                    Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                }

                foreach (MultipartFileData item in provider.FileData)
                {
                    try
                    {
                        string name = item.Headers.ContentDisposition.FileName.Replace("\"", "");
                        string newfilename = Guid.NewGuid() + Path.GetExtension(name);
                        File.Move(item.LocalFileName, Path.Combine(rootpath, newfilename));
                        Uri baseuri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, string.Empty));
                        string fileRelativePath = "~/UploadFiles/" + newfilename;
                        Uri filefullpath = new Uri(baseuri, VirtualPathUtility.ToAbsolute(fileRelativePath));
                        savefilepath.Add(filefullpath.ToString());
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                return Request.CreateResponse(HttpStatusCode.Created, savefilepath);
            });
            return task;
        }
    }
}
