using AquaHobby.Models.Base;
using Bieniol.Base.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models.Fish
{
    public class Illness:AppEntity<long>
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        [ForeignKey("HealthBook")]
        public long? HealthBookId { get; set; }
        public HealthBook HealthBook { get; set; }

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