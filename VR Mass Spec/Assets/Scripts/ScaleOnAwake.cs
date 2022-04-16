using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAwake : MonoBehaviour
{
    public float scalingFactor;
    public float endScale;
    void Start()
    {
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        
    }

    void Update()
    {
        ScaleToFloat(scalingFactor, endScale);
    }
    
    public void ScaleToFloat(float scalingFactor, float endScale)
    {
        transform.localScale += Vector3.one * scalingFactor;
        if (transform.localScale.x >= endScale)
        {
            Destroy(this);
        }
    }
  
}
