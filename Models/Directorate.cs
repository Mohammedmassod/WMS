using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WMS.Models;

public class Directorate
{
    public int DirectorateId { get; set; }
    public string DirectorateName { get; set; }
    public int GovernorateId { get; set; }
    public virtual Governorate Governorate { get; set; }
    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Office> Offices { get; set; }

    public Directorate()
    {
        CreatedDate = DateTime.Now;
        Offices = new HashSet<Office>();
    }
}