using UnityEngine;


namespace WheelApps {
    public struct Input {
        public static KeyCode exitButton = KeyCode.Escape;
        public static KeyCode cameraButton = KeyCode.C;
        public static KeyCode fireButton = KeyCode.Space;
        public static KeyCode helpButton = KeyCode.H;
        
        public const string Horizontal = "Horizontal";
        public const string Vertical = "Vertical";
        public const string Throttle = "Throttle";
        public const string Collective = "Collective";
        public const string Pedal = "Pedal";
        
        public const string XboxCyclicH = "XboxCyclicHorizontal";
        public const string XboxCyclicV = "XboxCyclicVertical";
        public const string XboxCollective = "XboxCollective";
        public const string XboxPedal = "XboxPedal";
        public const string XboxThrottleUp = "XboxThrottleUp";
        public const string XboxThrottleDown = "XboxThrottleDown";
        public const string XboxCameraButton = "XboxCameraButton";
        public const string XboxFireButton = "XboxFireButton";
    }
}