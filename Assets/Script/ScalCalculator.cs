using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalCalculator
{
    float maxScale = 4f;
    float minScale = 1.2f;
    float obstacleDamageValue = 0.7f;

    public Vector3 CalculatePlayerHeadSize(GateType gateType , int gateValue ,Transform headTrasform)
    {
        float changeSize = gateValue / 100;

        float newXScale = 0;
        float newYScale = 0;
        float newZScale = 0;

        switch (gateType)
        {
            case GateType.fatterType:

                newXScale = headTrasform.localScale.x + changeSize;
                newYScale = headTrasform.localScale.y + changeSize;
                newZScale = headTrasform.localScale.z ;
                if(newXScale > maxScale)
                {
                    newXScale = maxScale;
                }
                if(newYScale > maxScale)
                {
                    newXScale = maxScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);

            case GateType.thinnerType:

                newXScale = headTrasform.localScale.x - changeSize;
                newYScale = headTrasform.localScale.y - changeSize;
                newZScale = headTrasform.localScale.z;

                if(newXScale < minScale)
                {
                    newXScale = minScale;
                }
                if(newYScale < minScale)
                {
                    newYScale = minScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);

            case GateType.tallerType:

                newXScale = headTrasform.localScale.x;
                newYScale = headTrasform.localScale.y;
                newZScale = headTrasform.localScale.z + changeSize;
                if(newZScale > maxScale)
                {
                    newZScale = maxScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);

            case GateType.shorterType:
                newXScale = headTrasform.localScale.x;
                newYScale = headTrasform.localScale.y;
                newZScale = headTrasform.localScale.z - changeSize;

                if(newZScale < minScale)
                {
                    newZScale = minScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);
        }

        return new Vector3(newXScale, newYScale, newZScale);
        
    }

    public Vector3 DecreasePlayerHeadSize(Transform playerTransform)
    {
        float newXScale = playerTransform.localScale.x - obstacleDamageValue;
        float newYScale = playerTransform.localScale.y - obstacleDamageValue;
        float newZscale = playerTransform.localScale.z - obstacleDamageValue;

        if(newXScale < minScale)
        {
            newXScale = minScale;
        }
        if (newYScale < minScale)
        {
            newYScale = minScale;
        }
        if(newZscale < minScale)
        {
            newZscale = minScale;
        }

        return new Vector3(newXScale, newYScale, newZscale);
    }
}
