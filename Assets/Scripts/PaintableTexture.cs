﻿using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class PaintableTexture
{
    public string id;
    public RenderTexture runTimeTexture;
    public RenderTexture paintedTexture;

    public CommandBuffer cb;

    public Material mPaintInUV;
    public Material mFixedEdges;
    public RenderTexture fixedIlsands;

    public PaintableTexture(Color clearColor, int width, int height, string id,
        Shader sPaintInUV, Mesh mToDraw, Shader fixIlsandEdgesShader, RenderTexture markedIlsandes)
    {
        this.id = id;

        runTimeTexture = new RenderTexture(width, height, 0)
        {
            anisoLevel = 0,
            useMipMap = false,
            filterMode = FilterMode.Bilinear
        };

        paintedTexture = new RenderTexture(width, height, 0)
        {
            anisoLevel = 0,
            useMipMap = false,
            filterMode = FilterMode.Bilinear
        };
        fixedIlsands = new RenderTexture(paintedTexture.descriptor);

        Graphics.SetRenderTarget(runTimeTexture);
        GL.Clear(false, true, clearColor);
        Graphics.SetRenderTarget(paintedTexture);
        GL.Clear(false, true, clearColor);


        mPaintInUV = new Material(sPaintInUV);
        if (!mPaintInUV.SetPass(0)) Debug.LogError("Invalid Shader Pass: ");
        mPaintInUV.SetTexture("_MainTex", paintedTexture);

        mFixedEdges = new Material(fixIlsandEdgesShader);
        mFixedEdges.SetTexture("_IlsandMap", markedIlsandes);
        mFixedEdges.SetTexture("_MainTex", paintedTexture);

        // ----------------------------------------------

        //cb = new CommandBuffer
        //{
        //    name = "TexturePainting" + id
        //};


        Graphics.SetRenderTarget(runTimeTexture);
        //Graphics.DrawMesh(mToDraw, Matrix4x4.identity, mPaintInUV);

        Graphics.Blit(runTimeTexture, fixedIlsands, mFixedEdges);
        Graphics.Blit(fixedIlsands, runTimeTexture);
        Graphics.Blit(runTimeTexture, paintedTexture);

    }

    public void SetActiveTexture(Camera mainC)
    {
        mainC.AddCommandBuffer(CameraEvent.AfterDepthTexture, cb);
    }

    public void SetInactiveTexture(Camera mainC)
    {
        mainC.RemoveCommandBuffer(CameraEvent.AfterDepthTexture, cb);
    }

    public void UpdateShaderParameters(Matrix4x4 localToWorld)
    {
        mPaintInUV.SetMatrix("mesh_Object2World", localToWorld); // Mus be updated every time the mesh moves, and also at start
    }
}