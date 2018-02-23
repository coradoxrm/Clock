Shader "Unlit/outLine"
{
	Properties
	{
	    _MainTex ("Texture", 2D) = "white" {}
		_Color("mainColor", Color) = (0,0,0,0)
		_OutlineColor("outlineColor", Color) = (0,0,0,0)
		_OutlineWidth("outlineWidth", Range(1, 1.5)) = 1.04
	}

	CGINCLUDE
	#include "UnityCG.cginc"
	struct appdata_outline
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f_outline
			{
				float4 pos : POSITION;
				float4 color : COLOR;
				float3 normal : NORMAL;
			};

			float _OutlineWidth;
			float4 _OutlineColor;

			v2f_outline vert(appdata_outline v)
			{
				v.vertex.xyz *= _OutlineWidth;
				v2f_outline o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.color = _OutlineColor;
				return o;
			}

	ENDCG

	SubShader
	{
		Tags { "RenderType"="Opaque" "Queue"="Transparent"}
		LOD 100

		
		Pass  // outline pass
		{
		ZWrite Off

		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"

		half4 frag(v2f_outline i) : COLOR
		{
			return _OutlineColor;
		}

		ENDCG
		}
		
		//Pass  // normal pass
		//{
		//	ZWrite On

		//	Material
		//	{
		//		Diffuse[_Color]
		//		Ambient[_Color]
		//	}
		//}
		Pass{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 worldNormal : NORMAL;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float3 normalDir : NORMAL;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.normalDir = UnityObjectToWorldNormal(v.worldNormal);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
			fixed4 col = tex2D(_MainTex, i.uv);
			float NdotL =  floor(max(0.0, dot(normalize(i.normalDir), normalize(_WorldSpaceLightPos0.xyz)))*1.2);
			float DiffuseThrehold = max(0.0, dot(normalize(i.normalDir), normalize(_WorldSpaceLightPos0.xyz)));
				// sample the texture
				if(DiffuseThrehold > 0)
				col.rgb *= _Color;
				else if(DiffuseThrehold <= 0)
				col.rgb *= _Color * 0.5;
				return col;
			}
			ENDCG
			}
	}
}
