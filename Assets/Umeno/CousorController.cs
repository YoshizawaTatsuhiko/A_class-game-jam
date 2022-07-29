using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CousorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // マウスカーソルを消す
        //Cursor.visible = false;
    }

    void Update()
    {
        // Camera.main でメインカメラ（MainCamera タグの付いた Camera）を取得する
        // Camera.ScreenToWorldPoint 関数で、スクリーン座標をワールド座標に変換する
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition.x = 0;    // Z 座標がカメラと同じになっているので、リセットする
        this.transform.position = mousePosition;
    }
}
