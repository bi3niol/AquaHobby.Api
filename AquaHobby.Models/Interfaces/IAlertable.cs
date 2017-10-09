namespace AquaHobby.Models.Interfaces
{
    public interface IAlertable
    {
        int AlertsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alertData"></param>
        /// <returns>information if object was modified</returns>
        bool Alert(object alertData = null);
    }
}
