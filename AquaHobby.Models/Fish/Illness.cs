using Bieniol.Base.Models;
using System;

namespace AquaHobby.Models.Fish
{
    public class Illness:BaseEntity<long>
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endtime">need to keep user local time (not server time)</param>
        public void EndIllnes(DateTime endtime)
        {
            End = endtime;
        }
    }
}