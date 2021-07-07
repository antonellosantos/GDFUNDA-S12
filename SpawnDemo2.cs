using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDemo2 : MonoBehaviour
{
    [SerializeField] private CylinderGemino cylinderCopy;
    [SerializeField] private List<CylinderGemino> geminoList;

    private float ticks = 0.0f;
    private float SPAWN_INTERVAL = 1.0f;

    private float colorTicks = 0.0f;
    private float COLOR_INTERVAL = 1.0f;

    private float destroyTicks = 0.0f;
    private float DESTROY_INTERVAL = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.cylinderCopy.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.ticks += Time.deltaTime;
        if(this.ticks > this.SPAWN_INTERVAL)
        {
            this.ticks = 0.0f;
            this.SpawnBatch();
        }

        this.colorTicks += Time.deltaTime;
        if (this.colorTicks > this.COLOR_INTERVAL)
        {
            this.colorTicks = 0.0f;
            this.ChangeColorBatch();
        }

        this.destroyTicks += Time.deltaTime;
        if (this.destroyTicks > this.DESTROY_INTERVAL)
        {
            this.destroyTicks = 0.0f;
            this.DestroyBatch();
        }
    }

    private void SpawnBatch()
    {
        CylinderGemino myObj = GameObject.Instantiate<CylinderGemino>(this.cylinderCopy, this.transform);
        myObj.gameObject.SetActive(true);
        myObj.RandomizeGeminiColor();

        this.geminoList.Add(myObj);
    }

    private void ChangeColorBatch()
    {
        for (int i = 0; i < this.geminoList.Count; i++)
        {
            this.geminoList[i].RandomizeGeminiColor();
        }
    }

    private void DestroyBatch()
    {
        for(int i = 0; i < this.geminoList.Count; i++)
        {
            GameObject.Destroy(this.geminoList[i].gameObject);
        }

        this.geminoList.Clear();
    }
}
