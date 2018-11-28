public class CoolingController {
    public void setTemperatureUpperLimit(int defaultCoolingTemp) {
        System.out.println("Cooling Controller set temperature to " + defaultCoolingTemp);
    }

    public void run() {
        System.out.println("Cooling Controller run");
    }

    public void cool(int maxAllowedTemp) {
        System.out.println("Cooling Controller cool to " + maxAllowedTemp + " temperature");
    }

    public void stop() {
        System.out.println("Cooling Controller stop");
    }
}
