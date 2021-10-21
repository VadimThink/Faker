using System;
using Generator;
using DTO;
using System.Reflection;

namespace Faker
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseGenerator baseGenerator = new BaseGenerator();
            baseGenerator.AddGenerator(new SongsGenerator.SongsGenerator());
            baseGenerator.AddGenerator(new UriGenerator());

            Assembly asm =
                Assembly.LoadFrom("../../../../PrimetiveGenerators/bin/Debug/PrimetiveGenerators.dll");
            var types = asm.GetTypes();
            foreach (var type in types)
            {
                if (!type.IsAbstract && type.GetInterface("IBaseGenerator") != null)
                {
                    baseGenerator.AddGenerator((IBaseGenerator)Activator.CreateInstance(type));
                }
            }

            IGenerator generator = new DTOGenerator(baseGenerator);
            var book = generator.Generate(typeof(Book));
            Console.WriteLine(book.ToString());
            Console.ReadKey();
        }
    }
}
