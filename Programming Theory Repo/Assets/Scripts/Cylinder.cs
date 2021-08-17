using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : Shape
{
    public override void DisplayText(Transform shape)
    {
        scaleMultiplier = 0.1f; 
        StartCoroutine(ScaleUp(shape));

    }
}
