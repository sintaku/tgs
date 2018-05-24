Shader "Custom/BeltConveyor" {
	Properties{
		_MainTex("BeltConveyor Texture", 2D) = "white" {}
		_XSpeed("uv.x direction speed",Float) = 0
		_YSpeed("uv.y direction speed", Float) = 0
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
#pragma surface surf Standard fullforwardshadows
#pragma target 3.0

		sampler2D _MainTex;
		float _XSpeed;
		float _YSpeed;

	struct Input {
		float2 uv_MainTex;
	};

	void surf(Input IN, inout SurfaceOutputStandard o) {
		fixed2 uv = IN.uv_MainTex;
		uv.x += _XSpeed * _Time;
		uv.y += _YSpeed * _Time;
		o.Albedo = tex2D(_MainTex, uv);
	}
	ENDCG
	}
		FallBack "Diffuse"
}