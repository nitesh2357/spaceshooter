using UnityEngine;
using System.Collections;

public class beginCommand : Icommand {

    private level _level;

    public beginCommand(level level)
    {
        _level = level;
    }

    public void Execute()
    {
        _level.begin();
    }
}
