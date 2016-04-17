using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class Monster : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Material RegularMaterial;
    public Material DamageMaterial;
    public float DamagedTime = 1.5f;
    private float _currentDamagedTime=-1;
    public GameObject Target;
    public GameObject ProjectilePrefab;
    public float [] ProjectileDelay;
    public int _delayIndex;
    private float _currentTime=0;
    public bool Active;
    public float TotalHealth=10;
    private float _health;
    private Texture2D texture;
    public GameMaster Master;
    public float TriggerDistance = 10;
    public GameObject SpawnLocation;

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
        GameObject go = (GameObject)Instantiate(ProjectilePrefab,SpawnLocation.transform.position,transform.rotation);
        Projectile pr = go.GetComponent<Projectile>();
        if (pr != null)
        {
            pr.Initialize((Camera.main.transform.position-transform.position).normalized, Master);
        }
    }

    // Update is called once per frame
	void Update ()
	{
	    if (Active)
	    {
	        _currentTime += Time.deltaTime;
	        if (_currentDamagedTime >= 0 && _currentDamagedTime < DamagedTime)
	        {
	            _currentDamagedTime += Time.deltaTime;
	        }
	        else if (_currentDamagedTime > DamagedTime)
	        {
	            _currentDamagedTime = -1;
	            Renderer.material = RegularMaterial;
	        }
	        if (_currentTime > ProjectileDelay[_delayIndex])
	        {
	            _delayIndex = (_delayIndex + 1)%ProjectileDelay.Length;
	            _currentTime = 0;
	            LaunchProjectile();
	        }
	    }
	    else
	    {
	        if ((transform.position - Target.transform.position).magnitude <= TriggerDistance)
	        {
                Debug.Log("asdb");
	            Active = true;
	        }
	    }
	}

    public void Damage(float amount)
    {
        Renderer.material = DamageMaterial;
        _currentDamagedTime = 0;
        _health -= amount;
        if (amount <= 0)
        {
            Master.RemoveMonster(this);
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