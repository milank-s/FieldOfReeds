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
    
    void Start(){
        StartSession();
    }
   public override void StartSession(){
       StartCoroutine(SessionSequence());
   }

    public override IEnumerator SessionSequence()
    {
        yield return new WaitForSeconds(2f);
        
        yield return StartCoroutine(PlayNarration(firstMemoryInNature));

        while(GameManager.i.voiceSource.isPlaying){
            yield return null;
        }

        //react to Loudness
       

        yield return StartCoroutine(PlayNarration(wereYouAChild));

        while(GameManager.i.voiceSource.isPlaying){
            yield return null;
        }

        yield return StartCoroutine(PlayNarration(doYouRemember));

        yield return StartCoroutine(PlayNarration(emotionDoYouFeel));

        yield return StartCoroutine(PlayNarration(weRemember));
    }



   
}
