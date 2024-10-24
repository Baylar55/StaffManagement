namespace StaffManagement.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string objectName, int key) : base($"Queried object {objectName} was not found, Key: {key}") { }
    }

    public class InvalidIdException : Exception
    {
        public InvalidIdException(string objectName) : base($"Invalid Id for object {objectName}") { }
    }
}
