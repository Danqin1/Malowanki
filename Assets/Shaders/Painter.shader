Shader "Unlit/Painter"
{
    SubShader
    {
        Tags { "RenderType"="Opaque"}
        LOD 100

        Pass
        {
            CGPROGRAM
            //#pragma target 4.0
            
            #pragma vertex vert
            #pragma fragment frag


            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float3 worldPos : TEXCOORD1;
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D           _MainTex;
            float4              _MainTex_ST;
            uniform float4      _Mouse;
            float4x4            mesh_Object2World;
            float4	            _BrushColor;
            float	            _BrushOpacity;
            float	            _BrushHardness;
            float	            _BrushSize;
            v2f vert (appdata v)
            {
                v2f o;
               o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                float2 uvRemapped = v.uv.xy;
                uvRemapped.y = 1. - uvRemapped.y;
                uvRemapped = uvRemapped * 2. - 1.;

                o.vertex = float4(uvRemapped.xy, 0., 1.);
                o.worldPos = mul(mesh_Object2World, v.vertex);
                o.uv = v.uv;
               
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);
                float  size = _BrushSize;
                float  soft = _BrushHardness;
                float  f = distance(_Mouse.xyz, i.worldPos);
                f = 1. - smoothstep(size * soft, size, f);
                col = lerp(col, _BrushColor, f * _Mouse.w * _BrushOpacity);
                col = saturate(col);
                return col;
            }
            ENDCG
        }
    }
}
