using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using PathCreation;
public class MSEquationManager : MonoBehaviour
{
    public Slider magneticFieldStrengthSliderCoarse;
    public Slider magneticFieldStrengthSliderFine;

    public float magneticFieldStrengthCoarse;
    public float magneticFieldStrengthFine;
    public float magneticFieldStrength;

    public TextMeshProUGUI magneticFieldStrengthValueText, correctMagneticFieldStrengthText;

    public PathCreator pathCreator;

    private void Update()
    {
        //UpdateValues();
        
    }
    public void UpdateValues()
    {
        magneticFieldStrengthCoarse = RoundValueToInterval(magneticFieldStrengthSliderCoarse.value, 1000);
        magneticFieldStrengthFine = RoundValueToInterval(magneticFieldStrengthSliderFine.value, 1);
        magneticFieldStrength = magneticFieldStrengthCoarse + magneticFieldStrengthFine;
        magneticFieldStrengthValueText.text = magneticFieldStrength.ToString() + " Gauss";

    }

    public float TwoDecimalRound(float value)
    {
        return Mathf.Round(value * 100f) / 100f;
    }

    public float RoundValueToInterval(float value, float interval)
    {
        value = Mathf.Round(value / interval) * interval;
        return value;
    }

    public float CalculateCorrectBValue(float elementMass)
    {
        float radius = 0.23f; //centimeters
        float mass = elementMass; //element mass
        float voltage = 10000f; //10kV = 10,000V
        float charge = 1f;
        float correctMagneticFieldValue = Mathf.Sqrt(2 * mass * voltage / charge) / radius;
        correctMagneticFieldStrengthText.text = correctMagneticFieldValue.ToString();  
        return correctMagneticFieldValue;

    }
}
