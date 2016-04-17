using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float LifeSpan=2;
    public float Speed=1;
    public GameMaster Master;
    public float TimePenalty = 3;

	// Use this for initialization
	void Start ()
    {
	}

    //Todo: Add reference to main object to increase timer on collision
    public void Initialize(Vector3 direction, GameMaster master)
    {
        Master = master;
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
        if (collision.gameObject.tag == "Player")
        {
            Master.GLOBAL_Time += TimePenalty;
            Destroy(gameObject);
        }
    }


}