
//////////////////////////////////////////////////////////////////////////////////////////
//																						//
// Flashback '94 Shader Pack for Unity 3D												//
// © 2016 George Khandaker-Kokoris														//
//																						//
// Shader for UI overlays																//
//																						//
//////////////////////////////////////////////////////////////////////////////////////////

Shader "Flashback 94/Object Shader/UI Overlay"
{
	Properties
	{
		_MainTex ("Main Texture (RGB) Alpha (A)", 2D) = "white" {}
		_DiffColor ("Diffuse Color", Color) = (1, 1, 1, 1)
		_Emissive ("Emissive Color", Color) = (0, 0, 0, 0)
		_Snapping ("Vertex Snapping", Range (1, 100)) = 10
	}

	SubShader
	{
		Tags { "Queue" = "Overlay" "RenderType" = "Overlay" }

		ZTest Always
		ZWrite Off
		Cull Off

		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask RGB

		Pass
		{
			Tags { "LightMode" = "Always" }

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog

			#include "Flashback94_ShaderFunctions.cginc"

			fixed4 _DiffColor;
			fixed4 _Emissive;
			half _Snapping;

			sampler2D _MainTex;
			float4 _MainTex_ST;

			fb94_v2f vert(appdata_full v)
			{
				float4 viewPos = FB94_ViewPos(v.vertex, _Snapping);
				fb94_v2f o = FB94_NewStruct(viewPos);
				
				o.uv = FB94_AffineUV(v.texcoord, _MainTex_ST, o.pos);

				return o;
			}
			
			fixed4 frag(fb94_v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv.xy / i.uv.z);

				col *= fixed4(i.diff, 1) * _DiffColor;
				col += fixed4(i.spec + _Emissive.rgb, 0);

				return col;
			}

			ENDCG
		}
	}
}
