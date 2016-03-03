using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.StorageRepository
{
    public class RfidRepository : IReadWriteRepository<Rfid>
    {
        private readonly KitchenStorageRepository _storageRepository;

        public RfidRepository()
        {
            _storageRepository = new KitchenStorageRepository();
        }

        public Rfid GetById(int id)
        {
            return GetAll().Single(r => r.Id == id);
        }

        public IQueryable<Rfid> Search(Expression<Func<Rfid, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<Rfid> GetAll()
        {
            return _storageRepository.Things.Where(t => t.ThingType.Name == "RFID").Select(t => new Rfid
            {
                Id = t.Id,
                DeviceId = int.Parse(t.ThingFieldValues.Single(tfv => tfv.Field.Name == "Device ID").Value),
                TransponderData = t.ThingData.Select(td => new RfidData { Id = td.Id, DataTimeStamp = DateTime.Parse(td.ThingDataFieldValues.Single(tdfv => tdfv.Field.Name == "Data Time Stamp").Value), Transponders = td.ThingDataFieldValues.Single(tdfv => tdfv.Field.Name == "Transponder List").Value.Split(',') })
            });
        }

        public void Insert(Rfid model)
        {
            var type = _storageRepository.ThingTypes.Single(tp => tp.Name == "RFID");
            var dataType = _storageRepository.ThingDataTypes.Single(tdt => tdt.Name == "Transponders");
            _storageRepository.Things.Add(new Thing
            {
                Name = "RFID Pad",
                ThingType = type,
                ThingFieldValues = new List<ThingFieldValue>
                {
                    new ThingFieldValue
                    {
                        Field = type.Fields.Single(f => f.Name == "Device ID"),
                        Value = model.DeviceId.ToString()
                    }
                },
                ThingData = model.TransponderData.Select(td => new ThingData
                {
                    Name = "Transponders",
                    ThingDataType = dataType,
                    ThingDataFieldValues = new List<ThingDataFieldValue>
                    {
                        new ThingDataFieldValue
                        {
                            Field = dataType.Fields.Single(f => f.Name == "Data Time Stamp"),
                            Value = td.DataTimeStamp.ToString(CultureInfo.InvariantCulture)
                        },
                        new ThingDataFieldValue
                        {
                            Field = dataType.Fields.Single(dt => dt.Name == "Transponder List"),
                            Value = string.Join(",", td.Transponders)
                        }
                    }
                }).ToList()
            });
            _storageRepository.SaveChangesAsync();
        }

        public void Update(Rfid model)
        {
            var entity = _storageRepository.Things.Single(t => t.Id == model.Id);
            var dataType = _storageRepository.ThingDataTypes.Single(tdt => tdt.Name == "Transponders");
            var newTransponderData = model.TransponderData.Where(tr => entity.ThingData.All(td => td.Id != tr.Id));
            var newThingData = newTransponderData.Select(td => new ThingData
            {
                Name = "Transponders",
                ThingDataType = dataType,
                ThingDataFieldValues = new List<ThingDataFieldValue>
                {
                    new ThingDataFieldValue
                    {
                        Field = dataType.Fields.Single(f => f.Name == "Data Time Stamp"),
                        Value = td.DataTimeStamp.ToString(CultureInfo.InvariantCulture)
                    },
                    new ThingDataFieldValue
                    {
                        Field = dataType.Fields.Single(dt => dt.Name == "Transponder List"),
                        Value = string.Join(",", td.Transponders)
                    }
                }
            }).ToList();
            newThingData.ForEach(ntd => entity.ThingData.Add(ntd));
            _storageRepository.SaveChangesAsync();
        }

        public void Delete(Rfid model)
        {
            _storageRepository.Things.Remove(_storageRepository.Things.Single(t => t.Id == model.Id));
            _storageRepository.SaveChangesAsync();
        }
    }
}
