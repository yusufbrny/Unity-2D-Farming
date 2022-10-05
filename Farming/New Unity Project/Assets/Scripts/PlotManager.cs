using System;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    private bool isPlanted = false;
    private SpriteRenderer plant;

    public Sprite[] plantStages;
    [SerializeField] private int plantStage = 0;
    [SerializeField] private float timeBtwStages = 2f;
    [SerializeField] private float timer;

    private void Awake()
    {
        plant = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (isPlanted)
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else if (plantStage < plantStages.Length - 1)
            {
                plantStage++;
                timer = timeBtwStages;
                PlantUpdate();
            }
        }
    }

    private void OnMouseDown()
    {
        if (isPlanted)
        {
            if(plantStage == plantStages.Length - 1)
                Harvest();
        }
        else
            Plant();
    }

    private void Plant()
    {
        isPlanted = true;
        plantStage = 0;
        timer = timeBtwStages;
        PlantUpdate();
        plant.gameObject.SetActive(true);
    }

    private void Harvest()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    private void PlantUpdate()
    {
        plant.sprite = plantStages[plantStage];
    }
}
