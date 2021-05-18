using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Indicator : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public Camera camera;
    void Update()
    {
        PlaceIndicator();
    }

    public void PlaceIndicator(){
        List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();
        Vector2 middle = camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        raycastManager.Raycast(middle, raycastHits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if(raycastHits.Count > 0){
            transform.position = raycastHits[0].pose.position;
            transform.rotation = raycastHits[0].pose.rotation;
        }
    }
}
