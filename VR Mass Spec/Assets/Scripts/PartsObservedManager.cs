using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsObservedManager : MonoBehaviour
{
    public GameObject[] neptuneParts;
    public bool enoughPartsInspected = false;

    public GameObject consoleCanvasLoading;
    public GameObject consoleCanvasLoaded;
    
    public void CheckIfAllPartsHaveBeenSeen()
    {
        int totalSeen = 0;
        for (int i = 0; i < neptuneParts.Length; i++)
        {
            if (neptuneParts[i].GetComponent<HasBeenSeenOrNot>().hasBeenSeen)
                totalSeen++;
        }

        if (totalSeen > 10)
        {
            Debug.Log("Enough parts have been inspected.");
            SwapConsoleCanvas();
            Destroy(this);
        }
    }

    public void SwapConsoleCanvas()
    {
        Debug.Log("Swapping Console Canvases");
        consoleCanvasLoading.SetActive(false);
        consoleCanvasLoaded.SetActive(true);
    }



}
