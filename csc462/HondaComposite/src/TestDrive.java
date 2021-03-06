
public class TestDrive {

	public static void main (String[] args){
		CarComposite theCar = new CarComposite ("Summary");
		CarComposite model = new CarComposite("Model");
		CarLeaf modelDetails = new CarLeaf("2016 CR-Z EX, Manual", 22140.00);
		CarComposite colors = new CarComposite("Colors");
		CarLeaf exteriorColor = new CarLeaf ("Exterior: Milano Red",0);
		CarLeaf interiorColor = new CarLeaf ("Interior: Black/Orange",0);
		CarComposite accessories = new CarComposite ("Accessories");
		CarComposite exteriorAccessories = new CarComposite("Exterior");
		CarLeaf spoiler = new CarLeaf ("Tailgate Spoiler", 430);
		CarComposite interiorAccessories = new CarComposite ("Interior");
		CarLeaf floorMats = new CarLeaf ("All Season Floor Mats", 99.00);
		CarLeaf handling = new CarLeaf ("Destination and handling", 835.00);
		
		theCar.add(model);
		theCar.add(colors);
		theCar.add(accessories);
		
		model.add(modelDetails);
		
		colors.add(exteriorColor);
		colors.add(interiorColor);
		
		accessories.add(exteriorAccessories);
		accessories.add(interiorAccessories);
		
		exteriorAccessories.add(spoiler);
		
		interiorAccessories.add(floorMats);
		interiorAccessories.add(handling);
		
		theCar.print();
		System.out.printf("%60s", "Total MSRP as built $" + theCar.getPrice());
	}
	
}
