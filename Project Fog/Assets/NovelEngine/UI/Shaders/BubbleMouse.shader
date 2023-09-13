Shader "Unlit/BubbleMouse"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_SecondaryTex("Secondary Texture", 2D) = "white" {}
		_StepTex("Step Texture", 2D) = "white" {}
		_Color("Color", Color) = (0, 0, 0, 1)
		_Radius("Radius", Range(0, 1)) = 0.3
		_DistanceRange("Distance Range", Range(0, 1)) = 0.3
		_Increment("Increment", Range(0, 1)) = 0
		_Density("Density", Range(0, 1)) = 0.3
		_Direction("Pattern Direction", Vector) = (1, 1, 0, 0)
		_PatternIntensity("Pattern Intensity", Range(0, 1)) = 0
		_PatternRotation("Rotation", Range(0, 3.15)) = 0
		//_PulseArray("Pulse Array", Vector[50]) = {}
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        LOD 100

		ZWrite Off	
		Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
				float2 uv2 : TEXCOORD1;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
				float4 screenPos: POSITION1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			sampler2D _SecondaryTex;
			float4 _SecondaryTex_ST;
			sampler2D _StepTex;
			float4 _StepTex_ST;
			fixed4 _Color;
			float _Step;
			float _Increment;
			float _Radius;
			float _DistanceRange;
			float4 _MousePos;
			float4 _Direction;
			float _Density;
			float _Ratio;
			float _PatternIntensity;
			float _PatternRotation;
			int _ArrayLength;
			float4 _PulseArray[32];

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); 
				o.screenPos = ComputeScreenPos(o.vertex); 
				float s = sin(_PatternRotation);
				float c = cos(_PatternRotation);
				float2x2 rotationMatrix = float2x2(c, -s, s, c);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				v.uv.xy = mul(v.uv.xy, rotationMatrix);
				o.uv2 = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
				float2 stepUV = i.uv2 / _MainTex_ST.xy;
				stepUV = stepUV * _StepTex_ST;
				stepUV.x += _Direction.x * (_Time.y/5);
				stepUV.y += _Direction.y * (_Time.y/5);
				fixed4 stepTex = tex2D(_StepTex, stepUV);
				float2 mouseNormals = _MousePos.xy;
				float xCoord = (i.uv.x - _MainTex_ST.z) / _MainTex_ST.x;
				float yCoord = (i.uv.y - _MainTex_ST.w) / _MainTex_ST.y;
				float multiplier = (step(1.0f, _Ratio) * _Ratio) + (1 * step(_Ratio, 1.0f));
				float radiusDistanceX = (xCoord - mouseNormals.x) * multiplier;
				multiplier = (step(_Ratio, 1.0f) * _Ratio) + (1 * step(1.0f, _Ratio));
				float radiusDistanceY = (yCoord - mouseNormals.y) / multiplier;
				//float radiusDistance = (distance(float2(xCoord, yCoord), mouseNormals)) - _Increment;
				float radiusDistance = length(float2(radiusDistanceX, radiusDistanceY));
				float radiusStep = radiusDistance / _Radius;//max(0, xCoord + yCoord + (radiusStep)) * _Increment;
				float newRadiusStep = smoothstep(radiusStep - 0.1f, radiusStep, col.a);
				float newPulseStep = 0.0f;
				for (int j = 0; j < _ArrayLength; j++) {
					float2 pulseNormals = _PulseArray[j].xy;
					float pulseDistanceX = xCoord - pulseNormals.x;
					float pulseDistanceY = (yCoord - pulseNormals.y) / (_ScreenParams.x / _ScreenParams.y);
					float pulseDistance = length(float2(pulseDistanceX, pulseDistanceY));
					//float pulseDistance = distance(float2(xCoord, yCoord), pulseNormals);
					float lowerBound = _PulseArray[j].z - _DistanceRange;
					float upperBound = _PulseArray[j].z;
					float pulseStep = 1.1f - smoothstep(lowerBound - 0.2f, lowerBound, pulseDistance) * smoothstep(upperBound, upperBound - 0.2f, pulseDistance);
					newPulseStep = newPulseStep + smoothstep(pulseStep - 0.1f, pulseStep, col.a);
				}
				float densityStep = step(_Density, col.a + (stepTex.a * _PatternIntensity));
				float fixedStep = newRadiusStep + newPulseStep + densityStep;
				float2 secondaryUV = i.uv / _MainTex_ST.xy;
				secondaryUV = secondaryUV * _SecondaryTex_ST.xy;
				fixed4 secondaryCol = tex2D(_SecondaryTex, secondaryUV);
				col = secondaryCol * _Color;
				col = fixed4(col.x, col.y, col.z, fixedStep);
                return col;
            }
            ENDCG
        }
    }
}
