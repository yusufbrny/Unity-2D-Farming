using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private void OnMouseDown()
    {//loota tıklanınca ilgili işlemler buradan yapılabilir.
        Debug.Log("collecting loot");
        Destroy(gameObject);
    }
}
