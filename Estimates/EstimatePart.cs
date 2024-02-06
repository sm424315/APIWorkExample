using System.Collections.Generic;
using TharstenAPI.Models.Dimensions;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.Estimates
{
    public class EstimatePart
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? LineNumber { get; set; }
        public int? SubstrateId { get; set; }
        public int? ProductTypePartId { get; set; }
        public Dimension StockDimensions { get; set; }
        public string InkProfileFace { get; set; }
        public string InkProfileReverse { get; set; }
        public string ColoursFace { get; set; }
        public string ColoursReverse { get; set; }
        public string ProcessInksFace { get; set; }
        public string ProcessInksReverse { get; set; }
        public string SpotInksFace { get; set; }
        public string SpotInksReverse { get; set; }
        public string MetallicInksFace { get; set; }
        public string MetallicInksReverse { get; set; }
        public int? TotalPages { get; set; }
        public int? FoldingHeaderId { get; set; }
        public EnumValueAndName Orientation { get; set; }
        public Dimension FinishedSize { get; set; }
        public float? FlatWidth { get; set; }
        public string Seal1Side { get; set; }
        public string Seal1Type { get; set; }
        public string Seal2Side { get; set; }
        public string Seal2Type { get; set; }
        public List<EstimateProcess> Processes { get; set; }
        public List<EstimateVersion> Versions { get; set; }
        public float? BleedTop { get; set; }
        public float? GutterHorizontal { get; set; }
        public float? BleedBottom { get; set; }
        public float? BleedLeft { get; set; }
        public float? BleedRight { get; set; }
        public float? GutterVertical { get; set; }

    }
}