using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoudnessIndicator : MonoBehaviour
{
    public SpriteRenderer sprite;
    void Update()
    {
        if(GameManager.i.listeningForPlayer){
            Color c = sprite.color;
            c.a = Mathf.Clamp(Mathf.Pow(MicInput.MicLoudness, 0.5f), 0.1f, 1f);
            sprite.color = c;
        }else{
            Color c = sprite.color;
            c.a = Mathf.Lerp(c.a, 0, Time.deltaTime * 3f);
        }
    }
}
