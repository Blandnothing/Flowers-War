using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class PiecesStem : pieces
{

    // Start is called before the first frame update
    private void Awake()
    {
        mPiecesMode = EMode.STEM;
        mpiecesCamp = GameManager.EGamePlayer.Red;
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
            GameManager.Instance.redStemExisting = false;
            GameManager.Instance.redStemCool = 1;
            return true;
        }
        return false;
    }
}
