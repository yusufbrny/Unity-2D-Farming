using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private void OnMouseDown()
    {//loota t�klan�nca ilgili i�lemler buradan yap�labilir.
        Debug.Log("collecting loot");
        Destroy(gameObject);
    }
}
