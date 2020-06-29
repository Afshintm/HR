namespace HR.Api.Models
{
    public enum EmploymentType
    {
        FullTime,
        PartTime,
        Casual,
        Contract,
    }

    public enum Gender
    {
        Female,
        Male
    }

    public enum ContractStatus
    {
        Initialized,
        Signed,
        InProgress,
        Suspended,
        Finished,
    }
}