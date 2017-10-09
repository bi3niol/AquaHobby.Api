namespace AquaHobby.Models.Base
{
    public abstract class AlertableEntity<Tkey>: Bieniol.Base.Models.BaseEntity<Tkey>
    {
        public int NumberOfAlerts { get; set; }
    }
}
