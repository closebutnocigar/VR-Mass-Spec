using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using TMPro;

public class IonPathManager : MonoBehaviour
{
    public GameObject[] pathParticles;

    public Sample currentSample;
    public TextMeshProUGUI resultsText;

    public bool sampleIsSocketed;

    public bool isVeryStrong;
    public bool isStrong;
    public bool isSlightlyStrong;

    public bool isCorrect;

    public bool isSlightlyWeak;
    public bool isWeak;
    public bool isVeryWeak;

    private void Awake()
    {
        ResetPaths();
    }
    private void Update()
    {
        currentSample = GameObject.FindObjectOfType<Sample>();
    }
    public void StartIonBeamPaths()
    {
        ResetBools();

        ResetPaths();
        StartPathsBeforeMagneticSector();

        if (currentSample != null)
        {
            currentSample.DecidePath();
        }
        else
        {
            resultsText.text = "There is no sample selected. Go to the table on the right and select an isotope.";
            return;
        }


        if (isCorrect)
            {
                pathParticles[3].SetActive(true);
            }
            else if(isVeryWeak)
            {
                pathParticles[4].SetActive(true);
            }
            else if(isVeryStrong)
            {
                pathParticles[5].SetActive(true);
            }
            else if(isSlightlyWeak)
            {
                pathParticles[6].SetActive(true);
            }
            else if(isSlightlyStrong)
            {
                pathParticles[7].SetActive(true);
            }
            else if(isWeak)
            {
                pathParticles[8].SetActive(true);
            }
            else if(isStrong)
            {
                pathParticles[9].SetActive(true);
            }

    }

    public void ResetPaths()
    {
      for (int i = 0; i < pathParticles.Length; i++)
        {
            pathParticles[i].SetActive(false);
        }
    }

    public void ResetBools()
    {
    isVeryStrong = false;
    isStrong = false;
    isSlightlyStrong = false;

    isCorrect = false;

    isSlightlyWeak = false;
    isWeak = false;
    isVeryWeak = false;
}

    public void StartPathsBeforeMagneticSector()
    {
        pathParticles[0].SetActive(true);
        pathParticles[1].SetActive(true);
        pathParticles[2].SetActive(true);
    }
}
