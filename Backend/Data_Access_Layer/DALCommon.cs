using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DALCommon
    {
        private readonly AppDbContext _cIDbContext;

        public DALCommon(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }
        public List<Country> CountryList()
        {
            return _cIDbContext.Country.ToList();
        }

        public List<City> CityList(int countryId)
        {
            return _cIDbContext.City.Where(c => c.CountryId == countryId).ToList();
        }
    }
}
