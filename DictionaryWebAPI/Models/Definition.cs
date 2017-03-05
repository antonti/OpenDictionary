namespace DictionaryWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Definition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Definition()
        {
            Words = new HashSet<Word>();
        }

        public int DefinitionID { get; set; }

        [Required]
        [StringLength(4)]
        public string partOfSpeech { get; set; }

        [Required]
        public string definition { get; set; }

        public string example { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Word> Words { get; set; }
    }
}
