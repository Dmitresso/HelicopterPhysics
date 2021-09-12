using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_Arcade_Heli_Characteristics : IP_Heli_Characteristics
    {
        #region Variables
        [Header("Arcade Properties")]
        public float bankAngle = 35f;
        public float bankSpeed = 4f;

        private float yRot = 0f;
        private float xRot = 0f;
        private float zRot = 0f;

        Quaternion finalRot = Quaternion.identity;
        #endregion


        protected override void HandleLift(Rigidbody rb, IP_Input_Controller input)
        {
            //base.HandleLift(rb, input);
            Vector3 liftForce = Vector3.up * (Physics.gravity.magnitude * rb.mass);
            rb.AddForce(liftForce, ForceMode.Force);

            rb.AddForce(Vector3.up * input.ThrottleInput * maxLiftForce, ForceMode.Acceleration);
        }

        protected override void HandleCyclic(Rigidbody rb, IP_Input_Controller input)
        {
            //base.HandleCyclic(rb, input);
            Vector3 fwdDir = input.CyclicInput.y * flatFwd;
            Vector3 rightDir = input.CyclicInput.x * flatRight;
            Vector3 finalDir = (fwdDir + rightDir).normalized;

            rb.AddForce(finalDir * cyclicForce, ForceMode.Acceleration);

            xRot = input.CyclicInput.y * bankAngle;
            zRot = -input.CyclicInput.x * bankAngle;
        }

        protected override void HandlePedals(Rigidbody rb, IP_Input_Controller input)
        {
            //base.HandlePedals(rb, input);
            yRot += input.PedalInput * tailForce;
        }

        protected override void AutoLevel(Rigidbody rb)
        {
            Quaternion wantedRot = Quaternion.Euler(xRot, yRot, zRot);
            finalRot = Quaternion.Slerp(finalRot, wantedRot, Time.fixedDeltaTime * bankSpeed);
            rb.MoveRotation(finalRot);
        }
    }
}
