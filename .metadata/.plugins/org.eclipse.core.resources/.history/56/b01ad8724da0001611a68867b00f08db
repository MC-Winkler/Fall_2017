import java.util.Iterator;

public class CarLeaf extends CarComponent {
	String name;
	String description;
	boolean isFree;
	double price;
	
	public CarLeaf (String name,
			String description,
			boolean isFree,
			double price) {
		this.name = name;
		this.description = description;
		this.isFree = isFree;
		this.price = price;
	}
	
	public String getName(){
		return name;
	}
	
	public String getDescription() {
		return description;
	}
	
	public double getPrice() {
		return price;
	}
	
	public boolean isFree() {
		return isFree;
	}
	
	public void print() {
		System.out.print(getName());
		if (!isFree){
			System.out.print("\t\t\t");
			System.out.print("$" + getPrice());
		}
		System.out.println();
	}
	
	public Iterator<CarComponent> createIterator() {
		return new NullIterator();
	}
}
