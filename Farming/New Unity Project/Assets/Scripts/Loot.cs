using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private void OnMouseDown()
    {//loota týklanýnca ilgili iþlemler buradan yapýlabilir.
        Debug.Log("collecting loot");
        Destroy(gameObject);
    }
}
