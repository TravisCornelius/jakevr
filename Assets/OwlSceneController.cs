using UnityEngine;
using System.Collections;

public class OwlSceneController : MonoBehaviour
{

    private GameObject enemy1;
    private float enemySpawnRate = 5;


    protected void Start()
    {
        enemy1 = transform.Find("Enemy1").gameObject;
        enemy1.SetActive(false);
        StartCoroutine(SpawnEnemy1());
    }

    IEnumerator SpawnEnemy1()
    {

        yield return new WaitForSeconds(enemySpawnRate);
        createEnemy1();
        StartCoroutine(SpawnEnemy1());
    }

    void Update()
    {

    }

    private void createEnemy1()
    {
        GameObject enemy1Clone = Instantiate(enemy1, new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100)), enemy1.transform.rotation) as GameObject;
        enemy1Clone.SetActive(true);
        enemy1Clone.gameObject.tag = "Enemy1";
    }
}
