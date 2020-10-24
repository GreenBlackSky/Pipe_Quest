﻿using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;


[XmlRoot("reply")]
public class DialogueReply {
    [XmlElement("text")]
    public string text;

    [XmlElement("nextLineUID")]
    public int nextLineUID;

    public DialogueReply() {
        text = "";
        nextLineUID = -1;
    }
    // TODO connect reply, disconnect reply
}

[XmlRoot("line")]
public class DialogueNode {
    [XmlElement("uid")]
    public int lineUID;

    [XmlElement("speakerUID")]
    public string speakerUID;

    [XmlElement("text")]
    public string text;

    [XmlArray("replies")]
    [XmlArrayItem("reply")]
    public List<DialogueReply> replies;

    public DialogueReply AddReply() {
        DialogueReply reply = new DialogueReply();
        replies.Add(reply);
        return reply;
    }
    // TODO Remove reply, connect, diconnect
}