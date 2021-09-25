// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Indie-Pixel/Particles/Heat_refraction"
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Particle Texture", 2D) = "white" {}
		_InvFade ("Soft Particles Factor", Range(0.01,3.0)) = 1.0
		_NormalIntensity("Normal Intensity", Range( 0 , 1)) = 0.5
		_Normal("Normal", 2D) = "bump" {}
	}

	Category 
	{
		SubShader
		{
			Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" }
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask RGB
			Cull Off
			Lighting Off 
			ZWrite Off
			ZTest LEqual
			GrabPass{ }

			Pass {
			
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#pragma target 2.0
				#pragma multi_compile_particles
				#pragma multi_compile_fog
				#include "UnityStandardUtils.cginc"
				#include "UnityShaderVariables.cginc"


				#include "UnityCG.cginc"

				struct appdata_t 
				{
					float4 vertex : POSITION;
					fixed4 color : COLOR;
					float4 texcoord : TEXCOORD0;
					UNITY_VERTEX_INPUT_INSTANCE_ID
					
				};

				struct v2f 
				{
					float4 vertex : SV_POSITION;
					fixed4 color : COLOR;
					float4 texcoord : TEXCOORD0;
					UNITY_FOG_COORDS(1)
					#ifdef SOFTPARTICLES_ON
					float4 projPos : TEXCOORD2;
					#endif
					UNITY_VERTEX_OUTPUT_STEREO
					float4 ase_texcoord3 : TEXCOORD3;
				};
				
				uniform sampler2D _MainTex;
				uniform fixed4 _TintColor;
				uniform float4 _MainTex_ST;
				uniform sampler2D_float _CameraDepthTexture;
				uniform float _InvFade;
				uniform sampler2D _GrabTexture;
				uniform sampler2D _Normal;
				uniform float _NormalIntensity;

				v2f vert ( appdata_t v  )
				{
					v2f o;
					UNITY_SETUP_INSTANCE_ID(v);
					UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
					float4 ase_clipPos = UnityObjectToClipPos(v.vertex);
					float4 screenPos = ComputeScreenPos(ase_clipPos);
					o.ase_texcoord3 = screenPos;
					

					v.vertex.xyz +=  float3( 0, 0, 0 ) ;
					o.vertex = UnityObjectToClipPos(v.vertex);
					#ifdef SOFTPARTICLES_ON
						o.projPos = ComputeScreenPos (o.vertex);
						COMPUTE_EYEDEPTH(o.projPos.z);
					#endif
					o.color = v.color;
					o.texcoord = v.texcoord;
					UNITY_TRANSFER_FOG(o,o.vertex);
					return o;
				}

				fixed4 frag ( v2f i  ) : SV_Target
				{
					#ifdef SOFTPARTICLES_ON
						float sceneZ = LinearEyeDepth (SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));
						float partZ = i.projPos.z;
						float fade = saturate (_InvFade * (sceneZ-partZ));
						i.color.a *= fade;
					#endif

					float4 screenPos = i.ase_texcoord3;
					float4 ase_screenPosNorm = screenPos/screenPos.w;
					ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
					float2 uv37 = i.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
					float2 panner36 = ( _Time.y * float2( 0.6,-0.4 ) + uv37);
					float2 panner49 = ( _Time.y * float2( -0.5,0.4 ) + uv37);
					float3 break53 = BlendNormals( UnpackNormal( tex2D( _Normal, panner36 ) ) , UnpackNormal( tex2D( _Normal, panner49 ) ) );
					float4 appendResult45 = (float4(( break53.x * _NormalIntensity ) , ( break53.y * _NormalIntensity ) , break53.z , 0.0));
					float4 screenColor27 = tex2D( _GrabTexture, ( (ase_screenPosNorm).xy + (appendResult45).xy ) );
					float2 uv12 = i.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
					float smoothstepResult24 = smoothstep( 0.0 , 0.3 , length( ( uv12 - float2( 0.5,0.5 ) ) ));
					float4 appendResult16 = (float4(screenColor27.r , screenColor27.g , screenColor27.b , ( 1.0 - pow( smoothstepResult24 , 9.0 ) )));
					

					fixed4 col = ( appendResult16 * i.color );
					UNITY_APPLY_FOG(i.fogCoord, col);
					return col;
				}
				ENDCG 
			}
		}	
	}
	CustomEditor "ASEMaterialInspector"
	
	
}
/*ASEBEGIN
Version=15500
51;245;1869;1030;1004.146;-13.33214;1;True;True
Node;AmplifyShaderEditor.CommentaryNode;55;-4185.913,-400.1549;Float;False;1647.704;936.5831;Normals;10;40;39;48;37;36;46;49;47;25;50;;0.8396226,0.4223712,0.1703008,1;0;0
Node;AmplifyShaderEditor.Vector2Node;48;-3834.819,375.4283;Float;False;Constant;_Vector2;Vector 2;1;0;Create;True;0;0;False;0;-0.5,0.4;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.TextureCoordinatesNode;37;-3993.504,-227.6517;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleTimeNode;40;-4135.913,160.5329;Float;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;39;-3962.73,-61.13522;Float;False;Constant;_Vector1;Vector 1;1;0;Create;True;0;0;False;0;0.6,-0.4;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.PannerNode;36;-3506.729,-63.3708;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexturePropertyNode;46;-3551.612,-342.1549;Float;True;Property;_Normal;Normal;1;0;Create;True;0;0;False;0;None;066f29fd0fc3d0341b96857dcf2cede3;True;bump;Auto;Texture2D;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.PannerNode;49;-3473.22,237.1931;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;25;-3184.801,-88.45239;Float;True;Property;_TextureSample0;Texture Sample 0;0;0;Create;True;0;0;False;0;None;066f29fd0fc3d0341b96857dcf2cede3;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;47;-3180.419,222.3109;Float;True;Property;_TextureSample1;Texture Sample 1;0;0;Create;True;0;0;False;0;None;066f29fd0fc3d0341b96857dcf2cede3;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.BlendNormalsNode;50;-2772.59,122.3558;Float;False;0;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.CommentaryNode;54;-1990.993,539.2441;Float;False;1482.69;395.117;Mask;7;12;14;15;19;24;23;22;;0.3820755,0.5383948,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;41;-2486.728,-119.3254;Float;False;Property;_NormalIntensity;Normal Intensity;0;0;Create;True;0;0;False;0;0.5;0.207;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;12;-1940.993,589.2441;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.BreakToComponentsNode;53;-2466.493,126.0632;Float;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.Vector2Node;14;-1905.604,773.3611;Float;False;Constant;_Vector0;Vector 0;1;0;Create;True;0;0;False;0;0.5,0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleSubtractOpNode;15;-1630.856,657.3415;Float;True;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;42;-2140.138,-207.2585;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;43;-2136.497,-68.99123;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;45;-1883.592,127.34;Float;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.LengthOpNode;19;-1390.027,657.147;Float;False;1;0;FLOAT2;0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;26;-1763.799,-454.6944;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;24;-1182.847,658.4332;Float;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0.3;False;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;29;-1481.512,120.822;Float;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ComponentMaskNode;28;-1517.665,-451.8561;Float;False;True;True;False;False;1;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;32;-1137.376,-204.7051;Float;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PowerNode;23;-951.4338,654.6984;Float;False;2;0;FLOAT;0;False;1;FLOAT;9;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;22;-706.3033,654.1255;Float;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenColorNode;27;-815.4976,-207.4071;Float;False;Global;_GrabScreen0;Grab Screen 0;2;0;Create;True;0;0;False;0;Object;-1;False;False;1;0;FLOAT2;0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;16;-470.8481,194.2753;Float;True;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.VertexColorNode;35;-308.9594,429.0112;Float;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;33;-111.4615,197.1843;Float;False;2;2;0;FLOAT4;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;11;157.7986,195.5221;Float;False;True;2;Float;ASEMaterialInspector;0;6;Indie-Pixel/Particles/Heat_refraction;0b6a9f8b4f707c74ca64c0be8e590de0;0;0;SubShader 0 Pass 0;2;True;2;5;False;-1;10;False;-1;0;1;False;-1;0;False;-1;False;True;2;False;-1;True;True;True;True;False;0;False;-1;False;True;2;False;-1;True;3;False;-1;False;True;4;Queue=Transparent;IgnoreProjector=True;RenderType=Transparent;PreviewType=Plane;False;0;False;False;False;False;False;False;False;False;False;True;0;0;;0;0;Standard;2;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0,0,0;False;0
WireConnection;36;0;37;0
WireConnection;36;2;39;0
WireConnection;36;1;40;0
WireConnection;49;0;37;0
WireConnection;49;2;48;0
WireConnection;49;1;40;0
WireConnection;25;0;46;0
WireConnection;25;1;36;0
WireConnection;47;0;46;0
WireConnection;47;1;49;0
WireConnection;50;0;25;0
WireConnection;50;1;47;0
WireConnection;53;0;50;0
WireConnection;15;0;12;0
WireConnection;15;1;14;0
WireConnection;42;0;53;0
WireConnection;42;1;41;0
WireConnection;43;0;53;1
WireConnection;43;1;41;0
WireConnection;45;0;42;0
WireConnection;45;1;43;0
WireConnection;45;2;53;2
WireConnection;19;0;15;0
WireConnection;24;0;19;0
WireConnection;29;0;45;0
WireConnection;28;0;26;0
WireConnection;32;0;28;0
WireConnection;32;1;29;0
WireConnection;23;0;24;0
WireConnection;22;0;23;0
WireConnection;27;0;32;0
WireConnection;16;0;27;1
WireConnection;16;1;27;2
WireConnection;16;2;27;3
WireConnection;16;3;22;0
WireConnection;33;0;16;0
WireConnection;33;1;35;0
WireConnection;11;0;33;0
ASEEND*/
//CHKSM=4A91C15596E00370C718F8FCDA3FF80674C68879