using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoudnessIndicator : LineReadout
{
    public SpriteRenderer sprite;
    void Update()
    {
        UpdateLine();
        Color c = sprite.color;

        if(GameManager.i.listeningForPlayer){
            c.a = Mathf.Clamp(Mathf.Pow(MicInput.MicLoudness, 0.5f), 0.1f, 1f);
            sprite.color = c;
        }else{
            c.a = Mathf.Lerp(c.a, 0, Time.deltaTime * 3f);
        }
        
        sprite.color = c;
    }
}
