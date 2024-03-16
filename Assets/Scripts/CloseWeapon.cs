using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeapon: MonoBehaviour
{
    public string closeWeaponName; // 근접무기 이름.

    // 웨폰 유형.
    public bool isHand;
    public bool isAxe;
    public bool isPickaxe;

    public float range;
    public int damage;
    public float workSpeed;
    public float attackDelay;
    public float attackDelayA;
    public float attackDelayB;

    public Animator anim; // 애니메이션.
}
