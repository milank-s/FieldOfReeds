using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionOne : SessionScript
{

    public AudioClip firstMemoryInNature;
    public AudioClip wereYouAChild;
    public AudioClip doYouRemember;
    public AudioClip emotionDoYouFeel;
    public AudioClip weRemember;
    
   public override void StartSession(){
       StartCoroutine(SessionSequence());
   }

    public override IEnumerator SessionSequence()
    {
        yield return new WaitForSeconds(2f);
        
        yield return StartCoroutine(PlayNarration(firstMemoryInNature));

        yield return StartCoroutine(WaitForPlayer());
       
        yield return StartCoroutine(PlayNarration(wereYouAChild));

        yield return StartCoroutine(WaitForPlayer());
        
        yield return StartCoroutine(PlayNarration(doYouRemember));

        yield return StartCoroutine(WaitForPlayer());

        yield return StartCoroutine(PlayNarration(emotionDoYouFeel));
        
        yield return StartCoroutine(WaitForPlayer());

        yield return StartCoroutine(PlayNarration(weRemember));
        
        yield return StartCoroutine(WaitForPlayer());
    }



   
}
