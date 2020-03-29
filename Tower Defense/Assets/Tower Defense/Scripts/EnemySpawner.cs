using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float spawnCD = 0.25f;
    float spawnCDremaining = 5;

    [System.Serializable]
    public class WaveComponent
    {
        public GameObject enemyPrefab;
        public int num;
        [System.NonSerialized]
        public int spawned = 0;
    }

    public WaveComponent[] waveComps;

    void Update()
    {
       spawnCDremaining -= Time.deltaTime;
        if(spawnCDremaining < 0)
        {
            spawnCDremaining = spawnCD;
            bool didSpawn = false;

            foreach (WaveComponent wc in waveComps)
            {
                if(wc.spawned < wc.num)
                {
                    wc.spawned++;
                    Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);

                    didSpawn = true;
                    break;
                }
            }
            if(didSpawn == false)
            {
                if(transform.parent.childCount > 1)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                }
                else
                {

                }
                
                Destroy(gameObject);
            }
        }
    }
}
