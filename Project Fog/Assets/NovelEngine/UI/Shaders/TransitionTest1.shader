Shader "Unlit/TransitionTest1"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_SecondaryTex("Secondary Texture", 2D) = "white" {}
		_Color("Color", Color) = (0, 0, 0, 1)
		_Step("Step", Range(-5, 1.1)) = 0
		_Increment("Increment", Range(1, 50)) = 1
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
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			sampler2D _SecondaryTex;
			fixed4 _Color;
			float _Step;
			float _Increment;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
				float xCoord = (i.uv.x - _MainTex_ST.z) / _MainTex_ST.x;
				float yCoord = (i.uv.y - _MainTex_ST.w) / _MainTex_ST.y;
				float newStep = max(0, xCoord + yCoord + (_Step)) * _Increment;
				float fixedStep = smoothstep(newStep - 0.1f, newStep, col.a);
				float outNewStep = max(0, xCoord + yCoord + ((_Step + 3))) * _Increment;
				float outStep = 1 - smoothstep((outNewStep - 0.1f), outNewStep, 1 -col.a);
				fixedStep = fixedStep * step(-2, _Step) + (outStep * step(_Step, -2));
				fixed4 secondaryCol = tex2D(_SecondaryTex, i.uv);
				col = secondaryCol * _Color;
				col = fixed4(col.x, col.y, col.z, fixedStep);
                return col;
            }
            ENDCG
        }
    }
}
