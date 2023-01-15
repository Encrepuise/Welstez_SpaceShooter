using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject tripleshotPrefab;
    [SerializeField]
    private float fireRate = 0.15f;
    private float canFire = -1f;
    [SerializeField]
    private bool shield;
    [SerializeField]
    private int lives = 2;
    [SerializeField]
    private int score = 1;
    private SpawnManager spawnManager;

    [SerializeField]
    private GameObject righthurt, lefthurt;
    
    [SerializeField]
    private AudioClip laserSound;
    private AudioSource audioSource;
   
    [SerializeField]
    public bool tripleshot = false;
    [SerializeField]
    public bool speedboost = false;

    private UIManager uiManager;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0 ,0);
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = laserSound;
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        Laser();
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    void Laser()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            canFire = Time.time + fireRate;
            
            if (tripleshot == true){
            Instantiate(tripleshotPrefab, transform.position, Quaternion.identity);
            }
            else{
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
            }
        audioSource.Play();
        }

        
    }

    public void scoreadd()
    {
        score += 1;
        uiManager.UpdateScore(score);
    }

    public void activateShield()
    {
        shield = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    void CalculateMovement()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
    
        // Movement Style 1
        // transform.Translate(Vector3.up * verticalInput * speed);
        // transform.Translate(Vector3.left * horizontalInput * speed);
        
        // Movement Style 2
        //transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * speed);

        // Movement Style 3
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        
        if (speedboost == true){
        transform.Translate(direction * speed * 2f * Time.deltaTime);
        }
        else{
        transform.Translate(direction * speed * Time.deltaTime);
        }

        // Border Style 1 - Y Border - X Round
        if (transform.position.y >= 3.8f)
        {
            transform.position = new Vector3(transform.position.x, 3.8f, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        if (transform.position.x > 11)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x < -11)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }

        // Border Style 2 - Y+X Border
        // transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -11.0f, 11.0f), Mathf.Clamp(transform.position.y, -3.8f, 3.8f), 0);



    }

    public void ActivateSpeedBoost(){
        StartCoroutine(SpeedPowerRoutine());
    }

    public void Damage(int damage){

        if (shield == true)
        {
        shield = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }       
        else
        {
        lives -= damage;

        uiManager.UpdateLives(lives);

        }

        if (lives == 2)
        {
            righthurt.SetActive(true);
        }
        else if (lives == 1)
        {
            lefthurt.SetActive(true);
        }

        if (lives < 1)
        {
            spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }

    }

IEnumerator TripleShotPowerDownRoutine()
{
    while (tripleshot == true){
    yield return new WaitForSeconds(2.0f);
    tripleshot = false;
    }

}

IEnumerator SpeedPowerRoutine()
{
    
    speed = speed + 20f;   
    yield return new WaitForSeconds(3);
    speed -= 20f;

}
}