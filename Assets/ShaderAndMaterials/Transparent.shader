// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Chrome/Transparent" {
	Properties {
		_Color("Color",Color) = (1,1,1,1)
		_MainTex ("Main Texture (RGB)", 2D) = "white" {}
		_SecondTex("Albedo (RGB)",Color) = (1,1,1,1)
	}
	SubShader {
		//Tags { "RenderType"="Opaque" }
		Tags
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
		LOD 200
		Cull Back
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		
		#pragma surface surf Standard alpha:fade //This indicates that all the pixels from this
		//material have to be blended with what was on the screen before according to their alpha
		//values.Without this directive, the pixels will be drawn in the correct order, but they won’t
		//have any transparency.


		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _SecondTex;
	fixed4 _Color;

		struct Input {
			float2 uv_MainTex;
		};

		UNITY_INSTANCING_BUFFER_START(Props)

		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {

			//fixed2 scrolledUV = IN.uv_MainTex;

			// Create variables that store the individual x and y
			// components for the UV's scaled by time
			//fixed xScrollValue = 0;// _Time.y / 2;
			//fixed yScrollValue = _Time.y/2;

								   // Apply the final UV offset
			//scrolledUV += fixed2(xScrollValue, yScrollValue);

			// Apply textures and tint
			float4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;

			o.Albedo = c.rgb;


			//float4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
