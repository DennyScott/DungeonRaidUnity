using UnityEngine;
using System.Collections;

public interface IFSMState {

    void OnEntry();
    void OnExit();

}
