using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    delegate void SetName(string name);  
    SetName nameSetter;

    delegate void  MakeCookie(int butter, string frosting);
    MakeCookie cookieDelegate;

    void Start()
    {
        nameSetter += SetNameA;
        nameSetter += SetNameB;

        nameSetter("Moe");


        //nameSetter = 0;

        nameSetter("Larry");
    }

    void SetNameA(string A)
    {
        Debug.Log("SetNameA " + A);
    }

    void SetNameB(string B)
    {
        Debug.Log("SetNameB " + B);
    }

    // Update is called once per frame
    void Update()
    {

        /* Func<int, int, int> scoreLambda = (score, toAdd) =>
         {
             score += toAdd;

             return score;
         };

         int curScore = 100;
         Debug.Log(scoreLambda(curScore, 100));*/

        /*string word = "Tree";
        Func<char, int> findLetter = firstLetter => word.IndexOf(firstLetter);
        Debug.Log(findLetter('e'));*/

       // cookieDelegate = RestartLevel;

    }

   /* void MakeCookie(int butter, string frosting)
    {

    }*/

    int MakeCake(int birthday, string name)
    {
        return 0;
    }

    void DamageAlien(int damage, string alienName)
    {
    }

    void MakeChocolateChipCookie(int butter, string frosting, int chips)
    {

    }

    void RestartLevel(int levelNum)
    {
    }

}
