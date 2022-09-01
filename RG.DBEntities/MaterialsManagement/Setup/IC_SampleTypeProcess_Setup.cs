using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RG.DBEntities.MaterialsManagement.Setup
{
    public class IC_SampleTypeProcess_Setup
    {
        [Key]
        public int SampleTypeProcessID { get; set; }

        [ForeignKey("IC_SampleType_Setup")]
        public int SampleTypeID { get; set; }
        public string SampleProcessType { get; set; }
        public string ProcessTypeDescription { get; set; }
        public bool IsActive { get; set; }

        public IC_SampleType_Setup IC_SampleType_Setup { get; set; }
    }
}
