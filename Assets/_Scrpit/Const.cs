
//储存游戏中的各种不常修改的变量，方便统一管理
//起名字是个体力活  2024/11/6

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Const : MonoBehaviour
{
    public static Const Instance;

    //格子的宽高
    static public int CellWidth = 1;
    public static int CellHeight = 1;

    //棋子的资源
    public GameObject preStem;
    public GameObject preRoot;
    public GameObject preLeaf;
    public GameObject preStemB;
    public GameObject preRootB;
    public GameObject preLeafB;

    private void Start()
    {
        Instance = this;

        //棋子的资源
        preRoot = Resources.Load<GameObject>("prefabs/Root");
        preLeaf = Resources.Load<GameObject>("prefabs/Leaf");
        preStem = Resources.Load<GameObject>("prefabs/Stem");
        preRootB = Resources.Load<GameObject>("prefabs/RootB");
        preLeafB = Resources.Load<GameObject>("prefabs/LeafB");
        preStemB = Resources.Load<GameObject>("prefabs/StemB");
        //棋子的资源
    }

}
