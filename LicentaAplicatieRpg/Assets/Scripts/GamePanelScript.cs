using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class GamePanelScript : MonoBehaviour
{
    public GameObject ui;
    public GameObject ui2;
    public GameObject ui3;
    public TextMeshProUGUI startBtnText;
    Slider[] sliders;
    AudioSource audioSource;
    PostProcessVolume volume;
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        sliders=ui3.GetComponentsInChildren<Slider>();
        volume = Camera.main.GetComponent<PostProcessVolume>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ui.SetActive(!ui.activeSelf);
        }
    }

    public void StartGame() {
        ui.SetActive(false);
        audioSource.Play();
        startBtnText.text = "Resume";
    }

    public void QuitGame()
    {
       Application.Quit();
    }


    public void BackButton()
    {
        ui2.SetActive(false);
    }

    public void HelpButton()
    {
        ui2.SetActive(true);
    }

    public void BackButtonOptions()
    {
        ui3.SetActive(false);
    }

    public void OptionsButton()
    {
        ui3.SetActive(true);

        ColorGrading color;
        volume.profile.TryGetSettings<ColorGrading>(out color);
        sliders[2].value = color.saturation.value/100;

        sliders[1].value = color.contrast.value / 100;

        sliders[0].value = audioSource.volume;
    }

    public void SaveOptionsBtn()
    {
        ColorGrading color;
        volume.profile.TryGetSettings<ColorGrading>(out color);
        color.saturation.value = sliders[2].value*100;


        color.contrast.value = sliders[1].value*100;

        audioSource.volume = sliders[0].value;
    }
}
