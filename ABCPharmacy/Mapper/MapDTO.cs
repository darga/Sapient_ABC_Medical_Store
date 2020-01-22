using ABCPharmacy.Models;
using System.Collections.Generic;
using System.Linq;

namespace ABCPharmacy.Mapper
{
    public static class MapDTO
    {
        public static List<Medicine> MapDTOMedicine(List<DataService.DataModel.Medicine> medicines)
        {

            IEnumerable<Medicine> uiMedicines = medicines.Select(a => new Medicine()
            {
                Brand = a.Brand,
                ExpiryDate = a.ExpiryDate,
                FullName = a.FullName,
                Notes = a.Notes,
                Price = a.Price,
                Quantity = a.Quantity
            });
            return uiMedicines.ToList();
        }

        public static DataService.DataModel.Medicine MapUIMedicine(Medicine medicine)
        {

            return new DataService.DataModel.Medicine
            {
                Brand = medicine.Brand,
                Quantity = medicine.Quantity,
                ExpiryDate = medicine.ExpiryDate,
                FullName = medicine.FullName,
                Notes = medicine.Notes,
                Price = medicine.Price
            };
        }
    }
}