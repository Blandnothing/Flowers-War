
//记录游戏状态，改变游戏状态
//起名字是个体力活  2024/11/6

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   public static GameManager Instance;
    //下棋方  0为红方 1为蓝方
    public EGamePlayer player = EGamePlayer.Blue;

    //当前落下的棋子
   public GameObject currentPiece = null;

    //红蓝方的根茎是否存在
    public bool redRootExisting = false;
    public bool redStemExisting = false;
    public bool blueRootExisting = false;
    public bool blueStemExisting = false;

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


                gameStateChange(EGameState.Thinking);
                break;
            case EGameState.Thinking:


                break;
            case EGameState.Clearing:
                System.Threading.Thread.Sleep(200);
                if (currentPiece != null)
                {
                    currentPiece = null;
                    gameStateChange(EGameState.Switching);

                }
                else { gameStateChange(EGameState.Thinking); 
                }
                break;
            case EGameState.Switching:
                if (player == EGamePlayer.Blue)
                { player = EGamePlayer.Red; }
                else if (player == EGamePlayer.Red)
                { player = EGamePlayer.Blue; }
                gameStateChange(EGameState.Thinking);
                    break;
            case EGameState.Ending:
                break;
        }
    }

    
    public void gameStateChange(EGameState state) { 
       gameState = state;
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
    Blue = 1
    }
}
