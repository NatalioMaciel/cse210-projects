using System.Text;

public class Order
{
    private List<Product> _products = new();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }
        total += _customer.LivesInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var product in _products)
        {
            sb.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
        }

        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}