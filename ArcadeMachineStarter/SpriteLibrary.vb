''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'   SPRITE LIBRARY
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Imports System.Math
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class Sprite

    ' this constant used to convert angle degrees to radians for the Sin() and Cos() functions
    Const PI_OVER_180 As Double = Math.PI / 180.0

    ' Here are all the properties of a sprite

    Public UpperLeft As Point
    Public Size As Point

    Public Angle As Double = 0.0
    Public Velocity As PointF = New PointF(0.0, 0.0)
    Public MaxSpeed As Double = 0.0

    Public IsAlive As Boolean = True
    Public TimeToLive As Integer = -1

    Public loadedImage As System.Drawing.Image

    ' SetCenter calculates and sets the center point of the sprite
    Public Sub SetCenter(ByVal center As Point)
        ' calculate the current UpperLeft of the sprite based on the input center and current Size
        UpperLeft.X = center.X - Size.X / 2
        UpperLeft.Y = center.Y - Size.Y / 2

    End Sub

    ' GetCenter calculates and returns the center point of the sprite
    Public Function GetCenter() As Point
        ' calculate the current center of the sprite based on the current UpperLeft and Size
        Dim center As Point
        center.X = UpperLeft.X + Size.X / 2
        center.Y = UpperLeft.Y + Size.Y / 2
        Return center
    End Function


    ' SetVelocity 
    Public Sub SetVelocity(ByVal speed As Double)
        ' calculate the X and Y velocity components based on the current angle and input speed
        Dim radians As Double = Angle * PI_OVER_180   ' convert current sprite angle to radians

        Velocity.X = speed * Cos(radians)
        Velocity.Y = -speed * Sin(radians) ' -1 corrects for computer's "up"
    End Sub


    ' ChangeAngle
    Public Sub ChangeAngle(ByVal delta As Double)
        ' adjust the sprite's current angle by the input amount (may be positive or negative)
        Angle = Angle + delta

        ' keep the sprite's angle between [0,359] so it's easy to read and understand
        If Angle < 0.0 Then Angle = Angle + 360.0
        If Angle >= 360.0 Then Angle = Angle - 360.0

    End Sub

    ' Accelerate
    Public Sub Accelerate(ByVal acceleration As Double)

        ' calculate overall speed using Pythagorean's theorem:
        ' s*s = x*x + y*y, or s = sqrt(x*x + y*y)

        ' calculate new speed
        Dim radians As Double = Angle * PI_OVER_180   ' convert current sprite angle to radians
        Dim speedX As Single = Velocity.X + acceleration * Cos(radians)
        Dim speedY As Single = Velocity.Y - acceleration * Sin(radians) '- accounts for computer's "up"

        ' update the speed, ensuring it does not exceed the maximum
        UpdateSpeed(speedX, speedY)

    End Sub

    ' Accelerate
    Public Sub Accelerate(ByVal AX As Double, ByVal AY As Double)

        ' calculate new speed
        Dim speedX As Single = Velocity.X + AX
        Dim speedY As Single = Velocity.Y + AY

        ' update the speed, ensuring it does not exceed the maximum
        UpdateSpeed(speedX, speedY)

    End Sub

    Public Sub StopMoving()
        UpdateSpeed(0, 0)
    End Sub

    ' UpdateSpeed is an internal function used to make sure the object is not going
    ' too fast after acceleration
    Private Sub UpdateSpeed(ByVal speedX As Single, ByVal speedY As Single)

        Dim newSpeed As Double = Sqrt(speedX * speedX + speedY * speedY)

        Velocity.X = speedX  ' update the X speed component
        Velocity.Y = speedY  ' update the Y speed component

        ' make sure we don't get going too fast.  
        If (newSpeed > MaxSpeed) Then   ' If new speed exceeds maximum
            ' we want to scale back both the X and Y speed components such that they stay within the max
            Dim reductionFactor As Double = MaxSpeed / newSpeed

            Velocity.X *= reductionFactor    ' reduce X component
            Velocity.Y *= reductionFactor    ' reduce Y component

        End If

    End Sub

    ' MoveAndWrap allows the sprite to leave and return to the screen as in an Asteroids-style game.
    Public Sub MoveAndWrap(ByVal screenSize As Point)

        ' If Time-to-live is configured, reduce it by one
        If (TimeToLive >= 1) Then  '
            TimeToLive -= 1
        ElseIf (TimeToLive = 0) Then    ' if Time-to-live has been reduced to zero, turn off sprite
            IsAlive = False
        End If

        ' see if this sprite is alive
        If (IsAlive <> True) Then
            Return  ' nothing to do if not alive
        End If

        ' create and calculate the new position based on current upper-left coordinate and speed
        Dim newPosition As Point

        newPosition.X = UpperLeft.X + Velocity.X
        newPosition.Y = UpperLeft.Y + Velocity.Y

        ' calculate the sprite's new right and bottom coordinates for wraparound checking
        Dim right As Integer
        Dim bottom As Integer
        right = newPosition.X + Size.X
        bottom = newPosition.Y + Size.Y

        ' wrap left - if sprite is all the way off the left side, 
        ' place it as just coming in from the right side
        If newPosition.X < (0 - Size.X) Then
            newPosition.X = screenSize.X
        End If

        ' wrap right - if sprite is all the way off the right side, 
        ' place it as just coming in from the left side
        If newPosition.X > (screenSize.X) Then
            newPosition.X = 0 - Size.X
        End If

        ' wrap top - if sprite is all the way off the top side, 
        ' place it as just coming in from the bottom side
        If newPosition.Y < (-Size.Y) Then
            newPosition.Y = screenSize.Y
        End If

        ' wrap bottom - if sprite is all the way off the bottom side, 
        ' place it as just coming in from the top side
        If newPosition.Y > (screenSize.Y) Then
            newPosition.Y = 0 - Size.Y
        End If

        ' update the sprite's current UpperLeft coordinates with the final position
        UpperLeft = newPosition

    End Sub


    ' RotatePoint will rotate the second point around the first point according to the current angle.
    ' The second point is actually modified within the function (ByRef and not ByVal).  This function
    ' is used in the Ice Cream Toss game.
    Public Sub RotatePoint(ByVal origin As Point, ByRef thePoint As Point)

        Dim radians As Double = Angle * PI_OVER_180   ' convert current sprite angle to radians

        ' from http://www.vb-helper.com/howto_rotate_polygon_points.html
        ' When you rotate a point (X, Y) around the origin through angle theta, the point's new coordinates (X', Y') are given by: 
        ' X() ' = Cos(angle) * X - Sin(angle) * Y
        ' Y() ' = Sin(angle) * X + Cos(angle) * Y

        ' note the above equations assume "up" is a positive Y direction, when really in computer graphics "up" is negative

        ' first adjust the target point using the origin point as 0,0
        thePoint.X -= origin.X
        thePoint.Y -= origin.Y

        ' now calculate the new point position by rotating around the origin using the angle in radians
        Dim theNewPoint As Point
        theNewPoint.X = thePoint.X * Cos(radians) - thePoint.Y * Sin(radians)
        theNewPoint.Y = -(thePoint.X * Sin(radians) + thePoint.Y * Cos(radians)) ' correct for computer "up" by making this negative

        ' now translate new point back to the origin, and update the output point
        thePoint.X = theNewPoint.X + origin.X
        thePoint.Y = theNewPoint.Y + origin.Y

    End Sub


    ' GetBoundingRectangle 
    Public Function GetBoundingRectangle() As Rectangle
        Return New Rectangle(UpperLeft.X, UpperLeft.Y, Size.X, Size.Y)
    End Function

    Private Function ShrinkRectangle(ByVal rect As Rectangle, ByVal factor As Double) As Rectangle
        If (factor > 1.0) Then
            factor = 1.0
        End If
        If (factor < 0.0) Then
            factor = 0.0
        End If

        Dim newRect As Rectangle
        newRect.Width = rect.Width * factor
        newRect.Height = rect.Height * factor
        newRect.X = rect.X + (rect.Width - newRect.Width) / 2
        newRect.Y = rect.Y + (rect.Height - newRect.Height) / 2

        Return newRect

    End Function

    ' IsCollided returns a boolean value for a collision between two sprites
    Public Function IsCollided(ByRef otherSprite As Sprite) As Boolean


        If (IsAlive <> True) Then
            Return False    ' this sprite is not active, can't possibly collide
        End If


        If (otherSprite.IsAlive <> True) Then
            Return False    ' other sprite is not active, can't possibly collide
        End If

        Dim thisRect As Rectangle = GetBoundingRectangle()
        Dim otherRect As Rectangle = otherSprite.GetBoundingRectangle()

        ' if the bounding rectangles of the sprite intersect
        If (thisRect.IntersectsWith(otherRect)) Then
            Return True ' there was a collision!
        End If

        ' no collision!
        Return False
    End Function

    'Move is the standard movement sub for moving a sprite around the screen
    Public Sub Move(ByVal screenSize As Point)
        ' reduce Time-to-live if configured
        '''''If (TimeToLive >= 1) Then
        '''''    TimeToLive -= 1
        '''''ElseIf (TimeToLive = 0) Then
        '''''    IsAlive = False
        '''''End If

        ' see if this sprite is alive
        If (IsAlive <> True) Then
            Return  ' nothing to do if not alive
        End If

        ' create and calculate the new position based on current upper-left coordinate and speed
        Dim newPosition As Point

        newPosition.X = UpperLeft.X + Velocity.X
        newPosition.Y = UpperLeft.Y + Velocity.Y

        ' calculate the sprite's new right and bottom coordinates for boundary checking
        Dim right As Integer
        Dim bottom As Integer
        right = newPosition.X + Size.X
        bottom = newPosition.Y + Size.Y

        If frmGameScreen.blnGameIsStarted = True Then
            If frmGameScreen.p1Sprite.UpperLeft.X < 0 Then
                frmGameScreen.p1Sprite.UpperLeft.X = 0
            End If

            If frmGameScreen.p1Sprite.UpperLeft.X > 764 Then
                frmGameScreen.p1Sprite.UpperLeft.X = 764
            End If

            If frmGameScreen.p2Sprite.UpperLeft.X < 6 Then
                frmGameScreen.p2Sprite.UpperLeft.X = 6
            End If

            If frmGameScreen.p2Sprite.UpperLeft.X > 759 Then
                frmGameScreen.p2Sprite.UpperLeft.X = 759
            End If

            'If newPosition.X < 0 Or right > screenSize.X Then
            '    If newPosition.X < 0 Then
            '        newPosition.X = -6

            '        For Each shot In frmGameScreen.p1Shots
            '            newPosition.X -= 6
            '        Next

            '        For Each shot In frmGameScreen.p2Shots
            '            newPosition.X -= 6
            '        Next
            '    ElseIf right > screenSize.X Then
            '        'newPosition.X = right - 46
            '        For Each shot In frmGameScreen.p1Shots
            '            newPosition.X += 6
            '        Next

            '        For Each shot In frmGameScreen.p2Shots
            '            newPosition.X += 6
            '        Next
            '    End If
            'End If

            If newPosition.Y < 0 Or bottom > screenSize.Y Then
                If newPosition.Y < 0 Then
                    newPosition.Y = 556
                ElseIf bottom > screenSize.Y Then
                    bottom = 0
                End If
            End If

            ' update the sprite's current UpperLeft coordinates with the final position
            UpperLeft = New Point(newPosition)
        End If

    End Sub

    ' SetImage is used to set the image for a sprite
    Public Sub SetImage(ByVal filename As String)
        ' load the image from disk when we are given the filename,
        ' and then pass that resource to SetImageResource
        SetImageResource(Image.FromFile(filename))
    End Sub

    ' SetImageResource
    Public Sub SetImageResource(ByVal resourceName As System.Drawing.Image)
        ' save the loaded image
        loadedImage = resourceName

        '  automatically adjust the current size to match
        Size.X = loadedImage.Size.Width
        Size.Y = loadedImage.Size.Height
    End Sub

    ' PaintImageWithRotation is first used in the BubbleBlaster game to rotate the player's ship.
    ' It can be used on any sprite.  Pass in the Graphicsobject, the angle to rotate,
    ' the point around which to rotate, and a transparency flag, and this function
    ' will take care of all the rotation math.
    Public Sub PaintRotatedImage(ByRef myGraphics As System.Drawing.Graphics,
                                 ByVal angle As Double, ByVal origin As Point,
                                 ByVal transparent As Boolean)

        ' don't do anything if this sprite is not alive!
        If (Not IsAlive) Then
            Return
        End If

        ' in order to rotate an image, we need to do some fancy matrix math
        Dim spriteMatrix As Matrix = New Matrix()
        spriteMatrix.RotateAt(-angle, origin)

        ' temporarily adjust the Graphics transformation to rotate painted images
        myGraphics.Transform = spriteMatrix

        ' now paint the image
        PaintImage(myGraphics, transparent)

        ' undo the matrix transformation on the Graphics object
        myGraphics.ResetTransform()

    End Sub

    ' PaintImage
    Public Sub PaintImage(ByRef myGraphics As System.Drawing.Graphics, ByVal transparent As Boolean)

        ' don't do anything if this sprite is not alive!
        If (Not IsAlive) Then
            Return
        End If

        Dim transparency As New ImageAttributes

        If transparent Then
            transparency.SetColorKey(Color.White, Color.White)
        End If

        ' if we loaded an image successfully
        If (loadedImage IsNot Nothing) Then
            Dim boundingRectangle = GetBoundingRectangle()

            If transparent = False Then
                'draw the image using the current location and size to the provided Graphics context 
                myGraphics.DrawImage(loadedImage, boundingRectangle)

            Else
                myGraphics.DrawImage(loadedImage, boundingRectangle, 0, 0, loadedImage.Width, loadedImage.Height, GraphicsUnit.Pixel, transparency)
            End If
        End If
    End Sub
End Class

