using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning1 : MonoBehaviour
{
    [SerializeField] private GameObject templateObject;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform[] spawnLocations;

    private GameObject activeObject;
    private float ticks = 0.0f;
    private float SPAWN_INTERVAL = 1.0f;
    private int spawnIndex = 0;

    private void Awake()
    {
        this.templateObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.ticks += Time.deltaTime;
        if(this.ticks > this.SPAWN_INTERVAL)
        {
            this.ticks = 0.0f;
            this.SPAWN_INTERVAL = Random.Range(0.5f, 1.5f);
            if(this.activeObject != null)
            {
                GameObject.Destroy(this.activeObject);
                this.activeObject = null;
            }

            this.activeObject = this.SpawnDefault();

            Vector3 myLocation = this.activeObject.transform.localPosition;
            Vector3 newLocation = this.spawnLocations[this.spawnIndex].localPosition;
            myLocation.x = newLocation.x;
            myLocation.z = newLocation.z;
            this.activeObject.transform.localPosition = myLocation;

            this.spawnIndex++;
            this.spawnIndex %= this.spawnLocations.Length;
        }
    }

    private GameObject SpawnDefault()
    {
        GameObject myObj = GameObject.Instantiate(this.templateObject, this.parent);
        myObj.SetActive(true);
        return myObj;
    }
}

