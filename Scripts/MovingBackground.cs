using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour {

    public Transform target;

    public SpriteRenderer leftImage;
    public SpriteRenderer middleImage;
    public SpriteRenderer rightImage;

    private float width;

    private void Start()
    {
        width = middleImage.bounds.size.x;
        middleImage.transform.position = new Vector3(target.position.x, middleImage.transform.position.y,middleImage.transform.position.z);
        leftImage.transform.position = new Vector3(middleImage.transform.position.x - width, middleImage.transform.position.y, middleImage.transform.position.z);
        rightImage.transform.position = new Vector3(middleImage.transform.position.x + width, middleImage.transform.position.y, middleImage.transform.position.z);
    }

    private void Update()
    {
        if(target.position.x > middleImage.transform.position.x + width)
        {
            leftImage.transform.position = new Vector3(rightImage.transform.position.x + width, rightImage.transform.position.y, rightImage.transform.position.z);
            SpriteRenderer tmp = middleImage;
            middleImage = rightImage;
            rightImage = leftImage;
            leftImage = tmp;
        } else if (target.position.x < middleImage.transform.position.x - width)
        {
            rightImage.transform.position = new Vector3(leftImage.transform.position.x - width, leftImage.transform.position.y, leftImage.transform.position.z);
            SpriteRenderer tmp = middleImage;
            middleImage = leftImage;
            leftImage = rightImage;
            rightImage = tmp;
        }
    }

}
