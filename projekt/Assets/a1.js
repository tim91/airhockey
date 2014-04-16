#pragma strict
public var cursorObject : Transform;
public var distance : float = 1.5;

static var mousepos : Vector3;

function Start () {

Debug.Log("start");
 Screen.showCursor = false;
}

var naszObjekt : GameObject;
var speed : float = 100f;
var go : float = 10f;
function Update() {
		// Move the object forward along its z axis 1 unit/second.
		//transform.Translate(Vector3.forward * Time.deltaTime*go);
	//	transform.Rotate(Vector3.up, speed * Time.deltaTime);
		// Move the object upward in world space 1 unit/second.
		//transform.Translate(Vector3.up * Time.deltaTime, Space.World);
		//transform.rotation = naszObjekt.transform.rotation;//Quaternion.Euler(0,naszObjekt.transform.rotation,0);
		rigidbody.AddRelativeForce(Input.GetAxis("Horizontal")*speed, 0, Input.GetAxis("Vertical")*speed);
		//rigidbody.AddRelativeForce(0, 0, 0);
		//rigidbody.AddForceAtPosition();
		//Debug.Log(rigidbody.GetRelativePointVelocity(Vector3.forward).ToString);
		
		//rigidbody.MovePosition( new Vector3 ( rigidbody.position.x+Input.GetAxis("Horizontal"), rigidbody.position.y, rigidbody.position.z+Input.GetAxis("Vertical")) ) ;
	//ObjectFollowCursor();


	if (Input.GetKey(KeyCode.Escape)) {
			Debug.Log("end");
			Application.Quit();
		}
		
		
		
		var ray : Ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		
		var point : Vector3 = ray.origin + (ray.direction * distance);
		point.y =1;
		if(point.z>58)point.z = 58;
		if(point.z<44.2)point.z = 44.2;
		
		if(point.x<204)point.x = 204;
		if(point.x>229.5)point.x = 229.5;

	cursorObject.position = point;

    
	}
	


	/*
function ObjectFollowCursor() 
{

    var ray : Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    var point : Vector3 = ray.origin + (ray.direction * distance);

 	point.y = 1;
 	
    cursorObject.position = point;
} 

*/






