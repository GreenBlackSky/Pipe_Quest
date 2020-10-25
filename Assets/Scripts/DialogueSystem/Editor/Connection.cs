﻿using System;
using UnityEditor;
using UnityEngine;
 
public class Connection {
    public ConnectionPoint inPoint;
    public ConnectionPoint outPoint;
    public Action<Connection> OnClickRemoveConnection;
 
    public Connection(ConnectionPoint inPoint, ConnectionPoint outPoint, Action<Connection> OnClickRemoveConnection) {
        this.inPoint = inPoint;
        inPoint.connections.Add(this);
        this.outPoint = outPoint;
        outPoint.connections.Add(this);
        this.OnClickRemoveConnection = OnClickRemoveConnection;
        outPoint.replyParent.nextLineUID = inPoint.parent.lineUID;
    }
 
    public void Draw() {
        Handles.DrawBezier(
            inPoint.rect.center,
            outPoint.rect.center,
            inPoint.rect.center + Vector2.left * 50f,
            outPoint.rect.center - Vector2.left * 50f,
            Color.white,
            null,
            2f
        );
 
        if (Handles.Button((inPoint.rect.center + outPoint.rect.center) * 0.5f, Quaternion.identity, 4, 8, Handles.RectangleHandleCap)) {
            if (OnClickRemoveConnection != null) {
                OnClickRemoveConnection(this);
            }
        }
    }

    public void Destroy() {
        inPoint.connections.Remove(this);
        outPoint.replyParent.nextLineUID = -1;
    }
}