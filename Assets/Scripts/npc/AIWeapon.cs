using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AIWeapon : MonoBehaviour
{
    public Item current_gun;
    public GameObject equipted_gun;
    public GameObject character_socket;
    public GameObject weapon_drop;

    public GameObject w_button;
    public GameObject w_image;

    Animator animator;
    public AIHeadBone head_tracking;

    public ParticleSystem hit_effect;
    public MeshSockets sockets;
    public AIWeaponIK ai_weapon_ik;

    float fire_rate;
    float next_round = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sockets = GetComponent<MeshSockets>();
        ai_weapon_ik = GetComponent<AIWeaponIK>();
    }


    public void EquiptWeapon(GameObject weapon)
    {
        equipted_gun = weapon;
        sockets.Attach(equipted_gun.transform, MeshSockets.SocketID.Spine);
        GetComponent<AIAgent>().ai_weapon_ik.aim_transform = equipted_gun.transform;
    }

    public void ActivateWeapon()
    {
        //animator.SetBool("equip", true);
        StartCoroutine(EquipWeaponIK());
    }

    
    IEnumerator EquipWeaponIK()
    {
        animator.SetBool("equip", true);
        yield return new WaitForSeconds(.5f);

        while(animator.GetCurrentAnimatorStateInfo(1).normalizedTime < 1f)
        {
            yield return null;
        }

        ai_weapon_ik.SetAimTransform(equipted_gun.GetComponent<FireWeapon>().raycast_origin);
    }

    public void DropWeapon()
    {
        Destroy(equipted_gun.gameObject);
    }

    public bool HasWeapon()
    {
        return equipted_gun != null;
    }

    public void OnAnimationEvent(string event_name)
    {
        if (event_name == "equip_weapon")
        {
            sockets.Attach(equipted_gun.transform, MeshSockets.SocketID.RightHand);
        }
            
    }
}
