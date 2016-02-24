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
    /// Model for Cropping
    /// </summary>
    [DataContract]
    public class Cropping : IEquatable<Cropping>
    {
        
        /// <summary>
        /// Gets or Sets TargetHeight
        /// </summary>
        [DataMember(Name="target_height", EmitDefaultValue=false)]
        public int? TargetHeight { get; set; }
  
        
        /// <summary>
        /// Gets or Sets TargetWidth
        /// </summary>
        [DataMember(Name="target_width", EmitDefaultValue=false)]
        public int? TargetWidth { get; set; }
  
        
        /// <summary>
        /// Gets or Sets X1
        /// </summary>
        [DataMember(Name="x1", EmitDefaultValue=false)]
        public int? X1 { get; set; }
  
        
        /// <summary>
        /// Gets or Sets X2
        /// </summary>
        [DataMember(Name="x2", EmitDefaultValue=false)]
        public int? X2 { get; set; }
  
        
        /// <summary>
        /// Gets or Sets Y1
        /// </summary>
        [DataMember(Name="y1", EmitDefaultValue=false)]
        public int? Y1 { get; set; }
  
        
        /// <summary>
        /// Gets or Sets Y2
        /// </summary>
        [DataMember(Name="y2", EmitDefaultValue=false)]
        public int? Y2 { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Cropping {\n");
            sb.Append("  TargetHeight: ").Append(TargetHeight).Append("\n");
            sb.Append("  TargetWidth: ").Append(TargetWidth).Append("\n");
            sb.Append("  X1: ").Append(X1).Append("\n");
            sb.Append("  X2: ").Append(X2).Append("\n");
            sb.Append("  Y1: ").Append(Y1).Append("\n");
            sb.Append("  Y2: ").Append(Y2).Append("\n");
            
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
            return this.Equals(obj as Cropping);
        }

        /// <summary>
        /// Returns true if Cropping instances are equal
        /// </summary>
        /// <param name="obj">Instance of Cropping to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Cropping other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.TargetHeight == other.TargetHeight ||
                    this.TargetHeight != null &&
                    this.TargetHeight.Equals(other.TargetHeight)
                ) && 
                (
                    this.TargetWidth == other.TargetWidth ||
                    this.TargetWidth != null &&
                    this.TargetWidth.Equals(other.TargetWidth)
                ) && 
                (
                    this.X1 == other.X1 ||
                    this.X1 != null &&
                    this.X1.Equals(other.X1)
                ) && 
                (
                    this.X2 == other.X2 ||
                    this.X2 != null &&
                    this.X2.Equals(other.X2)
                ) && 
                (
                    this.Y1 == other.Y1 ||
                    this.Y1 != null &&
                    this.Y1.Equals(other.Y1)
                ) && 
                (
                    this.Y2 == other.Y2 ||
                    this.Y2 != null &&
                    this.Y2.Equals(other.Y2)
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
                
                if (this.TargetHeight != null)
                    hash = hash * 57 + this.TargetHeight.GetHashCode();
                
                if (this.TargetWidth != null)
                    hash = hash * 57 + this.TargetWidth.GetHashCode();
                
                if (this.X1 != null)
                    hash = hash * 57 + this.X1.GetHashCode();
                
                if (this.X2 != null)
                    hash = hash * 57 + this.X2.GetHashCode();
                
                if (this.Y1 != null)
                    hash = hash * 57 + this.Y1.GetHashCode();
                
                if (this.Y2 != null)
                    hash = hash * 57 + this.Y2.GetHashCode();
                
                return hash;
            }
        }

    }
}
