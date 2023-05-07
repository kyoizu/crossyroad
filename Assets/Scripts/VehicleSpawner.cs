using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> vehicle = new List<GameObject>();
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSeparationTime;
    [SerializeField] private float maxSeparationTime;
    [SerializeField] private bool isRightSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnVehicle());
    }

    // Update is called once per frame
    private IEnumerator SpawnVehicle()
    {
        int whichVehicle = Random.Range(0, vehicle.Count);
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minSeparationTime, maxSeparationTime));
            GameObject go = Instantiate(vehicle[whichVehicle], spawnPos.position, Quaternion.identity);
            if(!isRightSide)
            {
                go.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}
