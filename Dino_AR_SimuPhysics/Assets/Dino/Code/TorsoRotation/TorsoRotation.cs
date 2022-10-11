using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoRotation : MonoBehaviour
{
    [SerializeField] private GameObject chest;
    [SerializeField] private GameObject hand1;
    [SerializeField] private GameObject hand2;
    [SerializeField] private GameObject middlePoint;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 posHand1 = hand1.transform.position;
        Vector3 posHand2 = hand2.transform.position;
        
        Vector3 chestFoward = transform.forward;
        Vector3 fowardHand1 = hand1.transform.forward;
        Vector3 fowardHand2 = hand2.transform.forward;

        Vector3 fowardHands = fowardHand1 + fowardHand2;
        
        float middlePointX = (posHand1.x + posHand2.x) / 2;
        float middlePointY = (posHand1.y + posHand2.y) / 2;
        float middlePointZ = (posHand1.z + posHand2.z) / 2;

        Vector3 middlePointHands = new Vector3(middlePointX, middlePointY, middlePointZ);
        middlePoint.transform.position = middlePointHands;
        
        float dotProduct = Vector3.Dot(chestFoward, fowardHands);
       
        print(dotProduct);

        if (dotProduct > 0)
        {
           chest.transform.rotation = Quaternion.FromToRotation(chest.transform.position, middlePointHands);
        }
        
    }
}
