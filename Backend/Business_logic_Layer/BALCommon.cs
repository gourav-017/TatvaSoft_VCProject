using Data_Access_Layer;
using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer
{
    public class BALCommon
    {
        private readonly DALCommon _dalCommon;

        public BALCommon(DALCommon dalCommon)
        {
            _dalCommon = dalCommon;
        }

        public List<Country> CountryList()
        {
            return _dalCommon.CountryList();
        }

        public List<City> CityList(int countryId)
        {
            return _dalCommon.CityList(countryId);
        }
    }
}
