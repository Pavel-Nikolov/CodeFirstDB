using Controller;
using Controller.Enums;
using Controller.Events;
using System;
using System.Linq;

namespace View
{
    static class Program
    {
        
        static Program()
        {
            EventManager.OnBrandRead += EventManager_OnBrandRead;
            EventManager.OnProductRead += EventManager_OnProductRead;
            EventManager.OnUserRead += EventManager_OnUserRead;
        }

        private static void EventManager_OnUserRead(UserReadEventArgs args)
        {
            Print.PrintUser(args);
        }

        private static void EventManager_OnProductRead(ProductReadEventArgs args)
        {
            Print.PrintProduct(args);
        }

        private static void EventManager_OnBrandRead(BrandReadEventArgs args)
        {
            Print.PrintBrand(args);
        }

        static void Main(string[] args)
        { 
            
            while (true)
            {
                try
                {
                    string[] command = Console.ReadLine().Split();
                    switch (command[0].ToLower())
                    {
                        case "brand":
                            switch (command[1].ToLower())
                            {
                                case "create":
                                    DBManager.RunCommand(ModelType.Brand, OperationType.Create, command[2]);
                                    break;
                                case "read":
                                    DBManager.RunCommand(ModelType.Brand, OperationType.Read, command[2]);
                                    break;
                                case "readall":
                                    DBManager.RunCommand(ModelType.Brand, OperationType.ReadAll);
                                    break;
                                case "update":
                                    DBManager.RunCommand(ModelType.Brand, OperationType.Update, command[2], command[3]);
                                    break;
                                case "delete":
                                    DBManager.RunCommand(ModelType.Brand, OperationType.Delete, command[2]);
                                    break;
                                case "find":
                                    DBManager.RunCommand(ModelType.Brand, OperationType.Find, command[2]);
                                    break;
                                default:
                                    Console.WriteLine("Wrong command");
                                    break;
                            }
                            break;
                        case "product":
                            switch (command[1].ToLower())
                            {
                                case "create":
                                    DBManager.RunCommand(ModelType.Product, OperationType.Create, command[2], command[3], command[4], command[5], command[6]);
                                    break;
                                case "read":
                                    DBManager.RunCommand(ModelType.Product, OperationType.Read, command[2]);
                                    break;
                                case "readall":
                                    DBManager.RunCommand(ModelType.Product, OperationType.ReadAll);
                                    break;
                                case "update":
                                    DBManager.RunCommand(ModelType.Product, OperationType.Update, command[2], command[3], command[4], command[5], command[6]);
                                    break;
                                case "delete":
                                    DBManager.RunCommand(ModelType.Product, OperationType.Delete, command[2]);
                                    break;
                                case "find":
                                    DBManager.RunCommand(ModelType.Product, OperationType.Find, command[2]);
                                    break;
                                default:
                                    Console.WriteLine("Wrong command");
                                    break;
                            }
                            break;
                        case "user":
                            switch (command[1].ToLower())
                            {
                                case "create":
                                    DBManager.RunCommand(ModelType.User, OperationType.Create, command[2], command[3], command.Skip(4).ToArray());
                                    break;
                                case "read":
                                    DBManager.RunCommand(ModelType.User, OperationType.Read, command[2]);
                                    break;
                                case "readall":
                                    DBManager.RunCommand(ModelType.User, OperationType.ReadAll);
                                    break;
                                case "update":
                                    DBManager.RunCommand(ModelType.User, OperationType.Update, command[2], command[3], command[4], command.Skip(5).ToArray());
                                    break;
                                case "delete":
                                    DBManager.RunCommand(ModelType.User, OperationType.Delete, command[2]);
                                    break;
                                case "find":
                                    DBManager.RunCommand(ModelType.User, OperationType.Find, command[2]);
                                    break;
                                default:
                                    Console.WriteLine("Wrong command");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("WrongType");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //Console.WriteLine(ex.InnerException.Message);
                }
                finally
                {
                    Console.WriteLine("Next command:");
                }
                
            }
            
            
        }
    }
}
