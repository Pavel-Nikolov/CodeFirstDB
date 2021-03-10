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
        static ProductRepo productRepo;
        static UserRepo userRepo;
        static DBManager()
        {
            brandRepo = new BrandRepo();
            productRepo = new ProductRepo();
            userRepo = new UserRepo();
        }
        public static void RunCommand(ModelType modelType, OperationType operationType, params object[] commandArgs)
        {
            switch (modelType)
            {
                case ModelType.Brand:
                    ManageBrands(operationType, commandArgs);
                    break;
                case ModelType.Product:
                    ManageProducts(operationType, commandArgs);
                    break;
                case ModelType.User:
                    ManageUsers(operationType, commandArgs);
                    break;
                default:
                    break;
            }
        }

        private static void ManageUsers(OperationType operationType, object[] commandArgs)
        {
            switch (operationType)
            {
                case OperationType.Create:
                    //string[] ProductKeysToBeCreated = commandArgs
                    //    .Skip(2)
                    //    .Select(x => x.ToString())
                    //    .ToArray();

                    string[] ProductKeysToBeCreated = commandArgs[2] as string[];
                    List<Product> products = new List<Product>();
                    if (ProductKeysToBeCreated != null)
                    {
                        foreach (string item in ProductKeysToBeCreated) 
                        {
                            products.Add(productRepo.Read(item));
                        }
                        
                    }
                    User user = new User()
                        {
                            Name = commandArgs[0].ToString(),
                            Age = int.Parse(commandArgs[1].ToString()),
                            Products = products
                        };
                    
                    userRepo.Create(user);
                    break;

                case OperationType.Read:
                    int readKey = int.Parse(commandArgs[0].ToString());
                    User readUser = userRepo.Read(readKey);
                    EventManager.ReadUser(readUser);
                    break;

                case OperationType.ReadAll:
                    ICollection<User> readUsers = userRepo.ReadAll();
                    foreach (User item in readUsers)
                    {
                        EventManager.ReadUser(item);
                    }
                    break;

                case OperationType.Update:
                    string[] productKeysToBeUpdated = commandArgs[3] as string[];
                    List<Product> productsUpd = new List<Product>();
                    if (productsUpd != null)
                    {
                        foreach (string item in productKeysToBeUpdated)
                        {
                            productsUpd.Add(productRepo.Read(item));
                        }
                    }                    
                    User userUpd = new User() 
                    {
                        ID = int.Parse(commandArgs[0].ToString()),
                        Name = commandArgs[1].ToString(),
                        Age = int.Parse(commandArgs[2].ToString()),
                        Products = productsUpd 
                    };
                    userRepo.Update(userUpd);
                    break;

                case OperationType.Delete:
                    int delKey = int.Parse(commandArgs[0].ToString());
                    userRepo.Delete(delKey);
                    break;

                case OperationType.Find:
                    ICollection<User> foundUsers = userRepo.Find(commandArgs[0].ToString());
                    foreach (User item in foundUsers)
                    {
                        EventManager.ReadUser(item);
                    }
                    break;
                    
                default:
                    break;
            }
        }

        private static void ManageProducts(OperationType operationType, object[] commandArgs)
        {
            switch (operationType)
            {
                case OperationType.Create:
                    Brand brandFromDb = brandRepo.Read(int.Parse(commandArgs[4].ToString()));
                    Product productToBeAdded = new Product()
                    {
                        Barcode = commandArgs[0].ToString(),
                        Name = commandArgs[1].ToString(),
                        Quantity = int.Parse(commandArgs[2].ToString()),
                        Price = decimal.Parse(commandArgs[3].ToString()),
                        Brand = brandFromDb
                    };
                    productRepo.Create(productToBeAdded);
                    break;

                case OperationType.Read:
                    string keyRead = commandArgs[0].ToString();
                    Product productRead = productRepo.Read(keyRead);
                    EventManager.ReadProduct(productRead);
                    break;

                case OperationType.ReadAll:
                    ICollection<Product> productsRead = productRepo.ReadAll();
                    foreach (Product item in productsRead)
                    {
                        EventManager.ReadProduct(item);
                    }
                    break;

                case OperationType.Update:
                    Brand brandFromDbUpd = brandRepo.Read(int.Parse(commandArgs[4].ToString()));
                    Product productToBeUpdated = new Product()
                    {
                        Barcode = commandArgs[0].ToString(),
                        Name = commandArgs[1].ToString(),
                        Quantity = int.Parse(commandArgs[2].ToString()),
                        Price = decimal.Parse(commandArgs[3].ToString()),
                        Brand = brandFromDbUpd
                    };
                    productRepo.Update(productToBeUpdated);
                    break;

                case OperationType.Delete:
                    string keyDel = commandArgs[0].ToString();
                    productRepo.Read(keyDel);                    
                    break;
                case OperationType.Find:
                    string index = commandArgs[0].ToString();
                    ICollection<Product> productsFound = productRepo.Find(index);
                    foreach (Product item in productsFound)
                    {
                        EventManager.ReadProduct(item);
                    }
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
                    foreach (Brand item in brandsRead)
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
