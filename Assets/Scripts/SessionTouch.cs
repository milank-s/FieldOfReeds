using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionTouch : SessionScript
{

    public AudioClip currentBuild;
    public AudioClip thankYou;
    
   public override void StartSession(){
       StartCoroutine(SessionSequence());
   }

    public override IEnumerator SessionSequence()
    {
        yield return new WaitForSeconds(2f);
        
        yield return StartCoroutine(PlayNarration(currentBuild));

        
        
        yield return StartCoroutine(PlayNarration(thankYou));
        
    }



   
}
