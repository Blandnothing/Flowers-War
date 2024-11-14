using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweating : MonoBehaviour
{
    private Animator SweatDown;
    public void TreeSweat(bool Sweat)
    {
        if (Sweat==true)
        {
            SweatDown.SetTrigger("isSweat");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SweatDown = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //测试用例
        //if (Input.GetKeyUp(KeyCode.Q)) {
        //    bool Sweat = true;
        //    TreeSweat(Sweat);
        //}
        //        // 假设在其他脚本中有对敌方棋子进入核心区域的检测逻辑
        //            if (IsEnemyInCore()) // 假设这是一个判断敌方棋子是否进入核心区域的方法
        //            {
        //                bool Sweat=true;
        //                TreeSweat(Sweat);
        //            }
    }
}
