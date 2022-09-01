using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class IC_SampleType_Setup
    {
        public IC_SampleType_Setup()
        {
            IC_SampleTypeProcess_Setup = new List<IC_SampleTypeProcess_Setup>();
        }
        [Key]
        public int SampleTypeID { get; set; }
        public string SampleType { get; set; }
        public string TypeDescription { get; set; }
        public bool IsActive { get; set; }

        public List<IC_SampleTypeProcess_Setup> IC_SampleTypeProcess_Setup { get; set; }
    }
}
