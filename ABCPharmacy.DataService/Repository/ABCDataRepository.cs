using ABCPharmacy.DataService.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCPharmacy.DataService.Repository
{
    public class ABCDataRepository : IABCDataRepository
    {
        private static List<Medicine> _medicines = new List<Medicine>{
                new Medicine{Brand = "Dr.Reddys", ExpiryDate = DateTime.Now.AddDays(40), FullName = "P125", Notes="for fever", Price=20.50m, Quantity=10 }
                ,new Medicine{Brand = "Cipla", ExpiryDate = DateTime.Now.AddDays(10), FullName = "P250", Notes="for fever", Price=120.50m, Quantity=10}
                ,new Medicine{Brand = "Abbott", ExpiryDate = DateTime.Now.AddDays(100), FullName = "P126", Notes="for fever", Price=200.50m, Quantity=10}
                ,new Medicine{Brand = "Amsco", ExpiryDate = DateTime.Now.AddDays(-10), FullName = "P127", Notes="for fever", Price=420.50m, Quantity=10}
                ,new Medicine{Brand = "Biolight", ExpiryDate = DateTime.Now.AddDays(100), FullName = "P128", Notes="for fever", Price=220.50m, Quantity=10}
                ,new Medicine{Brand = "Biolight", ExpiryDate = DateTime.Now.AddDays(20), FullName = "P129", Notes="for fever", Price=204.50m, Quantity=10}
                ,new Medicine{Brand = "Amsco", ExpiryDate = DateTime.Now.AddDays(30), FullName = "P130", Notes="for fever", Price=206.50m, Quantity=10}
                ,new Medicine{Brand = "Dr.Reddys", ExpiryDate = DateTime.Now.AddDays(25), FullName = "P255", Notes="for pain relief", Price=230.50m, Quantity=10}
                ,new Medicine{Brand = "Cipla", ExpiryDate = DateTime.Now.AddDays(50), FullName = "P200", Notes="for headache", Price=207.50m, Quantity=10}
            };
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Medicine> GetMedicines()
        {
            return _medicines;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Medicine> GetMedicinesByName(string name)
        {
            return _medicines.Where(med => med.FullName.Contains(name)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicine"></param>
        /// <returns></returns>
        public bool SaveMedicine(Medicine medicine)
        {
            _medicines.Add(medicine);
            return true;
        }
    }

    public interface IABCDataRepository
    {
        List<Medicine> GetMedicines();
        List<Medicine> GetMedicinesByName(string name);
        bool SaveMedicine(Medicine medicine);
    }
}
