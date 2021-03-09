using Controller;
using Controller.Enums;
using Controller.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        private static void EventManager_OnProductRead(ProductReadEventArgs args)
        {
            throw new NotImplementedException();
        }

        private static void EventManager_OnBrandRead(BrandReadEventArgs args)
        {
            Console.WriteLine(args);
        }

        static void Main(string[] args)
        { 
            
            while (true)
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
                    default:
                        Console.WriteLine("WrongType");
                        break;
                }
            }
            
            
        }
    }
}
