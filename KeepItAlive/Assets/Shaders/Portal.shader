// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Custom/Portal"
{
	Properties
	{
		_Speed("Speed", Float) = 1
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Noise2("Noise 2", 2D) = "white" {}
		_NoiseMap("Noise Map", 2D) = "white" {}
		_NoiseMapSize("NoiseMapSize", Vector) = (512,512,0,0)
		_NoiseMapPannerSpeed("NoiseMapPannerSpeed", Vector) = (0,0,0,0)
		_NoiseMapStrenght("NoiseMapStrenght", Float) = 1
		_RingPannerSpeed("RingPannerSpeed", Vector) = (0,0,0,0)
		[HDR]_Color0("Color 0", Color) = (3.732132,1.522124,0,0.8196079)
		[HDR]_Color1("Color 1", Color) = (1,0.3885518,0,0)
		[HDR]_Color2("Color 2", Color) = (1,0.163559,0,0)
		_AlphaMask1("AlphaMask1", 2D) = "white" {}
		_GlowMask("GlowMask", 2D) = "white" {}
		[HDR]_Emissive("Emissive", Color) = (13.92881,13.92881,13.92881,0)
		_TextureSample1("Texture Sample 1", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityPBSLighting.cginc"
		#include "UnityShaderVariables.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		struct Input
		{
			float2 uv_texcoord;
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

		uniform float4 _Color0;
		uniform float4 _Color1;
		uniform sampler2D _Noise2;
		uniform sampler2D _NoiseMap;
		uniform float2 _NoiseMapSize;
		uniform float2 _NoiseMapPannerSpeed;
		uniform float _NoiseMapStrenght;
		uniform float2 _RingPannerSpeed;
		uniform float _Speed;
		uniform float4 _Color2;
		uniform sampler2D _TextureSample1;
		uniform float4 _TextureSample1_ST;
		uniform float4 _Emissive;
		uniform sampler2D _GlowMask;
		uniform float4 _GlowMask_ST;
		uniform sampler2D _AlphaMask1;
		uniform float4 _AlphaMask1_ST;
		uniform float _Cutoff = 0.5;

		inline half4 LightingStandardCustomLighting( inout SurfaceOutputCustomLightingCustom s, half3 viewDir, UnityGI gi )
		{
			UnityGIInput data = s.GIData;
			Input i = s.SurfInput;
			half4 c = 0;
			float2 temp_output_1_0_g1 = _NoiseMapSize;
			float2 appendResult10_g1 = (float2(( (temp_output_1_0_g1).x * i.uv_texcoord.x ) , ( i.uv_texcoord.y * (temp_output_1_0_g1).y )));
			float2 temp_output_11_0_g1 = _NoiseMapPannerSpeed;
			float2 panner18_g1 = ( ( (temp_output_11_0_g1).x * _Time.y ) * float2( 1,0 ) + i.uv_texcoord);
			float2 panner19_g1 = ( ( _Time.y * (temp_output_11_0_g1).y ) * float2( 0,1 ) + i.uv_texcoord);
			float2 appendResult24_g1 = (float2((panner18_g1).x , (panner19_g1).y));
			float2 temp_output_47_0_g1 = _RingPannerSpeed;
			float2 uv_TexCoord78_g1 = i.uv_texcoord * float2( 2,2 );
			float2 temp_output_31_0_g1 = ( uv_TexCoord78_g1 - float2( 1,1 ) );
			float2 appendResult39_g1 = (float2(frac( ( atan2( (temp_output_31_0_g1).x , (temp_output_31_0_g1).y ) / 6,28318548202515 ) ) , length( temp_output_31_0_g1 )));
			float2 panner54_g1 = ( ( (temp_output_47_0_g1).x * _Time.y ) * float2( 1,0 ) + appendResult39_g1);
			float2 panner55_g1 = ( ( _Time.y * (temp_output_47_0_g1).y ) * float2( 0,1 ) + appendResult39_g1);
			float2 appendResult58_g1 = (float2((panner54_g1).x , (panner55_g1).y));
			float2 uv_TexCoord1 = i.uv_texcoord + float2( -0.5,-0.5 );
			float mulTime8 = _Time.y * _Speed;
			float temp_output_9_0 = ( ( atan2( uv_TexCoord1.x , uv_TexCoord1.y ) / 6,28318548202515 ) + mulTime8 );
			float2 appendResult12 = (float2(temp_output_9_0 , temp_output_9_0));
			float4 tex2DNode37 = tex2D( _Noise2, ( ( ( (tex2D( _NoiseMap, ( appendResult10_g1 + appendResult24_g1 ) )).rg * _NoiseMapStrenght ) + ( float2( 1,1 ) * appendResult58_g1 ) ) + appendResult12 ) );
			float temp_output_82_0 = step( tex2DNode37.r , 0.47 );
			float2 uv_AlphaMask1 = i.uv_texcoord * _AlphaMask1_ST.xy + _AlphaMask1_ST.zw;
			float2 uv_TextureSample1 = i.uv_texcoord * _TextureSample1_ST.xy + _TextureSample1_ST.zw;
			float4 tex2DNode128 = tex2D( _TextureSample1, uv_TextureSample1 );
			c.rgb = 0;
			c.a = 1;
			clip( ( ( temp_output_82_0 * tex2D( _AlphaMask1, uv_AlphaMask1 ).r ) + tex2DNode128.r ) - _Cutoff );
			return c;
		}

		inline void LightingStandardCustomLighting_GI( inout SurfaceOutputCustomLightingCustom s, UnityGIInput data, inout UnityGI gi )
		{
			s.GIData = data;
		}

		void surf( Input i , inout SurfaceOutputCustomLightingCustom o )
		{
			o.SurfInput = i;
			float2 temp_output_1_0_g1 = _NoiseMapSize;
			float2 appendResult10_g1 = (float2(( (temp_output_1_0_g1).x * i.uv_texcoord.x ) , ( i.uv_texcoord.y * (temp_output_1_0_g1).y )));
			float2 temp_output_11_0_g1 = _NoiseMapPannerSpeed;
			float2 panner18_g1 = ( ( (temp_output_11_0_g1).x * _Time.y ) * float2( 1,0 ) + i.uv_texcoord);
			float2 panner19_g1 = ( ( _Time.y * (temp_output_11_0_g1).y ) * float2( 0,1 ) + i.uv_texcoord);
			float2 appendResult24_g1 = (float2((panner18_g1).x , (panner19_g1).y));
			float2 temp_output_47_0_g1 = _RingPannerSpeed;
			float2 uv_TexCoord78_g1 = i.uv_texcoord * float2( 2,2 );
			float2 temp_output_31_0_g1 = ( uv_TexCoord78_g1 - float2( 1,1 ) );
			float2 appendResult39_g1 = (float2(frac( ( atan2( (temp_output_31_0_g1).x , (temp_output_31_0_g1).y ) / 6,28318548202515 ) ) , length( temp_output_31_0_g1 )));
			float2 panner54_g1 = ( ( (temp_output_47_0_g1).x * _Time.y ) * float2( 1,0 ) + appendResult39_g1);
			float2 panner55_g1 = ( ( _Time.y * (temp_output_47_0_g1).y ) * float2( 0,1 ) + appendResult39_g1);
			float2 appendResult58_g1 = (float2((panner54_g1).x , (panner55_g1).y));
			float2 uv_TexCoord1 = i.uv_texcoord + float2( -0.5,-0.5 );
			float mulTime8 = _Time.y * _Speed;
			float temp_output_9_0 = ( ( atan2( uv_TexCoord1.x , uv_TexCoord1.y ) / 6,28318548202515 ) + mulTime8 );
			float2 appendResult12 = (float2(temp_output_9_0 , temp_output_9_0));
			float4 tex2DNode37 = tex2D( _Noise2, ( ( ( (tex2D( _NoiseMap, ( appendResult10_g1 + appendResult24_g1 ) )).rg * _NoiseMapStrenght ) + ( float2( 1,1 ) * appendResult58_g1 ) ) + appendResult12 ) );
			float4 lerpResult77 = lerp( _Color0 , _Color1 , step( tex2DNode37.r , 0.58 ));
			float temp_output_82_0 = step( tex2DNode37.r , 0.47 );
			float4 lerpResult85 = lerp( lerpResult77 , _Color2 , temp_output_82_0);
			float2 uv_TextureSample1 = i.uv_texcoord * _TextureSample1_ST.xy + _TextureSample1_ST.zw;
			float4 tex2DNode128 = tex2D( _TextureSample1, uv_TextureSample1 );
			float2 uv_GlowMask = i.uv_texcoord * _GlowMask_ST.xy + _GlowMask_ST.zw;
			o.Emission = ( ( lerpResult85 * tex2DNode128.r ) + ( _Emissive * tex2D( _GlowMask, uv_GlowMask ) ) ).rgb;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf StandardCustomLighting keepalpha fullforwardshadows 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = IN.worldPos;
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				SurfaceOutputCustomLightingCustom o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputCustomLightingCustom, o )
				surf( surfIN, o );
				UnityGI gi;
				UNITY_INITIALIZE_OUTPUT( UnityGI, gi );
				o.Alpha = LightingStandardCustomLighting( o, worldViewDir, gi ).a;
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18000
336;81;398;484;1045.761;-725.7126;1.899635;False;False
Node;AmplifyShaderEditor.TextureCoordinatesNode;1;-4829.069,766.4188;Inherit;True;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;-0.5,-0.5;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ATan2OpNode;3;-4461.819,788.503;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TauNode;89;-4334.657,1049.949;Inherit;False;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;4;-4146.042,1302.101;Inherit;False;Property;_Speed;Speed;0;0;Create;True;0;0;False;0;1;0.32;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;8;-3955.748,1234.633;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;87;-4113.872,850.267;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;55;-3897.094,452.0347;Inherit;False;Constant;_Vector2;Vector 2;8;0;Create;True;0;0;False;0;1,1;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleAddOpNode;9;-3799.565,906.0846;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;51;-3915.029,-9.883248;Inherit;False;Property;_NoiseMapSize;NoiseMapSize;4;0;Create;True;0;0;False;0;512,512;512,512;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;53;-4008.444,312.2021;Inherit;False;Property;_NoiseMapStrenght;NoiseMapStrenght;6;0;Create;True;0;0;False;0;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;49;-3867.279,-230.7278;Inherit;True;Property;_NoiseMap;Noise Map;3;0;Create;True;0;0;False;0;67cc4c382e89ab545a2095aa13113808;67cc4c382e89ab545a2095aa13113808;False;white;Auto;Texture2D;-1;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.Vector2Node;52;-3956.783,136.2838;Inherit;False;Property;_NoiseMapPannerSpeed;NoiseMapPannerSpeed;5;0;Create;True;0;0;False;0;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.Vector2Node;57;-3948.884,630.7099;Inherit;False;Property;_RingPannerSpeed;RingPannerSpeed;7;0;Create;True;0;0;False;0;0,0;0.2,0.2;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.DynamicAppendNode;12;-3317.964,890.1981;Inherit;True;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.FunctionNode;47;-3414.923,127.7319;Inherit;False;RadialUVDistortion;-1;;1;f10a29ca53963b1459443830d5ac5752;0;7;60;SAMPLER2D;0.0;False;1;FLOAT2;1,1;False;11;FLOAT2;0,0;False;65;FLOAT;1;False;68;FLOAT2;1,1;False;47;FLOAT2;1,1;False;29;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;58;-2763.558,791.5499;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;37;-2461.521,817.8923;Inherit;True;Property;_Noise2;Noise 2;2;0;Create;True;0;0;False;0;-1;64e7766099ad46747a07014e44d0aea1;67cc4c382e89ab545a2095aa13113808;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;79;-2196.295,410.4555;Inherit;False;Property;_Color1;Color 1;9;1;[HDR];Create;True;0;0;False;0;1,0.3885518,0,0;0.5349588,0,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StepOpNode;81;-2059.137,825.2519;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0.58;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;78;-2187.116,214.6464;Inherit;False;Property;_Color0;Color 0;8;1;[HDR];Create;True;0;0;False;0;3.732132,1.522124,0,0.8196079;6.964404,6.964404,6.964404,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;86;-2184.512,619.4897;Inherit;False;Property;_Color2;Color 2;10;1;[HDR];Create;True;0;0;False;0;1,0.163559,0,0;0,0,0,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StepOpNode;82;-2060.136,1156.036;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0.47;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;77;-1845.963,576.196;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;90;-1924.015,1567.49;Inherit;True;Property;_AlphaMask1;AlphaMask1;11;0;Create;True;0;0;False;0;-1;None;2eb953a5a90e28d45a106ba78cfd5eb6;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;128;-1387.087,1790.216;Inherit;True;Property;_TextureSample1;Texture Sample 1;14;0;Create;True;0;0;False;0;-1;None;465d2f36a1aa2b64e946d151b13a671d;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;95;-1160.423,631.1787;Inherit;True;Property;_GlowMask;GlowMask;12;0;Create;True;0;0;False;0;-1;None;dffe7e3aad71fb342b0b6345ea756004;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;98;-966.5383,427.6489;Inherit;False;Property;_Emissive;Emissive;13;1;[HDR];Create;True;0;0;False;0;13.92881,13.92881,13.92881,0;1335.418,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;85;-1477.612,974.344;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;113;-953.0746,992.3873;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;96;-734.7866,779.3128;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;112;-1435.174,1386.075;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;130;-650.8085,1012.408;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;129;-714.4492,1299.001;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-368.4969,994.2569;Float;False;True;-1;2;ASEMaterialInspector;0;0;CustomLighting;Custom/Portal;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;TransparentCutout;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;3;0;1;1
WireConnection;3;1;1;2
WireConnection;8;0;4;0
WireConnection;87;0;3;0
WireConnection;87;1;89;0
WireConnection;9;0;87;0
WireConnection;9;1;8;0
WireConnection;12;0;9;0
WireConnection;12;1;9;0
WireConnection;47;60;49;0
WireConnection;47;1;51;0
WireConnection;47;11;52;0
WireConnection;47;65;53;0
WireConnection;47;68;55;0
WireConnection;47;47;57;0
WireConnection;58;0;47;0
WireConnection;58;1;12;0
WireConnection;37;1;58;0
WireConnection;81;0;37;1
WireConnection;82;0;37;1
WireConnection;77;0;78;0
WireConnection;77;1;79;0
WireConnection;77;2;81;0
WireConnection;85;0;77;0
WireConnection;85;1;86;0
WireConnection;85;2;82;0
WireConnection;113;0;85;0
WireConnection;113;1;128;1
WireConnection;96;0;98;0
WireConnection;96;1;95;0
WireConnection;112;0;82;0
WireConnection;112;1;90;1
WireConnection;130;0;113;0
WireConnection;130;1;96;0
WireConnection;129;0;112;0
WireConnection;129;1;128;1
WireConnection;0;2;130;0
WireConnection;0;10;129;0
ASEEND*/
//CHKSM=E04C0E0471A079CB971D2DF63B04E83283467E7B