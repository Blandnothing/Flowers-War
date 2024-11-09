using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class PiecesStem : pieces
{   
    
    // Start is called before the first frame update
    void Start()
    {
        mPiecesMode = EMode.STEM;
        mpiecesCamp = GameManager.EGamePlayer.Red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
