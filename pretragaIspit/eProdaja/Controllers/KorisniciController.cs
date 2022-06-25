using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController :  BaseCRUDController<Model.Korisnici, KorisniciSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>
    {
        public IKorisniciService korisniciService { get; set; }
        public KorisniciController(IKorisniciService service)
            :base(service)
        {
            korisniciService = service;
        }

        //[Authorize("Administrator")]
        public override Korisnici Insert([FromBody] KorisniciInsertRequest insert)
        {
            return base.Insert(insert);
        }

        //[Authorize("Administrator")]
        public override Korisnici Update(int id, [FromBody] KorisniciUpdateRequest update)
        {
            return base.Update(id, update);
        }

        [HttpGet("/filterPretraga")]
        public List<Model.Korisnici> KorisniciFilterPretraga([FromQuery] PretragaIspitSearchObject search)
        {
            return korisniciService.KorisniciFilterPretraga(search);    
        }


    }
}
