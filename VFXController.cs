using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VFXController : MonoBehaviour
{
    public Volume SlowmoVolume;
    public Volume GeneralVolume;

    Bloom bloomAdjLayer = null;
    ColorAdjustments colorAdjLayer = null;

    public bool grader;
    // Update is called once per frame
    void Update()
    {
        SlowmoEffectController();
        GeneralEffectsController();
    }
    public void SlowmoEffectController()
    {
        SlowmoVolume.profile.TryGet<ColorAdjustments>(out colorAdjLayer);
        if (grader)
        {
            colorAdjLayer.hueShift.value += Time.deltaTime * 60;
        }
        if (!grader)
        {
            colorAdjLayer.hueShift.value -= Time.deltaTime * 60;
        }
        if(colorAdjLayer.hueShift.value >= 120)
        {
            grader = true;
        }
        if (colorAdjLayer.hueShift.value <= -120)
        {
            grader = false;
        }
    }
    public void GeneralEffectsController()
    {

        GeneralVolume.profile.TryGet<Bloom>(out bloomAdjLayer);
        if (TimeScript.timeinstance.timefrozen)
        {
            bloomAdjLayer.intensity.value = 0.2f;   
        }
        if (TimeScript.timeinstance.timefrozen == false)
        {
            bloomAdjLayer.intensity.value = 0.5f;
        }




    }
}
