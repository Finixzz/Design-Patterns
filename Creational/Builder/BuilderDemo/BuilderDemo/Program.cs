using System;

namespace BuilderDemo
{
    public class SystemUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }
    }

    public class SystemDoctor : SystemUser
    {
        public string Qualifications { get; set; }

        public string Title { get; set; }
        public string CVPath { get; set; }

    }

    public class Doctor
    {
        public Guid Id { get; set; }

        public string Qualifications { get; set; }

        public string Title { get; set; }

        public string CVPath { get; set; }
    }

    public interface IUserBuilder
    {
        public SystemUser GetUser(SystemUser User);
    }

    public class UserBuilder : IUserBuilder
    {
        public SystemUser GetUser(SystemUser User)
        {
            return new SystemUser()
            {
                Id = User.Id,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Email = User.Email,
                Gender = User.Gender,
                DateOfBirth = User.DateOfBirth
            };
        }
    }

    public interface IDoctorBuilder
    {
        public Doctor GetDoctor(SystemDoctor systemDoctor);
    }

    public class DoctorBuilder : IDoctorBuilder
    {
        public Doctor GetDoctor(SystemDoctor systemDoctor)
        {
            return new Doctor()
            {
                Id = systemDoctor.Id,
                Qualifications = systemDoctor.Qualifications,
                Title = systemDoctor.Title,
                CVPath = systemDoctor.CVPath
            };
        }
    }

   

    public class DirectorBuilder
    {
        private readonly DoctorBuilder doctorBuilder;
        private readonly UserBuilder userBuilder;

        public DirectorBuilder()
        {
            doctorBuilder = new DoctorBuilder();
            userBuilder = new UserBuilder();
        }

        public Doctor GetDoctor(SystemDoctor sysDoctor)
        {
            return doctorBuilder.GetDoctor(sysDoctor);
        }

        public SystemUser GetUser(SystemUser user)
        {
            return userBuilder.GetUser(user);
        }


    }



    class Program
    {
        static void Main(string[] args)
        {
            DirectorBuilder directorBuilder = new DirectorBuilder();

            SystemDoctor sysDoctor = new SystemDoctor()
            {
                Id = new Guid(),
                FirstName = "First",
                LastName = "Doctor",
                Email="firstdoctor@email.com",
                DateOfBirth = "26/05/1975",
                Gender = "Male",
                Qualifications = "DDM",
                Title = "Doctor of dental medicine",
                CVPath = "somecvpath"
            };

            SystemUser user = directorBuilder.GetUser(sysDoctor);
            Console.WriteLine("System user information ready to be saved!");
            Console.WriteLine($"UserID: {user.Id}");
            Console.WriteLine($"First Name {user.FirstName}");
            Console.WriteLine($"Last Name: {user.LastName}");
            Console.WriteLine($"Email : {user.Email}");
            Console.WriteLine($"Gender: {user.Gender}");
            Console.WriteLine("-----------------------");

            Console.WriteLine("Doctor information data ready to be saved!");
            Doctor newDoctor = directorBuilder.GetDoctor(sysDoctor);
            Console.WriteLine($"UserID: {newDoctor.Id}");
            Console.WriteLine($"Title: {newDoctor.Title}");
            Console.WriteLine($"Qualifications: {newDoctor.Qualifications}");
            Console.WriteLine($"CVPath: {newDoctor.CVPath}");
            
        }
    }
}
