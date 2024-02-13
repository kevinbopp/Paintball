'Audio Library, copyright © Tyler Cross 2016
'OK, it isn't actually copyright, but still. Yeah, nevermind.

Public Class AudioLibrary
    Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String,
        ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer

    Public oName As String = Nothing

    'Media Library - sets paths of files
    Private Function GetFile(ByVal id As Integer) As String
        Dim strPath As String = ""
        Dim tempPath As String = ""


        ' Spaces cause failure to load (add quotation marks).
        ' Dots in the path can cause failure to load, because the dot marks the beginning of the file extension.
        ' Very long paths will cause failure to load. Maximum 255 char?
        ' Relative paths will cause failure to load.
        ' .wav files will fail to load if "repeat" = true.

        Select Case id
            Case 1 ' SPLAT SOUND ENGAGED
                strPath = "splat1.mp3"  'SPLAT IN YO FACE FOOL
            Case 2 ' GUNFIRE SOUND ENGAGED
                strPath = "gunfire.mp3" 'GUN FIRE IN YO FACE FOOL
            Case 3 ' music 1
                strPath = "bkgd-funky.mp3"
            Case 4 ' music 2
                strPath = "bkgd-insane.mp3"
            Case 5 ' music 3
                strPath = "bkgd-techno.mp3"
            Case 6 ' ammo pickup
                strPath = "ammo-pickup.mp3"
            Case 7 ' victory
                strPath = "victory.mp3"
            Case 8 ' launcher loop
                strPath = "launcherLoop.mp3"
            Case 9 ' health boost sound
                strPath = "healthUp.wav"
            Case 10 ' final ten seconds of game alert
                strPath = "lastTen.wav"
            Case 11 ' moving the cursor
                strPath = "moveCursor.wav"
            Case 12 ' collecting shield power-up
                strPath = "shieldUp.wav"
            Case 13 ' collecting slow power-up
                strPath = "slowDown.mp3"
            Case 14 ' collecting speed power-up
                strPath = "speedUp.mp3"
            Case 15 ' collecting triple shot power-up
                strPath = "tripleUp.wav"
            Case 16 ' button woosh sound when moving
                strPath = "woosh.wav"
        End Select
        tempPath = strPath

        If Strings.Right(Application.StartupPath, 9) = "bin\Debug" Then ' Program is being debugged, locate the audioFiles folder near its bin\Debug folder.
            strPath = Chr(34) & Strings.Left(Application.StartupPath, Strings.Len(Application.StartupPath) - 9) & "audioFiles\" & tempPath & Chr(34)
        Else
            strPath = Chr(34) & Application.StartupPath & "\audioFiles\" & tempPath & Chr(34)
        End If



        'hours of sadness are below in numerous attempts to get the AudioLibary to come bundled with the .exe

        'strPath = Chr(34) & System.IO.Path.GetFullPath(Application.StartupPath) & "\Resources\" & tempPath & Chr(34)
        'strPath = Chr(34) & IO.Path.GetFullPath(My.Resources.ResourceManager.BaseName) & "\" & tempPath & Chr(34)

        'strPath = IO.Path.GetFullPath(My.Resources.ResourceManager.BaseName)
        'strPath = Chr(34) & strPath.Substring(0, strPath.Length - 40) & "Resources\" & tempPath & Chr(34)


        ' path for use with My.Resources Chr(34) is "
        'strPath = Strings.Left(Application.StartupPath, Strings.Len(Application.StartupPath) - 9) & "Resources\" & tempPath



        ' KEVINSLAPTOP strPath = Chr(34) & Application.StartupPath & "\" & tempPath & Chr(34)

        'strPath = Chr(34) & Application.StartupPath & "\Paintball!\" & tempPath & Chr(34)
        'strPath = Chr(34) & IO.Path.GetFullPath(My.Resources.ResourceManager.BaseName) & "\" & tempPath & Chr(34)
        'strPath = Chr(34) & Strings.Left(4, System.IO.Path.GetFullPath(Application.ExecutablePath) & "\" & strPath & Chr(34))
        'MsgBox(strPath)

        Return strPath
    End Function

    Public Property Name As String
        Set(value As String)
            oName = value
        End Set
        Get
            Return oName
        End Get
    End Property

    Public Sub Play(ByVal id As Integer, ByVal blnRepeat As Boolean, Optional intVolume As Integer = 1000)

        ' One for repeating and one not for repeating. 2 sendstrings

        If (blnRepeat = True) Then
            ' Opens file (loads)
            mciSendString("Open " & GetFile(id) & " alias " & oName, CStr(0), 0, 0)
            ' Plays file, repeating (bkgd music)
            mciSendString("play " & oName & " repeat ", CStr(0), 0, 0)
            ' If isn't a sound that repeats (beep sfx, success btnclick, etc., play w/o repeat
        Else
            ' Opens file (loads)
            mciSendString("Open " & GetFile(id) & " alias " & oName, CStr(0), 0, 0)
            ' Plays file, not repeating (simple sfx)
            mciSendString("play " & oName, CStr(0), 0, 0)
        End If
        ' Optionally, Set Volume
        mciSendString("setaudio " & oName & " volume to " & intVolume, CStr(0), 0, 0)
    End Sub

    Public Sub Kill(ByVal music As String)
        mciSendString("close " & music, CStr(0), 0, 0)
        oName = Nothing
    End Sub
End Class
