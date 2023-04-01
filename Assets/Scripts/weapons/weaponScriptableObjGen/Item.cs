using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    // scriptable objsct script to contain data for multiple other weapons that share the same variables

    //  name of gun
    public string name;

    public string description;

    //  reference to gun prefab
    public GameObject gun_prefab;

    public GameObject gun_npc;

    public GameObject gun_pickup;

    //  reference to bullet
    public GameObject bullet;

    // aim speed
    public float ads_speed;

    //  speed of bullet
    public float bullet_speed;

    //  fire rate of gun
    public float fire_rate;

    public float magazine_size;

    public float ammo_reserve = 999;

    public AmmoTypeScriptableObject ammo_type;

    public GameObject muzzle_flash;

    // speed of weapon rotation after firing [LOWER IS SLOWER];
    public float recoilRotationSpeed;

    // speed of weapon rotation returning to default position [LOWER IS SLOWER]
    public float recoilRotationReturn;

    // Amount of recoil experienced
    // x is upward directional force, not randomaly decided
    // y and z are randomaly decided with random.range function
    // present values will act as default
    public Vector3 recoilRotation = new Vector3(10f, 5f, 7f);

    public AudioClip gun_fire;

    //  used for ui elements, eg weapon wheel
    public Sprite ui_sprite;

    //======================================================
    //
    //  This is for melee-based weapons only
    //  Do not have fields populated if weapon is ranged
    //
    //======================================================
    public bool is_melee_weapon = false;
    public int melee_damage;
    public GameObject weapon_prefab;

    public bool is_throwable = false;



    public GameObject weapon_wheel_button;
    public int stack_location;
}