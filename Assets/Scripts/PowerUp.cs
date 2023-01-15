using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private int powerUpId;
    [SerializeField]
    private AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    
    if (transform.position.y > 8f)
    {
        Destroy(this.gameObject);
    }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player"){
            Player player = other.transform.GetComponent<Player>(); 
            AudioSource.PlayClipAtPoint(clip, transform.position);
            if(player != null)
            {  
                switch(powerUpId){
                    case 0:
                        player.tripleshot = true;
                        break;
                    case 1:
                        player.ActivateSpeedBoost();
                        break;
                    case 2:
                        player.activateShield();
                        break;
            }
            }
            Destroy(this.gameObject);
        }

    }

}
