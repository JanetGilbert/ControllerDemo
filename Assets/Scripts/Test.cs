using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Func<int, int, int> scoreLambda = (score, toAdd) =>
        {
            score += toAdd;

            return score;
        };

        int curScore = 100;
        Debug.Log(scoreLambda(curScore, 100));
    }
}
