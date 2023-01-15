using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private int damageToGive = 1;

    private Player _player;

    private Animator anim;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 5.0f, 0);
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down * speed * Time.deltaTime);
         
        if (transform.position.y <= -5.20f)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 5.0f, 0);
        }

    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            Player player = other.transform.GetComponent<Player>(); 
            if(player != null)
            {  
                player.Damage(damageToGive);
            }
            anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            Destroy(this.gameObject, 2.3f);
            audioSource.Play();
        }

        if (other.tag == "Laser"){
            Destroy(other.gameObject);
            if (_player !=null)
            {
            _player.scoreadd();
            }
            anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            Destroy(this.gameObject, 2.3f);
            audioSource.Play();
        }

    }

}
