using UnityEngine;
using System.Collections;
using Thalmic.Myo;

public class DamageDealer_Myo : DamageDealer
{
    public JointOrientation Orientation;
    public ThalmicMyo Myo;
    public float DamageScale=1;
    public float BlockAccuracy=10;
    private bool _previouslyBlocking;
    public Collider MyCollider;

    void Update()
    {
        if (_previouslyBlocking != Mathf.Abs(Orientation.transform.eulerAngles.x - 270) < BlockAccuracy)
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
            Myo.Vibrate(VibrationType.Short);
            Damage(monster, Myo.accelerometer.magnitude*DamageScale);
        }
    }

}
