using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shape : MonoBehaviour
{
    public Text DisplayTxt;
    public Vector3 textPos;
    string shapeName;
    public float scaleMultiplier;
    public float waitingTime { get; } = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        shapeName = "Please select a shape!";
        textPos = DisplayTxt.transform.position;
        DisplayTxt.text = shapeName;
        scaleMultiplier = 1.5f;
}
void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisplayOnClick();
        }
    }
    public virtual IEnumerator ScaleUp(Transform objTr)
    {
        AdjustScale(scaleMultiplier, 0, objTr);
        MoveText(new Vector3(Input.mousePosition.x, Input.mousePosition.y), objTr.name);
        yield return new WaitForSeconds(waitingTime);
        AdjustScale(scaleMultiplier, 1, objTr);
        MoveText(textPos, shapeName);


    }
    public virtual void DisplayText(Transform shape)
    {
        StartCoroutine(ScaleUp(shape));
    }
    
    void DisplayOnClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == gameObject.transform)
            {
                DisplayText(hit.transform);
            }
        }
    }
    void AdjustScale(float adjustFactor, int mOrD, Transform objTr)
    {
        switch (mOrD)
        {
            case 0:
                objTr.localScale *= scaleMultiplier;
                break;
            case 1:
                objTr.localScale /= scaleMultiplier;
                break;
        }
    }
    void MoveText(Vector3 pos, string name)
    {
        DisplayTxt.transform.position = pos;
        DisplayTxt.text = name;
    }
}
