using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveManager
{
    void LoadDate(GameData _data);

    void SaveDate(ref GameData _data);
}
