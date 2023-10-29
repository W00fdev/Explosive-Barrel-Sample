using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour
{
    public GameObject ExplosionParticles;
    public string DestroyableTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(DestroyableTag))
        {
            // Explode
            Destroy(collision.gameObject);
        }

        Instantiate(ExplosionParticles, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }
}
