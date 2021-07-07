using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject bigCube;
    [SerializeField] private GameObject spawnCopy;
    [SerializeField] private List<GameObject> spawns;

    // Start is called before the first frame update
    void Start()
    {
        this.spawnCopy.SetActive(false);
        this.StartCoroutine(this.DestroyAfter(2.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DestroyAfter(float secs)
    {
        yield return new WaitForSeconds(secs);

        //hide parent object
        this.bigCube.SetActive(false);

        //spawn multiple objects of smaller size
        int count = 500;
        for(int i = 0; i < count; i++)
        {
            Vector3 localPos = this.bigCube.transform.localPosition;
            //spread for cooler effect
            localPos.x += Random.Range(-1.0f, 1.0f);
            localPos.y += Random.Range(-1.0f, 1.0f);
            localPos.z += Random.Range(-1.0f, 1.0f);

            GameObject myObj = ObjectUtils.SpawnDefault(this.spawnCopy, this.transform.parent, localPos);
            myObj.SetActive(true);
            this.spawns.Add(myObj);
        }

        yield return new WaitForSeconds(5.0f);

        //reset
        for(int i = 0; i < this.spawns.Count; i++)
        {
            GameObject.Destroy(this.spawns[i]);
        }
        this.spawns.Clear();
        this.bigCube.SetActive(true); //show again

        this.StartCoroutine(this.DestroyAfter(secs)); //repeat
    }
}
