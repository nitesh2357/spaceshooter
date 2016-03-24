using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{

    public void Beginerlevel(Button button)
    {

        
         level level = new level();
         Icommand beginner = new beginCommand(level);
         Icommand advance = new advancedCommand(level);
         Icommand menu = new menuCommand(level);

        invoke game = new invoke();
         // "Stage1" is the name of the first scene we created.
         
             if (button.name == "Button") {
            // Application.LoadLevel("Stage1");
            game.StoreAndExecute(beginner);

        }
              if (button.name == "Button1")
         {
              game.StoreAndExecute(advance);
            // Application.LoadLevel("Stage1");
         }

        if (button.name == "Main Menu")
        {
            game.StoreAndExecute(menu);
            // Application.LoadLevel("Stage1");
        }

    }

}
