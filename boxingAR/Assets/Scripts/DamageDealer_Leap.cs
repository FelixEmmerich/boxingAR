using UnityEngine;
using System.Collections;
using Leap;

public class DamageDealer_Leap : DamageDealer
{
    public Vector3 CurrPos=Vector3.zero;
    public Vector3 PrevPos=Vector3.zero;
    public float DamageScale = 20;
    public float BlockAccuracy = 10;
    private bool _previouslyBlocking;
    public Collider MyCollider;

    void Update()
    {
        PrevPos = CurrPos;
        CurrPos = transform.position;
        if (_previouslyBlocking != Mathf.Abs(transform.eulerAngles.x - 270) < BlockAccuracy)
        {
            MyCollider.isTrigger = _previouslyBlocking;
            _previouslyBlocking = !_previouslyBlocking;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();
        if (monster != null)
        {
            Damage(monster,  (CurrPos-PrevPos).magnitude* DamageScale);
        }
    }

}