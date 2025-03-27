public class PatientVitalsService
{
    public void RecordVitals(
        int patientId,
        double temperature,
        int systolic,
        int diastolic,
        int heartRate,
        string bloodType,
        int age,     
        DateTime lastMealTime)
    {
        // Temperature validation
        if (temperature < 34 || temperature > 42)
            throw new ArgumentException("Invalid temperature");
        
        // Blood pressure validation (basic)
        if (systolic < 70 || systolic > 200)
            throw new ArgumentException("Invalid systolic BP");
        if (diastolic < 40 || diastolic > 120)
            throw new ArgumentException("Invalid diastolic BP");
        if (diastolic > systolic)
            throw new ArgumentException("Diastolic cannot exceed systolic");

        // Heart rate validation (age-dependent)
        int maxHeartRate = 220 - age;
        if (heartRate < 40 || heartRate > maxHeartRate * 1.2)
            throw new ArgumentException($"Heart rate invalid for age {age}");

        // Blood type validation
        if (!new[] {"A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"}.Contains(bloodType))
            throw new ArgumentException("Invalid blood type");
     

        // Meal timing affects blood pressure readings
        if ((DateTime.Now - lastMealTime).TotalHours < 2 && diastolic > 90)
            TriggerAlert("Elevated postprandial blood pressure");

       
    }
}