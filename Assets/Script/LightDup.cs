using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightDup : MonoBehaviour ,IDataSave
{
    public Light2D light2D;
    public float minIntensity = 0f;
    public float maxIntensity = 10f;
    public int lighton = 0;

    private void Update()
    {
        // Check if quest6 is true, and set the intensity to 0 if it is
        if (QuestManager.questID == 6)
        {
            lighton = 1;
        }
        if(lighton == 1)
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

    public void SaveData(GameData data)
    {
        data.lightonQ = lighton;
    }

    public void LoadData(GameData data)
    {
       lighton = data.lightonQ;
    }

}