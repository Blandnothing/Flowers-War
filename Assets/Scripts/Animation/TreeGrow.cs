using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrow : MonoBehaviour
{
    private Animator treeAnimator;
    // private GameObject[] enemyPieces;
    //private GameObject[] friendlyPieces;

    //private const string ExcitementTrigger = "Excitement";
    //private const string DepressionTrigger = "Depression";


    void Start()
    {
        treeAnimator = GetComponent<Animator>();
    }

    // 封装设置树生长动画状态的函数
     public void SetTreeGrowing(bool isGrowing)
    {
        if (treeAnimator != null)
        {
            treeAnimator.SetTrigger("isGrow");
        }
        else
        {
            Debug.LogError("动画组件未获取到！");
        }
    }

    // 封装设置树枯萎动画状态的函数
    public void SetTreeWithered(bool isWithered)
    {
        if (treeAnimator != null)
        {
            treeAnimator.SetTrigger("isReduce");
        }
        else
        {
            Debug.LogError("动画组件未获取到！");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //因目前没有相关逻辑判断，故先使用空格和E去判断
        if (Input.GetKeyUp(KeyCode.K))
        {
            SetTreeGrowing(true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            SetTreeWithered(true);
        }
        //enemyPieces = GameObject.FindGameObjectsWithTag("EnemyPiece");
        //friendlyPieces = GameObject.FindGameObjectsWithTag("FriendlyPiece");

        //// 检测敌方棋子存在并触发兴奋动画
        //if (enemyPieces.Length > 0)
        //{
        //    treeAnimator.SetTrigger(ExcitementTrigger);
        //}

        //// 检测己方棋子被消除并触发萎靡动画
        //if (friendlyPieces.Length == 0)
        //{
        //    treeAnimator.SetTrigger(DepressionTrigger);
        //}
    }

}
