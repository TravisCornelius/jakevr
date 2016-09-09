// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.12 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.12;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:3,spmd:1,grmd:0,uamb:False,mssp:True,bkdf:False,rprd:True,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:True,tesm:0,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:8731,x:33775,y:32827,varname:node_8731,prsc:2|diff-4107-RGB,spec-1504-RGB,gloss-9024-OUT,normal-6197-OUT,alpha-535-OUT,refract-1186-OUT,voffset-6732-OUT;n:type:ShaderForge.SFN_Add,id:1546,x:33063,y:33090,varname:node_1546,prsc:2|A-3980-RGB,B-7845-OUT;n:type:ShaderForge.SFN_Color,id:4107,x:33084,y:32514,ptovrint:False,ptlb:BaseColor,ptin:_BaseColor,varname:node_4107,prsc:2,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:9024,x:33400,y:32861,ptovrint:False,ptlb:Glossyness,ptin:_Glossyness,varname:node_9024,prsc:2,glob:False,v1:0.2;n:type:ShaderForge.SFN_Color,id:1504,x:33207,y:32733,ptovrint:False,ptlb:specColor,ptin:_specColor,varname:node_1504,prsc:2,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Panner,id:3955,x:32433,y:32858,varname:node_3955,prsc:2,spu:-0.05,spv:0;n:type:ShaderForge.SFN_Panner,id:6444,x:32481,y:33076,varname:node_6444,prsc:2,spu:0.05,spv:0|UVIN-1467-OUT,DIST-927-OUT;n:type:ShaderForge.SFN_TexCoord,id:4273,x:31998,y:33055,varname:node_4273,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:1467,x:32276,y:33052,varname:node_1467,prsc:2|A-4273-UVOUT,B-9663-OUT;n:type:ShaderForge.SFN_Vector2,id:9663,x:31998,y:33206,varname:node_9663,prsc:2,v1:2,v2:2;n:type:ShaderForge.SFN_Vector1,id:535,x:33038,y:32910,varname:node_535,prsc:2,v1:0.75;n:type:ShaderForge.SFN_ComponentMask,id:7845,x:32869,y:33104,varname:node_7845,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-7094-RGB;n:type:ShaderForge.SFN_Normalize,id:9185,x:33222,y:33112,varname:node_9185,prsc:2|IN-1546-OUT;n:type:ShaderForge.SFN_ComponentMask,id:5890,x:33400,y:33162,varname:node_5890,prsc:2,cc1:2,cc2:-1,cc3:-1,cc4:-1|IN-9185-OUT;n:type:ShaderForge.SFN_Multiply,id:6732,x:33587,y:33183,varname:node_6732,prsc:2|A-5890-OUT,B-6642-OUT;n:type:ShaderForge.SFN_Tex2d,id:7094,x:32678,y:33104,ptovrint:False,ptlb:NormalMap1,ptin:_NormalMap1,varname:node_7094,prsc:2,tex:03695c63955a55240bedc20a1f3929e1,ntxv:3,isnm:True|UVIN-6444-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:3980,x:32724,y:32881,ptovrint:False,ptlb:NormalMap2,ptin:_NormalMap2,varname:_NormalMap2,prsc:2,tex:03695c63955a55240bedc20a1f3929e1,ntxv:3,isnm:True|UVIN-3955-UVOUT;n:type:ShaderForge.SFN_ValueProperty,id:6642,x:33208,y:33358,ptovrint:False,ptlb:water_height,ptin:_water_height,varname:node_6642,prsc:2,glob:False,v1:0.15;n:type:ShaderForge.SFN_Vector1,id:927,x:32224,y:33299,varname:node_927,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Vector3,id:8003,x:33306,y:32926,varname:node_8003,prsc:2,v1:0.4980392,v2:0.4980392,v3:1;n:type:ShaderForge.SFN_Lerp,id:6197,x:33484,y:32954,varname:node_6197,prsc:2|A-8003-OUT,B-9185-OUT,T-7347-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7347,x:33319,y:33047,ptovrint:False,ptlb:waterNorms,ptin:_waterNorms,varname:node_7347,prsc:2,glob:False,v1:0.5;n:type:ShaderForge.SFN_ComponentMask,id:1186,x:33559,y:32695,varname:node_1186,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-5554-OUT;n:type:ShaderForge.SFN_Multiply,id:5554,x:33313,y:32591,varname:node_5554,prsc:2|A-4026-OUT,B-6197-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4026,x:33007,y:32693,ptovrint:False,ptlb:Refraction,ptin:_Refraction,varname:_Glossyness_copy,prsc:2,glob:False,v1:0.1;proporder:4107-9024-1504-7094-3980-6642-7347-4026;pass:END;sub:END;*/

Shader "Shader Forge/sf_watershader" {
    Properties {
        _BaseColor ("BaseColor", Color) = (0.5,0.5,0.5,1)
        _Glossyness ("Glossyness", Float ) = 0.2
        _specColor ("specColor", Color) = (0.5,0.5,0.5,1)
        _NormalMap1 ("NormalMap1", 2D) = "bump" {}
        _NormalMap2 ("NormalMap2", 2D) = "bump" {}
        _water_height ("water_height", Float ) = 0.15
        _waterNorms ("waterNorms", Float ) = 0.5
        _Refraction ("Refraction", Float ) = 0.1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform float4 _BaseColor;
            uniform float _Glossyness;
            uniform float4 _specColor;
            uniform sampler2D _NormalMap1; uniform float4 _NormalMap1_ST;
            uniform sampler2D _NormalMap2; uniform float4 _NormalMap2_ST;
            uniform float _water_height;
            uniform float _waterNorms;
            uniform float _Refraction;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 screenPos : TEXCOORD5;
                UNITY_FOG_COORDS(6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_4756 = _Time + _TimeEditor;
                float2 node_3955 = (o.uv0+node_4756.g*float2(-0.05,0));
                float3 _NormalMap2_var = UnpackNormal(tex2Dlod(_NormalMap2,float4(TRANSFORM_TEX(node_3955, _NormalMap2),0.0,0)));
                float2 node_6444 = ((o.uv0*float2(2,2))+0.1*float2(0.05,0));
                float3 _NormalMap1_var = UnpackNormal(tex2Dlod(_NormalMap1,float4(TRANSFORM_TEX(node_6444, _NormalMap1),0.0,0)));
                float3 node_9185 = normalize((_NormalMap2_var.rgb+float3(_NormalMap1_var.rgb.rg,0.0)));
                float node_6732 = (node_9185.b*_water_height);
                v.vertex.xyz += float3(node_6732,node_6732,node_6732);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float4 node_4756 = _Time + _TimeEditor;
                float2 node_3955 = (i.uv0+node_4756.g*float2(-0.05,0));
                float3 _NormalMap2_var = UnpackNormal(tex2D(_NormalMap2,TRANSFORM_TEX(node_3955, _NormalMap2)));
                float2 node_6444 = ((i.uv0*float2(2,2))+0.1*float2(0.05,0));
                float3 _NormalMap1_var = UnpackNormal(tex2D(_NormalMap1,TRANSFORM_TEX(node_6444, _NormalMap1)));
                float3 node_9185 = normalize((_NormalMap2_var.rgb+float3(_NormalMap1_var.rgb.rg,0.0)));
                float3 node_6197 = lerp(float3(0.4980392,0.4980392,1),node_9185,_waterNorms);
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_Refraction*node_6197).rg;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalLocal = node_6197;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Glossyness;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float3 diffuseColor = _BaseColor.rgb; // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _specColor.rgb.r, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(lerp(sceneColor.rgb, finalColor,0.75),1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform sampler2D _GrabTexture;
            uniform float4 _TimeEditor;
            uniform float4 _BaseColor;
            uniform float _Glossyness;
            uniform float4 _specColor;
            uniform sampler2D _NormalMap1; uniform float4 _NormalMap1_ST;
            uniform sampler2D _NormalMap2; uniform float4 _NormalMap2_ST;
            uniform float _water_height;
            uniform float _waterNorms;
            uniform float _Refraction;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                float4 screenPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_2967 = _Time + _TimeEditor;
                float2 node_3955 = (o.uv0+node_2967.g*float2(-0.05,0));
                float3 _NormalMap2_var = UnpackNormal(tex2Dlod(_NormalMap2,float4(TRANSFORM_TEX(node_3955, _NormalMap2),0.0,0)));
                float2 node_6444 = ((o.uv0*float2(2,2))+0.1*float2(0.05,0));
                float3 _NormalMap1_var = UnpackNormal(tex2Dlod(_NormalMap1,float4(TRANSFORM_TEX(node_6444, _NormalMap1),0.0,0)));
                float3 node_9185 = normalize((_NormalMap2_var.rgb+float3(_NormalMap1_var.rgb.rg,0.0)));
                float node_6732 = (node_9185.b*_water_height);
                v.vertex.xyz += float3(node_6732,node_6732,node_6732);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float4 node_2967 = _Time + _TimeEditor;
                float2 node_3955 = (i.uv0+node_2967.g*float2(-0.05,0));
                float3 _NormalMap2_var = UnpackNormal(tex2D(_NormalMap2,TRANSFORM_TEX(node_3955, _NormalMap2)));
                float2 node_6444 = ((i.uv0*float2(2,2))+0.1*float2(0.05,0));
                float3 _NormalMap1_var = UnpackNormal(tex2D(_NormalMap1,TRANSFORM_TEX(node_6444, _NormalMap1)));
                float3 node_9185 = normalize((_NormalMap2_var.rgb+float3(_NormalMap1_var.rgb.rg,0.0)));
                float3 node_6197 = lerp(float3(0.4980392,0.4980392,1),node_9185,_waterNorms);
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5 + (_Refraction*node_6197).rg;
                float4 sceneColor = tex2D(_GrabTexture, sceneUVs);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalLocal = node_6197;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = _Glossyness;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float3 diffuseColor = _BaseColor.rgb; // Need this for specular when using metallic
                float specularMonochrome;
                float3 specularColor;
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, _specColor.rgb.r, specularColor, specularMonochrome );
                specularMonochrome = 1-specularMonochrome;
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * 0.75,0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform sampler2D _NormalMap1; uniform float4 _NormalMap1_ST;
            uniform sampler2D _NormalMap2; uniform float4 _NormalMap2_ST;
            uniform float _water_height;
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
                float4 node_2969 = _Time + _TimeEditor;
                float2 node_3955 = (o.uv0+node_2969.g*float2(-0.05,0));
                float3 _NormalMap2_var = UnpackNormal(tex2Dlod(_NormalMap2,float4(TRANSFORM_TEX(node_3955, _NormalMap2),0.0,0)));
                float2 node_6444 = ((o.uv0*float2(2,2))+0.1*float2(0.05,0));
                float3 _NormalMap1_var = UnpackNormal(tex2Dlod(_NormalMap1,float4(TRANSFORM_TEX(node_6444, _NormalMap1),0.0,0)));
                float3 node_9185 = normalize((_NormalMap2_var.rgb+float3(_NormalMap1_var.rgb.rg,0.0)));
                float node_6732 = (node_9185.b*_water_height);
                v.vertex.xyz += float3(node_6732,node_6732,node_6732);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
