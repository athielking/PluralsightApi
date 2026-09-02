using PluralsightApi.Web.Models;

namespace PluralsightApi.Web.Services
{
    public interface IInventoryService
    {
        LocationInventory? GetLocationInventory(int locationId);

        IEnumerable<LocationInventory> ListLocationInventory();
    }
}
