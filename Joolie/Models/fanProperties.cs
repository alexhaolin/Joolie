using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joolie.Models
{
    public class fanProperties
    {
        public int MinModelYear{ get; set; }
        public int MaxModelYear { get; set; }
        public int ModelYearPropertID { get; set; }
      
        public int MinAirFlow { get; set; }
        public int MaxAirFlow { get; set; }
        public int AirFlowPropertID { get; set; }
        public int MinMaxPower { get; set; }
        public int MaxMaxPower { get; set; }
        public int MaxPowerPropertyID { get; set; }
   
        public int MinFanSpeedDimater { get; set; }
        public int MaxFanSpeedDimater { get; set; }
        public int FanSpeedDimaterPropertyID { get; set; }
        public int MinHeight { get; set; }
        public int MaxHeight { get; set; }
        public int HeightPropertyID { get; set; }
        public int MinFirm{ get; set; }
        public int MaxFirm { get; set; }
        public int FirmPropertyID { get; set; }
        public int MinGlobal { get; set; }
        public int MaxGlobal { get; set; }
        public int GlobalPropertyID { get; set; }
        public List<string> Brands { get; set; }

        string[] Properties = { "ModelYear", "AirFlow", "MaxPower", "FanSpeedDiameter", "Height", "FIrm", "Golbal" };

      


        //public int MinSoundAtMaxSpeed { get; set; }
        //public int MaxSoundAtMaxSpeed { get; set; }
        //public int SoundAtMaxSpeedPropertyID { get; set; }

        //public bool Commercial { get; set; }
        //public bool Industrial { get; set; }
        //public bool Resedential { get; set; }
        //public bool Indoor { get; set; }
        //public bool OutDoor { get; set; }
        //public bool Wall { get; set; }
        //public bool Roof { get; set; }
        //public bool FreeStanding { get; set; }
        //public bool WithLight { get; set; }
        //public bool WithOutLight { get; set; }
    }
}