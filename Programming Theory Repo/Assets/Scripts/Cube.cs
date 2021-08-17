using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Shape
{
    Vector3 rotateAmount = new Vector3(60000, 60000);
    public override void DisplayText(Transform shape)
    {
        RotateShape();
        StartCoroutine(ScaleUp(shape));
    }
    void RotateShape()
    {
        gameObject.transform.Rotate(rotateAmount * Time.deltaTime);
    }
}