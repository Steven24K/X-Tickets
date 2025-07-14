using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class OrdersPaymentLnk
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? PaymentId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Payment? Payment { get; set; }
}
