using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BatTest
{
    [Test]
    public void OnPressLeft_BatMoveToTheLeft()
    {
        //batter.Move(new Vector2(-1,0)); 
    }

    [Test]
    public void OnReachLeftLimit_BaterStop()
    {
        //initialPos=box.left;
        //pos = box.left;
        //batter.Move(new Vector2(-1,0));
        // then pos = initialPos
    }


    [Test]
    public void OnPressRight_BatMoveToTheRight()
    {
    }

}
