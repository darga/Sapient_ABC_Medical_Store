using ABCPharmacy.DataService.Repository;
using ABCPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ABCPharmacy.Mapper;

namespace ABCPharmacy.Controllers
{
    public class MedicalStoreController : ApiController
    {
        private IABCDataRepository _ABCDataRepository = null;
        public MedicalStoreController()
        {
            _ABCDataRepository = new ABCDataRepository();
        }
        // GET api/<controller>
        public List<Medicine> Get()
        {
            var medicines = _ABCDataRepository.GetMedicines();
            return Mapper.MapDTO.MapDTOMedicine(medicines);
        }

        
        public List<Medicine> Get(string name)
        {
            var medicines = _ABCDataRepository.GetMedicinesByName(name);
            return Mapper.MapDTO.MapDTOMedicine(medicines);
        }

        // POST api/<controller>
        public bool Post([FromBody]Medicine medicine)
        {
            var dtoMedicine = MapDTO.MapUIMedicine(medicine);
            return _ABCDataRepository.SaveMedicine(dtoMedicine);
        }

    }
}