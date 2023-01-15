using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 6f;
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private int damageToGive = 4;

    private Player _player;

    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);


    }


private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            Player player = other.transform.GetComponent<Player>(); 
            if(player != null)
            {  
                player.Damage(damageToGive);
            };
        }

        if (other.tag == "Laser"){
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            if (_player !=null)
            {
            _player.scoreadd();
            }
            speed = 0;
            spawnManager.startSpawning();
            Destroy(this.gameObject, 1f);
        }

    }

}
