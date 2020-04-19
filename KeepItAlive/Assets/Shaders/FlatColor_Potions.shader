// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Custom/FlatColor_Liquid"
{
	Properties
	{
		_Color("Color", Color) = (0,0,0,0)
		_TessValue( "Max Tessellation", Range( 1, 32 ) ) = 13.6
		_Enflamme("En flamme", Range( 0 , 1)) = 0.05
		_Float0("Float 0", Float) = 0.2
		_Float9("Float 9", Float) = 0.2
		_Oscillation("Oscillation", Range( 0 , 3)) = 2
		_Float4("Float 4", Float) = 0
		_MovementSpeed("Movement Speed", Float) = 0
		_Limit("Limit", Range( -1 , 1.5)) = 1.5
		_EmissionColor("Emission Color", Color) = (1,0.75,0.75,0)
		_ColorInt("Color Int", Float) = 0
		_RotatorSpeed("Rotator Speed", Float) = 1
		_Noisescale("Noise scale", Range( 0 , 1)) = 0.1
		_Noise("Noise", 2D) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityPBSLighting.cginc"
		#include "UnityShaderVariables.cginc"
		#pragma target 4.6
		#pragma surface surf StandardCustomLighting keepalpha addshadow fullforwardshadows vertex:vertexDataFunc tessellate:tessFunction 
		struct Input
		{
			float3 worldPos;
		};

		struct SurfaceOutputCustomLightingCustom
		{
			half3 Albedo;
			half3 Normal;
			half3 Emission;
			half Metallic;
			half Smoothness;
			half Occlusion;
			half Alpha;
			Input SurfInput;
			UnityGIInput GIData;
		};

		uniform float _Enflamme;
		uniform float _Float0;
		uniform sampler2D _Noise;
		uniform float _MovementSpeed;
		uniform float _Oscillation;
		uniform float _Limit;
		uniform float _Noisescale;
		uniform float _RotatorSpeed;
		uniform float _Float4;
		uniform float4 _Color;
		uniform float4 _EmissionColor;
		uniform float _ColorInt;
		uniform float _Float9;
		uniform float _TessValue;


		float4 CalculateContrast( float contrastValue, float4 colorTarget )
		{
			float t = 0.5 * ( 1.0 - contrastValue );
			return mul( float4x4( contrastValue,0,0,t, 0,contrastValue,0,t, 0,0,contrastValue,t, 0,0,0,1 ), colorTarget );
		}

		float4 tessFunction( )
		{
			return _TessValue;
		}

		void vertexDataFunc( inout appdata_full v )
		{
			float3 ase_vertexNormal = v.normal.xyz;
			float dotResult24 = dot( ase_vertexNormal , float3(0,1,0) );
			float3 ase_vertex3Pos = v.vertex.xyz;
			float4 appendResult33 = (float4(0.0 , ( ( dotResult24 * _Enflamme ) + min( ( _Float0 - ase_vertex3Pos.y ) , 0.0 ) ) , 0.0 , 0.0));
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float mulTime42 = _Time.y * _MovementSpeed;
			float2 appendResult9 = (float2(( ase_worldPos.x + ( ( mulTime42 * _Oscillation ) + _Limit ) ) , ase_worldPos.z));
			float mulTime46 = _Time.y * _RotatorSpeed;
			float cos44 = cos( mulTime46 );
			float sin44 = sin( mulTime46 );
			float2 rotator44 = mul( ( appendResult9 * _Noisescale ) - float2( 0.5,0.5 ) , float2x2( cos44 , -sin44 , sin44 , cos44 )) + float2( 0.5,0.5 );
			float4 tex2DNode12 = tex2Dlod( _Noise, float4( rotator44, 0, 0.0) );
			float myVarName37 = ( tex2DNode12.g + _Float4 );
			float smoothstepResult21 = smoothstep( ( myVarName37 - _Float0 ) , ( myVarName37 + _Float0 ) , ase_vertex3Pos.y);
			v.vertex.xyz += ( appendResult33 * smoothstepResult21 ).xyz;
		}

		inline half4 LightingStandardCustomLighting( inout SurfaceOutputCustomLightingCustom s, half3 viewDir, UnityGI gi )
		{
			UnityGIInput data = s.GIData;
			Input i = s.SurfInput;
			half4 c = 0;
			c.rgb = 0;
			c.a = 1;
			return c;
		}

		inline void LightingStandardCustomLighting_GI( inout SurfaceOutputCustomLightingCustom s, UnityGIInput data, inout UnityGI gi )
		{
			s.GIData = data;
		}

		void surf( Input i , inout SurfaceOutputCustomLightingCustom o )
		{
			o.SurfInput = i;
			float3 ase_worldPos = i.worldPos;
			float mulTime42 = _Time.y * _MovementSpeed;
			float2 appendResult9 = (float2(( ase_worldPos.x + ( ( mulTime42 * _Oscillation ) + _Limit ) ) , ase_worldPos.z));
			float mulTime46 = _Time.y * _RotatorSpeed;
			float cos44 = cos( mulTime46 );
			float sin44 = sin( mulTime46 );
			float2 rotator44 = mul( ( appendResult9 * _Noisescale ) - float2( 0.5,0.5 ) , float2x2( cos44 , -sin44 , sin44 , cos44 )) + float2( 0.5,0.5 );
			float4 tex2DNode12 = tex2D( _Noise, rotator44 );
			float myVarName37 = ( tex2DNode12.g + _Float4 );
			float temp_output_55_0 = ( myVarName37 - _Float9 );
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			float4 lerpResult53 = lerp( _Color , ( _EmissionColor * ( CalculateContrast(0.0,tex2DNode12) * _ColorInt ) ) , step( temp_output_55_0 , ase_vertex3Pos.y ));
			o.Emission = lerpResult53.rgb;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18000
200;73;757;653;5109.781;932.5981;3.763642;True;False
Node;AmplifyShaderEditor.RangedFloatNode;43;-6757.428,608.1383;Inherit;False;Property;_MovementSpeed;Movement Speed;12;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;4;-6602.403,855.7365;Inherit;False;Property;_Oscillation;Oscillation;10;0;Create;True;0;0;False;0;2;1.49;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;42;-6501.769,597.472;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-6306.133,742.2714;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;6;-6394.051,993.9576;Inherit;False;Property;_Limit;Limit;13;0;Create;True;0;0;False;0;1.5;1.5;-1;1.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;7;-5889.011,498.03;Inherit;True;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleAddOpNode;5;-6088.748,812.9059;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;8;-5457.422,505.2552;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;9;-5274.991,544.9142;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;47;-4931.815,724.653;Inherit;False;Property;_RotatorSpeed;Rotator Speed;16;0;Create;True;0;0;False;0;1;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;11;-5371.533,716.7924;Inherit;False;Property;_Noisescale;Noise scale;17;0;Create;True;0;0;False;0;0.1;0.152;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-4997.378,550.202;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleTimeNode;46;-4694.037,708.1915;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;44;-4452.008,575.6499;Inherit;True;3;0;FLOAT2;0,0;False;1;FLOAT2;0.5,0.5;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;41;-3405.941,1173.69;Inherit;False;Property;_Float4;Float 4;11;0;Create;True;0;0;False;0;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;20;-3072.684,1199.317;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;12;-3950.557,597.873;Inherit;True;Property;_Noise;Noise;18;0;Create;True;0;0;False;0;-1;None;67cc4c382e89ab545a2095aa13113808;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NormalVertexDataNode;22;-2771.581,578.4795;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector3Node;23;-2828.401,756.0472;Inherit;False;Constant;_Vector0;Vector 0;5;0;Create;True;0;0;False;0;0,1,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;14;-2981.256,1495.484;Inherit;False;Property;_Float0;Float 0;8;0;Create;True;0;0;False;0;0.2;10.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;27;-2567.404,818.3773;Inherit;False;Property;_Enflamme;En flamme;7;0;Create;True;0;0;False;0;0.05;0.297;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;38;-3211.667,1048.497;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;32;-2606.718,1056.103;Inherit;False;Constant;_Float2;Float 2;6;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DotProductOpNode;24;-2487.586,664.692;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;29;-2642.528,940.715;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;61;-3192.988,183.8997;Inherit;False;Property;_ColorInt;Color Int;15;0;Create;True;0;0;False;0;0;4.46;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMinOpNode;31;-2403.892,943.4221;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleContrastOpNode;50;-3339.859,4.969535;Inherit;False;2;1;COLOR;0,0,0,0;False;0;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;37;-3067.274,1006.644;Inherit;False;myVarName;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;54;-2989.02,1903.193;Inherit;False;Property;_Float9;Float 9;9;0;Create;True;0;0;False;0;0.2;0.1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;25;-2239.334,684.8291;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;17;-2679.986,1530.249;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;52;-3014.059,-351.6497;Inherit;False;Property;_EmissionColor;Emission Color;14;0;Create;True;0;0;False;0;1,0.75,0.75,0;0.6320754,0.3488341,0.5742711,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;16;-2603.564,1396.909;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;28;-2001.748,859.1898;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;60;-2941.18,-18.50023;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;34;-2006.436,1013.079;Inherit;False;Constant;_Float3;Float 3;6;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;55;-2687.75,1937.958;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;51;-2605.875,-121.0519;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.DynamicAppendNode;33;-1797.464,857.3747;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SmoothstepOpNode;21;-2356.039,1510.321;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;1;-2940.419,-642.1199;Inherit;False;Property;_Color;Color;1;0;Create;True;0;0;False;0;0,0,0,0;0.7372549,0.4352941,0.6377041,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StepOpNode;58;-2153.921,1754.254;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;35;-1582.094,869.812;Inherit;True;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.LerpOp;53;-1444.918,-162.238;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;57;-2611.328,1804.619;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;56;-2354.447,1915.692;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;132.1685,432.6677;Float;False;True;-1;6;ASEMaterialInspector;0;0;CustomLighting;Custom/FlatColor_Liquid;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Transparent;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;True;1;13.6;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;2;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;42;0;43;0
WireConnection;3;0;42;0
WireConnection;3;1;4;0
WireConnection;5;0;3;0
WireConnection;5;1;6;0
WireConnection;8;0;7;1
WireConnection;8;1;5;0
WireConnection;9;0;8;0
WireConnection;9;1;7;3
WireConnection;10;0;9;0
WireConnection;10;1;11;0
WireConnection;46;0;47;0
WireConnection;44;0;10;0
WireConnection;44;2;46;0
WireConnection;12;1;44;0
WireConnection;38;0;12;2
WireConnection;38;1;41;0
WireConnection;24;0;22;0
WireConnection;24;1;23;0
WireConnection;29;0;14;0
WireConnection;29;1;20;2
WireConnection;31;0;29;0
WireConnection;31;1;32;0
WireConnection;50;1;12;0
WireConnection;37;0;38;0
WireConnection;25;0;24;0
WireConnection;25;1;27;0
WireConnection;17;0;37;0
WireConnection;17;1;14;0
WireConnection;16;0;37;0
WireConnection;16;1;14;0
WireConnection;28;0;25;0
WireConnection;28;1;31;0
WireConnection;60;0;50;0
WireConnection;60;1;61;0
WireConnection;55;0;37;0
WireConnection;55;1;54;0
WireConnection;51;0;52;0
WireConnection;51;1;60;0
WireConnection;33;0;34;0
WireConnection;33;1;28;0
WireConnection;33;2;34;0
WireConnection;33;3;34;0
WireConnection;21;0;20;2
WireConnection;21;1;17;0
WireConnection;21;2;16;0
WireConnection;58;0;55;0
WireConnection;58;1;20;2
WireConnection;35;0;33;0
WireConnection;35;1;21;0
WireConnection;53;0;1;0
WireConnection;53;1;51;0
WireConnection;53;2;58;0
WireConnection;57;0;37;0
WireConnection;57;1;54;0
WireConnection;56;0;20;2
WireConnection;56;1;55;0
WireConnection;56;2;57;0
WireConnection;0;2;53;0
WireConnection;0;11;35;0
ASEEND*/
//CHKSM=EF07DB4C9A551D804282E059333EDEF961C8101E