using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoudnessIndicator : LineReadout
{
    public SpriteRenderer sprite;
    void Update()
    {
        SetValue(MicInput.MicLoudness);
        UpdateLine();
        Color c = sprite.color;

       
        if(GameManager.i.listeningForPlayer){
            c.a = Mathf.Clamp(Mathf.Pow(MicInput.averageLoudness, 0.5f) * 10f, 0.1f, 1f);
            sprite.color = c;
        }else{
            c.a = Mathf.Lerp(c.a, 0, Time.deltaTime * 10f);
        }
        
        sprite.color = c;
    }
}
