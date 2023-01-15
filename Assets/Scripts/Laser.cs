using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    
    if (transform.position.y > 8f)
    {
        if (transform.parent != null){
            Destroy(transform.parent.gameObject);
        }
        else{
        Destroy(this.gameObject);
        }
    }

    
    
    }


}
