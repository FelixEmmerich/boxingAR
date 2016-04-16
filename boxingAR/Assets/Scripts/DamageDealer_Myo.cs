using UnityEngine;
using System.Collections;
using Thalmic.Myo;

public class DamageDealer_Myo : DamageDealer
{
    public ThalmicMyo Myo;
    public float DamageScale=1;

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("abc");
        Monster monster = collision.gameObject.GetComponent<Monster>();
        if (monster != null)
        {
            Debug.Log(Myo.accelerometer.magnitude);
            Damage(monster, Myo.accelerometer.magnitude*DamageScale);
        }
    }

}
