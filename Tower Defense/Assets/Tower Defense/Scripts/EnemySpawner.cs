using System.Collections;
using UnityEngine;

[System.Serializable]
public class WaveComponent
{
    public GameObject enemyPrefab;
    public int num;

    [System.NonSerialized]
    public int spawned = 0;
}

public class EnemySpawner : MonoBehaviour
{
    float spawnCD = 0.25f;
    float spawnCDremaining = 5;

    [Tooltip("Esto permite que cada cierto tiempo se vuelva a spawner los enemigos, dejando el contador en 0")]
    [Range(0,10)]
    [SerializeField] internal float timeRespawn;

    [SerializeField] internal WaveComponent[] waveComps;

    void Update()
    {
        spawnCDremaining -= Time.deltaTime;

        if (spawnCDremaining < 0)
        {
            spawnCDremaining = spawnCD;
            StartCoroutine(SpawnEnemy());
        }
    }

    public IEnumerator  SpawnEnemy()
    {
        foreach (WaveComponent wc in waveComps)
        {
            if (wc.spawned < wc.num)
            {
                wc.spawned++;
                Instantiate(wc.enemyPrefab, transform.position, transform.rotation);
                break;  
            }

            else if(wc.spawned == wc.num)
            {
                yield return new WaitForSeconds(timeRespawn);
                wc.spawned = 0;
            }
            yield return new WaitForSeconds(timeRespawn);
            
        }
        
    }
}
