using UnityEngine;
using System.Collections;

public class level : MonoBehaviour {

    public void begin()
    {
        // Console.WriteLine("The light is on");
        Application.LoadLevel("Stage1");
    }
    public void advanced()
    {
        //  Console.WriteLine("The light is off");
        Application.LoadLevel("Stage2");
    }
    public void menu()
    {
        //  Console.WriteLine("The light is off");
        Application.LoadLevel("Menu");
    }
}
