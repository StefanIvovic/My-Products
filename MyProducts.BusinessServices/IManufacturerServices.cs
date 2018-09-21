using MyProducts.BusinessEntities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProducts.BusinessServices
{
    public interface IManufacturerServices
    {
        void CreateManufacturer(ManufacturerEntity manufacturerEntity);
        IEnumerable<ManufacturerEntity> GetAllManufacturers();
    }
}
