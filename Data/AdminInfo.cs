﻿using System;
using System.Collections.Generic;

namespace Ecommerce.API.Data;

public partial class AdminInfo
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string LastLogin { get; set; }

    public string CreatedOn { get; set; }

    public string UpdatedOn { get; set; }
}
