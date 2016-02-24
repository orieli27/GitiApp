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
    /// Model for TaggingResponse
    /// </summary>
    [DataContract]
    public class TaggingResponse : IEquatable<TaggingResponse>
    {
        
        /// <summary>
        /// Gets or Sets Results
        /// </summary>
        [DataMember(Name="results", EmitDefaultValue=false)]
        public List<TaggingResult> Results { get; set; }
  
        
        /// <summary>
        /// Gets or Sets Unsuccessful
        /// </summary>
        [DataMember(Name="unsuccessful", EmitDefaultValue=false)]
        public UnsuccessfulResult Unsuccessful { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TaggingResponse {\n");
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
            return this.Equals(obj as TaggingResponse);
        }

        /// <summary>
        /// Returns true if TaggingResponse instances are equal
        /// </summary>
        /// <param name="obj">Instance of TaggingResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TaggingResponse other)
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
                    this.Unsuccessful.Equals(other.Unsuccessful)
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
