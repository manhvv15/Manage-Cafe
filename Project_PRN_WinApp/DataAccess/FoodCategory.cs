using System;
using System.Collections.Generic;

namespace Project_PRN_WinApp.DataAccess;

public partial class FoodCategory
{
    public FoodCategory()
    {
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Food> Foods { get; } = new List<Food>();
}
