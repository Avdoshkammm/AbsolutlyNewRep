using System;
using System.Collections.Generic;

namespace CRUDFromASV.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Cost { get; set; }

    public string Description { get; set; } = null!;
}
