using System;
using System.Collections.Generic;

namespace Project_PRN_WinApp.DataAccess;

public partial class Food
{
    public Food()
    {
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdCategory { get; set; }

    public double Price { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; } = new List<BillDetail>();

    public virtual FoodCategory IdCategoryNavigation { get; set; } = null!;
}
