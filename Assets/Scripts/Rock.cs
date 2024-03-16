using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int hp;

    [SerializeField]
    private float destoryTime;

    [SerializeField]
    private SphereCollider col;

    [SerializeField]
    private GameObject go_rock;
    [SerializeField]
    private GameObject go_debris;
    [SerializeField]
    private GameObject go_effect_prefabs;

    [SerializeField]
    private int count;

    [SerializeField]
    private string strike_Sound;
    [SerializeField]
    private string destory_Sound;
    [SerializeField]
    private GameObject go_rock_item_prefab;

    public void Mining()
    {
        SoundManager.instance.PlaySE(strike_Sound);
        var clone = Instantiate(go_effect_prefabs, col.bounds.center, Quaternion.identity);
        Destroy(clone, destoryTime);

        hp--;
        if (hp <= 0)
            Destruction();
    }
    private void Destruction()
    {
        SoundManager.instance.PlaySE(destory_Sound);
        col.enabled = false;
        for (int i = 0; i <= count; i++)
        {
            Instantiate(go_rock_item_prefab, go_rock.transform.position, Quaternion.identity);
        }
        Destroy(go_rock);

        go_debris.SetActive(true);
        Destroy(go_debris, destoryTime);
    }
}
