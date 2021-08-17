using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Shape
{
    float upwardForceMultiplier = 125f;
    public override void DisplayText(Transform shape)
    {
        StartCoroutine(Bounce());
        StartCoroutine(ScaleUp(shape));

    }
    IEnumerator Bounce()
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().AddForce(transform.up * upwardForceMultiplier);
        yield return new WaitForSeconds(waitingTime);
        Destroy(gameObject.GetComponent<Rigidbody>());
    }
}
