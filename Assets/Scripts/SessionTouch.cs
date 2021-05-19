using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionTouch : SessionScript
{

    public AudioClip currentBuild;
    public AudioClip thankYou;
    
    bool touched = false;
   public override void StartSession(){
       PlantManager.i.PlantTouched += PlantTouched;
       PlantManager.i.SetPlantInput(Plant.DesiredInput.touch);
       StartCoroutine(SessionSequence());
   }

    public override void EndSession()
    {
        base.EndSession();
        PlantManager.i.PlantTouched -= PlantTouched;
    }

    public override IEnumerator SessionSequence()
    {
        yield return new WaitForSeconds(2f);
        
        yield return StartCoroutine(PlayNarration(currentBuild));

        while(!touched){
            yield return null;
        }
        
        yield return new WaitForSeconds(2f);
        
        yield return StartCoroutine(PlayNarration(thankYou));
        
    }

    public void PlantTouched(){
        touched = true;
    }


   
}
