
//创建棋盘，获取为棋盘的格子编号并记录编号
//起名字是个体力活  2024/11/6

//R1.1 起名字是个体力活 2024.11.12
//增加了检测棋子是否三个相连的方法InspectPiecesRow()和InspectPiecesCol()
//添加了消除可消除棋子的函数

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehavior : MonoBehaviour
{


    public static BoardBehavior Instance;

    //棋盘格子的宽高
    private int mCellWidth = Const.CellWidth;
    private int mCellHeight = Const.CellHeight;

    //格子碰撞体的原件
    GameObject originCell = null;

    //格子碰撞体的实例和脚本的列表
    List<GameObject> cellList = new List<GameObject>();
    List<CellBehavior> CellBehaviors = new List<CellBehavior>();

    //判断棋子相连时的中间变量
    int next = -1;
    int last = -1;
    int current = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        originCell = Resources.Load<GameObject>("prefabs/Cell");

        GameObject cell = null;

        for (int i = 0; i < 8; i++) {
            for (int n = 0; n < 8; n++) {
                //创建格子的碰撞体并且命名
                cell = Instantiate(originCell);
                cellList.Add(cell);
                CellBehaviors.Add(cell.GetComponent<CellBehavior>());
                cellList[i * 8 + n].transform.position = originCell.transform.position + new Vector3(n * mCellWidth, i * mCellHeight, 0);
                cellList[i * 8 + n].name = "cube" + (i * 8 + n);
                //创建格子的碰撞体并且命名

                //为格子脚本设定格子的编号
                CellBehaviors[i * 8 + n].index = i * 8 + n;
            }
        }
        CellBehaviors.Add(null);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void InspectPiecesRow() {
    int r = 0;
            for (int c = 1; c < 7; c++)
            {
                current = r * 8 + c;
                if (CellBehaviors[current].thisScript != null)
                {
                    last = current - 1;
                    next = current + 1;
                    if (CellBehaviors[last]?.thisScript?.mpiecesCamp == CellBehaviors[current].thisScript.mpiecesCamp && CellBehaviors[next]?.thisScript?.mpiecesCamp == CellBehaviors[current].thisScript.mpiecesCamp) {
                        CellBehaviors[last].thisScript.isRemove = (CellBehaviors[last].thisScript.isCenter != true);
                        CellBehaviors[current].thisScript.isRemove = (CellBehaviors[current].thisScript.isCenter != true);
                        CellBehaviors[next].thisScript.isRemove = (CellBehaviors[next].thisScript.isCenter != true);
                    }
                }
            }
        r = 1;
            for (int c = 1; c < 7; c++)
        {
            current = r * 8 + c;
            if (CellBehaviors[current].thisScript != null)
            {
                last = current - 1;
                next = current + 1;
                if (CellBehaviors[last]?.thisScript?.mpiecesCamp == CellBehaviors[current].thisScript.mpiecesCamp && CellBehaviors[next]?.thisScript?.mpiecesCamp == CellBehaviors[current].thisScript.mpiecesCamp)
                {
                    CellBehaviors[last].thisScript.isRemove = (CellBehaviors[last].thisScript.isCenter != true);
                    CellBehaviors[current].thisScript.isRemove = (CellBehaviors[current].thisScript.isCenter != true);
                    CellBehaviors[next].thisScript.isRemove = (CellBehaviors[next].thisScript.isCenter != true);
                }
            }
        }
            

        current = 0;
    }
    void InspectPiecesCol()
    {
        for (int c = 0; c < 8; c++) {
            for (int r = 0; r < 8; r++) {
                current = r * 8 + c;
                if (CellBehaviors[current].thisScript != null)
                {   
                    //if ( r > 0) { last = current - 1; }
                    //if ( r < 7) { next = current + 1; }
                    last = current - 8;
                    if (last < 0) { last = 64; }//处理下标超过列表范围
                    next = current + 8;
                    if (next > 63) { next = 64; }
                    if (CellBehaviors[last]?.thisScript?.mpiecesCamp == CellBehaviors[current].thisScript.mpiecesCamp && CellBehaviors[next]?.thisScript?.mpiecesCamp == CellBehaviors[current].thisScript.mpiecesCamp)
                    {
                        CellBehaviors[last].thisScript.isRemove = (CellBehaviors[last].thisScript.isCenter != true);
                        CellBehaviors[current].thisScript.isRemove = (CellBehaviors[current].thisScript.isCenter != true);
                        CellBehaviors[next].thisScript.isRemove = (CellBehaviors[next].thisScript.isCenter != true);
                    }

                }
            }
        }
        current = 0;
    }

    void ClearCell() {
        foreach (CellBehavior cell in CellBehaviors) {
            cell?.thisScript?.piecesRemove();
            if (cell?.thisScript?.isRemove == true) { 
            cell.thisScript = null;
            cell.thisPieces = null;
            }
        }
    }
     
   public void IntegrationClearingCell() {
        InspectPiecesRow();
        InspectPiecesCol();
        ClearCell();
    }
}
