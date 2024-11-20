
//记录游戏状态，改变游戏状态
//起名字是个体力活  2024/11/6

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   public static GameManager Instance;
    //回合数
    public static int round = 0;
    //下棋方  0为红方 1为蓝方
    public EGamePlayer player = EGamePlayer.Red;

    //当前落下的棋子
    public GameObject currentPiece = null;
    //下棋的格子
    public CellBehavior currentScript = null;
    //红蓝方的根茎是否存在
    public bool redRootExisting = false;
    public bool redStemExisting = false;
    public bool blueRootExisting = false;
    public bool blueStemExisting = false;
    //红蓝方的根茎冷却
    public int redRootCool = 0;
    public int blueRootCool = 0;
    public int redStemCool = 0;
    public int blueStemCool = 0;
    //失败方
   public EGamePlayer loser { get; private set; }

    public EGameState gameState { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        gameStateChange(EGameState.Starting);
        Instance = this;
    }
    void Start()
    {
       
    }

    // Update is called once per fram
    void Update()
    {
        switch (gameState) {
            case EGameState.Starting:
                BoardBehavior.Instance.IntergrationCellDorp();
                gameStateChange(EGameState.Thinking);
                break;
            case EGameState.Thinking:


                break;
            case EGameState.Clearing:
                BoardBehavior.Instance.IntergrationPushCell();
                BoardBehavior.Instance.IntegrationClearingCell();
                System.Threading.Thread.Sleep(200);
                if (currentPiece != null)
                {
                    
                    BoardBehavior.Instance.EstimateGameEnd();
                    currentScript = null;
                    currentPiece = null;
                    if (round < 1 && gameState != EGameState.Ending)
                    {
                        round++;
                        BoardBehavior.Instance.IntergrationCellDorp();
                        gameStateChange(EGameState.Thinking);
                    }
                    else if ( 1< round&&round < 3 && gameState != EGameState.Ending) {
                        round++;
                        BoardBehavior.Instance.IntergrationCellDorp();
                        gameStateChange(EGameState.Thinking);
                    }
                    else if(gameState != EGameState.Ending)
                    {   round++;
                        gameStateChange(EGameState.Switching);
                    }
                }
                else { gameStateChange(EGameState.Thinking); 
                }
                break;
            case EGameState.Switching:
                if (player == EGamePlayer.Blue)
                { player = EGamePlayer.Red; }
                else if (player == EGamePlayer.Red)
                { player = EGamePlayer.Blue; }
                BoardBehavior.Instance.IntergrationCellDorp();
                gameStateChange(EGameState.Thinking);
                    break;
            case EGameState.Ending:
                print(loser);
                break;
        }
    }

    
    public void gameStateChange(EGameState state) { 
       gameState = state;
    }
    public void LoserSet(EGamePlayer loser) {
        this.loser = loser;
    }

    //游戏的各种状态
    public enum EGameState { 
       Starting = 0, //游戏开始的准备阶段
       Thinking = 1, //玩家下棋的思考阶段
       Clearing = 2, //下棋结束之后，结算棋盘的变化
       Switching = 3, //变换下棋方
       Ending = 4     //游戏结束
    }
    public enum EGamePlayer { 
    Red = 0 ,
    Blue = 1,
    Cell = 2 ,
    }
}
