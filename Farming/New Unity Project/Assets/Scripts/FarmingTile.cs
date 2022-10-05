using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingTile : MonoBehaviour
{
    FarmingSystem farmingSystem;

    private void Start()
    {
        farmingSystem = FindObjectOfType<FarmingSystem>();
    }

    private void OnMouseDown()
    {
        if (farmingSystem.GetIsPlanting())
        {// planting (if player can click this  tile, it's already empty. So we can plant.
            Debug.Log("planting");
            PlantTheCrop();
        }
        else
        {// harvesting (if player can click this tile, it's already empty. So there is nothing to do.)
            Debug.Log("harvesting");
        }
    }

    private void PlantTheCrop()
    {
        Crop newCrop = Instantiate(farmingSystem.GetCropPrefab()); //cropu instantiate et
        newCrop.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 1f); // pozisyonunu ayarla
        newCrop.transform.parent = gameObject.transform; // ard�ndan parent olarak ata.
        //child olarak atama sebebi, ileride i�lem yap�lmak istenirse kolayl�k olsun diye ve objeler ortal�kta kafas�na g�re gezmesin diye.
        //pozisyonu ayarlarken baz� s�k�nt�lar ��kt���nda b�yle basamak basamak yapt�m.
    }
}
