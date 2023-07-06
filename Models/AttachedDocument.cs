using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WMS.Models
{
    public partial class AttachedDocument
    {
        [Key]
        //"DocumentID")]
        public int DocumentId { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string DocumentName { get; set; } = null!;
        //"RequestID")]
        public int RequestId { get; set; }

        [ForeignKey("RequestId")]
        [InverseProperty("AttachedDocuments")]
        public virtual Request Request { get; set; } = null!;
    }
}
