using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Image timeImage;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float duration, currentTime;

    void Start()
    {
        panel.SetActive(false);
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime++;
        }
        OpenPanel();
    }

    void OpenPanel()
    {
        timeText.text = "";
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
}