namespace AsaTeb.Domain
{
    public interface IBaseEntity<T>
    {
        public T Id { get; set; }
    }

    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        public T Id { get; set; }
    }

    public class BaseEntity : BaseEntity<Guid>
    {

    }
}
