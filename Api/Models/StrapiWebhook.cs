using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class StrapiWebhook
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public string? Headers { get; set; }

    public string? Events { get; set; }

    public bool? Enabled { get; set; }
}
