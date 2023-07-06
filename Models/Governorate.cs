using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WMS.Models;

public class Governorate
{
    public int GovernorateId { get; set; }
    public string GovernorateName { get; set; }
    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Directorate>? Directorates { get; set; }
    public virtual ICollection<Office>? Offices { get; set; }

    public Governorate()
    {
        CreatedDate = DateTime.Now;
       /* Directorates = new HashSet<Directorate>();
        Offices = new HashSet<Office>();*/
    }
}