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
    /// Model for UploadsResult
    /// </summary>
    [DataContract]
    public class UploadsResponse : IEquatable<UploadsResponse>
    {
        
        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }
  
        
        /// <summary>
        /// Gets or Sets Uploaded
        /// </summary>
        [DataMember(Name="uploaded", EmitDefaultValue=false)]
        public List<Uploaded> Uploaded { get; set; }
  
        
  
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UploadsResponse {\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Uploaded: ").Append(Uploaded).Append("\n");
            
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
            return this.Equals(obj as UploadsResponse);
        }

        /// <summary>
        /// Returns true if UploadsResponse instances are equal
        /// </summary>
        /// <param name="obj">Instance of UploadsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UploadsResponse other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Status == other.Status ||
                    this.Status != null &&
                    this.Status.Equals(other.Status)
                ) && 
                (
                    this.Uploaded == other.Uploaded ||
                    this.Uploaded != null &&
                    this.Uploaded.SequenceEqual(other.Uploaded)
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
                
                if (this.Status != null)
                    hash = hash * 57 + this.Status.GetHashCode();
                
                if (this.Uploaded != null)
                    hash = hash * 57 + this.Uploaded.GetHashCode();
                
                return hash;
            }
        }

    }
}
