using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public NPC npc;                    //  contains data etc health
    Ragdoll ragdoll;                            //  controlls ragdoll effects for entity
    Rigidbody[] rigidbodies;

    public float impact_force = 20f;            //  force applied to entity when hit with killing bullet

    public float health;

    

    /// <summary>
    /// if assigned true, gameObject mass included in ragdoll physics. if assigned false, ragdoll mass is ignored. default is true
    /// </summary>
    public bool death_force_mode = true;

    void Awake()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;

        health = npc.health;

        ragdoll = GetComponent<Ragdoll>();

        CreateEntityRagdoll();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Function called when bone gameObject containing script EntityHitbox hit with bullet.
    /// </summary>
    /// <param name="amount">passes damage amount</param>
    /// <param name="impact_direction">the direction of impact received from bullet prefab ray</param>
    /// <param name="hit_rb">bone gameObject with rigidbody that was hit by RaycastHit passed via hit.rigidbody</param>
    public void ReceiveDamage(float amount, Vector3 impact_direction, Rigidbody hit_rb)
    {
        health -= amount;
        if(health <= 0)
        {
            Die(impact_direction, hit_rb);
        }
    }

    public void ReceiveExplosiveDamage(float damage, Vector3 det_loc)
    {
        health -= damage;
        if(health <= 0)
        {
            ExplosiveDie();
        }
    }

    /// <summary>
    /// Function called when health value reaches or below threshold, 0
    /// </summary>
    /// <param name="impact_direction">direction of impact. must be passed via ray.direction</param>
    /// <param name="hit_rb">bone gameObject with rigidbody that was hit by RaycastHit passed via hit.rigidbody</param>
    void Die(Vector3 impact_direction, Rigidbody hit_rb)
    {
        float gib_chance_mutiplier = 0 - health;
        float rand_num = Random.RandomRange(0f, 100f);

        if(rand_num <= gib_chance_mutiplier)
        {
            Instantiate(npc.gib_model, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
        else
        {
            ragdoll.ActivateRagdoll();
            impact_direction.y = 1f;
            ragdoll.impact_body_part = hit_rb;
            ragdoll.ApplyForce(impact_direction * impact_force, death_force_mode);

            foreach (Rigidbody rb in rigidbodies)
            {
                rb.tag = "EntityDead";
            }
        }
    }

    void ExplosiveDie()
    {
        float rand = Random.RandomRange(0f, 100f);

        
        if(rand < 50)
        {
            Instantiate(npc.gib_model, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
        else
        {
            ragdoll.ActivateRagdoll();
        }
    }

    void CreateEntityRagdoll()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rigidbodies)
        {
            EntityHitbox entity_hitbox;


            //  split into if statemment to prevent adding second hitbox to enemy rigidbody if previously added for weak-points
            if (!rb.GetComponent<EntityHitbox>())
            {
                entity_hitbox = rb.gameObject.AddComponent<EntityHitbox>();
                entity_hitbox.health = this;                                                //  health values for entity_hitbox equal to health value of Health.cs
            }
            else
            {
                rb.GetComponent<EntityHitbox>().health = this;
            }
        }
            
    }
}
