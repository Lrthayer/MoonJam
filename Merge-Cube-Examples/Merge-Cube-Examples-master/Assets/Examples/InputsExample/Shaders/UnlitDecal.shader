/*SF_DATA;ver:1.35;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-6454-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:31801,y:32708,ptovrint:False,ptlb:base color,ptin:_basecolor,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2d,id:838,x:31618,y:32565,ptovrint:False,ptlb:base,ptin:_base,varname:node_838,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:26b1605d13304418cb30ba974b41f298,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:585,x:31692,y:32871,ptovrint:False,ptlb:decal,ptin:_decal,varname:node_585,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:72f052122502345f1b365b37455a8e3d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4769,x:32058,y:32695,varname:node_4769,prsc:2|A-838-RGB,B-7241-RGB;n:type:ShaderForge.SFN_Lerp,id:6454,x:32477,y:32763,varname:node_6454,prsc:2|A-4769-OUT,B-585-RGB,T-585-A;proporder:7241-838-585;pass:END;sub:END;*/

Shader "HSDK/UnlitDecal" {
    Properties {
        _basecolor ("base color", Color) = (1,1,1,1)
        _base ("base", 2D) = "white" {}
        _decal ("decal", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _basecolor;
            uniform sampler2D _base; uniform float4 _base_ST;
            uniform sampler2D _decal; uniform float4 _decal_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _base_var = tex2D(_base,TRANSFORM_TEX(i.uv0, _base));
                float4 _decal_var = tex2D(_decal,TRANSFORM_TEX(i.uv0, _decal));
                float3 emissive = lerp((_base_var.rgb*_basecolor.rgb),_decal_var.rgb,_decal_var.a);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
