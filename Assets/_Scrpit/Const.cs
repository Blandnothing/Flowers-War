
//������Ϸ�еĸ��ֲ����޸ĵı���������ͳһ����
//�������Ǹ�������  2024/11/6

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Const : MonoBehaviour
{
    public static Const Instance;

    //���ӵĿ��
    static public int CellWidth = 1;
    public static int CellHeight = 1;

    //���ӵ���Դ
    public GameObject preStem;
    public GameObject preRoot;
    public GameObject preLeaf;
    public GameObject preStemB;
    public GameObject preRootB;
    public GameObject preLeafB;

    private void Start()
    {
        Instance = this;

        //���ӵ���Դ
        preRoot = Resources.Load<GameObject>("prefabs/Root");
        preLeaf = Resources.Load<GameObject>("prefabs/Leaf");
        preStem = Resources.Load<GameObject>("prefabs/Stem");
        preRootB = Resources.Load<GameObject>("prefabs/RootB");
        preLeafB = Resources.Load<GameObject>("prefabs/LeafB");
        preStemB = Resources.Load<GameObject>("prefabs/StemB");
        //���ӵ���Դ
    }

}
