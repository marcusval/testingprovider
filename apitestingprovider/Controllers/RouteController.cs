
using System.Collections.Generic;

using System.Data;

using System.Data.Entity;

using System.Data.Entity.Infrastructure;

using System.Linq;

using System.Net;

using System.Web.Http;

using System.Web.Http.Description;

using testingproviderClassLibrary;



namespace apitestingprovider.Controllers

{

    public class RouteController : ApiController

    {

        private CoyApp_dbEntities db = new CoyApp_dbEntities();



        // GET: api/Route

        public IQueryable<Route> GetRoutes()

        {

            return db.Routes;

        }



        // GET: api/Route/5

        [ResponseType(typeof(Route))]

        public IHttpActionResult GetRoute(int id)

        {

            Route route = db.Routes.Find(id);

            if (route == null)

            {

                return NotFound();

            }



            return Ok(route);

        }



        public List<Route> GetRoutesForProvider(string providerID)

        {

            using (CoyApp_dbEntities entities = new CoyApp_dbEntities())

            {

                return (entities.Routes.Where(e => e.Id_P == providerID).ToList());



            }

        }





        // PUT: api/Route/5

        [ResponseType(typeof(void))]

        public IHttpActionResult PutRoute(int id, Route route)

        {

            if (!ModelState.IsValid)

            {

                return BadRequest(ModelState);

            }



            if (id != route.Id_R)

            {

                return BadRequest();

            }



            db.Entry(route).State = EntityState.Modified;



            try

            {

                db.SaveChanges();

            }

            catch (DbUpdateConcurrencyException)

            {

                if (!RouteExists(id))

                {

                    return NotFound();

                }

                else

                {

                    throw;

                }

            }



            return StatusCode(HttpStatusCode.NoContent);

        }



        // POST: api/Route

        [ResponseType(typeof(Route))]

        public IHttpActionResult PostRoute(Route route)

        {

            if (!ModelState.IsValid)

            {

                return BadRequest(ModelState);

            }



            db.Routes.Add(route);



            try

            {

                db.SaveChanges();

            }

            catch (DbUpdateException)

            {

                if (RouteExists(route.Id_R))

                {

                    return Conflict();

                }

                else

                {

                    throw;

                }

            }



            return CreatedAtRoute("DefaultApi", new { id = route.Id_R }, route);

        }



        // DELETE: api/Route/5

        [ResponseType(typeof(Route))]

        public IHttpActionResult DeleteRoute(int id)

        {

            Route route = db.Routes.Find(id);

            if (route == null)

            {

                return NotFound();

            }



            db.Routes.Remove(route);

            db.SaveChanges();



            return Ok(route);

        }



        protected override void Dispose(bool disposing)

        {

            if (disposing)

            {

                db.Dispose();

            }

            base.Dispose(disposing);

        }



        private bool RouteExists(int id)

        {

            return db.Routes.Count(e => e.Id_R == id) > 0;

        }

    }

}