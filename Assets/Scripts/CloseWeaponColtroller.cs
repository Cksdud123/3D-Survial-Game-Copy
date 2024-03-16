using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CloseWeaponColtroller : MonoBehaviour
{

    // 현재 장착된 Hand형 타입 무기.
    [SerializeField]
    protected CloseWeapon currentCloseWepon;

    // 공격 중??
    protected bool isAttack = false;
    protected bool isSwing = false;

    protected RaycastHit hitInfo;

    [SerializeField] protected LayerMask layerMask;

    protected void TryAttack()
    {
        if (!Inventory.inventoryActivated)
        {
            if (Input.GetButton("Fire1"))
            {
                if (!isAttack)
                {
                    isSwing = false;
                    // 코루틴 실행.
                    StartCoroutine(AttackCoroutine());
                }
            }
        }
    }

    protected IEnumerator AttackCoroutine()
    {
        isAttack = true;
        currentCloseWepon.anim.SetTrigger("Attack");

        yield return new WaitForSeconds(currentCloseWepon.attackDelayA);
        isSwing = true;

        // 공격 활성화 시점.
        StartCoroutine(HitCoroutine());

        yield return new WaitForSeconds(currentCloseWepon.attackDelayB);
        isSwing = false;

        yield return new WaitForSeconds(currentCloseWepon.attackDelay - currentCloseWepon.attackDelayA - currentCloseWepon.attackDelayB);
        isAttack = false;
    }

    protected abstract IEnumerator HitCoroutine();

    protected bool CheckObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, currentCloseWepon.range, layerMask))
        {
            return true;
        }
        return false;
    }
    // 완성 함수이지만, 추가 편집한 함수.
    public virtual void CloseWeaponChange(CloseWeapon _cloaeWeapon)
    {
        if (WeaponManager.currentWeapon != null)
            WeaponManager.currentWeapon.gameObject.SetActive(false);

        currentCloseWepon = _cloaeWeapon;
        WeaponManager.currentWeapon = currentCloseWepon.GetComponent<Transform>();
        WeaponManager.currentWeaponAnim = currentCloseWepon.anim;

        currentCloseWepon.transform.localPosition = Vector3.zero;
        currentCloseWepon.gameObject.SetActive(true);
    }
}
