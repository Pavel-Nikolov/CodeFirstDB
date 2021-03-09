using Controller.Enums;
using Controller.Events;
using Model;
using Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class DBManager
    {
        static BrandRepo brandRepo;
        static DBManager()
        {
            brandRepo = new BrandRepo();
        }
        public static void RunCommand(ModelType modelType, OperationType operationType, params object[] commandArgs)
        {
            switch (modelType)
            {
                case ModelType.Brand:
                    ManageBrands(operationType, commandArgs);
                    break;
                case ModelType.Product:
                    throw new NotImplementedException();
                    break;
                case ModelType.User:
                    throw new NotImplementedException();
                    break;
                default:
                    break;
            }
        }

        private static void ManageBrands(OperationType operationType, object[] commandArgs)
        {
            switch (operationType)
            {
                case OperationType.Create:
                    Brand brandToBeAdded = new Brand()
                    {
                        Name = commandArgs[0].ToString()
                    };
                    brandRepo.Create(brandToBeAdded);
                    break;

                case OperationType.Read:
                    int readKey = int.Parse(commandArgs[0].ToString());
                    Brand readBrand = brandRepo.Read(readKey);
                    EventManager.ReadBrand(readBrand);
                    break;

                case OperationType.ReadAll:
                    ICollection<Brand> brandsRead = brandRepo.ReadAll();
                    foreach (var item in brandsRead)
                    {
                        EventManager.ReadBrand(item);
                    }
                    break;

                case OperationType.Update:
                    Brand brandToBeUpdated = new Brand()
                    {
                        ID = int.Parse(commandArgs[0].ToString()),
                        Name = commandArgs[1].ToString()
                    };
                    brandRepo.Update(brandToBeUpdated);
                    break;

                case OperationType.Delete:
                    int deleteKey = int.Parse(commandArgs[0].ToString());
                    brandRepo.Delete(deleteKey);
                    break;
                case OperationType.Find:
                    string index = commandArgs[0].ToString();
                    ICollection<Brand> foundBrands = brandRepo.Find(index);
                    foreach (var item in foundBrands)
                    {
                        EventManager.ReadBrand(item);
                    }
                    break;
                default:
                    
                    break;
            }
        }
    }
}
