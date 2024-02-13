'Kevin Bopp
'Period 8
'Last Updated: 11/12/2016
'Paintball! v2.0 - Indie Game Project

'##################################
'###   Paintball! Version 2.0   ###
'##################################
' Complete with crouching, new animations, bug fixes, a main menu, options, a how-to section, tweaks, sound effects, rewritten power-ups, a game timer, and more!

' Paintball! has been completed. On November 12, 2016, at 12:46 PM, it was deployed and released. It will no longer be updated.
' Goodbye. It's on to Unity, now.

Public Class frmGameScreen

    ' Redoing the powerup system: I need these at the top for easy reference.

    Dim p1IsTripled As Boolean = False
    Dim p2IsTripled As Boolean = False

    Dim p1IsShielded As Boolean = False
    Dim p2IsShielded As Boolean = False

    Dim GameIsSpedUp As Boolean = False
    Dim GameIsSlowedDown As Boolean = False

    Dim charGameState As Char = "N" ' normal, S is fast, s is slow

    Dim blnP1CanBeHit As Boolean = True
    Dim blnP2CanBeHit As Boolean = True

    Dim shootDelayIsActive As Boolean = True

    Dim trophySprite As New Sprite

    Dim intReturnToMenuTick As Integer = 0
    Dim strHeadingToMenuText As String = ""

    'Dim blnCursorGlitched As Boolean = True

    Dim strVictoryButtonShot As String = ""

    Dim blnScreenCanChange As Boolean = False

    Dim blnYesCanMove As Boolean = False
    Dim blnNoCanMove As Boolean = False

    Dim intMoveVictoryButtonsTick As Integer = 0

    Dim winnerTextSprite As New Sprite
    Dim playAgainSprite As New Sprite

    Dim yesSprite As New Sprite
    Dim noSprite As New Sprite

    Dim intBobPowerUpsTick As Integer = 0
    Dim blnMinuteChanged As Boolean = False
    Dim strTimeLeft As String

    Dim strWinner As String

    Dim p1UpperLeftY As Integer
    Dim p2UpperLeftY As Integer

    Dim intPlayer1StandUpTick As Integer = 0
    Dim intPlayer2StandUpTick As Integer = 0

    Dim intPlayer1StartCrouchTick As Integer = 0
    Dim intPlayer2StartCrouchTick As Integer = 0

    Public musicVolume As Integer = 750
    Public sfxVolume As Integer = 1000
    Public gameTime As Integer = 130

    Dim p1IsCrouching As Boolean = False
    Dim p2IsCrouching As Boolean = True

    Dim fiveMin As New Sprite
    Dim tenMin As New Sprite
    Dim twoHalfMin As New Sprite
    Dim noMin As New Sprite

    Dim musicMax As New Sprite
    Dim music75 As New Sprite
    Dim music50 As New Sprite
    Dim music25 As New Sprite
    Dim musicMuted As New Sprite

    Dim sfxMax As New Sprite
    Dim sfx75 As New Sprite
    Dim sfx50 As New Sprite
    Dim sfx25 As New Sprite
    Dim sfxMuted As New Sprite

    Dim pupsEnabled As New Sprite
    Dim pupsDisabled As New Sprite

    Dim strButtonDirection As String = "STATIC"
    Dim strButtonShot As String
    Dim strOptionButtonShot As String

    Dim strCurrentMenu As String = ""

    Dim picOptionsTabSprite As New Sprite
    Dim picOptions1Sprite As New Sprite
    Dim picOptions2Sprite As New Sprite
    Dim picOptions3Sprite As New Sprite

    Dim intMoveOptionsButtonsLeftTick As Integer = 0
    Dim intMoveOptionsButtonsRightTick As Integer = 0

    Dim blnFirstORowCanMove As Boolean = False
    Dim blnSecondORowCanMove As Boolean = False
    Dim blnThirdORowCanMove As Boolean = False
    Dim blnFourthORowCanMove As Boolean = False

    Dim picGetReadySprite As New Sprite

    Dim intGetReadyTextSize As Integer = 100

    Dim strGetReady As String = ""

    Dim intGetReadyTick As Integer = 0

    Dim blnPicGetReadyCanMove As Boolean = False

    Dim intMoveMMButtonsLeftTick As Integer = 0
    Dim intMoveMMButtonsRightTick As Integer = 0

    Dim blnFirstCanMove As Boolean = False
    Dim blnSecondCanMove As Boolean = False
    Dim blnThirdCanMove As Boolean = False
    Dim blnFourthCanMove As Boolean = False

    Dim cursorRightIdleFrame As Integer = 1
    Dim cursorShootPoint As New Point()
    Dim cursorAmmo As Integer = 15
    Public cursorShots(cursorAmmo - 1) As Sprite

    Dim picPlaySprite As New Sprite
    Dim picHTPSprite As New Sprite
    Dim picOptionsSprite As New Sprite
    Dim picArcadeSprite As New Sprite

    Dim blnCursorHasShot As Boolean = False

    'SPLASH STUFF
    Dim tmrOptionsTick As Integer = 0
    Dim tmrFromOptionsToMMTick As Integer = 0
    Dim tmrSplashPulseTick As Integer = 0
    Dim intSplashSize As Integer = 16

    Dim strSplash As String
    Dim intSplash As Integer
    Dim rdmSplash As New Random()


    Dim launcherBkgdSprite As New Sprite
    Public backgroundImageSprite As Sprite
    Dim cursorSprite As New Sprite

    Dim TheResetBug As Boolean = True

    Public blnPUPsEnabled As Boolean = True

    Public blnGameIsStarted As Boolean = False

    Dim p1ShootPoint As New Point
    Dim p2ShootPoint As New Point

    Public p1Ammo As Integer = 10
    Public p2Ammo As Integer = 10

    Public p1Shots(p1Ammo - 1) As Sprite
    Public p2Shots(p2Ammo - 1) As Sprite

    Dim p1RightIdleFrame As Integer = 1
    Dim p1LeftIdleFrame As Integer = 1

    Dim p2RightIdleFrame As Integer = 1
    Dim p2LeftIdleFrame As Integer = 1

    Dim p1RightRunFrame As Integer = 1
    Dim p1LeftRunFrame As Integer = 1

    Dim p2RightRunFrame As Integer = 1
    Dim p2LeftRunFrame As Integer = 1
    '################################################################################ Platform sprites ################################################################################


    ' Floor 1 (bottom floor) one BIG sprite to rule them all (the stinkin' bottom floor of the game)
    Dim mainPlatformSprite As New Sprite
    Dim rectMainPlatform As New Rectangle

    ' Floor 2, TWO in from the LEFT
    Dim spritePlatform2 As New Sprite
    Dim rectPlatform2 As New Rectangle

    ' Floor 2, ONE in from the LEFT
    Dim spritePlatform3 As New Sprite
    Dim rectPlatform3 As New Rectangle

    Dim spritePlatform4 As New Sprite
    Dim rectPlatform4 As New Rectangle

    Dim spritePlatform5 As New Sprite
    Dim rectPlatform5 As New Rectangle

    ' FLOOR 3
    Dim spritePlatform6 As New Sprite
    Dim rectPlatform6 As New Rectangle

    Dim spritePlatform7 As New Sprite
    Dim rectPlatform7 As New Rectangle

    Dim spritePlatform8 As New Sprite
    Dim rectPlatform8 As New Rectangle

    ' FLOOR 4 \/
    Dim spritePlatform9 As New Sprite
    Dim rectPlatform9 As New Rectangle

    Dim spritePlatform10 As New Sprite
    Dim rectPlatform10 As New Rectangle

    Dim spritePlatform11 As New Sprite
    Dim rectPlatform11 As New Rectangle

    ' Top wall for hitting head
    Dim spriteTopWall As New Sprite
    Dim rectTopWall As New Rectangle

    Dim rectInvisibleRightWall As New Rectangle
    Dim rectInvisibleLeftWall As New Rectangle

    'Powerup sprites
    Dim testPowerUpSprite As New Sprite

    'Player sprites
    Public p1Sprite As Sprite
    Public p2Sprite As Sprite
    'player rectangles for collisions
    Dim rectPlayer1 As New Rectangle
    Dim rectPlayer2 As New Rectangle

    Dim MAX_SPEED As Double = 10.0
    Dim ACCELERATION As Double = 1.5


    Dim p1ComingUp As Boolean = False
    Dim p1ComingDown As Boolean = False

    Dim p1HitHead As Boolean = False
    Dim p2HitHead As Boolean = False

    'p1 movement
    Dim p1UpIsPressed As Boolean
    Dim p1DownIsPressed As Boolean
    Dim p1LeftIsPressed As Boolean
    Dim p1RightIsPressed As Boolean

    Dim p1Dir As String = "Right"

    Dim p1MovedLeftMidair As Boolean = False
    Dim p1MovedRightMidair As Boolean = False
    '{"Right", "Left", "RightUp", "LeftUp", "Up", "RunningRightUp", "RunningLeftUp", "RightDown", "LeftDown", "RunningRightDown", "RunningLeftDown"}


    Dim p1NoKeysPressed As Boolean = True
    Dim p1IsMoving As Boolean = False
    Dim p1IsJumping As Integer = 0
    Dim p1IsOnGround As Boolean = True

    Dim p1StartDroppingRightFromJump As Boolean = False
    Dim p1StartDroppingLeftFromJump As Boolean = False

    'p1 controls
    Dim p1YellowIsPressed As Boolean
    Dim p1WhiteIsPressed As Boolean
    Dim p1BlueIsPressed As Boolean
    Dim p1RedIsPressed As Boolean

    'p2 movement
    Dim p2UpIsPressed As Boolean
    Dim p2DownIsPressed As Boolean
    Dim p2LeftIsPressed As Boolean
    Dim p2RightIsPressed As Boolean

    Dim p2Dir As String = "Left"
    '{"Right", "Left", "RightUp", "LeftUp", "Up"}


    Dim p2NoKeysPressed As Boolean = True
    Dim p2IsMoving As Boolean = False
    Dim p2IsJumping As Integer = 0 ' 0 jump up, 1 fall down, 2 not jumping
    Dim p2IsOnGround As Boolean = True

    'p2 controls
    Dim p2YellowIsPressed As Boolean
    Dim p2WhiteIsPressed As Boolean
    Dim p2BlueIsPressed As Boolean
    Dim p2RedIsPressed As Boolean

    Dim p2ComingUp As Boolean = False
    Dim p2ComingDown As Boolean = False

    Dim p2tmrStandingJumpRightIsRunning As Boolean = False
    Dim p2tmrStandingJumpLeftIsRunning As Boolean = False

    Dim p2StartDroppingRightFromJump As Boolean = False
    Dim p2StartDroppingLeftFromJump As Boolean = False

    Dim p2ReachedStandingJumpPeak As Boolean = False
    Dim p2ReachedRunningJumpPeak As Boolean = False


    Dim p2StandingJumpRightCurrentTick As Integer = 0
    Dim p2StandingJumpLeftCurrentTick As Integer = 0
    Dim gameIsStopped As Boolean

    Dim p1_blnIsJumping As Boolean = False
    Dim p2_blnIsJumping As Boolean = False

    Dim p1CollidedPlatformSide As Boolean = False
    Dim p2CollidedPlatformSide As Boolean = False

    Dim p1start As Integer
    Dim p2start As Integer

    Public sound As New AudioLibrary
    Public intSound As Integer = 0

    Dim restartGameTick As Integer = 0

    '#############################################
    '####### POWER-UPS AND POWER-UP TIMERS #######
    '#############################################

    ' Timer interval: 20 seconds, or 25 seconds, or 30 or 18.
    ' 20000, 25000, 30000, 18000

    Dim rdmPowerUpX As Random = New Random() ' chooses a random X value
    Dim intPowerUpX As Integer ' stores a random X value

    Dim rdmNumberFloorPowerUps As Random = New Random() ' chooses either 0, 1, or 2 powerups to appear per floor
    Dim intNumberFloorPowerUps As Integer ' stores random number

    Dim rdmPowerUp As Random = New Random() ' picks a random powerup to appear
    Dim intPowerUp As Integer ' stores a random powerup to appear

    Dim rdmMusic As Random = New Random()
    Dim intMusic As Integer

    ' Two per type of powerup.
    Dim powerup_speed_1 As New Sprite
    Dim powerup_speed_2 As New Sprite
    Dim powerup_health_3 As New Sprite
    Dim powerup_health_4 As New Sprite
    Dim powerup_health_5 As New Sprite
    Dim powerup_ammo_6 As New Sprite
    Dim powerup_ammo_7 As New Sprite
    Dim powerup_ammo_8 As New Sprite
    Dim powerup_slow_9 As New Sprite
    Dim powerup_slow_10 As New Sprite
    Dim powerup_shield_11 As New Sprite
    Dim powerup_shield_12 As New Sprite
    Dim powerup_triple_13 As New Sprite
    Dim powerup_triple_14 As New Sprite

    Dim spriteInvisibleRightWall As New Sprite
    Dim spriteInvisibleLeftWall As New Sprite

    Public powerUpDump As New List(Of Integer)(New Integer() {}) 'empty list to hold powerups
    Public powerUpsAlive As New List(Of Sprite)(New Sprite() {}) 'empty list to hold currently alive powerups
    'Speed, Slow, Ammo, Health, Triple, Shield
    ' Ideas: Rapid, Target, UpDown

    Dim blnTimeToStartPowerUps As Boolean = False

    Dim intRandomColorForLoading As Integer
    Dim rdmColorForLoading As New Random()

    Dim tmrLoadGameTick As Integer = 0

    Dim blnFancy As Boolean = False

    Dim strOptionsDirection As String = ""
    Dim cursorLeftIdleFrame As Integer = 1

    Dim intShowHTPTick As Integer = 0

    Dim htpShoot As New Sprite
    Dim htpMove As New Sprite
    Dim htpRun As New Sprite
    Dim htpJump As New Sprite
    Dim htpTime As New Sprite

    Private Sub frmGameScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '##################################
        '###   Paintball! Version 2.0   ###
        '##################################

        'This version will feature a loading screen, settings menu, map chooser, and more.
        'As such, don't *start* the game just yet! We'll just show the players a fake loading bar. Muahaha!

        intRandomColorForLoading = rdmColorForLoading.Next(0, 2)

        Select Case intRandomColorForLoading
            Case 0
                picLoadingStickfigure.Image = My.Resources.loadingRed
            Case 1
                picLoadingStickfigure.Image = My.Resources.loadingBlue
        End Select

        'Pick a random splash! Because the application restarts on game end, it'll pick a new one every time. No need to make a SplashDump List, because...well, there's a lot of splashes.
        'It'd be pretty interesting if it actually repeated, like, often.

        RandomSplash()

        tmrLoadGame.Start()

    End Sub

    Public Sub HaltSound()
        For i = 0 To intSound
            sound.Kill("sound" & i)
        Next
    End Sub

    Private Sub StartGame()

        If TheResetBug = False Then
            Exit Sub
        End If

        HaltSound()

        shootDelayIsActive = True
        tmrShootDelay.Start()

        p2IsCrouching = False

        p1HealthBar.ForeColor = Color.Red
        p2HealthBar.ForeColor = Color.Blue

        Select Case gameTime
            Case -1
                ' We won't be running the timer. Do nothing.
            Case 130
                strTimeLeft = "1:30"
            Case 230
                strTimeLeft = "2:30"
            Case 500
                strTimeLeft = "5:00"
            Case 1000
                strTimeLeft = "10:00"
        End Select

        'Show all the labels! All of them!
        p1HealthBar.Show()
        p1HealthIs.Show()
        p2HealthBar.Show()
        p2HealthIs.Show()
        lblPlayer1Ammo.Show()
        lblPlayer2Ammo.Show()
        picPlayer1ActivePUP.Show()
        picPlayer2ActivePUP.Show()
        picGameSpeed.Image = Nothing
        picGameSpeed.Show()

        p1Dir = "Right"
        p2Dir = "Left"

        intMusic = rdmMusic.Next(1, 4)
        Select Case intMusic
            Case 1
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(3, True, musicVolume)
                End With
            Case 2
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(4, True, musicVolume)
                End With
            Case Else
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(5, True, musicVolume)
                End With
        End Select
        If blnPUPsEnabled = True Then
            p1Ammo = 100
            ReDim Preserve p1Shots(p1Ammo - 1)
            p2Ammo = 100
            ReDim Preserve p2Shots(p2Ammo - 1)
            lblPlayer1Ammo.Text = "AMMO: " & p1Ammo
            lblPlayer2Ammo.Text = "AMMO: " & p2Ammo
        Else ' Better have unlimited ammo!
            lblPlayer1Ammo.Text = "AMMO: Unlimited!"
            lblPlayer2Ammo.Text = "AMMO: Unlimited!"
            p1Ammo = 50
            ReDim Preserve p1Shots(p1Ammo - 1)
            p2Ammo = 50
            ReDim Preserve p2Shots(p2Ammo - 1)
        End If

        gameIsStopped = False

        p1tmrRightIdle.Start()
        p2tmrLeftIdle.Start()

        p1tmrJump.Start()
        p2tmrJump.Start()

        If blnPUPsEnabled Then
            tmrRandomizePowerUps.Start()
        End If

        InitializeBackground()
        InitializePlayer1Shots(0)
        InitializePlayer2Shots(0)
        InitializePlayer1()
        InitializePlayer2()
        InitializePlatforms()
        InitializePowerUps()

        Invalidate()

        If gameTime = -1 Then
            ' Don't start the timer.
        Else
            tmrGameTimeLeft.Start()
        End If

        GameTimer.Start()
        'powerupstimer.start()
        'Jump timers automatically enabled and checking for jumps.
        'START ANIMATION TIMERS CHECK IF RUNNING, BEGIN ANIMATION
    End Sub

    Private Sub InitializeBackground()
        backgroundImageSprite = New Sprite
        backgroundImageSprite.IsAlive = True
        backgroundImageSprite.TimeToLive = -1
        backgroundImageSprite.SetImageResource(My.Resources.frmBkgd)
        backgroundImageSprite.UpperLeft.X = 0
        backgroundImageSprite.UpperLeft.Y = 0
    End Sub

    Private Sub InitializePlayer1()
        p1Sprite = New Sprite
        p1Sprite.IsAlive = True
        p1Sprite.TimeToLive = -1
        p1Sprite.SetImageResource(My.Resources.redRightIdle1)
        p1Sprite.MaxSpeed = MAX_SPEED
        p1Sprite.Angle = 0      ' Faces right towards player 1 ----- ANGLE WILL NOT BE USED LATER. This is to set the starting angle of the stickman.

        p1Sprite.UpperLeft.X = 45
        p1Sprite.UpperLeft.Y = 433
    End Sub

    Private Sub InitializePlayer2()
        p2Sprite = New Sprite
        p2Sprite.IsAlive = True
        p2Sprite.TimeToLive = -1
        'p2Sprite.SetImageResource(My.Resources.oneblue)
        p2Sprite.MaxSpeed = MAX_SPEED
        p2Sprite.Angle = 0    ' Faces left towards player 1

        p2Sprite.UpperLeft.X = 719
        p2Sprite.UpperLeft.Y = 433
    End Sub

    Private Sub InitializePlatforms()
        'Right wall
        spriteInvisibleRightWall = New Sprite
        spriteInvisibleRightWall.IsAlive = True
        spriteInvisibleRightWall.SetImageResource(My.Resources.InvisibleSideWall)
        spriteInvisibleRightWall.UpperLeft.X = 800
        spriteInvisibleRightWall.UpperLeft.Y = 0

        'Left wall
        spriteInvisibleLeftWall = New Sprite
        spriteInvisibleLeftWall.IsAlive = True
        spriteInvisibleLeftWall.SetImageResource(My.Resources.InvisibleSideWall)
        spriteInvisibleLeftWall.UpperLeft.X = 0
        spriteInvisibleLeftWall.UpperLeft.Y = 0

        'Top wall
        spriteTopWall = New Sprite
        spriteTopWall.IsAlive = True
        spriteTopWall.SetImageResource(My.Resources.invisibleTopWall)
        spriteTopWall.UpperLeft.X = 0
        spriteTopWall.UpperLeft.Y = 0

        'floor 2 platform 1
        spritePlatform2 = New Sprite
        spritePlatform2.IsAlive = True
        spritePlatform2.SetImageResource(My.Resources.Pf1)
        spritePlatform2.UpperLeft.X = 200
        spritePlatform2.UpperLeft.Y = 360

        'floor 2 platform 2 first from left
        spritePlatform3 = New Sprite
        spritePlatform3.IsAlive = True
        spritePlatform3.SetImageResource(My.Resources.Pf3)
        spritePlatform3.UpperLeft.X = 0
        spritePlatform3.UpperLeft.Y = 360

        'floor 2 platform 3 second from right
        spritePlatform4 = New Sprite
        spritePlatform4.IsAlive = True
        spritePlatform4.SetImageResource(My.Resources.Pf4)
        spritePlatform4.UpperLeft.X = 440
        spritePlatform4.UpperLeft.Y = 360

        'floor 2 platform 4 first from right
        spritePlatform5 = New Sprite
        spritePlatform5.IsAlive = True
        spritePlatform5.SetImageResource(My.Resources.Pf5)
        spritePlatform5.UpperLeft.X = 720
        spritePlatform5.UpperLeft.Y = 360

        'floor 3 platform 6 first in
        spritePlatform6 = New Sprite
        spritePlatform6.IsAlive = True
        spritePlatform6.SetImageResource(My.Resources.Pf6)
        spritePlatform6.UpperLeft.X = 0
        spritePlatform6.UpperLeft.Y = 240

        'floor 3 platform 7 second in
        spritePlatform7 = New Sprite
        spritePlatform7.IsAlive = True
        spritePlatform7.SetImageResource(My.Resources.Pf7)
        spritePlatform7.UpperLeft.X = 360
        spritePlatform7.UpperLeft.Y = 240

        'floor 3 platform 8 third in
        spritePlatform8 = New Sprite
        spritePlatform8.IsAlive = True
        spritePlatform8.SetImageResource(My.Resources.Pf8)
        spritePlatform8.UpperLeft.X = 560
        spritePlatform8.UpperLeft.Y = 240

        'floor 4 platform 9 first in
        spritePlatform9 = New Sprite
        spritePlatform9.IsAlive = True
        spritePlatform9.SetImageResource(My.Resources.Pf9)
        spritePlatform9.UpperLeft.X = 80
        spritePlatform9.UpperLeft.Y = 120

        'floor 4 platform 10 second in
        spritePlatform10 = New Sprite
        spritePlatform10.IsAlive = True
        spritePlatform10.SetImageResource(My.Resources.Pf10)
        spritePlatform10.UpperLeft.X = 320
        spritePlatform10.UpperLeft.Y = 120

        'floor 4 platform 11 third in
        spritePlatform11 = New Sprite
        spritePlatform11.IsAlive = True
        spritePlatform11.SetImageResource(My.Resources.Pf11)
        spritePlatform11.UpperLeft.X = 600
        spritePlatform11.UpperLeft.Y = 120

        'main floor
        mainPlatformSprite = New Sprite
        mainPlatformSprite.IsAlive = True
        mainPlatformSprite.SetImageResource(My.Resources.mainFloor)
        mainPlatformSprite.MaxSpeed = MAX_SPEED
        mainPlatformSprite.Angle = 0

        mainPlatformSprite.UpperLeft.X = 0
        mainPlatformSprite.UpperLeft.Y = 480

        '###########################################
        'bounding rectangles around sprites for collision detection
        '###########################################
        rectMainPlatform = mainPlatformSprite.GetBoundingRectangle()
        rectPlatform2 = spritePlatform2.GetBoundingRectangle()
        rectPlatform3 = spritePlatform3.GetBoundingRectangle()
        rectPlatform4 = spritePlatform4.GetBoundingRectangle()
        rectPlatform5 = spritePlatform5.GetBoundingRectangle()
        rectPlatform6 = spritePlatform6.GetBoundingRectangle()
        rectPlatform7 = spritePlatform7.GetBoundingRectangle()
        rectPlatform8 = spritePlatform8.GetBoundingRectangle()
        rectPlatform9 = spritePlatform9.GetBoundingRectangle()
        rectPlatform10 = spritePlatform10.GetBoundingRectangle()
        rectPlatform11 = spritePlatform11.GetBoundingRectangle()
        rectTopWall = spriteTopWall.GetBoundingRectangle()
        rectInvisibleLeftWall = spriteInvisibleLeftWall.GetBoundingRectangle()
        rectInvisibleRightWall = spriteInvisibleRightWall.GetBoundingRectangle()
    End Sub

    '####################################### POWER UPS - COLLISIONS DETECTED IN PLAYER COLLISIONS ########################
    Private Sub InitializePowerUps()
        powerup_speed_1 = New Sprite
        powerup_speed_1.IsAlive = False
        powerup_speed_1.SetImageResource(My.Resources.powerup_speedup)
        powerup_speed_1.MaxSpeed = MAX_SPEED
        powerup_speed_1.Angle = 0

        powerup_speed_2 = New Sprite
        powerup_speed_2.IsAlive = False
        powerup_speed_2.SetImageResource(My.Resources.powerup_speedup)
        powerup_speed_2.MaxSpeed = MAX_SPEED
        powerup_speed_2.Angle = 0

        powerup_health_3 = New Sprite
        powerup_health_3.IsAlive = False
        powerup_health_3.SetImageResource(My.Resources.powerup_health)
        powerup_health_3.MaxSpeed = MAX_SPEED
        powerup_health_3.Angle = 0

        powerup_health_4 = New Sprite
        powerup_health_4.IsAlive = False
        powerup_health_4.SetImageResource(My.Resources.powerup_health)
        powerup_health_4.MaxSpeed = MAX_SPEED
        powerup_health_4.Angle = 0

        powerup_health_5 = New Sprite
        powerup_health_5.IsAlive = False
        powerup_health_5.SetImageResource(My.Resources.powerup_health)
        powerup_health_5.MaxSpeed = MAX_SPEED
        powerup_health_5.Angle = 0

        powerup_ammo_6 = New Sprite
        powerup_ammo_6.IsAlive = False
        powerup_ammo_6.SetImageResource(My.Resources.powerup_ammo)
        powerup_ammo_6.MaxSpeed = MAX_SPEED
        powerup_ammo_6.Angle = 0

        powerup_ammo_7 = New Sprite
        powerup_ammo_7.IsAlive = False
        powerup_ammo_7.SetImageResource(My.Resources.powerup_ammo)
        powerup_ammo_7.MaxSpeed = MAX_SPEED
        powerup_ammo_7.Angle = 0

        powerup_ammo_8 = New Sprite
        powerup_ammo_8.IsAlive = False
        powerup_ammo_8.SetImageResource(My.Resources.powerup_ammo)
        powerup_ammo_8.MaxSpeed = MAX_SPEED
        powerup_ammo_8.Angle = 0

        powerup_slow_9 = New Sprite
        powerup_slow_9.IsAlive = False
        powerup_slow_9.SetImageResource(My.Resources.powerup_slowdown)
        powerup_slow_9.MaxSpeed = MAX_SPEED
        powerup_slow_9.Angle = 0

        powerup_slow_10 = New Sprite
        powerup_slow_10.IsAlive = False
        powerup_slow_10.SetImageResource(My.Resources.powerup_slowdown)
        powerup_slow_10.MaxSpeed = MAX_SPEED
        powerup_slow_10.Angle = 0

        powerup_shield_11 = New Sprite
        powerup_shield_11.IsAlive = False
        powerup_shield_11.SetImageResource(My.Resources.powerup_shield)
        powerup_shield_11.MaxSpeed = MAX_SPEED
        powerup_shield_11.Angle = 0

        powerup_shield_12 = New Sprite
        powerup_shield_12.IsAlive = False
        powerup_shield_12.SetImageResource(My.Resources.powerup_shield)
        powerup_shield_12.MaxSpeed = MAX_SPEED
        powerup_shield_12.Angle = 0

        powerup_triple_13 = New Sprite
        powerup_triple_13.IsAlive = False
        powerup_triple_13.SetImageResource(My.Resources.powerup_triple)
        powerup_triple_13.MaxSpeed = MAX_SPEED
        powerup_triple_13.Angle = 0

        powerup_triple_14 = New Sprite
        powerup_triple_14.IsAlive = False
        powerup_triple_14.SetImageResource(My.Resources.powerup_triple)
        powerup_triple_14.MaxSpeed = MAX_SPEED
        powerup_triple_14.Angle = 0
    End Sub

    Private Sub PaintPowerUps(ByRef myGraphics As Graphics)
        If (powerup_speed_1 Is Nothing) Then
            Return
        End If

        If (powerup_speed_2 Is Nothing) Then
            Return
        End If

        If (powerup_health_3 Is Nothing) Then
            Return
        End If

        If (powerup_health_4 Is Nothing) Then
            Return
        End If

        If (powerup_health_5 Is Nothing) Then
            Return
        End If

        If (powerup_ammo_6 Is Nothing) Then
            Return
        End If

        If (powerup_ammo_7 Is Nothing) Then
            Return
        End If

        If (powerup_ammo_8 Is Nothing) Then
            Return
        End If

        If (powerup_slow_9 Is Nothing) Then
            Return
        End If

        If (powerup_slow_10 Is Nothing) Then
            Return
        End If

        If (powerup_shield_11 Is Nothing) Then
            Return
        End If

        If (powerup_shield_12 Is Nothing) Then
            Return
        End If

        If (powerup_triple_13 Is Nothing) Then
            Return
        End If

        If (powerup_triple_14 Is Nothing) Then
            Return
        End If

        powerup_speed_1.PaintRotatedImage(myGraphics, powerup_speed_1.Angle, powerup_speed_1.GetCenter(), True)
        powerup_speed_2.PaintRotatedImage(myGraphics, powerup_speed_2.Angle, powerup_speed_2.GetCenter(), True)
        powerup_health_3.PaintRotatedImage(myGraphics, powerup_health_3.Angle, powerup_health_3.GetCenter(), True)
        powerup_health_4.PaintRotatedImage(myGraphics, powerup_health_4.Angle, powerup_health_4.GetCenter(), True)
        powerup_health_5.PaintRotatedImage(myGraphics, powerup_health_5.Angle, powerup_health_5.GetCenter(), True)
        powerup_ammo_6.PaintRotatedImage(myGraphics, powerup_ammo_6.Angle, powerup_ammo_6.GetCenter(), True)
        powerup_ammo_7.PaintRotatedImage(myGraphics, powerup_ammo_7.Angle, powerup_ammo_7.GetCenter(), True)
        powerup_ammo_8.PaintRotatedImage(myGraphics, powerup_ammo_8.Angle, powerup_ammo_8.GetCenter(), True)
        powerup_slow_9.PaintRotatedImage(myGraphics, powerup_slow_9.Angle, powerup_slow_9.GetCenter(), True)
        powerup_slow_10.PaintRotatedImage(myGraphics, powerup_slow_10.Angle, powerup_slow_10.GetCenter(), True)
        powerup_shield_11.PaintRotatedImage(myGraphics, powerup_shield_11.Angle, powerup_shield_11.GetCenter(), True)
        powerup_shield_12.PaintRotatedImage(myGraphics, powerup_shield_12.Angle, powerup_shield_12.GetCenter(), True)
        powerup_triple_13.PaintRotatedImage(myGraphics, powerup_triple_13.Angle, powerup_triple_13.GetCenter(), True)
        powerup_triple_14.PaintRotatedImage(myGraphics, powerup_triple_14.Angle, powerup_triple_14.GetCenter(), True)
    End Sub

    Private Sub MovePlayer1()
        p1Sprite.Move(Me.ClientSize)
    End Sub

    Private Sub MovePlayer2()
        p2Sprite.Move(Me.ClientSize)
    End Sub

    Private Sub frmGameScreen_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If blnGameIsStarted = False Then

            Select Case e.KeyCode
                Case Keys.Up
                    p2UpIsPressed = True
                Case Keys.Right
                    p2RightIsPressed = True
                Case Keys.Left
                    p2LeftIsPressed = True
                Case Keys.Down
                    p2DownIsPressed = True
            End Select

            Select Case e.KeyCode
                Case Keys.W
                    p1UpIsPressed = True
                Case Keys.D
                    p1RightIsPressed = True
                Case Keys.A
                    p1LeftIsPressed = True
                Case Keys.S
                    p1DownIsPressed = True
            End Select

            Select Case e.KeyCode
                Case Keys.L
                    p1WhiteIsPressed = True
                Case Keys.O
                    p1YellowIsPressed = True
                Case Keys.F
                    p1BlueIsPressed = True
                Case Keys.B
                    p1RedIsPressed = True
            End Select

            Select Case e.KeyCode
                Case Keys.G
                    p2YellowIsPressed = True
                Case Keys.Space
                    p2WhiteIsPressed = True
                Case Keys.I
                    p2BlueIsPressed = True
                Case Keys.K
                    p2RedIsPressed = True
            End Select
        End If

        Select Case e.KeyCode
            Case Keys.W And p1_blnIsJumping = False     'if player one jumps and isn't jumping, start jumping
                p1IsJumping = 1
            Case Else
                If Keys.W And p1_blnIsJumping Then      'if player one jumps but is jumping, just do nothing
                    Exit Select
                End If
        End Select

        Select Case e.KeyCode
            Case Keys.Up And p2_blnIsJumping = False     'if player two jumps and isn't jumping, start jumping
                p2IsJumping = 1
            Case Else
                If Keys.Up And p2_blnIsJumping Then      'if player two jumps but is jumping, just do nothing
                    Exit Select
                End If
        End Select

        'draw rect per sprite, set rect = sprite.GetBoundingRectangle()
        'if collides with x.left then do(shit);

        Select Case e.KeyCode
            'Case Keys.W             ' Player 1 - UP
            '    p1UpIsPressed = True
            '    p1NoKeysPressed = False
            Case Keys.S             ' Player 1 - DOWN
                p1DownIsPressed = True
                p1NoKeysPressed = False
            Case Keys.A             ' Player 1 - LEFT
                p1LeftIsPressed = True

                'If p1IsJumping Then
                '    If p1Dir = "LeftUp" Then
                '        p1MovedLeftMidair = True
                '    End If

                'End If

                p1NoKeysPressed = False
            Case Keys.D             ' Player 1 - RIGHT
                p1RightIsPressed = True

                'If p1IsJumping Then
                '    If p1Dir = "RightUp" Then
                '        p1MovedRightMidair = True
                '    End If
                'End If

                p1NoKeysPressed = False

            Case Keys.O             ' Player 1 - YELLOW
                If p1Ammo > 1 Then

                    p1YellowIsPressed = True
                    p1NoKeysPressed = False
                    If blnPUPsEnabled = False Then
                        Exit Sub
                    End If
                    lblPlayer1Ammo.Text = "AMMO: " & p1Ammo
                    p1Ammo -= 1

                ElseIf (p1Ammo = 1) Then
                    p1YellowIsPressed = True
                    p1NoKeysPressed = False
                    lblPlayer1Ammo.Text = "AMMO: 0"
                    p1Ammo -= 1
                ElseIf (p1Ammo = 0) Then
                    lblPlayer1Ammo.Text = "AMMO: Insufficient!"
                    'Do nothing, out of ammo.
                End If
            Case Keys.L             ' Player 1 - WHITE                                                 
                If p1Ammo > 1 Then

                    p1WhiteIsPressed = True
                    p1NoKeysPressed = False
                    If blnPUPsEnabled = False Then
                        Exit Sub
                    End If
                    lblPlayer1Ammo.Text = "AMMO: " & p1Ammo
                    p1Ammo -= 1
                ElseIf (p1Ammo = 1) Then
                    lblPlayer1Ammo.Text = "AMMO: 0"
                    p1Ammo -= 1
                    p1WhiteIsPressed = True
                    p1NoKeysPressed = False
                ElseIf (p1Ammo = 0) Then
                    lblPlayer1Ammo.Text = "AMMO: Insufficient!"
                    'Do nothing, out of ammo.
                End If

            Case Keys.F             ' Player 1 - BLUE                                                   
                If p1Ammo > 1 Then
                    p1BlueIsPressed = True
                    p1NoKeysPressed = False
                    If blnPUPsEnabled = False Then
                        Exit Sub
                    End If
                    lblPlayer1Ammo.Text = "AMMO: " & p1Ammo
                    p1Ammo -= 1
                ElseIf (p1Ammo = 1) Then
                    lblPlayer1Ammo.Text = "AMMO: 0"
                    p1Ammo -= 1
                    p1BlueIsPressed = True
                    p1NoKeysPressed = False
                ElseIf (p1Ammo = 0) Then
                    lblPlayer1Ammo.Text = "AMMO: Insufficient!"
                    'Do nothing, out of ammo.
                End If

            Case Keys.B             ' Player 1 - RED
                If p1Ammo > 1 Then
                    p1RedIsPressed = True
                    p1NoKeysPressed = False
                    If blnPUPsEnabled = False Then
                        Exit Sub
                    End If
                    lblPlayer1Ammo.Text = "AMMO: " & p1Ammo
                    p1Ammo -= 1
                ElseIf (p1Ammo = 1) Then
                    lblPlayer1Ammo.Text = "AMMO: 0"
                    p1Ammo -= 1
                    p1RedIsPressed = True
                    p1NoKeysPressed = False
                ElseIf (p1Ammo = 0) Then
                    lblPlayer1Ammo.Text = "AMMO: Insufficient!"
                    'Do nothing, out of ammo.
                End If

            Case Keys.Up            ' Player 2 - UP
                p2UpIsPressed = True
                p2NoKeysPressed = False
            Case Keys.Down          ' Player 2 - DOWN
                p2DownIsPressed = True
                p2NoKeysPressed = False
            Case Keys.Left          ' Player 2 - LEFT
                p2LeftIsPressed = True

                p2NoKeysPressed = False
            Case Keys.Right         ' Player 2 - RIGHT
                p2RightIsPressed = True

                p2NoKeysPressed = False

            Case Keys.G             ' Player 2 - YELLOW
                If p2Ammo > 1 Then
                    p2YellowIsPressed = True
                    p2NoKeysPressed = False
                    If blnPUPsEnabled = False Then
                        Exit Sub
                    End If
                    lblPlayer2Ammo.Text = "AMMO: " & p2Ammo
                    p2Ammo -= 1
                ElseIf (p2Ammo = 1) Then
                    lblPlayer2Ammo.Text = "AMMO: 0"
                    p2Ammo -= 1
                    p2YellowIsPressed = True
                    p2NoKeysPressed = False
                ElseIf (p2Ammo = 0) Then
                    lblPlayer2Ammo.Text = "AMMO: Insufficient!"
                    'Do nothing, out of ammo.
                End If
            Case Keys.Space         ' Player 2 - WHITE                                                   
                If p2Ammo > 1 Then
                    p2WhiteIsPressed = True
                    p2NoKeysPressed = False
                    If blnPUPsEnabled = False Then
                        Exit Sub
                    End If
                    lblPlayer2Ammo.Text = "AMMO: " & p2Ammo
                    p2Ammo -= 1
                ElseIf (p2Ammo = 1) Then
                    lblPlayer2Ammo.Text = "AMMO: 0"
                    p2Ammo -= 1
                    p2WhiteIsPressed = True
                    p2NoKeysPressed = False
                ElseIf (p2Ammo = 0) Then
                    lblPlayer2Ammo.Text = "AMMO: Insufficient!"
                    'Do nothing, out of ammo.
                End If
            Case Keys.I             ' Player 2 - BLUE                                                       
                If p2Ammo > 1 Then
                    p2BlueIsPressed = True
                    p2NoKeysPressed = False
                    If blnPUPsEnabled = False Then
                        Exit Sub
                    End If
                    lblPlayer2Ammo.Text = "AMMO: " & p2Ammo
                    p2Ammo -= 1
                ElseIf (p2Ammo = 1) Then
                    lblPlayer2Ammo.Text = "AMMO: 0"
                    p2Ammo -= 1
                    p2BlueIsPressed = True
                    p2NoKeysPressed = False
                ElseIf (p2Ammo = 0) Then
                    lblPlayer2Ammo.Text = "AMMO: Insufficient!"
                    'Do nothing, out of ammo.
                End If

            Case Keys.K             ' Player 2 - RED
                If p2Ammo > 1 Then
                    p2RedIsPressed = True
                    p2NoKeysPressed = False
                    If blnPUPsEnabled = False Then
                        Exit Sub
                    End If
                    lblPlayer2Ammo.Text = "AMMO: " & p2Ammo
                    p2Ammo -= 1
                ElseIf (p2Ammo = 1) Then
                    lblPlayer2Ammo.Text = "AMMO: 0"
                    p2Ammo -= 1
                    p2RedIsPressed = True
                    p2NoKeysPressed = False
                ElseIf (p2Ammo = 0) Then
                    lblPlayer2Ammo.Text = "AMMO: Insufficient!"
                    'Do nothing, out of ammo.
                End If
        End Select

    End Sub

    Private Sub frmGameScreen_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp

        If blnGameIsStarted = False Then

            Select Case e.KeyCode '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' DEVELOPER MODE SHORTCUTS FOR RandomSplash() AND MoveMMButtonsRight()
                Case Keys.Z
                    RandomSplash()
            End Select

            Select Case e.KeyCode
                Case Keys.W
                    p1UpIsPressed = False
                Case Keys.D
                    p1RightIsPressed = False
                Case Keys.A
                    p1LeftIsPressed = False
                Case Keys.S
                    p1DownIsPressed = False
            End Select

            Select Case e.KeyCode
                Case Keys.Up
                    p2UpIsPressed = False
                Case Keys.Right
                    p2RightIsPressed = False
                Case Keys.Left
                    p2LeftIsPressed = False
                Case Keys.Down
                    p2DownIsPressed = False
            End Select

            Select Case e.KeyCode
                Case Keys.L
                    p1WhiteIsPressed = False
                Case Keys.O
                    p1YellowIsPressed = False
                Case Keys.F
                    p1BlueIsPressed = False
                Case Keys.B
                    p1RedIsPressed = False
            End Select

            Select Case e.KeyCode
                Case Keys.G
                    p2YellowIsPressed = False
                Case Keys.Space
                    p2WhiteIsPressed = False
                Case Keys.I
                    p2BlueIsPressed = False
                Case Keys.K
                    p2RedIsPressed = False
            End Select
        End If

        Select Case e.KeyCode
            'Case Keys.W             ' Player 1 - UP
            '    p1UpIsPressed = False
            '    p1NoKeysPressed = True
            Case Keys.S             ' Player 1 - DOWN
                p1DownIsPressed = False
                p1NoKeysPressed = True
            Case Keys.A             ' Player 1 - LEFT
                p1LeftIsPressed = False
                p1NoKeysPressed = True
            Case Keys.D             ' Player 1 - RIGHT
                p1RightIsPressed = False
                p1NoKeysPressed = True

            Case Keys.O             ' Player 1 - YELLOW
                p1YellowIsPressed = False
                p1NoKeysPressed = True
            Case Keys.L             ' Player 1 - WHITE
                p1WhiteIsPressed = False
                p1NoKeysPressed = True
            Case Keys.F             ' Player 1 - BLUE
                p1BlueIsPressed = False
                p1NoKeysPressed = True
            Case Keys.B             ' Player 1 - RED
                p1RedIsPressed = False
                p1NoKeysPressed = True

            'Case Keys.Up            ' Player 2 - UP
            '    p2UpIsPressed = False
            '    p2NoKeysPressed = True
            Case Keys.Down          ' Player 2 - DOWN
                p2DownIsPressed = False
                p2NoKeysPressed = True
            Case Keys.Left          ' Player 2 - LEFT
                p2LeftIsPressed = False
                p2NoKeysPressed = True
            Case Keys.Right         ' Player 2 - RIGHT
                p2RightIsPressed = False
                p2NoKeysPressed = True

            Case Keys.G             ' Player 2 - YELLOW
                p2YellowIsPressed = False
                p2NoKeysPressed = True
            Case Keys.Space         ' Player 2 - WHITE
                p2WhiteIsPressed = False
                p2NoKeysPressed = True
            Case Keys.I             ' Player 2 - BLUE
                p2BlueIsPressed = False
                p2NoKeysPressed = True
            Case Keys.K             ' Player 2 - RED
                p2RedIsPressed = False
                p2NoKeysPressed = True


            Case Keys.End
                Application.Exit()
        End Select

    End Sub

    Private Sub ProcessKeys()
        ' first check the key states and respond to each one that is currently pressed

        ' Player one - Down!
        If p1DownIsPressed Then
            If p1IsOnGround Then
                If p1Dir = "Right" Then
                    If p1IsMoving Then
                        p1Sprite.StopMoving()
                        p1StopRunningRight()
                        p1RightRunFrame = 1
                        p1tmrRightRun.Stop()
                        p1tmrRightIdle.Stop()
                        p1RightIdleFrame = 1
                        p1Crouch()
                    Else
                        p1tmrRightRun.Stop()
                        p1RightRunFrame = 1
                        p1tmrRightIdle.Stop()
                        p1RightIdleFrame = 1
                        p1Crouch()
                    End If
                ElseIf p1Dir = "Left" Then
                    If p1IsMoving Then
                        p1StopRunningLeft()
                        p1LeftRunFrame = 1
                        p1tmrLeftRun.Stop()
                        p1LeftRunFrame = 1
                        p1tmrLeftIdle.Stop()
                        p1LeftIdleFrame = 1
                        p1Crouch()
                    Else
                        p1tmrLeftIdle.Stop()
                        p1LeftIdleFrame = 1
                        p1tmrLeftRun.Stop()
                        p1LeftRunFrame = 1
                        p1StopRunningLeft()
                        p1Crouch()
                    End If
                End If
            End If
        End If


        If p1DownIsPressed = False Then
            If p1IsCrouching Then
                p1StandUp()
            End If
        End If

        If p2DownIsPressed = False Then
            If p2IsCrouching Then
                p2StandUp()
            End If
        End If

        ' Player one - Left!

        If p1LeftIsPressed Then

            If p1IsMoving = True And p1Dir Is "Right" Then                           'If running right and GOES left
                p1StopRunningRight()
                p1TurnAround()
                p1StartRunningLeft()
            End If
            If p1IsMoving = True And p1Dir Is "Left" Then                        'If running left and GOES left
                '   Do nothing, already running left.
            End If
            If p1IsMoving = False And p1Dir Is "Right" Then                      'If not running and facing right and GOES left
                p1TurnAround()
                p1StartRunningLeft()
            End If
            If p1IsMoving = False And p1Dir Is "Left" Then                       'If not running and facing left and GOES left
                p1StartRunningLeft()
            End If
            If (p1IsJumping = True) And (p1Dir = "LeftUp") Then
                p1MovedLeftMidair = True
            End If

        Else
            If p1IsMoving And p1LeftIsPressed = False And p1Dir = "Left" Then        'If the user has not clicked left
                p1StopRunningLeft()
            End If
        End If


        If p1WhiteIsPressed Then
            While (p1WhiteIsPressed = True)
                If p1IsTripled Then
                    Player1Shoot()
                    Player1ShootUp()
                    Player1ShootDown()
                Else
                    Player1Shoot()
                End If
                p1WhiteIsPressed = False
            End While
        End If

        If p2WhiteIsPressed Then
            While (p2WhiteIsPressed = True)
                If p2IsTripled Then
                    Player2Shoot()
                    Player2ShootUp()
                    Player2ShootDown()
                Else
                    Player2Shoot()
                End If
                p2WhiteIsPressed = False
            End While
        End If

        If p1RedIsPressed Then
            While (p1RedIsPressed = True)
                If p1IsTripled Then
                    Player1Shoot()
                    Player1ShootUp()
                    Player1ShootDown()
                Else
                    Player1Shoot()
                End If
                p1RedIsPressed = False
            End While
        End If

        If p2RedIsPressed Then
            While (p2RedIsPressed = True)
                If p2IsTripled Then
                    Player2Shoot()
                    Player2ShootUp()
                    Player2ShootDown()
                Else
                    Player2Shoot()
                End If
                p2RedIsPressed = False
            End While
        End If

        If p1BlueIsPressed Then
            While (p1BlueIsPressed = True)
                If p1IsTripled Then
                    Player1Shoot()
                    Player1ShootUp()
                    Player1ShootDown()
                Else
                    Player1Shoot()
                End If
                p1BlueIsPressed = False
            End While
        End If

        If p2BlueIsPressed Then
            While (p2BlueIsPressed = True)
                If p2IsTripled Then
                    Player2Shoot()
                    Player2ShootUp()
                    Player2ShootDown()
                Else
                    Player2Shoot()
                End If
                p2BlueIsPressed = False
            End While
        End If

        If p1YellowIsPressed Then
            While (p1YellowIsPressed = True)
                If p1IsTripled Then
                    Player1Shoot()
                    Player1ShootUp()
                    Player1ShootDown()
                Else
                    Player1Shoot()
                End If
                p1YellowIsPressed = False
            End While
        End If

        If p2YellowIsPressed Then
            While (p2YellowIsPressed = True)
                If p2IsTripled Then
                    Player2Shoot()
                    Player2ShootUp()
                    Player2ShootDown()
                Else
                    Player2Shoot()
                End If
                p2YellowIsPressed = False
            End While
        End If
        ' Player one - Right!

        If p1RightIsPressed Then
            If p1IsMoving = True And p1Dir Is "Right" Then                           'If running right and GOES right
                '   Do nothing, already running right.
            End If
            If p1IsMoving = True And p1Dir Is "Left" Then                        'If running left and GOES right
                p1StopRunningLeft()
                p1TurnAround()
                p1StartRunningRight()
            End If
            If p1IsMoving = False And p1Dir Is "Right" Then                      'If not running and facing right and GOES right
                p1StartRunningRight()

            End If
            If p1IsMoving = False And p1Dir Is "Left" Then                       'If not running and facing left and GOES right
                p1TurnAround()
                p1StartRunningRight()
            End If



            'If the user has not clicked right
        Else
            If p1IsMoving And p1RightIsPressed = False And p1Dir = "Right" Then
                p1StopRunningRight()
            End If

        End If



        '#####################################
        '##         JUMPING MECHANISMS      ##
        '#####################################
        'Players can run-jump (jump if already running), which allows them to angle their landing?
        'Players can jump in place, in which they go straight up and fall back down (avoiding gun shots).



        'If p1UpIsPressed Then
        '    If p1IsMoving = True And p1Dir Is "Right" Then                           'If running right and JUMPS
        '        p1RunningJumpRight()

        '    ElseIf p1IsMoving = True And p1Dir Is "Left" Then                        'If running left and JUMPS
        '        p1RunningJumpLeft()

        '    ElseIf p1IsMoving = False And p1Dir Is "Right" Then                      'If not running and facing right and JUMPS
        '        p1StandingJumpRight()

        '    ElseIf p1IsMoving = False And p1Dir Is "Left" Then                       'If not running and facing left and JUMPS
        '        p1StandingJumpLeft()
        '    End If
        'End If





        ' Player one /\
        '#################################################################################################################################################################################################
        ' Player two \/

        ' Player two - Down!
        If p2DownIsPressed Then
            If p2IsOnGround Then
                If p2Dir = "Right" Then
                    If p2IsMoving Then
                        p2Sprite.StopMoving()
                        p2StopRunningRight()
                        p2RightRunFrame = 1
                        p2tmrRightRun.Stop()
                        p2tmrRightIdle.Stop()
                        p2RightIdleFrame = 1
                        p2Crouch()
                    Else
                        p2tmrRightRun.Stop()
                        p2RightRunFrame = 1
                        p2tmrRightIdle.Stop()
                        p2RightIdleFrame = 1
                        p2Crouch()
                    End If
                ElseIf p2Dir = "Left" Then
                    If p2IsMoving Then
                        p2StopRunningLeft()
                        p2LeftRunFrame = 1
                        p2tmrLeftRun.Stop()
                        p2LeftRunFrame = 1
                        p2tmrLeftIdle.Stop()
                        p2LeftIdleFrame = 1
                        p2Crouch()
                    Else
                        p2tmrLeftIdle.Stop()
                        p2LeftIdleFrame = 1
                        p2tmrLeftRun.Stop()
                        p2LeftRunFrame = 1
                        p2StopRunningLeft()
                        p2Crouch()
                    End If
                End If
            End If
        End If


        ' Player two - Left!

        If p2LeftIsPressed Then
            ' If JUMPED IN MIDAIR 
            If p2IsMoving = True And p2Dir Is "Right" Then                           'If running right and GOES left
                p2StopRunningRight()
                p2TurnAround()
                p2StartRunningLeft()
            End If
            If p2IsMoving = True And p2Dir Is "Left" Then                        'If running left and GOES left
                '   Do nothing, already running left.
            End If
            If p2IsMoving = False And p2Dir Is "Right" Then                      'If not running and facing right and GOES left
                p2TurnAround()
                p2StartRunningLeft()
            End If
            If p2IsMoving = False And p2Dir Is "Left" Then                       'If not running and facing left and GOES left
                p2StartRunningLeft()
            End If

            'If player 2 stopped pressing left
        Else
            If p2LeftIsPressed = False And p2IsMoving And p2Dir = "Left" Then
                p2StopRunningLeft()
            End If
        End If





        ' Player two - Right!

        If p2RightIsPressed Then
            If p2IsMoving = True And p2Dir Is "Right" Then                           'If running right and GOES right
                '   Do nothing, already running right.
            End If
            If p2IsMoving = True And p2Dir Is "Left" Then                        'If running left and GOES right
                p2StopRunningLeft()
                p2TurnAround() 'this is pretty much strictly for the animation
                p2StartRunningRight()
            End If
            If p2IsMoving = False And p2Dir Is "Right" Then                      'If not running and facing right and GOES right
                p2StartRunningRight()
            End If
            If p2IsMoving = False And p2Dir Is "Left" Then                       'If not running and facing left and GOES right
                p2TurnAround()
                p2StartRunningRight()
            End If

            'If player 2 stopped pressing right
        Else
            If p2IsMoving And p2RightIsPressed = False And p2Dir = "Right" Then
                p2StopRunningRight()
            End If
        End If








        '#####################################
        '##         JUMPING MECHANISMS      ##
        '#####################################
        'Players can run-jump (jump if already running), which allows them to angle their landing?
        'Players can jump in place, in which they go straight up and fall back down (avoiding gun shots).



        'If p2UpIsPressed Then
        '    If p2IsMoving = True And p2Dir Is "Right" Then                           'If running right and JUMPS
        '        p2RunningJumpRight()

        '    ElseIf p2IsMoving = True And p2Dir Is "Left" Then                        'If running left and JUMPS
        '        p2RunningJumpLeft()

        '    ElseIf p2IsMoving = False And p2Dir Is "Right" Then                      'If not running and facing right and JUMPS
        '        p2StandingJumpRight()

        '    ElseIf p2IsMoving = False And p2Dir Is "Left" Then                       'If not running and facing left and JUMPS
        '        p2StandingJumpLeft()
        '    End If
        'End If
    End Sub

    '#################### PLAYER MOVEMENT METHODS CALLED FROM ProcessKeys() ##################################################################################################

    Private Sub p1StartRunningLeft()

        If p1IsCrouching Then
            Exit Sub
        End If

        ' Set Image Resource - player1 BEGINS RUNNING from IDLE ANIMATION
        If p1tmrLeftIdle.Enabled Then
            p1Sprite.SetImageResource(My.Resources.redLeftIdle1)
            p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
        End If

        p1Sprite.Accelerate(-6)


        p1IsMoving = True
        p1Dir = "Left"
        p1tmrLeftIdle.Stop()
        p1LeftIdleFrame = 1
        p1tmrLeftRun.Start()
    End Sub

    Private Sub p1StartRunningRight()

        If p1IsCrouching Then
            Exit Sub
        End If

        ' Set Image Resource - player1 BEGINS RUNNING from IDLE ANIMATION
        If p1tmrRightIdle.Enabled Then
            p1Sprite.SetImageResource(My.Resources.redRightIdle1)
            p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
        End If

        p1Sprite.Accelerate(6)


        p1IsMoving = True
        p1Dir = "Right"
        p1tmrRightIdle.Stop()
        p1RightIdleFrame = 1
        p1tmrRightRun.Start()
    End Sub

    Private Sub p1StopRunningLeft()
        ' Set Image Resource - player1 STOPS RUNNING from RUNNING LEFT to IDLE ANIMATION

        p1Sprite.StopMoving()
        p1IsMoving = False

        p1tmrLeftRun.Stop()
        p1LeftIdleFrame = 1
        p1tmrLeftIdle.Start()
    End Sub

    Private Sub p1StopRunningRight()
        ' Set Image Resource - player1 STOPS RUNNING from RUNNING RIGHT to IDLE ANIMATION
        p1Sprite.StopMoving()
        p1IsMoving = False

        p1tmrRightRun.Stop()
        p1RightIdleFrame = 1

        p1tmrRightIdle.Start()

    End Sub

    '##################################################################################################################################################################

    Private Sub p2StartRunningLeft()

        If p2IsCrouching Then
            Exit Sub
        End If

        If p2tmrLeftIdle.Enabled Then
            p2Sprite.SetImageResource(My.Resources.blueLeftIdle1)
            p2ShootPoint.X = p2Sprite.UpperLeft.X
        End If

        ' Set Image Resource - player2 BEGINS RUNNING from IDLE ANIMATION
        p2Sprite.Accelerate(-6)
        p2IsMoving = True
        p2Dir = "Left"

        p2LeftIdleFrame = 1
        p2tmrLeftIdle.Stop()
        p2tmrLeftRun.Start()
    End Sub

    Private Sub p2StartRunningRight()

        If p2IsCrouching Then
            Exit Sub
        End If

        If p2tmrRightIdle.Enabled Then
            p2Sprite.SetImageResource(My.Resources.blueRightIdle1)
            p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
        End If

        ' Set Image Resource - player2 BEGINS RUNNING from IDLE ANIMATION

        p2Sprite.Accelerate(6)
        p2IsMoving = True
        p2Dir = "Right"

        p2RightIdleFrame = 1
        p2tmrRightIdle.Stop()
        p2tmrRightRun.Start()
    End Sub

    Private Sub p2StopRunningLeft()
        ' Set Image Resource - player2 STOPS RUNNING from RUNNING LEFT to IDLE ANIMATION
        p2Sprite.StopMoving()
        p2IsMoving = False

        p2tmrLeftRun.Stop()
        p2LeftIdleFrame = 1
        p2tmrLeftIdle.Start()
    End Sub

    Private Sub p2StopRunningRight()
        ' Set Image Resource - player2 STOPS RUNNING from RUNNING RIGHT to IDLE ANIMATION
        p2Sprite.StopMoving()
        p2IsMoving = False

        p2tmrRightRun.Stop()
        p2RightIdleFrame = 1
        p2tmrRightIdle.Start()
    End Sub

    Private Sub p1TurnAround()
        If p1Dir = "Right" Then
            p1Dir = "Left"
            p1tmrRightIdle.Stop()
            p1tmrLeftIdle.Start()
        ElseIf p1Dir = "Left" Then
            p1Dir = "Right"
            p1tmrLeftIdle.Stop()
            p1tmrRightIdle.Start()
        End If

    End Sub

    Private Sub p2TurnAround()
        If p2Dir = "Right" Then
            p2Dir = "Left"
            p2tmrRightIdle.Stop()
            p2tmrLeftIdle.Start()
        ElseIf p2Dir = "Left" Then
            p2Dir = "Right"
            p2tmrLeftIdle.Stop()
            p2tmrRightIdle.Start()
        End If
    End Sub

    Private Sub PaintPlayer1(ByRef myGraphics As Graphics)
        'Make sure that the sprite exists on the screen
        If (p1Sprite Is Nothing) Then
            Return
        End If

        ' paint the sprite image at it's current rotation angle
        p1Sprite.PaintRotatedImage(myGraphics, p1Sprite.Angle, p1Sprite.GetCenter(), True)
    End Sub

    Private Sub PaintPlayer2(ByRef myGraphics As Graphics)
        'Make sure that the sprite exists on the screen
        If (p2Sprite Is Nothing) Then
            Return
        End If

        ' paint the sprite image at it's current rotation angle
        p2Sprite.PaintRotatedImage(myGraphics, p2Sprite.Angle, p2Sprite.GetCenter(), True)
    End Sub

    Private Sub PaintBackground(ByRef myGraphics As Graphics)
        If (backgroundImageSprite Is Nothing) Then
            Return
        End If

        backgroundImageSprite.PaintRotatedImage(myGraphics, backgroundImageSprite.Angle, backgroundImageSprite.GetCenter(), True)
    End Sub

    Private Sub PaintPlatforms(ByRef myGraphics As Graphics)
        'Make sure that the platforms exist on the screen

        'Main platform
        If (mainPlatformSprite Is Nothing) Then
            Return
        End If

        If (spritePlatform2 Is Nothing) Then
            Return
        End If

        If (spritePlatform3 Is Nothing) Then
            Return
        End If

        If (spritePlatform4 Is Nothing) Then
            Return
        End If

        If (spritePlatform5 Is Nothing) Then
            Return
        End If

        If (spritePlatform6 Is Nothing) Then
            Return
        End If

        If (spritePlatform7 Is Nothing) Then
            Return
        End If

        If (spritePlatform8 Is Nothing) Then
            Return
        End If

        If (spritePlatform9 Is Nothing) Then
            Return
        End If

        If (spritePlatform10 Is Nothing) Then
            Return
        End If

        If (spritePlatform11 Is Nothing) Then
            Return
        End If

        If (spriteTopWall Is Nothing) Then
            Return
        End If

        If (spriteInvisibleRightWall Is Nothing) Then
            Return
        End If

        If (spriteInvisibleLeftWall Is Nothing) Then
            Return
        End If

        spriteTopWall.PaintRotatedImage(myGraphics, spriteTopWall.Angle, spriteTopWall.GetCenter(), True)
        spriteInvisibleLeftWall.PaintRotatedImage(myGraphics, spriteInvisibleLeftWall.Angle, spriteInvisibleLeftWall.GetCenter(), True)
        spriteInvisibleRightWall.PaintRotatedImage(myGraphics, spriteInvisibleRightWall.Angle, spriteInvisibleRightWall.GetCenter(), True)
        mainPlatformSprite.PaintRotatedImage(myGraphics, mainPlatformSprite.Angle, mainPlatformSprite.GetCenter(), True)
        spritePlatform2.PaintRotatedImage(myGraphics, spritePlatform2.Angle, spritePlatform2.GetCenter(), True)
        spritePlatform3.PaintRotatedImage(myGraphics, spritePlatform3.Angle, spritePlatform3.GetCenter(), True)
        spritePlatform4.PaintRotatedImage(myGraphics, spritePlatform4.Angle, spritePlatform4.GetCenter(), True)
        spritePlatform5.PaintRotatedImage(myGraphics, spritePlatform5.Angle, spritePlatform5.GetCenter(), True)
        spritePlatform6.PaintRotatedImage(myGraphics, spritePlatform6.Angle, spritePlatform6.GetCenter(), True)
        spritePlatform7.PaintRotatedImage(myGraphics, spritePlatform7.Angle, spritePlatform7.GetCenter(), True)
        spritePlatform8.PaintRotatedImage(myGraphics, spritePlatform8.Angle, spritePlatform8.GetCenter(), True)
        spritePlatform9.PaintRotatedImage(myGraphics, spritePlatform9.Angle, spritePlatform9.GetCenter(), True)
        spritePlatform10.PaintRotatedImage(myGraphics, spritePlatform10.Angle, spritePlatform10.GetCenter(), True)
        spritePlatform11.PaintRotatedImage(myGraphics, spritePlatform11.Angle, spritePlatform11.GetCenter(), True)
    End Sub

    Private Sub frmGameScreen_MouseHover(sender As Object, e As EventArgs) Handles MyBase.MouseHover
        Cursor.Hide()
    End Sub

    Private Sub frmGameScreen_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        If tmrSplashPulse.Enabled = True Then
            Exit Sub
        End If
        Dim myGraphics As Graphics = e.Graphics
        'Dim whiteBrush As New SolidBrush(Color.White)
        'Dim Consolas As Font = New Font("Consolas", 20, FontStyle.Bold, GraphicsUnit.Pixel)
        'Dim rightToLeft As New StringFormat(StringFormatFlags.DirectionRightToLeft)
        'Dim whitePen As New Pen(whiteBrush, 2)
        'Dim bluePen As New Pen(Brushes.Blue, 1)



        '    p1HP(i).UpperLeft = New Point(p1HPX, 560)
        '    p1HP(i).SetImageResource(My.Resources.p1Life)
        '    p1HP(i).Size = New Point(p1HP(i).loadedImage.Width, p1HP(i).loadedImage.Height)



        ' Top divider line
        'myGraphics.DrawLine(whitePen, 0, 45, 800, 45)

        ' Bottom divider line
        'myGraphics.DrawLine(whitePen, 0, 486, 800, 486)


        ' Center lines for spacing testing
        ' myGraphics.DrawLine(bluePen, 400, 0, 400, 600)
        ' myGraphics.DrawLine(bluePen, 0, 300, 800, 300)

        PaintBackground(myGraphics)
        PaintPlatforms(myGraphics)  'players will be over platforms
        PaintPlayer1(myGraphics)
        PaintPlayer2(myGraphics)
        PaintPlayer1Shots(myGraphics)
        PaintPlayer2Shots(myGraphics)

        PaintPowerUps(myGraphics)


        ' Painting the timer!
        If gameTime = -1 Then
            ' Time is unlimited, don't bother with the timer.
        Else
            Dim fntTimerFont As New Font("DS-Digital", 36, FontStyle.Regular, GraphicsUnit.Point)

            If blnGameIsStarted = True Then
                Try
                    Dim rect1 As New Rectangle(335, 517, 200, 50)

                    ' Create a StringFormat object with the each line of text, and the block
                    ' of text centered on the page.
                    Dim stringFormat As New StringFormat()
                    stringFormat.Alignment = StringAlignment.Near
                    stringFormat.LineAlignment = StringAlignment.Center


                    ' Draw the text and the surrounding rectangle.
                    'e.Graphics.TranslateTransform(100.0F, 0.0F)
                    If strTimeLeft = "0:0-1" Then
                        e.Graphics.DrawString(strTimeLeft, fntTimerFont, Brushes.Transparent, rect1, stringFormat)
                    Else
                        e.Graphics.DrawString(strTimeLeft, fntTimerFont, Brushes.White, rect1, stringFormat)
                    End If

                    If (Strings.Right(strTimeLeft, 2) <= "10" And Strings.Left(strTimeLeft, 1) = 0) Then
                        e.Graphics.DrawString(strTimeLeft, fntTimerFont, Brushes.Red, rect1, stringFormat)
                    End If

                    e.Graphics.DrawRectangle(Pens.Transparent, rect1) ' change to blue to see timer boundaries

                Finally
                    fntTimerFont.Dispose()
                End Try
            Else
                fntTimerFont.Dispose()
            End If
        End If
    End Sub

    Private Sub tmrGameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick

        ProcessKeys()

        MovePlayer1()
        MovePlayer2()
        MovePlayer1Shots()
        MovePlayer2Shots()

        'after player moves, redraw rects per each one
        rectPlayer1 = p1Sprite.GetBoundingRectangle()
        rectPlayer2 = p2Sprite.GetBoundingRectangle()

        p1CheckCollisions()
        p2CheckCollisions()
        CheckCorrectYValues() ' Makes sure stickfigures, when on the ground, are at the right heights on the platforms and objects. Fixes the odd up-and-down from jumping, landing, and falling, as well as running.

        CheckPlayer1ShotCollisions()
        CheckPlayer2ShotCollisions()
        CheckPlayer1PowerUpCollisions()
        CheckPlayer2PowerUpCollisions()

        CheckIfPlayerDied()

        If gameIsStopped Then
            GameTimer.Stop()
        End If

        Invalidate()

    End Sub

    ' The game is nearly 100% bug-free to this subroutine!
    ' This checks to make sure players never fall through platforms, and always stand directly in the middle of them.
    ' It ALSO prevents players from falling through them! NO MORE BUGS wait no really does it i honestly have no idea
    Private Sub CheckCorrectYValues()
        ' Make sure that...y'know, players are always at the right Y value.

        ' Player 1!
        If p1IsJumping = 0 Then ' floor 1
            If p1Sprite.IsCollided(mainPlatformSprite) Then
                If p1Sprite.UpperLeft.Y < 433 Or p1Sprite.UpperLeft.Y > 433 Then
                    If p1IsCrouching = False Then
                        p1Sprite.UpperLeft.Y = 433
                    End If

                End If
            End If

            ' floor 2
            If p1Sprite.IsCollided(spritePlatform2) Or p1Sprite.IsCollided(spritePlatform3) Or p1Sprite.IsCollided(spritePlatform4) Or p1Sprite.IsCollided(spritePlatform5) Then
                If p1Sprite.UpperLeft.Y < 313 Or p1Sprite.UpperLeft.Y > 313 Then
                    If p1IsCrouching = False Then
                        p1Sprite.UpperLeft.Y = 313
                    End If
                End If
            End If

            ' floor 3
            If p1Sprite.IsCollided(spritePlatform6) Or p1Sprite.IsCollided(spritePlatform7) Or p1Sprite.IsCollided(spritePlatform8) Then
                If p1Sprite.UpperLeft.Y < 193 Or p1Sprite.UpperLeft.Y > 193 Then
                    If p1IsCrouching = False Then
                        p1Sprite.UpperLeft.Y = 193
                    End If
                End If
            End If

            ' floor 4
            If p1Sprite.IsCollided(spritePlatform9) Or p1Sprite.IsCollided(spritePlatform10) Or p1Sprite.IsCollided(spritePlatform11) Then
                If p1Sprite.UpperLeft.Y < 73 Or p1Sprite.UpperLeft.Y > 73 Then
                    If p1IsCrouching = False Then
                        p1Sprite.UpperLeft.Y = 73
                    End If
                End If
            End If
        End If

        ' Player 2!
        If p2IsJumping = 0 Then ' floor 1
            If p2Sprite.IsCollided(mainPlatformSprite) Then
                If p2Sprite.UpperLeft.Y < 433 Or p2Sprite.UpperLeft.Y > 433 Then
                    If p2IsCrouching = False Then
                        p2Sprite.UpperLeft.Y = 433
                    End If
                End If
            End If

            ' floor 2
            If p2Sprite.IsCollided(spritePlatform2) Or p2Sprite.IsCollided(spritePlatform3) Or p2Sprite.IsCollided(spritePlatform4) Or p2Sprite.IsCollided(spritePlatform5) Then
                If p2Sprite.UpperLeft.Y < 313 Or p2Sprite.UpperLeft.Y > 313 Then
                    If p2IsCrouching = False Then
                        p2Sprite.UpperLeft.Y = 313
                    End If
                End If
            End If

            ' floor 3
            If p2Sprite.IsCollided(spritePlatform6) Or p2Sprite.IsCollided(spritePlatform7) Or p2Sprite.IsCollided(spritePlatform8) Then
                If p2Sprite.UpperLeft.Y < 193 Or p2Sprite.UpperLeft.Y > 193 Then
                    If p2IsCrouching = False Then
                        p2Sprite.UpperLeft.Y = 193
                    End If
                End If
            End If

            ' floor 4
            If p2Sprite.IsCollided(spritePlatform9) Or p2Sprite.IsCollided(spritePlatform10) Or p2Sprite.IsCollided(spritePlatform11) Then
                If p2Sprite.UpperLeft.Y < 73 Or p2Sprite.UpperLeft.Y > 73 Then
                    If p2IsCrouching = False Then
                        p2Sprite.UpperLeft.Y = 73
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub p1CheckCollisions()
        'p#IsJumping As int = 0, 1, 2, or 3
        '0 is on ground/running
        '1 is hit up
        '2 is going up
        '3 is falling down
        '4 is before anyone moves, game start.

        If rectPlayer1.IntersectsWith(rectMainPlatform) Or rectPlayer1.IntersectsWith(rectPlatform2) Or rectPlayer1.IntersectsWith(rectPlatform3) _
            Or rectPlayer1.IntersectsWith(rectPlatform4) Or rectPlayer1.IntersectsWith(rectPlatform5) Or rectPlayer1.IntersectsWith(rectPlatform6) _
            Or rectPlayer1.IntersectsWith(rectPlatform7) Or rectPlayer1.IntersectsWith(rectPlatform8) Or rectPlayer1.IntersectsWith(rectPlatform9) _
            Or rectPlayer1.IntersectsWith(rectPlatform10) Or rectPlayer1.IntersectsWith(rectPlatform11) Or rectPlayer1.IntersectsWith(rectTopWall) Then

        Else
            If (p1tmrFall.Enabled = False) And p1ComingUp = False Then
                p1CollidedPlatformSide = False
                p1IsJumping = 3
                p1tmrFall.Start()
            End If
        End If

        If p1HitHead Then
            If (p1tmrFall.Enabled = False) And (p1ComingDown) Then
                p1HitHead = False
                p1tmrFall.Start()
            End If
        End If

        '###################################################################################### Movement system 1: collisions only are on LANDING on platforms, can jump through (3D). Doesn't stop paintballs.

        'If rectPlayer1.IntersectsWith(rectPlatform1) Then
        '    If p1ComingDown And rectPlayer1.Bottom >= rectPlatform1.Top Then
        '        If p1IsJumping = 3 Then
        '            p1IsJumping = 0
        '            p1_blnIsJumping = False
        '            p1IsOnGround = True
        '            p1start = Nothing
        '            p1tmrFall.Stop()
        '            p1tmrJump.Start()
        '        End If
        '    End If
        'End If

        'If rectPlayer1.IntersectsWith(rectMainPlatform) Then
        '    If p1ComingDown And rectPlayer1.Bottom >= rectMainPlatform.Top Then
        '        If p1IsJumping = 3 Then
        '            p1IsJumping = 0
        '            p1_blnIsJumping = False
        '            p1IsOnGround = True
        '            p1start = Nothing

        '            p1tmrJump.Start()
        '        End If
        '        p1tmrFall.Stop()
        '    End If
        'End If

        '###################################################################################### Movement system 2: collisions on all four sides, more physical and realistic. Prevents paintball shots..

        If rectPlayer1.IntersectsWith(rectTopWall) Then
            'If p1ComingDown And rectPlayer1.Bottom >= rectTopWall.Top Then
            '    If p1IsJumping = 3 And rectPlayer1.Bottom < rectTopWall.Bottom Then
            '        p1IsJumping = 0
            '        p1_blnIsJumping = False
            '        p1IsOnGround = True
            '        p1start = Nothing
            '        p1tmrFall.Stop()
            '        p1tmrJump.Start()
            '        Exit Sub
            '    End If
            'End If

            If p1ComingUp And rectPlayer1.Top <= rectTopWall.Bottom Then
                If p1IsJumping = 2 And rectPlayer1.Bottom > rectTopWall.Bottom Then
                    p1IsJumping = 3
                    p1tmrJump.Stop()
                    p1ComingDown = True
                    p1ComingUp = False
                    p1HitHead = True
                    Exit Sub
                End If
            End If

            '    If rectPlayer1.Left < rectTopWall.Left AndAlso rectTopWall.Left < rectPlayer1.Right Then 'hits left

            '        If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
            '            'player is on platform, don't do anything
            '        Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
            '            If p1ComingUp Then
            '                p1Sprite.UpperLeft.X -= 6
            '                Exit Sub
            '            ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround = False Then
            '                p1Sprite.UpperLeft.X -= 6
            '                Exit Sub
            '            ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround Then
            '                'do nothing, player is trying to run on the platform
            '            End If
            '        End If
            '    End If
            '    If rectPlayer1.Right > rectTopWall.Right AndAlso rectTopWall.Right > rectPlayer1.Left Then 'hits right
            '        If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
            '            'player is on platform, don't do anything
            '        Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
            '            If p1ComingUp Then
            '                p1Sprite.UpperLeft.X += 6
            '                Exit Sub
            '            ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround = False Then
            '                p1Sprite.UpperLeft.X += 6
            '                Exit Sub
            '            ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround Then
            '                'do nothing, player is trying to run on the platform
            '            End If
            '        End If
            '    End If
        End If

        '###################
        If rectPlayer1.IntersectsWith(rectPlatform2) Then
            If p1ComingDown And rectPlayer1.Bottom >= rectPlatform2.Top Then
                If p1IsJumping = 3 And rectPlayer1.Bottom < rectPlatform2.Bottom Then
                    p1IsJumping = 0
                    p1_blnIsJumping = False
                    p1IsOnGround = True
                    p1start = Nothing
                    p1tmrFall.Stop()
                    p1tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p1ComingUp And rectPlayer1.Top <= rectPlatform2.Bottom Then
                If p1IsJumping = 2 And rectPlayer1.Bottom > rectPlatform2.Bottom Then
                    p1IsJumping = 3
                    p1tmrJump.Stop()
                    p1ComingDown = True
                    p1ComingUp = False
                    p1HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer1.Left < rectPlatform2.Left AndAlso rectPlatform2.Left < rectPlayer1.Right Then 'hits left

                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer1.Right > rectPlatform2.Right AndAlso rectPlatform2.Right > rectPlayer1.Left Then 'hits right
                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If
        '##############


        If rectPlayer1.IntersectsWith(rectPlatform3) Then
            If p1ComingDown And rectPlayer1.Bottom >= rectPlatform3.Top Then
                If p1IsJumping = 3 And rectPlayer1.Bottom < rectPlatform3.Bottom Then
                    p1IsJumping = 0
                    p1_blnIsJumping = False
                    p1IsOnGround = True
                    p1start = Nothing
                    p1tmrFall.Stop()
                    p1tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p1ComingUp And rectPlayer1.Top <= rectPlatform3.Bottom Then
                If p1IsJumping = 2 And rectPlayer1.Bottom > rectPlatform3.Bottom Then
                    p1IsJumping = 3
                    p1tmrJump.Stop()
                    p1ComingDown = True
                    p1ComingUp = False
                    p1HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer1.Left < rectPlatform3.Left AndAlso rectPlatform3.Left < rectPlayer1.Right Then 'hits left

                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer1.Right > rectPlatform3.Right AndAlso rectPlatform3.Right > rectPlayer1.Left Then 'hits right
                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If

        '############

        If rectPlayer1.IntersectsWith(rectPlatform4) Then
            If p1ComingDown And rectPlayer1.Bottom >= rectPlatform4.Top Then
                If p1IsJumping = 3 And rectPlayer1.Bottom < rectPlatform4.Bottom Then
                    p1IsJumping = 0
                    p1_blnIsJumping = False
                    p1IsOnGround = True
                    p1start = Nothing
                    p1tmrFall.Stop()
                    p1tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p1ComingUp And rectPlayer1.Top <= rectPlatform4.Bottom Then
                If p1IsJumping = 2 And rectPlayer1.Bottom > rectPlatform4.Bottom Then
                    p1IsJumping = 3
                    p1tmrJump.Stop()
                    p1ComingDown = True
                    p1ComingUp = False
                    p1HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer1.Left < rectPlatform4.Left AndAlso rectPlatform4.Left < rectPlayer1.Right Then 'hits left

                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer1.Right > rectPlatform4.Right AndAlso rectPlatform4.Right > rectPlayer1.Left Then 'hits right
                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If

        '##########

        If rectPlayer1.IntersectsWith(rectPlatform5) Then
            If p1ComingDown And rectPlayer1.Bottom >= rectPlatform5.Top Then
                If p1IsJumping = 3 And rectPlayer1.Bottom < rectPlatform5.Bottom Then
                    p1IsJumping = 0
                    p1_blnIsJumping = False
                    p1IsOnGround = True
                    p1start = Nothing
                    p1tmrFall.Stop()
                    p1tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p1ComingUp And rectPlayer1.Top <= rectPlatform5.Bottom Then
                If p1IsJumping = 2 And rectPlayer1.Bottom > rectPlatform5.Bottom Then
                    p1IsJumping = 3
                    p1tmrJump.Stop()
                    p1ComingDown = True
                    p1ComingUp = False
                    p1HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer1.Left < rectPlatform5.Left AndAlso rectPlatform5.Left < rectPlayer1.Right Then 'hits left

                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer1.Right > rectPlatform5.Right AndAlso rectPlatform5.Right > rectPlayer1.Left Then 'hits right
                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If

        '################

        If rectPlayer1.IntersectsWith(rectPlatform6) Then
            If p1ComingDown And rectPlayer1.Bottom >= rectPlatform6.Top Then
                If p1IsJumping = 3 And rectPlayer1.Bottom < rectPlatform6.Bottom Then
                    p1IsJumping = 0
                    p1_blnIsJumping = False
                    p1IsOnGround = True
                    p1start = Nothing
                    p1tmrFall.Stop()
                    p1tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p1ComingUp And rectPlayer1.Top <= rectPlatform6.Bottom Then
                If p1IsJumping = 2 And rectPlayer1.Bottom > rectPlatform6.Bottom Then
                    p1IsJumping = 3
                    p1tmrJump.Stop()
                    p1ComingDown = True
                    p1ComingUp = False
                    p1HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer1.Left < rectPlatform6.Left AndAlso rectPlatform6.Left < rectPlayer1.Right Then 'hits left

                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer1.Right > rectPlatform6.Right AndAlso rectPlatform6.Right > rectPlayer1.Left Then 'hits right
                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If

        '###############
        If rectPlayer1.IntersectsWith(rectPlatform7) Then
            If p1ComingDown And rectPlayer1.Bottom >= rectPlatform7.Top Then
                If p1IsJumping = 3 And rectPlayer1.Bottom < rectPlatform7.Bottom Then
                    p1IsJumping = 0
                    p1_blnIsJumping = False
                    p1IsOnGround = True
                    p1start = Nothing
                    p1tmrFall.Stop()
                    p1tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p1ComingUp And rectPlayer1.Top <= rectPlatform7.Bottom Then
                If p1IsJumping = 2 And rectPlayer1.Bottom > rectPlatform7.Bottom Then
                    p1IsJumping = 3
                    p1tmrJump.Stop()
                    p1ComingDown = True
                    p1ComingUp = False
                    p1HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer1.Left < rectPlatform7.Left AndAlso rectPlatform7.Left < rectPlayer1.Right Then 'hits left

                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer1.Right > rectPlatform7.Right AndAlso rectPlatform7.Right > rectPlayer1.Left Then 'hits right
                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If
        '###########
        If rectPlayer1.IntersectsWith(rectPlatform8) Then
            If p1ComingDown And rectPlayer1.Bottom >= rectPlatform8.Top Then
                If p1IsJumping = 3 And rectPlayer1.Bottom < rectPlatform8.Bottom Then
                    p1IsJumping = 0
                    p1_blnIsJumping = False
                    p1IsOnGround = True
                    p1start = Nothing
                    p1tmrFall.Stop()
                    p1tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p1ComingUp And rectPlayer1.Top <= rectPlatform8.Bottom Then
                If p1IsJumping = 2 And rectPlayer1.Bottom > rectPlatform8.Bottom Then
                    p1IsJumping = 3
                    p1tmrJump.Stop()
                    p1ComingDown = True
                    p1ComingUp = False
                    p1HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer1.Left < rectPlatform8.Left AndAlso rectPlatform8.Left < rectPlayer1.Right Then 'hits left

                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer1.Right > rectPlatform8.Right AndAlso rectPlatform8.Right > rectPlayer1.Left Then 'hits right
                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If
        '############
        If rectPlayer1.IntersectsWith(rectPlatform9) Then
            If p1ComingDown And rectPlayer1.Bottom >= rectPlatform9.Top Then
                If p1IsJumping = 3 And rectPlayer1.Bottom < rectPlatform9.Bottom Then
                    p1IsJumping = 0
                    p1_blnIsJumping = False
                    p1IsOnGround = True
                    p1start = Nothing
                    p1tmrFall.Stop()
                    p1tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p1ComingUp And rectPlayer1.Top <= rectPlatform9.Bottom Then
                If p1IsJumping = 2 And rectPlayer1.Bottom > rectPlatform9.Bottom Then
                    p1IsJumping = 3
                    p1tmrJump.Stop()
                    p1ComingDown = True
                    p1ComingUp = False
                    p1HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer1.Left < rectPlatform9.Left AndAlso rectPlatform9.Left < rectPlayer1.Right Then 'hits left

                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer1.Right > rectPlatform9.Right AndAlso rectPlatform9.Right > rectPlayer1.Left Then 'hits right
                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If
        '############
        If rectPlayer1.IntersectsWith(rectPlatform10) Then
            If p1ComingDown And rectPlayer1.Bottom >= rectPlatform10.Top Then
                If p1IsJumping = 3 And rectPlayer1.Bottom < rectPlatform10.Bottom Then
                    p1IsJumping = 0
                    p1_blnIsJumping = False
                    p1IsOnGround = True
                    p1start = Nothing
                    p1tmrFall.Stop()
                    p1tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p1ComingUp And rectPlayer1.Top <= rectPlatform10.Bottom Then
                If p1IsJumping = 2 And rectPlayer1.Bottom > rectPlatform10.Bottom Then
                    p1IsJumping = 3
                    p1tmrJump.Stop()
                    p1ComingDown = True
                    p1ComingUp = False
                    p1HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer1.Left < rectPlatform10.Left AndAlso rectPlatform10.Left < rectPlayer1.Right Then 'hits left

                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer1.Right > rectPlatform10.Right AndAlso rectPlatform10.Right > rectPlayer1.Left Then 'hits right
                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If
        '############
        If rectPlayer1.IntersectsWith(rectPlatform11) Then
            If p1ComingDown And rectPlayer1.Bottom >= rectPlatform11.Top Then
                If p1IsJumping = 3 And rectPlayer1.Bottom < rectPlatform11.Bottom Then
                    p1IsJumping = 0
                    p1_blnIsJumping = False
                    p1IsOnGround = True
                    p1start = Nothing
                    p1tmrFall.Stop()
                    p1tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p1ComingUp And rectPlayer1.Top <= rectPlatform11.Bottom Then
                If p1IsJumping = 2 And rectPlayer1.Bottom > rectPlatform11.Bottom Then
                    p1IsJumping = 3
                    p1tmrJump.Stop()
                    p1ComingDown = True
                    p1ComingUp = False
                    p1HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer1.Left < rectPlatform11.Left AndAlso rectPlatform11.Left < rectPlayer1.Right Then 'hits left

                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1RightIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer1.Right > rectPlatform11.Right AndAlso rectPlatform11.Right > rectPlayer1.Left Then 'hits right
                If (p1IsOnGround) And (p1_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p1ComingUp Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround = False Then
                        p1Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p1ComingUp = False And p1LeftIsPressed And p1IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If
        '############

        If rectPlayer1.IntersectsWith(rectMainPlatform) Then
            If p1ComingDown Then
                p1IsJumping = 0
                p1_blnIsJumping = False
                p1IsOnGround = True
                p1start = Nothing
                p1tmrFall.Stop()
                p1tmrJump.Start()
                p1ComingDown = False
                p1ComingUp = False
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub p2CheckCollisions()

        'p#IsJumping As int = 0, 1, 2, or 3
        '0 is on ground/running
        '1 is hit up
        '2 is going up
        '3 is falling down


        If rectPlayer2.IntersectsWith(rectMainPlatform) Or rectPlayer2.IntersectsWith(rectPlatform2) Or rectPlayer2.IntersectsWith(rectPlatform3) _
            Or rectPlayer2.IntersectsWith(rectPlatform4) Or rectPlayer2.IntersectsWith(rectPlatform5) Or rectPlayer2.IntersectsWith(rectPlatform6) _
            Or rectPlayer2.IntersectsWith(rectPlatform7) Or rectPlayer2.IntersectsWith(rectPlatform8) Or rectPlayer2.IntersectsWith(rectPlatform9) _
            Or rectPlayer2.IntersectsWith(rectPlatform10) Or rectPlayer2.IntersectsWith(rectPlatform11) Or rectPlayer2.IntersectsWith(rectTopWall) _
            Or rectPlayer2.IntersectsWith(rectInvisibleRightWall) Or rectPlayer2.IntersectsWith(rectInvisibleLeftWall) Then
            ' Do nothing.
        Else
            If (p2tmrFall.Enabled = False) And (p2ComingDown) Then
                p2CollidedPlatformSide = False
                p2IsJumping = 3
                p2tmrFall.Start()
            End If
        End If

        If p2HitHead Then
            If (p2tmrFall.Enabled = False) And (p2ComingDown) Then
                p2HitHead = False
                p2tmrFall.Start()
            End If
        End If

        '###################################################################################### Movement system 1: collisions only are on LANDING on platforms, can jump through (3D). Doesn't stop paintballs.

        'If rectPlayer2.IntersectsWith(rectPlatform1) Then
        '    If p2ComingDown And rectPlayer2.Bottom >= rectPlatform1.Top Then
        '        If p2IsJumping = 3 Then
        '            p2IsJumping = 0
        '            p2_blnIsJumping = False
        '            p2IsOnGround = True
        '            p2start = Nothing
        '            p2tmrFall.Stop()
        '            p2tmrJump.Start()
        '        End If
        '    End If
        'End If

        'If rectPlayer2.IntersectsWith(rectMainPlatform) Then
        '    If p2ComingDown And rectPlayer2.Bottom >= rectMainPlatform.Top Then
        '        If p2IsJumping = 3 Then
        '            p2IsJumping = 0
        '            p2_blnIsJumping = False
        '            p2IsOnGround = True
        '            p2start = Nothing

        '            p2tmrJump.Start()
        '        End If
        '        p2tmrFall.Stop()
        '    End If
        'End If

        '###################################################################################### Movement system 2: collisions on all four sides, more physical and realistic. Prevents paintball shots..

        If rectPlayer2.IntersectsWith(rectTopWall) Then
            If p2ComingUp And rectPlayer2.Top <= rectTopWall.Bottom Then
                If p2IsJumping = 2 And rectPlayer2.Bottom > rectTopWall.Bottom Then
                    p2IsJumping = 3
                    p2tmrJump.Stop()
                    p2ComingDown = True
                    p2ComingUp = False
                    p2HitHead = True
                    Exit Sub
                End If
            End If
        End If

        '###################
        'If rectPlayer2.IntersectsWith(rectInvisibleRightWall) Then
        '    If rectPlayer2.Right > rectInvisibleRightWall.Left Then 'hits left
        '        p2Sprite.UpperLeft.X -= 10
        '        Exit Sub
        '    End If
        'End If
        ''###################
        'If rectPlayer2.IntersectsWith(rectInvisibleLeftWall) Then
        '    p2Sprite.UpperLeft.X += 10
        '    Exit Sub
        'End If
        '###################

        If rectPlayer2.IntersectsWith(rectPlatform2) Then
            If p2ComingDown And rectPlayer2.Bottom >= rectPlatform2.Top Then
                If p2IsJumping = 3 And rectPlayer2.Bottom < rectPlatform2.Bottom Then
                    p2IsJumping = 0
                    p2_blnIsJumping = False
                    p2IsOnGround = True
                    p2start = Nothing
                    p2tmrFall.Stop()
                    p2tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p2ComingUp And rectPlayer2.Top <= rectPlatform2.Bottom Then
                If p2IsJumping = 2 And rectPlayer2.Bottom > rectPlatform2.Bottom Then
                    p2IsJumping = 3
                    p2tmrJump.Stop()
                    p2ComingDown = True
                    p2ComingUp = False
                    p2HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer2.Left < rectPlatform2.Left AndAlso rectPlatform2.Left < rectPlayer2.Right Then 'hits left

                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer2.Right > rectPlatform2.Right AndAlso rectPlatform2.Right > rectPlayer2.Left Then 'hits right
                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If
        '##############


        If rectPlayer2.IntersectsWith(rectPlatform3) Then
            If p2ComingDown And rectPlayer2.Bottom >= rectPlatform3.Top Then
                If p2IsJumping = 3 And rectPlayer2.Bottom < rectPlatform3.Bottom Then
                    p2IsJumping = 0
                    p2_blnIsJumping = False
                    p2IsOnGround = True
                    p2start = Nothing
                    p2tmrFall.Stop()
                    p2tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p2ComingUp And rectPlayer2.Top <= rectPlatform3.Bottom Then
                If p2IsJumping = 2 And rectPlayer2.Bottom > rectPlatform3.Bottom Then
                    p2IsJumping = 3
                    p2tmrJump.Stop()
                    p2ComingDown = True
                    p2ComingUp = False
                    p2HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer2.Left < rectPlatform3.Left AndAlso rectPlatform3.Left < rectPlayer2.Right Then 'hits left

                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer2.Right > rectPlatform3.Right AndAlso rectPlatform3.Right > rectPlayer2.Left Then 'hits right
                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If

        '############

        If rectPlayer2.IntersectsWith(rectPlatform4) Then
            If p2ComingDown And rectPlayer2.Bottom >= rectPlatform4.Top Then
                If p2IsJumping = 3 And rectPlayer2.Bottom < rectPlatform4.Bottom Then
                    p2IsJumping = 0
                    p2_blnIsJumping = False
                    p2IsOnGround = True
                    p2start = Nothing
                    p2tmrFall.Stop()
                    p2tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p2ComingUp And rectPlayer2.Top <= rectPlatform4.Bottom Then
                If p2IsJumping = 2 And rectPlayer2.Bottom > rectPlatform4.Bottom Then
                    p2IsJumping = 3
                    p2tmrJump.Stop()
                    p2ComingDown = True
                    p2ComingUp = False
                    p2HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer2.Left < rectPlatform4.Left AndAlso rectPlatform4.Left < rectPlayer2.Right Then 'hits left

                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer2.Right > rectPlatform4.Right AndAlso rectPlatform4.Right > rectPlayer2.Left Then 'hits right
                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If

        '##########

        If rectPlayer2.IntersectsWith(rectPlatform5) Then
            If p2ComingDown And rectPlayer2.Bottom >= rectPlatform5.Top Then
                If p2IsJumping = 3 And rectPlayer2.Bottom < rectPlatform5.Bottom Then
                    p2IsJumping = 0
                    p2_blnIsJumping = False
                    p2IsOnGround = True
                    p2start = Nothing
                    p2tmrFall.Stop()
                    p2tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p2ComingUp And rectPlayer2.Top <= rectPlatform5.Bottom Then
                If p2IsJumping = 2 And rectPlayer2.Bottom > rectPlatform5.Bottom Then
                    p2IsJumping = 3
                    p2tmrJump.Stop()
                    p2ComingDown = True
                    p2ComingUp = False
                    p2HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer2.Left < rectPlatform5.Left AndAlso rectPlatform5.Left < rectPlayer2.Right Then 'hits left

                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer2.Right > rectPlatform5.Right AndAlso rectPlatform5.Right > rectPlayer2.Left Then 'hits right
                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If

        '################

        If rectPlayer2.IntersectsWith(rectPlatform6) Then
            If p2ComingDown And rectPlayer2.Bottom >= rectPlatform6.Top Then
                If p2IsJumping = 3 And rectPlayer2.Bottom < rectPlatform6.Bottom Then
                    p2IsJumping = 0
                    p2_blnIsJumping = False
                    p2IsOnGround = True
                    p2start = Nothing
                    p2tmrFall.Stop()
                    p2tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p2ComingUp And rectPlayer2.Top <= rectPlatform6.Bottom Then
                If p2IsJumping = 2 And rectPlayer2.Bottom > rectPlatform6.Bottom Then
                    p2IsJumping = 3
                    p2tmrJump.Stop()
                    p2ComingDown = True
                    p2ComingUp = False
                    p2HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer2.Left < rectPlatform6.Left AndAlso rectPlatform6.Left < rectPlayer2.Right Then 'hits left

                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer2.Right > rectPlatform6.Right AndAlso rectPlatform6.Right > rectPlayer2.Left Then 'hits right
                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If

        '###############
        If rectPlayer2.IntersectsWith(rectPlatform7) Then
            If p2ComingDown And rectPlayer2.Bottom >= rectPlatform7.Top Then
                If p2IsJumping = 3 And rectPlayer2.Bottom < rectPlatform7.Bottom Then
                    p2IsJumping = 0
                    p2_blnIsJumping = False
                    p2IsOnGround = True
                    p2start = Nothing
                    p2tmrFall.Stop()
                    p2tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p2ComingUp And rectPlayer2.Top <= rectPlatform7.Bottom Then
                If p2IsJumping = 2 And rectPlayer2.Bottom > rectPlatform7.Bottom Then
                    p2IsJumping = 3
                    p2tmrJump.Stop()
                    p2ComingDown = True
                    p2ComingUp = False
                    p2HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer2.Left < rectPlatform7.Left AndAlso rectPlatform7.Left < rectPlayer2.Right Then 'hits left

                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer2.Right > rectPlatform7.Right AndAlso rectPlatform7.Right > rectPlayer2.Left Then 'hits right
                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If
        '###########
        If rectPlayer2.IntersectsWith(rectPlatform8) Then
            If p2ComingDown And rectPlayer2.Bottom >= rectPlatform8.Top Then
                If p2IsJumping = 3 And rectPlayer2.Bottom < rectPlatform8.Bottom Then
                    p2IsJumping = 0
                    p2_blnIsJumping = False
                    p2IsOnGround = True
                    p2start = Nothing
                    p2tmrFall.Stop()
                    p2tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p2ComingUp And rectPlayer2.Top <= rectPlatform8.Bottom Then
                If p2IsJumping = 2 And rectPlayer2.Bottom > rectPlatform8.Bottom Then
                    p2IsJumping = 3
                    p2tmrJump.Stop()
                    p2ComingDown = True
                    p2ComingUp = False
                    p2HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer2.Left < rectPlatform8.Left AndAlso rectPlatform8.Left < rectPlayer2.Right Then 'hits left

                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer2.Right > rectPlatform8.Right AndAlso rectPlatform8.Right > rectPlayer2.Left Then 'hits right
                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If
        '############
        If rectPlayer2.IntersectsWith(rectPlatform9) Then
            If p2ComingDown And rectPlayer2.Bottom >= rectPlatform9.Top Then
                If p2IsJumping = 3 And rectPlayer2.Bottom < rectPlatform9.Bottom Then
                    p2IsJumping = 0
                    p2_blnIsJumping = False
                    p2IsOnGround = True
                    p2start = Nothing
                    p2tmrFall.Stop()
                    p2tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p2ComingUp And rectPlayer2.Top <= rectPlatform9.Bottom Then
                If p2IsJumping = 2 And rectPlayer2.Bottom > rectPlatform9.Bottom Then
                    p2IsJumping = 3
                    p2tmrJump.Stop()
                    p2ComingDown = True
                    p2ComingUp = False
                    p2HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer2.Left < rectPlatform9.Left AndAlso rectPlatform9.Left < rectPlayer2.Right Then 'hits left

                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer2.Right > rectPlatform9.Right AndAlso rectPlatform9.Right > rectPlayer2.Left Then 'hits right
                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If
        '############
        If rectPlayer2.IntersectsWith(rectPlatform10) Then
            If p2ComingDown And rectPlayer2.Bottom >= rectPlatform10.Top Then
                If p2IsJumping = 3 And rectPlayer2.Bottom < rectPlatform10.Bottom Then
                    p2IsJumping = 0
                    p2_blnIsJumping = False
                    p2IsOnGround = True
                    p2start = Nothing
                    p2tmrFall.Stop()
                    p2tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p2ComingUp And rectPlayer2.Top <= rectPlatform10.Bottom Then
                If p2IsJumping = 2 And rectPlayer2.Bottom > rectPlatform10.Bottom Then
                    p2IsJumping = 3
                    p2tmrJump.Stop()
                    p2ComingDown = True
                    p2ComingUp = False
                    p2HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer2.Left < rectPlatform10.Left AndAlso rectPlatform10.Left < rectPlayer2.Right Then 'hits left

                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer2.Right > rectPlatform10.Right AndAlso rectPlatform10.Right > rectPlayer2.Left Then 'hits right
                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If
        '############
        If rectPlayer2.IntersectsWith(rectPlatform11) Then
            If p2ComingDown And rectPlayer2.Bottom >= rectPlatform11.Top Then
                If p2IsJumping = 3 And rectPlayer2.Bottom < rectPlatform11.Bottom Then
                    p2IsJumping = 0
                    p2_blnIsJumping = False
                    p2IsOnGround = True
                    p2start = Nothing
                    p2tmrFall.Stop()
                    p2tmrJump.Start()
                    Exit Sub
                End If
            End If

            If p2ComingUp And rectPlayer2.Top <= rectPlatform11.Bottom Then
                If p2IsJumping = 2 And rectPlayer2.Bottom > rectPlatform11.Bottom Then
                    p2IsJumping = 3
                    p2tmrJump.Stop()
                    p2ComingDown = True
                    p2ComingUp = False
                    p2HitHead = True
                    Exit Sub
                End If
            End If

            If rectPlayer2.Left < rectPlatform11.Left AndAlso rectPlatform11.Left < rectPlayer2.Right Then 'hits left

                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X -= 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2RightIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
            If rectPlayer2.Right > rectPlatform11.Right AndAlso rectPlatform11.Right > rectPlayer2.Left Then 'hits right
                If (p2IsOnGround) And (p2_blnIsJumping = True) Then                 'if the player lands on top of the platform from jumping, do nothing
                    'player is on platform, don't do anything
                Else                                                            'otherwise, player MUST be falling or coming up and hit the left side
                    If p2ComingUp Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround = False Then
                        p2Sprite.UpperLeft.X += 6
                        Exit Sub
                    ElseIf p2ComingUp = False And p2LeftIsPressed And p2IsOnGround Then
                        'do nothing, player is trying to run on the platform
                    End If
                End If
            End If
        End If
        '############

        If rectPlayer2.IntersectsWith(rectMainPlatform) Then
            If p2ComingDown Then
                p2IsJumping = 0
                p2_blnIsJumping = False
                p2IsOnGround = True
                p2start = Nothing
                p2tmrFall.Stop()
                p2tmrJump.Start()
                p2ComingDown = False
                p2ComingUp = False
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub CheckIfPlayerDied()
        If p1HealthBar.Value = 0 Then
            EndGame()
        End If

        If p2HealthBar.Value = 0 Then
            EndGame()
        End If
    End Sub

    Private Sub p1tmrJump_Tick(sender As Object, e As EventArgs) Handles p1tmrJump.Tick



        If p1IsJumping = 1 Then
            If p1IsCrouching = False Then
                p1IsJumping = 2
                p1_blnIsJumping = True
                p1ComingUp = True
                p1ComingDown = False
                p1IsOnGround = False
                p1start = p1Sprite.UpperLeft.Y
            End If
        End If
        If p1IsJumping = 2 Then
            p1Sprite.UpperLeft.Y -= 4
            If p1Sprite.UpperLeft.Y <= p1start - 150 Then ' jump height
                p1IsJumping = 3
            End If
        ElseIf p1IsJumping = 3 Then
            'jump has hit peak, no matter what, stick must fall until a collision
            p1ComingUp = False
            p1ComingDown = True
            p1tmrJump.Stop()
            p1tmrFall.Start()
        End If
    End Sub

    Private Sub p2tmrJump_Tick(sender As Object, e As EventArgs) Handles p2tmrJump.Tick
        If p2IsJumping = 1 Then
            p2IsJumping = 2
            p2_blnIsJumping = True
            p2ComingUp = True
            p2ComingDown = False
            p2IsOnGround = False
            p2start = p2Sprite.UpperLeft.Y
        End If
        If p2IsJumping = 2 Then
            p2Sprite.UpperLeft.Y -= 4
            If p2Sprite.UpperLeft.Y <= p2start - 150 Then
                p2IsJumping = 3
            End If
        ElseIf p2IsJumping = 3 Then
            'jump has hit peak, no matter what, stick must fall until a collision
            p2ComingUp = False
            p2ComingDown = True
            p2tmrJump.Stop()
            p2tmrFall.Start()
        End If
    End Sub

    Private Sub p1tmrFall_Tick(sender As Object, e As EventArgs) Handles p1tmrFall.Tick

        If p1IsCrouching Then
            p1IsCrouching = False
            p1tmrCrouch.Stop()
            p1tmrStandUp.Stop()
            intPlayer1StandUpTick = 0
            intPlayer1StartCrouchTick = 0
        End If

        If p1IsJumping = 0 Then
            If p1ComingDown Then
                ' Do nothing.
            Else
                p1tmrFall.Stop()
            End If

        End If
        p1Sprite.UpperLeft.Y += 4
        p1IsOnGround = False

        If p1IsJumping = 1 Then
            p1IsJumping = 3
        End If

        If p1IsJumping = 2 Then ' FIXES GETTING STUCK IN AIR WHEN JUMPING ON CORNER OF PLATFORM - yay this bothered me for over a year so like it's a huge accomplishment with a simple fix. Of course it is.
            p1IsJumping = 3
        End If

        If p1IsCrouching Then
            p1IsJumping = 4
        End If
    End Sub

    Private Sub Player1Shoot()
        If shootDelayIsActive Then
            Exit Sub
        End If
        For Each shot In p1Shots
            If shot.IsAlive = False Then
                shot.IsAlive = True
                shot.TimeToLive = 5 ' change this so shots fall and die out
                If p1Dir = "Right" Then
                    shot.Angle = 0
                ElseIf p1Dir = "Left" Then
                    shot.Angle = 180
                End If
                shot.SetVelocity(8)                                                                                     'GLITCH KILLER ENGAGED
                shot.UpperLeft = p1ShootPoint                                                                'GLITCH IN YO FACE FOOL
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(2, False, sfxVolume)
                End With
                Return
            End If
        Next
    End Sub

    Private Sub Player1ShootUp()
        For Each shot In p1Shots
            If shot.IsAlive = False Then
                shot.IsAlive = True
                shot.TimeToLive = 5 ' change this so shots fall and die out
                If p1Dir = "Right" Then
                    shot.Angle = 15
                ElseIf p1Dir = "Left" Then
                    shot.Angle = 195
                End If
                shot.SetVelocity(8)                                                                                     'GLITCH KILLER ENGAGED
                shot.UpperLeft = p1ShootPoint                                                                'GLITCH IN YO FACE FOOL
                'shotSound.Play()
                Return
            End If
        Next
    End Sub

    Private Sub Player1ShootDown()
        For Each shot In p1Shots
            If shot.IsAlive = False Then
                shot.IsAlive = True
                shot.TimeToLive = 5 ' change this so shots fall and die out
                If p1Dir = "Right" Then
                    shot.Angle = -15
                ElseIf p1Dir = "Left" Then
                    shot.Angle = 165
                End If
                shot.SetVelocity(8)                                                                                     'GLITCH KILLER ENGAGED
                shot.UpperLeft = p1ShootPoint                                                                'GLITCH IN YO FACE FOOL
                'shotSound.Play()
                Return
            End If
        Next
    End Sub

    Private Sub InitializePlayer1Shots(a)
        For i = a To p1Ammo - 1
            p1Shots(i) = New Sprite()
            p1Shots(i).IsAlive = False
            p1Shots(i).SetImageResource(My.Resources.shotRedWide)
            p1Shots(i).MaxSpeed = MAX_SPEED
        Next
    End Sub

    Private Sub PaintPlayer1Shots(ByRef myGraphics As Graphics)
        For Each shot In p1Shots
            If (shot.IsAlive = True) Then
                shot.PaintRotatedImage(myGraphics, shot.Angle, shot.GetCenter(), True)
            End If
        Next
    End Sub

    Private Sub MovePlayer1Shots()
        For Each shot In p1Shots
            shot.Move(Me.ClientSize) 'time to live should be so that it doesn't die, but f falls down until a collision. Yay no sides for collision, just use a RECT.
        Next
    End Sub

    Private Sub CheckPlayer1ShotCollisions()

        For Each shot In p1Shots

            If (shot.IsCollided(p2Sprite)) Then
                If p2IsCrouching Then ' Don't hit the guy, graze over his head. I couldn't make the stick figures go any lower without loss of pixel quality.
                    ' Ok, now we can hit the guy as long as he's low enough.
                    If blnP2CanBeHit = True Or p1IsCrouching Then
                        If p2HealthBar.Value > 0 Then ' If not, then do nothing; otherwise, we'll run into an exception.
                            If p2IsShielded Then
                                p2HealthBar.Value -= 1
                            Else
                                If p2HealthBar.Value - 2 <= 0 Then
                                    p2HealthBar.Value = 0
                                Else
                                    p2HealthBar.Value -= 2
                                End If
                            End If
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(1, False, sfxVolume)
                            End With
                            shot.IsAlive = False
                        End If
                    End If
                Else
                    If p2HealthBar.Value > 0 Then ' If not, then do nothing; otherwise, we'll run into an exception.
                        If p2IsShielded Then
                            p2HealthBar.Value -= 1
                        Else
                            If p2HealthBar.Value - 2 <= 0 Then
                                p2HealthBar.Value = 0
                            Else
                                p2HealthBar.Value -= 2
                            End If
                        End If
                        intSound += 1
                        With sound
                            .Name = "sound" & intSound
                            .Play(1, False, sfxVolume)
                        End With
                        shot.IsAlive = False
                    End If
                End If
            End If

            If shot.IsCollided(spriteInvisibleRightWall) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If shot.IsCollided(spriteInvisibleLeftWall) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform2)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform3)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform4)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform5)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform6)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform7)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform8)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform9)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform10)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform11)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(mainPlatformSprite)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If
        Next


    End Sub

    Private Sub Player2Shoot()
        TheResetBug = False
        If shootDelayIsActive Then
            Exit Sub
        End If
        For Each shot In p2Shots
            If shot.IsAlive = False Then
                shot.IsAlive = True
                shot.TimeToLive = 5 ' change this so shots fall and die out
                If p2Dir = "Right" Then
                    shot.Angle = 0
                ElseIf p2Dir = "Left" Then
                    shot.Angle = 180
                End If
                shot.SetVelocity(8)                                                                                     'GLITCH KILLER ENGAGED
                shot.UpperLeft = p2ShootPoint                                                                'GLITCH IN YO FACE FOOL
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(2, False, sfxVolume)
                End With
                Return
            End If
        Next
    End Sub

    Private Sub Player2ShootUp()
        For Each shot In p2Shots
            If shot.IsAlive = False Then
                shot.IsAlive = True
                shot.TimeToLive = 5 ' change this so shots fall and die out
                If p2Dir = "Right" Then
                    shot.Angle = 15
                ElseIf p2Dir = "Left" Then
                    shot.Angle = 195
                End If
                shot.SetVelocity(8)                                                                                     'GLITCH KILLER ENGAGED
                shot.UpperLeft = p2ShootPoint                                                                'GLITCH IN YO FACE FOOL
                'shotSound.Play()
                Return
            End If
        Next
    End Sub

    Private Sub Player2ShootDown()
        For Each shot In p2Shots
            If shot.IsAlive = False Then
                shot.IsAlive = True
                shot.TimeToLive = 5 ' change this so shots fall and die out
                If p2Dir = "Right" Then
                    shot.Angle = -15
                ElseIf p2Dir = "Left" Then
                    shot.Angle = 165
                End If
                shot.SetVelocity(8)                                                                                     'GLITCH KILLER ENGAGED
                shot.UpperLeft = p2ShootPoint                                                                'GLITCH IN YO FACE FOOL
                'shotSound.Play()
                Return
            End If
        Next
    End Sub

    Private Sub InitializePlayer2Shots(b)
        For i = b To p2Ammo - 1
            p2Shots(i) = New Sprite()
            p2Shots(i).IsAlive = False
            p2Shots(i).SetImageResource(My.Resources.shotBlueWide)
            p2Shots(i).MaxSpeed = MAX_SPEED
        Next
    End Sub

    Private Sub PaintPlayer2Shots(ByRef myGraphics As Graphics)
        For Each shot In p2Shots
            If (shot.IsAlive = True) Then
                shot.PaintRotatedImage(myGraphics, shot.Angle, shot.GetCenter(), True)
            End If
        Next
    End Sub

    Private Sub MovePlayer2Shots()
        For Each shot In p2Shots
            shot.Move(Me.ClientSize) 'time to live should be so that it doesn't die, but f falls down until a collision. Yay no sides for collision, just use a RECT.
        Next
    End Sub

    Private Sub CheckPlayer2ShotCollisions()
        For Each shot In p2Shots
            If (shot.IsCollided(p1Sprite)) Then
                If p1IsCrouching Then ' Don't hit the guy, graze over his head. I couldn't make the stick figures go any lower without loss of pixel quality.
                    ' Ok, now we can hit the guy as long as he's low enough.
                    If blnP1CanBeHit = True Or p1IsCrouching Then
                        If p1HealthBar.Value > 0 Then ' If not, then do nothing; otherwise, we'll run into an exception.
                            If p1IsShielded Then
                                p1HealthBar.Value -= 1
                            Else
                                If p1HealthBar.Value - 2 <= 0 Then
                                    p1HealthBar.Value = 0
                                Else
                                    p1HealthBar.Value -= 2
                                End If
                            End If
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(1, False, sfxVolume)
                            End With
                            shot.IsAlive = False
                        End If
                    End If
                Else
                    If p1HealthBar.Value > 0 Then ' If not, then do nothing; otherwise, we'll run into an exception.
                        If p1IsShielded Then
                            p1HealthBar.Value -= 1
                        Else
                            If p1HealthBar.Value - 2 <= 0 Then
                                p1HealthBar.Value = 0
                            Else
                                p1HealthBar.Value -= 2
                            End If
                        End If
                        intSound += 1
                        With sound
                            .Name = "sound" & intSound
                            .Play(1, False, sfxVolume)
                        End With
                        shot.IsAlive = False
                    End If
                End If
            End If

            If shot.IsCollided(spriteInvisibleRightWall) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If shot.IsCollided(spriteInvisibleLeftWall) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform2)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform3)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform4)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform5)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform6)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform7)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform8)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform9)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform10)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(spritePlatform11)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If

            If (shot.IsCollided(mainPlatformSprite)) Then
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                shot.IsAlive = False
            End If
        Next
    End Sub

    Private Sub p1tmrRightIdle_Tick(sender As Object, e As EventArgs) Handles p1tmrRightIdle.Tick
        Select Case p1RightIdleFrame
            Case 1
                'frame 2
                p1Sprite.SetImageResource(My.Resources.redRightIdle2)
                p1RightIdleFrame += 1
                'p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
            Case 2
                'frame 3
                p1Sprite.SetImageResource(My.Resources.redRightIdle3)
                p1RightIdleFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
            Case 3
                'frame 4
                p1Sprite.SetImageResource(My.Resources.redRightIdle4)
                p1RightIdleFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
            Case 4
                'frame 5
                p1Sprite.SetImageResource(My.Resources.redRightIdle5)
                p1RightIdleFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                'p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
            Case 5
                'frame 6
                p1Sprite.SetImageResource(My.Resources.redRightIdle6)
                p1RightIdleFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                'p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 15
            Case 6
                'frame 7
                p1Sprite.SetImageResource(My.Resources.redRightIdle7)
                p1RightIdleFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                'p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
            Case 7
                'frame 8
                p1Sprite.SetImageResource(My.Resources.redRightIdle8)
                p1RightIdleFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
            Case 8
                'frame 9
                p1Sprite.SetImageResource(My.Resources.redRightIdle9)
                p1RightIdleFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
            Case 9
                'frame 10
                p1Sprite.SetImageResource(My.Resources.redRightIdle10)
                p1RightIdleFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
            Case 10
                'start over at frame 1
                p1Sprite.SetImageResource(My.Resources.redRightIdle1)
                p1RightIdleFrame = 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
        End Select
    End Sub

    Private Sub p1tmrLeftIdle_Tick(sender As Object, e As EventArgs) Handles p1tmrLeftIdle.Tick
        Select Case p1LeftIdleFrame
            Case 1
                'frame 2
                p1Sprite.SetImageResource(My.Resources.redLeftIdle2)
                p1LeftIdleFrame += 1
                'p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
            Case 2
                'frame 3
                p1Sprite.SetImageResource(My.Resources.redLeftIdle3)
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                p1LeftIdleFrame += 1
            Case 3
                'frame 4
                p1Sprite.SetImageResource(My.Resources.redLeftIdle4)
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                p1LeftIdleFrame += 1
            Case 4
                'frame 5
                p1Sprite.SetImageResource(My.Resources.redLeftIdle5)
                p1LeftIdleFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                'p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
            Case 5
                'frame 6
                p1Sprite.SetImageResource(My.Resources.redLeftIdle6)
                p1LeftIdleFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                'p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 15
            Case 6
                'frame 7
                p1Sprite.SetImageResource(My.Resources.redLeftIdle7)
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                p1LeftIdleFrame += 1
                'p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
            Case 7
                'frame 8
                p1Sprite.SetImageResource(My.Resources.redLeftIdle8)
                p1LeftIdleFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
            Case 8
                'frame 9
                p1Sprite.SetImageResource(My.Resources.redLeftIdle9)
                p1LeftIdleFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
            Case 9
                'frame 10
                p1Sprite.SetImageResource(My.Resources.redLeftIdle10)
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                p1LeftIdleFrame += 1
            Case 10
                'start over at frame 1
                p1Sprite.SetImageResource(My.Resources.redLeftIdle1)
                p1LeftIdleFrame = 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
        End Select
    End Sub

    Private Sub p2tmrLeftIdle_Tick(sender As Object, e As EventArgs) Handles p2tmrLeftIdle.Tick
        Select Case p2LeftIdleFrame
            Case 1
                'frame 2
                p2Sprite.SetImageResource(My.Resources.blueLeftIdle2)
                p2LeftIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 2
                'frame 3
                p2Sprite.SetImageResource(My.Resources.blueLeftIdle3)
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                p2LeftIdleFrame += 1
            Case 3
                'frame 4
                p2Sprite.SetImageResource(My.Resources.blueLeftIdle4)
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                p2LeftIdleFrame += 1
            Case 4
                'frame 5
                p2Sprite.SetImageResource(My.Resources.blueLeftIdle5)
                p2LeftIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 5
                'frame 6
                p2Sprite.SetImageResource(My.Resources.blueLeftIdle6)
                p2LeftIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 6
                'frame 7
                p2Sprite.SetImageResource(My.Resources.blueLeftIdle7)
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                p2LeftIdleFrame += 1
            Case 7
                'frame 8
                p2Sprite.SetImageResource(My.Resources.blueLeftIdle8)
                p2LeftIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 8
                'frame 9
                p2Sprite.SetImageResource(My.Resources.blueLeftIdle9)
                p2LeftIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 9
                'frame 10
                p2Sprite.SetImageResource(My.Resources.blueLeftIdle10)
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                p2LeftIdleFrame += 1
            Case 10
                'start over at frame 1
                p2Sprite.SetImageResource(My.Resources.blueLeftIdle1)
                p2LeftIdleFrame = 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
        End Select
    End Sub

    Private Sub p2tmrRightIdle_Tick(sender As Object, e As EventArgs) Handles p2tmrRightIdle.Tick
        Select Case p2RightIdleFrame
            Case 1
                'frame 2
                p2Sprite.SetImageResource(My.Resources.blueRightIdle2)
                p2RightIdleFrame += 1
                'p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 2
                'frame 3
                p2Sprite.SetImageResource(My.Resources.blueRightIdle3)
                p2RightIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 3
                'frame 4
                p2Sprite.SetImageResource(My.Resources.blueRightIdle4)
                p2RightIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 4
                'frame 5
                p2Sprite.SetImageResource(My.Resources.blueRightIdle5)
                p2RightIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 5
                'frame 6
                p2Sprite.SetImageResource(My.Resources.blueRightIdle6)
                p2RightIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 6
                'frame 7
                p2Sprite.SetImageResource(My.Resources.blueRightIdle7)
                p2RightIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 7
                'frame 8
                p2Sprite.SetImageResource(My.Resources.blueRightIdle8)
                p2RightIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 8
                'frame 9
                p2Sprite.SetImageResource(My.Resources.blueRightIdle9)
                p2RightIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 9
                'frame 10
                p2Sprite.SetImageResource(My.Resources.blueRightIdle10)
                p2RightIdleFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 10
                'start over at frame 1
                p2Sprite.SetImageResource(My.Resources.blueRightIdle1)
                p2RightIdleFrame = 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
        End Select
    End Sub

    Private Sub p1tmrRightRun_Tick(sender As Object, e As EventArgs) Handles p1tmrRightRun.Tick
        Select Case p1RightRunFrame
            Case 1
                'frame 2
                p1Sprite.SetImageResource(My.Resources.redRightRun2)
                p1RightRunFrame += 1
                'p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 2
                'frame 3
                p1Sprite.SetImageResource(My.Resources.redRightRun3)
                p1RightRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 3
                'frame 4
                p1Sprite.SetImageResource(My.Resources.redRightRun4)
                p1RightRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 4
                'frame 5
                p1Sprite.SetImageResource(My.Resources.redRightRun5)
                p1RightRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
                'p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
            Case 5
                'frame 6
                p1Sprite.SetImageResource(My.Resources.redRightRun6)
                p1RightRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
                'p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 15
            Case 6
                'frame 7
                p1Sprite.SetImageResource(My.Resources.redRightRun7)
                p1RightRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
                'p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
            Case 7
                'frame 8
                p1Sprite.SetImageResource(My.Resources.redRightRun8)
                p1RightRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 8
                'frame 9
                p1Sprite.SetImageResource(My.Resources.redRightRun9)
                p1RightRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 9
                'frame 10
                p1Sprite.SetImageResource(My.Resources.redRightRun10)
                p1RightRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 10
                'frame 11
                p1Sprite.SetImageResource(My.Resources.redRightRun11)
                p1RightRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 11
                'frame 12
                p1Sprite.SetImageResource(My.Resources.redRightRun12)
                p1RightRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 12
                'start over at frame 1
                p1Sprite.SetImageResource(My.Resources.redRightRun1)
                p1RightRunFrame = 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
        End Select
    End Sub

    Private Sub p1tmrLeftRun_Tick(sender As Object, e As EventArgs) Handles p1tmrLeftRun.Tick
        Select Case p1LeftRunFrame
            Case 1
                'frame 2
                p1Sprite.SetImageResource(My.Resources.redLeftRun2)
                p1LeftRunFrame += 1
                'p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 2
                'frame 3
                p1Sprite.SetImageResource(My.Resources.redLeftRun3)
                p1LeftRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 3
                'frame 4
                p1Sprite.SetImageResource(My.Resources.redLeftRun4)
                p1LeftRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 4
                'frame 5
                p1Sprite.SetImageResource(My.Resources.redLeftRun5)
                p1LeftRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
                'p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
            Case 5
                'frame 6
                p1Sprite.SetImageResource(My.Resources.redLeftRun6)
                p1LeftRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
                'p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 15
            Case 6
                'frame 7
                p1Sprite.SetImageResource(My.Resources.redLeftRun7)
                p1LeftRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
                'p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
            Case 7
                'frame 8
                p1Sprite.SetImageResource(My.Resources.redLeftRun8)
                p1LeftRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 8
                'frame 9
                p1Sprite.SetImageResource(My.Resources.redLeftRun9)
                p1LeftRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 9
                'frame 10
                p1Sprite.SetImageResource(My.Resources.redLeftRun10)
                p1LeftRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 10
                'frame 11
                p1Sprite.SetImageResource(My.Resources.redLeftRun11)
                p1LeftRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 11
                'frame 12
                p1Sprite.SetImageResource(My.Resources.redLeftRun12)
                p1LeftRunFrame += 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
            Case 12
                'start over at frame 1
                p1Sprite.SetImageResource(My.Resources.redLeftRun1)
                p1LeftRunFrame = 1
                p1ShootPoint.X = p1Sprite.UpperLeft.X
                p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
        End Select
    End Sub

    Private Sub p2tmrRightRun_Tick(sender As Object, e As EventArgs) Handles p2tmrRightRun.Tick
        Select Case p2RightRunFrame
            Case 1
                'frame 2
                p2Sprite.SetImageResource(My.Resources.blueRightRun2)
                p2RightRunFrame += 1
                'p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 2
                'frame 3
                p2Sprite.SetImageResource(My.Resources.blueRightRun3)
                p2RightRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 3
                'frame 4
                p2Sprite.SetImageResource(My.Resources.blueRightRun4)
                p2RightRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 4
                'frame 5
                p2Sprite.SetImageResource(My.Resources.blueRightRun5)
                p2RightRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                'p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
            Case 5
                'frame 6
                p2Sprite.SetImageResource(My.Resources.blueRightRun6)
                p2RightRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                'p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 15
            Case 6
                'frame 7
                p2Sprite.SetImageResource(My.Resources.blueRightRun7)
                p2RightRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                'p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
            Case 7
                'frame 8
                p2Sprite.SetImageResource(My.Resources.blueRightRun8)
                p2RightRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 8
                'frame 9
                p2Sprite.SetImageResource(My.Resources.blueRightRun9)
                p2RightRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 9
                'frame 10
                p2Sprite.SetImageResource(My.Resources.blueRightRun10)
                p2RightRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 10
                'frame 11
                p2Sprite.SetImageResource(My.Resources.blueRightRun11)
                p2RightRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 11
                'frame 12
                p2Sprite.SetImageResource(My.Resources.blueRightRun12)
                p2RightRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 12
                'start over at frame 1
                p2Sprite.SetImageResource(My.Resources.blueRightRun1)
                p2RightRunFrame = 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
        End Select
    End Sub

    Private Sub p2tmrLeftRun_Tick(sender As Object, e As EventArgs) Handles p2tmrLeftRun.Tick
        Select Case p2LeftRunFrame
            Case 1
                'frame 2
                p2Sprite.SetImageResource(My.Resources.blueLeftRun2)
                p2LeftRunFrame += 1
                'p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 2
                'frame 3
                p2Sprite.SetImageResource(My.Resources.blueLeftRun3)
                p2LeftRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 3
                'frame 4
                p2Sprite.SetImageResource(My.Resources.blueLeftRun4)
                p2LeftRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 4
                'frame 5
                p2Sprite.SetImageResource(My.Resources.blueLeftRun5)
                p2LeftRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                'p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
            Case 5
                'frame 6
                p2Sprite.SetImageResource(My.Resources.blueLeftRun6)
                p2LeftRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                'p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 15
            Case 6
                'frame 7
                p2Sprite.SetImageResource(My.Resources.blueLeftRun7)
                p2LeftRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                'p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
            Case 7
                'frame 8
                p2Sprite.SetImageResource(My.Resources.blueLeftRun8)
                p2LeftRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 8
                'frame 9
                p2Sprite.SetImageResource(My.Resources.blueLeftRun9)
                p2LeftRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 9
                'frame 10
                p2Sprite.SetImageResource(My.Resources.blueLeftRun10)
                p2LeftRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 10
                'frame 11
                p2Sprite.SetImageResource(My.Resources.blueLeftRun11)
                p2LeftRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 11
                'frame 12
                p2Sprite.SetImageResource(My.Resources.blueLeftRun12)
                p2LeftRunFrame += 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
            Case 12
                'start over at frame 1
                p2Sprite.SetImageResource(My.Resources.blueLeftRun1)
                p2LeftRunFrame = 1
                p2ShootPoint.X = p2Sprite.UpperLeft.X
                p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
        End Select
    End Sub

    '#############################################
    '####### POWER-UPS AND POWER-UP TIMERS #######
    '#############################################

    Private Sub tmrRandomizePowerUps_Tick(sender As Object, e As EventArgs) Handles tmrRandomizePowerUps.Tick
        If tmrBobPowerUps.Enabled = False Then
            tmrBobPowerUps.Start()
        End If

        If tmrRandomizePowerUps.Interval <> 15000 Then
            tmrRandomizePowerUps.Interval = 15000
        End If
        powerUpDump.Clear()
        powerUpsAlive.Clear()

        ' It's been the first twenty seconds, at least! Time to start (or continue).

        ' This timer, each individual tick, will kill all
        ' currently spawned powerups, spawn new locations for
        ' others, and put them in. This does not control whether
        ' or not they are activated, but rather, just their spawning.

        ' Kills all powerups. One/two power-up(s) per floor.
        ' ODD numbers are for ONE powerup.
        ' EVEN numbers are for TWO powerups.
        powerup_speed_1.IsAlive = False     ' code: 1
        powerup_speed_2.IsAlive = False     ' code: 2
        powerup_health_3.IsAlive = False    ' code: 3
        powerup_health_4.IsAlive = False    ' code: 4
        powerup_health_5.IsAlive = False    ' code: 5
        powerup_ammo_6.IsAlive = False      ' code: 6
        powerup_ammo_7.IsAlive = False      ' code: 7
        powerup_ammo_8.IsAlive = False      ' code: 8
        powerup_slow_9.IsAlive = False      ' code: 9
        powerup_slow_10.IsAlive = False     ' code: 10
        powerup_shield_11.IsAlive = False   ' code: 11
        powerup_shield_12.IsAlive = False   ' code: 12
        powerup_triple_13.IsAlive = False   ' code: 13
        powerup_triple_14.IsAlive = False   ' code: 14

        '>>>>>> Randomization: 0, 1, or 2 per floor

        '##################### FLOOR 2 ######################
        intNumberFloorPowerUps = rdmNumberFloorPowerUps.Next(0, 3) ' If this never spawns up to 2, change the 2 to 3. K done.

        Select Case intNumberFloorPowerUps
            Case 0
                ' There are no powerups on the second floor, do nothing.
            Case 1
                ' There will be one powerup on the second floor.
                ' Pick a random powerup with the value of 1; must be an odd number.
                intPowerUp = rdmPowerUp.Next(1, 16)

                ' The number returned a remainder, indicating the fact that it was even. Considering there's only one powerup on this floor, keep randomizing!
                'While (intPowerUp Mod 2 = 0) Then
                '	intPowerUp = RdmPowerUp.Next(1, 10)
                'End While

                'Above is a no-longer-used old system.

                While powerUpDump.Contains(intPowerUp)
                    intPowerUp = rdmPowerUp.Next(1, 16)
                End While

                powerUpDump.Add(intPowerUp)

                ' The number is now odd, which is good.
                ' Now it's time to get a location value.

                ' Pick a random location 5 pixels away from the sides.
                intPowerUpX = rdmPowerUpX.Next(5, 765)


                ' Collision detection is a bit hard with one point, so that'll be checked later. Now, set the correct point sprite and paint

                Select Case intPowerUp
                    Case 1
                        powerup_speed_1.UpperLeft.X = intPowerUpX
                        powerup_speed_1.UpperLeft.Y = 310 'platforms on 360
                        powerup_speed_1.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_1)
                    Case 2
                        powerup_speed_2.UpperLeft.X = intPowerUpX
                        powerup_speed_2.UpperLeft.Y = 310
                        powerup_speed_2.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_2)
                    Case 3
                        powerup_health_3.UpperLeft.X = intPowerUpX
                        powerup_health_3.UpperLeft.Y = 310
                        powerup_health_3.IsAlive = True
                        powerUpsAlive.Add(powerup_health_3)
                    Case 4
                        powerup_health_4.UpperLeft.X = intPowerUpX
                        powerup_health_4.UpperLeft.Y = 310
                        powerup_health_4.IsAlive = True
                        powerUpsAlive.Add(powerup_health_4)
                    Case 5
                        powerup_health_5.UpperLeft.X = intPowerUpX
                        powerup_health_5.UpperLeft.Y = 310
                        powerup_health_5.IsAlive = True
                        powerUpsAlive.Add(powerup_health_5)
                    Case 6
                        powerup_ammo_6.UpperLeft.X = intPowerUpX
                        powerup_ammo_6.UpperLeft.Y = 310
                        powerup_ammo_6.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_6)
                    Case 7
                        powerup_ammo_7.UpperLeft.X = intPowerUpX
                        powerup_ammo_7.UpperLeft.Y = 310
                        powerup_ammo_7.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_7)
                    Case 8
                        powerup_ammo_8.UpperLeft.X = intPowerUpX
                        powerup_ammo_8.UpperLeft.Y = 310
                        powerup_ammo_8.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_8)
                    Case 9
                        powerup_slow_9.UpperLeft.X = intPowerUpX
                        powerup_slow_9.UpperLeft.Y = 310
                        powerup_slow_9.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_9)
                    Case 10
                        powerup_slow_10.UpperLeft.X = intPowerUpX
                        powerup_slow_10.UpperLeft.Y = 310
                        powerup_slow_10.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_10)
                    Case 11
                        powerup_shield_11.UpperLeft.X = intPowerUpX
                        powerup_shield_11.UpperLeft.Y = 310
                        powerup_shield_11.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_11)
                    Case 12
                        powerup_shield_12.UpperLeft.X = intPowerUpX
                        powerup_shield_12.UpperLeft.Y = 310
                        powerup_shield_12.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_12)
                    Case 13
                        powerup_triple_13.UpperLeft.X = intPowerUpX
                        powerup_triple_13.UpperLeft.Y = 310
                        powerup_triple_13.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_13)
                    Case 14
                        powerup_triple_14.UpperLeft.X = intPowerUpX
                        powerup_triple_14.UpperLeft.Y = 310
                        powerup_triple_14.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_14)
                End Select

            Case 2
                'spawn 2 powerups instead
                intPowerUp = rdmPowerUp.Next(1, 15) ' pick it
                While powerUpDump.Contains(intPowerUp)
                    intPowerUp = rdmPowerUp.Next(1, 15)
                End While
                powerUpDump.Add(intPowerUp)
                intPowerUpX = rdmPowerUpX.Next(5, 765)

                Select Case intPowerUp
                    Case 1
                        powerup_speed_1.UpperLeft.X = intPowerUpX
                        powerup_speed_1.UpperLeft.Y = 310
                        powerup_speed_1.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_1)
                    Case 2
                        powerup_speed_2.UpperLeft.X = intPowerUpX
                        powerup_speed_2.UpperLeft.Y = 310
                        powerup_speed_2.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_2)
                    Case 3
                        powerup_health_3.UpperLeft.X = intPowerUpX
                        powerup_health_3.UpperLeft.Y = 310
                        powerup_health_3.IsAlive = True
                        powerUpsAlive.Add(powerup_health_3)
                    Case 4
                        powerup_health_4.UpperLeft.X = intPowerUpX
                        powerup_health_4.UpperLeft.Y = 310
                        powerup_health_4.IsAlive = True
                        powerUpsAlive.Add(powerup_health_4)
                    Case 5
                        powerup_health_5.UpperLeft.X = intPowerUpX
                        powerup_health_5.UpperLeft.Y = 310
                        powerup_health_5.IsAlive = True
                        powerUpsAlive.Add(powerup_health_5)
                    Case 6
                        powerup_ammo_6.UpperLeft.X = intPowerUpX
                        powerup_ammo_6.UpperLeft.Y = 310
                        powerup_ammo_6.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_6)
                    Case 7
                        powerup_ammo_7.UpperLeft.X = intPowerUpX
                        powerup_ammo_7.UpperLeft.Y = 310
                        powerup_ammo_7.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_7)
                    Case 8
                        powerup_ammo_8.UpperLeft.X = intPowerUpX
                        powerup_ammo_8.UpperLeft.Y = 310
                        powerup_ammo_8.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_8)
                    Case 9
                        powerup_slow_9.UpperLeft.X = intPowerUpX
                        powerup_slow_9.UpperLeft.Y = 310
                        powerup_slow_9.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_9)
                    Case 10
                        powerup_slow_10.UpperLeft.X = intPowerUpX
                        powerup_slow_10.UpperLeft.Y = 310
                        powerup_slow_10.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_10)
                    Case 11
                        powerup_shield_11.UpperLeft.X = intPowerUpX
                        powerup_shield_11.UpperLeft.Y = 310
                        powerup_shield_11.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_11)
                    Case 12
                        powerup_shield_12.UpperLeft.X = intPowerUpX
                        powerup_shield_12.UpperLeft.Y = 310
                        powerup_shield_12.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_12)
                    Case 13
                        powerup_triple_13.UpperLeft.X = intPowerUpX
                        powerup_triple_13.UpperLeft.Y = 310
                        powerup_triple_13.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_13)
                    Case 14
                        powerup_triple_14.UpperLeft.X = intPowerUpX
                        powerup_triple_14.UpperLeft.Y = 310
                        powerup_triple_14.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_14)
                End Select

                intPowerUp = rdmPowerUp.Next(1, 15) ' pick it
                While powerUpDump.Contains(intPowerUp)
                    intPowerUp = rdmPowerUp.Next(1, 15)
                End While
                powerUpDump.Add(intPowerUp)
                intPowerUpX = rdmPowerUpX.Next(5, 765)

                'second power up on same floor
                Select Case intPowerUp
                    Case 1
                        powerup_speed_1.UpperLeft.X = intPowerUpX
                        powerup_speed_1.UpperLeft.Y = 310
                        powerup_speed_1.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_1)
                    Case 2
                        powerup_speed_2.UpperLeft.X = intPowerUpX
                        powerup_speed_2.UpperLeft.Y = 310
                        powerup_speed_2.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_2)
                    Case 3
                        powerup_health_3.UpperLeft.X = intPowerUpX
                        powerup_health_3.UpperLeft.Y = 310
                        powerup_health_3.IsAlive = True
                        powerUpsAlive.Add(powerup_health_3)
                    Case 4
                        powerup_health_4.UpperLeft.X = intPowerUpX
                        powerup_health_4.UpperLeft.Y = 310
                        powerup_health_4.IsAlive = True
                        powerUpsAlive.Add(powerup_health_4)
                    Case 5
                        powerup_health_5.UpperLeft.X = intPowerUpX
                        powerup_health_5.UpperLeft.Y = 310
                        powerup_health_5.IsAlive = True
                        powerUpsAlive.Add(powerup_health_5)
                    Case 6
                        powerup_ammo_6.UpperLeft.X = intPowerUpX
                        powerup_ammo_6.UpperLeft.Y = 310
                        powerup_ammo_6.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_6)
                    Case 7
                        powerup_ammo_7.UpperLeft.X = intPowerUpX
                        powerup_ammo_7.UpperLeft.Y = 310
                        powerup_ammo_7.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_7)
                    Case 8
                        powerup_ammo_8.UpperLeft.X = intPowerUpX
                        powerup_ammo_8.UpperLeft.Y = 310
                        powerup_ammo_8.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_8)
                    Case 9
                        powerup_slow_9.UpperLeft.X = intPowerUpX
                        powerup_slow_9.UpperLeft.Y = 310
                        powerup_slow_9.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_9)
                    Case 10
                        powerup_slow_10.UpperLeft.X = intPowerUpX
                        powerup_slow_10.UpperLeft.Y = 310
                        powerup_slow_10.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_10)
                    Case 11
                        powerup_shield_11.UpperLeft.X = intPowerUpX
                        powerup_shield_11.UpperLeft.Y = 310
                        powerup_shield_11.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_11)
                    Case 12
                        powerup_shield_12.UpperLeft.X = intPowerUpX
                        powerup_shield_12.UpperLeft.Y = 310
                        powerup_shield_12.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_12)
                    Case 13
                        powerup_triple_13.UpperLeft.X = intPowerUpX
                        powerup_triple_13.UpperLeft.Y = 310
                        powerup_triple_13.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_13)
                    Case 14
                        powerup_triple_14.UpperLeft.X = intPowerUpX
                        powerup_triple_14.UpperLeft.Y = 310
                        powerup_triple_14.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_14)
                End Select

                ' The power up for floor 2 has been SET.
        End Select



        '##################### FLOOR 3 ######################
        intNumberFloorPowerUps = rdmNumberFloorPowerUps.Next(0, 3) ' If this never spawns 2, change the 2 to 3.

        Select Case intNumberFloorPowerUps
            Case 0
                ' There are no powerups on the third floor, do nothing.
            Case 1
                ' There will be one powerup on the first floor.
                ' Pick a random powerup with the value of 1; must be an odd number.
                intPowerUp = rdmPowerUp.Next(1, 16)

                ' The number returned a remainder, indicating the fact that it was even. Considering there's only one powerup on this floor, keep randomizing!
                'While (intPowerUp Mod 2 = 0) Then
                '	intPowerUp = RdmPowerUp.Next(1, 10)
                'End While

                'Above is a no-longer-used old system.

                While powerUpDump.Contains(intPowerUp)
                    intPowerUp = rdmPowerUp.Next(1, 16)
                End While

                powerUpDump.Add(intPowerUp)

                ' The number is now odd, which is good.
                ' Now it's time to get a location value.

                ' Pick a random location 5 pixels away from the sides.
                intPowerUpX = rdmPowerUpX.Next(5, 765)


                ' Collision detection is a bit hard with one point, so that'll be checked later. Now, set the correct point sprite and paint

                Select Case intPowerUp
                    Case 1
                        powerup_speed_1.UpperLeft.X = intPowerUpX
                        powerup_speed_1.UpperLeft.Y = 196 'platforms on 360
                        powerup_speed_1.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_1)
                    Case 2
                        powerup_speed_2.UpperLeft.X = intPowerUpX
                        powerup_speed_2.UpperLeft.Y = 196
                        powerup_speed_2.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_2)
                    Case 3
                        powerup_health_3.UpperLeft.X = intPowerUpX
                        powerup_health_3.UpperLeft.Y = 196
                        powerup_health_3.IsAlive = True
                        powerUpsAlive.Add(powerup_health_3)
                    Case 4
                        powerup_health_4.UpperLeft.X = intPowerUpX
                        powerup_health_4.UpperLeft.Y = 196
                        powerup_health_4.IsAlive = True
                        powerUpsAlive.Add(powerup_health_4)
                    Case 5
                        powerup_health_5.UpperLeft.X = intPowerUpX
                        powerup_health_5.UpperLeft.Y = 196
                        powerup_health_5.IsAlive = True
                        powerUpsAlive.Add(powerup_health_5)
                    Case 6
                        powerup_ammo_6.UpperLeft.X = intPowerUpX
                        powerup_ammo_6.UpperLeft.Y = 196
                        powerup_ammo_6.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_6)
                    Case 7
                        powerup_ammo_7.UpperLeft.X = intPowerUpX
                        powerup_ammo_7.UpperLeft.Y = 196
                        powerup_ammo_7.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_7)
                    Case 8
                        powerup_ammo_8.UpperLeft.X = intPowerUpX
                        powerup_ammo_8.UpperLeft.Y = 196
                        powerup_ammo_8.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_8)
                    Case 9
                        powerup_slow_9.UpperLeft.X = intPowerUpX
                        powerup_slow_9.UpperLeft.Y = 196
                        powerup_slow_9.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_9)
                    Case 10
                        powerup_slow_10.UpperLeft.X = intPowerUpX
                        powerup_slow_10.UpperLeft.Y = 196
                        powerup_slow_10.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_10)
                    Case 11
                        powerup_shield_11.UpperLeft.X = intPowerUpX
                        powerup_shield_11.UpperLeft.Y = 196
                        powerup_shield_11.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_11)
                    Case 12
                        powerup_shield_12.UpperLeft.X = intPowerUpX
                        powerup_shield_12.UpperLeft.Y = 196
                        powerup_shield_12.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_12)
                    Case 13
                        powerup_triple_13.UpperLeft.X = intPowerUpX
                        powerup_triple_13.UpperLeft.Y = 196
                        powerup_triple_13.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_13)
                    Case 14
                        powerup_triple_14.UpperLeft.X = intPowerUpX
                        powerup_triple_14.UpperLeft.Y = 196
                        powerup_triple_14.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_14)
                End Select

            Case 2
                'spawn 2 powerups instead
                intPowerUp = rdmPowerUp.Next(1, 15) ' pick it
                While powerUpDump.Contains(intPowerUp)
                    intPowerUp = rdmPowerUp.Next(1, 15)
                End While
                powerUpDump.Add(intPowerUp)
                intPowerUpX = rdmPowerUpX.Next(5, 765)

                Select Case intPowerUp
                    Case 1
                        powerup_speed_1.UpperLeft.X = intPowerUpX
                        powerup_speed_1.UpperLeft.Y = 196
                        powerup_speed_1.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_1)
                    Case 2
                        powerup_speed_2.UpperLeft.X = intPowerUpX
                        powerup_speed_2.UpperLeft.Y = 196
                        powerup_speed_2.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_2)
                    Case 3
                        powerup_health_3.UpperLeft.X = intPowerUpX
                        powerup_health_3.UpperLeft.Y = 196
                        powerup_health_3.IsAlive = True
                        powerUpsAlive.Add(powerup_health_3)
                    Case 4
                        powerup_health_4.UpperLeft.X = intPowerUpX
                        powerup_health_4.UpperLeft.Y = 196
                        powerup_health_4.IsAlive = True
                        powerUpsAlive.Add(powerup_health_4)
                    Case 5
                        powerup_health_5.UpperLeft.X = intPowerUpX
                        powerup_health_5.UpperLeft.Y = 196
                        powerup_health_5.IsAlive = True
                        powerUpsAlive.Add(powerup_health_5)
                    Case 6
                        powerup_ammo_6.UpperLeft.X = intPowerUpX
                        powerup_ammo_6.UpperLeft.Y = 196
                        powerup_ammo_6.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_6)
                    Case 7
                        powerup_ammo_7.UpperLeft.X = intPowerUpX
                        powerup_ammo_7.UpperLeft.Y = 196
                        powerup_ammo_7.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_7)
                    Case 8
                        powerup_ammo_8.UpperLeft.X = intPowerUpX
                        powerup_ammo_8.UpperLeft.Y = 196
                        powerup_ammo_8.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_8)
                    Case 9
                        powerup_slow_9.UpperLeft.X = intPowerUpX
                        powerup_slow_9.UpperLeft.Y = 196
                        powerup_slow_9.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_9)
                    Case 10
                        powerup_slow_10.UpperLeft.X = intPowerUpX
                        powerup_slow_10.UpperLeft.Y = 196
                        powerup_slow_10.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_10)
                    Case 11
                        powerup_shield_11.UpperLeft.X = intPowerUpX
                        powerup_shield_11.UpperLeft.Y = 196
                        powerup_shield_11.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_11)
                    Case 12
                        powerup_shield_12.UpperLeft.X = intPowerUpX
                        powerup_shield_12.UpperLeft.Y = 196
                        powerup_shield_12.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_12)
                    Case 13
                        powerup_triple_13.UpperLeft.X = intPowerUpX
                        powerup_triple_13.UpperLeft.Y = 196
                        powerup_triple_13.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_13)
                    Case 14
                        powerup_triple_14.UpperLeft.X = intPowerUpX
                        powerup_triple_14.UpperLeft.Y = 196
                        powerup_triple_14.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_14)
                End Select

                intPowerUp = rdmPowerUp.Next(1, 15) ' pick it
                While powerUpDump.Contains(intPowerUp)
                    intPowerUp = rdmPowerUp.Next(1, 15)
                End While
                powerUpDump.Add(intPowerUp)
                intPowerUpX = rdmPowerUpX.Next(5, 765)

                'second power up on same floor
                Select Case intPowerUp
                    Case 1
                        powerup_speed_1.UpperLeft.X = intPowerUpX
                        powerup_speed_1.UpperLeft.Y = 196
                        powerup_speed_1.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_1)
                    Case 2
                        powerup_speed_2.UpperLeft.X = intPowerUpX
                        powerup_speed_2.UpperLeft.Y = 196
                        powerup_speed_2.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_2)
                    Case 3
                        powerup_health_3.UpperLeft.X = intPowerUpX
                        powerup_health_3.UpperLeft.Y = 196
                        powerup_health_3.IsAlive = True
                        powerUpsAlive.Add(powerup_health_3)
                    Case 4
                        powerup_health_4.UpperLeft.X = intPowerUpX
                        powerup_health_4.UpperLeft.Y = 196
                        powerup_health_4.IsAlive = True
                        powerUpsAlive.Add(powerup_health_4)
                    Case 5
                        powerup_health_5.UpperLeft.X = intPowerUpX
                        powerup_health_5.UpperLeft.Y = 196
                        powerup_health_5.IsAlive = True
                        powerUpsAlive.Add(powerup_health_5)
                    Case 6
                        powerup_ammo_6.UpperLeft.X = intPowerUpX
                        powerup_ammo_6.UpperLeft.Y = 196
                        powerup_ammo_6.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_6)
                    Case 7
                        powerup_ammo_7.UpperLeft.X = intPowerUpX
                        powerup_ammo_7.UpperLeft.Y = 196
                        powerup_ammo_7.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_7)
                    Case 8
                        powerup_ammo_8.UpperLeft.X = intPowerUpX
                        powerup_ammo_8.UpperLeft.Y = 196
                        powerup_ammo_8.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_8)
                    Case 9
                        powerup_slow_9.UpperLeft.X = intPowerUpX
                        powerup_slow_9.UpperLeft.Y = 196
                        powerup_slow_9.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_9)
                    Case 10
                        powerup_slow_10.UpperLeft.X = intPowerUpX
                        powerup_slow_10.UpperLeft.Y = 196
                        powerup_slow_10.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_10)
                    Case 11
                        powerup_shield_11.UpperLeft.X = intPowerUpX
                        powerup_shield_11.UpperLeft.Y = 196
                        powerup_shield_11.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_11)
                    Case 12
                        powerup_shield_12.UpperLeft.X = intPowerUpX
                        powerup_shield_12.UpperLeft.Y = 196
                        powerup_shield_12.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_12)
                    Case 13
                        powerup_triple_13.UpperLeft.X = intPowerUpX
                        powerup_triple_13.UpperLeft.Y = 196
                        powerup_triple_13.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_13)
                    Case 14
                        powerup_triple_14.UpperLeft.X = intPowerUpX
                        powerup_triple_14.UpperLeft.Y = 196
                        powerup_triple_14.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_14)
                End Select

                ' The power up for floor 3 has been SET.
        End Select

        '##################### FLOOR 4 ######################
        intNumberFloorPowerUps = rdmNumberFloorPowerUps.Next(0, 3)

        Select Case intNumberFloorPowerUps
            Case 0
                ' There are no powerups on the fourth floor, do nothing.
            Case 1
                ' There will be one powerup on the fourth floor.
                ' Pick a random powerup with the value of 1; must be an odd number. N/A no longer needed.
                intPowerUp = rdmPowerUp.Next(1, 16)

                ' The number returned a remainder, indicating the fact that it was even. Considering there's only one powerup on this floor, keep randomizing!
                'While (intPowerUp Mod 2 = 0) Then
                '	intPowerUp = RdmPowerUp.Next(1, 10)
                'End While

                'Above is a no-longer-used old system.

                While powerUpDump.Contains(intPowerUp)
                    intPowerUp = rdmPowerUp.Next(1, 16)
                End While

                powerUpDump.Add(intPowerUp)

                ' The number is now odd, which is good.
                ' Now it's time to get a location value.

                ' Pick a random location 5 pixels away from the sides.
                intPowerUpX = rdmPowerUpX.Next(5, 765)


                ' Collision detection is a bit hard with one point, so that'll be checked later. Now, set the correct point sprite and paint

                Select Case intPowerUp
                    Case 1
                        powerup_speed_1.UpperLeft.X = intPowerUpX
                        powerup_speed_1.UpperLeft.Y = 70 'platforms on 360
                        powerup_speed_1.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_1)
                    Case 2
                        powerup_speed_2.UpperLeft.X = intPowerUpX
                        powerup_speed_2.UpperLeft.Y = 70
                        powerup_speed_2.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_2)
                    Case 3
                        powerup_health_3.UpperLeft.X = intPowerUpX
                        powerup_health_3.UpperLeft.Y = 70
                        powerup_health_3.IsAlive = True
                        powerUpsAlive.Add(powerup_health_3)
                    Case 4
                        powerup_health_4.UpperLeft.X = intPowerUpX
                        powerup_health_4.UpperLeft.Y = 70
                        powerup_health_4.IsAlive = True
                        powerUpsAlive.Add(powerup_health_4)
                    Case 5
                        powerup_health_5.UpperLeft.X = intPowerUpX
                        powerup_health_5.UpperLeft.Y = 70
                        powerup_health_5.IsAlive = True
                        powerUpsAlive.Add(powerup_health_5)
                    Case 6
                        powerup_ammo_6.UpperLeft.X = intPowerUpX
                        powerup_ammo_6.UpperLeft.Y = 70
                        powerup_ammo_6.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_6)
                    Case 7
                        powerup_ammo_7.UpperLeft.X = intPowerUpX
                        powerup_ammo_7.UpperLeft.Y = 70
                        powerup_ammo_7.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_7)
                    Case 8
                        powerup_ammo_8.UpperLeft.X = intPowerUpX
                        powerup_ammo_8.UpperLeft.Y = 70
                        powerup_ammo_8.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_8)
                    Case 9
                        powerup_slow_9.UpperLeft.X = intPowerUpX
                        powerup_slow_9.UpperLeft.Y = 70
                        powerup_slow_9.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_9)
                    Case 10
                        powerup_slow_10.UpperLeft.X = intPowerUpX
                        powerup_slow_10.UpperLeft.Y = 70
                        powerup_slow_10.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_10)
                    Case 11
                        powerup_shield_11.UpperLeft.X = intPowerUpX
                        powerup_shield_11.UpperLeft.Y = 70
                        powerup_shield_11.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_11)
                    Case 12
                        powerup_shield_12.UpperLeft.X = intPowerUpX
                        powerup_shield_12.UpperLeft.Y = 70
                        powerup_shield_12.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_12)
                    Case 13
                        powerup_triple_13.UpperLeft.X = intPowerUpX
                        powerup_triple_13.UpperLeft.Y = 70
                        powerup_triple_13.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_13)
                    Case 14
                        powerup_triple_14.UpperLeft.X = intPowerUpX
                        powerup_triple_14.UpperLeft.Y = 70
                        powerup_triple_14.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_14)
                End Select

            Case 2
                'spawn 2 powerups instead
                intPowerUp = rdmPowerUp.Next(1, 15) ' pick it
                While powerUpDump.Contains(intPowerUp)
                    intPowerUp = rdmPowerUp.Next(1, 15)
                End While
                powerUpDump.Add(intPowerUp)
                intPowerUpX = rdmPowerUpX.Next(5, 765)

                Select Case intPowerUp
                    Case 1
                        powerup_speed_1.UpperLeft.X = intPowerUpX
                        powerup_speed_1.UpperLeft.Y = 70
                        powerup_speed_1.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_1)
                    Case 2
                        powerup_speed_2.UpperLeft.X = intPowerUpX
                        powerup_speed_2.UpperLeft.Y = 70
                        powerup_speed_2.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_2)
                    Case 3
                        powerup_health_3.UpperLeft.X = intPowerUpX
                        powerup_health_3.UpperLeft.Y = 70
                        powerup_health_3.IsAlive = True
                        powerUpsAlive.Add(powerup_health_3)
                    Case 4
                        powerup_health_4.UpperLeft.X = intPowerUpX
                        powerup_health_4.UpperLeft.Y = 70
                        powerup_health_4.IsAlive = True
                        powerUpsAlive.Add(powerup_health_4)
                    Case 5
                        powerup_health_5.UpperLeft.X = intPowerUpX
                        powerup_health_5.UpperLeft.Y = 70
                        powerup_health_5.IsAlive = True
                        powerUpsAlive.Add(powerup_health_5)
                    Case 6
                        powerup_ammo_6.UpperLeft.X = intPowerUpX
                        powerup_ammo_6.UpperLeft.Y = 70
                        powerup_ammo_6.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_6)
                    Case 7
                        powerup_ammo_7.UpperLeft.X = intPowerUpX
                        powerup_ammo_7.UpperLeft.Y = 70
                        powerup_ammo_7.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_7)
                    Case 8
                        powerup_ammo_8.UpperLeft.X = intPowerUpX
                        powerup_ammo_8.UpperLeft.Y = 70
                        powerup_ammo_8.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_8)
                    Case 9
                        powerup_slow_9.UpperLeft.X = intPowerUpX
                        powerup_slow_9.UpperLeft.Y = 70
                        powerup_slow_9.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_9)
                    Case 10
                        powerup_slow_10.UpperLeft.X = intPowerUpX
                        powerup_slow_10.UpperLeft.Y = 70
                        powerup_slow_10.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_10)
                    Case 11
                        powerup_shield_11.UpperLeft.X = intPowerUpX
                        powerup_shield_11.UpperLeft.Y = 70
                        powerup_shield_11.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_11)
                    Case 12
                        powerup_shield_12.UpperLeft.X = intPowerUpX
                        powerup_shield_12.UpperLeft.Y = 70
                        powerup_shield_12.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_12)
                    Case 13
                        powerup_triple_13.UpperLeft.X = intPowerUpX
                        powerup_triple_13.UpperLeft.Y = 70
                        powerup_triple_13.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_13)
                    Case 14
                        powerup_triple_14.UpperLeft.X = intPowerUpX
                        powerup_triple_14.UpperLeft.Y = 70
                        powerup_triple_14.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_14)
                End Select

                intPowerUp = rdmPowerUp.Next(1, 15) ' pick it
                While powerUpDump.Contains(intPowerUp)
                    intPowerUp = rdmPowerUp.Next(1, 15)
                End While
                powerUpDump.Add(intPowerUp)
                intPowerUpX = rdmPowerUpX.Next(5, 765)

                'second power up on same floor
                Select Case intPowerUp
                    Case 1
                        powerup_speed_1.UpperLeft.X = intPowerUpX
                        powerup_speed_1.UpperLeft.Y = 70
                        powerup_speed_1.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_1)
                    Case 2
                        powerup_speed_2.UpperLeft.X = intPowerUpX
                        powerup_speed_2.UpperLeft.Y = 70
                        powerup_speed_2.IsAlive = True
                        powerUpsAlive.Add(powerup_speed_2)
                    Case 3
                        powerup_health_3.UpperLeft.X = intPowerUpX
                        powerup_health_3.UpperLeft.Y = 70
                        powerup_health_3.IsAlive = True
                        powerUpsAlive.Add(powerup_health_3)
                    Case 4
                        powerup_health_4.UpperLeft.X = intPowerUpX
                        powerup_health_4.UpperLeft.Y = 70
                        powerup_health_4.IsAlive = True
                        powerUpsAlive.Add(powerup_health_4)
                    Case 5
                        powerup_health_5.UpperLeft.X = intPowerUpX
                        powerup_health_5.UpperLeft.Y = 70
                        powerup_health_5.IsAlive = True
                        powerUpsAlive.Add(powerup_health_5)
                    Case 6
                        powerup_ammo_6.UpperLeft.X = intPowerUpX
                        powerup_ammo_6.UpperLeft.Y = 70
                        powerup_ammo_6.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_6)
                    Case 7
                        powerup_ammo_7.UpperLeft.X = intPowerUpX
                        powerup_ammo_7.UpperLeft.Y = 70
                        powerup_ammo_7.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_7)
                    Case 8
                        powerup_ammo_8.UpperLeft.X = intPowerUpX
                        powerup_ammo_8.UpperLeft.Y = 70
                        powerup_ammo_8.IsAlive = True
                        powerUpsAlive.Add(powerup_ammo_8)
                    Case 9
                        powerup_slow_9.UpperLeft.X = intPowerUpX
                        powerup_slow_9.UpperLeft.Y = 70
                        powerup_slow_9.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_9)
                    Case 10
                        powerup_slow_10.UpperLeft.X = intPowerUpX
                        powerup_slow_10.UpperLeft.Y = 70
                        powerup_slow_10.IsAlive = True
                        powerUpsAlive.Add(powerup_slow_10)
                    Case 11
                        powerup_shield_11.UpperLeft.X = intPowerUpX
                        powerup_shield_11.UpperLeft.Y = 70
                        powerup_shield_11.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_11)
                    Case 12
                        powerup_shield_12.UpperLeft.X = intPowerUpX
                        powerup_shield_12.UpperLeft.Y = 70
                        powerup_shield_12.IsAlive = True
                        powerUpsAlive.Add(powerup_shield_12)
                    Case 13
                        powerup_triple_13.UpperLeft.X = intPowerUpX
                        powerup_triple_13.UpperLeft.Y = 70
                        powerup_triple_13.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_13)
                    Case 14
                        powerup_triple_14.UpperLeft.X = intPowerUpX
                        powerup_triple_14.UpperLeft.Y = 70
                        powerup_triple_14.IsAlive = True
                        powerUpsAlive.Add(powerup_triple_14)
                End Select

                ' The power ups for floor 4 have been SET.
                ' well that was long and painful
        End Select
    End Sub

    Private Sub CheckPlayer1PowerUpCollisions()
        If p1Sprite.IsCollided(powerup_speed_1) Then
            powerup_speed_1.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(14, False, sfxVolume)
            End With
            SpeedGameUp()
        End If

        If p1Sprite.IsCollided(powerup_speed_2) Then
            powerup_speed_2.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(14, False, sfxVolume)
            End With
            SpeedGameUp()
        End If
        If p1Sprite.IsCollided(powerup_health_3) Then
            If p1HealthBar.Value < 100 Then
                If p1HealthBar.Value + 5 > 100 Then
                    p1HealthBar.Value = 100
                    powerup_health_3.IsAlive = False
                Else
                    p1HealthBar.Value += 5
                    powerup_health_3.IsAlive = False
                End If
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(9, False, sfxVolume)
                End With
            End If
        End If
        If p1Sprite.IsCollided(powerup_health_4) Then
            If p1HealthBar.Value < 100 Then
                If p1HealthBar.Value + 5 > 100 Then
                    p1HealthBar.Value = 100
                    powerup_health_4.IsAlive = False
                Else
                    p1HealthBar.Value += 5
                    powerup_health_4.IsAlive = False
                End If
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(9, False, sfxVolume)
                End With
            End If
        End If
        If p1Sprite.IsCollided(powerup_health_5) Then
            If p1HealthBar.Value < 100 Then
                If p1HealthBar.Value + 5 > 100 Then
                    p1HealthBar.Value = 100
                    powerup_health_5.IsAlive = False
                Else
                    p1HealthBar.Value += 5
                    powerup_health_5.IsAlive = False
                End If
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(9, False, sfxVolume)
                End With
            End If
        End If
        If p1Sprite.IsCollided(powerup_ammo_6) Then
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(6, False, sfxVolume)
            End With
            powerup_ammo_6.IsAlive = False
            ' Collecting ammunition and holding it:
            p1Ammo += 75
            lblPlayer1Ammo.Text = "AMMO: " & p1Ammo
            ReDim Preserve p1Shots(p1Ammo - 1)
            InitializePlayer1Shots(p1Ammo - 75)
        End If
        If p1Sprite.IsCollided(powerup_ammo_7) Then
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(6, False, sfxVolume)
            End With
            powerup_ammo_7.IsAlive = False
            ' Collecting ammunition and holding it:
            p1Ammo += 75
            lblPlayer1Ammo.Text = "AMMO: " & p1Ammo
            ReDim Preserve p1Shots(p1Ammo - 1)
            InitializePlayer1Shots(p1Ammo - 75)
        End If
        If p1Sprite.IsCollided(powerup_ammo_8) Then
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(6, False, sfxVolume)
            End With
            powerup_ammo_8.IsAlive = False
            ' Collecting ammunition and holding it:
            p1Ammo += 75
            lblPlayer1Ammo.Text = "AMMO: " & p1Ammo
            ReDim Preserve p1Shots(p1Ammo - 1)
            InitializePlayer1Shots(p1Ammo - 75)
        End If
        If p1Sprite.IsCollided(powerup_slow_9) Then
            powerup_slow_9.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(13, False, sfxVolume)
            End With
            SlowGameDown()
        End If
        If p1Sprite.IsCollided(powerup_slow_10) Then
            powerup_slow_10.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(13, False, sfxVolume)
            End With
            SlowGameDown()
        End If
        If p1Sprite.IsCollided(powerup_shield_11) Then
            powerup_shield_11.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(12, False, sfxVolume)
            End With
            ShieldPlayer1()
        End If
        If p1Sprite.IsCollided(powerup_shield_12) Then
            powerup_shield_12.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(12, False, sfxVolume)
            End With
            ShieldPlayer1()
        End If
        If p1Sprite.IsCollided(powerup_triple_13) Then
            powerup_triple_13.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(15, False, sfxVolume)
            End With
            TriplePlayer1()
        End If
        If p1Sprite.IsCollided(powerup_triple_14) Then
            powerup_triple_14.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(15, False, sfxVolume)
            End With
            TriplePlayer1()
        End If
    End Sub

    Private Sub CheckPlayer2PowerUpCollisions()
        If p2Sprite.IsCollided(powerup_speed_1) Then
            powerup_speed_1.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(14, False, sfxVolume)
            End With
            SpeedGameUp()
        End If

        If p2Sprite.IsCollided(powerup_speed_2) Then
            powerup_speed_2.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(14, False, sfxVolume)
            End With
            SpeedGameUp()
        End If
        If p2Sprite.IsCollided(powerup_health_3) Then
            If p2HealthBar.Value < 100 Then
                If p2HealthBar.Value + 5 > 100 Then
                    p2HealthBar.Value = 100
                    powerup_health_3.IsAlive = False
                Else
                    p2HealthBar.Value += 5
                    powerup_health_3.IsAlive = False
                End If
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(9, False, sfxVolume)
                End With
            End If
        End If
        If p2Sprite.IsCollided(powerup_health_4) Then
            If p2HealthBar.Value < 100 Then
                If p2HealthBar.Value + 5 > 100 Then
                    p2HealthBar.Value = 100
                    powerup_health_4.IsAlive = False
                Else
                    p2HealthBar.Value += 5
                    powerup_health_4.IsAlive = False
                End If
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(9, False, sfxVolume)
                End With
            End If
        End If
        If p2Sprite.IsCollided(powerup_health_5) Then
            If p2HealthBar.Value < 100 Then
                If p2HealthBar.Value + 5 > 100 Then
                    p2HealthBar.Value = 100
                    powerup_health_5.IsAlive = False
                Else
                    p2HealthBar.Value += 5
                    powerup_health_5.IsAlive = False
                End If
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(9, False, sfxVolume)
                End With
            End If
        End If
        If p2Sprite.IsCollided(powerup_ammo_6) Then
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(6, False, sfxVolume)
            End With
            powerup_ammo_6.IsAlive = False
            ' Collecting ammunition and holding it:
            p2Ammo += 75
            lblPlayer2Ammo.Text = "AMMO: " & p2Ammo
            ReDim Preserve p2Shots(p2Ammo - 1)
            InitializePlayer2Shots(p2Ammo - 75)
        End If
        If p2Sprite.IsCollided(powerup_ammo_7) Then
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(6, False, sfxVolume)
            End With
            powerup_ammo_7.IsAlive = False
            ' Collecting ammunition and holding it:
            p2Ammo += 75
            lblPlayer2Ammo.Text = "AMMO: " & p2Ammo
            ReDim Preserve p2Shots(p2Ammo - 1)
            InitializePlayer2Shots(p2Ammo - 75)
        End If
        If p2Sprite.IsCollided(powerup_ammo_8) Then
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(6, False, sfxVolume)
            End With
            powerup_ammo_8.IsAlive = False
            ' Collecting ammunition and holding it:
            p2Ammo += 75
            lblPlayer2Ammo.Text = "AMMO: " & p2Ammo
            ReDim Preserve p2Shots(p2Ammo - 1)
            InitializePlayer2Shots(p2Ammo - 75)
        End If
        If p2Sprite.IsCollided(powerup_slow_9) Then
            powerup_slow_9.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(13, False, sfxVolume)
            End With
            SlowGameDown()
        End If
        If p2Sprite.IsCollided(powerup_slow_10) Then
            powerup_slow_10.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(13, False, sfxVolume)
            End With
            SlowGameDown()
        End If
        If p2Sprite.IsCollided(powerup_shield_11) Then
            powerup_shield_11.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(12, False, sfxVolume)
            End With
            ShieldPlayer2()
        End If
        If p2Sprite.IsCollided(powerup_shield_12) Then
            powerup_shield_12.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(12, False, sfxVolume)
            End With
            ShieldPlayer2()
        End If
        If p2Sprite.IsCollided(powerup_triple_13) Then
            powerup_triple_13.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(15, False, sfxVolume)
            End With
            TriplePlayer2()
        End If
        If p2Sprite.IsCollided(powerup_triple_14) Then
            powerup_triple_14.IsAlive = False
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(15, False, sfxVolume)
            End With
            TriplePlayer2()
        End If
    End Sub

    Private Sub p1TripleShot_Tick(sender As Object, e As EventArgs) Handles p1TripleShot.Tick
        p1IsTripled = False
        picPlayer1ActivePUP.Image = Nothing
        p1TripleShot.Stop()
    End Sub

    Private Sub p2TripleShot_Tick(sender As Object, e As EventArgs) Handles p2TripleShot.Tick
        p2IsTripled = False
        picPlayer2ActivePUP.Image = Nothing
        p2TripleShot.Stop()
    End Sub

    Private Sub tmrSpeedUpGame_Tick(sender As Object, e As EventArgs) Handles tmrSpeedUp.Tick
        ReturnGameToNormalSpeed("F")
        tmrSpeedUp.Stop()
    End Sub

    Private Sub tmrSlowDown_Tick(sender As Object, e As EventArgs) Handles tmrSlowDown.Tick
        ReturnGameToNormalSpeed("S")
    End Sub

    Private Sub p1Shield_Tick(sender As Object, e As EventArgs) Handles p1Shield.Tick
        p1IsShielded = False
        picPlayer1ActivePUP.Image = Nothing
        p1Shield.Stop()
    End Sub

    Private Sub p2Shield_Tick(sender As Object, e As EventArgs) Handles p2Shield.Tick
        p2IsShielded = False
        picPlayer2ActivePUP.Image = Nothing
        p2Shield.Stop()
    End Sub

    Private Sub p2tmrFall_Tick(sender As Object, e As EventArgs) Handles p2tmrFall.Tick

        If p2IsCrouching Then
            Exit Sub
        End If

        If p2IsJumping = 0 Then
            If p2ComingDown Then
                ' Do nothing.
            Else
                p2tmrFall.Stop()
            End If

        End If
        p2Sprite.UpperLeft.Y += 4
        p2IsOnGround = False

        If p2IsJumping = 1 Then
            p2IsJumping = 3
        End If

        If p2IsJumping = 2 Then ' FIXES GETTING STUCK IN AIR WHEN JUMPING ON CORNER OF PLATFORM - yay this bothered me for over a year so like it's a huge accomplishment with a simple fix. Of course it is.
            p2IsJumping = 3
        End If
    End Sub

    Private Sub tmrLoadGame_Tick(sender As Object, e As EventArgs) Handles tmrLoadGame.Tick
        Select Case tmrLoadGameTick
            Case 0
                tmrLoadGameTick += 1
                pbLoading.Value = 5
            Case 1
                tmrLoadGameTick += 1
                pbLoading.Value = 15
            Case 2
                tmrLoadGameTick += 1
                pbLoading.Value = 35
            Case 3
                tmrLoadGameTick += 1
                pbLoading.Value = 80
            Case 4
                tmrLoadGameTick += 1
                pbLoading.Value = 100
                tmrLoadGame.Interval = 550
            Case 5
                tmrLoadGameTick = 0
                pbLoading.Hide()
                picLoadingStickfigure.Hide()
                Application.VisualStyleState = VisualStyles.VisualStyleState.NoneEnabled ' makes the progress bars for player health be able to be red and blue
                pbLogo.Show()
                picPlaySprite.IsAlive = True
                picHTPSprite.IsAlive = True
                picOptionsSprite.IsAlive = True
                picArcadeSprite.IsAlive = True

                InitializeLauncherBkgd()
                InitializeCursor()
                InitializeCursorShots(0)
                InitializeButtons()
                bkgdForLauncher.Show()

                shootDelayIsActive = True
                tmrShootDelay.Start()

                LauncherTimer.Start()
                tmrCursorIdleRight.Start()
                tmrLoadGame.Stop()

                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(8, True, musicVolume)
                End With
        End Select
    End Sub

    Private Sub InitializeLauncherBkgd()
        launcherBkgdSprite = New Sprite
        launcherBkgdSprite.IsAlive = True
        launcherBkgdSprite.TimeToLive = -1
        launcherBkgdSprite.SetImageResource(My.Resources.frmBkgd)
        launcherBkgdSprite.UpperLeft.X = 0
        launcherBkgdSprite.UpperLeft.Y = 0
    End Sub

    Private Sub InitializeCursor()
        cursorSprite = New Sprite
        cursorSprite.IsAlive = True
        cursorSprite.TimeToLive = -1
        cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle1)
        cursorSprite.UpperLeft.X = 70
        cursorSprite.UpperLeft.Y = 220
    End Sub

    Private Sub tmrSplashPulse_Tick(sender As Object, e As EventArgs) Handles tmrSplashPulse.Tick
        Select Case tmrSplashPulseTick
            Case 0
                intSplashSize -= 1
                tmrSplashPulseTick += 1
            Case 1
                intSplashSize -= 1
                tmrSplashPulseTick += 1
            Case 2
                intSplashSize -= 1
                tmrSplashPulseTick += 1
            Case 3
                intSplashSize -= 1
                tmrSplashPulseTick += 1
            Case 4
                intSplashSize += 1
                tmrSplashPulseTick += 1
            Case 5
                intSplashSize += 1
                tmrSplashPulseTick += 1
            Case 6
                intSplashSize += 1
                tmrSplashPulseTick += 1
            Case 7
                intSplashSize += 1
                tmrSplashPulseTick = 0
        End Select

        pbLogo.Invalidate()
    End Sub

    Private Sub pbLogo_Paint(sender As Object, e As PaintEventArgs) Handles pbLogo.Paint
        Dim fntSplashFont As New Font("Times New Roman", intSplashSize, FontStyle.Bold, GraphicsUnit.Point)
        If blnFancy Then
            fntSplashFont = New Font("Times New Roman", intSplashSize, FontStyle.Italic, GraphicsUnit.Point)
        End If
        Try
            Dim rect1 As New Rectangle(230, 292, 400, 70)

            ' Create a StringFormat object with the each line of text, and the block
            ' of text centered on the page.
            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center


            ' Draw the text and the surrounding rectangle.
            e.Graphics.TranslateTransform(100.0F, 0.0F)
            e.Graphics.RotateTransform(-25.0F)
            e.Graphics.DrawString(strSplash, fntSplashFont, Brushes.Yellow, rect1, stringFormat) 'to do- custom brush

            e.Graphics.DrawRectangle(Pens.Transparent, rect1) ' change to black to see Splash boundaries

        Finally
            fntSplashFont.Dispose()
        End Try

        'Dim whiteBrush As New SolidBrush(Color.White)
        'Dim Consolas As Font = New Font("Consolas", 20, FontStyle.Bold, GraphicsUnit.Pixel)
    End Sub

    Private Sub bkgdForLauncher_Paint(sender As Object, e As PaintEventArgs) Handles bkgdForLauncher.Paint
        PaintLauncherBkgd(e.Graphics)
        PaintCursor(e.Graphics)
        PaintCursorShots(e.Graphics)
        PaintButtons(e.Graphics)

        ' Painting the get ready countdown text for usage in pulsing

        Dim getReadyBrush As New SolidBrush(Color.Green)
        Dim fntGetReadyTextFont As New Font("GROBOLD", intGetReadyTextSize, FontStyle.Bold, GraphicsUnit.Point)

        Try
            Dim rect1 As New Rectangle(220, 335, 170, 144)

            ' Create a StringFormat object with the each line of text, and the block
            ' of text centered on the page.
            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center


            ' Draw the text and the surrounding rectangle.
            e.Graphics.TranslateTransform(100.0F, 0.0F)
            'e.Graphics.RotateTransform(-25.0F)

            Select Case strGetReady
                Case "4"
                    getReadyBrush = New SolidBrush(Color.DarkGreen)
                Case "3"
                    getReadyBrush = New SolidBrush(Color.Orange)
                Case "2"
                    getReadyBrush = New SolidBrush(Color.DarkOrange)
                Case "1"
                    getReadyBrush = New SolidBrush(Color.Red)
            End Select

            e.Graphics.DrawString(strGetReady, fntGetReadyTextFont, getReadyBrush, rect1, stringFormat)

            e.Graphics.DrawRectangle(Pens.Transparent, rect1) ' change to white to see boundaries



        Finally
            fntGetReadyTextFont.Dispose()
        End Try

        '----------------------------------------------------------------------------------------------------------- Heading to Main Menu text.

        Dim fntHeadingToMenu As New Font("GROBOLD", 22, FontStyle.Regular, GraphicsUnit.Point)

        Try
            Dim rect1 As New Rectangle(-90, 540, 480, 59)

            ' Create a StringFormat object with the each line of text, and the block
            ' of text centered on the page.
            Dim menuFormat As New StringFormat()
            menuFormat.Alignment = StringAlignment.Near
            menuFormat.LineAlignment = StringAlignment.Center


            ' Draw the text and the surrounding rectangle.
            'e.Graphics.TranslateTransform(100.0F, 0.0F)
            'e.Graphics.RotateTransform(-25.0F)
            e.Graphics.DrawString(strHeadingToMenuText, fntHeadingToMenu, Brushes.White, rect1, menuFormat)

            e.Graphics.DrawRectangle(Pens.Transparent, rect1) ' change to black to see Splash boundaries

        Finally
            fntHeadingToMenu.Dispose()
        End Try
    End Sub

    Private Sub PaintLauncherBkgd(ByRef myGraphics As Graphics)
        If (launcherBkgdSprite Is Nothing) Then
            Return
        End If

        launcherBkgdSprite.PaintRotatedImage(myGraphics, launcherBkgdSprite.Angle, launcherBkgdSprite.GetCenter(), True)
    End Sub

    Private Sub PaintCursor(ByRef myGraphics As Graphics)
        If (cursorSprite Is Nothing) Then
            Return
        End If

        cursorSprite.PaintRotatedImage(myGraphics, cursorSprite.Angle, cursorSprite.GetCenter(), True)
    End Sub

    Private Sub tmrCursorIdleRight_Tick(sender As Object, e As EventArgs) Handles tmrCursorIdleRight.Tick
        Select Case cursorRightIdleFrame
            Case 1
                'If blnCursorGlitched = True And cursorSprite.UpperLeft.Y = 498 Then
                '    cursorSprite.UpperLeft.Y = 383
                '    blnCursorGlitched = False
                'End If
                'frame 2
                cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle2)
                cursorRightIdleFrame += 1
                'cursorShootPoint.X = cursorSprite.UpperLeft.X
                cursorShootPoint.X = cursorSprite.UpperLeft.X + 32
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 2
                'frame 3
                cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle3)
                cursorRightIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X + 32
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 3
                'frame 4
                cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle4)
                cursorRightIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X + 32
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 4
                'frame 5
                cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle5)
                cursorRightIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X + 32
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
                'cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 14
            Case 5
                'frame 6
                cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle6)
                cursorRightIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X + 32
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
                'cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 15
            Case 6
                'frame 7
                cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle7)
                cursorRightIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X + 32
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
                'cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 14
            Case 7
                'frame 8
                cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle8)
                cursorRightIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X + 32
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 8
                'frame 9
                cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle9)
                cursorRightIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X + 32
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 9
                'frame 10
                cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle10)
                cursorRightIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X + 32
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 10
                'start over at frame 1
                cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle1)
                cursorRightIdleFrame = 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X + 32
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
        End Select
    End Sub

    Private Sub LauncherTimer_Tick(sender As Object, e As EventArgs) Handles LauncherTimer.Tick
        launcherProcessKeys()
        MoveCursorShots()

        CheckCursorShotCollisions()
        'for each shot, set upperleft to cursor shootpoint

        'For Each shot In cursorShots
        '    shot.UpperLeft = cursorShootPoint
        'Next

        For Each shot In cursorShots
            If shot.IsAlive = True Then
                If cursorSprite.UpperLeft.X = 695 Then
                    shot.UpperLeft.X -= 6
                Else
                    shot.UpperLeft.X += 6
                End If

            End If
        Next


        If strButtonDirection = "Left" Then

            ' closing main menu

            If blnFirstCanMove Then
                picPlaySprite.UpperLeft.X -= 14
            End If
            If blnSecondCanMove Then
                picHTPSprite.UpperLeft.X -= 14
            End If
            If blnThirdCanMove Then
                picOptionsSprite.UpperLeft.X -= 14
            End If
            If blnFourthCanMove Then
                picArcadeSprite.UpperLeft.X -= 14
            End If
        End If

        If strOptionsDirection = "Left" Then
            ' opening options menu

            If blnFirstORowCanMove Then
                picOptionsTabSprite.UpperLeft.X -= 14
            End If
            If blnSecondORowCanMove Then
                picOptions1Sprite.UpperLeft.X -= 14
            End If
            If blnThirdORowCanMove Then
                picOptions2Sprite.UpperLeft.X -= 14
            End If
            If blnFourthORowCanMove Then
                picOptions3Sprite.UpperLeft.X -= 14
            End If
        End If

        If strButtonDirection = "Right" Then

            ' opening main menu

            If blnFirstCanMove Then
                picPlaySprite.UpperLeft.X += 14
            End If
            If blnSecondCanMove Then
                picHTPSprite.UpperLeft.X += 14
            End If
            If blnThirdCanMove Then
                picOptionsSprite.UpperLeft.X += 14
            End If
            If blnFourthCanMove Then
                picArcadeSprite.UpperLeft.X += 14
            End If
        End If

        If strOptionsDirection = "Right" Then
            ' closing options menu

            If blnFirstORowCanMove Then
                picOptionsTabSprite.UpperLeft.X += 14
            End If
            If blnSecondORowCanMove Then
                picOptions1Sprite.UpperLeft.X += 14
            End If
            If blnThirdORowCanMove Then
                picOptions2Sprite.UpperLeft.X += 14
            End If
            If blnFourthORowCanMove Then
                picOptions3Sprite.UpperLeft.X += 14
            End If
        End If

        If blnPicGetReadyCanMove Then
            picGetReadySprite.UpperLeft.X -= 10
        End If

        If picGetReadySprite.UpperLeft.X <= 200 Then
            picGetReadySprite.UpperLeft.X = 200
            blnPicGetReadyCanMove = False
        End If

        'killing or reviving the cursor temporarily

        If strButtonDirection = "Left" Then
            Select Case strButtonShot
                Case "PLAY"
                    If picPlaySprite.UpperLeft.X <= 80 Then
                        If cursorSprite.IsAlive = True Then
                            cursorSprite.IsAlive = False
                        End If
                    End If
                Case "HTP"
                    If picHTPSprite.UpperLeft.X <= 80 Then
                        If cursorSprite.IsAlive = True Then
                            cursorSprite.IsAlive = False
                        End If
                    End If
                Case "OPTIONS"
                    If picOptionsSprite.UpperLeft.X <= 80 Then
                        If cursorSprite.IsAlive = True Then
                            cursorSprite.IsAlive = False
                        End If
                    End If
                Case "ARCADE"
                    If picArcadeSprite.UpperLeft.X <= 80 Then
                        If cursorSprite.IsAlive = True Then
                            cursorSprite.IsAlive = False
                        End If
                    End If
            End Select
        End If

        If strButtonDirection = "Right" Then 'YEAH UH WHEN MOVING BACK THEY CANT BE ANY OF THESE FOUR BUTTONS UNLESS - Remember the original button that was shot. Then place the cursor back where he was?
            Select Case strButtonShot
                Case "PLAY"
                    If picPlaySprite.UpperLeft.X >= 80 Then
                        If cursorSprite.IsAlive = False Then
                            cursorSprite.IsAlive = True
                        End If
                    End If
                Case "HTP"
                    If picHTPSprite.UpperLeft.X >= 80 Then
                        If cursorSprite.IsAlive = False Then
                            cursorSprite.IsAlive = True
                        End If
                    End If
                Case "OPTIONS"
                    If picOptionsSprite.UpperLeft.X >= 80 Then
                        If cursorSprite.IsAlive = False Then
                            cursorSprite.IsAlive = True
                        End If
                    End If
                Case "ARCADE"
                    If picArcadeSprite.UpperLeft.X >= 80 Then
                        If cursorSprite.IsAlive = False Then
                            cursorSprite.IsAlive = True
                        End If
                    End If
            End Select

            If strButtonShot = "OPTIONS" Then
                If picHTPSprite.UpperLeft.X >= 0 Then
                    cursorSprite.IsAlive = True
                    tmrCursorIdleRight.Start()
                End If
            End If
        End If

        If strButtonDirection = "Left" Then

            If picPlaySprite.UpperLeft.X <= -340 Then
                blnFirstCanMove = False
            End If
            If picHTPSprite.UpperLeft.X <= -340 Then
                blnSecondCanMove = False
            End If
            If picOptionsSprite.UpperLeft.X <= -340 Then
                blnThirdCanMove = False
            End If
            If picArcadeSprite.UpperLeft.X <= -340 Then
                blnFourthCanMove = False
                strButtonDirection = ""
            End If
        End If

        If strOptionsDirection = "Left" Then
            ' stopping options buttons in middle

            If picOptionsTabSprite.UpperLeft.X <= -340 Then
                blnFirstORowCanMove = False
            End If
            If picOptions1Sprite.UpperLeft.X <= -340 Then
                blnSecondORowCanMove = False
            End If
            If picOptions2Sprite.UpperLeft.X <= -340 Then
                blnThirdORowCanMove = False
            End If
            If picOptions3Sprite.UpperLeft.X <= -340 Then
                blnFourthORowCanMove = False
                strOptionsDirection = ""
                blnCursorHasShot = False
                'tmrMoveMMButtonsRight.Stop()
            End If
        End If


        If strButtonDirection = "Right" Then
            If picPlaySprite.UpperLeft.X >= 230 Then
                blnFirstCanMove = False
                picPlaySprite.UpperLeft.X = 236
                strButtonShot = ""
            End If
            If picHTPSprite.UpperLeft.X >= 230 Then
                blnSecondCanMove = False
                picHTPSprite.UpperLeft.X = 236
                strButtonShot = ""
            End If
            If picOptionsSprite.UpperLeft.X >= 230 Then
                blnThirdCanMove = False
                picOptionsSprite.UpperLeft.X = 236
                strButtonShot = ""
            End If
            If picArcadeSprite.UpperLeft.X >= 230 Then
                blnFourthCanMove = False
                picArcadeSprite.UpperLeft.X = 236
                strButtonDirection = ""
                strButtonShot = ""
                blnCursorHasShot = False
                blnFirstCanMove = False
                blnSecondCanMove = False
                blnThirdCanMove = False
                blnFourthCanMove = False
                tmrMoveMMButtonsRight.Stop()
            End If
        End If

        If strOptionsDirection = "Left" Then
            If picOptionsTabSprite.UpperLeft.X <= 230 Then
                blnFirstORowCanMove = False
                picOptionsTabSprite.UpperLeft.X = 236
            End If
            If picOptions1Sprite.UpperLeft.X <= 230 Then
                blnSecondORowCanMove = False
                picOptions1Sprite.UpperLeft.X = 236
            End If
            If picOptions2Sprite.UpperLeft.X <= 230 Then
                blnThirdORowCanMove = False
                picOptions2Sprite.UpperLeft.X = 236
            End If
            If picOptions3Sprite.UpperLeft.X <= 230 Then
                blnFourthORowCanMove = False
                picOptions3Sprite.UpperLeft.X = 236
                strOptionsDirection = ""
                blnCursorHasShot = False
            End If
        End If

        If strOptionsDirection = "Right" Then
            If picOptionsTabSprite.UpperLeft.X >= 801 Then
                picOptionsTabSprite.IsAlive = False
                blnFirstORowCanMove = False
            End If
            If picOptions1Sprite.UpperLeft.X >= 801 Then
                picOptions1Sprite.IsAlive = False
                blnSecondORowCanMove = False
            End If
            If picOptions2Sprite.UpperLeft.X >= 801 Then
                picOptions2Sprite.IsAlive = False
                blnThirdORowCanMove = False
            End If
            If picOptions3Sprite.UpperLeft.X >= 801 Then
                picOptions3Sprite.IsAlive = False
                blnFourthORowCanMove = False
                strOptionsDirection = ""
            End If
        End If

        If strOptionsDirection = "Left" Then
            If picOptionsTabSprite.UpperLeft.X <= 450 And picOptionsTabSprite.UpperLeft.X >= 350 Then
                If cursorSprite.UpperLeft.X = 695 Then
                    ' Do nothing.
                Else
                    cursorSprite.UpperLeft.X = 695
                    cursorSprite.UpperLeft.Y = 220
                    tmrCursorIdleRight.Stop()
                    cursorRightIdleFrame = 1
                    cursorSprite.SetImageResource(My.Resources.orangeLeftCursorIdle1)
                    cursorLeftIdleFrame = 1
                    cursorSprite.IsAlive = True
                    tmrCursorIdleLeft.Start()
                End If
            End If
        End If

        If strOptionsDirection = "Right" Then
            If picOptions3Sprite.UpperLeft.X >= 450 Then
                If cursorSprite.UpperLeft.X = 70 Then
                    ' Do nothing.
                Else
                    cursorSprite.IsAlive = False
                    cursorSprite.UpperLeft.X = 70
                    cursorSprite.UpperLeft.Y = 420
                    cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle1)
                    cursorRightIdleFrame = 1
                    cursorLeftIdleFrame = 1
                    tmrCursorIdleLeft.Stop()
                End If
            End If
        End If

        If blnScreenCanChange Then
            If strVictoryButtonShot = "YES" Then
                strVictoryButtonShot = ""
                blnScreenCanChange = False
                HideVictoryScreen()
                p1IsJumping = 4 'Setting this to four due to the fact that otherwise, if a player moves the cursor up or down, they give a little "hop" when they spawn in. this resets it.
                p2IsJumping = 4
                bkgdForLauncher.Hide()
                launcherBkgdSprite.IsAlive = False
                cursorSprite.IsAlive = False
                picPlaySprite.IsAlive = False
                picHTPSprite.IsAlive = False
                picOptionsSprite.IsAlive = False
                picArcadeSprite.IsAlive = False
                blnGameIsStarted = True
                pbLogo.Hide()
                tmrSplashPulse.Stop()
                LauncherTimer.Stop()
                tmrCursorIdleRight.Stop()
                cursorRightIdleFrame = 1
                tmrCursorIdleLeft.Stop()
                cursorLeftIdleFrame = 1
                intGetReadyTextSize = 100
                intGetReadyTick = 0
                strHeadingToMenuText = ""

                strWinner = ""
                StartGame()
            Else ' hit no
                blnScreenCanChange = False
                strVictoryButtonShot = ""
                strHeadingToMenuText = ""
                HideVictoryScreen()
                HeadToLauncher()
            End If
        End If

        If blnYesCanMove Then
            If yesSprite.UpperLeft.X < 800 Then
                yesSprite.UpperLeft.X += 14
                blnCursorHasShot = True
            Else
                yesSprite.IsAlive = False
                blnYesCanMove = False
            End If
        End If

        If blnNoCanMove Then
            If noSprite.UpperLeft.X < 800 Then
                noSprite.UpperLeft.X += 14
            Else
                blnCursorHasShot = True
                noSprite.IsAlive = False
                blnNoCanMove = False
                blnScreenCanChange = True
            End If
        End If
        Invalidate()
    End Sub

    Private Sub launcherProcessKeys()
        If blnCursorHasShot Then
            Exit Sub
        End If

        ' Cursor shooting keys; white yellow red blue

        If p1WhiteIsPressed Then
            While (p1WhiteIsPressed = True)
                CursorShoot()
                p1WhiteIsPressed = False
            End While
        End If

        If p1YellowIsPressed Then
            While (p1YellowIsPressed = True)
                CursorShoot()
                p1YellowIsPressed = False
            End While
        End If

        If p1BlueIsPressed Then
            While (p1BlueIsPressed = True)
                CursorShoot()
                p1BlueIsPressed = False
            End While
        End If

        If p1RedIsPressed Then
            While (p1RedIsPressed = True)
                CursorShoot()
                p1RedIsPressed = False
            End While
        End If

        '/////////////////////////////////////

        If p2WhiteIsPressed Then
            While (p2WhiteIsPressed = True)
                CursorShoot()
                p2WhiteIsPressed = False
            End While
        End If

        If p2YellowIsPressed Then
            While (p2YellowIsPressed = True)
                CursorShoot()
                p2YellowIsPressed = False
            End While
        End If

        If p2BlueIsPressed Then
            While (p2BlueIsPressed = True)
                CursorShoot()
                p2BlueIsPressed = False
            End While
        End If

        If p2RedIsPressed Then
            While (p2RedIsPressed = True)
                CursorShoot()
                p2RedIsPressed = False
            End While
        End If

        If p1LeftIsPressed Then
            ' does nothing atm
        End If
        If p1RightIsPressed Then
            ' does nothing atm
        End If
        If p1UpIsPressed Then
            If shootDelayIsActive Then
                ' Do nothing.
                p1UpIsPressed = False
            Else
                If cursorSprite.UpperLeft.Y = 220 Then
                    cursorSprite.UpperLeft.Y = 520
                    p1UpIsPressed = False
                    HideOptionsText()
                ElseIf cursorSprite.UpperLeft.Y = 320 Then
                    cursorSprite.UpperLeft.Y = 220
                    p1UpIsPressed = False
                    HideOptionsText()
                ElseIf cursorSprite.UpperLeft.Y = 420 Then
                    cursorSprite.UpperLeft.Y = 320
                    p1UpIsPressed = False
                    HideOptionsText()
                ElseIf cursorSprite.UpperLeft.Y = 520 Then
                    cursorSprite.UpperLeft.Y = 420
                    p1UpIsPressed = False
                    HideOptionsText()
                End If

                If cursorSprite.UpperLeft.Y = 383 Then
                    cursorSprite.UpperLeft.Y = 498
                    p1UpIsPressed = False
                ElseIf cursorSprite.UpperLeft.Y = 498 Then
                    cursorSprite.UpperLeft.Y = 383
                    p1UpIsPressed = False
                End If
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(11, False, sfxVolume)
                End With
            End If
        End If

        If p1DownIsPressed Then
            If shootDelayIsActive Then
                ' Do nothing.
                p1DownIsPressed = False
            Else
                If blnGameIsStarted = False Then
                    If cursorSprite.UpperLeft.Y = 220 Then
                        cursorSprite.UpperLeft.Y = 320
                        p1DownIsPressed = False
                        HideOptionsText()
                    ElseIf cursorSprite.UpperLeft.Y = 320 Then
                        cursorSprite.UpperLeft.Y = 420
                        p1DownIsPressed = False
                        HideOptionsText()
                    ElseIf cursorSprite.UpperLeft.Y = 420 Then
                        cursorSprite.UpperLeft.Y = 520
                        p1DownIsPressed = False
                        HideOptionsText()
                    ElseIf cursorSprite.UpperLeft.Y = 520 Then
                        cursorSprite.UpperLeft.Y = 220
                        p1DownIsPressed = False
                        HideOptionsText()
                    End If

                    If cursorSprite.UpperLeft.Y = 383 Then
                        cursorSprite.UpperLeft.Y = 498
                        p1DownIsPressed = False
                    ElseIf cursorSprite.UpperLeft.Y = 498 Then
                        cursorSprite.UpperLeft.Y = 383
                        p1DownIsPressed = False
                    End If
                    intSound += 1
                    With sound
                        .Name = "sound" & intSound
                        .Play(11, False, sfxVolume)
                    End With
                End If
            End If
        End If

        If p2LeftIsPressed Then

        End If
        If p2RightIsPressed Then

        End If

        If p2UpIsPressed Then
            If shootDelayIsActive Then
                ' Do nothing.
                p2UpIsPressed = False
            Else
                If cursorSprite.UpperLeft.Y = 220 Then
                    cursorSprite.UpperLeft.Y = 520
                    p2UpIsPressed = False
                    HideOptionsText()
                ElseIf cursorSprite.UpperLeft.Y = 320 Then
                    cursorSprite.UpperLeft.Y = 220
                    p2UpIsPressed = False
                    HideOptionsText()
                ElseIf cursorSprite.UpperLeft.Y = 420 Then
                    cursorSprite.UpperLeft.Y = 320
                    p2UpIsPressed = False
                    HideOptionsText()
                ElseIf cursorSprite.UpperLeft.Y = 520 Then
                    cursorSprite.UpperLeft.Y = 420
                    p2UpIsPressed = False
                    HideOptionsText()
                End If

                If cursorSprite.UpperLeft.Y = 383 Then
                    cursorSprite.UpperLeft.Y = 498
                    p2UpIsPressed = False
                ElseIf cursorSprite.UpperLeft.Y = 498 Then
                    cursorSprite.UpperLeft.Y = 383
                    p2UpIsPressed = False
                End If
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(11, False, sfxVolume)
                End With
            End If
        End If
        If p2DownIsPressed Then
            If shootDelayIsActive Then
                ' Do nothing.
                p2DownIsPressed = False
            Else
                If blnGameIsStarted = False Then
                    If cursorSprite.UpperLeft.Y = 220 Then
                        cursorSprite.UpperLeft.Y = 320
                        p2DownIsPressed = False
                        HideOptionsText()
                    ElseIf cursorSprite.UpperLeft.Y = 320 Then
                        cursorSprite.UpperLeft.Y = 420
                        p2DownIsPressed = False
                        HideOptionsText()
                    ElseIf cursorSprite.UpperLeft.Y = 420 Then
                        cursorSprite.UpperLeft.Y = 520
                        p2DownIsPressed = False
                        HideOptionsText()
                    ElseIf cursorSprite.UpperLeft.Y = 520 Then
                        cursorSprite.UpperLeft.Y = 220
                        p2DownIsPressed = False
                        HideOptionsText()
                    End If

                    If cursorSprite.UpperLeft.Y = 383 Then
                        cursorSprite.UpperLeft.Y = 498
                        p2DownIsPressed = False
                    ElseIf cursorSprite.UpperLeft.Y = 498 Then
                        cursorSprite.UpperLeft.Y = 383
                        p2DownIsPressed = False
                    End If
                    intSound += 1
                    With sound
                        .Name = "sound" & intSound
                        .Play(11, False, sfxVolume)
                    End With
                End If
            End If
        End If
    End Sub

    Private Sub CursorShoot()
        If blnCursorHasShot Then
            Exit Sub
        End If
        If shootDelayIsActive Then
            Exit Sub
        End If

        blnCursorHasShot = True

        intMoveMMButtonsLeftTick = 0
        intMoveMMButtonsRightTick = 0
        tmrMoveMMButtonsLeft.Interval = 300
        tmrMoveMMButtonsRight.Interval = 300

        For Each shot In cursorShots
            If shot.IsAlive = False Then
                shot.IsAlive = True
                shot.TimeToLive = 5
                If cursorSprite.UpperLeft.X = 695 Then ' if he's on the left
                    shot.Angle = 180
                Else ' if he's facing left
                    shot.Angle = 0
                End If
                shot.SetVelocity(8)
                shot.UpperLeft = cursorShootPoint
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(2, False, sfxVolume)
                End With
                Return
            End If
        Next
    End Sub

    Private Sub CheckCursorShotCollisions()
        For Each shot In cursorShots
            If shot.IsCollided(picPlaySprite) Then

                strButtonDirection = "Left"
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                strButtonShot = "PLAY"

                shot.IsAlive = False
                blnFirstCanMove = False
                blnSecondCanMove = False
                blnThirdCanMove = False
                blnFourthCanMove = False
                MoveMMButtonsLeft()

            End If
            If shot.IsCollided(picHTPSprite) Then
                strButtonDirection = "Left"
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                strButtonShot = "HTP"
                blnFirstCanMove = False
                blnSecondCanMove = False
                blnThirdCanMove = False
                blnFourthCanMove = False
                MoveMMButtonsLeft()

                shot.IsAlive = False

            End If
            If shot.IsCollided(picOptionsSprite) Then
                strButtonDirection = "Left"
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                strButtonShot = "OPTIONS"
                blnFirstCanMove = False
                blnSecondCanMove = False
                blnThirdCanMove = False
                blnFourthCanMove = False
                MoveMMButtonsLeft()
                strCurrentMenu = "GAME"
                shot.IsAlive = False


            End If
            If shot.IsCollided(picArcadeSprite) Then
                strButtonDirection = "Left"
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                strButtonShot = "ARCADE"
                blnFirstCanMove = False
                blnSecondCanMove = False
                blnThirdCanMove = False
                blnFourthCanMove = False
                MoveMMButtonsLeft()

                shot.IsAlive = False
                tmrFadeToArcade.Start()
            End If

            ' options menu

            If shot.IsCollided(picOptionsTabSprite) Then
                strOptionButtonShot = ""
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With

                SwitchOptionsMenu()

                shot.IsAlive = False
            End If

            If shot.IsCollided(picOptions1Sprite) Then 'game time or music
                noMin.IsAlive = False
                twoHalfMin.IsAlive = False
                fiveMin.IsAlive = False
                tenMin.IsAlive = False
                musicMuted.IsAlive = False
                music25.IsAlive = False
                music50.IsAlive = False
                music75.IsAlive = False
                musicMax.IsAlive = False
                tmrHideOptionsText.Stop()
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With
                shot.IsAlive = False

                If strCurrentMenu = "GAME" Then 'Game time "AUDIO"
                    strOptionButtonShot = "GAMETIME"

                    Select Case gameTime
                        Case 1000
                            'make 5 min
                            fiveMin.IsAlive = True
                            gameTime = 500
                        Case 500
                            'make 2 and a half min
                            twoHalfMin.IsAlive = True
                            gameTime = 230
                        Case 230
                            'make one and a half min
                            twoHalfMin.IsAlive = True
                            twoHalfMin.SetImageResource(My.Resources.gameTimeOneHalfMinutesText)
                            gameTime = 130
                        Case 130
                            ' make unlimited
                            twoHalfMin.SetImageResource(My.Resources.gameTimeTwoHalfMinutesText)
                            noMin.IsAlive = True
                            gameTime = -1
                        Case -1
                            ' make 10 min
                            tenMin.IsAlive = True
                            gameTime = 1000
                    End Select
                Else ' Music volume/Max/Muted/75%/50%/25%
                    strOptionButtonShot = "MUSIC"

                    Select Case musicVolume
                        Case 1000
                            'make 75
                            music75.IsAlive = True
                            musicVolume = 750
                            HaltSound()
                            ' play launcher music again
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(8, True, musicVolume)
                            End With

                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(1, False, sfxVolume)
                            End With
                        Case 750
                            'make 50
                            music50.IsAlive = True
                            musicVolume = 500
                            HaltSound()
                            ' play launcher music again
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(8, True, musicVolume)
                            End With

                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(1, False, sfxVolume)
                            End With
                        Case 500
                            'make 25
                            music25.IsAlive = True
                            musicVolume = 250
                            HaltSound()
                            ' play launcher music again
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(8, True, musicVolume)
                            End With
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(1, False, sfxVolume)
                            End With
                        Case 250
                            ' make muted
                            musicMuted.IsAlive = True
                            musicVolume = 0
                            HaltSound()
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(1, False, sfxVolume)
                            End With
                        Case 0
                            ' make maxxed
                            musicMax.IsAlive = True
                            musicVolume = 1000
                            HaltSound()
                            ' play launcher music again
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(8, True, musicVolume)
                            End With
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(1, False, sfxVolume)
                            End With
                    End Select
                End If

                tmrHideOptionsText.Start()
                blnCursorHasShot = False
            End If

            If shot.IsCollided(picOptions2Sprite) Then ' Power-ups enabled or sound effects
                pupsEnabled.IsAlive = False
                pupsDisabled.IsAlive = False
                sfxMuted.IsAlive = False
                sfx25.IsAlive = False
                sfx50.IsAlive = False
                sfx75.IsAlive = False
                sfxMax.IsAlive = False
                tmrHideOptionsText.Stop()
                shot.IsAlive = False

                If strCurrentMenu = "GAME" Then 'PUPs Enabled/Disabled
                    strOptionButtonShot = "PUPS"
                    Select Case blnPUPsEnabled
                        Case True
                            'make false
                            pupsDisabled.IsAlive = True
                            blnPUPsEnabled = False
                        Case False
                            'make true
                            pupsEnabled.IsAlive = True
                            blnPUPsEnabled = True
                    End Select
                    intSound += 1
                    With sound
                        .Name = "sound" & intSound
                        .Play(1, False, sfxVolume)
                    End With
                Else ' Sound effects volume/Max/Muted/75%/50%/25%
                    strOptionButtonShot = "SFX"

                    Select Case sfxVolume
                        Case 1000
                            'make 75
                            sfx75.IsAlive = True
                            sfxVolume = 750
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(1, False, sfxVolume)
                            End With
                        Case 750
                            'make 50
                            sfx50.IsAlive = True
                            sfxVolume = 500
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(1, False, sfxVolume)
                            End With
                        Case 500
                            'make 25
                            sfx25.IsAlive = True
                            sfxVolume = 250
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(1, False, sfxVolume)
                            End With
                        Case 250
                            ' make muted
                            sfxMuted.IsAlive = True
                            sfxVolume = 0
                        Case 0
                            ' make maxxed
                            sfxMax.IsAlive = True
                            sfxVolume = 1000
                            intSound += 1
                            With sound
                                .Name = "sound" & intSound
                                .Play(1, False, sfxVolume)
                            End With
                    End Select
                End If

                tmrHideOptionsText.Start()
                blnCursorHasShot = False
            End If

            If shot.IsCollided(picOptions3Sprite) Then ' Main menu
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With
                shot.IsAlive = False
                MoveOptionsButtonsRight()
            End If

            If shot.IsCollided(yesSprite) Then ' Play again!
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With
                shot.IsAlive = False
                tmrReturnToMenu.Stop()
                strHeadingToMenuText = ""
                strVictoryButtonShot = "YES"
                MoveVictoryButtonsRight()
            End If
            If shot.IsCollided(noSprite) Then ' Return to menu from victory screen.
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With
                shot.IsAlive = False
                tmrReturnToMenu.Stop()
                strHeadingToMenuText = "Heading to main menu..."
                strVictoryButtonShot = "NO"
                MoveVictoryButtonsRight()
            End If
        Next
    End Sub

    Private Sub InitializeCursorShots(a)
        For i = a To cursorAmmo - 1
            cursorShots(i) = New Sprite()
            cursorShots(i).IsAlive = False
            cursorShots(i).SetImageResource(My.Resources.shotOrangeWide)
            cursorShots(i).MaxSpeed = MAX_SPEED
        Next
    End Sub

    Private Sub PaintCursorShots(ByRef myGraphics As Graphics)
        For Each shot In cursorShots
            If (shot.IsAlive = True) Then
                shot.PaintRotatedImage(myGraphics, shot.Angle, shot.GetCenter(), True)
            End If
        Next
    End Sub

    Private Sub MoveCursorShots()
        For Each shot In cursorShots
            shot.Move(Me.ClientSize)
        Next
    End Sub

    Private Sub frmGameScreen_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        e.IsInputKey = True 'Without this being set to true, the arrow keys are suppressed and do nothing on the main menu. Odd, huh?
    End Sub

    Private Sub InitializeButtons()

        ' end game yes no buttons, text, and victorious stickmen

        trophySprite = New Sprite
        trophySprite.IsAlive = False
        trophySprite.TimeToLive = -1
        trophySprite.UpperLeft.X = 20
        trophySprite.UpperLeft.Y = 45

        yesSprite = New Sprite
        yesSprite.IsAlive = False
        yesSprite.TimeToLive = -1
        yesSprite.SetImageResource(My.Resources.picYes)
        yesSprite.UpperLeft.X = 547
        yesSprite.UpperLeft.Y = 379

        noSprite = New Sprite
        noSprite.IsAlive = False
        noSprite.TimeToLive = -1
        noSprite.SetImageResource(My.Resources.picNo)
        noSprite.UpperLeft.X = 547
        noSprite.UpperLeft.Y = 494

        winnerTextSprite = New Sprite
        winnerTextSprite.IsAlive = False
        winnerTextSprite.TimeToLive = -1
        winnerTextSprite.SetImageResource(My.Resources.picBothWin)
        winnerTextSprite.UpperLeft.X = 348
        winnerTextSprite.UpperLeft.Y = 21

        playAgainSprite = New Sprite
        playAgainSprite.IsAlive = False
        playAgainSprite.TimeToLive = -1
        playAgainSprite.SetImageResource(My.Resources.picPlayAgain)
        playAgainSprite.UpperLeft.X = 355
        playAgainSprite.UpperLeft.Y = 275

        ' options menu

        fiveMin = New Sprite
        fiveMin.IsAlive = False
        fiveMin.TimeToLive = -1
        fiveMin.SetImageResource(My.Resources.gameTimeFiveMinutesText)
        fiveMin.UpperLeft.X = 118
        fiveMin.UpperLeft.Y = 325

        tenMin = New Sprite
        tenMin.IsAlive = False
        tenMin.TimeToLive = -1
        tenMin.SetImageResource(My.Resources.gameTimeTenMinutesText)
        tenMin.UpperLeft.X = 88
        tenMin.UpperLeft.Y = 325

        twoHalfMin = New Sprite
        twoHalfMin.IsAlive = False
        twoHalfMin.TimeToLive = -1
        twoHalfMin.SetImageResource(My.Resources.gameTimeTwoHalfMinutesText)
        twoHalfMin.UpperLeft.X = 114
        twoHalfMin.UpperLeft.Y = 325

        noMin = New Sprite
        noMin.IsAlive = False
        noMin.TimeToLive = -1
        noMin.SetImageResource(My.Resources.gameTimeUnlimitedText)
        noMin.UpperLeft.X = 3
        noMin.UpperLeft.Y = 322

        musicMax = New Sprite
        musicMax.IsAlive = False
        musicMax.TimeToLive = -1
        musicMax.SetImageResource(My.Resources.soundMaxText)
        musicMax.UpperLeft.X = 91
        musicMax.UpperLeft.Y = 320

        music75 = New Sprite
        music75.IsAlive = False
        music75.TimeToLive = -1
        music75.SetImageResource(My.Resources.sound75Text)
        music75.UpperLeft.X = 136
        music75.UpperLeft.Y = 324

        music50 = New Sprite
        music50.IsAlive = False
        music50.TimeToLive = -1
        music50.SetImageResource(My.Resources.sound50Text)
        music50.UpperLeft.X = 131
        music50.UpperLeft.Y = 323

        music25 = New Sprite
        music25.IsAlive = False
        music25.TimeToLive = -1
        music25.SetImageResource(My.Resources.sound25Text)
        music25.UpperLeft.X = 130
        music25.UpperLeft.Y = 324

        musicMuted = New Sprite
        musicMuted.IsAlive = False
        musicMuted.TimeToLive = -1
        musicMuted.SetImageResource(My.Resources.soundMutedText)
        musicMuted.UpperLeft.X = 46
        musicMuted.UpperLeft.Y = 320

        sfxMax = New Sprite
        sfxMax.IsAlive = False
        sfxMax.TimeToLive = -1
        sfxMax.SetImageResource(My.Resources.soundMaxText)
        sfxMax.UpperLeft.X = 91
        sfxMax.UpperLeft.Y = 420

        sfx75 = New Sprite
        sfx75.IsAlive = False
        sfx75.TimeToLive = -1
        sfx75.SetImageResource(My.Resources.sound75Text)
        sfx75.UpperLeft.X = 136
        sfx75.UpperLeft.Y = 424

        sfx50 = New Sprite
        sfx50.IsAlive = False
        sfx50.TimeToLive = -1
        sfx50.SetImageResource(My.Resources.sound50Text)
        sfx50.UpperLeft.X = 131
        sfx50.UpperLeft.Y = 423

        sfx25 = New Sprite
        sfx25.IsAlive = False
        sfx25.TimeToLive = -1
        sfx25.SetImageResource(My.Resources.sound25Text)
        sfx25.UpperLeft.X = 130
        sfx25.UpperLeft.Y = 424

        sfxMuted = New Sprite
        sfxMuted.IsAlive = False
        sfxMuted.TimeToLive = -1
        sfxMuted.SetImageResource(My.Resources.soundMutedText)
        sfxMuted.UpperLeft.X = 46
        sfxMuted.UpperLeft.Y = 420

        pupsEnabled = New Sprite
        pupsEnabled.IsAlive = False
        pupsEnabled.TimeToLive = -1
        pupsEnabled.SetImageResource(My.Resources.pupsEnabledText)
        pupsEnabled.UpperLeft.X = 20
        pupsEnabled.UpperLeft.Y = 422


        pupsDisabled = New Sprite
        pupsDisabled.IsAlive = False
        pupsDisabled.TimeToLive = -1
        pupsDisabled.SetImageResource(My.Resources.pupsDisabledText)
        pupsDisabled.UpperLeft.X = 6
        pupsDisabled.UpperLeft.Y = 422

        ' main menu

        picPlaySprite = New Sprite
        picPlaySprite.IsAlive = True
        picPlaySprite.TimeToLive = -1
        picPlaySprite.SetImageResource(My.Resources.tempButtonPlay)
        picPlaySprite.UpperLeft.X = 236
        picPlaySprite.UpperLeft.Y = 210

        picHTPSprite = New Sprite
        picHTPSprite.IsAlive = True
        picHTPSprite.TimeToLive = -1
        picHTPSprite.SetImageResource(My.Resources.tempButtonHTP)
        picHTPSprite.UpperLeft.X = 236
        picHTPSprite.UpperLeft.Y = 310

        picOptionsSprite = New Sprite
        picOptionsSprite.IsAlive = True
        picOptionsSprite.TimeToLive = -1
        picOptionsSprite.SetImageResource(My.Resources.tempButtonOptions)
        picOptionsSprite.UpperLeft.X = 236
        picOptionsSprite.UpperLeft.Y = 410

        picArcadeSprite = New Sprite
        picArcadeSprite.IsAlive = True
        picArcadeSprite.TimeToLive = -1
        picArcadeSprite.SetImageResource(My.Resources.tempButtonArcade)
        picArcadeSprite.UpperLeft.X = 236
        picArcadeSprite.UpperLeft.Y = 510

        ' more options menu

        picOptionsTabSprite = New Sprite
        picOptionsTabSprite.IsAlive = False
        picOptionsTabSprite.TimeToLive = -1
        picOptionsTabSprite.SetImageResource(My.Resources.btnOptionsGameTab)
        picOptionsTabSprite.UpperLeft.X = 801 ' put at 236
        picOptionsTabSprite.UpperLeft.Y = 210 ' stays same

        picOptions1Sprite = New Sprite
        picOptions1Sprite.IsAlive = False
        picOptions1Sprite.TimeToLive = -1
        picOptions1Sprite.SetImageResource(My.Resources.btnGameTime)
        picOptions1Sprite.UpperLeft.X = 801 ' put at 236
        picOptions1Sprite.UpperLeft.Y = 310 ' stays same

        picOptions2Sprite = New Sprite
        picOptions2Sprite.IsAlive = False
        picOptions2Sprite.TimeToLive = -1
        picOptions2Sprite.SetImageResource(My.Resources.btnPowerUps)
        picOptions2Sprite.UpperLeft.X = 801 ' put at 236
        picOptions2Sprite.UpperLeft.Y = 410 ' stays same

        picOptions3Sprite = New Sprite
        picOptions3Sprite.IsAlive = False
        picOptions3Sprite.TimeToLive = -1
        picOptions3Sprite.SetImageResource(My.Resources.btnMainMenu)
        picOptions3Sprite.UpperLeft.X = 801 ' put at 236
        picOptions3Sprite.UpperLeft.Y = 510 ' stays same

        htpShoot = New Sprite
        htpShoot.IsAlive = False
        htpShoot.TimeToLive = -1
        htpShoot.SetImageResource(My.Resources.htpShoot)
        htpShoot.UpperLeft = New Point(108, 211)

        htpMove = New Sprite
        htpMove.IsAlive = False
        htpMove.TimeToLive = -1
        htpMove.SetImageResource(My.Resources.htpMove)
        htpMove.UpperLeft = New Point(447, 215)

        htpRun = New Sprite
        htpRun.IsAlive = False
        htpRun.TimeToLive = -1
        htpRun.SetImageResource(My.Resources.htpRun)
        htpRun.UpperLeft = New Point(607, 209)

        htpJump = New Sprite
        htpJump.IsAlive = False
        htpJump.TimeToLive = -1
        htpJump.SetImageResource(My.Resources.htpJump)
        htpJump.UpperLeft = New Point(620, 273)

        htpTime = New Sprite
        htpTime.IsAlive = False
        htpTime.TimeToLive = -1
        htpTime.SetImageResource(My.Resources.htpTime)
        htpTime.UpperLeft = New Point(30, 487)

        ' Not a button, but rather the get ready text. I'm too lazy to make a whole 'nuther initialize() and paint() subroutine for it.
        ' While I'm at it, I'll do the text images here for the options menu.
        ' I know. Lazy.
        ' TO DO: get ready 5 4 3 2 1--change everything that uses grobold font to images, because other computers don't have my favorite font!
        picGetReadySprite = New Sprite
        picGetReadySprite.IsAlive = False 'gets set to true when it comes out
        picGetReadySprite.TimeToLive = -1
        picGetReadySprite.SetImageResource(My.Resources.picGetReady)
        picGetReadySprite.UpperLeft.X = 800
        picGetReadySprite.UpperLeft.Y = 225
    End Sub

    Private Sub PaintButtons(ByRef myGraphics As Graphics)
        If (picPlaySprite Is Nothing) Then
            Return
        End If
        If (picHTPSprite Is Nothing) Then
            Return
        End If
        If (picOptionsSprite Is Nothing) Then
            Return
        End If
        If (picArcadeSprite Is Nothing) Then
            Return
        End If
        If (picGetReadySprite Is Nothing) Then
            Return
        End If
        If (picOptionsTabSprite Is Nothing) Then
            Return
        End If
        If (picOptions1Sprite Is Nothing) Then
            Return
        End If
        If (picOptions2Sprite Is Nothing) Then
            Return
        End If
        If (picOptions3Sprite Is Nothing) Then
            Return
        End If
        If (fiveMin Is Nothing) Then
            Return
        End If
        If (tenMin Is Nothing) Then
            Return
        End If
        If (twoHalfMin Is Nothing) Then
            Return
        End If
        If (noMin Is Nothing) Then
            Return
        End If
        If (musicMax Is Nothing) Then
            Return
        End If
        If (music75 Is Nothing) Then
            Return
        End If
        If (music50 Is Nothing) Then
            Return
        End If
        If (music25 Is Nothing) Then
            Return
        End If
        If (musicMuted Is Nothing) Then
            Return
        End If
        If (sfxMax Is Nothing) Then
            Return
        End If
        If (sfx75 Is Nothing) Then
            Return
        End If
        If (sfx50 Is Nothing) Then
            Return
        End If
        If (sfx25 Is Nothing) Then
            Return
        End If
        If (sfxMuted Is Nothing) Then
            Return
        End If
        If (pupsEnabled Is Nothing) Then
            Return
        End If
        If (pupsDisabled Is Nothing) Then
            Return
        End If
        If (yesSprite Is Nothing) Then
            Return
        End If
        If (noSprite Is Nothing) Then
            Return
        End If
        If (winnerTextSprite Is Nothing) Then
            Return
        End If
        If (playAgainSprite Is Nothing) Then
            Return
        End If
        If (trophySprite Is Nothing) Then
            Return
        End If
        If (htpShoot Is Nothing) Then
            Return
        End If
        If (htpMove Is Nothing) Then
            Return
        End If
        If (htpRun Is Nothing) Then
            Return
        End If
        If (htpJump Is Nothing) Then
            Return
        End If
        If (htpTime Is Nothing) Then
            Return
        End If

        picPlaySprite.PaintRotatedImage(myGraphics, picPlaySprite.Angle, picPlaySprite.GetCenter(), True)
        picHTPSprite.PaintRotatedImage(myGraphics, picHTPSprite.Angle, picHTPSprite.GetCenter(), True)
        picOptionsSprite.PaintRotatedImage(myGraphics, picOptionsSprite.Angle, picOptionsSprite.GetCenter(), True)
        picArcadeSprite.PaintRotatedImage(myGraphics, picArcadeSprite.Angle, picArcadeSprite.GetCenter(), True)
        picGetReadySprite.PaintRotatedImage(myGraphics, picGetReadySprite.Angle, picGetReadySprite.GetCenter(), True)
        picOptionsTabSprite.PaintRotatedImage(myGraphics, picOptionsTabSprite.Angle, picOptionsTabSprite.GetCenter(), True)
        picOptions1Sprite.PaintRotatedImage(myGraphics, picOptions1Sprite.Angle, picOptions1Sprite.GetCenter(), True)
        picOptions2Sprite.PaintRotatedImage(myGraphics, picOptions2Sprite.Angle, picOptions2Sprite.GetCenter(), True)
        picOptions3Sprite.PaintRotatedImage(myGraphics, picOptions3Sprite.Angle, picOptions3Sprite.GetCenter(), True)
        tenMin.PaintRotatedImage(myGraphics, tenMin.Angle, tenMin.GetCenter(), True)
        fiveMin.PaintRotatedImage(myGraphics, fiveMin.Angle, fiveMin.GetCenter(), True)
        twoHalfMin.PaintRotatedImage(myGraphics, twoHalfMin.Angle, twoHalfMin.GetCenter(), True)
        noMin.PaintRotatedImage(myGraphics, noMin.Angle, noMin.GetCenter(), True)
        musicMax.PaintRotatedImage(myGraphics, musicMax.Angle, musicMax.GetCenter(), True)
        music75.PaintRotatedImage(myGraphics, music75.Angle, music75.GetCenter(), True)
        music50.PaintRotatedImage(myGraphics, music50.Angle, music50.GetCenter(), True)
        music25.PaintRotatedImage(myGraphics, music25.Angle, music25.GetCenter(), True)
        musicMuted.PaintRotatedImage(myGraphics, musicMuted.Angle, musicMuted.GetCenter(), True)
        sfxMax.PaintRotatedImage(myGraphics, sfxMax.Angle, sfxMax.GetCenter(), True)
        sfx75.PaintRotatedImage(myGraphics, sfx75.Angle, sfx75.GetCenter(), True)
        sfx50.PaintRotatedImage(myGraphics, sfx50.Angle, sfx50.GetCenter(), True)
        sfx25.PaintRotatedImage(myGraphics, sfx25.Angle, sfx25.GetCenter(), True)
        sfxMuted.PaintRotatedImage(myGraphics, sfxMuted.Angle, sfxMuted.GetCenter(), True)
        pupsEnabled.PaintRotatedImage(myGraphics, pupsEnabled.Angle, pupsEnabled.GetCenter(), True)
        pupsDisabled.PaintRotatedImage(myGraphics, pupsDisabled.Angle, pupsDisabled.GetCenter(), True)
        yesSprite.PaintRotatedImage(myGraphics, yesSprite.Angle, yesSprite.GetCenter(), True)
        noSprite.PaintRotatedImage(myGraphics, noSprite.Angle, noSprite.GetCenter(), True)
        winnerTextSprite.PaintRotatedImage(myGraphics, winnerTextSprite.Angle, winnerTextSprite.GetCenter(), True)
        playAgainSprite.PaintRotatedImage(myGraphics, playAgainSprite.Angle, playAgainSprite.GetCenter(), True)
        trophySprite.PaintRotatedImage(myGraphics, trophySprite.Angle, trophySprite.GetCenter(), True)

        htpShoot.PaintRotatedImage(myGraphics, htpShoot.Angle, htpShoot.GetCenter(), True)
        htpMove.PaintRotatedImage(myGraphics, htpMove.Angle, htpMove.GetCenter(), True)
        htpRun.PaintRotatedImage(myGraphics, htpRun.Angle, htpRun.GetCenter(), True)
        htpJump.PaintRotatedImage(myGraphics, htpJump.Angle, htpJump.GetCenter(), True)
        htpTime.PaintRotatedImage(myGraphics, htpTime.Angle, htpTime.GetCenter(), True)
    End Sub

    ' Anytime on the main menu screen, when the user hits any of the four buttons, call this to automatically move them off the screen.
    Private Sub MoveMMButtonsLeft()
        tmrMoveMMButtonsLeft.Start()
    End Sub

    Private Sub tmrMoveMMButtonsLeft_Tick(sender As Object, e As EventArgs) Handles tmrMoveMMButtonsLeft.Tick
        Select Case intMoveMMButtonsLeftTick
            Case 0
                ' Do nothing, let that splat sound sink in and be meaningful. Just...pause. How dramatic.
                intMoveMMButtonsLeftTick += 1
            Case 1 'start moving
                tmrMoveMMButtonsLeft.Interval = 250
                intMoveMMButtonsLeftTick += 1

                blnFirstCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With
            Case 2
                intMoveMMButtonsLeftTick += 1
                blnSecondCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With

            Case 3
                intMoveMMButtonsLeftTick += 1
                blnThirdCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With
            Case 4
                intMoveMMButtonsLeftTick += 1
                blnFourthCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With
            Case 5
                intMoveMMButtonsLeftTick += 1

            Case 6
                intMoveMMButtonsLeftTick += 1

                If strButtonShot = "OPTIONS" Then
                    MoveOptionsButtonsLeft()
                    intMoveMMButtonsLeftTick = 0
                    tmrMoveMMButtonsLeft.Interval = 300
                    tmrMoveMMButtonsLeft.Stop()
                ElseIf strButtonShot = "HTP" Then
                    intMoveMMButtonsLeftTick = 0
                    tmrMoveMMButtonsLeft.Interval = 300
                    tmrMoveMMButtonsLeft.Stop()
                    ShowHTPScreen()
                ElseIf strButtonShot = "PLAY" Then
                    picGetReadySprite.IsAlive = True
                    blnPicGetReadyCanMove = True
                    intSound += 1
                    With sound
                        .Name = "sound" & intSound
                        .Play(16, False, sfxVolume)
                    End With
                    tmrMoveMMButtonsLeft.Interval = 300
                    intMoveMMButtonsLeftTick = 0
                    tmrGetReady.Start()
                    tmrMoveMMButtonsLeft.Stop()
                ElseIf strButtonShot = "ARCADE" Then
                    intMoveMMButtonsLeftTick = 0
                    tmrMoveMMButtonsLeft.Interval = 300
                    tmrMoveMMButtonsLeft.Stop()
                End If

        End Select
    End Sub

    Private Sub MoveMMButtonsRight()
        strButtonDirection = "Right"
        intMoveMMButtonsRightTick = 0
        tmrMoveMMButtonsRight.Start()
    End Sub

    Private Sub MoveOptionsButtonsLeft()
        strOptionsDirection = "Left"
        tmrMoveOptionsButtonsLeft.Start()
    End Sub

    Private Sub MoveOptionsButtonsRight()
        strOptionsDirection = "Right"
        strButtonDirection = "Right"
        intMoveOptionsButtonsLeftTick = 0
        intMoveOptionsButtonsRightTick = 0
        intMoveMMButtonsLeftTick = 0
        intMoveMMButtonsRightTick = 0
        strCurrentMenu = "GAME"
        tmrMoveOptionsButtonsRight.Start()
    End Sub

    Private Sub MoveVictoryButtonsRight()
        intMoveVictoryButtonsTick = 0
        tmrMoveVictoryButtons.Start()
    End Sub

    'Private Sub MoveOptionsButtonsRight()
    '    tmrMoveOptionsButtonsRight.Start()
    'End Sub

    Private Sub tmrMoveMMButtonsRight_Tick(sender As Object, e As EventArgs) Handles tmrMoveMMButtonsRight.Tick
        Select Case intMoveMMButtonsRightTick
            Case 0
                ' Do nothing, let that splat sound sink in and be meaningful. Just...pause. How dramatic.
                intMoveMMButtonsRightTick += 1
            Case 1 'start moving
                tmrMoveMMButtonsRight.Interval = 250
                intMoveMMButtonsRightTick += 1
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With
                blnFirstCanMove = True

            Case 2
                intMoveMMButtonsRightTick += 1
                blnSecondCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With
            Case 3
                intMoveMMButtonsRightTick += 1
                blnThirdCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With
            Case 4
                intMoveMMButtonsRightTick += 1
                blnFourthCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With
            Case 5
                intMoveMMButtonsRightTick += 1

            Case 6
                intMoveMMButtonsRightTick += 1
                strCurrentMenu = "GAME"
                picOptionsTabSprite.SetImageResource(My.Resources.btnOptionsGameTab)
                picOptions1Sprite.SetImageResource(My.Resources.btnGameTime)
                picOptions2Sprite.SetImageResource(My.Resources.btnPowerUps)
                If strButtonShot = "OPTIONS" Then
                    'MoveOptionsButtonsRight()
                    intMoveMMButtonsRightTick = 0
                    intMoveOptionsButtonsLeftTick = 0
                    intMoveOptionsButtonsRightTick = 0
                    tmrMoveMMButtonsRight.Interval = 300
                    tmrMoveMMButtonsRight.Stop()
                ElseIf strButtonShot = "HTP" Then
                    'enter HTP screen? currently no buttons active
                    intMoveMMButtonsRightTick = 0
                    tmrMoveMMButtonsRight.Interval = 300
                    tmrMoveMMButtonsRight.Stop()
                ElseIf strButtonShot = "PLAY" Then
                    intMoveMMButtonsRightTick = 0
                    tmrMoveMMButtonsRight.Interval = 300
                    tmrMoveMMButtonsRight.Stop()
                    'get ready text comes in! countdown, startgame. Kill the buttons. All of them.
                ElseIf strButtonShot = "ARCADE" Then
                    intMoveMMButtonsRightTick = 0
                    tmrMoveMMButtonsRight.Interval = 300
                    tmrMoveMMButtonsRight.Stop()
                    'good bye text comes in! wait a second with a timer, application.exit.
                End If
        End Select
    End Sub

    Private Sub RandomSplash()
        blnFancy = False
        intSplash = rdmSplash.Next(0, 94) 'change second number to match total Splashes, more can be added by changing the number and adding to the case statement below. Easy as pie!
        'Note: the second number must always be the total number of Splashes, considering "0" is counted. I have 74 splashes, but the 74th splash is actually the 73rd. 0, 1...73. Yea.

        Select Case intSplash
            Case 0
                strSplash = "Now with more exclamation points!"
            Case 1
                strSplash = "Also try Escher's Keep!"
            Case 2
                strSplash = "Splat!"
            Case 3
                strSplash = "Version two-point-oh!"
            Case 4
                strSplash = "Also try Simon Says!"
            Case 5
                strSplash = "Also try Crack the Code!"
            Case 6
                strSplash = "Also try Presidential Defense!"
            Case 7
                strSplash = "Red vs. Blue!"
            Case 8
                strSplash = "Skirdooey!"
            Case 9
                strSplash = "A ripple, an anomaly!"
            Case 10
                strSplash = "Great Scott!"
            Case 11
                strSplash = "Vexing!"
            Case 12
                strSplash = "Tip of the iceberg!"
            Case 13
                strSplash = "Better than Dimitri's!"
            Case 14
                strSplash = "Better than Jeff's!"
            Case 15
                strSplash = "Better than Paul's!"
            Case 16
                strSplash = "Silence! I keel you!"
            Case 17
                strSplash = "Oddly satisfying!"
            Case 18
                strSplash = "Made by Kevin!"
            Case 19
                strSplash = "3spooky5me"
            Case 20
                strSplash = "Tick-tock, reset the clock!"
            Case 21
                strSplash = "He's not in the stove!"
            Case 22
                strSplash = "It starts and ends in lightning!"
            Case 23
                strSplash = "That's Numberwang!"
            Case 24
                strSplash = "Them's fightin' words!"
            Case 25
                strSplash = "1.21 gigawatts!"
            Case 26
                strSplash = "As seen on TV!"
            Case 27
                strSplash = "The Work of Kevin!"
            Case 28
                strSplash = "Engage!"
            Case 29
                strSplash = "It's a trap!"
            Case 30
                strSplash = "Does barrel rolls!"
            Case 31
                strSplash = "If IsFun Then showSplash() End If"
            Case 32
                strSplash = "VisualBasic!"
            Case 33
                strSplash = "Ask your parent's permission!"
            Case 34
                strSplash = "Maximum overdrive!"
            Case 35
                strSplash = "Blood and sweat!"
            Case 36
                strSplash = "KHAAAAAAAN!"
            Case 37
                strSplash = "This is my true form!"
            Case 38
                strSplash = "Of course you realize, this means war!"
            Case 39
                strSplash = "Get the Neosporin!"
            Case 40
                strSplash = "May contain nuts!"
            Case 41
                strSplash = "Ask your doctor!"
            Case 42
                strSplash = "Fancy splash!"
                blnFancy = True 'lol
            Case 43
                strSplash = "Chuck Norris plays it!"
            Case 44
                strSplash = "Life finds a way!"
            Case 45
                strSplash = "Yeah, yeah, yeah, YEAH! Oh yeah!"
            Case 46
                strSplash = "Tell your peers!"
            Case 47
                strSplash = "The bee's knees!"
            Case 48
                strSplash = "Dramatic entrances!"
            Case 49
                strSplash = "Born to be alive!"
            Case 50
                strSplash = "10,238 lines of code!"
            Case 51
                strSplash = "asdfasdfasdf!"
            Case 52
                strSplash = "Cogito ergo sum!"
            Case 53
                strSplash = "A wild stick figure appeared!"
            Case 54
                strSplash = "Tyler Cross!"
            Case 55
                strSplash = "LEEEROYYY JEEENKIIINS!"
            Case 56
                strSplash = "Is that word even IN your vocabulary?!"
            Case 57
                strSplash = "Messy, messy, messy!"
            Case 58
                strSplash = "Oxfords, not brogues!"
            Case 59
                strSplash = "Won an Oscar!"
            Case 60
                strSplash = "Bada bing, bada boom!"
            Case 61
                strSplash = "99.9% bacteria-free!"
            Case 62
                strSplash = "The points don't matter!"
            Case 63
                strSplash = "Stop—hammertime!"
            Case 64
                strSplash = "Møøse bites Kan be pretti nasti!"
            Case 65
                strSplash = "Déjà vu!"
            Case 66
                strSplash = "Paintception!"
            Case 67
                strSplash = "The magical s!"
            Case 68
                strSplash = "Paintball!"
            Case 69
                strSplash = "A classic!"
            Case 70
                strSplash = "See the løveli lakes!"
            Case 71
                strSplash = "42!"
            Case 72
                strSplash = "African or European?!"
            Case 73
                strSplash = "There are some who call me...Tim!"
            Case 74
                strSplash = "Back to the drawing board!"
            Case 75
                strSplash = "Carpe diem!"
            Case 76
                strSplash = "Live long and prosper!"
            Case 77
                strSplash = "Beam me up, Scotty!"
            Case 78
                strSplash = "Wait in the car, Brian!"
            Case 79
                strSplash = "This is Spork territory!"
            Case 80
                strSplash = "Plug your nose!"
            Case 81
                strSplash = "Energize!"
            Case 82
                strSplash = "This isn't real!"
            Case 83
                strSplash = "Woo, ohs!"
            Case 84
                strSplash = "WHERE'S REMIEL?"
            Case 85
                strSplash = "It's about time!"
            Case 86
                strSplash = "All clear!"
            Case 87
                strSplash = "Nobody calls me chicken!"
            Case 88
                strSplash = "It's all about the game!"
            Case 89
                strSplash = "There's nothing better than a fourth taco!"
            Case 90
                strSplash = "Welcome...to ME!"
            Case 91
                strSplash = "Better call WHOM?!"
            Case 92
                strSplash = "Nobody expects the Spanish Inquisition!"
            Case 93
                strSplash = "Heavy!"
        End Select

    End Sub

    Private Sub tmrGetReady_Tick(sender As Object, e As EventArgs) Handles tmrGetReady.Tick
        Select Case intGetReadyTick
            Case 0
                ' Wait!
                intGetReadyTick += 1
            Case 1
                ' Wait!
                intGetReadyTick += 1
            Case 2
                ' 5
                strGetReady = "5"
                intGetReadyTick += 1
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(10, False, sfxVolume)
                End With
            Case 3
                ' 4
                strGetReady = "4"
                intGetReadyTick += 1
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(10, False, sfxVolume)
                End With
            Case 4
                ' 3
                strGetReady = "3"
                intGetReadyTick += 1
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(10, False, sfxVolume)
                End With
            Case 5
                ' 2
                strGetReady = "2"
                intGetReadyTick += 1
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(10, False, sfxVolume)
                End With
            Case 6
                ' 1
                strGetReady = "1"
                intGetReadyTick += 1
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(10, False, sfxVolume)
                End With
            Case 7
                ' Start the game!
                strGetReady = ""

                p1IsJumping = 4 'Setting this to four due to the fact that otherwise, if a player moves the cursor up or down, they give a little "hop" when they spawn in. this resets it.
                p2IsJumping = 4
                bkgdForLauncher.Hide()
                launcherBkgdSprite.IsAlive = False
                cursorSprite.IsAlive = False
                picPlaySprite.IsAlive = False
                picHTPSprite.IsAlive = False
                picOptionsSprite.IsAlive = False
                picArcadeSprite.IsAlive = False
                blnGameIsStarted = True
                pbLogo.Hide()
                tmrSplashPulse.Stop()
                LauncherTimer.Stop()
                tmrCursorIdleRight.Stop()
                cursorRightIdleFrame = 1
                tmrCursorIdleLeft.Stop()
                cursorLeftIdleFrame = 1
                intGetReadyTextSize = 100
                intGetReadyTick = 0

                strWinner = ""
                StartGame()

                tmrGetReady.Stop()
        End Select
    End Sub

    Private Sub EndGame()

        CheckWinner() ' Winner is stored in "strWinner" as a String. Yeah, I could've been super efficient with RAM and used a Char, but whatevs. I'm a jerk.

        ' Here in Paintball! v2.0, we no longer restart the application upon game completion.
        ' We now return to the main menu screen! As such...we've got a lot of stuff to get rid of, kill, hide, or reset.

        HaltSound()

        intSound += 1
        With sound
            .Name = "sound" & intSound
            .Play(7, False, musicVolume)
        End With

        tmrGameTimeLeft.Stop()
        GameTimer.Stop()

        picPlayer1ActivePUP.Hide()
        picPlayer2ActivePUP.Hide()
        picPlayer1ActivePUP.Image = Nothing
        picPlayer2ActivePUP.Image = Nothing
        p1Sprite.IsAlive = False
        p2Sprite.IsAlive = False
        spriteInvisibleLeftWall.IsAlive = False
        spriteInvisibleRightWall.IsAlive = False
        testPowerUpSprite.IsAlive = False
        spriteTopWall.IsAlive = False
        spritePlatform2.IsAlive = False
        spritePlatform3.IsAlive = False
        spritePlatform4.IsAlive = False
        spritePlatform5.IsAlive = False
        spritePlatform6.IsAlive = False
        spritePlatform7.IsAlive = False
        spritePlatform8.IsAlive = False
        spritePlatform9.IsAlive = False
        spritePlatform10.IsAlive = False
        spritePlatform11.IsAlive = False
        backgroundImageSprite.IsAlive = False
        mainPlatformSprite.IsAlive = False
        picGameSpeed.Image = Nothing
        picPlayer1ActivePUP.Image = Nothing
        picPlayer2ActivePUP.Image = Nothing
        picGameSpeed.Hide()

        p2tmrLeftIdle.Stop()
        p2tmrRightIdle.Stop()
        p2tmrLeftRun.Stop()
        p2tmrRightRun.Stop()
        p1tmrLeftIdle.Stop()
        p1tmrRightIdle.Stop()
        p1tmrLeftRun.Stop()
        p1tmrRightRun.Stop()
        tmrRandomizePowerUps.Stop()
        p1tmrJump.Stop()
        p2tmrJump.Stop()
        p1tmrCrouch.Stop()
        p1tmrStandUp.Stop()
        p2tmrCrouch.Stop()
        p2tmrStandUp.Stop()
        tmrBobPowerUps.Stop()
        p1TripleShot.Stop()
        p2TripleShot.Stop()
        p1Shield.Stop()
        p2Shield.Stop()
        tmrSpeedUp.Stop()
        tmrSlowDown.Stop()
        p1IsCrouching = False
        p2IsCrouching = False
        p1DownIsPressed = False
        p2DownIsPressed = False
        intPlayer1StandUpTick = 0
        intPlayer1StartCrouchTick = 0
        intPlayer2StandUpTick = 0
        intPlayer2StartCrouchTick = 0
        intBobPowerUpsTick = 0

        p1IsJumping = 4
        p2IsJumping = 4
        powerup_speed_1.IsAlive = False     ' code: 1
        powerup_speed_2.IsAlive = False     ' code: 2
        powerup_health_3.IsAlive = False    ' code: 3
        powerup_health_4.IsAlive = False    ' code: 4
        powerup_health_5.IsAlive = False    ' code: 5
        powerup_ammo_6.IsAlive = False      ' code: 6
        powerup_ammo_7.IsAlive = False      ' code: 7
        powerup_ammo_8.IsAlive = False      ' code: 8
        powerup_slow_9.IsAlive = False      ' code: 9
        powerup_slow_10.IsAlive = False     ' code: 10
        powerup_shield_11.IsAlive = False   ' code: 11
        powerup_shield_12.IsAlive = False   ' code: 12
        powerup_triple_13.IsAlive = False   ' code: 13
        powerup_triple_14.IsAlive = False   ' code: 14
        p1IsTripled = False
        p2IsTripled = False
        p1IsShielded = False
        p2IsShielded = False
        GameIsSlowedDown = False
        GameIsSpedUp = False
        powerUpDump.Clear()
        p1HealthIs.Hide()
        p2HealthIs.Hide()
        p1HealthBar.Hide()
        p2HealthBar.Hide()
        lblPlayer1Ammo.Hide()
        lblPlayer2Ammo.Hide()
        tmrGameTimeLeft.Stop()
        ReturnGameToNormalSpeed("E")
        strTimeLeft = "0:00"

        For Each shot In p1Shots
            shot.IsAlive = False
        Next
        For Each shot In p2Shots
            shot.IsAlive = False
        Next
        Invalidate()

        ' Stop all timers and reset their ticks.
        GameTimer.Stop()
        restartGameTick = 0
        p1tmrJump.Stop()
        p1tmrFall.Stop()
        p2tmrJump.Stop()
        p2tmrFall.Stop()
        p1IsJumping = 4
        p2IsJumping = 4
        p1tmrLeftRun.Stop()
        p1LeftRunFrame = 1
        p2tmrRightRun.Stop()
        p2RightRunFrame = 1
        p1tmrLeftIdle.Stop()
        p1LeftIdleFrame = 1
        p2tmrRightIdle.Stop()
        p2RightIdleFrame = 1
        tmrRandomizePowerUps.Stop()
        tmrSpeedUp.Stop()
        tmrSlowDown.Stop()
        p1Shield.Stop()
        p2Shield.Stop()
        p1TripleShot.Stop()
        p2TripleShot.Stop()
        tmrCursorIdleLeft.Stop()
        tmrCursorIdleRight.Stop()
        tmrMoveOptionsButtonsLeft.Stop()
        tmrMoveOptionsButtonsRight.Stop()
        intMoveOptionsButtonsLeftTick = 0
        intMoveOptionsButtonsRightTick = 0
        intMoveMMButtonsRightTick = 0
        intMoveMMButtonsLeftTick = 0

        ' Reset the variables.
        TheResetBug = True
        p1IsShielded = False
        p2IsShielded = False
        blnFancy = False
        blnFirstCanMove = False
        blnSecondCanMove = False
        blnThirdCanMove = False
        blnFourthCanMove = False
        blnGameIsStarted = False
        blnPicGetReadyCanMove = False
        blnTimeToStartPowerUps = False
        p1IsTripled = False
        p2IsTripled = False
        GameIsSlowedDown = False
        GameIsSpedUp = False
        p1_blnIsJumping = False
        p2_blnIsJumping = False
        picPlayer1ActivePUP.Tag = ""
        picPlayer2ActivePUP.Tag = ""
        spriteInvisibleLeftWall.IsAlive = False
        spriteInvisibleRightWall.IsAlive = False
        testPowerUpSprite.IsAlive = False
        spriteTopWall.IsAlive = False
        spritePlatform2.IsAlive = False
        spritePlatform3.IsAlive = False
        spritePlatform4.IsAlive = False
        spritePlatform5.IsAlive = False
        spritePlatform6.IsAlive = False
        spritePlatform7.IsAlive = False
        spritePlatform8.IsAlive = False
        spritePlatform9.IsAlive = False
        spritePlatform10.IsAlive = False
        spritePlatform11.IsAlive = False
        backgroundImageSprite.IsAlive = False
        mainPlatformSprite.IsAlive = False
        backgroundImageSprite.IsAlive = False
        mainPlatformSprite.IsAlive = False


        ' Reset the placement of menu items.
        picGetReadySprite.UpperLeft.X = 800
        picGetReadySprite.UpperLeft.Y = 225
        powerUpDump.Clear()
        picPlaySprite.UpperLeft.X = 236
        picHTPSprite.UpperLeft.X = 236
        picOptionsSprite.UpperLeft.X = 236
        picArcadeSprite.UpperLeft.X = 236
        cursorSprite.UpperLeft.X = 70
        cursorSprite.UpperLeft.Y = 220

        blnFirstCanMove = False
        blnSecondCanMove = False
        blnThirdCanMove = False
        blnFourthCanMove = False

        lblPlayer1Ammo.Hide()
        lblPlayer1Ammo.Text = "AMMO: 100"
        lblPlayer2Ammo.Hide()
        lblPlayer2Ammo.Text = "AMMO: 100"
        p1HealthBar.Hide()
        p1HealthBar.Value = 100
        p2HealthBar.Hide()
        p2HealthBar.Value = 100
        p1HealthIs.Hide()
        p2HealthIs.Hide()
        picPlayer1ActivePUP.Hide()
        picPlayer2ActivePUP.Hide()
        strButtonDirection = ""
        strButtonShot = ""

        powerup_speed_1.IsAlive = False     ' code: 1
        powerup_speed_2.IsAlive = False     ' code: 2
        powerup_health_3.IsAlive = False    ' code: 3
        powerup_health_4.IsAlive = False    ' code: 47
        powerup_health_5.IsAlive = False    ' code: 5
        powerup_ammo_6.IsAlive = False      ' code: 6
        powerup_ammo_7.IsAlive = False      ' code: 7
        powerup_ammo_8.IsAlive = False      ' code: 8
        powerup_slow_9.IsAlive = False      ' code: 9
        powerup_slow_10.IsAlive = False     ' code: 10
        powerup_shield_11.IsAlive = False   ' code: 11
        powerup_shield_12.IsAlive = False   ' code: 12
        powerup_triple_13.IsAlive = False   ' code: 13
        powerup_triple_14.IsAlive = False   ' code: 14

        p1UpIsPressed = False
        p1DownIsPressed = False
        p2UpIsPressed = False
        p2DownIsPressed = False

        ShowVictoryScreen()
    End Sub

    Private Sub tmrFadeToArcade_Tick(sender As Object, e As EventArgs) Handles tmrFadeToArcade.Tick
        If tmrFadeToArcade.Tag = "this is funny because you will never see this" Then
            tmrFadeToArcade.Interval = 10
            tmrFadeToArcade.Tag = ""
        End If
        If tmrFadeToArcade.Interval = 1350 Then
            tmrFadeToArcade.Tag = "this is funny because you will never see this"
            Exit Sub
        End If
        Me.Opacity -= 0.02

        If Me.Opacity = 0 Then
            Application.Exit()
        End If
    End Sub

    Private Sub tmrMoveOptionsButtonsLeft_Tick(sender As Object, e As EventArgs) Handles tmrMoveOptionsButtonsLeft.Tick
        Select Case intMoveOptionsButtonsLeftTick
            Case 0
                ' Do nothing, let that splat sound sink in and be meaningful. Just...pause. How dramatic.
                ' Ok, fine. This is the options menu. Let's change the shot angle too while we're at it.
                ' Don't want to be slackin' on the job. Might get fired if boss sees.
                For Each shot In cursorShots
                    shot.Angle = 180 'bam now he shoots to the left how magnificent. gotta make a new idle animation for the left tho and change the shootpoint too.
                Next
                intMoveOptionsButtonsLeftTick += 1
            Case 1 'start moving
                tmrMoveOptionsButtonsLeft.Interval = 250
                intMoveOptionsButtonsLeftTick += 1

                picOptionsTabSprite.IsAlive = True
                'TOP ROW OF BUTTONS
                blnFirstORowCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With

                ' ADD MORE CASE STATEMENTS IN BETWEEN THIS ONE AND CASE 4 TO ADD FOR MORE "ROWS" of BUTTONS
            Case 2
                intMoveOptionsButtonsLeftTick += 1
                picOptions1Sprite.IsAlive = True
                blnSecondORowCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With

            Case 3
                intMoveOptionsButtonsLeftTick += 1
                picOptions2Sprite.IsAlive = True
                blnThirdORowCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With
            Case 4
                intMoveOptionsButtonsLeftTick += 1
                picOptions3Sprite.IsAlive = True
                blnFourthORowCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With

                ' Timer over, told all buttons to move!
                intMoveOptionsButtonsLeftTick += 1
                intMoveOptionsButtonsLeftTick = 0
                tmrMoveOptionsButtonsLeft.Interval = 300
                tmrMoveOptionsButtonsLeft.Stop()
        End Select
    End Sub

    Private Sub tmrCursorIdleLeft_Tick(sender As Object, e As EventArgs) Handles tmrCursorIdleLeft.Tick
        Select Case cursorLeftIdleFrame
            Case 1
                'frame 2
                cursorSprite.SetImageResource(My.Resources.orangeLeftCursorIdle2)
                cursorLeftIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 2
                'frame 3
                cursorSprite.SetImageResource(My.Resources.orangeLeftCursorIdle3)
                cursorLeftIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 3
                'frame 4
                cursorSprite.SetImageResource(My.Resources.orangeLeftCursorIdle4)
                cursorLeftIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 4
                'frame 5
                cursorSprite.SetImageResource(My.Resources.orangeLeftCursorIdle5)
                cursorLeftIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 5
                'frame 6
                cursorSprite.SetImageResource(My.Resources.orangeLeftCursorIdle6)
                cursorLeftIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 6
                'frame 7
                cursorSprite.SetImageResource(My.Resources.orangeLeftCursorIdle7)
                cursorLeftIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
                'cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 14
            Case 7
                'frame 8
                cursorSprite.SetImageResource(My.Resources.orangeLeftCursorIdle8)
                cursorLeftIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 8
                'frame 9
                cursorSprite.SetImageResource(My.Resources.orangeLeftCursorIdle9)
                cursorLeftIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 9
                'frame 10
                cursorSprite.SetImageResource(My.Resources.orangeLeftCursorIdle10)
                cursorLeftIdleFrame += 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
            Case 10
                'start over at frame 1
                cursorSprite.SetImageResource(My.Resources.orangeLeftCursorIdle1)
                cursorLeftIdleFrame = 1
                cursorShootPoint.X = cursorSprite.UpperLeft.X
                cursorShootPoint.Y = cursorSprite.UpperLeft.Y + 13
        End Select
    End Sub

    Private Sub SwitchOptionsMenu()
        If strCurrentMenu = "GAME" Then
            strCurrentMenu = "AUDIO"
            picOptionsTabSprite.SetImageResource(My.Resources.btnOptionsAudioTab)
            picOptions1Sprite.SetImageResource(My.Resources.btnMusic)
            picOptions2Sprite.SetImageResource(My.Resources.btnSfx) ' last button stays same
            blnCursorHasShot = False
        Else
            strCurrentMenu = "GAME"
            picOptionsTabSprite.SetImageResource(My.Resources.btnOptionsGameTab)
            picOptions1Sprite.SetImageResource(My.Resources.btnGameTime)
            picOptions2Sprite.SetImageResource(My.Resources.btnPowerUps) ' last button stays same
            blnCursorHasShot = False
        End If
    End Sub

    Private Sub tmrMoveOptionsButtonsRight_Tick(sender As Object, e As EventArgs) Handles tmrMoveOptionsButtonsRight.Tick
        Select Case intMoveOptionsButtonsRightTick
            Case 0
                ' Do nothing, let that splat sound sink in and be meaningful. Just...pause. How dramatic.
                ' Ok, fine. This is the options menu. Let's change the shot angle too while we're at it.
                ' Don't want to be slackin' on the job. Might get fired if boss sees.
                For Each shot In cursorShots
                    shot.Angle = 0 'bam now he shoots to the right how magnificent. gotta make a new idle animation for the right tho and change the shootpoint too.
                Next
                intMoveOptionsButtonsRightTick += 1
            Case 1 'start moving
                tmrMoveOptionsButtonsRight.Interval = 250
                intMoveOptionsButtonsRightTick += 1

                'TOP ROW OF BUTTONS
                blnFirstORowCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With

            Case 2
                intMoveOptionsButtonsRightTick += 1
                blnSecondORowCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With
            Case 3
                intMoveOptionsButtonsRightTick += 1
                blnThirdORowCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With
            Case 4
                intMoveOptionsButtonsRightTick += 1
                blnFourthORowCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With

                ' Timer over, told all buttons to move!
                intMoveOptionsButtonsRightTick += 1
                intMoveOptionsButtonsRightTick = 0
                MoveMMButtonsRight()
                tmrMoveOptionsButtonsRight.Interval = 300
                tmrMoveOptionsButtonsRight.Stop()
        End Select
    End Sub

    Private Sub tmrHideOptionsText_Tick(sender As Object, e As EventArgs) Handles tmrHideOptionsText.Tick
        'Select Case strOptionButtonShot
        '    Case "GAMETIME"
        tenMin.IsAlive = False
        fiveMin.IsAlive = False
        twoHalfMin.IsAlive = False
        noMin.IsAlive = False
        '    Case "PUPS"
        pupsDisabled.IsAlive = False
        pupsEnabled.IsAlive = False
        '    Case "MUSIC"
        music25.IsAlive = False
        music50.IsAlive = False
        music75.IsAlive = False
        musicMax.IsAlive = False
        musicMuted.IsAlive = False
        '    Case "SFX"
        sfx25.IsAlive = False
        sfx50.IsAlive = False
        sfx75.IsAlive = False
        sfxMax.IsAlive = False
        sfxMuted.IsAlive = False
        'End Select

        tmrHideOptionsText.Stop()
    End Sub

    Private Sub HideOptionsText()
        tenMin.IsAlive = False
        fiveMin.IsAlive = False
        twoHalfMin.IsAlive = False
        noMin.IsAlive = False
        pupsDisabled.IsAlive = False
        pupsEnabled.IsAlive = False
        music25.IsAlive = False
        music50.IsAlive = False
        music75.IsAlive = False
        musicMax.IsAlive = False
        musicMuted.IsAlive = False
        sfx25.IsAlive = False
        sfx50.IsAlive = False
        sfx75.IsAlive = False
        sfxMax.IsAlive = False
        sfxMuted.IsAlive = False
        tmrHideOptionsText.Stop()
    End Sub

    Private Sub tmrGameTimeLeft_Tick(sender As Object, e As EventArgs) Handles tmrGameTimeLeft.Tick

        CheckForMinuteChange()
        If blnMinuteChanged Then
            blnMinuteChanged = False
            Exit Sub
        End If
        CheckForSecondChange()

        If (Strings.Left(strTimeLeft, 1) = "0") And (Strings.Right(strTimeLeft, 2) <= "10") And (Strings.Right(strTimeLeft, 2) <> "-1") Then
            intSound += 1
            With sound
                .Name = "sound" & intSound
                .Play(10, False, sfxVolume)
            End With
        End If

    End Sub

    Private Sub CheckForMinuteChange()
        If (Strings.Right(strTimeLeft, 2) = "00") And (Strings.Left(strTimeLeft, 1) <> 0) Then
            If (Strings.Left(strTimeLeft, 2) = "10") Then
                strTimeLeft = "9:59"
            Else
                ' Subtract one from the minute, make the seconds "59".
                strTimeLeft = Strings.Left(strTimeLeft, 1) - 1 & ":59"
            End If
            blnMinuteChanged = True
        End If
    End Sub

    Private Sub CheckForSecondChange()
        If strTimeLeft = "0:00" Then
            EndGame()
        End If
        If (Strings.Right(strTimeLeft, 2) <> "10") Then
            If (Strings.Left(Strings.Right(strTimeLeft, 2), 1) = "0") Then
                strTimeLeft = Strings.Left(strTimeLeft, 1) & ":0" & Strings.Right(strTimeLeft, 1) - 1
            Else
                strTimeLeft = Strings.Left(strTimeLeft, 1) & ":" & Strings.Right(strTimeLeft, 2) - 1
                'strTimeLeft = Strings.Left(strTimeLeft, 1) & ":0" & Strings.Right(strTimeLeft, 1) - 1
            End If
        Else
            strTimeLeft = Strings.Left(strTimeLeft, 1) & ":0" & Strings.Right(strTimeLeft, 2) - 1
        End If
    End Sub

    Private Function CheckWinner() As String
        If p1HealthBar.Value > p2HealthBar.Value Then
            strWinner = "RED"
        ElseIf p1HealthBar.Value = p2HealthBar.Value Then
            strWinner = "BOTH"
        Else
            strWinner = "BLUE"
        End If

        Return strWinner
    End Function

    Private Sub p1Crouch()
        If p1IsOnGround = False Then
            Exit Sub
        End If

        If p1IsCrouching Then
            Exit Sub
        End If

        ' Player is ONLY standing still. Crouch.
        ' If the player tries to run AND crouch (diagonally downwards) he *should* only run, and not crouch. Test by pressing right key AND down key.
        ' If the player is already running and moves the joystick down (presses down), they should STOP running and immediatly crouch the direction they're facing.
        ' If the player is either jumping or falling (at any time in the air) and tries to crouch, they won't crouch UNTIL they hit the ground.

        ' How crouching works:
        ' Because the whole mechanic is to duck underneath shots, we need to physically move the player's UpperLeft.Y value down without including extra transparency.
        ' Henceforth, right before the player crouches, we'll save their UpperLeft.Y in a temporary Integer variable and use that later on to mess with their 

        If p1tmrCrouch.Enabled = False Then
            intPlayer1StartCrouchTick = 0
            p1Sprite.StopMoving()
            p1UpperLeftY = p1Sprite.UpperLeft.Y
            p1tmrCrouch.Start()
        End If

        ' The crouching timer updates the stickfigure from an idle animation directly to the crouch pose, and then starts the crouch idle animation and stops the tmrCrouch.

        ' If the player is crouching at any time and goes directly to running AND crouching, he will immediatly stop crouching and start running right.
        ' If the player is crouching at any time ang goes directly to running ONLY, he will immediatly stop crouching and start running right.

        ' When a player stops crouching, the p#StopCrouching method is called, which instantly returns a player to the idle state AND starts the idle animation. If they jump, run, etc., it won't even be noticable.
    End Sub

    Private Sub p2Crouch()
        If p2IsOnGround = False Then
            Exit Sub
        End If

        If p2IsCrouching Then
            Exit Sub
        End If

        If p2tmrCrouch.Enabled = False Then
            intPlayer2StartCrouchTick = 0
            p2Sprite.StopMoving()
            p2UpperLeftY = p2Sprite.UpperLeft.Y
            p2tmrCrouch.Start()
        End If

    End Sub

    Private Sub p1tmrCrouch_Tick(sender As Object, e As EventArgs) Handles p1tmrCrouch.Tick
        ' The bullets are 13 pixels underneath the UpperLeft.Y of each player.
        ' Therefore, the crouch should be... at least 14 pixels moving downwards from the original UpperLeft.
        ' 15 pixels sounds about good.

        ' Each tick, set the... \/
        ' Shootpoint, upperleft.y
        Select Case intPlayer1StartCrouchTick
            Case 0
                p1IsCrouching = True
                intPlayer1StartCrouchTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch1)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch1)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 1
            Case 1
                intPlayer1StartCrouchTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch2)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch2)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 4
            Case 2
                intPlayer1StartCrouchTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch3)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch3)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 6
            Case 3
                intPlayer1StartCrouchTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch4)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch4)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 9
            Case 4
                intPlayer1StartCrouchTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch5)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch5)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 13
            Case 5
                intPlayer1StartCrouchTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch6)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch6)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                End If
                blnP1CanBeHit = False
                p1Sprite.UpperLeft.Y = p1UpperLeftY + 15
            Case 6
                intPlayer1StartCrouchTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch7)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 12
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch7)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 12
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 18
            Case 7
                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch8)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 12
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch8)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 12
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 20
                p1tmrCrouch.Stop()

                ' tmrCrouchIdle.Start() determine if right or left copy code
        End Select
    End Sub

    Private Sub p1StandUp()
        p1tmrCrouch.Stop()
        p1tmrStandUp.Start()
        p1tmrLeftIdle.Stop()
        p1LeftIdleFrame = 1
    End Sub

    Private Sub p2StandUp()
        p2tmrCrouch.Stop()
        p2tmrStandUp.Start()
        p2tmrLeftIdle.Stop()
        p2LeftIdleFrame = 1
    End Sub

    Private Sub p1tmrStandUp_Tick(sender As Object, e As EventArgs) Handles p1tmrStandUp.Tick
        p1tmrLeftIdle.Stop()
        p1tmrRightIdle.Stop()
        Select Case intPlayer1StartCrouchTick
            Case 0
                intPlayer1StandUpTick = 8
                intPlayer1StartCrouchTick = 9
            Case 1
                intPlayer1StandUpTick = 7
                intPlayer1StartCrouchTick = 9
            Case 2
                intPlayer1StandUpTick = 6
                intPlayer1StartCrouchTick = 9
            Case 3
                intPlayer1StandUpTick = 5
                intPlayer1StartCrouchTick = 9
            Case 4
                intPlayer1StandUpTick = 4
                intPlayer1StartCrouchTick = 9
            Case 5
                intPlayer1StandUpTick = 3
                intPlayer1StartCrouchTick = 9
            Case 6
                intPlayer1StandUpTick = 2
                intPlayer1StartCrouchTick = 9
            Case 7
                intPlayer1StandUpTick = 1
                intPlayer1StartCrouchTick = 9
        End Select

        Select Case intPlayer1StandUpTick
            Case 0
                intPlayer1StandUpTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch8)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 12
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch8)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 12
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 20
            Case 1
                intPlayer1StandUpTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch7)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 12
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch7)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 12
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 18
            Case 2
                intPlayer1StandUpTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch6)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch6)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 15
                blnP1CanBeHit = True
            Case 3
                intPlayer1StandUpTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch5)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch5)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 13
            Case 4
                intPlayer1StandUpTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch4)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch4)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 9
            Case 5
                intPlayer1StandUpTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch3)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch3)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 6
            Case 6
                intPlayer1StandUpTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch2)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch2)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 13
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 4
            Case 7

                intPlayer1StandUpTick += 1

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightCrouch1)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + p1Sprite.Size.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftCrouch1)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 14
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY + 1
            Case 8
                intPlayer1StandUpTick = 0

                If p1Dir = "Right" Then
                    p1Sprite.SetImageResource(My.Resources.redRightIdle1)

                    p1tmrRightIdle.Start()
                Else
                    p1Sprite.SetImageResource(My.Resources.redLeftIdle1)
                    p1ShootPoint.X = p1Sprite.UpperLeft.X + 32
                    p1ShootPoint.Y = p1Sprite.UpperLeft.Y + 10
                    p1tmrLeftIdle.Start()
                End If

                p1Sprite.UpperLeft.Y = p1UpperLeftY
                p1UpperLeftY = 0

                p1IsCrouching = False
                intPlayer1StartCrouchTick = 0
                p1tmrStandUp.Stop()
        End Select
    End Sub

    Private Sub HeadToLauncher()
        RandomSplash()

        intSound += 1
        With sound
            .Name = "sound" & intSound
            .Play(8, True, musicVolume)
        End With

        pbLogo.Show()
        picPlaySprite.IsAlive = True
        picHTPSprite.IsAlive = True
        picOptionsSprite.IsAlive = True
        picArcadeSprite.IsAlive = True

        InitializeLauncherBkgd()
        InitializeCursor()
        InitializeCursorShots(0)
        InitializeButtons()
        bkgdForLauncher.Show()

        shootDelayIsActive = True
        tmrShootDelay.Start()
        LauncherTimer.Start()
        tmrSplashPulse.Start()
        tmrCursorIdleRight.Start()
        tmrLoadGame.Stop()
        cursorSprite.UpperLeft.Y = 220
        Invalidate()
    End Sub

    Private Sub p2tmrCrouch_Tick(sender As Object, e As EventArgs) Handles p2tmrCrouch.Tick
        Select Case intPlayer2StartCrouchTick
            Case 0
                p2IsCrouching = True
                intPlayer2StartCrouchTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch1)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch1)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 1
            Case 1
                intPlayer2StartCrouchTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch2)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch2)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 4
            Case 2
                intPlayer2StartCrouchTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch3)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch3)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 6
            Case 3
                intPlayer2StartCrouchTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch4)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch4)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 9
            Case 4
                intPlayer2StartCrouchTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch5)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch5)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 13
            Case 5
                intPlayer2StartCrouchTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch6)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch6)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                End If
                blnP2CanBeHit = False
                p2Sprite.UpperLeft.Y = p2UpperLeftY + 15
            Case 6
                intPlayer2StartCrouchTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch7)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 12
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch7)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 12
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 18
            Case 7
                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch8)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 12
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch8)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 12
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 20
                p2tmrCrouch.Stop()

                ' tmrCrouchIdle.Start() determine if right or left copy code
        End Select
    End Sub

    Private Sub p2tmrStandUp_Tick(sender As Object, e As EventArgs) Handles p2tmrStandUp.Tick
        p2tmrLeftIdle.Stop()
        p2tmrRightIdle.Stop()
        Select Case intPlayer2StartCrouchTick
            Case 0
                intPlayer2StandUpTick = 8
                intPlayer2StartCrouchTick = 9
            Case 1
                intPlayer2StandUpTick = 7
                intPlayer2StartCrouchTick = 9
            Case 2
                intPlayer2StandUpTick = 6
                intPlayer2StartCrouchTick = 9
            Case 3
                intPlayer2StandUpTick = 5
                intPlayer2StartCrouchTick = 9
            Case 4
                intPlayer2StandUpTick = 4
                intPlayer2StartCrouchTick = 9
            Case 5
                intPlayer2StandUpTick = 3
                intPlayer2StartCrouchTick = 9
            Case 6
                intPlayer2StandUpTick = 2
                intPlayer2StartCrouchTick = 9
            Case 7
                intPlayer2StandUpTick = 1
                intPlayer2StartCrouchTick = 9
        End Select

        Select Case intPlayer2StandUpTick
            Case 0
                intPlayer2StandUpTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch8)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 12
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch8)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 12
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 20
            Case 1
                intPlayer2StandUpTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch7)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 12
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch7)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 12
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 18
            Case 2
                intPlayer2StandUpTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch6)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch6)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                End If
                blnP2CanBeHit = True
                p2Sprite.UpperLeft.Y = p2UpperLeftY + 15
            Case 3
                intPlayer2StandUpTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch5)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch5)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 13
            Case 4
                intPlayer2StandUpTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch4)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch4)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 9
            Case 5
                intPlayer2StandUpTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch3)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch3)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 6
            Case 6
                intPlayer2StandUpTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch2)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch2)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 13
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 4
            Case 7

                intPlayer2StandUpTick += 1

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightCrouch1)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + p2Sprite.Size.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftCrouch1)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 14
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY + 1
            Case 8
                intPlayer2StandUpTick = 0

                If p2Dir = "Right" Then
                    p2Sprite.SetImageResource(My.Resources.blueRightIdle1)

                    p2tmrRightIdle.Start()
                Else
                    p2Sprite.SetImageResource(My.Resources.blueLeftIdle1)
                    p2ShootPoint.X = p2Sprite.UpperLeft.X + 32
                    p2ShootPoint.Y = p2Sprite.UpperLeft.Y + 10
                    p2tmrLeftIdle.Start()
                End If

                p2Sprite.UpperLeft.Y = p2UpperLeftY
                p2UpperLeftY = 0

                p2IsCrouching = False
                intPlayer2StartCrouchTick = 0
                p2tmrStandUp.Stop()
        End Select
    End Sub

    Private Sub tmrBobPowerUps_Tick(sender As Object, e As EventArgs) Handles tmrBobPowerUps.Tick
        Select Case intBobPowerUpsTick
            Case 0 ' go down
                For Each pup In powerUpsAlive
                    pup.UpperLeft.Y += 1
                Next
                intBobPowerUpsTick += 1
            Case 1 ' go down
                For Each pup In powerUpsAlive
                    pup.UpperLeft.Y += 1
                Next
                intBobPowerUpsTick += 1
            Case 2 ' go down
                For Each pup In powerUpsAlive
                    pup.UpperLeft.Y += 1
                Next
                intBobPowerUpsTick += 1
            Case 3 ' go down
                For Each pup In powerUpsAlive
                    pup.UpperLeft.Y += 1
                Next
                intBobPowerUpsTick += 1
            Case 4 ' stay
                ' do nothing, stay
                intBobPowerUpsTick += 1
            Case 5 ' go up
                For Each pup In powerUpsAlive
                    pup.UpperLeft.Y -= 1
                Next
                intBobPowerUpsTick += 1
            Case 6 ' go up
                For Each pup In powerUpsAlive
                    pup.UpperLeft.Y -= 1
                Next
                intBobPowerUpsTick += 1
            Case 7 ' go up
                For Each pup In powerUpsAlive
                    pup.UpperLeft.Y -= 1
                Next
                intBobPowerUpsTick += 1
            Case 8 ' go up
                For Each pup In powerUpsAlive
                    pup.UpperLeft.Y -= 1
                Next
                intBobPowerUpsTick += 1
            Case 9 'stay, then reset to 0
                ' do nothing, stay
                intBobPowerUpsTick = 0
        End Select
    End Sub

    Private Sub ShowVictoryScreen()
        shootDelayIsActive = True
        tmrShootDelay.Start()
        strHeadingToMenuText = ""
        intReturnToMenuTick = 0
        Select Case strWinner
            Case "RED"
                winnerTextSprite.SetImageResource(My.Resources.picRedWins)
                trophySprite.SetImageResource(My.Resources.redTrophy)
                trophySprite.IsAlive = True
                winnerTextSprite.IsAlive = True
            Case "BLUE"
                winnerTextSprite.SetImageResource(My.Resources.picBlueWins)
                trophySprite.SetImageResource(My.Resources.blueTrophy)
                trophySprite.IsAlive = True
                winnerTextSprite.IsAlive = True
            Case "BOTH"
                winnerTextSprite.SetImageResource(My.Resources.picBothWin)
                trophySprite.SetImageResource(My.Resources.bothTrophy)
                trophySprite.IsAlive = True
                winnerTextSprite.IsAlive = True
        End Select
        strOptionButtonShot = ""
        strOptionsDirection = ""
        strCurrentMenu = "GAME"
        strButtonDirection = ""
        strButtonShot = ""
        bkgdForLauncher.Show()
        launcherBkgdSprite.IsAlive = True
        cursorSprite.UpperLeft.X = 350
        cursorSprite.UpperLeft.Y = 383
        playAgainSprite.IsAlive = True
        yesSprite.IsAlive = True
        noSprite.IsAlive = True


        cursorSprite.SetImageResource(My.Resources.orangeRightCursorIdle1)
        cursorSprite.IsAlive = True
        tmrCursorIdleRight.Start()
        LauncherTimer.Start()
        tmrReturnToMenu.Start()
    End Sub

    Private Sub tmrMoveVictoryButtons_Tick(sender As Object, e As EventArgs) Handles tmrMoveVictoryButtons.Tick
        Select Case intMoveVictoryButtonsTick
            Case 0
                ' Do nothing, let that splat sound sink in and be meaningful. Just...pause. How dramatic.
                intMoveVictoryButtonsTick += 1
            Case 1 'start moving
                tmrMoveVictoryButtons.Interval = 250
                intMoveVictoryButtonsTick += 1
                blnYesCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With
            Case 2
                intMoveVictoryButtonsTick = 0
                blnNoCanMove = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(16, False, sfxVolume)
                End With
                tmrMoveVictoryButtons.Stop()
        End Select
    End Sub

    Private Sub HideVictoryScreen()
        playAgainSprite.IsAlive = False
        winnerTextSprite.IsAlive = False
        cursorSprite.IsAlive = False
        trophySprite.IsAlive = False
        bkgdForLauncher.Hide()
        yesSprite.UpperLeft.X = 547
        noSprite.UpperLeft.X = 547
        cursorRightIdleFrame = 1
        tmrCursorIdleRight.Stop()
        tmrReturnToMenu.Stop()
        strVictoryButtonShot = ""
        strWinner = ""
        HaltSound()
        blnCursorHasShot = False
    End Sub

    Private Sub tmrReturnToMenu_Tick(sender As Object, e As EventArgs) Handles tmrReturnToMenu.Tick
        Select Case intReturnToMenuTick
            Case 0
                intReturnToMenuTick += 1
                blnCursorHasShot = False
            Case 1
                intReturnToMenuTick += 1
            Case 2
                intReturnToMenuTick += 1
            Case 3
                intReturnToMenuTick += 1
                strHeadingToMenuText = "Heading to main menu in 10..."
            Case 4
                intReturnToMenuTick += 1
                strHeadingToMenuText = "Heading to main menu in 9..."
            Case 5
                intReturnToMenuTick += 1
                strHeadingToMenuText = "Heading to main menu in 8..."
            Case 6
                intReturnToMenuTick += 1
                strHeadingToMenuText = "Heading to main menu in 7..."
            Case 7
                intReturnToMenuTick += 1
                strHeadingToMenuText = "Heading to main menu in 6..."
            Case 8
                intReturnToMenuTick += 1
                strHeadingToMenuText = "Heading to main menu in 5..."
            Case 9
                intReturnToMenuTick += 1
                strHeadingToMenuText = "Heading to main menu in 4..."
            Case 10
                intReturnToMenuTick += 1
                strHeadingToMenuText = "Heading to main menu in 3..."
            Case 11
                intReturnToMenuTick += 1
                strHeadingToMenuText = "Heading to main menu in 2..."
            Case 12
                intReturnToMenuTick += 1
                strHeadingToMenuText = "Heading to main menu in 1..."
            Case 13
                For Each shot In cursorShots
                    If shot.IsAlive = True Then
                        shot.IsAlive = False
                    End If
                Next
                intReturnToMenuTick = 0
                strHeadingToMenuText = "Heading to main menu..."
                shootDelayIsActive = True
                blnCursorHasShot = True
                strVictoryButtonShot = "NO"
                MoveVictoryButtonsRight()
        End Select
    End Sub

    Private Sub bkgdForLauncher_MouseHover(sender As Object, e As EventArgs) Handles bkgdForLauncher.MouseHover
        Cursor.Hide()
    End Sub

    Private Sub tmrShootDelay_Tick(sender As Object, e As EventArgs) Handles tmrShootDelay.Tick
        shootDelayIsActive = False
        tmrShootDelay.Stop()
    End Sub

    Private Sub SpeedGameUp()
        Select Case charGameState
            Case "F" ' check if already fast
                ReturnGameToNormalSpeed("F")
            Case "S" ' check if slow
                ReturnGameToNormalSpeed("S")
        End Select

        GameIsSpedUp = True
        GameIsSlowedDown = False

        GameTimer.Interval = 8
        p1tmrJump.Interval = 2
        p2tmrJump.Interval = 2
        p1tmrFall.Interval = 2
        p2tmrFall.Interval = 2
        p1tmrRightIdle.Interval = 42
        p1tmrLeftIdle.Interval = 42
        p2tmrRightIdle.Interval = 42
        p2tmrLeftIdle.Interval = 42
        p1tmrRightRun.Interval = 17
        p1tmrLeftRun.Interval = 17
        p2tmrRightRun.Interval = 17
        p2tmrLeftRun.Interval = 17
        p1tmrCrouch.Interval = 17
        p1tmrStandUp.Interval = 17
        p2tmrCrouch.Interval = 17
        p2tmrStandUp.Interval = 17

        charGameState = "F"

        tmrSpeedUp.Start()
        picGameSpeed.Image = My.Resources.powerup_speedup

        ' Play speed up sound effect.
    End Sub

    Private Sub SlowGameDown()
        Select Case charGameState
            Case "F" ' check if fast
                ReturnGameToNormalSpeed("F")
            Case "S" ' check if already slow
                ReturnGameToNormalSpeed("S")
        End Select

        GameIsSpedUp = False
        GameIsSlowedDown = True

        GameTimer.Interval = 32
        p1tmrJump.Interval = 10
        p2tmrJump.Interval = 10
        p1tmrFall.Interval = 10
        p2tmrFall.Interval = 10
        p1tmrRightIdle.Interval = 170
        p1tmrLeftIdle.Interval = 170
        p2tmrRightIdle.Interval = 170
        p2tmrLeftIdle.Interval = 170
        p1tmrRightRun.Interval = 70
        p1tmrLeftRun.Interval = 70
        p2tmrRightRun.Interval = 70
        p2tmrLeftRun.Interval = 70
        p1tmrCrouch.Interval = 70
        p1tmrStandUp.Interval = 70
        p2tmrCrouch.Interval = 70
        p2tmrStandUp.Interval = 70

        charGameState = "S"

        tmrSlowDown.Start()
        picGameSpeed.Image = My.Resources.powerup_slowdown

        ' Play slowed down sound effect.
    End Sub

    Private Sub ReturnGameToNormalSpeed(ByRef state As Char)
        Select Case state
            Case "F"
                tmrSpeedUp.Stop()
            Case "S"
                tmrSlowDown.Stop()
            Case "E" ' Game ending.
                ' Do nothing, the game is resetting to the correct intervals below.
        End Select

        GameTimer.Interval = 16
        p1tmrJump.Interval = 5
        p2tmrJump.Interval = 5
        p1tmrFall.Interval = 5
        p2tmrFall.Interval = 5
        p1tmrRightIdle.Interval = 85
        p1tmrLeftIdle.Interval = 85
        p2tmrRightIdle.Interval = 85
        p2tmrLeftIdle.Interval = 85
        p1tmrRightRun.Interval = 35
        p1tmrLeftRun.Interval = 35
        p2tmrRightRun.Interval = 35
        p2tmrLeftRun.Interval = 35
        p1tmrCrouch.Interval = 35
        p1tmrStandUp.Interval = 35
        p2tmrCrouch.Interval = 35
        p2tmrStandUp.Interval = 35

        picGameSpeed.Image = Nothing

        charGameState = "N"
    End Sub

    Private Sub ShieldPlayer1()
        ' check if tripled
        If p1IsTripled Then
            p1TripleShot.Stop()
            p1IsTripled = False
            picPlayer1ActivePUP.Image = Nothing
        End If
        ' check if already shielded
        If p1IsShielded Then
            p1Shield.Stop()
        End If

        p1IsShielded = True
        picPlayer1ActivePUP.Image = My.Resources.powerup_shield
        p1Shield.Start()
    End Sub

    Private Sub ShieldPlayer2()
        ' check if tripled
        If p2IsTripled Then
            p2TripleShot.Stop()
            p2IsTripled = False
            picPlayer2ActivePUP.Image = Nothing
        End If
        ' check if already shielded
        If p2IsShielded Then
            p2Shield.Stop()
        End If

        p2IsShielded = True
        picPlayer2ActivePUP.Image = My.Resources.powerup_shield
        p2Shield.Start()
    End Sub

    Private Sub TriplePlayer1()
        ' check if already tripled
        If p1IsTripled Then
            p1TripleShot.Stop()
            p1IsShielded = False
            p1IsTripled = True
            p1TripleShot.Start()
        ElseIf p1IsShielded Then ' check if shielded
            p1Shield.Stop()
            p1IsShielded = False
            p1IsTripled = True
            picPlayer1ActivePUP.Image = My.Resources.powerup_triple
            p1TripleShot.Start()
        Else
            p1IsTripled = True
            picPlayer1ActivePUP.Image = My.Resources.powerup_triple
            p1TripleShot.Start()
        End If
    End Sub

    Private Sub TriplePlayer2()
        ' check if already tripled
        If p2IsTripled Then
            p2TripleShot.Stop()
            p2IsShielded = False
            p2IsTripled = True
            p2TripleShot.Start()
        ElseIf p2IsShielded Then ' check if shielded
            p2Shield.Stop()
            p2IsShielded = False
            p2IsTripled = True
            picPlayer2ActivePUP.Image = My.Resources.powerup_triple
            p2TripleShot.Start()
        Else
            p2IsTripled = True
            picPlayer2ActivePUP.Image = My.Resources.powerup_triple
            p2TripleShot.Start()
        End If
    End Sub

    Private Sub ShowHTPScreen()
        tmrShowHTP.Start()
    End Sub

    Private Sub tmrShowHTP_Tick(sender As Object, e As EventArgs) Handles tmrShowHTP.Tick
        Select Case intShowHTPTick
            Case 0
                ' Do nothing. Wait.
                intShowHTPTick += 1
                tmrShowHTP.Interval = 750
            Case 1
                ' Start showing the stuff.
                htpShoot.IsAlive = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With
                intShowHTPTick += 1
            Case 2
                htpMove.IsAlive = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(1, False, sfxVolume)
                End With
                intShowHTPTick += 1
                tmrShowHTP.Interval = 3000
            Case 3
                tmrShowHTP.Interval = 350
                htpRun.IsAlive = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(12, False, sfxVolume)
                End With
                intShowHTPTick += 1
            Case 4
                htpJump.IsAlive = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(12, False, sfxVolume)
                End With
                intShowHTPTick += 1
            Case 5
                htpTime.IsAlive = True
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(12, False, sfxVolume)
                End With
                intShowHTPTick += 1
            Case 6
                ' wait 3 seconds and then start hiding stuff
                intShowHTPTick += 1
            Case 7
                intShowHTPTick += 1
            Case 8
                intShowHTPTick += 1
            Case 9
                intShowHTPTick += 1
            Case 10
                intShowHTPTick += 1
                tmrShowHTP.Interval = 5500
            Case 11
                tmrShowHTP.Interval = 250
                intShowHTPTick += 1
                htpTime.IsAlive = False
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(12, False, sfxVolume)
                End With
            Case 12
                intShowHTPTick += 1
                htpJump.IsAlive = False
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(12, False, sfxVolume)
                End With
            Case 13
                intShowHTPTick += 1
                htpRun.IsAlive = False
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(12, False, sfxVolume)
                End With
            Case 14
                intShowHTPTick += 1
                htpMove.IsAlive = False
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(12, False, sfxVolume)
                End With
            Case 15
                intShowHTPTick += 1
                htpShoot.IsAlive = False
                intSound += 1
                With sound
                    .Name = "sound" & intSound
                    .Play(12, False, sfxVolume)
                End With
            Case 16
                intShowHTPTick = 0
                MoveMMButtonsRight()
                tmrShowHTP.Interval = 750
                tmrShowHTP.Stop()
        End Select
    End Sub
End Class