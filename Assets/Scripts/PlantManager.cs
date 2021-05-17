using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARKit;
public class PlantManager : MonoBehaviour
{
    public class PlantRegion{
        public ARPlane plane;
        public List<Plant> plants;
        public Vector2 extents;
        public PlantRegion(ARPlane p){
            plane = p;
            extents = p.extents;
        }
    }
    public GameObject[] plantPrefabs;
    public ARPlaneManager planeManager;
    
    public List<Plant> plants;
    public Dictionary<ARPlane, PlantRegion> plantRegions;
    public void OnPlaneChange(ARPlanesChangedEventArgs context){
        foreach(ARPlane p in context.added){
            InitializePlantRegion(p);
        }

        foreach(ARPlane p in context.updated){
            TryPopulatePlane(plantRegions[p]);
        }
    }

    // public ARPlane GetPlane(ARPlane plane){
    //     foreach(PlantRegion r in plantRegions){
    //         if(r.plane == plane){
    //             return r.plane;
    //         }
    //     }
    //     return null;
    // }

    public void TryPopulatePlane(PlantRegion r){
        ARPlane p = r.plane;
        //new plane is big enough to spawn another plant
        if(r.plants.Count < 4 && r.plane.extents.magnitude > r.extents.magnitude + 0.2f){
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

            SpawnPlant(r, p.center + spawnOffset);
        }
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
        Vector3 spawnPos = plane.center;
        Vector3 localSpawnPos = plane.centerInPlaneSpace;
        Quaternion spawnRot = Quaternion.LookRotation(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)), plane.normal);
         
        GameObject newPlant = Instantiate(plantToSpawn, spawnPos, spawnRot);
        Plant plantScript = newPlant.GetComponent<Plant>();
        region.plants.Add(plantScript);    
    }
    void Update()
    {
        
    }
}
