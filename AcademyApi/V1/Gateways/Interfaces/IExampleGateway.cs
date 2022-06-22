using System.Collections.Generic;
using AcademyApi.V1.Domain;

namespace AcademyApi.V1.Gateways
{
    public interface IExampleGateway
    {
        Entity GetEntityById(int id);

        List<Entity> GetAll();
    }
}
