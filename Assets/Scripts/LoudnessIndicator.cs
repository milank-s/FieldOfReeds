using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoudnessIndicator : MonoBehaviour
{
    public AudioLoudness loudness;
   public SpriteRenderer sprite;
    void Update()
    {
        Color c = sprite.color;
        c.a = Mathf.Pow(loudness.loudness, 0.5f);
        sprite.color = c;
    }
}
