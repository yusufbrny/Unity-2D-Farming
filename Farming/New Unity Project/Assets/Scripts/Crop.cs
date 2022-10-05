using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public int SecondsUntilReadyToHarvest;

    private FarmingSystem farmingSystem;
    private float timerOnPlantation;
    // Start is called before the first frame update
    void Start()
    {
        farmingSystem = FindObjectOfType<FarmingSystem>();
        timerOnPlantation = farmingSystem.GetTimer();
    }

    private void OnMouseDown()
    {
        if (farmingSystem.GetIsPlanting())
        {//planting
            Debug.Log("Planting " + gameObject.name + " says that.");
        }
        else
        {//Harvesting
            if((farmingSystem.GetTimer() - timerOnPlantation) >= SecondsUntilReadyToHarvest) // eðer harvestlanmasý için yeterince zaman geçtiyse
            {//crop biçilmeye uygun, bu esnadaki iþlemler burada yapýlýyor. Ýstenirse baþka kriterlerde eklenebilir.
                DropLoot();
                Debug.Log("loot instantiated, gonna destroy"); //buralarda gerekli CoRoutine iþlemleri yapýlarak animasyon vs eklenebilir.
                Destroy(gameObject);
            }
            //Debug.Log("can harvest. Proceeding to harvest. TimerOnPlantation = " + timerOnPlantation + " currentTimer = " + farmingSystem.GetTimer() + "needed time = " + SecondsUntilReadyToHarvest);
            else
            {// crop biçime uygun deðil.
                Debug.Log("too early to harvest. Please wait. " + gameObject.name + " says that.");
            }
        }
    }

    private void DropLoot()
    {
        Loot newLoot = Instantiate(farmingSystem.GetLootPrefab());
        newLoot.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 1f);
        newLoot.transform.parent = gameObject.transform.parent.transform;
    }
}
