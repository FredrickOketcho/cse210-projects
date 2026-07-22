using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        double shippingCost = _customer.LivesInUSA() ? 5.00 : 35.00;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (var product in _products)
        {
            sb.AppendLine($"- {product.GetName()} (ID: {product.GetProductId()})");
        }
        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetAddressString()}";
    }
}