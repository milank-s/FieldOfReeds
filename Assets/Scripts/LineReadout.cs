using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineReadout : MonoBehaviour
{
    public LineRenderer line;
    
    public float magnitude = 0.1f;
    public float frequency = 0.2f;
    public float speed = 1f;
    public float amplitude;
    public float width;
    int segments = 10;

    public void Start(){
        line.positionCount = segments;
    }

    public void SetValue(float value){
        amplitude = value;
    }
    public void UpdateLine()
    {   
        for(int i = 0; i < segments; i++){
            float normalized = (float)i/(float)segments;
            normalized = (normalized - 0.5f) * 2f;
            float height = Mathf.PerlinNoise((float)frequency * i + Time.time * speed, 0) * 2;
            height = (height - 0.5f) * magnitude * amplitude;
            Vector3 position = new Vector3(width * normalized, height, 0);
            line.SetPosition(i, position);
        }

        amplitude = Mathf.Lerp(amplitude, 0, Time.deltaTime);
    }
}
