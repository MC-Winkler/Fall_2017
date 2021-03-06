package headfirst.seniorstudent2;

import static org.junit.Assert.*;

import java.awt.BorderLayout;
import java.awt.Container;
import java.awt.GridLayout;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.util.Observable;
import java.util.Observer;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.SwingConstants;

import org.junit.Test;

public class WeatherDataTest {

	class CurrentConditionsDisplay1 extends JFrame implements Observer {

		Observable observable;
		private JTextField humidityTextField;
		private JTextField pressureTextField;
		private JTextField temperatureTextField;

		public CurrentConditionsDisplay1(Observable observable, int x, int y) {
			this.setTitle("Current Conditions");
			this.observable = observable;
			// Key to register his observer with Observable.
			observable.addObserver(this);
			createGui();
			this.setLocation(x, y);
			this.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
			this.addWindowListener(new WindowAdapter() {
				/**
				 * Remove the observer from the Subject so no attempt is made by
				 * Subject to nofify a non existing instance that is closed
				 */
				@Override
				public void windowClosing(WindowEvent e) {
					System.out.println("Removed observer");
					removeTheObserver();
				}
			});
			this.pack();
			this.setVisible(true);
		}

		/**
		 * Observer method called when data changes in WeatherData. The method
		 * supplies the three data values needed by GUI
		 * 
		 * @param temperature
		 *            float of temperature in degrees
		 * @param humidity
		 *            float of relative humidity
		 * @param pressure
		 *            float of the measured barometric pressure
		 * @see headfirst.seniorstudent1.Observer#updateData(float, float,
		 *      float)
		 */
		@Override
		public void update(Observable obs, Object arg) {
			if (obs instanceof WeatherData) {
				WeatherData weatherData = (WeatherData) obs;
				temperatureTextField.setText("" + weatherData.getTemperature());
				humidityTextField.setText("" + weatherData.getHumidity());
				pressureTextField.setText("" + weatherData.getPressure());
			}
		}

		private void createGui() {
			Container container = this.getContentPane();
			JPanel holdGrid = new JPanel();
			JPanel leftGrid = new JPanel();
			JPanel rightGrid = new JPanel();

			leftGrid.setLayout(new GridLayout(3, 1));
			leftGrid.add(new JLabel("Current Temperature ", SwingConstants.RIGHT));
			leftGrid.add(new JLabel("Current Humidity ", SwingConstants.RIGHT));
			leftGrid.add(new JLabel("Current Pressure ", SwingConstants.RIGHT));

			rightGrid.setLayout(new GridLayout(3, 1));
			rightGrid.add(temperatureTextField = new JTextField("0", 10));
			rightGrid.add(humidityTextField = new JTextField("0", 10));
			rightGrid.add(pressureTextField = new JTextField("0", 10));

			holdGrid.setLayout(new BorderLayout(5, 0));
			holdGrid.add(leftGrid, BorderLayout.WEST);
			holdGrid.add(rightGrid, BorderLayout.CENTER);
			container.add(holdGrid, BorderLayout.CENTER);
		}

		private void removeTheObserver() {
			observable.deleteObserver(this);
		}
	}

	@Test
	public void testSetMeasurements() {
		WeatherData weatherData = new WeatherData();
		CurrentConditionsDisplay1 c = new CurrentConditionsDisplay1(weatherData, 0, 0);
		weatherData.setMeasurements(12, 5, 50);
		assertEquals(weatherData.getTemperature(), 12, 0);
		assertEquals(weatherData.getHumidity(), 5, 0);
		assertEquals(weatherData.getPressure(), 50, 0);
		assertEquals(Double.parseDouble(c.temperatureTextField.getText()), 12.0, 0);
		assertEquals(Double.parseDouble(c.humidityTextField.getText()), 5.0, 0);
		assertEquals(Double.parseDouble(c.pressureTextField.getText()), 50.0, 0);
	}

	@Test
	public void testAddObserver() {
		WeatherData weatherData = new WeatherData();
		assertEquals(weatherData.countObservers(), 0, 0);
		new CurrentConditionsDisplay(weatherData, 300, 440);
		assertEquals(weatherData.countObservers(), 1, 0);
	}

	@Test
	public void testDeleteObserver() {
		WeatherData weatherData = new WeatherData();
		assertEquals(weatherData.countObservers(), 0, 0);
		CurrentConditionsDisplay testDisplay = new CurrentConditionsDisplay(weatherData, 300, 440);
		assertEquals(weatherData.countObservers(), 1, 0);
		weatherData.deleteObserver(testDisplay);
		assertEquals(weatherData.countObservers(), 0, 0);
	}

}
