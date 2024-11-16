using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    public GameObject play;
    // Update is called once per frame
    public void online()
    {
        play.SetActive(true);
    }
}
