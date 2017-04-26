using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startElevator : MonoBehaviour {

	public ElevatorBehavior elevator;
	public void StartElevator(){
		if (GameController.Instance.started == false) {
			elevator.On = true;
			GameController.Instance.started = true;
		}
	}

	public ConveyerBeltBehavior conveyer;
	public void StartConveyer(){
		conveyer.moving = true;
	}
}
