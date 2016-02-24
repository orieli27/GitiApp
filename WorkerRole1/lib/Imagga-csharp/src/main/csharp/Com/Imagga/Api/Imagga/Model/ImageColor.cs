using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Com.Imagga.Api.Imagga.Model
{

    /// <summary>
    /// Model for ImageColor
    /// </summary>
    [DataContract]
    public class ImageColor : IEquatable<ImageColor>
    {
        
        /// <summary>
        /// Gets or Sets B
        /// </summary>
        [DataMember(Name="b", EmitDefaultValue=false)]
        public string B { get; set; }
  
        
        /// <summary>
        /// Gets or Sets ClosestPaletteColor
        /// </summary>
        [DataMember(Name="closest_palette_color", EmitDefaultValue=false)]
        public string ClosestPaletteColor { get; set; }
  
        
        /// <summary>
        /// Gets or Sets ClosestPaletteColorHtmlCode
        /// </summary>
        [DataMember(Name="closest_palette_color_html_code", EmitDefaultValue=false)]
        public string ClosestPaletteColorHtmlCode { get; set; }
  
        
        /// <summary>
        /// Gets or Sets ClosestPaletteColorParent
        /// </summary>
        [DataMember(Name="closest_palette_color_parent", EmitDefaultValue=false)]
        public string ClosestPaletteColorParent { get; set; }
  
        
        /// <summary>
        /// Gets or Sets ClosestPaletteDistance
        /// </summary>
        [DataMember(Name="closest_palette_distance", EmitDefaultValue=false)]
        public float? ClosestPaletteDistance { get; set; }
  
        
        /// <summary>
        /// Gets or Sets G
        /// </summary>
        [DataMember(Name="g", EmitDefaultValue=false)]
        public string G { get; set; }
  
        
        /// <summary>
        /// Gets or Sets HtmlCode
        /// </summary>
        [DataMember(Name="html_code", EmitDefaultValue=false)]
        public string HtmlCode { get; set; }
  
        
        /// <summary>
        /// Gets or Sets Percent
        /// </summary>
        [DataMember(Name="percent", EmitDefaultValue=false)]
        public float? Percent { get; set; }
  
        
        /// <summary>
        /// Gets or Sets R
        /// </summary>
        [DataMember(Name="r", EmitDefaultValue=false)]
        public string R { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ImageColor {\n");
            sb.Append("  B: ").Append(B).Append("\n");
            sb.Append("  ClosestPaletteColor: ").Append(ClosestPaletteColor).Append("\n");
            sb.Append("  ClosestPaletteColorHtmlCode: ").Append(ClosestPaletteColorHtmlCode).Append("\n");
            sb.Append("  ClosestPaletteColorParent: ").Append(ClosestPaletteColorParent).Append("\n");
            sb.Append("  ClosestPaletteDistance: ").Append(ClosestPaletteDistance).Append("\n");
            sb.Append("  G: ").Append(G).Append("\n");
            sb.Append("  HtmlCode: ").Append(HtmlCode).Append("\n");
            sb.Append("  Percent: ").Append(Percent).Append("\n");
            sb.Append("  R: ").Append(R).Append("\n");
            
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as ImageColor);
        }

        /// <summary>
        /// Returns true if ImageColor instances are equal
        /// </summary>
        /// <param name="obj">Instance of ImageColor to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ImageColor other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.B == other.B ||
                    this.B != null &&
                    this.B.Equals(other.B)
                ) && 
                (
                    this.ClosestPaletteColor == other.ClosestPaletteColor ||
                    this.ClosestPaletteColor != null &&
                    this.ClosestPaletteColor.Equals(other.ClosestPaletteColor)
                ) && 
                (
                    this.ClosestPaletteColorHtmlCode == other.ClosestPaletteColorHtmlCode ||
                    this.ClosestPaletteColorHtmlCode != null &&
                    this.ClosestPaletteColorHtmlCode.Equals(other.ClosestPaletteColorHtmlCode)
                ) && 
                (
                    this.ClosestPaletteColorParent == other.ClosestPaletteColorParent ||
                    this.ClosestPaletteColorParent != null &&
                    this.ClosestPaletteColorParent.Equals(other.ClosestPaletteColorParent)
                ) && 
                (
                    this.ClosestPaletteDistance == other.ClosestPaletteDistance ||
                    this.ClosestPaletteDistance != null &&
                    this.ClosestPaletteDistance.Equals(other.ClosestPaletteDistance)
                ) && 
                (
                    this.G == other.G ||
                    this.G != null &&
                    this.G.Equals(other.G)
                ) && 
                (
                    this.HtmlCode == other.HtmlCode ||
                    this.HtmlCode != null &&
                    this.HtmlCode.Equals(other.HtmlCode)
                ) && 
                (
                    this.Percent == other.Percent ||
                    this.Percent != null &&
                    this.Percent.Equals(other.Percent)
                ) && 
                (
                    this.R == other.R ||
                    this.R != null &&
                    this.R.Equals(other.R)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                
                if (this.B != null)
                    hash = hash * 57 + this.B.GetHashCode();
                
                if (this.ClosestPaletteColor != null)
                    hash = hash * 57 + this.ClosestPaletteColor.GetHashCode();
                
                if (this.ClosestPaletteColorHtmlCode != null)
                    hash = hash * 57 + this.ClosestPaletteColorHtmlCode.GetHashCode();
                
                if (this.ClosestPaletteColorParent != null)
                    hash = hash * 57 + this.ClosestPaletteColorParent.GetHashCode();
                
                if (this.ClosestPaletteDistance != null)
                    hash = hash * 57 + this.ClosestPaletteDistance.GetHashCode();
                
                if (this.G != null)
                    hash = hash * 57 + this.G.GetHashCode();
                
                if (this.HtmlCode != null)
                    hash = hash * 57 + this.HtmlCode.GetHashCode();
                
                if (this.Percent != null)
                    hash = hash * 57 + this.Percent.GetHashCode();
                
                if (this.R != null)
                    hash = hash * 57 + this.R.GetHashCode();
                
                return hash;
            }
        }

    }
}
