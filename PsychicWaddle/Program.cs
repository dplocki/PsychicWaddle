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
        public IEnumerable<Role> SomeCollection { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class EmployeeDTO
    {
        public IEnumerable<Role> SomeCollection { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }

    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<Employee, EmployeeDTO>();
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            //Create and Populate Employee Object i.e. Source Object
            Employee emp = new Employee
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT",
                SomeCollection = new List<Role>()
                {
                    new Role() { Id = 1, Name = "A" },
                    new Role() { Id = 2, Name = "B" },
                    new Role() { Id = 3, Name = "C" }
                }
            };

            //Initializing AutoMapper
            var mapper = MapperConfig.InitializeAutomapper();

            //Way1: Specify the Destination Type and to The Map Method pass the Source Object
            //Now, empDTO1 object will having the same values as emp object
            var empDTO1 = mapper.Map<EmployeeDTO>(emp);

            //Way2: Specify the both Source and Destination Type 
            //and to The Map Method pass the Source Object
            //Now, empDTO2 object will having the same values as emp object
            var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);

            Console.WriteLine("Name: " + empDTO1.Name + ", Salary: " + empDTO1.Salary + ", Address: " + empDTO1.Address + ", Department: " + empDTO1.Department + ", SomeCollection:");

            foreach(var entry in empDTO1.SomeCollection)
            {
                Console.WriteLine(" >> " + entry.Id + " " + entry.Name);
            }

            Console.ReadLine();
        }
    }
}