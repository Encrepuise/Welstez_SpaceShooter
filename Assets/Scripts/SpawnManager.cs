using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyContainer;
    [SerializeField]
    private GameObject powerUpPrefab;
    [SerializeField]
    private GameObject powerUpSpeedPrefab;
    [SerializeField]
    private GameObject shieldPrefab;
    private bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSpawning()
    {

        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
        StartCoroutine(SpawnPowerUpSpeedRoutine());
        StartCoroutine(ShieldRoutine());

    }

    IEnumerator SpawnEnemyRoutine(){
    
    yield return new WaitForSeconds(2.0f);

    while (stopSpawning == false){
    
    Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
    GameObject newEnemy = Instantiate(enemyPrefab, posToSpawn, Quaternion.identity);
    newEnemy.transform.parent = enemyContainer.transform;
    yield return new WaitForSeconds(5.0f);
    
    }
    }

    IEnumerator SpawnPowerUpRoutine(){
    yield return new WaitForSeconds(2.0f);

    while (stopSpawning == false){
    
    Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
    GameObject powerUp = Instantiate(powerUpPrefab, posToSpawn, Quaternion.identity);
    yield return new WaitForSeconds(Random.Range(3f, 7f));
    
    }
    }

    IEnumerator SpawnPowerUpSpeedRoutine(){
    yield return new WaitForSeconds(2.0f);

    while (stopSpawning == false){
    
    Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
    GameObject powerUp = Instantiate(powerUpSpeedPrefab, posToSpawn, Quaternion.identity);
    yield return new WaitForSeconds(Random.Range(3f, 7f));
    
    }
    }



    IEnumerator ShieldRoutine(){
    yield return new WaitForSeconds(2.0f);

    while (stopSpawning == false){
    
    Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
    GameObject powerUp = Instantiate(shieldPrefab, posToSpawn, Quaternion.identity);
    yield return new WaitForSeconds(Random.Range(3f, 7f));
    
    }
    }



    public void OnPlayerDeath(){
        stopSpawning = true;
    }


}
