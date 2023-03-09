namespace EmployeeSystem.Core;

public static class ModelsConstants
{
    public static class Employee
    {
        public const string FULL_NAME_REQUIRED = "Full name is required.";
        public const string EMAIL_REQUIRED = "Email address is required.";
        public const string PHONE_REQUIRED = "Phone number is required.";
        public const string DATE_OF_BIRTH_REQUIRED = "Date of birth is required.";
        public const string MONTHLY_SALARY_REQUIRED = "Monthly salary is required.";

        public const int FULL_NAME_MIN_LENGTH = 5;
        public const int FULL_NAME_MAX_LENGTH = 100;
        public const string FULL_NAME_LENGTH = "Full name must be at least 5 characters and the most 100 characters long.";

        public const string EMAIL_INVALID = "Email addres is invalid.";

    }

    public static class Task
    {

    }
}
