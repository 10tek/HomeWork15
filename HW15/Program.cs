using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HW15
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = typeof(Console).Assembly;
            var types = assembly.GetTypes();
            var methodList = new List<string>();
            foreach (var type in types)
            {
                if (type.Name == "Console")
                {
                    foreach (var method in type.GetMethods())
                    {
                        if (!methodList.Contains(method.Name))
                        {
                            methodList.Add(method.Name);
                        }
                    }
                }
            }
            foreach(var method in methodList)
            {
                Console.WriteLine(method);
            }

            User user = new User()
            {
                Name = "Tomy",
                Login = "Shelby",
                Age = 33
            };

            Console.WriteLine("\n2.");
            assembly = typeof(User).Assembly;
            types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.Name == "User")
                {
                    foreach (var member in type.GetMembers())
                    {
                        if (member is PropertyInfo)
                        {
                            var propertyInfo = member as PropertyInfo;
                            Console.WriteLine($"{propertyInfo.Name} - {propertyInfo.GetValue(user)}");
                        }
                    }
                }
            }



        }
    }
}
