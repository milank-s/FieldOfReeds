using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoudnessIndicator : LineReadout
{
   public SpriteRenderer sprite;
    void Update()
    {
        UpdateLine();
        Color c = sprite.color;
        c.a = Mathf.Pow(AudioLoudness.narrationLoudness, 0.5f);
        SetValue(AudioLoudness.narrationLoudness);
        sprite.color = c;
    }
}
