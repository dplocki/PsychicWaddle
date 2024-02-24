using AutoMapper;

namespace AutoMapperDemo
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Employee
    {
        public IEnumerable<Role> Roles { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class EmployeeDTO
    {
        public IEnumerable<Role> Roles { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var mapper = MapperConfig.InitializeAutomapper();

            Employee emp = new Employee
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT",
                Roles = new List<Role>()
                {
                    new Role() { Id = 1, Name = "A" },
                    new Role() { Id = 2, Name = "B" },
                    new Role() { Id = 3, Name = "C" }
                }
            };

            var empDTO1 = mapper.Map<EmployeeDTO>(emp);
            Console.WriteLine("empDTO1");
            DisplayEmployeeDTO(empDTO1);

            var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);
            Console.WriteLine("empDTO2");
            DisplayEmployeeDTO(empDTO2);
        }

        private static void DisplayEmployeeDTO(EmployeeDTO employee)
        {
            Console.WriteLine("Name: " + employee.Name + ", Salary: " + employee.Salary + ", Address: " + employee.Address + ", Department: " + employee.Department + ", SomeCollection:");

            foreach (var entry in employee.Roles)
            {
                Console.WriteLine(" >> " + entry.Id + " " + entry.Name);
            }
        }
    }
}