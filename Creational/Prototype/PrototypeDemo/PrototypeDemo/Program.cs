using System;

namespace PrototypeDemo
{

    public interface Prototype
    {
        public object CloneShallow();

        public Prototype CloneDeep();
    }


    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Department(int id,string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }

    public class Employee : Prototype
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public Department Department { get; set; }

        public Employee(Department department)
        {
            this.Department = department;
        }
        public Prototype CloneDeep()
        {
            return new Employee(this.Department);
        }

        public object CloneShallow()
        {
            return this.MemberwiseClone();
        }

        public void printInfo(string varName)
        {
            Console.WriteLine($"---------{varName}----------");
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Full name: {FullName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"DeparmentId: {Department.Id}");
            Console.WriteLine($"Department: {Department.Name}");
            Console.WriteLine("------------------------------");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Department IT = new Department(1, "IT");
            Department HR = new Department(2, "HR");
            Employee original = new Employee(IT) { Id = 1, FullName = "First Employee", Email = "firstemp@gmail.com}" };
            original.printInfo("original");

            Employee cloneShallow = (Employee)original.CloneShallow();
            cloneShallow.Id = 2;
            cloneShallow.FullName = "Second employee";
            cloneShallow.Email = "secondemp@gmail.com";
            cloneShallow.printInfo("cloneShallow");

            Employee cloneDeep = (Employee)original.CloneDeep();
            cloneDeep.Id = 2;
            cloneDeep.FullName = "Second employee";
            cloneDeep.Email = "secondemp@gmail.com";
            cloneDeep.Department = HR;
            cloneDeep.printInfo("cloneDeep");

            original.printInfo("original");
            cloneShallow.printInfo("cloneShallow");

        }
    }
}
