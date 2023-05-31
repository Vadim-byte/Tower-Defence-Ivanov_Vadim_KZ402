using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButon;

    void Start()
    {

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelButon.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButon[i].interactable = false;
            }
            else if (i + 1 == levelReached)
            {
                levelButon[i].interactable = true;
            }
        }
    }

	public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

}
