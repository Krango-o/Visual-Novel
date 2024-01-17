// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Stylized Toon"
{
	Properties
	{
		[Toggle(_USERIMLIGHT_ON)] _UseRimLight("UseRim Light", Float) = 0
		[Toggle(_USESPECULAR_ON)] _UseSpecular("UseSpecular Highlights", Float) = 1
		_SpecColor("Specular Value", Color) = (1,1,1,0)
		_Thicnkess("Thickness", Range( 0 , 0.1)) = 0
		_AdaptiveThicnkess("Adaptive Thickness", Range( 0 , 1)) = 0
		[HDR]_OutlineColor("Outline Color", Color) = (0,0,0,0)
		_Color("Color", Color) = (0.6792453,0.6792453,0.6792453,1)
		_SpecularFaloff("Specular Falloff", Range( 0 , 1)) = 0
		_LightRampOffset("Light Ramp Offset", Range( -1 , 1)) = 0
		_MainTex("Albedo Texture", 2D) = "white" {}
		_SideShineHardness("Side Shine Hardness", Range( 0 , 0.5)) = 0
		[NoScaleOffset][SingleLineTexture]_LightRampTexture("Light Ramp Texture", 2D) = "white" {}
		_BacklightHardness("Backlight Hardness", Range( 0 , 0.5)) = 0
		_StepOffset("Step Offset", Range( -0.5 , 0.5)) = 0
		[KeywordEnum(Step,DiffuseRamp,Posterize)] _UseLightRamp("Shading Mode", Float) = 0
		[HideInInspector]_RampDiffuseTextureLoaded("RampDiffuseTextureLoaded", Float) = 1
		[NoScaleOffset][SingleLineTexture]_DiffuseWarpNoise("Diffuse Warp Noise", 2D) = "white" {}
		[NoScaleOffset][SingleLineTexture]_SpecularMaskTexture("Specular Mask Texture", 2D) = "white" {}
		_SpecularMaskStrength("Specular Mask Strength", Range( 0 , 1)) = 0.1856417
		_WarpStrength("Warp Strength", Range( -1 , 1)) = 0
		_SpecularMaskScale("Specular Mask Tiling", Float) = 1
		_WarpTextureScale("UV Tiling", Float) = 1
		[Toggle]_UseDiffuseWarp("UseDiffuse Warp", Float) = 0
		[Toggle]_UseSpecularMask("UseSpecular Mask", Float) = 0
		[HDR]_RimColor("Rim Color", Color) = (1,1,1,0)
		_RimThickness("Rim Thickness", Range( 0 , 3)) = 1
		_RimPower("Rim Power", Range( 1 , 12)) = 12
		_RimSmoothness("Rim Smoothness", Range( 0 , 0.5)) = 0
		[Normal]_BumpMap("Normal Map", 2D) = "bump" {}
		_NormalMapStrength("Normal Map Strength", Float) = 1
		_SpecularPosterizeSteps("Specular Posterize Steps", Range( 0 , 15)) = 15
		_OutlineNoiseScale("Outline Noise Scale", Float) = 10
		_OutlineNoiseIntesity("Outline Noise Intensity", Range( 0 , 2)) = 1
		_OutlineDynamicSpeed("Outline Dynamic Speed", Range( 0 , 0.05)) = 0
		_Strength("Strength", Range( 0 , 1)) = 0
		[NoScaleOffset][SingleLineTexture]_SpecGlossMap("Specular Map", 2D) = "white" {}
		_Glossiness("Smoothness", Range( 0 , 1)) = 0.5
		[HDR]_EmissionColor("Emission Color", Color) = (0,0,0,0)
		[Toggle]_UseOutline("UseOutline", Float) = 1
		[HDR][NoScaleOffset][SingleLineTexture]_EmissionMap("Emission Map", 2D) = "white" {}
		_UseEmission("UseEmission", Float) = 0
		_IndirectLightStrength("Indirect Light Strength", Range( 0 , 1)) = 1
		_SpecularShadowMask("Specular Shadow Mask", Range( 0 , 1)) = 0
		_WarpTextureRotation("UV Rotation", Range( 0 , 180)) = 0
		_SpecularMaskRotation("Specular Mask Rotation", Range( 0 , 180)) = 0
		_BacklightAmount("Backlight Amount", Range( 0 , 1)) = 0.5
		_BacklightIntensity("Backlight Intensity", Range( 0 , 4)) = 1
		_SideShineIntensity("Side Shine Intensity", Range( 0 , 4)) = 1
		_SideShineAmount("Side Shine Amount", Range( 0 , 0.7)) = 0.2717647
		[NoScaleOffset][SingleLineTexture]_HalftoneTexture("Halftone Texture", 2D) = "white" {}
		_HalftoneSmoothness("Halftone Smoothness", Range( 0 , 2)) = 0.3
		_HalftoneEdgeOffset("Halftone Edge Offset", Range( -1 , 1)) = 0.1
		_HalftoneThreshold("Halftone Threshold", Range( 0 , 0.15)) = 0.1
		_HalftoneColor("Halftone Color", Color) = (0,0,0,1)
		[NoScaleOffset]_Hatch2("Hatch Texture Brighter", 2D) = "white" {}
		[NoScaleOffset]_Hatch1("Hatch Texture Darker", 2D) = "white" {}
		_MaxScaleDependingOnCamera("Max Scale Depends On Camera", Range( 1 , 10)) = 1
		[Toggle(_USEHATCHINGCONSTANTSCALE_ON)] _UseHatchingConstantScale("Hatch Constant Scale", Float) = 1
		[KeywordEnum(None,Haftone,Hatching)] _OverlayMode1("Overlay Mode", Float) = 0
		_ShapeSmoothness("Transition Smoothness", Range( 0 , 1)) = 0.2
		_OverlayRotation("UV Rotation", Range( 0 , 180)) = 0
		_OverlayUVTilling("UV Tiling", Float) = 0
		_Darken("Darken", Range( -1 , 1)) = 0
		_Lighten("Lighten", Range( -1 , 1)) = 0
		_SmoothnessMultiplier("Main Specular Size", Range( 0 , 2)) = 1
		_HatchingColor("Hatching Color", Color) = (0,0,0,1)
		_UVAnimationSpeedWarp("UV Animation Speed", Range( 0 , 5)) = 2
		_UVAnimationSpeedSpec("UV Animation Speed", Range( 0 , 5)) = 2
		_UVAnimationSpeed("UV Animation Speed", Range( 0 , 5)) = 2
		_UVSrcrollAngleSpec("UV Scroll Angle", Range( 0 , 360)) = 0
		_UVSrcrollAngle("UV Scroll Angle", Range( 0 , 360)) = 0
		_UVSrcrollAngleWarp("UV Scroll Angle", Range( 0 , 360)) = 0
		_UVScrollSpeedWarp("UV Scroll Speed", Range( 0 , 0.1)) = 0
		_UVScrollSpeed("UV Scroll Speed", Range( 0 , 0.1)) = 0
		_UVScrollSpeedSpec("UV Scroll Speed", Range( 0 , 0.1)) = 0
		_DiffusePosterizeSteps("Posterize Steps", Range( 1 , 10)) = 3
		_DiffusePosterizePower("Posterize Power", Range( 0.5 , 3)) = 1
		[KeywordEnum(None,Haftone,Hatching)] _OverlayMode("Overlay Mode", Float) = 0
		_DiffusePosterizeOffset("Posterize Offset", Range( -0.5 , 0.5)) = 0
		_MainLightIntesity("Main Light Intensity", Range( 0 , 6)) = 1
		_OutlineTextureStrength("Texture Strength ", Range( 0 , 1)) = 0
		_ShadowColor("Shadow Color", Color) = (0,0,0,0)
		_HalftoneToonAffect("Toon Affect", Range( 0 , 1)) = 0
		_IndirectLightAffectOnHatch("Indirect Light Affect On Hatch", Range( 0 , 1)) = 0
		_DiffuseWarpBrightnessOffset("Brightness Offset", Float) = 1.12
		[ToggleUI]_StepHalftoneTexture("Step Halftone Texture", Float) = 0
		_HaltonePatternSize("Halftone Pattern Size", Range( 0 , 1)) = 0
		_RimShadowColor("Rim Shadow Color", Color) = (0,0.05551431,0.9622642,0)
		_OcclusionMap("Occlusion Map", 2D) = "white" {}
		_OcclusionStrength("Occlusion Strength ", Range( 0 , 1)) = 1
		_PaperTilling("Paper Tiling", Float) = 1
		[NoScaleOffset]_PaperTexture("Paper Texture", 2D) = "white" {}
		[Toggle]_InverseMask("Inverse Mask", Float) = 0
		[Toggle]_DiffuseWarpAffectHalftone("Diffuse Warp Affects Halftone", Float) = 0
		[Toggle]_UseDiffuseWarpAsOverlay("Impact Shadows", Float) = 0
		[Toggle]_UseEnvironmentRefletion("Environment Reflection", Float) = 0
		[Toggle]_UseScreenUvs("Screen Uvs", Float) = 0
		[Toggle]_UseScreenUvsWarp("Screen Uvs", Float) = 0
		[Toggle]_UsePureSketch("Pure Sketch", Float) = 0
		[Toggle]_UseBacklight("Rim As Backlight & Side Shine", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[Toggle]_UseDynamicOutline("Dynamic Outline", Float) = 0
		[Toggle]_UseAdaptiveScreenUvsWarp("Adaptive Screen Uvs", Float) = 0
		[Toggle]_UseAdaptiveUvsSpecular("Use Adaptive Uvs", Float) = 0
		[Toggle]_UseAdaptiveScreenUvs("Adaptive Screen Uvs", Float) = 0
		[Toggle]_UseScreenUvsSpecular("Screen Uvs", Float) = 0
		[Enum(No Split,0,Multiply with diffuse,1,Use second color,2)]_RimSplitColor("Rim Split Color", Float) = 0
		[Enum(Normal,0,Position,1,UVBaked,2)]_OutlineType("Outline Type", Float) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ }
		Cull Front
		CGPROGRAM
		#pragma target 3.0
		#pragma surface outlineSurf Outline nofog  keepalpha noshadow noambient novertexlights nolightmap nodynlightmap nodirlightmap nometa noforwardadd vertex:outlineVertexDataFunc 
		
		void outlineVertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			float lerpResult59 = lerp( 1.0 , distance( _WorldSpaceCameraPos , ase_worldPos ) , _AdaptiveThicnkess);
			float2 temp_cast_0 = (( _Time.x * _OutlineDynamicSpeed )).xx;
			float2 uv_TexCoord591 = v.texcoord.xy + temp_cast_0;
			float simplePerlin2D590 = snoise( uv_TexCoord591*_OutlineNoiseScale );
			simplePerlin2D590 = simplePerlin2D590*0.5 + 0.5;
			float3 ase_vertexNormal = v.normal.xyz;
			float3 ase_vertex3Pos = v.vertex.xyz;
			float3 temp_output_1899_0 = ( ( _OutlineType == 0.0 ? ase_vertexNormal : float3( 0,0,0 ) ) + ( _OutlineType == 1.0 ? ase_vertex3Pos : float3( 0,0,0 ) ) + ( _OutlineType == 2.0 ? v.texcoord3.xyz : float3( 0,0,0 ) ) );
			float3 outlineVar = ( _UseOutline == 1.0 ? ( lerpResult59 * ( ( _UseDynamicOutline == 1.0 ? ( ( simplePerlin2D590 * _OutlineNoiseIntesity ) * temp_output_1899_0 ) : temp_output_1899_0 ) * _Thicnkess ) ) : float3( 0,0,0 ) );
			v.vertex.xyz += outlineVar;
		}
		inline half4 LightingOutline( SurfaceOutput s, half3 lightDir, half atten ) { return half4 ( 0,0,0, s.Alpha); }
		void outlineSurf( Input i, inout SurfaceOutput o )
		{
			float2 uv_OcclusionMap = i.uv_texcoord * _OcclusionMap_ST.xy + _OcclusionMap_ST.zw;
			float4 tex2DNode362 = tex2D( _MainTex, uv_OcclusionMap );
			float4 AlbedoTexture1853 = tex2DNode362;
			float4 lerpResult1448 = lerp( float4( 1,1,1,0 ) , AlbedoTexture1853 , _OutlineTextureStrength);
			o.Emission = ( _OutlineColor * lerpResult1448 ).rgb;
		}
		ENDCG
		

		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGINCLUDE
		#include "UnityPBSLighting.cginc"
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		#pragma shader_feature_local _OVERLAYMODE_NONE _OVERLAYMODE_HAFTONE _OVERLAYMODE_HATCHING
		#pragma shader_feature_local _USELIGHTRAMP_STEP _USELIGHTRAMP_DIFFUSERAMP _USELIGHTRAMP_POSTERIZE
		#pragma shader_feature_local _USESPECULAR_ON
		#pragma shader_feature_local _OVERLAYMODE1_NONE _OVERLAYMODE1_HAFTONE _OVERLAYMODE1_HATCHING
		#pragma shader_feature_local _USERIMLIGHT_ON
		#pragma shader_feature_local _USEHATCHINGCONSTANTSCALE_ON
		#ifdef UNITY_PASS_SHADOWCASTER
			#undef INTERNAL_DATA
			#undef WorldReflectionVector
			#undef WorldNormalVector
			#define INTERNAL_DATA half3 internalSurfaceTtoW0; half3 internalSurfaceTtoW1; half3 internalSurfaceTtoW2;
			#define WorldReflectionVector(data,normal) reflect (data.worldRefl, half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal)))
			#define WorldNormalVector(data,normal) half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal))
		#endif
		struct Input
		{
			float3 worldPos;
			float4 screenPos;
			float2 uv_texcoord;
			float3 worldNormal;
			INTERNAL_DATA
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

		uniform float _RampDiffuseTextureLoaded;
		uniform float4 _ShadowColor;
		uniform float _StepOffset;
		uniform float _UseDiffuseWarp;
		uniform sampler2D _DiffuseWarpNoise;
		uniform float _UseScreenUvsWarp;
		uniform float _UseAdaptiveScreenUvsWarp;
		uniform float _WarpTextureScale;
		uniform float _UVAnimationSpeedWarp;
		uniform float _UVScrollSpeedWarp;
		uniform float _UVSrcrollAngleWarp;
		uniform float _WarpTextureRotation;
		uniform float _WarpStrength;
		uniform sampler2D _BumpMap;
		uniform sampler2D _OcclusionMap;
		uniform float4 _OcclusionMap_ST;
		uniform float _NormalMapStrength;
		uniform float _UseDiffuseWarpAsOverlay;
		uniform float _DiffuseWarpBrightnessOffset;
		uniform sampler2D _LightRampTexture;
		uniform float _LightRampOffset;
		uniform float _DiffusePosterizeOffset;
		uniform float _DiffusePosterizePower;
		uniform float _DiffusePosterizeSteps;
		uniform float4 _Color;
		uniform sampler2D _MainTex;
		uniform float _OcclusionStrength;
		uniform float _IndirectLightStrength;
		uniform float _HalftoneToonAffect;
		uniform float4 _HalftoneColor;
		uniform float _ShapeSmoothness;
		uniform float _HalftoneThreshold;
		uniform float _HalftoneEdgeOffset;
		uniform float _HalftoneSmoothness;
		uniform float _DiffuseWarpAffectHalftone;
		uniform sampler2D _HalftoneTexture;
		uniform float _UseScreenUvs;
		uniform float _UseAdaptiveScreenUvs;
		uniform float _OverlayUVTilling;
		uniform float _UVAnimationSpeed;
		uniform float _UVScrollSpeed;
		uniform float _UVSrcrollAngle;
		uniform float _OverlayRotation;
		uniform float _MainLightIntesity;
		uniform sampler2D _SpecGlossMap;
		uniform float _Glossiness;
		uniform float _SmoothnessMultiplier;
		uniform float _SpecularFaloff;
		uniform float _SpecularPosterizeSteps;
		uniform float _UseSpecularMask;
		uniform float _InverseMask;
		uniform float _StepHalftoneTexture;
		uniform sampler2D _SpecularMaskTexture;
		uniform float _UseScreenUvsSpecular;
		uniform float _UVScrollSpeedSpec;
		uniform float _UVSrcrollAngleSpec;
		uniform float _UVAnimationSpeedSpec;
		uniform float _UseAdaptiveUvsSpecular;
		uniform float _SpecularMaskScale;
		uniform float _SpecularMaskRotation;
		uniform float _HaltonePatternSize;
		uniform float _SpecularMaskStrength;
		uniform float _SpecularShadowMask;
		uniform float _UseEnvironmentRefletion;
		uniform float _Strength;
		uniform float _RimSplitColor;
		uniform float4 _RimColor;
		uniform float4 _RimShadowColor;
		uniform float _UseBacklight;
		uniform float _BacklightIntensity;
		uniform float _RimSmoothness;
		uniform float _RimThickness;
		uniform float _RimPower;
		uniform float _BacklightHardness;
		uniform float _BacklightAmount;
		uniform float _SideShineIntensity;
		uniform float _SideShineHardness;
		uniform float _SideShineAmount;
		uniform float _UseEmission;
		uniform sampler2D _EmissionMap;
		uniform float4 _EmissionColor;
		uniform float _UsePureSketch;
		uniform float4 _HatchingColor;
		uniform float _IndirectLightAffectOnHatch;
		uniform sampler2D _PaperTexture;
		uniform float _PaperTilling;
		uniform float _Darken;
		uniform float _Lighten;
		uniform sampler2D _Hatch1;
		uniform sampler2D _Hatch2;
		uniform float _MaxScaleDependingOnCamera;
		uniform float4 _OutlineColor;
		uniform float _OutlineTextureStrength;
		uniform float _UseOutline;
		uniform float _AdaptiveThicnkess;
		uniform float _UseDynamicOutline;
		uniform float _OutlineDynamicSpeed;
		uniform float _OutlineNoiseScale;
		uniform float _OutlineNoiseIntesity;
		uniform float _OutlineType;
		uniform float _Thicnkess;


		inline float4 ASE_ComputeGrabScreenPos( float4 pos )
		{
			#if UNITY_UV_STARTS_AT_TOP
			float scale = -1.0;
			#else
			float scale = 1.0;
			#endif
			float4 o = pos;
			o.y = pos.w * 0.5f;
			o.y = ( pos.y - o.y ) * _ProjectionParams.x * scale + o.y;
			return o;
		}


		float Posterize1331( float In, float Steps )
		{
			return  floor(In / (1 / Steps)) * (1 / Steps);
		}


		float FaloffPosterize( float IN, float SpecFaloff, float Steps )
		{
			float minOut = 0.5 * SpecFaloff - 0.005;
			float faloff = lerp(IN, smoothstep(minOut, 0.5, IN), SpecFaloff);
			if(Steps < 1)
			{
			    return faloff;
			}
			else
			{
			    return  floor(faloff / (1 / Steps)) * (1 / Steps);
			}
		}


		float3 Hatching476( float2 _uv, float color, sampler2D _Hatch0, sampler2D _Hatch1 )
		{
			float intensity = color;
			    float3 hatch0 = tex2D(_Hatch0, _uv).rgb;
			    float3 hatch1 = tex2D(_Hatch1, _uv).rgb;
			    float3 overbright = max(0, intensity - 1.0);
			    float3 weightsA = saturate((intensity * 6.0) + float3(-0, -1, -2));
			    float3 weightsB = saturate((intensity * 6.0) + float3(-3, -4, -5));
			    weightsA.xy -= weightsA.yz;
			    weightsA.z -= weightsB.x;
			    weightsB.xy -= weightsB.yz;
			    hatch0 = hatch0 * weightsA;
			    hatch1 = hatch1 * weightsB;
			    float3 hatching = overbright + hatch0.r +
			        hatch0.g + hatch0.b +
			        hatch1.r + hatch1.g +
			        hatch1.b;
			    return hatching;
			    return hatching;
		}


		float3 HatchingConstantScale491( float2 _uv, float _intensity, sampler2D _Hatch0, sampler2D _Hatch1, float _dist, float _MaxScaleDependingOnCamera )
		{
				float log2_dist = log2(_dist)-0.2;
				
				float2 floored_log_dist = floor( (log2_dist + float2(0.0, 1.0) ) * 0.5) *2.0 - float2(0.0, 1.0);				
				float2 uv_scale = min(_MaxScaleDependingOnCamera, pow(2.0, floored_log_dist));
				
				float uv_blend = abs(frac(log2_dist * 0.5) * 2.0 - 1.0);
				
				float2 scaledUVA = _uv / uv_scale.x; // 16
				float2 scaledUVB = _uv / uv_scale.y; // 8 
				float3 hatch0A = tex2D(_Hatch0, scaledUVA).rgb;
				float3 hatch1A = tex2D(_Hatch1, scaledUVA).rgb;
				float3 hatch0B = tex2D(_Hatch0, scaledUVB).rgb;
				float3 hatch1B = tex2D(_Hatch1, scaledUVB).rgb;
				float3 hatch0 = lerp(hatch0A, hatch0B, uv_blend);
				float3 hatch1 = lerp(hatch1A, hatch1B, uv_blend);
				float3 overbright = max(0, _intensity - 1.0);
				float3 weightsA = saturate((_intensity * 6.0) + float3(-0, -1, -2));
				float3 weightsB = saturate((_intensity * 6.0) + float3(-3, -4, -5));
				weightsA.xy -= weightsA.yz;
				weightsA.z -= weightsB.x;
				weightsB.xy -= weightsB.yz;
				hatch0 = hatch0 * weightsA;
				hatch1 = hatch1 * weightsB;
				float3 hatching = overbright + hatch0.r +
					hatch0.g + hatch0.b +
					hatch1.r + hatch1.g +
					hatch1.b;
				return hatching;
		}


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			v.vertex.xyz += 0;
			v.vertex.w = 1;
		}

		inline half4 LightingStandardCustomLighting( inout SurfaceOutputCustomLightingCustom s, half3 viewDir, UnityGI gi )
		{
			UnityGIInput data = s.GIData;
			Input i = s.SurfInput;
			half4 c = 0;
			#ifdef UNITY_PASS_FORWARDBASE
			float ase_lightAtten = data.atten;
			if( _LightColor0.a == 0)
			ase_lightAtten = 0;
			#else
			float3 ase_lightAttenRGB = gi.light.color / ( ( _LightColor0.rgb ) + 0.000001 );
			float ase_lightAtten = max( max( ase_lightAttenRGB.r, ase_lightAttenRGB.g ), ase_lightAttenRGB.b );
			#endif
			#if defined(HANDLE_SHADOWS_BLENDING_IN_GI)
			half bakedAtten = UnitySampleBakedOcclusion(data.lightmapUV.xy, data.worldPos);
			float zDist = dot(_WorldSpaceCameraPos - data.worldPos, UNITY_MATRIX_V[2].xyz);
			float fadeDist = UnityComputeShadowFadeDistance(data.worldPos, zDist);
			ase_lightAtten = UnityMixRealtimeAndBakedShadows(data.atten, bakedAtten, UnityComputeShadowFade(fadeDist));
			#endif
			#if defined(LIGHTMAP_ON) && ( UNITY_VERSION < 560 || ( defined(LIGHTMAP_SHADOW_MIXING) && !defined(SHADOWS_SHADOWMASK) && defined(SHADOWS_SCREEN) ) )//aselc
			float4 ase_lightColor = 0;
			#else //aselc
			float4 ase_lightColor = _LightColor0;
			#endif //aselc
			float temp_output_371_0 = ( _StepOffset + 0.5 );
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			float4 unityObjectToClipPos2_g188 = UnityObjectToClipPos( ase_vertex3Pos );
			float4 computeScreenPos3_g188 = ComputeScreenPos( unityObjectToClipPos2_g188 );
			float temp_output_29_0_g188 = ( _WarpTextureScale / 4.0 );
			float4 unityObjectToClipPos13_g188 = UnityObjectToClipPos( float3(0,0,0) );
			float4 computeScreenPos17_g188 = ComputeScreenPos( unityObjectToClipPos13_g188 );
			float4 transform20_g188 = mul(unity_ObjectToWorld,float4( 0,0,0,1 ));
			float4 break22_g188 = ( ( ( ( computeScreenPos3_g188 / (computeScreenPos3_g188).w ) * temp_output_29_0_g188 ) - ( temp_output_29_0_g188 * ( computeScreenPos17_g188 / (computeScreenPos17_g188).w ) ) ) * distance( ( float4( _WorldSpaceCameraPos , 0.0 ) - transform20_g188 ) , float4( 0,0,0,0 ) ) );
			float4 break26_g188 = _ScreenParams;
			float4 appendResult24_g188 = (float4(( break22_g188.x * ( break26_g188.x / break26_g188.y ) ) , break22_g188.y , break22_g188.z , break22_g188.w));
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_grabScreenPos = ASE_ComputeGrabScreenPos( ase_screenPos );
			float4 ase_grabScreenPosNorm = ase_grabScreenPos / ase_grabScreenPos.w;
			float2 appendResult1847 = (float2(( _WarpTextureScale * ( _ScreenParams.x / _ScreenParams.y ) ) , _WarpTextureScale));
			float mulTime1525 = _Time.y * _UVAnimationSpeedWarp;
			float temp_output_1527_0 = ( floor( ( mulTime1525 % 2.0 ) ) * 0.5 );
			float2 appendResult1531 = (float2(temp_output_1527_0 , temp_output_1527_0));
			float mulTime1523 = _Time.y * _UVScrollSpeedWarp;
			float temp_output_1518_0 = radians( _UVSrcrollAngleWarp );
			float2 appendResult1520 = (float2(cos( temp_output_1518_0 ) , sin( temp_output_1518_0 )));
			float2 temp_output_1522_0 = ( mulTime1523 * appendResult1520 );
			float2 temp_cast_4 = (_WarpTextureScale).xx;
			float2 uv_TexCoord1495 = i.uv_texcoord * temp_cast_4 + temp_output_1522_0;
			float cos1489 = cos( radians( _WarpTextureRotation ) );
			float sin1489 = sin( radians( _WarpTextureRotation ) );
			float2 rotator1489 = mul( ( _UseScreenUvsWarp == 1.0 ? ( ( _UseAdaptiveScreenUvsWarp == 1.0 ? appendResult24_g188 : ( ase_grabScreenPosNorm * float4( appendResult1847, 0.0 , 0.0 ) ) ) + float4( appendResult1531, 0.0 , 0.0 ) + float4( temp_output_1522_0, 0.0 , 0.0 ) ) : float4( uv_TexCoord1495, 0.0 , 0.0 ) ).xy - float2( 0.5,0.5 ) , float2x2( cos1489 , -sin1489 , sin1489 , cos1489 )) + float2( 0.5,0.5 );
			float BNLightWarpVector250 = ( _UseDiffuseWarp == 1.0 ? ( tex2D( _DiffuseWarpNoise, rotator1489 ).r * _WarpStrength ) : 0.0 );
			float2 uv_OcclusionMap = i.uv_texcoord * _OcclusionMap_ST.xy + _OcclusionMap_ST.zw;
			float3 lerpResult1536 = lerp( float3(0,0,1) , UnpackNormal( tex2D( _BumpMap, uv_OcclusionMap ) ) , _NormalMapStrength);
			float3 BNCurrentNormal1538 = normalize( (WorldNormalVector( i , lerpResult1536 )) );
			float3 ase_worldPos = i.worldPos;
			#if defined(LIGHTMAP_ON) && UNITY_VERSION < 560 //aseld
			float3 ase_worldlightDir = 0;
			#else //aseld
			float3 ase_worldlightDir = normalize( UnityWorldSpaceLightDir( ase_worldPos ) );
			#endif //aseld
			float dotResult234 = dot( BNCurrentNormal1538 , ase_worldlightDir );
			float BNNDotL233 = dotResult234;
			float3 temp_cast_7 = (( BNLightWarpVector250 + ( ( 1.0 - BNLightWarpVector250 ) * BNNDotL233 ) )).xxx;
			float3 BNAttenuationColor244 = ( ase_lightColor.rgb * ase_lightAtten );
			float3 temp_output_260_0 = ( max( temp_cast_7 , float3(0,0,0) ) * BNAttenuationColor244 );
			float3 break3_g197 = temp_output_260_0;
			float temp_output_1188_0 = max( max( break3_g197.x , break3_g197.y ) , break3_g197.z );
			float smoothstepResult444 = smoothstep( ( temp_output_371_0 - 0.009 ) , temp_output_371_0 , temp_output_1188_0);
			float4 lerpResult1619 = lerp( _ShadowColor , ase_lightColor , saturate( smoothstepResult444 ));
			float ShadowAtten1415 = ase_lightAtten;
			float temp_output_1875_0 = ( _UseDiffuseWarpAsOverlay == 1.0 ? saturate( ( ShadowAtten1415 + BNLightWarpVector250 + ( _DiffuseWarpBrightnessOffset * -1.0 * ( 1.0 - ShadowAtten1415 ) ) ) ) : ShadowAtten1415 );
			float4 lerpResult1626 = lerp( _ShadowColor , lerpResult1619 , temp_output_1875_0);
			float2 appendResult356 = (float2(( _LightRampOffset + temp_output_1188_0 ) , 0.0));
			float2 temp_cast_8 = (0.01).xx;
			float2 temp_cast_9 = (0.98).xx;
			float2 clampResult358 = clamp( appendResult356 , temp_cast_8 , temp_cast_9 );
			float4 lerpResult1617 = lerp( tex2D( _LightRampTexture, float2( 0.02,0 ) ) , ( tex2D( _LightRampTexture, clampResult358 ) * ase_lightColor ) , temp_output_1875_0);
			float In1331 = pow( saturate( ( temp_output_1188_0 + ( _DiffusePosterizeOffset * -1.0 ) ) ) , _DiffusePosterizePower );
			float Steps1331 = round( _DiffusePosterizeSteps );
			float localPosterize1331 = Posterize1331( In1331 , Steps1331 );
			float4 lerpResult1629 = lerp( _ShadowColor , ase_lightColor , localPosterize1331);
			float4 lerpResult1628 = lerp( _ShadowColor , lerpResult1629 , temp_output_1875_0);
			#if defined(_USELIGHTRAMP_STEP)
				float4 staticSwitch372 = lerpResult1626;
			#elif defined(_USELIGHTRAMP_DIFFUSERAMP)
				float4 staticSwitch372 = lerpResult1617;
			#elif defined(_USELIGHTRAMP_POSTERIZE)
				float4 staticSwitch372 = lerpResult1628;
			#else
				float4 staticSwitch372 = lerpResult1626;
			#endif
			float4 BNDiffuse391 = ( staticSwitch372 + float4( 0,0,0,0 ) );
			#if defined(_OVERLAYMODE_NONE)
				float4 staticSwitch1266 = BNDiffuse391;
			#elif defined(_OVERLAYMODE_HAFTONE)
				float4 staticSwitch1266 = BNDiffuse391;
			#elif defined(_OVERLAYMODE_HATCHING)
				float4 staticSwitch1266 = BNDiffuse391;
			#else
				float4 staticSwitch1266 = BNDiffuse391;
			#endif
			float4 tex2DNode362 = tex2D( _MainTex, uv_OcclusionMap );
			float lerpResult1655 = lerp( 1.0 , tex2D( _OcclusionMap, uv_OcclusionMap ).r , _OcclusionStrength);
			float4 appendResult1656 = (float4(lerpResult1655 , lerpResult1655 , lerpResult1655 , 1.0));
			float4 MainTexture364 = ( _Color * tex2DNode362 * appendResult1656 );
			UnityGI gi276 = gi;
			float3 diffNorm276 = BNCurrentNormal1538;
			gi276 = UnityGI_Base( data, 1, diffNorm276 );
			float3 indirectDiffuse276 = gi276.indirect.diffuse + diffNorm276 * 0.0001;
			float IndirectLightStrength1221 = _IndirectLightStrength;
			float3 lerpResult692 = lerp( float3( 0,0,0 ) , indirectDiffuse276 , IndirectLightStrength1221);
			float4 IndirectDiffuseLight1269 = ( MainTexture364 * float4( lerpResult692 , 0.0 ) );
			float4 BNFinalDiffuse239 = ( ( staticSwitch1266 * MainTexture364 ) + IndirectDiffuseLight1269 );
			float4 BNDiffuseNoAdditionalLights1554 = staticSwitch372;
			float4 lerpResult1462 = lerp( ase_lightColor , BNDiffuseNoAdditionalLights1554 , _HalftoneToonAffect);
			float4 temp_output_1225_0 = ( lerpResult1462 * MainTexture364 );
			float4 lerpResult1784 = lerp( temp_output_1225_0 , _HalftoneColor , _HalftoneColor.a);
			float3 temp_cast_12 = (( BNLightWarpVector250 + ( ( 1.0 - BNLightWarpVector250 ) * BNNDotL233 ) )).xxx;
			float3 temp_cast_13 = (BNNDotL233).xxx;
			float3 CompleteDiffuseLight965 = ( _DiffuseWarpAffectHalftone == 1.0 ? ( temp_output_260_0 * ShadowAtten1415 ) : ( max( temp_cast_13 , float3(0,0,0) ) * BNAttenuationColor244 * ShadowAtten1415 ) );
			float3 break3_g199 = CompleteDiffuseLight965;
			float smoothstepResult525 = smoothstep( _HalftoneEdgeOffset , ( _HalftoneEdgeOffset + _HalftoneSmoothness ) , max( max( break3_g199.x , break3_g199.y ) , break3_g199.z ));
			float4 unityObjectToClipPos2_g198 = UnityObjectToClipPos( ase_vertex3Pos );
			float4 computeScreenPos3_g198 = ComputeScreenPos( unityObjectToClipPos2_g198 );
			float temp_output_29_0_g198 = ( _OverlayUVTilling / 4.0 );
			float4 unityObjectToClipPos13_g198 = UnityObjectToClipPos( float3(0,0,0) );
			float4 computeScreenPos17_g198 = ComputeScreenPos( unityObjectToClipPos13_g198 );
			float4 transform20_g198 = mul(unity_ObjectToWorld,float4( 0,0,0,1 ));
			float4 break22_g198 = ( ( ( ( computeScreenPos3_g198 / (computeScreenPos3_g198).w ) * temp_output_29_0_g198 ) - ( temp_output_29_0_g198 * ( computeScreenPos17_g198 / (computeScreenPos17_g198).w ) ) ) * distance( ( float4( _WorldSpaceCameraPos , 0.0 ) - transform20_g198 ) , float4( 0,0,0,0 ) ) );
			float4 break26_g198 = _ScreenParams;
			float4 appendResult24_g198 = (float4(( break22_g198.x * ( break26_g198.x / break26_g198.y ) ) , break22_g198.y , break22_g198.z , break22_g198.w));
			float2 appendResult1849 = (float2(( _OverlayUVTilling * ( _ScreenParams.x / _ScreenParams.y ) ) , _OverlayUVTilling));
			float mulTime1278 = _Time.y * _UVAnimationSpeed;
			float temp_output_1281_0 = ( floor( ( mulTime1278 % 2.0 ) ) * 0.5 );
			#if defined(_OVERLAYMODE_NONE)
				float staticSwitch1277 = 0.0;
			#elif defined(_OVERLAYMODE_HAFTONE)
				float staticSwitch1277 = temp_output_1281_0;
			#elif defined(_OVERLAYMODE_HATCHING)
				float staticSwitch1277 = temp_output_1281_0;
			#else
				float staticSwitch1277 = 0.0;
			#endif
			float2 appendResult1803 = (float2(staticSwitch1277 , staticSwitch1277));
			float mulTime1287 = _Time.y * _UVScrollSpeed;
			float temp_output_1293_0 = radians( _UVSrcrollAngle );
			float2 appendResult1294 = (float2(cos( temp_output_1293_0 ) , sin( temp_output_1293_0 )));
			float2 temp_output_1288_0 = ( mulTime1287 * appendResult1294 );
			float2 temp_cast_18 = (_OverlayUVTilling).xx;
			float2 uv_TexCoord478 = i.uv_texcoord * temp_cast_18 + temp_output_1288_0;
			float cos1047 = cos( radians( _OverlayRotation ) );
			float sin1047 = sin( radians( _OverlayRotation ) );
			float2 rotator1047 = mul( ( _UseScreenUvs == 1.0 ? ( ( _UseAdaptiveScreenUvs == 1.0 ? appendResult24_g198 : ( float4( appendResult1849, 0.0 , 0.0 ) * ase_grabScreenPosNorm ) ) + float4( appendResult1803, 0.0 , 0.0 ) + float4( temp_output_1288_0, 0.0 , 0.0 ) ) : float4( uv_TexCoord478, 0.0 , 0.0 ) ).xy - float2( 0.5,0.5 ) , float2x2( cos1047 , -sin1047 , sin1047 , cos1047 )) + float2( 0.5,0.5 );
			float2 OverlayUVs1051 = rotator1047;
			float smoothstepResult1045 = smoothstep( ( ( _ShapeSmoothness * -0.5 ) + 0.5 ) , ( ( _ShapeSmoothness * 0.5 ) + 0.5 ) , ( 0.1 / ( ( _HalftoneThreshold / smoothstepResult525 ) * (0.0 + (tex2D( _HalftoneTexture, OverlayUVs1051 ).r - 0.0) * (1.0 - 0.0) / (1.0 - 0.0)) ) ));
			float4 lerpResult1774 = lerp( lerpResult1784 , temp_output_1225_0 , smoothstepResult1045);
			float4 Halftone1022 = ( lerpResult1774 + IndirectDiffuseLight1269 );
			#if defined(_OVERLAYMODE_NONE)
				float4 staticSwitch1231 = BNFinalDiffuse239;
			#elif defined(_OVERLAYMODE_HAFTONE)
				float4 staticSwitch1231 = Halftone1022;
			#elif defined(_OVERLAYMODE_HATCHING)
				float4 staticSwitch1231 = BNFinalDiffuse239;
			#else
				float4 staticSwitch1231 = BNFinalDiffuse239;
			#endif
			float3 normalizeResult222 = normalize( _WorldSpaceLightPos0.xyz );
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 normalizeResult238 = normalize( ( normalizeResult222 + ase_worldViewDir ) );
			float3 BNHalfDirection265 = normalizeResult238;
			float dotResult252 = dot( BNHalfDirection265 , BNCurrentNormal1538 );
			float Smoothness638 = ( tex2D( _SpecGlossMap, uv_OcclusionMap ).r * _Glossiness );
			float IN1578 = ( pow( max( dotResult252 , 0.0 ) , ( exp2( ( ( Smoothness638 * 10.0 * ( 2.0 - _SmoothnessMultiplier ) ) + -2.0 ) ) * 2.0 ) ) * ( _SmoothnessMultiplier == 0.0 ? 0.0 : 1.0 ) );
			float SpecFaloff1578 = _SpecularFaloff;
			float Steps1578 = round( _SpecularPosterizeSteps );
			float localFaloffPosterize1578 = FaloffPosterize( IN1578 , SpecFaloff1578 , Steps1578 );
			float mulTime1811 = _Time.y * _UVScrollSpeedSpec;
			float temp_output_1807_0 = radians( _UVSrcrollAngleSpec );
			float2 appendResult1808 = (float2(cos( temp_output_1807_0 ) , sin( temp_output_1807_0 )));
			float mulTime1814 = _Time.y * _UVAnimationSpeedSpec;
			float temp_output_1817_0 = ( floor( ( mulTime1814 % 2.0 ) ) * 0.5 );
			#if defined(_OVERLAYMODE1_NONE)
				float staticSwitch1812 = 0.0;
			#elif defined(_OVERLAYMODE1_HAFTONE)
				float staticSwitch1812 = temp_output_1817_0;
			#elif defined(_OVERLAYMODE1_HATCHING)
				float staticSwitch1812 = temp_output_1817_0;
			#else
				float staticSwitch1812 = 0.0;
			#endif
			float2 appendResult1818 = (float2(staticSwitch1812 , staticSwitch1812));
			float4 unityObjectToClipPos2_g192 = UnityObjectToClipPos( ase_vertex3Pos );
			float4 computeScreenPos3_g192 = ComputeScreenPos( unityObjectToClipPos2_g192 );
			float temp_output_29_0_g192 = ( _SpecularMaskScale / 4.0 );
			float4 unityObjectToClipPos13_g192 = UnityObjectToClipPos( float3(0,0,0) );
			float4 computeScreenPos17_g192 = ComputeScreenPos( unityObjectToClipPos13_g192 );
			float4 transform20_g192 = mul(unity_ObjectToWorld,float4( 0,0,0,1 ));
			float4 break22_g192 = ( ( ( ( computeScreenPos3_g192 / (computeScreenPos3_g192).w ) * temp_output_29_0_g192 ) - ( temp_output_29_0_g192 * ( computeScreenPos17_g192 / (computeScreenPos17_g192).w ) ) ) * distance( ( float4( _WorldSpaceCameraPos , 0.0 ) - transform20_g192 ) , float4( 0,0,0,0 ) ) );
			float4 break26_g192 = _ScreenParams;
			float4 appendResult24_g192 = (float4(( break22_g192.x * ( break26_g192.x / break26_g192.y ) ) , break22_g192.y , break22_g192.z , break22_g192.w));
			float2 appendResult1842 = (float2(( _SpecularMaskScale * ( _ScreenParams.x / _ScreenParams.y ) ) , _SpecularMaskScale));
			float2 temp_cast_26 = (_SpecularMaskScale).xx;
			float2 uv_TexCoord1123 = i.uv_texcoord * temp_cast_26;
			float cos1124 = cos( radians( _SpecularMaskRotation ) );
			float sin1124 = sin( radians( _SpecularMaskRotation ) );
			float2 rotator1124 = mul( ( _UseScreenUvsSpecular == 1.0 ? ( float4( ( mulTime1811 * appendResult1808 ), 0.0 , 0.0 ) + float4( appendResult1818, 0.0 , 0.0 ) + ( _UseAdaptiveUvsSpecular == 1.0 ? appendResult24_g192 : ( float4( appendResult1842, 0.0 , 0.0 ) * ase_grabScreenPosNorm ) ) ) : float4( uv_TexCoord1123, 0.0 , 0.0 ) ).xy - float2( 0.5,0.5 ) , float2x2( cos1124 , -sin1124 , sin1124 , cos1124 )) + float2( 0.5,0.5 );
			float2 SpecularUVs1125 = rotator1124;
			float4 tex2DNode441 = tex2D( _SpecularMaskTexture, SpecularUVs1125 );
			float temp_output_1634_0 = ( 1.0 - _HaltonePatternSize );
			float smoothstepResult1557 = smoothstep( ( temp_output_1634_0 - 0.3 ) , temp_output_1634_0 , tex2DNode441.r);
			float lerpResult446 = lerp( 1.0 , (( _StepHalftoneTexture )?( smoothstepResult1557 ):( tex2DNode441.r )) , _SpecularMaskStrength);
			float SpecularMask902 = ( _UseSpecularMask == 1.0 ? ( _InverseMask == 1.0 ? ( 1.0 - lerpResult446 ) : lerpResult446 ) : 1.0 );
			float4 SpecularColor1388 = _SpecColor;
			#ifdef _USESPECULAR_ON
				float4 staticSwitch627 = ( float4( ( ase_lightColor.rgb * _MainLightIntesity * localFaloffPosterize1578 ) , 0.0 ) * SpecularMask902 * Smoothness638 * SpecularColor1388 );
			#else
				float4 staticSwitch627 = float4( 0,0,0,0 );
			#endif
			float4 BNspecularFinalColor243 = staticSwitch627;
			float4 lerpResult1216 = lerp( _HalftoneColor , lerpResult1462 , smoothstepResult1045);
			float4 HalftoneDiffuseShadowMask1236 = lerpResult1216;
			#if defined(_OVERLAYMODE_NONE)
				float4 staticSwitch1237 = BNDiffuse391;
			#elif defined(_OVERLAYMODE_HAFTONE)
				float4 staticSwitch1237 = HalftoneDiffuseShadowMask1236;
			#elif defined(_OVERLAYMODE_HATCHING)
				float4 staticSwitch1237 = BNDiffuse391;
			#else
				float4 staticSwitch1237 = BNDiffuse391;
			#endif
			float grayscale1797 = dot(staticSwitch1237.rgb, float3(0.299,0.587,0.114));
			float lerpResult695 = lerp( 1.0 , grayscale1797 , _SpecularShadowMask);
			float3 indirectNormal618 = BNCurrentNormal1538;
			Unity_GlossyEnvironmentData g618 = UnityGlossyEnvironmentSetup( Smoothness638, data.worldViewDir, indirectNormal618, float3(0,0,0));
			float3 indirectSpecular618 = UnityGI_IndirectSpecular( data, 0.75, indirectNormal618, g618 );
			float3 IndirectSpecular1364 = ( _UseEnvironmentRefletion == 1.0 ? ( indirectSpecular618 * _Strength * Smoothness638 ) : float3( 0,0,0 ) );
			float4 BNBlinnPhongLightning274 = ( staticSwitch1231 + ( BNspecularFinalColor243 * lerpResult695 ) + float4( IndirectSpecular1364 , 0.0 ) );
			float grayscale1648 = Luminance(BNDiffuseNoAdditionalLights1554.rgb);
			float4 lerpResult1650 = lerp( _RimShadowColor , _RimColor , saturate( grayscale1648 ));
			float4 RimColor1642 = ( ( _RimSplitColor == 0.0 ? _RimColor : float4( 0,0,0,0 ) ) + ( _RimSplitColor == 1.0 ? ( _RimColor * BNDiffuseNoAdditionalLights1554 ) : float4( 0,0,0,0 ) ) + ( _RimSplitColor == 2.0 ? lerpResult1650 : float4( 0,0,0,0 ) ) );
			float fresnelNdotV454 = dot( normalize( BNCurrentNormal1538 ), ase_worldViewDir );
			float fresnelNode454 = ( 0.0 + _RimThickness * pow( max( 1.0 - fresnelNdotV454 , 0.0001 ), _RimPower ) );
			float smoothstepResult462 = smoothstep( ( ( 1.0 - _RimSmoothness ) - 0.5 ) , 0.5 , fresnelNode454);
			float FresnelValue738 = smoothstepResult462;
			float dotResult704 = dot( ase_worldViewDir , _WorldSpaceLightPos0.xyz );
			float smoothstepResult726 = smoothstep( _BacklightHardness , 0.5 , saturate( ( 1.0 - ( dotResult704 - ( ( _BacklightAmount * 2.0 ) + -2.0 ) ) ) ));
			float dotResult749 = dot( BNCurrentNormal1538 , _WorldSpaceLightPos0.xyz );
			float temp_output_766_0 = ( 1.0 - ( _SideShineAmount - -0.3 ) );
			float dotResult745 = dot( ( ase_worldViewDir * -1.0 ) , _WorldSpaceLightPos0.xyz );
			float clampResult753 = clamp( ( ( ( dotResult749 - temp_output_766_0 ) * 4.0 ) + ( dotResult745 - temp_output_766_0 ) ) , 0.0 , 1.1 );
			float smoothstepResult759 = smoothstep( _SideShineHardness , 0.5 , ( clampResult753 * FresnelValue738 ));
			#ifdef _USERIMLIGHT_ON
				float staticSwitch464 = ( _UseBacklight == 1.0 ? ( ( _BacklightIntensity * ( FresnelValue738 * smoothstepResult726 ) ) + ( _SideShineIntensity * smoothstepResult759 ) ) : FresnelValue738 );
			#else
				float staticSwitch464 = 0.0;
			#endif
			float RimLight460 = staticSwitch464;
			float4 lerpResult1635 = lerp( BNBlinnPhongLightning274 , RimColor1642 , RimLight460);
			float4 Emission680 = ( _UseEmission == 1.0 ? ( tex2D( _EmissionMap, uv_OcclusionMap ) * _EmissionColor ) : float4( 0,0,0,0 ) );
			float4 temp_output_282_0 = ( lerpResult1635 + Emission680 );
			float3 IndirectHatching1466 = lerpResult692;
			float3 lerpResult1468 = lerp( float3( 0,0,0 ) , IndirectHatching1466 , _IndirectLightAffectOnHatch);
			float4 temp_output_1270_0 = ( _HatchingColor + float4( lerpResult1468 , 0.0 ) );
			float2 appendResult1907 = (float2(( _PaperTilling * ( _ScreenParams.x / _ScreenParams.y ) ) , _PaperTilling));
			float4 tex2DNode1795 = tex2D( _PaperTexture, ( ase_grabScreenPosNorm * float4( appendResult1907, 0.0 , 0.0 ) ).xy );
			float2 _uv476 = OverlayUVs1051;
			float3 break3_g200 = ( RimLight460 + BNDiffuse391 + Emission680 + BNspecularFinalColor243 ).rgb;
			float temp_output_1064_0 = (( _Darken * -2.0 ) + (max( max( break3_g200.x , break3_g200.y ) , break3_g200.z ) - 0.0) * (( ( _Lighten * 2.0 ) + 1.0 ) - ( _Darken * -2.0 )) / (1.0 - 0.0));
			float color476 = temp_output_1064_0;
			sampler2D _Hatch0476 = _Hatch1;
			sampler2D _Hatch1476 = _Hatch2;
			float3 localHatching476 = Hatching476( _uv476 , color476 , _Hatch0476 , _Hatch1476 );
			float2 _uv491 = OverlayUVs1051;
			float _intensity491 = temp_output_1064_0;
			sampler2D _Hatch0491 = _Hatch1;
			sampler2D _Hatch1491 = _Hatch2;
			float _dist491 = distance( _WorldSpaceCameraPos , ase_worldPos );
			float _MaxScaleDependingOnCamera491 = _MaxScaleDependingOnCamera;
			float3 localHatchingConstantScale491 = HatchingConstantScale491( _uv491 , _intensity491 , _Hatch0491 , _Hatch1491 , _dist491 , _MaxScaleDependingOnCamera491 );
			#ifdef _USEHATCHINGCONSTANTSCALE_ON
				float3 staticSwitch490 = localHatchingConstantScale491;
			#else
				float3 staticSwitch490 = localHatching476;
			#endif
			float3 Hatching1025 = saturate( staticSwitch490 );
			float4 lerpResult1254 = lerp( temp_output_1270_0 , tex2DNode1795 , Hatching1025.x);
			float4 lerpResult1257 = lerp( lerpResult1254 , tex2DNode1795 , ( 1.0 - _HatchingColor.a ));
			float4 lerpResult1264 = lerp( BNBlinnPhongLightning274 , temp_output_1270_0 , _HatchingColor.a);
			float4 lerpResult1260 = lerp( lerpResult1264 , BNBlinnPhongLightning274 , Hatching1025.x);
			float4 lerpResult1637 = lerp( ( _UsePureSketch == 1.0 ? lerpResult1257 : lerpResult1260 ) , RimColor1642 , RimLight460);
			#if defined(_OVERLAYMODE_NONE)
				float4 staticSwitch1024 = temp_output_282_0;
			#elif defined(_OVERLAYMODE_HAFTONE)
				float4 staticSwitch1024 = temp_output_282_0;
			#elif defined(_OVERLAYMODE_HATCHING)
				float4 staticSwitch1024 = ( lerpResult1637 + Emission680 );
			#else
				float4 staticSwitch1024 = temp_output_282_0;
			#endif
			c.rgb = staticSwitch1024.rgb;
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
			o.Normal = float3(0,0,1);
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf StandardCustomLighting keepalpha fullforwardshadows novertexlights nolightmap  nodynlightmap nodirlightmap noforwardadd vertex:vertexDataFunc 

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
				float4 screenPos : TEXCOORD2;
				float4 tSpace0 : TEXCOORD3;
				float4 tSpace1 : TEXCOORD4;
				float4 tSpace2 : TEXCOORD5;
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
				vertexDataFunc( v, customInputData );
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				half3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				o.screenPos = ComputeScreenPos( o.pos );
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
				float3 worldPos = float3( IN.tSpace0.w, IN.tSpace1.w, IN.tSpace2.w );
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldPos = worldPos;
				surfIN.worldNormal = float3( IN.tSpace0.z, IN.tSpace1.z, IN.tSpace2.z );
				surfIN.internalSurfaceTtoW0 = IN.tSpace0.xyz;
				surfIN.internalSurfaceTtoW1 = IN.tSpace1.xyz;
				surfIN.internalSurfaceTtoW2 = IN.tSpace2.xyz;
				surfIN.screenPos = IN.screenPos;
				SurfaceOutputCustomLightingCustom o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputCustomLightingCustom, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "StylizedToonEditor"
}
/*ASEBEGIN
Version=18935
489;73;2210;770;1929.118;45.0567;1;True;False
Node;AmplifyShaderEditor.CommentaryNode;277;-8712.34,-525.5221;Inherit;False;6331.035;6906.721;;13;217;1122;386;901;390;213;385;215;216;219;1840;1844;381;BlinnPhong;0.2631274,0.6002151,0.6886792,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;385;-8330.623,247.4478;Inherit;False;3259.512;999.9587;Comment;35;1861;1862;1668;250;384;382;378;379;375;1489;1492;1488;1495;1530;1496;1522;1531;1770;1527;1520;1523;1521;1847;1519;1524;1528;1846;1518;1526;1517;1525;1845;1529;1864;1863;Diffuse Warp;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;1529;-8325.402,1066.9;Inherit;False;Property;_UVAnimationSpeedWarp;UV Animation Speed;67;0;Create;False;0;0;0;True;0;False;2;0;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenParams;1844;-8523.726,567.7627;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;1517;-8318.326,807.0174;Inherit;False;Property;_UVSrcrollAngleWarp;UV Scroll Angle;72;0;Create;False;0;0;0;True;0;False;0;0;0;360;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;381;-8522.25,352.5942;Inherit;False;Property;_WarpTextureScale;UV Tiling;21;0;Create;False;0;0;0;True;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;1525;-8071.518,988.6365;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;1845;-8315.826,515.3929;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleRemainderNode;1526;-7888.918,948.2334;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.RadiansOpNode;1518;-8034.326,760.0173;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1846;-8186.045,468.7613;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;1521;-7904.324,830.0174;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CosOpNode;1519;-7891.323,732.0173;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FloorOpNode;1528;-7736.118,1016.636;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GrabScreenPosition;1794;-8135.249,146.5622;Inherit;False;0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;1847;-8008.751,364.2129;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;1524;-8121.289,640.8343;Inherit;False;Property;_UVScrollSpeedWarp;UV Scroll Speed;73;0;Create;False;0;0;0;True;0;False;0;0;0;0.1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1527;-7610.118,930.2394;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1668;-7738.178,286.131;Inherit;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;1520;-7760.322,759.0173;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.FunctionNode;1770;-7852.129,530.5059;Inherit;False;StaticScreenSpaceUV;-1;;188;1e9a29825d5b8df43882e5bd6744aaf5;0;1;7;FLOAT;1;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleTimeNode;1523;-7779.966,654.9861;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1861;-7800.59,419.5882;Inherit;False;Property;_UseAdaptiveScreenUvsWarp;Adaptive Screen Uvs;101;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;1531;-7426.273,869.2283;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;678;4046.568,1056.732;Inherit;False;1482.025;1686.722;Comment;28;636;659;686;679;685;658;680;638;682;677;364;204;362;1388;1376;1536;1537;1538;1539;1540;1541;1651;1652;1653;1655;1656;1669;1853;Inputs;1,1,1,1;0;0
Node;AmplifyShaderEditor.Compare;1862;-7485.005,467.2332;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT4;0,0,0,0;False;3;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1522;-7574.865,687.3629;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;1,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;1495;-7512.629,290.8127;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;1122;-4211.215,2740.08;Inherit;False;1770.555;1368.74;;33;1819;1818;1817;1816;1815;1814;1813;1812;1811;1810;1809;1808;1807;1806;1805;1804;1127;699;1126;1125;1124;1129;1769;1123;439;1793;1841;1842;1843;1881;1882;1883;1884;Specular UVs;1,1,1,1;0;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;1669;4112.486,1319.13;Inherit;False;0;1651;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;1496;-6260.965,729.7656;Inherit;False;Property;_WarpTextureRotation;UV Rotation;43;0;Create;False;0;0;0;True;0;False;0;83.96;0;180;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1530;-7067.619,513.6799;Inherit;False;3;3;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;1864;-6948.564,336.5879;Inherit;False;Property;_UseScreenUvsWarp;Screen Uvs;97;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;1492;-6368.533,368.41;Inherit;False;Constant;_Vector1;Vector 1;87;0;Create;True;0;0;0;False;0;False;0.5,0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.RadiansOpNode;1488;-6075.328,548.1746;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1813;-4128.089,3965.44;Inherit;False;Property;_UVAnimationSpeedSpec;UV Animation Speed;68;0;Create;False;0;0;0;True;0;False;2;0;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;1863;-6768.186,425.0685;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT4;0,0,0,0;False;3;FLOAT2;0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SamplerNode;1541;4409.913,2321.428;Inherit;True;Property;_BumpMap;Normal Map;28;1;[Normal];Create;False;0;0;0;True;0;False;-1;None;None;True;0;False;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector3Node;1540;4467.77,2549.595;Inherit;False;Constant;_Vector0;Vector 0;44;0;Create;True;0;0;0;False;0;False;0,0,1;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;1539;4757.33,2605.09;Inherit;False;Property;_NormalMapStrength;Normal Map Strength;29;0;Create;False;0;0;0;True;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RotatorNode;1489;-6120.499,322.4047;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.LerpOp;1536;4749.836,2378.906;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleTimeNode;1814;-3844.112,3935.601;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenParams;1840;-4305.743,2869.182;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleDivideOpNode;1843;-4122.894,2865.705;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1805;-4106.067,3764.866;Inherit;False;Property;_UVSrcrollAngleSpec;UV Scroll Angle;70;0;Create;False;0;0;0;True;0;False;0;0;0;360;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;439;-4256.596,2768.043;Inherit;False;Property;_SpecularMaskScale;Specular Mask Tiling;20;0;Create;False;0;0;0;True;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;375;-5906.418,466.2107;Inherit;True;Property;_DiffuseWarpNoise;Diffuse Warp Noise;16;2;[NoScaleOffset];[SingleLineTexture];Create;False;0;0;0;True;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;379;-5790.439,748.9904;Inherit;False;Property;_WarpStrength;Warp Strength;19;0;Create;True;0;0;0;True;0;False;0;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldNormalVector;1537;4904.502,2354.028;Inherit;False;True;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleRemainderNode;1815;-3582.948,3950.22;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;382;-5759.325,303.0701;Inherit;False;Property;_UseDiffuseWarp;UseDiffuse Warp;22;1;[Toggle];Create;True;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;216;-7674.659,-456.1669;Inherit;False;698.8475;398.5884;;4;1542;269;233;234;NDotL;1,1,1,1;0;0
Node;AmplifyShaderEditor.RadiansOpNode;1807;-3822.068,3717.866;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FloorOpNode;1816;-3340.528,3950.625;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1841;-3993.975,2831.581;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;378;-5551.19,588.2382;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1538;5102.502,2358.028;Float;False;BNCurrentNormal;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SinOpNode;1804;-3692.068,3787.866;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1809;-4133.39,3539.387;Inherit;False;Property;_UVScrollSpeedSpec;UV Scroll Speed;75;0;Create;False;0;0;0;True;0;False;0;0;0;0.1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1542;-7620.824,-410.0771;Inherit;False;1538;BNCurrentNormal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.CosOpNode;1806;-3679.068,3689.866;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GrabScreenPosition;1793;-4170.065,3041.778;Inherit;False;0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;1842;-3998.975,2944.581;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Compare;384;-5512.855,347.5926;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldSpaceLightDirHlpNode;269;-7603.765,-271.4286;Inherit;False;False;1;0;FLOAT;0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1817;-3208.149,3948.227;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;250;-5361.033,449.8615;Float;False;BNLightWarpVector;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;1769;-4001.408,3255.393;Inherit;False;StaticScreenSpaceUV;-1;;192;1e9a29825d5b8df43882e5bd6744aaf5;0;1;7;FLOAT;1;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RangedFloatNode;1881;-3742.962,3309.924;Inherit;False;Property;_UseAdaptiveUvsSpecular;Use Adaptive Uvs;102;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;386;-8655.438,1520.64;Inherit;False;4310.062;1258.77;;71;1451;372;361;1360;1331;1416;1504;391;1554;267;1276;370;1355;1087;1188;1418;248;262;1356;1502;264;965;260;1501;240;251;356;1505;223;1417;358;1329;1508;360;371;1362;359;1359;389;1500;1274;249;444;1357;1358;1330;445;1599;1600;1604;1605;1509;1611;1485;1483;1511;1486;1510;1617;1618;1619;1622;1623;1625;1626;1628;1629;1680;1875;1876;1878;Main Light Diffuse Mode;1,1,1,1;0;0
Node;AmplifyShaderEditor.StaticSwitch;1812;-3070.148,3900.931;Inherit;False;Property;_OverlayMode1;Overlay Mode;58;0;Create;False;0;0;0;True;0;False;0;0;0;True;;KeywordEnum;3;None;Haftone;Hatching;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;1811;-3872.134,3594.207;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DotProductOpNode;234;-7372.499,-393.5273;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1129;-3867.509,3027.999;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.DynamicAppendNode;1808;-3548.068,3716.866;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DynamicAppendNode;1818;-3083.187,3722.536;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;233;-7228.498,-377.5273;Float;False;BNNDotL;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1810;-3639.134,3539.329;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;1,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.CommentaryNode;1054;-1902.29,5289.873;Inherit;False;2863.306;1438.541;;34;1294;1282;486;1296;1293;1047;1051;1295;1292;1050;1049;1287;1279;1277;1288;1278;1285;1280;1297;1281;1056;1048;478;1792;1803;1848;1849;1850;1851;1771;1869;1870;1871;1872;Overlay UVs;1,1,1,1;0;0
Node;AmplifyShaderEditor.GetLocalVarNode;249;-8572.477,2017.969;Inherit;False;250;BNLightWarpVector;1;0;OBJECT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;219;-8680.826,-457.1807;Inherit;False;836.8075;393.9034;;5;1415;244;1860;1859;1858;Light Attenuation;1,1,1,1;0;0
Node;AmplifyShaderEditor.Compare;1882;-3451.617,3319.402;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT4;0,0,0,0;False;3;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.OneMinusNode;248;-8406.031,1899.421;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LightColorNode;1858;-8598.13,-380.8138;Inherit;False;0;3;COLOR;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;699;-3273.75,3083.975;Inherit;False;Property;_SpecularMaskRotation;Specular Mask Rotation;44;0;Create;True;0;0;0;True;0;False;0;83.96;0;180;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;1123;-3823.614,2790.08;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;1883;-3708.962,2913.924;Inherit;False;Property;_UseScreenUvsSpecular;Screen Uvs;104;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;223;-8221.254,2079.614;Inherit;False;233;BNNDotL;1;0;OBJECT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1285;-1585.346,6593.262;Inherit;False;Property;_UVAnimationSpeed;UV Animation Speed;69;0;Create;False;0;0;0;True;0;False;2;0;0;5;0;1;FLOAT;0
Node;AmplifyShaderEditor.LightAttenuation;1859;-8620.813,-210.3642;Inherit;False;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1819;-3019.408,3402.603;Inherit;False;3;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;251;-8237.035,1902.421;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;389;-8423.692,1747.842;Inherit;False;250;BNLightWarpVector;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;217;-6702.856,-372.6217;Inherit;False;977.2441;332.3028;;6;265;238;237;236;226;222;Half Dir;1,1,1,1;0;0
Node;AmplifyShaderEditor.Vector2Node;1126;-3204.857,2807.199;Inherit;False;Constant;_Vector5;Vector 5;87;0;Create;True;0;0;0;False;0;False;0.5,0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleTimeNode;1278;-1301.369,6563.423;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;1884;-3425.617,2826.402;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT4;0,0,0,0;False;3;FLOAT2;0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RadiansOpNode;1127;-3067.735,2952.401;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1860;-8355.775,-322.2192;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ScreenParams;1848;-1677.488,6216.65;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;659;4465.257,1336.172;Inherit;False;Property;_Glossiness;Smoothness;36;0;Create;False;0;0;0;True;0;False;0.5;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;267;-8110.707,1770.583;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;465;1929.844,-1197.134;Inherit;False;4163.613;1551.363;;64;1885;731;739;1886;758;464;760;755;764;1650;753;738;456;467;757;719;1648;737;745;726;462;741;704;702;1644;454;749;721;744;466;1647;715;537;763;759;718;712;458;457;463;747;1645;708;748;705;751;716;767;742;766;762;743;756;460;765;727;1642;740;1887;1888;1890;1891;1892;1893;Rim;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;1292;-1869.355,5909.286;Inherit;False;Property;_UVSrcrollAngle;UV Scroll Angle;71;0;Create;False;0;0;0;True;0;False;0;0;0;360;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;264;-8019.342,1914.061;Float;False;Constant;_Vector3;Vector 3;0;0;Create;True;0;0;0;False;0;False;0,0,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldSpaceLightPos;226;-6682.226,-301.5596;Inherit;False;0;3;FLOAT4;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.SamplerNode;636;4370.918,1121.404;Inherit;True;Property;_SpecGlossMap;Specular Map;35;2;[NoScaleOffset];[SingleLineTexture];Create;False;0;0;0;True;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RotatorNode;1124;-3031.854,2753.968;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleRemainderNode;1279;-1040.204,6578.042;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;244;-8114.042,-324.4052;Float;False;BNAttenuationColor;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;1056;-1521.488,5473.074;Inherit;False;Property;_OverlayUVTilling;UV Tiling;62;0;Create;False;0;0;0;True;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;901;-4308.089,1916.059;Inherit;False;1917.12;636.1124;;15;440;1561;1631;1213;1632;1634;902;1557;446;437;441;438;1682;1879;1880;Main Specular Mask;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;1851;-1442.199,6233.839;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FloorOpNode;1280;-797.7849,6578.447;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1850;-1313.679,6172.145;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;765;2634.804,-141.1844;Inherit;False;Property;_SideShineAmount;Side Shine Amount;48;0;Create;True;0;0;0;True;0;False;0.2717647;0;0;0.7;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;215;-8584.659,3077.576;Inherit;False;3808.721;1802.809;;37;627;220;1397;903;1403;618;256;619;651;1102;623;1404;660;207;243;1099;650;252;1400;1100;254;653;652;406;401;1096;583;649;644;588;661;1364;246;665;1578;1873;1874;Main Specular ;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;1631;-4203.31,2248.858;Inherit;False;Property;_HaltonePatternSize;Halftone Pattern Size;86;0;Create;False;0;0;0;True;0;False;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;240;-7812.167,1908.289;Inherit;False;244;BNAttenuationColor;1;0;OBJECT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RadiansOpNode;1293;-1585.356,5862.286;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1125;-2773.395,2832.979;Inherit;False;SpecularUVs;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;658;4690.962,1209.571;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NormalizeNode;222;-6426.227,-324.5595;Inherit;False;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMaxOpNode;262;-7896.342,1750.062;Inherit;False;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;236;-6627.761,-203.267;Float;False;World;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.CosOpNode;1295;-1442.356,5834.286;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldSpaceLightPos;741;2550.072,148.2723;Inherit;False;0;3;FLOAT4;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;370;-7185.927,2449.221;Inherit;False;Property;_StepOffset;Step Offset;13;0;Create;False;0;0;0;True;0;False;0;0;-0.5;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;463;1981.84,-883.8204;Inherit;False;Property;_RimSmoothness;Rim Smoothness;27;0;Create;True;0;0;0;True;0;False;0;0;0;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1415;-8167.138,-169.0329;Inherit;False;ShadowAtten;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1096;-8379.98,4746.146;Inherit;False;Property;_SmoothnessMultiplier;Main Specular Size;65;0;Create;False;0;0;0;True;0;False;1;0;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;1634;-3893.671,2248.036;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;638;4843.67,1228.993;Inherit;False;Smoothness;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;748;2564.278,-341.9847;Inherit;False;1538;BNCurrentNormal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;237;-6250.227,-285.5595;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;260;-7709.142,1771.562;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;1358;-6849.964,2240.591;Inherit;False;Property;_DiffusePosterizeOffset;Posterize Offset;78;0;Create;False;0;0;0;True;0;False;0;0;-0.5;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1281;-665.4057,6576.049;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;743;2446.363,39.48164;Inherit;False;Constant;_Float2;Float 2;62;0;Create;True;0;0;0;False;0;False;-1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1213;-4175.321,2011.506;Inherit;False;1125;SpecularUVs;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;1297;-1896.678,5683.807;Inherit;False;Property;_UVScrollSpeed;UV Scroll Speed;74;0;Create;False;0;0;0;True;0;False;0;0;0;0.1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;1296;-1455.356,5932.286;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GrabScreenPosition;1792;-806.4965,6054.647;Inherit;False;0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;708;1978.553,-379.9398;Inherit;False;Property;_BacklightAmount;Backlight Amount;45;0;Create;True;0;0;0;True;0;False;0.5;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;1849;-1163.503,6129.529;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;744;2388.713,-134.051;Inherit;False;World;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleSubtractOpNode;767;2936.088,-115.182;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;-0.3;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;1504;-8336.877,2427.897;Float;False;Constant;_Vector2;Vector 2;0;0;Create;True;0;0;0;False;0;False;0,0,0;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.StaticSwitch;1277;-527.4038,6528.753;Inherit;False;Property;_OverlayMode;Overlay Mode;60;0;Create;False;0;0;0;True;0;False;0;0;0;True;;KeywordEnum;3;None;Haftone;Hatching;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;371;-7003.382,2291.36;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1362;-6558.23,2224.656;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;-1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;651;-8317.708,4583.742;Float;False;Constant;_Float0;Float 0;0;0;Create;True;0;0;0;False;0;False;10;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1869;-523.8606,5773.047;Inherit;False;Property;_UseAdaptiveScreenUvs;Adaptive Screen Uvs;103;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;466;2327.196,-937.5477;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;742;2640.12,-5.970623;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;457;1964.917,-978.377;Inherit;False;Property;_RimPower;Rim Power;26;0;Create;True;0;0;0;True;0;False;12;1;1;12;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;486;-722.9409,5786.95;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.FunctionNode;1771;-782.7629,5614.481;Inherit;False;StaticScreenSpaceUV;-1;;198;1e9a29825d5b8df43882e5bd6744aaf5;0;1;7;FLOAT;1;False;1;FLOAT4;0
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;712;2110.792,-575.6523;Inherit;False;World;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.OneMinusNode;766;3061.088,-86.18204;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;721;2289.527,-363.3533;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;1294;-1311.356,5861.286;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;660;-8362.398,4452.416;Inherit;False;638;Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;1632;-3725.131,2329.295;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0.3;False;1;FLOAT;0
Node;AmplifyShaderEditor.NormalizeNode;238;-6122.227,-285.5595;Inherit;False;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;458;1972.339,-1071.988;Inherit;False;Property;_RimThickness;Rim Thickness;25;0;Create;True;0;0;0;True;0;False;1;1;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;441;-3840.463,2031.383;Inherit;True;Property;_SpecularMaskTexture;Specular Mask Texture;17;2;[NoScaleOffset];[SingleLineTexture];Create;True;0;0;0;True;0;False;-1;None;0c021cea0cf2417459ce7fa844118e17;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.FunctionNode;1188;-7375.836,1841.717;Inherit;False;MaxFromVector3;-1;;197;92f2539b674dd3042b132cfbdf18809e;0;1;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1502;-8367.388,2314.624;Inherit;False;233;BNNDotL;1;0;OBJECT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;537;2016.563,-1156.313;Inherit;False;1538;BNCurrentNormal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;359;-7462.312,1586.428;Inherit;False;Property;_LightRampOffset;Light Ramp Offset;8;0;Create;True;0;0;0;True;0;False;0;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;1102;-8093.716,4685.461;Inherit;False;2;0;FLOAT;2;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;1287;-1635.422,5738.627;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldSpaceLightPos;702;2055.073,-694.4506;Inherit;False;0;3;FLOAT4;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.DotProductOpNode;749;2842.648,-342.8691;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1416;-6459.888,2377.936;Inherit;False;1415;ShadowAtten;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1509;-6463.818,2617.044;Inherit;False;Property;_DiffuseWarpBrightnessOffset;Brightness Offset;84;0;Create;False;0;0;0;True;0;False;1.12;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;1870;-275.4827,5681.527;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT4;0,0,0,0;False;3;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMaxOpNode;1501;-8159.562,2330.285;Inherit;False;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1505;-8113.792,2445.615;Inherit;False;244;BNAttenuationColor;1;0;OBJECT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;445;-6943.111,2173.795;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0.009;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;467;2511.075,-998.298;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;1511;-6226.568,2570.127;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;763;3096.804,-206.1844;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;1803;-300.9299,6434.197;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.DotProductOpNode;704;2361.643,-646.1813;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1357;-6642.462,1926.19;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;653;-8080.706,4529.741;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DotProductOpNode;745;2835.455,39.24284;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;649;-7904.706,4662.741;Float;False;Constant;_Float1;Float 1;0;0;Create;True;0;0;0;False;0;False;-2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1417;-7754.294,2041.835;Inherit;False;1415;ShadowAtten;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;360;-7155.594,1636.903;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1288;-1402.422,5683.75;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT2;1,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;265;-5962.227,-285.5595;Float;False;BNHalfDirection;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.FresnelNode;454;2264.045,-1147.134;Inherit;False;Standard;WorldNormal;ViewDir;True;True;5;0;FLOAT3;0,0,1;False;4;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;5;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1508;-7986.188,2534.964;Inherit;False;1415;ShadowAtten;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;1557;-3571.099,2214.36;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0.6;False;2;FLOAT;0.97;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;719;2427.832,-383.2604;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;-2;False;1;FLOAT;0
Node;AmplifyShaderEditor.ToggleSwitchNode;1561;-3368.183,2096.343;Inherit;False;Property;_StepHalftoneTexture;Step Halftone Texture;85;0;Create;False;0;0;0;False;0;False;0;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;705;2551.253,-643.7584;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;-0.6;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1050;291.1501,5830.959;Inherit;False;Property;_OverlayRotation;UV Rotation;61;0;Create;False;0;0;0;True;0;False;0;0;0;180;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;254;-8253.023,4259.813;Inherit;False;265;BNHalfDirection;1;0;OBJECT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;1329;-6810.17,2362.941;Inherit;False;Property;_DiffusePosterizeSteps;Posterize Steps;76;0;Create;False;0;0;0;True;0;False;3;1;1;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;256;-8267.27,4348.813;Inherit;False;1538;BNCurrentNormal;1;0;OBJECT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1418;-7513.909,1994.875;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1282;-5.742126,5650.596;Inherit;False;3;3;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1500;-7797.34,2328.851;Inherit;False;3;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;1356;-6496.462,2134.391;Inherit;False;Property;_DiffusePosterizePower;Posterize Power;77;0;Create;False;0;0;0;True;0;False;1;0.5;0.5;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;764;3184.804,10.81565;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;440;-3290.488,2295.681;Inherit;False;Property;_SpecularMaskStrength;Specular Mask Strength;18;0;Create;True;0;0;0;True;0;False;0.1856417;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;751;3227.877,-270.3091;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;4;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1276;-7033.281,1816.061;Inherit;False;Constant;_Float4;Float 4;101;0;Create;True;0;0;0;False;0;False;0.98;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;650;-7770.713,4551.741;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;1359;-6473.462,1940.491;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1274;-7037.281,1738.061;Inherit;False;Constant;_Float3;Float 3;101;0;Create;True;0;0;0;False;0;False;0.01;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1878;-7708.791,2503.815;Inherit;False;Property;_DiffuseWarpAffectHalftone;Diffuse Warp Affects Halftone;93;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1871;-270.4992,5376.887;Inherit;False;Property;_UseScreenUvs;Screen Uvs;96;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1510;-6057.315,2638.59;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;-1;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;444;-6758.538,2083.357;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.5;False;2;FLOAT;0.495;False;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;462;2739.44,-1098.938;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.5;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;478;-575.89,5461.309;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;1483;-6203.97,2482.501;Inherit;False;250;BNLightWarpVector;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;356;-7020.02,1622.714;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PowerNode;1355;-6330.462,1931.391;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;747;3348.573,-157.7353;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;1877;-7472.445,2521.293;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;446;-3118.994,2126.112;Inherit;False;3;0;FLOAT;1;False;1;FLOAT;1;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RoundOpNode;1330;-6322.955,2222.411;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DotProductOpNode;252;-8005.683,4285.147;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;1360;-6065.672,1969.796;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RadiansOpNode;1049;574.3894,5747.171;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1485;-5934.949,2442.394;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Exp2OpNode;652;-7621.713,4556.741;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;1872;50.87872,5388.367;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT4;0,0,0,0;False;3;FLOAT2;0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.Vector2Node;1048;336.9011,5559.368;Inherit;False;Constant;_Vector0;Vector 0;87;0;Create;True;0;0;0;False;0;False;0.5,0.5;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.ClampOpNode;358;-6847.237,1691.888;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0.02,0.02;False;2;FLOAT2;0.98,0.98;False;1;FLOAT2;0
Node;AmplifyShaderEditor.OneMinusNode;715;2671.969,-779.5223;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;738;2926.143,-1084.267;Inherit;False;FresnelValue;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;361;-6612.557,1660.076;Inherit;True;Property;_LightRampTexture;Light Ramp Texture;10;2;[NoScaleOffset];[SingleLineTexture];Create;False;0;0;0;True;1;;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;716;2915.675,-697.3837;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1880;-3040.966,2377.349;Inherit;False;Property;_InverseMask;Inverse Mask;92;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;965;-7175.173,2060.798;Inherit;False;CompleteDiffuseLight;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;1451;-5641.219,1756.577;Inherit;False;Property;_ShadowColor;Shadow Color;81;0;Create;True;0;0;0;False;0;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;1682;-2942.101,2277.643;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1876;-5908.735,2277.054;Inherit;False;Property;_UseDiffuseWarpAsOverlay;Impact Shadows;94;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.CustomExpressionNode;1331;-6098.767,2092.703;Inherit;False;return  floor(In / (1 / Steps)) * (1 / Steps)@;1;Create;2;True;In;FLOAT;0;In;;Inherit;False;True;Steps;FLOAT;0;In;;Inherit;False;Posterize;True;False;0;;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;740;3671.523,104.1912;Inherit;False;738;FresnelValue;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;665;-7728.504,4410.999;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;1021;-2125.395,3937.868;Inherit;False;4020.123;1130.029;;36;1022;1216;1226;1225;1222;1220;1217;1042;1186;1045;508;1055;531;1041;1040;1046;1043;529;528;525;527;966;526;516;517;1236;1351;1462;1463;1465;1552;1774;1782;1783;1784;1785;Halftone;1,1,1,1;0;0
Node;AmplifyShaderEditor.Vector2Node;1623;-6054.545,1579.347;Inherit;False;Constant;_Vector7;Vector 7;127;0;Create;True;0;0;0;False;0;False;0.02,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.ClampOpNode;753;3547.876,-139.309;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1.1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMaxOpNode;246;-7856.275,4321.813;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;1625;-5706.054,2072.304;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;727;2754.032,-566.5176;Inherit;False;Property;_BacklightHardness;Backlight Hardness;12;0;Create;False;0;0;0;True;0;False;0;0;0;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;1486;-5767.511,2450.541;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LightColorNode;1618;-6118.529,1798.979;Inherit;False;0;3;COLOR;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.RotatorNode;1047;564.2337,5501.925;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Compare;1875;-5608.389,2255.532;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;1099;-7647.492,4687.706;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1680;-5853.912,1735.709;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1051;745.745,5489.999;Inherit;False;OverlayUVs;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;583;-7692.615,4133.14;Inherit;False;Property;_SpecularPosterizeSteps;Specular Posterize Steps;30;0;Create;True;0;0;0;True;0;False;15;0;0;15;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;527;-1896.652,4150.719;Inherit;False;Property;_HalftoneSmoothness;Halftone Smoothness;50;0;Create;True;0;0;0;True;0;False;0.3;0;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1619;-5453.472,1878.97;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;760;3774.884,200.6781;Inherit;False;Property;_SideShineHardness;Side Shine Hardness;11;0;Create;False;0;0;0;True;0;False;0;0;0;0.5;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;762;3982.941,-137.5395;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;966;-1960.685,4319.157;Inherit;False;965;CompleteDiffuseLight;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;1651;4420.51,1616.544;Inherit;True;Property;_OcclusionMap;Occlusion Map;88;0;Create;False;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Compare;1879;-2856.621,2108.827;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1622;-5804.497,1548.024;Inherit;True;Property;_LightRampTexture;Light Ramp Texture;12;2;[NoScaleOffset];[SingleLineTexture];Fetch;True;0;0;0;True;1;;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;726;3096.47,-678.4979;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.5;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1652;4491.939,1859.249;Inherit;False;Property;_OcclusionStrength;Occlusion Strength ;89;0;Create;True;0;0;0;True;0;False;1;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;401;-7575.165,4361.064;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1629;-5486.158,2078.652;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;438;-2944.745,1963.174;Inherit;False;Property;_UseSpecularMask;UseSpecular Mask;23;1;[Toggle];Create;True;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;526;-1905.652,4017.719;Inherit;False;Property;_HalftoneEdgeOffset;Halftone Edge Offset;51;0;Create;True;0;0;0;True;0;False;0.1;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1055;-1893.832,4672.492;Inherit;False;1051;OverlayUVs;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;528;-1577.557,4141.469;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;756;3179.259,-1078.435;Inherit;False;Property;_BacklightIntensity;Backlight Intensity;46;0;Create;True;0;0;0;True;0;False;1;0;0;4;0;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;759;4137.022,-156.3022;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0.5;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.RoundOpNode;588;-7357.685,4093.289;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;758;3323.754,-650.0638;Inherit;False;Property;_SideShineIntensity;Side Shine Intensity;47;0;Create;False;0;0;0;True;0;False;1;0;0;4;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;1376;5049.063,1127.798;Inherit;False;Property;_SpecColor;Specular Value;2;0;Fetch;False;0;0;0;True;0;False;1,1,1,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;755;3274.64,-821.2211;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;1186;-1652.068,4326.253;Inherit;False;MaxFromVector3;-1;;199;92f2539b674dd3042b132cfbdf18809e;0;1;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1628;-5238.33,1951.119;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;1655;4769.01,1684.568;Inherit;False;3;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;437;-2681.937,2015.409;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0;False;3;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1626;-5192.144,1747.387;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;1617;-5316.11,1619.201;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;207;-7644.859,3923.38;Inherit;False;Property;_SpecularFaloff;Specular Falloff;7;0;Create;False;0;0;0;True;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1100;-7355.603,4369.429;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;1656;4920.472,1780.187;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;1;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SamplerNode;508;-1663.055,4511.406;Inherit;True;Property;_HalftoneTexture;Halftone Texture;49;2;[NoScaleOffset];[SingleLineTexture];Create;True;0;0;0;True;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;718;3408.772,-978.8892;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CustomExpressionNode;1578;-6974.729,4082.329;Inherit;False;float minOut = 0.5 * SpecFaloff - 0.005@$float faloff = lerp(IN, smoothstep(minOut, 0.5, IN), SpecFaloff)@$if(Steps < 1)${$    return faloff@$}$else${$    return  floor(faloff / (1 / Steps)) * (1 / Steps)@$};1;Create;3;True;IN;FLOAT;0;In;;Inherit;False;True;SpecFaloff;FLOAT;0;In;;Inherit;False;True;Steps;FLOAT;0;In;;Inherit;False;FaloffPosterize;False;False;0;;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;902;-2568.28,2123.094;Inherit;False;SpecularMask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1388;5293.175,1180.653;Inherit;False;SpecularColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;529;-1485.198,3987.868;Inherit;False;Property;_HalftoneThreshold;Halftone Threshold;52;0;Create;True;0;0;0;True;0;False;0.1;0;0;0.15;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;362;4392.602,1430.464;Inherit;True;Property;_MainTex;Albedo Texture;9;0;Create;False;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;204;4959.695,1361.061;Inherit;False;Property;_Color;Color;6;0;Create;True;0;0;0;True;0;False;0.6792453,0.6792453,0.6792453,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;525;-1331.651,4143.719;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.LightColorNode;406;-6883.214,3783.191;Inherit;False;0;3;COLOR;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.RangedFloatNode;1404;-7095.287,3923.465;Inherit;False;Property;_MainLightIntesity;Main Light Intensity;79;0;Create;False;0;0;0;True;0;False;1;0;0;6;0;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;372;-4920.076,1746.524;Inherit;False;Property;_UseLightRamp;Shading Mode;14;0;Create;False;0;0;0;False;0;False;0;0;0;True;;KeywordEnum;3;Step;DiffuseRamp;Posterize;Create;True;True;All;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;757;3629.055,-732.8724;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1403;-5940.299,4124.008;Inherit;False;1388;SpecularColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;1046;-1192.901,4756.875;Inherit;False;Property;_ShapeSmoothness;Transition Smoothness;59;0;Create;False;0;0;0;True;0;False;0.2;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1554;-4617.162,1576.96;Inherit;False;BNDiffuseNoAdditionalLights;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TFHCRemapNode;1351;-1215.085,4456.954;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;517;-1111.825,4154.599;Inherit;False;2;0;FLOAT;0.1;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1400;-6724.9,3999.852;Inherit;False;3;3;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;679;4449.447,2133.176;Inherit;False;Property;_EmissionColor;Emission Color;37;1;[HDR];Create;True;0;0;0;True;0;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;1397;-5918.479,3999.763;Inherit;False;638;Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;731;3620.948,-1021.249;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;739;3771.293,-878.424;Inherit;False;738;FresnelValue;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1885;3542.862,-1133.882;Inherit;False;Property;_UseBacklight;Rim As Backlight & Side Shine;99;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1653;5029.258,1659.177;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT4;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;903;-5920.318,3897.118;Inherit;False;902;SpecularMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;682;4339.97,1938.008;Inherit;True;Property;_EmissionMap;Emission Map;39;3;[HDR];[NoScaleOffset];[SingleLineTexture];Create;True;0;0;0;True;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;390;-4258.111,704.8892;Inherit;False;1678.375;818.0153;;14;229;263;1269;692;642;392;1221;691;276;581;239;1266;1363;1466;Final Diffuse;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1041;-901.267,4597.95;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;-0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;1886;3928.24,-1126.402;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LightColorNode;1552;-130.8536,4085.332;Inherit;False;0;3;COLOR;0;FLOAT3;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1042;-858.3162,4772.233;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;581;-4000.692,1309.903;Inherit;False;1538;BNCurrentNormal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;364;5173.106,1548.681;Inherit;False;MainTexture;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;1220;-167.0386,4251.784;Inherit;False;1554;BNDiffuseNoAdditionalLights;1;0;OBJECT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;691;-3773.227,1400.115;Inherit;False;Property;_IndirectLightStrength;Indirect Light Strength;41;0;Create;True;0;0;0;True;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1463;-135.3279,4354.897;Inherit;False;Property;_HalftoneToonAffect;Toon Affect;82;0;Create;False;0;0;0;True;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;220;-5667.165,3850.343;Inherit;False;4;4;0;FLOAT3;1,1,1;False;1;FLOAT;0;False;2;FLOAT;0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;686;4815.713,2055.44;Inherit;False;Property;_UseEmission;UseEmission;40;0;Create;True;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;677;4759.825,2144.773;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;516;-944.1041,4275.447;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;685;4994.712,2161.44;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1040;-750.9719,4545.909;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1087;-4620.137,1909.086;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;1222;1002.009,4471.209;Inherit;False;364;MainTexture;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;627;-5397.655,3468.239;Inherit;False;Property;_UseSpecular;UseSpecular Highlights;1;0;Create;False;0;0;0;True;0;False;0;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.IndirectDiffuseLighting;276;-3764.335,1268.758;Inherit;False;World;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;464;4169.449,-1133.427;Inherit;False;Property;_UseRimLight;UseRim Light;0;0;Create;True;0;0;0;True;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;531;-692.3922,4255.171;Inherit;False;2;0;FLOAT;0.1;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1462;189.6721,4240.897;Inherit;False;3;0;COLOR;1,1,1,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1043;-686.53,4736.025;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1221;-3451.219,1360.915;Inherit;False;IndirectLightStrength;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;692;-3272.457,1181.337;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;243;-5374.557,3251.352;Float;False;BNspecularFinalColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1225;1240.809,4227.327;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;642;-4138.578,1020.884;Inherit;False;364;MainTexture;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;391;-4532.718,1697.535;Inherit;False;BNDiffuse;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;1217;195.3033,3989.512;Inherit;False;Property;_HalftoneColor;Halftone Color;53;0;Create;False;0;0;0;True;0;False;0,0,0,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SmoothstepOpNode;1045;-528.6564,4392.913;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;460;4430.621,-1116.154;Inherit;False;RimLight;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;680;5183.368,2165.13;Inherit;False;Emission;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;504;-1231.827,2662.274;Inherit;False;2567.819;1176.527;;24;1053;1069;1111;490;1066;482;503;476;491;1025;275;498;1121;1070;1120;1119;499;492;1067;1064;481;1187;1265;1460;Hatching;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;1066;-833.6616,3457.859;Inherit;False;Property;_Lighten;Lighten;64;0;Create;True;0;0;0;True;0;False;0;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;275;-1111.678,3213.279;Inherit;False;391;BNDiffuse;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;392;-4132.12,745.6323;Inherit;False;391;BNDiffuse;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;1120;-1094.37,3297.967;Inherit;False;680;Emission;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.WireNode;1782;657.3998,4829.287;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1216;449.0906,4356.392;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;1,1,1,0;False;2;FLOAT;1;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1363;-3200.625,1032.195;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT3;0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;1119;-1104.016,3120.498;Inherit;False;460;RimLight;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1784;710.4785,4041.085;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;1460;-1116.915,3396.036;Inherit;False;243;BNspecularFinalColor;1;0;OBJECT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;644;-6807.174,4391.738;Inherit;False;638;Smoothness;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1236;710.7438,4623.02;Inherit;False;HalftoneDiffuseShadowMask;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;619;-6540.359,4276.888;Inherit;False;1538;BNCurrentNormal;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1111;-531.7548,3459.94;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1121;-888.1926,3179.232;Inherit;False;4;4;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;1266;-3901.295,784.0469;Inherit;False;Property;_OverlayMode;Overlay Mode;78;0;Create;False;0;0;0;True;0;False;0;0;0;True;;KeywordEnum;3;None;Haftone;Hatching;Create;True;True;All;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1269;-2978.034,1065.561;Inherit;False;IndirectDiffuseLight;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;1067;-738.7885,3294.18;Inherit;False;Property;_Darken;Darken;63;0;Create;True;0;0;0;True;0;False;0;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;1785;1323.461,4148.079;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.WireNode;1783;1290.393,4529.448;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;213;-4675.104,-420.4454;Inherit;False;1762.018;982.026;;14;1231;274;696;694;270;695;259;693;271;1232;1237;1238;1366;1797;Diffuse + Specular;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;229;-3574.793,815.2498;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.WorldPosInputsNode;499;27.23447,3650.849;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.LerpOp;1774;1421.503,4196.536;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;1,1,1,0;False;2;FLOAT;1;False;1;COLOR;0
Node;AmplifyShaderEditor.IndirectSpecularLight;618;-6298.829,4300.885;Inherit;False;World;3;0;FLOAT3;0,0,1;False;1;FLOAT;1;False;2;FLOAT;0.75;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;693;-4625.304,-155.1281;Inherit;False;391;BNDiffuse;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;64;-1880.329,-664.5828;Inherit;False;2502.139;1100.715;;38;1857;62;1855;1856;53;50;58;52;604;591;599;596;593;602;592;598;600;54;55;56;59;601;51;60;590;1421;1449;1448;44;1854;1866;1865;1895;1894;1896;1898;1899;1904;Outline;1,1,1,1;0;0
Node;AmplifyShaderEditor.RangedFloatNode;623;-6447.313,4490.784;Inherit;False;Property;_Strength;Strength;34;0;Create;False;0;0;0;True;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldSpaceCameraPos;492;-51.96087,3477.878;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.FunctionNode;1187;-522.6708,2888.304;Inherit;False;MaxFromVector3;-1;;200;92f2539b674dd3042b132cfbdf18809e;0;1;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1465;1395.81,4634.543;Inherit;False;1269;IndirectDiffuseLight;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1069;-430.3678,3304.905;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;-2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1070;-397.0568,3424.875;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1238;-4659.746,-28.08583;Inherit;False;1236;HalftoneDiffuseShadowMask;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;1874;-5837.855,4505.054;Inherit;False;Property;_UseEnvironmentRefletion;Environment Reflection;95;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;599;-1846.061,-483.5386;Inherit;False;Property;_OutlineDynamicSpeed;Outline Dynamic Speed;33;0;Create;False;0;0;0;True;0;False;0;0;0;0.05;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;263;-3059.157,798.1735;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TexturePropertyNode;481;-1162.693,2719.027;Inherit;True;Property;_Hatch1;Hatch Texture Darker;55;1;[NoScaleOffset];Create;False;0;0;0;True;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.StaticSwitch;1237;-4398.406,-124.581;Inherit;False;Property;_OverlayMode;Overlay Mode;72;0;Create;False;0;0;0;False;0;False;0;0;0;True;;KeywordEnum;3;None;Haftone;Hatching;Create;True;True;All;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;661;-5968.442,4336.711;Inherit;False;3;3;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.DistanceOpNode;498;231.7297,3488.59;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;503;266.9348,3647.713;Inherit;False;Property;_MaxScaleDependingOnCamera;Max Scale Depends On Camera;56;0;Create;False;0;0;0;True;0;False;1;10;1;10;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1053;-386.7587,2738.988;Inherit;False;1051;OverlayUVs;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1226;1649.362,4335.563;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.TexturePropertyNode;482;-1164.286,2900.07;Inherit;True;Property;_Hatch2;Hatch Texture Brighter;54;1;[NoScaleOffset];Create;False;0;0;0;True;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.TFHCRemapNode;1064;-264.4967,3186.024;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TimeNode;598;-1837.066,-625.2249;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;1022;1694.836,4696.063;Inherit;False;Halftone;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.CustomExpressionNode;476;-70.58769,2752.779;Inherit;False;float intensity = color@$$    float3 hatch0 = tex2D(_Hatch0, _uv).rgb@$    float3 hatch1 = tex2D(_Hatch1, _uv).rgb@$$    float3 overbright = max(0, intensity - 1.0)@$$    float3 weightsA = saturate((intensity * 6.0) + float3(-0, -1, -2))@$    float3 weightsB = saturate((intensity * 6.0) + float3(-3, -4, -5))@$$    weightsA.xy -= weightsA.yz@$    weightsA.z -= weightsB.x@$    weightsB.xy -= weightsB.yz@$$    hatch0 = hatch0 * weightsA@$    hatch1 = hatch1 * weightsB@$$    float3 hatching = overbright + hatch0.r +$        hatch0.g + hatch0.b +$        hatch1.r + hatch1.g +$        hatch1.b@$$    return hatching@$    return hatching@;3;Create;4;False;_uv;FLOAT2;0,0;In;;Inherit;False;True;color;FLOAT;0;In;;Inherit;False;False;_Hatch0;SAMPLER2D;;In;;Inherit;False;False;_Hatch1;SAMPLER2D;;In;;Inherit;False;Hatching;True;False;0;;False;4;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;SAMPLER2D;;False;3;SAMPLER2D;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TFHCGrayscale;1797;-4153.83,-58.39511;Inherit;False;1;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;696;-4517.71,204.9207;Inherit;False;Property;_SpecularShadowMask;Specular Shadow Mask;42;0;Create;True;0;0;0;True;0;False;0;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;1461;-2166.924,1205.188;Inherit;False;1696.135;1222.97;;23;1790;1556;1249;1637;1555;1270;1469;1264;1026;1260;1468;1467;1256;1253;1254;1257;1789;1791;1795;1868;1867;1907;1908;Hatching Implementation;1,1,1,1;0;0
Node;AmplifyShaderEditor.Compare;1873;-5516.477,4516.534;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.CustomExpressionNode;491;20.92586,3114.201;Inherit;False;	float log2_dist = log2(_dist)-0.2@$	$	float2 floored_log_dist = floor( (log2_dist + float2(0.0, 1.0) ) * 0.5) *2.0 - float2(0.0, 1.0)@				$	float2 uv_scale = min(_MaxScaleDependingOnCamera, pow(2.0, floored_log_dist))@$	$	float uv_blend = abs(frac(log2_dist * 0.5) * 2.0 - 1.0)@$	$	float2 scaledUVA = _uv / uv_scale.x@ // 16$	float2 scaledUVB = _uv / uv_scale.y@ // 8 $$	float3 hatch0A = tex2D(_Hatch0, scaledUVA).rgb@$	float3 hatch1A = tex2D(_Hatch1, scaledUVA).rgb@$$	float3 hatch0B = tex2D(_Hatch0, scaledUVB).rgb@$	float3 hatch1B = tex2D(_Hatch1, scaledUVB).rgb@$$	float3 hatch0 = lerp(hatch0A, hatch0B, uv_blend)@$	float3 hatch1 = lerp(hatch1A, hatch1B, uv_blend)@$$	float3 overbright = max(0, _intensity - 1.0)@$$	float3 weightsA = saturate((_intensity * 6.0) + float3(-0, -1, -2))@$	float3 weightsB = saturate((_intensity * 6.0) + float3(-3, -4, -5))@$$	weightsA.xy -= weightsA.yz@$	weightsA.z -= weightsB.x@$	weightsB.xy -= weightsB.yz@$$	hatch0 = hatch0 * weightsA@$	hatch1 = hatch1 * weightsB@$$	float3 hatching = overbright + hatch0.r +$		hatch0.g + hatch0.b +$		hatch1.r + hatch1.g +$		hatch1.b@$$	return hatching@;3;Create;6;False;_uv;FLOAT2;0,0;In;;Inherit;False;False;_intensity;FLOAT;0;In;;Inherit;False;False;_Hatch0;SAMPLER2D;;In;;Inherit;False;False;_Hatch1;SAMPLER2D;;In;;Inherit;False;False;_dist;FLOAT;0;In;;Inherit;False;True;_MaxScaleDependingOnCamera;FLOAT;0;In;;Inherit;False;HatchingConstantScale;True;False;0;;False;6;0;FLOAT2;0,0;False;1;FLOAT;0;False;2;SAMPLER2D;;False;3;SAMPLER2D;;False;4;FLOAT;0;False;5;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ScreenParams;1905;-2021.625,2428.988;Inherit;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;239;-2802.317,769.5178;Float;True;BNFinalDiffuse;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;600;-1471.603,-589.2416;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1644;4329.731,-459.4672;Inherit;False;1554;BNDiffuseNoAdditionalLights;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1364;-5272.993,4391.16;Inherit;False;IndirectSpecular;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;1790;-1957.797,2315.442;Inherit;False;Property;_PaperTilling;Paper Tiling;90;0;Create;False;0;0;0;True;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;602;-1381.9,-463.5548;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;271;-4628.169,-376.4447;Inherit;False;239;BNFinalDiffuse;1;0;OBJECT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;1232;-4575.157,-275.6162;Inherit;False;1022;Halftone;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;1906;-1813.726,2376.618;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;270;-4165.508,-150.3121;Inherit;False;243;BNspecularFinalColor;1;0;OBJECT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;695;-3958.377,7.337563;Inherit;False;3;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;490;286.8386,2856.942;Inherit;False;Property;_UseHatchingConstantScale;Hatch Constant Scale;57;0;Create;False;0;0;0;True;0;False;0;1;1;True;;Toggle;2;Key0;Key1;Create;True;True;All;9;1;FLOAT3;0,0,0;False;0;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT3;0,0,0;False;5;FLOAT3;0,0,0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StaticSwitch;1231;-4198.647,-370.1738;Inherit;False;Property;_OverlayMode;Overlay Mode;77;0;Create;False;0;0;0;False;0;False;0;0;0;True;;KeywordEnum;3;None;Haftone;Hatching;Create;True;True;All;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.WireNode;601;-1733.868,-394.9604;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1366;-3538.575,-113.5741;Inherit;False;1364;IndirectSpecular;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;694;-3814.204,-108.875;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1466;-3047.77,1230.248;Inherit;False;IndirectHatching;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;1265;690.8874,2906.83;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1908;-1685.944,2302.986;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCGrayscale;1648;4529.153,-292.9815;Inherit;False;0;1;0;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TexCoordVertexDataNode;54;-1347.329,279.5605;Inherit;False;3;3;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GrabScreenPosition;1791;-2104.128,2123.934;Inherit;False;0;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PosVertexDataNode;53;-1795.237,98.6328;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;1907;-1534.65,2276.438;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.NormalVertexDataNode;52;-1647.069,-42.54811;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;1469;-2124.462,1991.161;Inherit;False;Property;_IndirectLightAffectOnHatch;Indirect Light Affect On Hatch;83;0;Create;False;0;0;0;True;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;1895;-1428.226,70.50305;Inherit;False;Property;_OutlineType;Outline Type;106;1;[Enum];Create;False;0;3;Normal;0;Position;1;UVBaked;2;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;593;-1634.274,-261.8212;Inherit;False;Property;_OutlineNoiseScale;Outline Noise Scale;31;0;Create;False;0;0;0;True;0;False;10;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1467;-2134.365,1863.206;Inherit;False;1466;IndirectHatching;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;1893;4744.46,-260.8463;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;259;-3353.517,-351.2742;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT3;0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;1645;4602.21,-135.7343;Inherit;False;Property;_RimShadowColor;Rim Shadow Color;87;0;Create;False;0;0;0;True;0;False;0,0.05551431,0.9622642,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;591;-1659.262,-377.5762;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;456;4385.484,-675.5858;Inherit;False;Property;_RimColor;Rim Color;24;1;[HDR];Create;True;0;0;0;True;0;False;1,1,1,0;1,1,1,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;1025;797.5136,2761.415;Inherit;False;Hatching;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;1650;4908.153,-321.9814;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1789;-1616.797,2100.442;Inherit;False;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT2;0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.Compare;1898;-1063.917,269.5001;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;2;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;1468;-1880.071,1840.766;Inherit;False;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.Compare;1896;-1071.226,117.5031;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;596;-1602.23,-175.0701;Inherit;False;Property;_OutlineNoiseIntesity;Outline Noise Intensity;32;0;Create;False;0;0;0;True;0;False;1;0;0;2;0;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;1894;-1094.226,-40.49695;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1647;4823.118,-562.4415;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;1026;-1958.094,1282.58;Inherit;False;1025;Hatching;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;590;-1405.021,-286.5762;Inherit;False;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;15.43;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;274;-3140.385,-357.7659;Inherit;False;BNBlinnPhongLightning;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;1253;-2070.124,1585.938;Inherit;False;Property;_HatchingColor;Hatching Color;66;0;Create;False;0;0;0;True;0;False;0,0,0,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;1887;4957.883,-815.8681;Inherit;False;Property;_RimSplitColor;Rim Split Color;105;1;[Enum];Create;False;0;3;No Split;0;Multiply with diffuse;1;Use second color;2;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1899;-860.917,123.5001;Inherit;False;3;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.BreakToComponentsNode;1555;-1762.134,1299.336;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.Compare;1888;5236.947,-730.1644;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Compare;1891;5262.947,-367.1644;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;2;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;530;-1778.019,976.3893;Inherit;False;274;BNBlinnPhongLightning;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;1795;-1430.905,1976.788;Inherit;True;Property;_PaperTexture;Paper Texture;91;1;[NoScaleOffset];Create;True;0;0;0;True;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;1270;-1801.1,1520.373;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT3;0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Compare;1890;5269.871,-539.054;Inherit;False;0;4;0;FLOAT;2;False;1;FLOAT;1;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;592;-1183.824,-221.6968;Inherit;False;2;2;0;FLOAT;1;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WireNode;1556;-1463.134,1409.336;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1264;-1482.546,1247.387;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;1,1,1,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;1254;-1553.623,1562.387;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;1,1,1,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.OneMinusNode;1256;-1518.766,1779.329;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldSpaceCameraPos;50;-1180.349,-615.5602;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;1865;-832.7467,-138.1006;Inherit;False;Property;_UseDynamicOutline;Dynamic Outline;100;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;604;-1024.31,-177.6753;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.WorldPosInputsNode;51;-1108.915,-468.6635;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleAddOpNode;1892;5517.947,-660.1644;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.DistanceOpNode;55;-929.3464,-498.2828;Inherit;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1853;4740.912,1469.644;Inherit;False;AlbedoTexture;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Compare;1866;-677.5688,34.08008;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;56;-1013.993,-297.0202;Inherit;False;Property;_AdaptiveThicnkess;Adaptive Thickness;4;0;Create;False;0;0;0;True;0;False;0;0.32;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;58;-365.5645,122.1464;Inherit;False;Property;_Thicnkess;Thickness;3;0;Create;False;0;0;0;True;0;False;0;0;0;0.1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1260;-1209.246,1245.788;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;1,1,1,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;1867;-1227.932,1487.442;Inherit;False;Property;_UsePureSketch;Pure Sketch;98;1;[Toggle];Create;False;0;0;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;1257;-1332.921,1677.669;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;1,1,1,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;1642;5693.605,-848.9111;Inherit;False;RimColor;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.WireNode;1636;-1215.137,709.5232;Inherit;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;461;-1063.669,1038.62;Inherit;False;460;RimLight;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1854;-251.089,-426.0198;Inherit;False;1853;AlbedoTexture;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;60;-315.4184,-45.43956;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.GetLocalVarNode;1643;-1137.734,830.2725;Inherit;False;1642;RimColor;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;59;-713.4068,-332.0495;Inherit;False;3;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.Compare;1868;-935.5541,1515.922;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;1449;-289.8379,-312.5108;Inherit;False;Property;_OutlineTextureStrength;Texture Strength ;80;0;Create;False;0;0;0;True;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;681;-773.323,1053.889;Inherit;False;680;Emission;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;44;36.07047,-600.1439;Inherit;False;Property;_OutlineColor;Outline Color;5;1;[HDR];Create;True;0;0;0;True;0;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;1637;-878.1372,1225.523;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;1448;55.33743,-402.0483;Inherit;False;3;0;COLOR;1,1,1,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;1635;-822.1129,860.0081;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;1856;-135.6351,-178.0221;Inherit;False;Property;_UseOutline;UseOutline;38;1;[Toggle];Create;False;0;0;0;True;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;62;-263.6328,-210.3605;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;1249;-688.2852,1269.027;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.CommentaryNode;387;5213.25,700.6266;Inherit;False;338;166;;1;373;Editor Properties;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleAddOpNode;282;-462.3608,867.2823;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.Compare;1855;40.62575,-90.38217;Inherit;False;0;4;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1421;262.5797,-231.3484;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;1600;-4935.629,2686.68;Inherit;False;250;BNLightWarpVector;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;1605;-4745.212,2537.469;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;1604;-4908.307,2566.073;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;1024;-150.8171,970.0305;Inherit;False;Property;_OverlayMode;Overlay Mode;78;0;Create;True;0;0;0;False;0;False;0;0;0;True;;KeywordEnum;3;None;Haftone;Hatching;Create;True;True;All;9;1;COLOR;0,0,0,0;False;0;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;4;COLOR;0,0,0,0;False;5;COLOR;0,0,0,0;False;6;COLOR;0,0,0,0;False;7;COLOR;0,0,0,0;False;8;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StepOpNode;737;3976.326,15.11785;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StickyNoteNode;1904;-1537.553,297.2654;Inherit;False;150;100;New Note;;1,1,1,1;you need to fix manually the convering error;0;0
Node;AmplifyShaderEditor.OutlineNode;1857;430.0396,-60.68168;Inherit;False;2;True;None;0;0;Front;True;True;True;True;0;False;-1;3;0;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;1611;-4620.763,2489.308;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;1599;-5111.077,2598.644;Inherit;False;1415;ShadowAtten;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;373;5263.25,750.6266;Inherit;False;Property;_RampDiffuseTextureLoaded;RampDiffuseTextureLoaded;15;1;[HideInInspector];Create;True;0;0;0;True;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;1852;798.8829,674.6481;Float;False;True;-1;2;StylizedToonEditor;0;0;CustomLighting;Stylized Toon;False;False;False;False;False;True;True;True;True;False;False;True;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;1525;0;1529;0
WireConnection;1845;0;1844;1
WireConnection;1845;1;1844;2
WireConnection;1526;0;1525;0
WireConnection;1518;0;1517;0
WireConnection;1846;0;381;0
WireConnection;1846;1;1845;0
WireConnection;1521;0;1518;0
WireConnection;1519;0;1518;0
WireConnection;1528;0;1526;0
WireConnection;1847;0;1846;0
WireConnection;1847;1;381;0
WireConnection;1527;0;1528;0
WireConnection;1668;0;1794;0
WireConnection;1668;1;1847;0
WireConnection;1520;0;1519;0
WireConnection;1520;1;1521;0
WireConnection;1770;7;381;0
WireConnection;1523;0;1524;0
WireConnection;1531;0;1527;0
WireConnection;1531;1;1527;0
WireConnection;1862;0;1861;0
WireConnection;1862;2;1770;0
WireConnection;1862;3;1668;0
WireConnection;1522;0;1523;0
WireConnection;1522;1;1520;0
WireConnection;1495;0;381;0
WireConnection;1495;1;1522;0
WireConnection;1530;0;1862;0
WireConnection;1530;1;1531;0
WireConnection;1530;2;1522;0
WireConnection;1488;0;1496;0
WireConnection;1863;0;1864;0
WireConnection;1863;2;1530;0
WireConnection;1863;3;1495;0
WireConnection;1541;1;1669;0
WireConnection;1489;0;1863;0
WireConnection;1489;1;1492;0
WireConnection;1489;2;1488;0
WireConnection;1536;0;1540;0
WireConnection;1536;1;1541;0
WireConnection;1536;2;1539;0
WireConnection;1814;0;1813;0
WireConnection;1843;0;1840;1
WireConnection;1843;1;1840;2
WireConnection;375;1;1489;0
WireConnection;1537;0;1536;0
WireConnection;1815;0;1814;0
WireConnection;1807;0;1805;0
WireConnection;1816;0;1815;0
WireConnection;1841;0;439;0
WireConnection;1841;1;1843;0
WireConnection;378;0;375;1
WireConnection;378;1;379;0
WireConnection;1538;0;1537;0
WireConnection;1804;0;1807;0
WireConnection;1806;0;1807;0
WireConnection;1842;0;1841;0
WireConnection;1842;1;439;0
WireConnection;384;0;382;0
WireConnection;384;2;378;0
WireConnection;1817;0;1816;0
WireConnection;250;0;384;0
WireConnection;1769;7;439;0
WireConnection;1812;0;1817;0
WireConnection;1812;2;1817;0
WireConnection;1811;0;1809;0
WireConnection;234;0;1542;0
WireConnection;234;1;269;0
WireConnection;1129;0;1842;0
WireConnection;1129;1;1793;0
WireConnection;1808;0;1806;0
WireConnection;1808;1;1804;0
WireConnection;1818;0;1812;0
WireConnection;1818;1;1812;0
WireConnection;233;0;234;0
WireConnection;1810;0;1811;0
WireConnection;1810;1;1808;0
WireConnection;1882;0;1881;0
WireConnection;1882;2;1769;0
WireConnection;1882;3;1129;0
WireConnection;248;0;249;0
WireConnection;1123;0;439;0
WireConnection;1819;0;1810;0
WireConnection;1819;1;1818;0
WireConnection;1819;2;1882;0
WireConnection;251;0;248;0
WireConnection;251;1;223;0
WireConnection;1278;0;1285;0
WireConnection;1884;0;1883;0
WireConnection;1884;2;1819;0
WireConnection;1884;3;1123;0
WireConnection;1127;0;699;0
WireConnection;1860;0;1858;1
WireConnection;1860;1;1859;0
WireConnection;267;0;389;0
WireConnection;267;1;251;0
WireConnection;636;1;1669;0
WireConnection;1124;0;1884;0
WireConnection;1124;1;1126;0
WireConnection;1124;2;1127;0
WireConnection;1279;0;1278;0
WireConnection;244;0;1860;0
WireConnection;1851;0;1848;1
WireConnection;1851;1;1848;2
WireConnection;1280;0;1279;0
WireConnection;1850;0;1056;0
WireConnection;1850;1;1851;0
WireConnection;1293;0;1292;0
WireConnection;1125;0;1124;0
WireConnection;658;0;636;1
WireConnection;658;1;659;0
WireConnection;222;0;226;1
WireConnection;262;0;267;0
WireConnection;262;1;264;0
WireConnection;1295;0;1293;0
WireConnection;1415;0;1859;0
WireConnection;1634;0;1631;0
WireConnection;638;0;658;0
WireConnection;237;0;222;0
WireConnection;237;1;236;0
WireConnection;260;0;262;0
WireConnection;260;1;240;0
WireConnection;1281;0;1280;0
WireConnection;1296;0;1293;0
WireConnection;1849;0;1850;0
WireConnection;1849;1;1056;0
WireConnection;767;0;765;0
WireConnection;1277;0;1281;0
WireConnection;1277;2;1281;0
WireConnection;371;0;370;0
WireConnection;1362;0;1358;0
WireConnection;466;0;463;0
WireConnection;742;0;744;0
WireConnection;742;1;743;0
WireConnection;486;0;1849;0
WireConnection;486;1;1792;0
WireConnection;1771;7;1056;0
WireConnection;766;0;767;0
WireConnection;721;0;708;0
WireConnection;1294;0;1295;0
WireConnection;1294;1;1296;0
WireConnection;1632;0;1634;0
WireConnection;238;0;237;0
WireConnection;441;1;1213;0
WireConnection;1188;1;260;0
WireConnection;1102;1;1096;0
WireConnection;1287;0;1297;0
WireConnection;749;0;748;0
WireConnection;749;1;741;1
WireConnection;1870;0;1869;0
WireConnection;1870;2;1771;0
WireConnection;1870;3;486;0
WireConnection;1501;0;1502;0
WireConnection;1501;1;1504;0
WireConnection;445;0;371;0
WireConnection;467;0;466;0
WireConnection;1511;0;1416;0
WireConnection;763;0;749;0
WireConnection;763;1;766;0
WireConnection;1803;0;1277;0
WireConnection;1803;1;1277;0
WireConnection;704;0;712;0
WireConnection;704;1;702;1
WireConnection;1357;0;1188;0
WireConnection;1357;1;1362;0
WireConnection;653;0;660;0
WireConnection;653;1;651;0
WireConnection;653;2;1102;0
WireConnection;745;0;742;0
WireConnection;745;1;741;1
WireConnection;360;0;359;0
WireConnection;360;1;1188;0
WireConnection;1288;0;1287;0
WireConnection;1288;1;1294;0
WireConnection;265;0;238;0
WireConnection;454;0;537;0
WireConnection;454;2;458;0
WireConnection;454;3;457;0
WireConnection;1557;0;441;1
WireConnection;1557;1;1632;0
WireConnection;1557;2;1634;0
WireConnection;719;0;721;0
WireConnection;1561;0;441;1
WireConnection;1561;1;1557;0
WireConnection;705;0;704;0
WireConnection;705;1;719;0
WireConnection;1418;0;260;0
WireConnection;1418;1;1417;0
WireConnection;1282;0;1870;0
WireConnection;1282;1;1803;0
WireConnection;1282;2;1288;0
WireConnection;1500;0;1501;0
WireConnection;1500;1;1505;0
WireConnection;1500;2;1508;0
WireConnection;764;0;745;0
WireConnection;764;1;766;0
WireConnection;751;0;763;0
WireConnection;650;0;653;0
WireConnection;650;1;649;0
WireConnection;1359;0;1357;0
WireConnection;1510;0;1509;0
WireConnection;1510;2;1511;0
WireConnection;444;0;1188;0
WireConnection;444;1;445;0
WireConnection;444;2;371;0
WireConnection;462;0;454;0
WireConnection;462;1;467;0
WireConnection;478;0;1056;0
WireConnection;478;1;1288;0
WireConnection;356;0;360;0
WireConnection;1355;0;1359;0
WireConnection;1355;1;1356;0
WireConnection;747;0;751;0
WireConnection;747;1;764;0
WireConnection;1877;0;1878;0
WireConnection;1877;2;1418;0
WireConnection;1877;3;1500;0
WireConnection;446;1;1561;0
WireConnection;446;2;440;0
WireConnection;1330;0;1329;0
WireConnection;252;0;254;0
WireConnection;252;1;256;0
WireConnection;1360;0;444;0
WireConnection;1049;0;1050;0
WireConnection;1485;0;1416;0
WireConnection;1485;1;1483;0
WireConnection;1485;2;1510;0
WireConnection;652;0;650;0
WireConnection;1872;0;1871;0
WireConnection;1872;2;1282;0
WireConnection;1872;3;478;0
WireConnection;358;0;356;0
WireConnection;358;1;1274;0
WireConnection;358;2;1276;0
WireConnection;715;0;705;0
WireConnection;738;0;462;0
WireConnection;361;1;358;0
WireConnection;716;0;715;0
WireConnection;965;0;1877;0
WireConnection;1682;0;446;0
WireConnection;1331;0;1355;0
WireConnection;1331;1;1330;0
WireConnection;665;0;652;0
WireConnection;753;0;747;0
WireConnection;246;0;252;0
WireConnection;1625;0;1360;0
WireConnection;1486;0;1485;0
WireConnection;1047;0;1872;0
WireConnection;1047;1;1048;0
WireConnection;1047;2;1049;0
WireConnection;1875;0;1876;0
WireConnection;1875;2;1486;0
WireConnection;1875;3;1416;0
WireConnection;1099;0;1096;0
WireConnection;1680;0;361;0
WireConnection;1680;1;1618;0
WireConnection;1051;0;1047;0
WireConnection;1619;0;1451;0
WireConnection;1619;1;1618;0
WireConnection;1619;2;1625;0
WireConnection;762;0;753;0
WireConnection;762;1;740;0
WireConnection;1651;1;1669;0
WireConnection;1879;0;1880;0
WireConnection;1879;2;1682;0
WireConnection;1879;3;446;0
WireConnection;1622;1;1623;0
WireConnection;726;0;716;0
WireConnection;726;1;727;0
WireConnection;401;0;246;0
WireConnection;401;1;665;0
WireConnection;1629;0;1451;0
WireConnection;1629;1;1618;0
WireConnection;1629;2;1331;0
WireConnection;528;0;526;0
WireConnection;528;1;527;0
WireConnection;759;0;762;0
WireConnection;759;1;760;0
WireConnection;588;0;583;0
WireConnection;755;0;738;0
WireConnection;755;1;726;0
WireConnection;1186;1;966;0
WireConnection;1628;0;1451;0
WireConnection;1628;1;1629;0
WireConnection;1628;2;1875;0
WireConnection;1655;1;1651;1
WireConnection;1655;2;1652;0
WireConnection;437;0;438;0
WireConnection;437;2;1879;0
WireConnection;1626;0;1451;0
WireConnection;1626;1;1619;0
WireConnection;1626;2;1875;0
WireConnection;1617;0;1622;0
WireConnection;1617;1;1680;0
WireConnection;1617;2;1875;0
WireConnection;1100;0;401;0
WireConnection;1100;1;1099;0
WireConnection;1656;0;1655;0
WireConnection;1656;1;1655;0
WireConnection;1656;2;1655;0
WireConnection;508;1;1055;0
WireConnection;718;0;756;0
WireConnection;718;1;755;0
WireConnection;1578;0;1100;0
WireConnection;1578;1;207;0
WireConnection;1578;2;588;0
WireConnection;902;0;437;0
WireConnection;1388;0;1376;0
WireConnection;362;1;1669;0
WireConnection;525;0;1186;0
WireConnection;525;1;526;0
WireConnection;525;2;528;0
WireConnection;372;1;1626;0
WireConnection;372;0;1617;0
WireConnection;372;2;1628;0
WireConnection;757;0;758;0
WireConnection;757;1;759;0
WireConnection;1554;0;372;0
WireConnection;1351;0;508;1
WireConnection;517;0;529;0
WireConnection;517;1;525;0
WireConnection;1400;0;406;1
WireConnection;1400;1;1404;0
WireConnection;1400;2;1578;0
WireConnection;731;0;718;0
WireConnection;731;1;757;0
WireConnection;1653;0;204;0
WireConnection;1653;1;362;0
WireConnection;1653;2;1656;0
WireConnection;682;1;1669;0
WireConnection;1041;0;1046;0
WireConnection;1886;0;1885;0
WireConnection;1886;2;731;0
WireConnection;1886;3;739;0
WireConnection;1042;0;1046;0
WireConnection;364;0;1653;0
WireConnection;220;0;1400;0
WireConnection;220;1;903;0
WireConnection;220;2;1397;0
WireConnection;220;3;1403;0
WireConnection;677;0;682;0
WireConnection;677;1;679;0
WireConnection;516;0;517;0
WireConnection;516;1;1351;0
WireConnection;685;0;686;0
WireConnection;685;2;677;0
WireConnection;1040;0;1041;0
WireConnection;1087;0;372;0
WireConnection;627;0;220;0
WireConnection;276;0;581;0
WireConnection;464;0;1886;0
WireConnection;531;1;516;0
WireConnection;1462;0;1552;0
WireConnection;1462;1;1220;0
WireConnection;1462;2;1463;0
WireConnection;1043;0;1042;0
WireConnection;1221;0;691;0
WireConnection;692;1;276;0
WireConnection;692;2;1221;0
WireConnection;243;0;627;0
WireConnection;1225;0;1462;0
WireConnection;1225;1;1222;0
WireConnection;391;0;1087;0
WireConnection;1045;0;531;0
WireConnection;1045;1;1040;0
WireConnection;1045;2;1043;0
WireConnection;460;0;464;0
WireConnection;680;0;685;0
WireConnection;1782;0;1045;0
WireConnection;1216;0;1217;0
WireConnection;1216;1;1462;0
WireConnection;1216;2;1045;0
WireConnection;1363;0;642;0
WireConnection;1363;1;692;0
WireConnection;1784;0;1225;0
WireConnection;1784;1;1217;0
WireConnection;1784;2;1217;4
WireConnection;1236;0;1216;0
WireConnection;1111;0;1066;0
WireConnection;1121;0;1119;0
WireConnection;1121;1;275;0
WireConnection;1121;2;1120;0
WireConnection;1121;3;1460;0
WireConnection;1266;1;392;0
WireConnection;1266;0;392;0
WireConnection;1266;2;392;0
WireConnection;1269;0;1363;0
WireConnection;1785;0;1784;0
WireConnection;1783;0;1782;0
WireConnection;229;0;1266;0
WireConnection;229;1;642;0
WireConnection;1774;0;1785;0
WireConnection;1774;1;1225;0
WireConnection;1774;2;1783;0
WireConnection;618;0;619;0
WireConnection;618;1;644;0
WireConnection;1187;1;1121;0
WireConnection;1069;0;1067;0
WireConnection;1070;0;1111;0
WireConnection;263;0;229;0
WireConnection;263;1;1269;0
WireConnection;1237;1;693;0
WireConnection;1237;0;1238;0
WireConnection;1237;2;693;0
WireConnection;661;0;618;0
WireConnection;661;1;623;0
WireConnection;661;2;644;0
WireConnection;498;0;492;0
WireConnection;498;1;499;0
WireConnection;1226;0;1774;0
WireConnection;1226;1;1465;0
WireConnection;1064;0;1187;0
WireConnection;1064;3;1069;0
WireConnection;1064;4;1070;0
WireConnection;1022;0;1226;0
WireConnection;476;0;1053;0
WireConnection;476;1;1064;0
WireConnection;476;2;481;0
WireConnection;476;3;482;0
WireConnection;1797;0;1237;0
WireConnection;1873;0;1874;0
WireConnection;1873;2;661;0
WireConnection;491;0;1053;0
WireConnection;491;1;1064;0
WireConnection;491;2;481;0
WireConnection;491;3;482;0
WireConnection;491;4;498;0
WireConnection;491;5;503;0
WireConnection;239;0;263;0
WireConnection;600;0;598;1
WireConnection;600;1;599;0
WireConnection;1364;0;1873;0
WireConnection;602;0;600;0
WireConnection;1906;0;1905;1
WireConnection;1906;1;1905;2
WireConnection;695;1;1797;0
WireConnection;695;2;696;0
WireConnection;490;1;476;0
WireConnection;490;0;491;0
WireConnection;1231;1;271;0
WireConnection;1231;0;1232;0
WireConnection;1231;2;271;0
WireConnection;601;0;602;0
WireConnection;694;0;270;0
WireConnection;694;1;695;0
WireConnection;1466;0;692;0
WireConnection;1265;0;490;0
WireConnection;1908;0;1790;0
WireConnection;1908;1;1906;0
WireConnection;1648;0;1644;0
WireConnection;1907;0;1908;0
WireConnection;1907;1;1790;0
WireConnection;1893;0;1648;0
WireConnection;259;0;1231;0
WireConnection;259;1;694;0
WireConnection;259;2;1366;0
WireConnection;591;1;601;0
WireConnection;1025;0;1265;0
WireConnection;1650;0;1645;0
WireConnection;1650;1;456;0
WireConnection;1650;2;1893;0
WireConnection;1789;0;1791;0
WireConnection;1789;1;1907;0
WireConnection;1898;0;1895;0
WireConnection;1898;2;54;0
WireConnection;1468;1;1467;0
WireConnection;1468;2;1469;0
WireConnection;1896;0;1895;0
WireConnection;1896;2;53;0
WireConnection;1894;0;1895;0
WireConnection;1894;2;52;0
WireConnection;1647;0;456;0
WireConnection;1647;1;1644;0
WireConnection;590;0;591;0
WireConnection;590;1;593;0
WireConnection;274;0;259;0
WireConnection;1899;0;1894;0
WireConnection;1899;1;1896;0
WireConnection;1899;2;1898;0
WireConnection;1555;0;1026;0
WireConnection;1888;0;1887;0
WireConnection;1888;2;456;0
WireConnection;1891;0;1887;0
WireConnection;1891;2;1650;0
WireConnection;1795;1;1789;0
WireConnection;1270;0;1253;0
WireConnection;1270;1;1468;0
WireConnection;1890;0;1887;0
WireConnection;1890;2;1647;0
WireConnection;592;0;590;0
WireConnection;592;1;596;0
WireConnection;1556;0;1555;0
WireConnection;1264;0;530;0
WireConnection;1264;1;1270;0
WireConnection;1264;2;1253;4
WireConnection;1254;0;1270;0
WireConnection;1254;1;1795;0
WireConnection;1254;2;1555;0
WireConnection;1256;0;1253;4
WireConnection;604;0;592;0
WireConnection;604;1;1899;0
WireConnection;1892;0;1888;0
WireConnection;1892;1;1890;0
WireConnection;1892;2;1891;0
WireConnection;55;0;50;0
WireConnection;55;1;51;0
WireConnection;1853;0;362;0
WireConnection;1866;0;1865;0
WireConnection;1866;2;604;0
WireConnection;1866;3;1899;0
WireConnection;1260;0;1264;0
WireConnection;1260;1;530;0
WireConnection;1260;2;1556;0
WireConnection;1257;0;1254;0
WireConnection;1257;1;1795;0
WireConnection;1257;2;1256;0
WireConnection;1642;0;1892;0
WireConnection;1636;0;530;0
WireConnection;60;0;1866;0
WireConnection;60;1;58;0
WireConnection;59;1;55;0
WireConnection;59;2;56;0
WireConnection;1868;0;1867;0
WireConnection;1868;2;1257;0
WireConnection;1868;3;1260;0
WireConnection;1637;0;1868;0
WireConnection;1637;1;1643;0
WireConnection;1637;2;461;0
WireConnection;1448;1;1854;0
WireConnection;1448;2;1449;0
WireConnection;1635;0;1636;0
WireConnection;1635;1;1643;0
WireConnection;1635;2;461;0
WireConnection;62;0;59;0
WireConnection;62;1;60;0
WireConnection;1249;0;1637;0
WireConnection;1249;1;681;0
WireConnection;282;0;1635;0
WireConnection;282;1;681;0
WireConnection;1855;0;1856;0
WireConnection;1855;2;62;0
WireConnection;1421;0;44;0
WireConnection;1421;1;1448;0
WireConnection;1605;0;1604;0
WireConnection;1605;1;1600;0
WireConnection;1604;0;1599;0
WireConnection;1024;1;282;0
WireConnection;1024;0;282;0
WireConnection;1024;2;1249;0
WireConnection;737;0;753;0
WireConnection;737;1;740;0
WireConnection;1857;0;1421;0
WireConnection;1857;1;1855;0
WireConnection;1611;0;1605;0
WireConnection;1852;13;1024;0
WireConnection;1852;11;1857;0
ASEEND*/
//CHKSM=D6AFD416E18AFE6EBEC9C308A77B5737C693D87F