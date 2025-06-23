using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlantInfo : MonoBehaviour
{
    [SerializeField] private PlaceManager placeManager;

    [SerializeField] private Image flowerIcon;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private Slider cooldownSloder;
    private int cooldownSloderIndex;

    private bool isActive;
    public void ShowUI(Transform plantPos, Sapling sapling)
    {
        if (!placeManager.Placeable)
        {
            if (isActive == false)
            {
                isActive = true;
                this.gameObject.SetActive(true);
                this.transform.position = Camera.main.WorldToScreenPoint(plantPos.position - Vector3.left);

                SetUI(sapling);
            }
            else
            {
                isActive = false;
                StopCoroutine(Cooldown());
                this.gameObject.SetActive(false);
            }
        }
    }
    public void SetUI(Sapling sapling)
    {
        StopCoroutine(Cooldown());

        Flower flower = sapling.flower;

        flowerIcon.sprite = flower.Icon;
        nameText.text = flower.Name;
        levelText.text = $"Lv.{flower.flowerLevel}";

        cooldownSloder.maxValue = sapling.growTime;
        cooldownSloder.value = sapling.growTime;
        cooldownSloderIndex = sapling.growTime;

        StartCoroutine(Cooldown());
    }
    private IEnumerator Cooldown()
    {
        while (cooldownSloderIndex > 0)
        {
            cooldownSloderIndex--;

            cooldownSloder.value = cooldownSloderIndex;
            timeText.text = $"남은 시간 : {IntToTimeString(cooldownSloderIndex)}";

            yield return new WaitForSeconds(1);
        }
    }
    private string IntToTimeString(int time)
    {
        int minute = time / 60;
        int second = time % 60;

        return $"{minute}분 {second}초";
    }
}
