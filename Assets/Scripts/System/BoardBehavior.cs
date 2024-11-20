
///创建棋盘，获取为棋盘的格子编号并记录编号
///起名字是个体力活  2024/11/6

///R1.1 起名字是个体力活 2024.11.12
///增加了检测棋子是否三个相连的方法InspectPiecesRow()和InspectPiecesCol()
///添加了消除可消除棋子的函数

///R1.2 起名字是个体力活 2024.11.18
///增加了推动棋子的功能

///R1.3起名字是个体力活 2024.11.20
///增加了对下棋的限制，eg:棋子的生长，根茎的冷却

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class BoardBehavior : MonoBehaviour
{


    public static BoardBehavior Instance;

    #region 程序所用的各种变量与属性
    //棋盘格子的宽高
    private int mCellWidth = Const.CellWidth;
    private int mCellHeight = Const.CellHeight;

    //格子的原件
    GameObject originCell = null;

    //格子碰撞体的实例和脚本的列表
    List<GameObject> cellList = new List<GameObject>();
    List<CellBehavior> CellBehaviors = new List<CellBehavior>();

    //判断棋子相连时的中间变量
    int next = -1;
    int last = -1;
    int current = 0;
    #endregion

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
        for (int i = 2; i < 6; i++) {
            CellBehaviors[i].cellCamp = GameManager.EGamePlayer.Red;
            CellBehaviors[i].coreCell = true;
        }
        CellBehaviors[11].CreatePiecesRed();
        CellBehaviors[12].CreatePiecesRed();
        for (int i = 58; i < 62; i++) {
            CellBehaviors[i].cellCamp = GameManager.EGamePlayer.Blue;
            CellBehaviors[i].coreCell = true;
        }
        CellBehaviors[51].CreatePiecesBlue();
        CellBehaviors[52].CreatePiecesBlue();

    }

    void Update()
    {

    }

    #region 实现多棋子结算的方法，由IntegrationClearingCell整合
    void InspectPiecesRow() {
        for(int r = 0; r < 8; r++)
            {
            for (int c = 1; c < 7; c++)
            {
                current = r * 8 + c;
                if (current <= 5 && current >= 2) { continue; }
                if (current <= 61 && current >= 58) { continue; }
                if (CellBehaviors[current].thisScript != null)
                {
                    last = current - 1;
                    next = current + 1;
                    if (CellBehaviors[last]?.thisScript?.mpiecesCamp == CellBehaviors[current].thisScript.mpiecesCamp && CellBehaviors[next]?.thisScript?.mpiecesCamp == CellBehaviors[current].thisScript.mpiecesCamp) {
                            CellBehaviors[last].thisScript.isRemove = true;
                        CellBehaviors[current].thisScript.isRemove = true;
                        CellBehaviors[next].thisScript.isRemove = true;
                    }
                }
            }
        }
        
            

        current = 0;
    }
    void InspectPiecesCol()
    {
        for (int c = 0; c < 8; c++) {
            for (int r = 1; r < 7; r++) {
                current = r * 8 + c;
                if (CellBehaviors[current].thisScript != null)
                {   
                    //if ( r > 0) { last = current - 1; }
                    //if ( r < 7) { next = current + 1; }
                    last = current - 8;
                    next = current + 8;
                    if (CellBehaviors[last]?.thisScript?.mpiecesCamp == CellBehaviors[current].thisScript.mpiecesCamp && CellBehaviors[next]?.thisScript?.mpiecesCamp == CellBehaviors[current].thisScript.mpiecesCamp)
                    {
                        CellBehaviors[last].thisScript.isRemove =true;
                        CellBehaviors[current].thisScript.isRemove = true;
                        CellBehaviors[next].thisScript.isRemove = true;
                        print("确实是棋子消除");
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
    public void IntegrationClearingCell()
    {
        InspectPiecesRow();
        InspectPiecesCol();
        ClearCell();
    }
    #endregion

    #region 实现棋子被推动的结算, 由IntergrationPushCell整合
    void PushcolCellUp() {
        if ( GameManager.Instance.currentScript != null) {
            int cellNumber = 0;
            for (int i = GameManager.Instance.currentScript.index + 8; i <= GameManager.Instance.currentScript.index + 8 * 3; i += 8) {
                if (i >= 64) { continue; }
                if (CellBehaviors[i].thisScript == null) { break; }
                if (i >= 56) { return; }
                if (CellBehaviors[i + 8].coreCell == true && CellBehaviors[i + 8].cellCamp != GameManager.Instance.player) { return; }
                if (CellBehaviors[i].thisScript?.mPiecesMode == pieces.EMode.ROOT) { return; }
                if (CellBehaviors[i].thisScript?.mpiecesCamp == CellBehaviors[GameManager.Instance.currentScript.index].thisScript?.mpiecesCamp) { return; }
                cellNumber++;
            }
            for (int i = GameManager.Instance.currentScript.index + cellNumber * 8; i >= GameManager.Instance.currentScript.index + 8; i -= 8) {
                if (CellBehaviors[i].thisPieces != null)
                {
                    CellBehaviors[i + 8].thisScript = CellBehaviors[i].thisScript;
                    CellBehaviors[i].thisScript = null;
                    CellBehaviors[i + 8].thisPieces = CellBehaviors[i].thisPieces;
                    CellBehaviors[i].thisPieces = null;
                    CellBehaviors[i + 8].thisPieces.transform.position += new Vector3(0, Const.CellHeight, 0);
                }
                else { break; }
            }
        }
    }
    void PushcolCellDown() {
        if (GameManager.Instance.currentScript != null)
        {
            int cellNumber = 0;
            for (int i = GameManager.Instance.currentScript.index - 8; i >= GameManager.Instance.currentScript.index - 8 * 3; i -= 8)
            {
                if (i <= -1) { continue; }
                if (CellBehaviors[i].thisScript == null) { break; }
                if (i <= 7) { return; }
                if (CellBehaviors[i - 8].coreCell == true && CellBehaviors[i - 8].cellCamp != GameManager.Instance.player) { return; }
                if (CellBehaviors[i].thisScript?.mPiecesMode == pieces.EMode.ROOT) { return; }
                if (CellBehaviors[i].thisScript?.mpiecesCamp == CellBehaviors[GameManager.Instance.currentScript.index].thisScript?.mpiecesCamp) { return; }
                cellNumber++;
            }
            for (int i = GameManager.Instance.currentScript.index - cellNumber * 8; i <= GameManager.Instance.currentScript.index - 8; i += 8)
            {   
                if (CellBehaviors[i].thisScript != null)
                {
                    CellBehaviors[i - 8].thisScript = CellBehaviors[i].thisScript;
                    CellBehaviors[i].thisScript = null;
                    CellBehaviors[i - 8].thisPieces = CellBehaviors[i].thisPieces;
                    CellBehaviors[i].thisPieces = null;
                    CellBehaviors[i - 8].thisPieces.transform.position -= new Vector3(0, Const.CellWidth, 0);
                }
            }
        }
    }
    void PushcolCellRight() {
        if (GameManager.Instance.currentScript != null)
        {
            int cellNumber = 0;
            int row = (GameManager.Instance.currentScript.index / 8);
            for (int i = GameManager.Instance.currentScript.index + 1; i <= GameManager.Instance.currentScript.index + 3; i += 1)
            {
                if (i >= 64) { continue; }
                if (CellBehaviors[i].thisScript == null) { break; }
                if ( i >= row*8 + 7) { return; }
                if (CellBehaviors[i + 1 ].coreCell == true && CellBehaviors[i + 1].cellCamp != GameManager.Instance.player) { return; }
                if (CellBehaviors[i].thisScript?.mPiecesMode == pieces.EMode.ROOT) { return; }
                if (CellBehaviors[i].thisScript?.mpiecesCamp == CellBehaviors[GameManager.Instance.currentScript.index].thisScript?.mpiecesCamp) { return; }
                cellNumber++;
            }
            for (int i = GameManager.Instance.currentScript.index + cellNumber * 1; i >= GameManager.Instance.currentScript.index + 1; i -= 1)
            {
                if (CellBehaviors[i].thisScript != null)
                {
                    CellBehaviors[i + 1].thisScript = CellBehaviors[i].thisScript;
                    CellBehaviors[i].thisScript = null;
                    CellBehaviors[i + 1].thisPieces = CellBehaviors[i].thisPieces;
                    CellBehaviors[i].thisPieces = null;
                    CellBehaviors[i + 1].thisPieces.transform.position += new Vector3(Const.CellWidth,0, 0);
                }
            }
        }
    }
    void PushcolCellLeft() {
        if (GameManager.Instance.currentScript != null)
        {
            int cellNumber = 0;
            int row = (GameManager.Instance.currentScript.index / 8);
            for (int i = GameManager.Instance.currentScript.index - 1; i >= GameManager.Instance.currentScript.index - 3; i -= 1)
            {
                if (i <= -1) { continue; }
                if (CellBehaviors[i].thisScript == null) { break; }
                if (i <= row * 8 + 1) { return; }
                if (CellBehaviors[i - 1].coreCell == true && CellBehaviors[i - 1].cellCamp != GameManager.Instance.player) { return; }
                if (CellBehaviors[i].thisScript?.mPiecesMode == pieces.EMode.ROOT) { return; }
                if (CellBehaviors[i].thisScript?.mpiecesCamp == CellBehaviors[GameManager.Instance.currentScript.index].thisScript?.mpiecesCamp) { return; }
                cellNumber++;
            }
            for (int i = GameManager.Instance.currentScript.index - cellNumber * 1; i <= GameManager.Instance.currentScript.index - 1; i += 1)
            {
                if (CellBehaviors[i].thisScript != null)
                {
                    CellBehaviors[i - 1].thisScript = CellBehaviors[i].thisScript;
                    CellBehaviors[i].thisScript = null;
                    CellBehaviors[i - 1].thisPieces = CellBehaviors[i].thisPieces;
                    CellBehaviors[i].thisPieces = null;
                    CellBehaviors[i - 1].thisPieces.transform.position -= new Vector3(Const.CellWidth, 0, 0);
                }
            }
        }
    }
    public void IntergrationPushCell()
    {
        PushcolCellDown();
        PushcolCellUp();
        PushcolCellRight();
        PushcolCellLeft();
    }
    #endregion

    #region 设置格子是否可以落子，在每次转换下棋方时调用,由IntergrationCellDorp整合
    void ClearCellCanDorp() { 
        foreach (CellBehavior cell in CellBehaviors)
        {
            cell.canDorp = false;
        }
    }
    void CellCanDorp() {
        foreach (CellBehavior cell in CellBehaviors) {
            if (cell.thisScript?.mpiecesCamp == GameManager.Instance.player && cell.coreCell != true)
            {
                switch (cell.thisScript.mPiecesMode)
                {
                    case pieces.EMode.LEAF:
                        for (int r = cell.index / 8 - 1; r <= cell.index/8 + 1; r++)
                        {
                            for (int c = cell.index % 8 - 1; c <= cell.index%8 + 1; c++)
                            {
                                if (r < 0 || r > 7) {  continue; }
                                if (c < 0 || c > 7) {  continue; }
                                if (CellBehaviors[r * 8 + c].cellCamp == GameManager.Instance.player && CellBehaviors[r * 8 + c].coreCell == true) { continue; }
                                CellBehaviors[r * 8 + c].canDorp = true;
                            }
                        }
                        break;
                    case pieces.EMode.STEM:
                        for (int r = cell.index / 8 - 1; r <= cell.index/8 + 1; r++)
                        {
                            for (int c = cell.index % 8 - 2; c <= cell.index%8 + 2; c++)
                            {
                                if (r < 0 || r > 7) { continue; }
                                if (c < 0 || c > 7) { continue; }
                                if (CellBehaviors[r * 8 + c].cellCamp == GameManager.Instance.player && CellBehaviors[r * 8 + c].coreCell == true) { continue; }
                                CellBehaviors[r * 8 + c].canDorp = true;
                            }
                        }
                        break;
                    case pieces.EMode.ROOT:
                        for (int r = cell.index / 8 - 1; r <= cell.index/8 + 1; r++)
                        {
                            for (int c = cell.index % 8 - 1; c <= cell.index%8 + 1; c++)
                            {
                                if (r < 0 || r > 7) { continue; }
                                if (c < 0 || c > 7) { continue; }
                                if (CellBehaviors[r * 8 + c].cellCamp == GameManager.Instance.player && CellBehaviors[r * 8 + c].coreCell == true) { continue; }
                                CellBehaviors[r * 8 + c].canDorp = true;
                            }
                        }
                        break;
                }
            }
        }
    }
    public void IntergrationCellDorp() {
        ClearCellCanDorp();
        CellCanDorp();
    }
    #endregion

    #region 游戏结束的判断 EstimateGameEnd
    void EstimatePiecesExit(GameManager.EGamePlayer eGamePlayer ) {
    int i = 0;
    foreach (CellBehavior cell in CellBehaviors) { 
            if(cell.thisScript != null && cell.thisScript.mpiecesCamp == eGamePlayer ) {
                i++;
            }
        }
    if (i == 0) { GameManager.Instance.gameStateChange(GameManager.EGameState.Ending);
                  GameManager.Instance.LoserSet(eGamePlayer);
        }
    }
    void EstimateCoreCell() {
            if (CellBehaviors[2].thisScript != null && CellBehaviors[3].thisScript != null && CellBehaviors[4].thisScript != null && CellBehaviors[5].thisScript != null)
            {
                GameManager.Instance.gameStateChange(GameManager.EGameState.Ending);
                GameManager.Instance.LoserSet(GameManager.EGamePlayer.Red);
            }
            if (CellBehaviors[58].thisScript != null && CellBehaviors[59].thisScript != null && CellBehaviors[60].thisScript != null && CellBehaviors[61].thisScript != null)
            {
                GameManager.Instance.gameStateChange(GameManager.EGameState.Ending);
                GameManager.Instance.LoserSet(GameManager.EGamePlayer.Blue);
            }
    }
    public void EstimateGameEnd() {

        if (GameManager.Instance.player == GameManager.EGamePlayer.Blue)
        {
            EstimatePiecesExit(GameManager.EGamePlayer.Blue);
            EstimatePiecesExit(GameManager.EGamePlayer.Red);
        }
        else {
            EstimatePiecesExit(GameManager.EGamePlayer.Red);
            EstimatePiecesExit(GameManager.EGamePlayer.Blue);
        }
        EstimateCoreCell();
    }
    #endregion
}
