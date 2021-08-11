using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnaliticsTools 
{
    void SendMessage(string nameEvent);

    void SendMessage(string nameEvent, (string, object) data);
}
