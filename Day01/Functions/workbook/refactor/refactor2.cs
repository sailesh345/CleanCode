public class OrderService
{
   
    public void ProcessOrder(Order order)
    {
        
        if (order == null)
            throw new ArgumentNullException(nameof(order));
        if (order.Items.Count == 0)
            throw new InvalidOperationException("Order has no items");

        
        decimal subtotal = order.Items.Sum(item => item.Price * item.Quantity);
        decimal tax = subtotal * 0.08m; 
        order.Total = subtotal + tax;

        SaveToDatabase(order);
        SendConfirmationEmail(order.CustomerEmail, order.Total);
    }


    public void ApplyDiscount(Order order, decimal discountPercent)
    {

        if (order == null)
            throw new ArgumentNullException(nameof(order));
        if (order.Items.Count == 0)
            throw new InvalidOperationException("Order has no items");


        decimal subtotal = order.Items.Sum(item => item.Price * item.Quantity);
        decimal tax = subtotal * 0.08m;
        order.Total = (subtotal + tax) * (1 - discountPercent);

        UpdateDatabase(order);
    }
}