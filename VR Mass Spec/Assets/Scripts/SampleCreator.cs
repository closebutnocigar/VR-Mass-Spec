using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SampleCreator : MonoBehaviour
{
    public GameObject samplePrefab;
    public Transform sampleStartLocation;
    public GameObject sampleUI;
    public GameObject samplePedestalUI;
    
    [Header("Element Attributes")]
    [SerializeField]
    public string sampleName;
    public float sampleMass;
    public int sampleZ;

    public void SetSampleValues(string name, float mass, int Z)
    {
        sampleName = name;
        sampleMass = mass;
        sampleZ = Z;

    }
    public void CreateSample()
    {

        var sample = Instantiate(samplePrefab, sampleStartLocation);
        sample.name = sampleName + " Sample";
        var sampleObject = sample.GetComponent<Sample>();
        sampleObject.sampleZ = sampleZ;
        sampleObject.sampleMass = sampleMass;
        print(sampleZ.ToString() + " " + sampleName + " " + sampleMass);
        samplePedestalUI.SetActive(true);
        samplePedestalUI.GetComponentInChildren<TextMeshProUGUI>().text = "You have created a sample of " + sampleName;


    }

    public void SetSampleFactsUI()
    {
        sampleUI.GetComponentInChildren<TextMeshProUGUI>().text = "Isotope Selected: " + sampleName + ". \n It has an atomic mass of " + sampleMass + "u \n and an atomic number of " + sampleZ + ".";
    }

    public void ResetSampleFactsUI()
    {
        sampleUI.GetComponentInChildren<TextMeshProUGUI>().text = "Facts about the isotope will display here when you bring the sample to the machine.";
    }

    public void DestroyExistingSamples()
    {
        var existingSample = GameObject.FindObjectOfType<Sample>();
        if (existingSample != null)
        {
            Destroy(existingSample.gameObject);

        }
    }
}
