import java.util.ArrayList;
import java.util.Iterator;

public class CarComposite extends CarComponent{

	String name;
	ArrayList<CarComponent> carComponents = new ArrayList<CarComponent>();
	Iterator<CarComponent> iterator = null;
	
	public CarComposite(String name){
		this.name = name;
	}

	public String getName() {
		return name;
	}

	public double getPrice() {
		double totalPrice = 0;
		Iterator<CarComponent> iterator = new CompositeIterator (carComponents.iterator());
		while(iterator.hasNext()){
			CarComponent next = iterator.next();
			totalPrice += next.getPrice();
		}
		return totalPrice;
	}
	
	public void add (CarComponent carComponent){
		carComponents.add(carComponent);
	}
	
	public Iterator<CarComponent> createIterator() {
		if (iterator == null){
			iterator = new CompositeIterator(carComponents.iterator());
		}
		return iterator;
	}
	
	public void print() {
		System.out.println(name);
		Iterator<CarComponent> iterator = createIterator();
		while(iterator.hasNext()){
			iterator.next().print();
		}
	}
}