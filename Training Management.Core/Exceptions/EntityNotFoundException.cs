namespace TrainingManagement.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("Item not Found")
        {

        }
    }
}
