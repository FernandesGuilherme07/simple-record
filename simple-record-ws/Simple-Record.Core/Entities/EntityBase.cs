using Flunt.Notifications;

namespace simple_record.core.entities
{
    public abstract class EntityBase : Notifiable, IEquatable<EntityBase>
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(EntityBase other)
        {
            return Id == other.Id;
        }
    }
}
