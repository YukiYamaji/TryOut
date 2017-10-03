﻿//////////////////////
//製作者　名越大樹
//製作日　10月2日
//クラス名　あたり判定の処理をするクラス　
//////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {

    [SerializeField]
    UIManager UIScript;
    /// <summary>
    /// プレイやーがほかのオブジェクト衝突した時の処理
    /// </summary>
    public void HitPlayer(GameObject playerobj,GameObject hitobj)
    {
        //イベントのオブジェクトに衝突した時
        if(hitobj.tag == "Event")
        {
            playerobj.GetComponent<Nagoshi.PlayerStatus>().SetEventObj(hitobj);
        }
        //ゴールオブジェクトに衝突した時
        else if (hitobj.tag == "Goal")
        {
            Debug.Log("ゴール！");
        }
        //宝に衝突した時
        else if (hitobj.tag == "Tresure")
        {
            int money = playerobj.GetComponent<Nagoshi.PlayerStatus>().GetMoney();
            money += 500;
            playerobj.GetComponent<Nagoshi.PlayerStatus>().SetMoney(money);
            UIScript.SetMoneyValue(money);
            Debug.Log(money);
            Destroy(hitobj);
        }
        //ギミックに衝突した時
        else if (hitobj.tag == "Gimmick")
        {
            int hp = playerobj.GetComponent<Nagoshi.PlayerStatus>().GetHp();
            hp -= 10;
            playerobj.GetComponent<Nagoshi.PlayerStatus>().SetHp(hp);
            Debug.Log("Damage");
        }
    }
}
