namespace EmployeesApp.Models.DTOs
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string EmployeeImageUrl { get; set; }
        public required string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StartDateOfEmployment { get; set; }
        public bool IsContractPermanent { get; set; }
        public DateTime ContractDuration { get; set; }
        public required string Department { get; set; }

        public int? AnnualLeaveDays { get; set; }
        public int? DaysOff { get; set; }
        public int? DaysOfPaidLeave { get; set; }
    }
}
