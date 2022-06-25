using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    public class IzlaziController : BaseController<Model.Izlazi, eProdaja.Model.SearchObjects.PretragaIspitSearchObject>
    {
        public IzlaziController(IService<Izlazi, PretragaIspitSearchObject> service) : base(service)
        {
        }
    }
}
