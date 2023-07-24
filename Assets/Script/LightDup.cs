using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightDup : MonoBehaviour
{
    public Light2D light2D;
    public float minIntensity = 0f;
    public float maxIntensity = 10f;

    private void Update()
    {
        // Check if quest6 is true, and set the intensity to 0 if it is
        if (QuestManager.quest6)
        {
            SetIntensity(0f);
        }
    }

    public void SetIntensity(float value)
    {
        // Clamp the value between the min and max intensity
        float clampedValue = Mathf.Clamp(value, minIntensity, maxIntensity);
        light2D.intensity = clampedValue;
    }

}