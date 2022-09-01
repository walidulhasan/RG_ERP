using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class TblTempCutToPack
    {
        public decimal? OrderId { get; set; }
        public string OrderName { get; set; }
        public decimal? StyleId { get; set; }
        public string StyleName { get; set; }
        public decimal? ColorId { get; set; }
        public string ColorName { get; set; }
        public decimal? SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal? PatternPieceId { get; set; }
        public string PatternPiece { get; set; }
        public decimal? OrderQty { get; set; }
        public decimal? CutI { get; set; }
        public decimal? CutRj { get; set; }
        public decimal? CutD { get; set; }
        public decimal? EmbR { get; set; }
        public decimal? EmbI { get; set; }
        public decimal? EmbRj { get; set; }
        public decimal? EmbD { get; set; }
        public decimal? PrintR { get; set; }
        public decimal? PrintI { get; set; }
        public decimal? PrintRj { get; set; }
        public decimal? PrintD { get; set; }
        public decimal? StitR { get; set; }
        public decimal? StitI { get; set; }
        public decimal? StitRj { get; set; }
        public decimal? StitD { get; set; }
        public decimal? WashR { get; set; }
        public decimal? WashC { get; set; }
        public decimal? WashIss { get; set; }
        public decimal? FinishR { get; set; }
        public decimal? FinishC { get; set; }
        public decimal? FinishIss { get; set; }
        public decimal? FinishRr { get; set; }
    }
}
