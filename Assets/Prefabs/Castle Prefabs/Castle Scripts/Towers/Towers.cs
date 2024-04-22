using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : Castle
{
    private int range;

    //set range increase
    public void setRangeUp(int r)
    {
        range = r;
        Debug.Log("This tower increses range by: " + range);
    }

    //get range increase
    public int getRangeUp()
    {
        return range;
    }
}
