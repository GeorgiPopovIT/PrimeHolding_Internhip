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

        public const string PHONE_INVALID = "Not a valid phone number";

    }

    public static class Task
    {
        public const string TITLE_REQUIRED = "Title is required.";
		public const string DESCRIPTION_REQUIRED = "Description is required.";
		public const string DUEDATE_REQUIRED = "Due date is required.";

        public const int TITLE_DESCRIPTION_MIN_LENGTH = 3;
		public const string TITLE_DESCRIPTION_MIN_LENGTH_ERRORR = "must be at least 3 characters.";


	}
}
