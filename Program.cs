using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace HelloApp
{
    class Property 
    { 
         public object this[string propName]
        {
            get
            {
                Type type = typeof(Person);
                PropertyInfo propInf = type.GetProperty(propName);
                return propInf.GetValue(this, null);
            }
            set
            {
                Type type = typeof(Person);
                PropertyInfo propInf = type.GetProperty(propName);
                propInf.SetValue(this, value, null);
            }
        }
    }

    class Person : Property
    {
        public string Name { get; set; }
        public int Age { get; set; }
       
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person tom = new Person() { Name = "Tom", Age = 35 };
            tom["Age"] = 50;
            Console.WriteLine(tom["Age"]);

            //string json = JsonSerializer.Serialize<Person>(tom);
            //Console.WriteLine(json);
            //Person restoredPerson = JsonSerializer.Deserialize<Person>(json);
            //Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}");

            string str = "{Simpheropol.asdasd}, {Fiodosiya} {Saki.}";
            Regex rg = new Regex("{[a-zA-Z]+.[a-zA-Z]+}");
            Regex r = new Regex("[a-zA-Z]+");
            foreach (var item in rg.Matches(str))
            {
                Console.WriteLine(r.Match(item.ToString()).Value);
            }
            
        }
    }
}