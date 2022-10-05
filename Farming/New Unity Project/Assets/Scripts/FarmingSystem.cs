using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmingSystem : MonoBehaviour
{
    private bool isPlanting = false;
    [Header("Buttons")]
    public Button PlantingButton;
    public Button HarvestingButton;
    //parameters used OnButtonClicks
    private Color toggledButtonColor = new Color(255, 247, 0); // tekrar tekrar tan�mlamayal�m diye
    private Color ReleasedButtonColor = new Color(255, 255, 255);
    private Image PlantingButtonImage; //optimizasyon i�in. Tekrar tekrar gidip bulmas�n diye.
    private Image HarvestingButtonImage;
    //sys parameters
    private float timer;
    public Crop cropToPlant;
    public Loot lootToDrop;

    private void Start()
    {
        PlantingButtonImage = PlantingButton.image;
        HarvestingButtonImage = HarvestingButton.image;
        OnHarvestingButton();
    }

    private void Update()
    {// timer mevzusunun sebebi optimizasyon. (oyunda mevcut bulunan t�m croplarda update() �al��t�rmamak.)
        //muhtemelen daha da iyi bir sistem yap�labilirdi ama bu yeterince i�i hafifletti�inden daha derine inmedim.
        //daha iyiden kast�m muhtemelen hi� update() kullanmadan yap�labilirdi.
        timer += Time.deltaTime;
    }



    public void OnPlantingButton()
    {
        SetIsPlanting(true);
        PlantingButtonImage.color = toggledButtonColor;
        HarvestingButtonImage.color = ReleasedButtonColor;
        Debug.Log("planting button clicked. new isPlanting = " + isPlanting);
    }

    public void OnHarvestingButton()
    {
        SetIsPlanting(false);
        HarvestingButton.image.color = toggledButtonColor;
        PlantingButton.image.color = ReleasedButtonColor;
        Debug.Log("harvesting button clicked. new isPlanting = " + isPlanting);
    }

    public bool GetIsPlanting()
    {
        return isPlanting;
    }

    public Crop GetCropPrefab()
    {
        return cropToPlant;
    }
    public Loot GetLootPrefab()
    {
        return lootToDrop;
    }

    public void SetIsPlanting(bool newBool)
    {
        isPlanting = newBool;
    }

    public float GetTimer()
    {
        return timer;
    }
}
