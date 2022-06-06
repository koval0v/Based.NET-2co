using System;
using System.Reflection;

namespace InWork_.NET2co_KovalVadym_IS01
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assem = typeof(int).Assembly;

            Console.WriteLine($"Assembly Location: {assem.Location}" +
                $"\nAssembly Full Name: {assem.FullName}" +
                $"\nAssembly Id Dynamic: {assem.IsDynamic}");

            Console.WriteLine("==========================================");

            Type type1 = typeof(Car);
            Console.WriteLine(type1);

            Type type2 = Type.GetType("InWork_.NET2co_KovalVadym_IS01.Car");
            Console.WriteLine(type2);

            Car car = new Car();
            object o = car;
            Type type3 = o.GetType();
            Console.WriteLine(type3);

            Console.WriteLine("==========================================");

            Car car2 = new Car("BMW", 139371, 120);
            car2.Move(30);
            car2.Move(130);

            Console.WriteLine("==========================================");

            Type myType = typeof(Car);

            foreach (MemberInfo member in myType.GetMembers())
            {
                Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
            }

            Console.WriteLine("==========================================");

            foreach (MemberInfo member in myType.GetMembers(BindingFlags.DeclaredOnly |
                BindingFlags.Public | BindingFlags.Instance))
            {
                Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
            }

            Console.WriteLine("==========================================");

            foreach (ConstructorInfo member in myType.GetConstructors(BindingFlags.DeclaredOnly |
                BindingFlags.Public | BindingFlags.Instance))
            {
                string modificator = "";

                if (member.IsPublic)
                    modificator += "public";
                else if (member.IsPrivate)
                    modificator += "private";
                else if (member.IsAssembly)
                    modificator += "internal";
                else if (member.IsFamily)
                    modificator += "protected";
                else if (member.IsFamilyAndAssembly)
                    modificator += "private protected";
                else if (member.IsFamilyOrAssembly)
                    modificator += "protected internal";

                Console.Write($"{modificator} {myType.Name}(");
                ParameterInfo[] parameters = member.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    Console.Write($"{param.ParameterType.Name} {param.Name}");
                    if (i < parameters.Length - 1) Console.Write(", ");
                }
                Console.WriteLine(")");
            }

            Console.WriteLine("==========================================");

            foreach (MethodInfo method in myType.GetMethods())
            {
                string modificator = "";

                if (method.IsStatic) modificator += "static ";
                if (method.IsVirtual) modificator += "virtual ";

                Console.WriteLine($"{modificator}{method.ReturnType.Name} {method.Name} ()");
            }

            Console.WriteLine("==========================================");

            foreach (MethodInfo method in myType.GetMethods(BindingFlags.DeclaredOnly |
                BindingFlags.Public | BindingFlags.Instance))
            {
                Console.Write($"{method.ReturnType.Name} {method.Name} (");
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    var param = parameters[i];
                    string modificator = "";
                    if (param.IsIn) modificator = "in";
                    else if (param.IsOut) modificator = "out";

                    Console.Write($"{param.ParameterType.Name} {modificator} {param.Name}");
                    if (param.HasDefaultValue) Console.Write($"={param.DefaultValue}");
                    if (i < parameters.Length - 1) Console.Write(", ");
                }
                Console.WriteLine(")");
            }

            Console.WriteLine("==========================================");

            foreach (FieldInfo field in myType.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                string modificator = "";

                if (field.IsPublic)
                    modificator += "public ";
                else if (field.IsPrivate)
                    modificator += "private ";
                else if (field.IsAssembly)
                    modificator += "internal ";
                else if (field.IsFamily)
                    modificator += "protected ";
                else if (field.IsFamilyAndAssembly)
                    modificator += "private protected ";
                else if (field.IsFamilyOrAssembly)
                    modificator += "protected internal ";

                if (field.IsStatic) modificator += "static ";

                Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");

                Console.WriteLine("==========================================");
                Car carToChange = new Car("Ferrari", 833167, 60, "Ferrari company");

                var companyField = typeof(Car).GetField("company", BindingFlags.Instance
                    | BindingFlags.NonPublic);
                var company = companyField?.GetValue(carToChange);
                Console.WriteLine(company);

                companyField?.SetValue(carToChange, "BMW company");
                Console.WriteLine(carToChange.CompanyInfo());


            }

            Console.WriteLine("==========================================");

            foreach (PropertyInfo property in typeof(Car).GetProperties())
            {
                Console.WriteLine($"Property name: {property.Name}");
                Console.WriteLine($"Property type: {property.PropertyType}");
                Console.WriteLine($"Read-Write:    {property.CanRead && property.CanWrite}");
                MethodInfo setAccessor = property.SetMethod;
                string accessibility;
                if (setAccessor.IsPublic)
                {
                    accessibility = "Public";
                }
                else if (setAccessor.IsPrivate)
                {
                    accessibility = "Private";
                }
                else if (setAccessor.IsAssembly)
                {
                    accessibility = "Internal";
                }
                else
                {
                    accessibility = "Protected";
                }
                Console.WriteLine($"Accessibility: {accessibility}");
                Console.WriteLine();
            }

            Console.WriteLine("==========================================");
            foreach (MemberInfo member in typeof(Car).GetMembers())
            {
                switch(member.MemberType)
                { 
                    case(MemberTypes.Field):
                        Console.WriteLine("This is a field:");
                        Console.WriteLine($"{((FieldInfo)member).FieldType.Name} {((FieldInfo)member).Name}");
                        break;
                    case (MemberTypes.Property):
                        Console.WriteLine("This is a property:");
                        Console.WriteLine($"{((PropertyInfo)member).Name} {((PropertyInfo)member).PropertyType}" +
                            $"{((PropertyInfo)member).CanRead && ((PropertyInfo)member).CanWrite}");
                        break;
                    case (MemberTypes.Event):
                        Console.WriteLine("This is an event:");
                        Console.WriteLine($"{((EventInfo)member).Name} {((EventInfo)member).EventHandlerType}");
                        break;
                    case (MemberTypes.Constructor):
                        Console.WriteLine("This is a constructor:");
                        foreach (var param in ((ConstructorInfo)member).GetParameters())
                        {
                            Console.Write($"{param.ParameterType.Name} {param.Name}");
                        }
                        Console.WriteLine();
                        break;
                    case (MemberTypes.Method):
                        Console.WriteLine("This is a method:");
                        Console.WriteLine($"{((MethodInfo)member).Name} {((MethodInfo)member).ReturnType}");
                        break;
                }
            }
        }
        public interface ICar
        {
            public void Print();
        }

        public interface IMovable
        {
            public void Move(int gasolineToMove);
        }

        public class Car : ICar, IMovable
        {
            public delegate void ToMove(string message);
            public event ToMove Notify;
            internal string name;
            public int Code { get; set; }
            private int Gasoline { get; set; }
            private string company;
            public Car() { }
            public Car(string name, int code, int gasoline)
            {
                this.name = name;
                Code = code;
                Gasoline = gasoline;
                Notify += Message;
            }
            public Car(string name, int code, int gasoline, string company)
            {
                this.name = name;
                Code = code;
                Gasoline = gasoline;
                Notify += Message;
                this.company = company;
            }
            public void Print() => Console.WriteLine($"Name: {name} Code: {Code}");
            public void Move(int gasolineToMove)
            {
                if (Gasoline >= gasolineToMove)
                {
                    Gasoline -= gasolineToMove;
                    Notify?.Invoke($"Було витрачено {gasolineToMove} л. бензину. Залишок: {Gasoline} л.");
                }
                else
                {
                    Notify?.Invoke($"Не вистачає бензину. Залишок: {Gasoline} л.");
                }
            }
            public void Message(string message)
            {
                Console.WriteLine(message);
            }

            public string CompanyInfo()
            {
                return company;
            }

        }
    }
}
