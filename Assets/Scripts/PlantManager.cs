using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARKit;
public class PlantManager : MonoBehaviour
{

    public delegate void EventToFire();
    public EventToFire PlantTouched;
    public static PlantManager i;
    public class PlantRegion{
        public ARPlane plane;
        public List<Plant> plants;
        public Vector2 extents;
        public PlantRegion(ARPlane p){
            plane = p;
            extents = p.extents;
            plants = new List<Plant>();
        }
    }

    public List<Plant> plants;
    public GameObject[] plantPrefabs;
    public ARPlaneManager planeManager;
    public Dictionary<ARPlane, PlantRegion> plantRegions;

    public void OnPlaneChange(ARPlanesChangedEventArgs context){
        foreach(ARPlane p in context.added){
            InitializePlantRegion(p);
        }

        foreach(ARPlane p in context.updated){
            TryPopulatePlane(plantRegions[p]);
        }
    }
    
    public void TryPopulatePlane(PlantRegion r){
        ARPlane p = r.plane;
        //new plane is big enough to spawn another plant
        if(r.plants.Count < 4 && r.plane.extents.magnitude > r.extents.magnitude + 0.5f){
            Vector3 spawnOffset = Vector3.zero;
            switch(r.plants.Count){
                case 2:
                    spawnOffset.x += r.extents.x * Random.Range(-2f, 2f);
                    spawnOffset.z += r.extents.y * Random.Range(0.5f, 2f);
                break;

                case 3: 
                    spawnOffset.x += r.extents.x * Random.Range(-2f, 2f);
                    spawnOffset.z -= r.extents.y * Random.Range(0.5f, 2f);
                break;
            }

            r.extents = r.plane.extents;
            SpawnPlant(r, p.center + spawnOffset);
        }
    }

    public void SetPlantInput(Plant.DesiredInput i){
        foreach(Plant p in plants){
            p.desiredInput = i;
        }
    }

    void Awake(){
        i = this;
        plants = new List<Plant>();
        plantRegions = new Dictionary<ARPlane, PlantRegion>();
    }
    void Start()
    {
        planeManager.planesChanged += OnPlaneChange;
    }

    public void InitializePlantRegion(ARPlane p){
        
       PlantRegion newPlantRegion = new PlantRegion(p);
       plantRegions.Add(p, newPlantRegion);
        SpawnPlant(newPlantRegion, p.center);
    }
    public void SpawnPlant(PlantRegion region, Vector3 pos){
        ARPlane plane = region.plane;
        GameObject plantToSpawn = plantPrefabs[Random.Range(0, plantPrefabs.Length)];
        Quaternion spawnRot = Quaternion.LookRotation(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)), plane.normal);
         
        GameObject newPlant = Instantiate(plantToSpawn, pos, spawnRot);
        Plant plantScript = newPlant.GetComponent<Plant>();
        region.plants.Add(plantScript);    
        plants.Add(plantScript);
    }
}
