namespace Cura.Assignment.Authentication.Domain.SeedWork
{
    public abstract class Entity<T>
    {
        T _id;
        public virtual T Id
        {
            get
            {
                return _id;
            }
            protected set
            {
                _id = value;
            }
        }
        public DateTime CreatedAt { get; protected set; }
        protected Entity()
        {
           this.CreatedAt = DateTime.Now;
        }

    }
}
