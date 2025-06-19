public class FinancialForecast {

    public static double futureValue(double initialValue, double growthRate, int periods) {
        if (periods == 0) {
            return initialValue; 
        } else {
            return futureValue(initialValue, growthRate, periods - 1) * (1 + growthRate);
        }
    }

    public static void main(String[] args) {
        double initialValue = 1000.0; 
        double growthRate = 0.05;     
        int periods = 5;              

        double result = futureValue(initialValue, growthRate, periods);
        System.out.printf("Future value after %d periods: %.2f\n", periods, result);
    }
}
