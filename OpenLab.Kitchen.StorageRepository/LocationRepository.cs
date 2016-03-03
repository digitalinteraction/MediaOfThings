using System;
using System.Linq;
using System.Linq.Expressions;
using OpenLab.Kitchen.Service.Interfaces;

namespace OpenLab.Kitchen.StorageRepository
{
    public class LocationRepository : IReadWriteRepository<Service.Models.Location>
    {
        private readonly KitchenStorageRepository _storageRepository;

        public LocationRepository()
        {
            _storageRepository = new KitchenStorageRepository();
        }

        public Service.Models.Location GetById(int id)
        {
            return GetAll().Single(l => l.Id == id);
        }

        public IQueryable<Service.Models.Location> Search(Expression<Func<Service.Models.Location, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<Service.Models.Location> GetAll()
        {
            return _storageRepository.Locations.Select(l => new Service.Models.Location
            {
                Id = l.Id,
                Name = l.Name
            });
        }

        public void Insert(Service.Models.Location model)
        {
            _storageRepository.Locations.Add(new Location
            {
                Name = model.Name
            });
            _storageRepository.SaveChangesAsync();
        }

        public void Update(Service.Models.Location model)
        {
            var entity = _storageRepository.Locations.Single(l => l.Id == model.Id);
            entity.Name = model.Name;
            _storageRepository.SaveChangesAsync();
        }

        public void Delete(Service.Models.Location model)
        {
            _storageRepository.Locations.Remove(_storageRepository.Locations.Single(l => l.Id == model.Id));
            _storageRepository.SaveChangesAsync();
        }
    }
}