using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.VFX;

/// <summary>
/// Base script for all projectile weapon behaviours [To be placed on a prefab of a weapon that is a projectile]
/// </summary>
public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;

    protected Vector3 direction;
    public float destroyAfterSeconds;

    //Current stats
    protected float currnetDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    void Awake()
    {
        currnetDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if(dirx< 0 && diry == 0) //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if(dirx > 0 && diry == 0) //right
        {
            //do nothing cause it starts like this
        }
        else if(dirx == 0 && diry < 0) //down
        {
            scale.y = scale.y * -1;
        }
        else if(dirx == 0 && diry > 0) //up
        {
            scale.x = scale.x * -1;
        }
        else if(dir.x > 0 && dir.y > 0) //up right
        {
            rotation.z = 0f;
        }
        else if(dir.x > 0 && dir.y < 0) //down right
        {
            rotation.z = -90f;
        }
        else if(dir.x < 0 && dir.y > 0) //up left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        
        else if(dir.x < 0 && dir.y < 0) //down left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }
        

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);

    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {

        //Refference the script from the collided collider and deal damage using TakeDamage()
        if(col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currnetDamage);
            ReducePierce();
        }
    }

    void ReducePierce()
    {
        currentPierce --;
        if(currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
