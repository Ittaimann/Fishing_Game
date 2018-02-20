Shader "Unlit/WaterDistort"
{
	Properties
	{
		_noise("NOISE",2D)="White"{}
	}
    SubShader
    {
        // Draw ourselves after all opaque geometry
        Tags { "Queue" = "Transparent" }
		//Blend SrcAlpha OneMinusSrcAlpha
        // Grab the screen behind the object into _BackgroundTexture
   		GrabPass
        {
            "_BackgroundTexture"
        }
        // Render the object with the texture generated above, and invert the colors
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

			
			struct appdata
			{
				float2 uv: TEXCOORD0;
				float4 grabPos : TEXCOORD1;
                float4 vertex : POSITION;
			};
            struct v2f
            {
                float2 uv: TEXCOORD0;
				float4 grabPos : TEXCOORD1;
                float4 pos : SV_POSITION;
            };

			sampler2D _noise;
			float4 _noise_ST;

            v2f vert(appdata v) {
                v2f o;
				o.uv=TRANSFORM_TEX(v.uv,_noise);
                // use UnityObjectToClipPos from UnityCG.cginc to calculate 
                // the clip-space of the vertex
                o.pos = UnityObjectToClipPos(v.vertex);
                // use ComputeGrabScreenPos function from UnityCG.cginc
                // to get the correct texture coordinate
                o.grabPos = ComputeGrabScreenPos(o.pos);
                return o;
            }

            sampler2D _BackgroundTexture;

            half4 frag(v2f i) : SV_Target
            {
				half4 uv = i.grabPos;
                half noiseVal = tex2D(_noise, uv).r;
				uv.y = uv.y + noiseVal * sin(_Time.y*5)/100;
				uv.x = uv.x + noiseVal * sin(_Time.x*5)/100;
				float4 col=tex2Dproj(_BackgroundTexture, uv);
				
                return col;
            }
            ENDCG
        }

    }
}