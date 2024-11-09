using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesLeaf : pieces
{
    // Start is called before the first frame update
    void Start()
    {
        mPiecesMode = EMode.LEAF;
        mpiecesCamp = GameManager.EGamePlayer.Red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
