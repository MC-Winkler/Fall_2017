import java.util.Iterator;

public class NullIterator implements Iterator<CarComponent>{

	@Override
	public boolean hasNext() {
		return false;
	}

	@Override
	public CarComponent next() {
		return null;
	}

	public void remove() {
		throw new UnsupportedOperationException();
	}
	
}
