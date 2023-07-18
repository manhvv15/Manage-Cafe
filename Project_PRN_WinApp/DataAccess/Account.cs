using System;
using System.Collections.Generic;

namespace Project_PRN_WinApp.DataAccess;

public partial class Account
{
    public Account()
    {
    }

    public string UserName { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Type { get; set; }
}
