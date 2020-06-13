using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    Vector3 Rotate;

    // Start is called before the first frame update
   void Start()
    {
        Rotate.z = 100;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Rotate * Time.deltaTime);
    }
}
