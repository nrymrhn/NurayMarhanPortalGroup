using NurayMarhanPortalGroup.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.Business.Concrete
{
    public static class MernisValidations
    {
        public async static Task<bool> ValidationTc(Customer customer)
        {
            bool status;
            try
            {
                using (Kimlik.KPSPublicSoapClient servis = new Kimlik.KPSPublicSoapClient(Kimlik.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12))
                {
                    var result =await servis.TCKimlikNoDogrulaAsync(customer.TCID,customer.FirstName,customer.LastName,customer.BirthDate.Year);
                    status=result.Body.TCKimlikNoDogrulaResult;
                }
            }
            catch
            {
                status = false;
            }
            return status;
        }
    }
}
