using UnityEngine;
using System.Collections;
using UnityEditor;

public class Projectile : MonoBehaviour
{
    public float LifeSpan=2;
    public float Speed=1;

	// Use this for initialization
	void Start ()
    {
	}

    //Todo: Add reference to main object to increase timer on collision
    public void Initialize(Vector3 direction)
    {
        Rigidbody rigid = GetComponent<Rigidbody>();
        if (rigid!=null)
        {
            rigid.velocity =Speed*direction;
        }
    }
	
	// Update is called once per frame
	void Update ()
	{
	    LifeSpan -= Time.deltaTime;
	    if (LifeSpan <= 0)
	    {
	        Destroy(gameObject);
	    }
	}

    void OnTriggerEnter(Collider collision)
    {
        //Todo: Increase time
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ouch");
            Destroy(gameObject);
        }
    }


}