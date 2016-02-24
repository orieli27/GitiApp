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
    /// Model for Info
    /// </summary>
    [DataContract]
    public class Info : IEquatable<Info>
    {
        
        /// <summary>
        /// Gets or Sets BackgroundColors
        /// </summary>
        [DataMember(Name="background_colors", EmitDefaultValue=false)]
        public List<BackgroundColor> BackgroundColors { get; set; }
  
        
        /// <summary>
        /// Gets or Sets ColorPercentThreshold
        /// </summary>
        [DataMember(Name="color_percent_threshold", EmitDefaultValue=false)]
        public float? ColorPercentThreshold { get; set; }
  
        
        /// <summary>
        /// Gets or Sets ColorVariance
        /// </summary>
        [DataMember(Name="color_variance", EmitDefaultValue=false)]
        public string ColorVariance { get; set; }
  
        
        /// <summary>
        /// Gets or Sets ForegroundColors
        /// </summary>
        [DataMember(Name="foreground_colors", EmitDefaultValue=false)]
        public List<ForegroundColor> ForegroundColors { get; set; }
  
        
        /// <summary>
        /// Gets or Sets ImageColors
        /// </summary>
        [DataMember(Name="image_colors", EmitDefaultValue=false)]
        public List<ImageColor> ImageColors { get; set; }
  
        
        /// <summary>
        /// Gets or Sets ObjectPercentage
        /// </summary>
        [DataMember(Name="object_percentage", EmitDefaultValue=false)]
        public string ObjectPercentage { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Info {\n");
            sb.Append("  BackgroundColors: ").Append(BackgroundColors).Append("\n");
            sb.Append("  ColorPercentThreshold: ").Append(ColorPercentThreshold).Append("\n");
            sb.Append("  ColorVariance: ").Append(ColorVariance).Append("\n");
            sb.Append("  ForegroundColors: ").Append(ForegroundColors).Append("\n");
            sb.Append("  ImageColors: ").Append(ImageColors).Append("\n");
            sb.Append("  ObjectPercentage: ").Append(ObjectPercentage).Append("\n");
            
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
            return this.Equals(obj as Info);
        }

        /// <summary>
        /// Returns true if Info instances are equal
        /// </summary>
        /// <param name="obj">Instance of Info to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Info other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.BackgroundColors == other.BackgroundColors ||
                    this.BackgroundColors != null &&
                    this.BackgroundColors.SequenceEqual(other.BackgroundColors)
                ) && 
                (
                    this.ColorPercentThreshold == other.ColorPercentThreshold ||
                    this.ColorPercentThreshold != null &&
                    this.ColorPercentThreshold.Equals(other.ColorPercentThreshold)
                ) && 
                (
                    this.ColorVariance == other.ColorVariance ||
                    this.ColorVariance != null &&
                    this.ColorVariance.Equals(other.ColorVariance)
                ) && 
                (
                    this.ForegroundColors == other.ForegroundColors ||
                    this.ForegroundColors != null &&
                    this.ForegroundColors.SequenceEqual(other.ForegroundColors)
                ) && 
                (
                    this.ImageColors == other.ImageColors ||
                    this.ImageColors != null &&
                    this.ImageColors.SequenceEqual(other.ImageColors)
                ) && 
                (
                    this.ObjectPercentage == other.ObjectPercentage ||
                    this.ObjectPercentage != null &&
                    this.ObjectPercentage.Equals(other.ObjectPercentage)
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
                
                if (this.BackgroundColors != null)
                    hash = hash * 57 + this.BackgroundColors.GetHashCode();
                
                if (this.ColorPercentThreshold != null)
                    hash = hash * 57 + this.ColorPercentThreshold.GetHashCode();
                
                if (this.ColorVariance != null)
                    hash = hash * 57 + this.ColorVariance.GetHashCode();
                
                if (this.ForegroundColors != null)
                    hash = hash * 57 + this.ForegroundColors.GetHashCode();
                
                if (this.ImageColors != null)
                    hash = hash * 57 + this.ImageColors.GetHashCode();
                
                if (this.ObjectPercentage != null)
                    hash = hash * 57 + this.ObjectPercentage.GetHashCode();
                
                return hash;
            }
        }

    }
}
