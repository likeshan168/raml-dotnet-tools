
using System;
using System.Web.Http;
using System.Web.Http.Description;
using MoviesWebApi2Sample.Movies.Models;

// Do not modify this file. This code was generated by RAML Web Api 2 Scaffolder

namespace MoviesWebApi2Sample.Movies
{
    [RoutePrefix("search")]
    public partial class SearchController : ApiController
    {


        /// <summary>
		/// search movies by name or director
		/// </summary>
		/// <param name="name">Name of the movie</param>
		/// <param name="director">Director of the movie</param>
		/// <returns>SearchGetOKResponseContent[]</returns>
        [ResponseType(typeof(SearchGetOKResponseContent[]))]
        [HttpGet]
        [Route("")]
        public virtual IHttpActionResult GetBase([FromUri] string name = null,[FromUri] string director = null)
        {
            // Do not modify this code
            return ((ISearchController)this).Get(name,director);
        }
    }
}