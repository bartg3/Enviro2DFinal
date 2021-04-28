using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPscript : MonoBehaviour
{
    public static int HPValue;
    Text HP;
    // Start is called before the first frame update
    void Start()
    {

        HP = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //HPValue.text = "HP: " + HP.ToString();
    }
}
