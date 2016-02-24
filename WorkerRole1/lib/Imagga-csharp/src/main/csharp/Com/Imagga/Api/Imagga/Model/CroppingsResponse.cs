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
    /// Model for CroppingsResponse
    /// </summary>
    [DataContract]
    public class CroppingsResponse : IEquatable<CroppingsResponse>
    {
        
        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [DataMember(Name="results", EmitDefaultValue=false)]
        public List<CroppingsResult> Results { get; set; }
  
        
        /// <summary>
        /// Gets or Sets Unsuccessful
        /// </summary>
        [DataMember(Name="unsuccessful", EmitDefaultValue=false)]
        public List<UnsuccessfulResult> Unsuccessful { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CroppingsResponse {\n");
            sb.Append("  Results: ").Append(Results).Append("\n");
            sb.Append("  Unsuccessful: ").Append(Unsuccessful).Append("\n");
            
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
            return this.Equals(obj as CroppingsResponse);
        }

        /// <summary>
        /// Returns true if CroppingsResponse instances are equal
        /// </summary>
        /// <param name="obj">Instance of CroppingsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CroppingsResponse other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Results == other.Results ||
                    this.Results != null &&
                    this.Results.SequenceEqual(other.Results)
                ) && 
                (
                    this.Unsuccessful == other.Unsuccessful ||
                    this.Unsuccessful != null &&
                    this.Unsuccessful.SequenceEqual(other.Unsuccessful)
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
                
                if (this.Results != null)
                    hash = hash * 57 + this.Results.GetHashCode();
                
                if (this.Unsuccessful != null)
                    hash = hash * 57 + this.Unsuccessful.GetHashCode();
                
                return hash;
            }
        }

    }
}
