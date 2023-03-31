using UnityEngine;

#pragma warning disable 649
namespace UnityStandardAssets.Utility
{

	public class SmoothFollow : MonoBehaviour
	{
		public float rotateSpeed = 5.0f;
		public float zoomSpeed = 8.0f;
		public Camera mainCamera;
		
		// The target we are following
		[SerializeField] public Transform target;

		// The distance in the x-z plane to the target
		[SerializeField] private float distance = 4.0f;

		// the height we want the camera to be above the target
		[SerializeField] private float height = 5.0f;

		[SerializeField] private float rotationDamping;
		[SerializeField] private float heightDamping;

		public float smoothRotate = 5.0f;

		// Use this for initialization
		void Start()
		{
			mainCamera = GetComponent<Camera>();
		}

		// Update is called once per frame
		void LateUpdate()
		{

			Zoom();
			Rotate();


			if (mainCamera.fieldOfView >= 60)
			{
				Invoke("Reset", 1);
				 mainCamera.fieldOfView = 30;
			}

			// Early out if we don't have a target
			if (!target)
				return;
			
			
			float currYAngle = Mathf.LerpAngle(transform.eulerAngles.y, target.eulerAngles.y,
				smoothRotate * Time.deltaTime);
			Quaternion rot = Quaternion.Euler(0, currYAngle, 0);

			transform.position = target.position - (rot * Vector3.forward * distance) + (Vector3.up * height);

			transform.LookAt(target);
		}


		private void Reset()
		{
			mainCamera.fieldOfView = 30;
			  transform.rotation = Quaternion.Euler(4.258f, -359.852f, -0.409f);

		}

		private void Zoom()
		{
			float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;


			if (distance != 0)
			{

				mainCamera.fieldOfView += distance;
			}


		}

		private void Rotate()
		{
			if (Input.GetMouseButton(1))
			{
				Vector3 rot = transform.rotation.eulerAngles; // 현재 카메라의 각도를 Vector3로 반환
				rot.y += Input.GetAxis("Mouse X") * rotateSpeed; // 마우스 X 위치 * 회전 스피드
				rot.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed; // 마우스 Y 위치 * 회전 스피드
				Quaternion q =  Quaternion.Euler(rot); // Quaternion으로 변환
				q.z = 0;
				transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f); // 자연스럽게 회전
			}
		}

	}
}