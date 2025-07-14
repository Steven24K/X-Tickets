using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiCoreStoreSetting
{
    public int Id { get; set; }

    public string? Key { get; set; }

    public string? Value { get; set; }

    public string? Type { get; set; }

    public string? Environment { get; set; }

    public string? Tag { get; set; }
}
