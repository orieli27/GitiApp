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
    /// Model for CroppingsResult
    /// </summary>
    [DataContract]
    public class CroppingsResult : IEquatable<CroppingsResult>
    {
        
        /// <summary>
        /// Gets or Sets Croppings
        /// </summary>
        [DataMember(Name="croppings", EmitDefaultValue=false)]
        public List<Cropping> Croppings { get; set; }
  
        
        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [DataMember(Name="image", EmitDefaultValue=false)]
        public string Image { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CroppingsResult {\n");
            sb.Append("  Croppings: ").Append(Croppings).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            
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
            return this.Equals(obj as CroppingsResult);
        }

        /// <summary>
        /// Returns true if CroppingsResult instances are equal
        /// </summary>
        /// <param name="obj">Instance of CroppingsResult to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CroppingsResult other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Croppings == other.Croppings ||
                    this.Croppings != null &&
                    this.Croppings.SequenceEqual(other.Croppings)
                ) && 
                (
                    this.Image == other.Image ||
                    this.Image != null &&
                    this.Image.Equals(other.Image)
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
                
                if (this.Croppings != null)
                    hash = hash * 57 + this.Croppings.GetHashCode();
                
                if (this.Image != null)
                    hash = hash * 57 + this.Image.GetHashCode();
                
                return hash;
            }
        }

    }
}
