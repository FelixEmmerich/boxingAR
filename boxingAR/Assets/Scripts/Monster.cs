using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class Monster : MonoBehaviour
{
    public GameObject Target;
    public GameObject ProjectilePrefab;
    public float ProjectileDelay=2;
    private float _currentTime=0;
    public bool Active;
    public float TotalHealth;
    private float _health;
    private Texture2D texture;

	// Use this for initialization
	void Start ()
	{
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.red);
        texture.wrapMode = TextureWrapMode.Repeat;
        texture.Apply();
	    _health = TotalHealth;
	}

    private void LaunchProjectile()
    {
        GameObject go = (GameObject)Instantiate(ProjectilePrefab,transform.position,transform.rotation);
        Projectile pr = go.GetComponent<Projectile>();
        if (pr != null)
        {
            pr.Initialize((Camera.main.transform.position-transform.position).normalized);
        }
    }

    // Update is called once per frame
	void Update ()
	{
        if (Active)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > ProjectileDelay)
            {
                _currentTime = 0;
                LaunchProjectile();
            } 
        }
	}

    public void Damage(float amount)
    {
        _health -= amount;
        if (amount <= 0)
        {
            //Todo: Notify the main class upon death
            Destroy(gameObject);
        }
    }

    void OnGUI()
    {
        if (Active)
        {
            GUI.DrawTexture(new Rect(0,0,Screen.width*(_health/TotalHealth),Screen.height/10f), texture);
        }
    }
}