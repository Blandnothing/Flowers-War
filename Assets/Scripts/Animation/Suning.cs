using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suning : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator Sun;
    //øÿ÷∆∫Ø ˝
    public void TreeSun(bool SunUp)
    {
        if (SunUp)
        {
            Sun.SetTrigger("isSun");
        }
    }
    void Start()
    {
        Sun = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //≤‚ ‘”√¿˝
        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    bool SunUp = true;
        //    TreeSun(SunUp);
        //}
    }
}
