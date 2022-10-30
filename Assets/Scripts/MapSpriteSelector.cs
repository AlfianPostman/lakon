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
					}else{
						selectedRoom = RBT;
					}
				}else if (left){
					selectedRoom = LTB;
				}else{
					selectedRoom = TB;
				}
			}else{
				if (right){
					if (left){
						selectedRoom = TRL;
					}else{
						selectedRoom = TR;
					}
				}else if (left){
					selectedRoom = LT;
				}else{
					selectedRoom = T;
				}
			}
		}
		if (bottom){
			if (right){
				if(left){
					selectedRoom = BLR;
				}else{
					selectedRoom = RB;
				}
			}else if (left){
				selectedRoom = BL;
			}else{
				selectedRoom = B;
			}
		}
		if (right){
			if (left){
				selectedRoom = RL;
			}else{
				selectedRoom = R;
			}
		}else{
			selectedRoom = L;
		}

        GameObject obj = Object.Instantiate(selectedRoom, transform.position, Quaternion.identity);
        obj.transform.parent = gameObject.transform;
    }
}
