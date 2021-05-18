using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class PlantTouchBehaviour : MonoBehaviour
{
   
   //implement ar raycast to plants
   //give plants boxcolliders....
   //play plant animation

   void Update(){
       TryTouchPlant();
       #if UNITY_EDITOR
        TryClickPlant();
       #endif
   }
   public void TryTouchPlant(){
        for (var i = 0; i < Input.touchCount; i++) {
             if (Input.GetTouch(i).phase == TouchPhase.Began) {
                 
                 // Construct a ray from the current touch coordinates
                 Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                 RaycastHit raycastHit;
                 // Create a particle if hit
                 if (Physics.Raycast(ray, out raycastHit)){
                     if(raycastHit.rigidbody != null && raycastHit.rigidbody.tag == "Plant"){
                         Plant plantHit = raycastHit.rigidbody.GetComponent<Plant>();
                         plantHit.OnPlayerTouch();
                     }
                 }          
             }
        }
   }

   public void TryClickPlant(){
       if (Input.GetMouseButtonDown(0)) {
                 // Construct a ray from the current touch coordinates
                 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                 RaycastHit raycastHit;
                 // Create a particle if hit
                 if (Physics.Raycast(ray, out raycastHit, 100f)){
                     if(raycastHit.rigidbody != null && raycastHit.rigidbody.tag == "Plant"){
                         Plant plantHit = raycastHit.rigidbody.GetComponent<Plant>();
                         plantHit.OnPlayerTouch();
                     }
                 }          
             }
   }
}
