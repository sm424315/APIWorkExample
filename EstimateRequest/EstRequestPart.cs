using Newtonsoft.Json;
using System.Collections.Generic;
using TharstenAPI.Models.Dimensions;
using TharstenAPI.Models.Enums;

namespace TharstenAPI.Models.EstimateRequest
{
    public class EstRequestPart
    {
        public string Name { get; set; }
        public int? Pages { get; set; }
        public string PaperCode { get; set; }
        public int? FoldingHeaderId { get; set; }
        public int? ImpositionTemplateId { get; set; }
        public float? SpineThickness { get; set; }
        public float? SpineToLeftEdge { get; set; }
        public float? SpineToRightEdge { get; set; }
        public bool? SameColours { get; set; }
        public bool? SameImage { get; set; }
        public bool? Bleed { get; set; }
        public bool? SameWidths { get; set; }
        public int? GSM { get; set; }
        public string FrontProcess { get; set; }
        public string FrontSpots { get; set; }
        public string FrontMetallics { get; set; }
        public string BackProcess { get; set; }
        public string BackSpots { get; set; }
        public string BackMetallics { get; set; }
        public string Seal1Side { get; set; }
        public string Seal1Type { get; set; }
        public string Seal2Side { get; set; }
        public string Seal2Type { get; set; }
        public Dimension FinishedSize { get; set; }
        [JsonProperty("ProductTypePartID")]
        public int? ProductTypePartId { get; set; }
        public EnumValueAndName BindingSide { get; set; }
        public string SpecificPress { get; set; }
        public int? Quantity { get; set; }
        public int? NumberCuts { get; set; }
        public bool? IsForceSheetWork { get; set; }
        public float? FlatWidth { get; set; }
        public bool? IsNoPrinting { get; set; }
        public List<EstRequestProcess> Processes { get; set; }
        public List<EstRequestVersion> Versions { get; set; }

    }
}