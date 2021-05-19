using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineReadout : MonoBehaviour
{
    public LineRenderer line;
    
    public float magnitude = 0.1f;
    public float frequency = 0.2f;
    public float speed = 10f;

    [HideInInspector]
    public float amplitude;
    public float width;
    public int segments = 25;

    public void Start(){
        line.positionCount = segments;
    }
    public void SetValue(float value){
        amplitude = value;
    }
    public void UpdateLine()
    {   
        float adjustedAmplitude = amplitude * magnitude;

        if(adjustedAmplitude > 1){
           adjustedAmplitude /= adjustedAmplitude;
        }

        for(int i = 0; i < segments; i++){
            float normalized = (float)i/(float)segments;
            normalized = (normalized - 0.5f) * 2f;
            float height = Mathf.PerlinNoise((float)frequency * i + Time.time * speed, 0);
            height = ((height*2) -1) * adjustedAmplitude;
            Vector3 position = new Vector3(width * normalized, height, 0);
            line.SetPosition(i, position);
        }
    }
}
