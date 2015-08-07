//Context
public class Order
{
	IShippingStrategy _shippingStrategy; 

	public Order(IShippingStrategy shippingStrategy)
	{
		_shippingStrategy = shippingStrategy;
	}

	IList<OrderItems> items; 

	public getTotal()
	{
		var total = 0;
		foreach(var item in items){
			total += item.Cost + shippingStrategy.getShippingCost(item);
		}
	}
}

//startegy
public interface ITaxCalculationStrategy
{
	public float getShippingCost(item item);
}

//concrete strategy 
public class TwoDayShipping: ITaxCalculationStrategy{
	public float getShippingCost(item item){
		return item.weight * 0.30;
	}
}

//
public class application{
	public static void main(){
		IShippingStrategy shippingStrategy = new TwoDayShipping();

		var Order = new Order(shippingStrategy);

		Order.items.add(new item(){price = 30, weight = 90});
		Order.items.add(new item(){price = 30, weight = 90});
		Order.items.add(new item(){price = 30, weight = 90});

		console.WriteLine( Order.getTotal());
	}
}