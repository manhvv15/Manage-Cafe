using System;
using System.Collections.Generic;

namespace Project_PRN_WinApp.DataAccess;

public partial class BillDetail
{
    public BillDetail()
    {
    }

    public BillDetail(int billID, int foodID, int quantity)
    {
        this.IdBill = billID;
        this.Idfood = foodID;
        this.Count = quantity;
    }

    public int Id { get; set; }

    public int IdBill { get; set; }

    public int Idfood { get; set; }

    public int Count { get; set; }

    public virtual Bill IdBillNavigation { get; set; } = null!;

    public virtual Food IdfoodNavigation { get; set; } = null!;
}
