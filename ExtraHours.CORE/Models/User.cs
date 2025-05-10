namespace ExtraHours.Core.Models {

    public class User{

       
        public int Id { get; set;}
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public decimal Salary { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

    }

}