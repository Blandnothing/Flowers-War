using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PiecesLeafB : pieces
{
    // Start is called before the first frame update
    private void Awake()
    {
        mPiecesMode = EMode.LEAF;
        mpiecesCamp = GameManager.EGamePlayer.Blue;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override bool piecesRemove()
    {
        if (isRemove)
        {
            GameObject.Destroy(this);
            GameObject.Destroy(pieceObj);
            return true;
        }
        return false;
    }
}
