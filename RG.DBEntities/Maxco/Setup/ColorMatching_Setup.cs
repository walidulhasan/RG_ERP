using RG.DBEntities.Maxco.Trims;
using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.Maxco.Setup
{
    public class ColorMatching_Setup
    {
        public ColorMatching_Setup()
        {
            BeadColor = new HashSet<BeadColor>();
            BuckleColor = new HashSet<BuckleColor>();
            ButtonColor = new HashSet<ButtonColor>();
            ChordholderColor = new HashSet<ChordholderColor>();
            EyeletColor = new HashSet<EyeletColor>();
            FurColor = new HashSet<FurColor>();
            LaceColor = new HashSet<LaceColor>();
            NetMeshColor = new HashSet<NetMeshColor>();
            SizeRingColor = new HashSet<SizeRingColor>();
            ThreadColor2 = new HashSet<ThreadColor2>();
            TwillTapeColor = new HashSet<TwillTapeColor>();
            ZipColor = new HashSet<ZipColor>();
        }

        public int ID { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BeadColor> BeadColor { get; set; }
        public virtual ICollection<BuckleColor> BuckleColor { get; set; }
        public virtual ICollection<ButtonColor> ButtonColor { get; set; }
        public virtual ICollection<ChordholderColor> ChordholderColor { get; set; }
        public virtual ICollection<EyeletColor> EyeletColor { get; set; }
        public virtual ICollection<FurColor> FurColor { get; set; }
        public virtual ICollection<LaceColor> LaceColor { get; set; }
        public virtual ICollection<NetMeshColor> NetMeshColor { get; set; }
        public virtual ICollection<SizeRingColor> SizeRingColor { get; set; }
        public virtual ICollection<ThreadColor2> ThreadColor2 { get; set; }
        public virtual ICollection<TwillTapeColor> TwillTapeColor { get; set; }
        public virtual ICollection<ZipColor> ZipColor { get; set; }
    }
}
