using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class GamePanelScript : MonoBehaviour
{
    public GameObject ui;
    public GameObject ui2;
    public GameObject ui3;
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
        sliders[2].value = color.saturation.value;

        Vignette vig;
        volume.profile.TryGetSettings<Vignette>(out vig);
        sliders[1].value=vig.intensity.value;

        sliders[0].value = audioSource.volume;
    }

    public void SaveOptionsBtn()
    {
        ColorGrading color;
        volume.profile.TryGetSettings<ColorGrading>(out color);
        color.saturation.value = sliders[2].value;

        Vignette vig;
        volume.profile.TryGetSettings<Vignette>(out vig);
        vig.intensity.value = sliders[1].value;

        audioSource.volume = sliders[0].value;
    }
}
