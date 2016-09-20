using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public int enemyCount = 5;
    public float spawnWait = 1;
    public float startWait = 10;
    public float waveWait = 10;
    public int waves = 5;
    public Vector3 spawnPosition = new Vector3(-30, 0, -5);

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        int wave = 0;
        yield return new WaitForSeconds(startWait);
        while (wave < waves)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            wave++;
            yield return new WaitForSeconds(waveWait);
        }
    }
}