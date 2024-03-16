using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]
    private GunController thegunController;
    private Gun currentGun;

    //필요하면 허드 호출, 없으면 비활성화 
    [SerializeField]
    private GameObject go_BulletHUD;

    //총알 갯수 반영
    [SerializeField]
    private TMP_Text[] text_Bullet;

    // Update is called once per frame
    void Update()
    {
        CheckBullet();
    }
    private void CheckBullet()
    {
        currentGun = thegunController.GetGun();
        text_Bullet[0].text = currentGun.carryBulletCount.ToString();
        text_Bullet[1].text = currentGun.reloadBulletCount.ToString();
        text_Bullet[2].text = currentGun.currentBulletCount.ToString();
    }
}
