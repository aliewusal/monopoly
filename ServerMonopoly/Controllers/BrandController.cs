using ServerMonopoly.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerMonopoly.Controllers
{
    public class BrandController : ApiController
    {
        private BrandModel brandModel;
        public BrandController()
        {
            brandModel = new BrandModel();
        }
        //GET api/brands
        [Route("api/brands/")]
        public IEnumerable<Brand> GetBrands()
        {
            return brandModel.GetBrands();
        }
    }
}