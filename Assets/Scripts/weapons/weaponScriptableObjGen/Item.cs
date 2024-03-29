using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    // scriptable objsct script to contain data for multiple other weapons that share the same variables

    //  name of gun
    public string item_name;

    public int item_amount = 0;

    [TextArea]
    public string description;

    //  reference to gun prefab
    public GameObject item_prefab;

    public WeaponSpecs weapon_specs;

    public BulletsSpecs bullets_specs;

    public GameObject gun_pickup;   

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

    public bool is_key = false;
    public int keycode = 0000;
}
