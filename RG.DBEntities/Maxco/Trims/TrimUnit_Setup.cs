using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Trims
{
    public class TrimUnit_Setup
    {
        public TrimUnit_Setup()
        {
            BuckleImageSetup = new HashSet<BuckleImage_Setup>();
            ButtonImageSetup = new HashSet<ButtonImage_Setup>();
            ChordholderImageSetup = new HashSet<ChordholderImageSetup>();
            DrawstringImage_Setup = new HashSet<DrawstringImage_Setup>();
            FurImageSetup = new HashSet<FurImageSetup>();
            HangTagImageSetup = new HashSet<HangTagImage_Setup>();
            LabelImageSetup = new HashSet<LabelImage_Setup>();
            LaceImageSetup = new HashSet<LaceImage_Setup>();
            NetMeshImageSetup = new HashSet<NetMeshImageSetup>();
            RivetImageSetup = new HashSet<RivetImageSetup>();
            SequenceImageSetup = new HashSet<SequenceImageSetup>();
            SizeRingImageSetup = new HashSet<SizeRingImageSetup>();
            TwillTapeImageSetup = new HashSet<TwillTapeImage_Setup>();
            VelcroImageSetup = new HashSet<VelcroImageSetup>();
            ZipPullerImageSetup = new HashSet<ZipPullerImageSetup>();
            ZipSliderImageSetup = new HashSet<ZipSliderImageSetup>();
            ZipStudImageSetup = new HashSet<ZipStudImageSetup>();
        }

        public long ID { get; set; }
        public string Description { get; set; }
        public int? IsLength { get; set; }
        public int? IsDisplay { get; set; }

        public virtual ICollection<BuckleImage_Setup> BuckleImageSetup { get; set; }
        public virtual ICollection<ButtonImage_Setup> ButtonImageSetup { get; set; }
        public virtual ICollection<ChordholderImageSetup> ChordholderImageSetup { get; set; }
        public virtual ICollection<DrawstringImage_Setup> DrawstringImage_Setup { get; set; }
        public virtual ICollection<FurImageSetup> FurImageSetup { get; set; }
        public virtual ICollection<HangTagImage_Setup> HangTagImageSetup { get; set; }
        public virtual ICollection<LabelImage_Setup> LabelImageSetup { get; set; }
        public virtual ICollection<LaceImage_Setup> LaceImageSetup { get; set; }
        public virtual ICollection<NetMeshImageSetup> NetMeshImageSetup { get; set; }
        public virtual ICollection<RivetImageSetup> RivetImageSetup { get; set; }
        public virtual ICollection<SequenceImageSetup> SequenceImageSetup { get; set; }
        public virtual ICollection<SizeRingImageSetup> SizeRingImageSetup { get; set; }
        public virtual ICollection<TwillTapeImage_Setup> TwillTapeImageSetup { get; set; }
        public virtual ICollection<VelcroImageSetup> VelcroImageSetup { get; set; }
        public virtual ICollection<ZipPullerImageSetup> ZipPullerImageSetup { get; set; }
        public virtual ICollection<ZipSliderImageSetup> ZipSliderImageSetup { get; set; }
        public virtual ICollection<ZipStudImageSetup> ZipStudImageSetup { get; set; }
    }
}
