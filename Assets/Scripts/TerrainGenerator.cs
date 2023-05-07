using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int minDistanceFromPlayer;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;
    [SerializeField] private Text scoreText;
    private List<GameObject> currentTerrains = new List<GameObject>();
    private Vector3 currentPosition = new Vector3(0,0,-4);
    private float score;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true, new Vector3(0,0,0));
        }
        maxTerrainCount = currentTerrains.Count;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.W))
    //    {
    //        SpawnTerrain(false, new Vector3(0,0,0));
    //    }
    //}

    public void SpawnTerrain(bool isStart, Vector3 playerPos)
    {
        if(currentPosition.z - playerPos.z < minDistanceFromPlayer)
        {
            int whichTerrain = Random.Range(0, terrainDatas.Count);
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);
            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].possibleTerrain[Random.Range(0, terrainDatas[whichTerrain].possibleTerrain.Count)],
                                                 currentPosition,
                                                 Quaternion.identity,
                                                 terrainHolder);
                //terrain.transform.SetParent(terrainHolder);
                currentTerrains.Add(terrain);
                if(!isStart)
                {
                    if(currentTerrains.Count > maxTerrainCount)
                    {
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }
                else
                {

                }
                currentPosition.z++;
                //Mathf.Round(score);
                //scoreText.text = "" + score;
                
            }
        }
    }

    private void FixedUpdate() {
            score += 0.005f;
        }
}
