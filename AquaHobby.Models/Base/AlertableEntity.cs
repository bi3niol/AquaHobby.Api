namespace AquaHobby.Models.Base
{
    public abstract class AlertableEntity<Tkey>: AppEntity<Tkey>
    {
        public int NumberOfAlerts { get; set; }
    }
}
