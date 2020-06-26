using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarahP2 : MonoBehaviour
{
    public static int hitungDarah;
    Text hitungDarahText;

    // Start is called before the first frame update
    void Start()
    {
        hitungDarah = 5;
        hitungDarahText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hitungDarahText.text = hitungDarah.ToString();
    }
}
