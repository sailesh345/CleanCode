public void ProcessOrder(Order order) 
{
    // Validate order
    if (order == null) throw new ArgumentNullException();
    if (order.Items.Count == 0) throw new InvalidOperationException("Empty order");
    
    // Calculate total
    decimal total = 0;
    foreach (var item in order.Items) 
    {
        total += item.Price * item.Quantity;
        if (item.IsTaxable) 
        {
            total += item.Price * 0.1m; // 10% tax
        }
    }

    // Apply discount
    if (order.Customer.IsPremium) 
    {
        total *= 0.9m; // 10% discount
    }

    // Save to DB
    using (var db = new AppDbContext()) 
    {
        order.Total = total;
        db.Orders.Add(order);
        db.SaveChanges();
    }

    // Send confirmation email
    var emailService = new EmailService();
    emailService.Send(order.Customer.Email, "Order Confirmed", $"Total: ${total}");
}