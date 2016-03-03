using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLab.Kitchen.StorageRepository;

namespace OpenLab.Kitchen.StorageSeeder
{
    class Program
    {
        private static KitchenStorageRepository _storageRepository;

        static void Main(string[] args)
        {
            _storageRepository = new KitchenStorageRepository();

            var stringType = new FieldDataType {DataType = "string"};
            var dateTimeType = new FieldDataType {DataType = "datetime"};
            var intType = new FieldDataType {DataType = "int"};
            var floatType = new FieldDataType {DataType = "float"};

            _storageRepository.ThingTypes.Add(new ThingType
            {
                Name = "RFID",
                Fields = new List<Field>
                {
                    new Field
                    {
                        Name = "Device ID",
                        FieldDataType = intType
                    }
                }a
            });

            _storageRepository.ThingTypes.Add(new ThingType
            {
                Name = "WAX3",

            });
        }
    }
}
