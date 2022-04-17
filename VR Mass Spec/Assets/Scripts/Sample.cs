using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sample : MonoBehaviour
{
    public MSEquationManager equationManager;
    public Slider magneticFieldStrengthSlider;
    public Button runButton;
    public IonPathManager pathManager;
    public TextMeshProUGUI resultsText;

    public float sampleMass;
    public int sampleZ;

    private void Awake()
    {
        
        runButton = GameObject.Find("Run Button").GetComponent<Button>();
        pathManager = GameObject.Find("IonPathManager").GetComponent<IonPathManager>();
        equationManager = GameObject.Find("MSEquationManager").GetComponent<MSEquationManager>();
        magneticFieldStrengthSlider = GameObject.Find("MagneticFieldStrengthSlider").GetComponent<Slider>();
        resultsText = GameObject.Find("ResultsText").GetComponent<TextMeshProUGUI>();
    }
    public void DecidePath()
    {
        float correctBField = equationManager.CalculateCorrectBValue(sampleMass);
        print("The correct B field value for the current sample is: " + correctBField);

        float userBField = magneticFieldStrengthSlider.value;
        print("The user B field value is: " + userBField);


        float veryStrong = correctBField + 5.00001f * correctBField / 100f;

        float strongUpper = correctBField + 5 * correctBField / 100f;
        float strongLower = correctBField + 3.00001f * correctBField / 100f;    

        float slightlyStrongUpper = correctBField + 3 * correctBField / 100f;
        float slightlyStrongLower = correctBField + 1.00001f * correctBField / 100f;

        float correctRangeUpper = correctBField + correctBField/100f;
        float correctRangeLower = correctBField - correctBField/100f;

        float slightlyWeakUpper = correctBField - 1.00001f * correctBField / 100f;
        float slightlyWeakLower = correctBField - 3 * correctBField / 100f;
        Debug.Log("Slightly Weak Range is between " + slightlyWeakLower + " and " + slightlyWeakUpper);

        float weakUpper = correctBField - 3.00001f * correctBField / 100f;
        float weakLower = correctBField - 5.00f * correctBField / 100f;

        float veryWeak = correctBField - 5.00001f * correctBField / 100f;


        print("The mass spectrometer must be set to a B field of " + correctBField);

        if (userBField <= correctRangeUpper && userBField >= correctRangeLower)
        {
            pathManager.isCorrect = true;
            resultsText.text = "The ions were deflected into the collector! You picked the correct B Field Value.";
        }
        else if (userBField <= slightlyStrongUpper && userBField >= slightlyStrongLower)
        {
            pathManager.isSlightlyStrong = true;
            resultsText.text = "The ions were deflected too far. Try lowering the B field.";
        }
        else if (userBField >= veryStrong)
        {
            pathManager.isVeryStrong = true;
            resultsText.text = "The ions were deflected very strongly. You should adjust the B field to a much lower value.";
        }
        else if (userBField <= veryWeak)
        {
            pathManager.isVeryWeak = true;
            resultsText.text = "The ions were barely deflected at all. You should adjust the B field to a much higher value.";
        }
        else if (userBField <= slightlyWeakUpper && userBField >= slightlyWeakLower)
        {
            pathManager.isSlightlyWeak = true;
            resultsText.text = "The ions just barely missed the detector. Try adjusting the B field to a slightly higher value.";
        } 
        else if (userBField <= weakUpper && userBField >= weakLower)
        {
            pathManager.isWeak = true;
            resultsText.text = "The ions missed the detector by a good margin. Try adjusting the B field to a higher value.";
        }
        else if (userBField <= strongUpper && userBField >= strongLower)
        {
            pathManager.isStrong = true;
            resultsText.text = "The ions were deflected too strongly. Try adjusting the B field to a lower value.";
        }
        else
        {
            resultsText.text = "The ions were not deflected correctly. Change your B Value";
        }

    }

}
