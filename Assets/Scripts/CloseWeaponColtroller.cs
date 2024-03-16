using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CloseWeaponColtroller : MonoBehaviour
{

    // ���� ������ Hand�� Ÿ�� ����.
    [SerializeField]
    protected CloseWeapon currentCloseWepon;

    // ���� ��??
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
                    // �ڷ�ƾ ����.
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

        // ���� Ȱ��ȭ ����.
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
    // �ϼ� �Լ�������, �߰� ������ �Լ�.
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
