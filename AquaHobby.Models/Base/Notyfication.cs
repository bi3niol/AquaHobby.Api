namespace AquaHobby.Models.Base
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">Notified entity type</typeparam>
    /// <typeparam name="TKey">Notyfication Id type</typeparam>
    /// <typeparam name="TObjKey">type of TEntity Id</typeparam>
    public class Notyfication<TEntity,TKey,TObjKey>: Bieniol.Base.Models.BaseEntity<TKey> where TEntity: AlertableEntity<TObjKey>
    {
        public TEntity NotifiedObject { get; set; }
    }
}
