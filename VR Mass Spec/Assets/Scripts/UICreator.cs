using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICreator : MonoBehaviour
{
    public Elements elements;
    public GameObject elementsUICanvas;
    public GameObject buttonPrefab;
    public SampleCreator sampleCreator;


    void Awake()
    {
        CreateButtons();
    }

    public void CreateButtons()
    {
        for (int i = 0; i < elements.elementNames.Length; i++)
        {
            var elementButton = Instantiate(buttonPrefab, elementsUICanvas.transform);
            elementButton.name = elements.elementNames[i];
            var elementText = elementButton.GetComponentInChildren<TextMeshProUGUI>();
            elementText.text = elements.elementSymbols[i];

            int x = i;
            elementButton.GetComponent<Button>().onClick.AddListener(delegate { sampleCreator.DestroyExistingSamples(); });
            elementButton.GetComponent<Button>().onClick.AddListener(delegate { sampleCreator.SetSampleValues(elements.elementNames[x], elements.elementMassValues[x], elements.ZValue[x]); });
            elementButton.GetComponent<Button>().onClick.AddListener(delegate { sampleCreator.CreateSample(); });


        }
    }
}
