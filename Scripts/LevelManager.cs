using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public GameObject[] levelPrefabs;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    public float levelLength = 12.0f;
    private float safeZone = 15.0f;
    public int amnLevelsOnScreen = 7;
    private int lastPrefabIndex = 0;
    public Slider levelslider;

    private List<GameObject> ActiveLevels;

    // Start is called before the first frame update
    void Start()
    {
        ActiveLevels = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < amnLevelsOnScreen; i++)
        {
            if ( i < 2 )
                SpawnLevel(0);
            else
                SpawnLevel ();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amnLevelsOnScreen * levelLength))
        {
            SpawnLevel();
            DeleteLevel();
        }
    }

    private void SpawnLevel(int prefabIndex = -1)
    {
        GameObject go;
        if(prefabIndex == -1)
            go = Instantiate(levelPrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(levelPrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent (transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += levelLength;
        ActiveLevels.Add (go);
    }
    
    private void DeleteLevel()
    {
        Destroy(ActiveLevels[0]);
        ActiveLevels.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (levelPrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, levelPrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
    //DEBUG MENU SCRIPT_____________________________________________________
    public void CloserObsticles(float newSpeed)
    {
        levelLength = (float)levelslider.value;
    }

    public void EasyGame()
    {
        levelLength = 18;
    }

    public void MediumGame()
    {
        levelLength = 15;
    }

    public void HardGame()
    {
        levelLength = 10;
    }
}
