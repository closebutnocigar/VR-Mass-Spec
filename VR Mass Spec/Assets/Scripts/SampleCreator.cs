using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SampleCreator : MonoBehaviour
{
    public GameObject samplePrefab;
    public Transform sampleStartLocation;
    public GameObject sampleUI;
    
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
        print(sampleZ.ToString() + " " + sampleName + " " + sampleMass);
        sampleUI.GetComponentInChildren<TextMeshProUGUI>().text = "Isotope Selected: " + sampleName + ". \n It has an atomic mass of " + sampleMass + "u \n and an atomic number of " + sampleZ + ".";
    }
}
