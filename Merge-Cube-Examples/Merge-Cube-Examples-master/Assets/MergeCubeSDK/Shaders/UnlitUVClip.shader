// Shader created with Shader Forge v1.35 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.35;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33285,y:33044,varname:node_3138,prsc:2|emission-197-RGB,clip-6410-OUT;n:type:ShaderForge.SFN_TexCoord,id:9313,x:31038,y:33088,varname:node_9313,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:197,x:32127,y:33082,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_197,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:aeb2e665d0ef148f2961ed047ddc8d97,ntxv:0,isnm:False|UVIN-293-OUT;n:type:ShaderForge.SFN_Vector2,id:5701,x:31038,y:33231,varname:node_5701,prsc:2,v1:1,v2:1;n:type:ShaderForge.SFN_Add,id:9048,x:31516,y:33206,varname:node_9048,prsc:2|A-7332-OUT,B-3649-OUT;n:type:ShaderForge.SFN_Vector2,id:3649,x:31251,y:33232,varname:node_3649,prsc:2,v1:0,v2:0;n:type:ShaderForge.SFN_Clamp01,id:293,x:31782,y:33081,varname:node_293,prsc:2|IN-9048-OUT;n:type:ShaderForge.SFN_If,id:8370,x:32115,y:33770,varname:node_8370,prsc:2|A-2713-OUT,B-1326-OUT,GT-2203-RGB,EQ-2441-RGB,LT-4644-RGB;n:type:ShaderForge.SFN_Color,id:2441,x:31782,y:33824,ptovrint:False,ptlb:node_2441,ptin:_node_2441,varname:node_2441,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:2203,x:31782,y:33656,ptovrint:False,ptlb:node_2203,ptin:_node_2203,varname:node_2203,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:4644,x:31782,y:33990,ptovrint:False,ptlb:node_4644,ptin:_node_4644,varname:node_4644,prsc:2,glob:False,taghide:True,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Vector1,id:1326,x:31782,y:33580,varname:node_1326,prsc:2,v1:1;n:type:ShaderForge.SFN_If,id:5485,x:32115,y:33634,varname:node_5485,prsc:2|A-6432-OUT,B-2713-OUT,GT-2203-RGB,EQ-2441-RGB,LT-4644-RGB;n:type:ShaderForge.SFN_Vector1,id:6432,x:31782,y:33504,varname:node_6432,prsc:2,v1:0;n:type:ShaderForge.SFN_ComponentMask,id:2539,x:32299,y:33770,varname:node_2539,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-8370-OUT;n:type:ShaderForge.SFN_ComponentMask,id:6622,x:32299,y:33634,varname:node_6622,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-5485-OUT;n:type:ShaderForge.SFN_Multiply,id:1039,x:32568,y:33680,varname:node_1039,prsc:2|A-6622-OUT,B-2539-OUT;n:type:ShaderForge.SFN_ComponentMask,id:2713,x:31782,y:33204,varname:node_2713,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-9048-OUT;n:type:ShaderForge.SFN_ComponentMask,id:6672,x:31782,y:33348,varname:node_6672,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-9048-OUT;n:type:ShaderForge.SFN_If,id:1378,x:32115,y:33469,varname:node_1378,prsc:2|A-6672-OUT,B-1326-OUT,GT-2203-RGB,EQ-2441-RGB,LT-4644-RGB;n:type:ShaderForge.SFN_If,id:4449,x:32115,y:33333,varname:node_4449,prsc:2|A-6432-OUT,B-6672-OUT,GT-2203-RGB,EQ-2441-RGB,LT-4644-RGB;n:type:ShaderForge.SFN_ComponentMask,id:9133,x:32299,y:33469,varname:node_9133,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-1378-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8962,x:32299,y:33333,varname:node_8962,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-4449-OUT;n:type:ShaderForge.SFN_Multiply,id:5411,x:32565,y:33406,varname:node_5411,prsc:2|A-8962-OUT,B-9133-OUT;n:type:ShaderForge.SFN_Multiply,id:6410,x:32832,y:33544,varname:node_6410,prsc:2|A-5411-OUT,B-1039-OUT;n:type:ShaderForge.SFN_Multiply,id:7332,x:31251,y:33115,varname:node_7332,prsc:2|A-9313-UVOUT,B-5701-OUT;proporder:197-2441-2203-4644;pass:END;sub:END;*/

Shader "Shader Forge/UnlitUVClip" {
    Properties {
        _Texture ("Texture", 2D) = "white" {}
        [HideInInspector]_node_2441 ("node_2441", Color) = (0,0,0,1)
        [HideInInspector]_node_2203 ("node_2203", Color) = (1,0,0,1)
        [HideInInspector]_node_4644 ("node_4644", Color) = (1,1,1,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
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
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float4 _node_2441;
            uniform float4 _node_2203;
            uniform float4 _node_4644;
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
                float node_6432 = 0.0;
                float2 node_9048 = ((i.uv0*float2(1,1))+float2(0,0));
                float node_6672 = node_9048.g;
                float node_4449_if_leA = step(node_6432,node_6672);
                float node_4449_if_leB = step(node_6672,node_6432);
                float node_1326 = 1.0;
                float node_1378_if_leA = step(node_6672,node_1326);
                float node_1378_if_leB = step(node_1326,node_6672);
                float node_2713 = node_9048.r;
                float node_5485_if_leA = step(node_6432,node_2713);
                float node_5485_if_leB = step(node_2713,node_6432);
                float node_8370_if_leA = step(node_2713,node_1326);
                float node_8370_if_leB = step(node_1326,node_2713);
                clip(((lerp((node_4449_if_leA*_node_4644.rgb)+(node_4449_if_leB*_node_2203.rgb),_node_2441.rgb,node_4449_if_leA*node_4449_if_leB).g*lerp((node_1378_if_leA*_node_4644.rgb)+(node_1378_if_leB*_node_2203.rgb),_node_2441.rgb,node_1378_if_leA*node_1378_if_leB).g)*(lerp((node_5485_if_leA*_node_4644.rgb)+(node_5485_if_leB*_node_2203.rgb),_node_2441.rgb,node_5485_if_leA*node_5485_if_leB).g*lerp((node_8370_if_leA*_node_4644.rgb)+(node_8370_if_leB*_node_2203.rgb),_node_2441.rgb,node_8370_if_leA*node_8370_if_leB).g)) - 0.5);
////// Lighting:
////// Emissive:
                float2 node_293 = saturate(node_9048);
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_293, _Texture));
                float3 emissive = _Texture_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _node_2441;
            uniform float4 _node_2203;
            uniform float4 _node_4644;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float node_6432 = 0.0;
                float2 node_9048 = ((i.uv0*float2(1,1))+float2(0,0));
                float node_6672 = node_9048.g;
                float node_4449_if_leA = step(node_6432,node_6672);
                float node_4449_if_leB = step(node_6672,node_6432);
                float node_1326 = 1.0;
                float node_1378_if_leA = step(node_6672,node_1326);
                float node_1378_if_leB = step(node_1326,node_6672);
                float node_2713 = node_9048.r;
                float node_5485_if_leA = step(node_6432,node_2713);
                float node_5485_if_leB = step(node_2713,node_6432);
                float node_8370_if_leA = step(node_2713,node_1326);
                float node_8370_if_leB = step(node_1326,node_2713);
                clip(((lerp((node_4449_if_leA*_node_4644.rgb)+(node_4449_if_leB*_node_2203.rgb),_node_2441.rgb,node_4449_if_leA*node_4449_if_leB).g*lerp((node_1378_if_leA*_node_4644.rgb)+(node_1378_if_leB*_node_2203.rgb),_node_2441.rgb,node_1378_if_leA*node_1378_if_leB).g)*(lerp((node_5485_if_leA*_node_4644.rgb)+(node_5485_if_leB*_node_2203.rgb),_node_2441.rgb,node_5485_if_leA*node_5485_if_leB).g*lerp((node_8370_if_leA*_node_4644.rgb)+(node_8370_if_leB*_node_2203.rgb),_node_2441.rgb,node_8370_if_leA*node_8370_if_leB).g)) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
