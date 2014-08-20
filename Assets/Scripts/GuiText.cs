using UnityEngine;
using System.Collections;

public class GuiText : MonoBehaviour
{

    public GUIText mainScore;
    public GUIText[] endScores;
    public GUIText[] nearMiss;

    void Start ()
    {
        // Control the size of the main score text.
        mainScore.fontSize = Screen.width / 25;
        // Control the scale of the near miss text.
        for (int i = 0; i < nearMiss.Length; i++)
        {
            nearMiss[i].fontSize = Screen.width / 25;
        }

        // Control the size of the score that is shown when the player dies.
        for (int i = 0; i < endScores.Length; i++)
        {
            endScores[i].fontSize = Screen.width / 30;
        }
    }
}
