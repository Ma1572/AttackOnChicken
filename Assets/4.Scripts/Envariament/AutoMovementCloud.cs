using UnityEngine;
using UnityEngine.Animations;

public class AutoMovementCloud : MonoBehaviour
{
#pragma warning disable 0649
   [SerializeField] private float _rotateSpeed;
   [SerializeField] private Axis _axis = Axis.Y;
#pragma warning restore 0649

   private Transform _transform;

   private void Start()
   {
      _transform = transform;
   }

   private void Update()
   {
      switch (_axis)
      {
         case Axis.X:
            _transform.Rotate(_rotateSpeed, 0, 0);
            break;
         case Axis.Y:
            _transform.Rotate(0, _rotateSpeed, 0);
            break;
         case Axis.Z:
            _transform.Rotate(0, 0, _rotateSpeed);
            break;
      }
   }
}
