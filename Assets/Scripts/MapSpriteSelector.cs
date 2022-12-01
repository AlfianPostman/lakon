using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpriteSelector : MonoBehaviour
{
    public GameObject T, R, B, L,
                    TB, RL,
                    TR, LT, RB, BL,
                    LTB, TRL, RBT, BLR, StartRoom;
    public GameObject selectedRoom;
                   
    public bool top, bottom, left, right;
    
    void Start() 
    {
        PickObject();
    }

    void PickObject()
    {
        if (top){
			if (bottom){
				if (right){
					if (left){
						selectedRoom = StartRoom;
						GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
        				obj.transform.parent = gameObject.transform.parent;
						obj.layer = LayerMask.NameToLayer("UI");
					}else{
						selectedRoom = RBT;
						GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
       				 	obj.transform.parent = gameObject.transform.parent;
						obj.layer = LayerMask.NameToLayer("UI");
					}
				}else if (left){
					selectedRoom = LTB;
					GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
        			obj.transform.parent = gameObject.transform.parent;
					obj.layer = LayerMask.NameToLayer("UI");
				}else{
					selectedRoom = TB;
					GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
        			obj.transform.parent = gameObject.transform.parent;
					obj.layer = LayerMask.NameToLayer("UI");
				}
			}else{
				if (right){
					if (left){
						selectedRoom = TRL;
						GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
        				obj.transform.parent = gameObject.transform.parent;
						obj.layer = LayerMask.NameToLayer("UI");
					}else{
						selectedRoom = TR;
						GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
        				obj.transform.parent = gameObject.transform.parent;
						obj.layer = LayerMask.NameToLayer("UI");
					}
				}else if (left){
					selectedRoom = LT;
					GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
					obj.transform.parent = gameObject.transform.parent;
					obj.layer = LayerMask.NameToLayer("UI");
				}else{
					selectedRoom = T;
					GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
        			obj.transform.parent = gameObject.transform.parent;
					obj.layer = LayerMask.NameToLayer("UI");
				}
			}
			return;
		}
		if (bottom){
			if (right){
				if(left){
					selectedRoom = BLR;
					GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
        			obj.transform.parent = gameObject.transform.parent;
					obj.layer = LayerMask.NameToLayer("UI");
				}else{
					selectedRoom = RB;
					GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
        			obj.transform.parent = gameObject.transform.parent;
					obj.layer = LayerMask.NameToLayer("UI");
				}
			}else if (left){
				selectedRoom = BL;
				GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
				obj.transform.parent = gameObject.transform.parent;
				obj.layer = LayerMask.NameToLayer("UI");
			}else{
				selectedRoom = B;
				GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
        		obj.transform.parent = gameObject.transform.parent;
				obj.layer = LayerMask.NameToLayer("UI");
			}
			return;
		}
		if (right){
			if (left){
				selectedRoom = RL;
				GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
        		obj.transform.parent = gameObject.transform.parent;
				obj.layer = LayerMask.NameToLayer("UI");
			}else{
				selectedRoom = R;
				GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
        		obj.transform.parent = gameObject.transform.parent;
				obj.layer = LayerMask.NameToLayer("UI");
			}
		}else{
			selectedRoom = L;
			GameObject obj = Object.Instantiate(selectedRoom, transform.position, selectedRoom.transform.rotation);
			obj.transform.parent = gameObject.transform.parent;
			obj.layer = LayerMask.NameToLayer("UI");
		}

    }
}
