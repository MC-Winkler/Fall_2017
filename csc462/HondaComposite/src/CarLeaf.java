import java.util.Iterator;

public class CarLeaf extends CarComponent {
	String name;
	double price;

	public CarLeaf(String name, double price) {
		this.name = name;
		this.price = price;
	}

	public String getName() {
		return name;
	}

	public double getPrice() {
		return price;
	}

	public void print() {
		System.out.print(getName());
		if (price > 0){
			int justifyAmount = 60 - name.length();
			String formatString = "%" + justifyAmount + "s";
			System.out.printf(formatString, "$" + getPrice());
		}
		System.out.println();
	}

	public Iterator<CarComponent> createIterator() {
		return new NullIterator();
	}
}
