using UnityEngine;
using System.Collections;

public class DamageDealer : MonoBehaviour
{
    public void Damage(Monster monster, float amount)
    {
        monster.Damage(amount);
    }
}
