<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGameScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGameScreen))
        Me.GameTimer = New System.Windows.Forms.Timer(Me.components)
        Me.p1HealthBar = New System.Windows.Forms.ProgressBar()
        Me.p2HealthBar = New System.Windows.Forms.ProgressBar()
        Me.p1HealthIs = New System.Windows.Forms.Label()
        Me.p2HealthIs = New System.Windows.Forms.Label()
        Me.p1tmrJump = New System.Windows.Forms.Timer(Me.components)
        Me.p2tmrJump = New System.Windows.Forms.Timer(Me.components)
        Me.p1tmrFall = New System.Windows.Forms.Timer(Me.components)
        Me.lblPlayer1Ammo = New System.Windows.Forms.Label()
        Me.lblPlayer2Ammo = New System.Windows.Forms.Label()
        Me.tmrRandomizePowerUps = New System.Windows.Forms.Timer(Me.components)
        Me.p1tmrRightIdle = New System.Windows.Forms.Timer(Me.components)
        Me.p1tmrLeftIdle = New System.Windows.Forms.Timer(Me.components)
        Me.p2tmrRightIdle = New System.Windows.Forms.Timer(Me.components)
        Me.p2tmrLeftIdle = New System.Windows.Forms.Timer(Me.components)
        Me.p1tmrRightRun = New System.Windows.Forms.Timer(Me.components)
        Me.p1tmrLeftRun = New System.Windows.Forms.Timer(Me.components)
        Me.p2tmrRightRun = New System.Windows.Forms.Timer(Me.components)
        Me.p2tmrLeftRun = New System.Windows.Forms.Timer(Me.components)
        Me.p1TripleShot = New System.Windows.Forms.Timer(Me.components)
        Me.p2TripleShot = New System.Windows.Forms.Timer(Me.components)
        Me.p2tmrFall = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSlowDown = New System.Windows.Forms.Timer(Me.components)
        Me.p1Shield = New System.Windows.Forms.Timer(Me.components)
        Me.p2Shield = New System.Windows.Forms.Timer(Me.components)
        Me.picPlayer2ActivePUP = New System.Windows.Forms.PictureBox()
        Me.picPlayer1ActivePUP = New System.Windows.Forms.PictureBox()
        Me.picLoadingStickfigure = New System.Windows.Forms.PictureBox()
        Me.pbLoading = New System.Windows.Forms.ProgressBar()
        Me.tmrLoadGame = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSplashPulse = New System.Windows.Forms.Timer(Me.components)
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.bkgdForLauncher = New System.Windows.Forms.PictureBox()
        Me.tmrCursorIdleRight = New System.Windows.Forms.Timer(Me.components)
        Me.LauncherTimer = New System.Windows.Forms.Timer(Me.components)
        Me.tmrMoveMMButtonsLeft = New System.Windows.Forms.Timer(Me.components)
        Me.tmrMoveMMButtonsRight = New System.Windows.Forms.Timer(Me.components)
        Me.tmrGetReady = New System.Windows.Forms.Timer(Me.components)
        Me.tmrFadeToArcade = New System.Windows.Forms.Timer(Me.components)
        Me.tmrMoveOptionsButtonsLeft = New System.Windows.Forms.Timer(Me.components)
        Me.tmrCursorIdleLeft = New System.Windows.Forms.Timer(Me.components)
        Me.tmrMoveOptionsButtonsRight = New System.Windows.Forms.Timer(Me.components)
        Me.tmrHideOptionsText = New System.Windows.Forms.Timer(Me.components)
        Me.tmrGameTimeLeft = New System.Windows.Forms.Timer(Me.components)
        Me.p1tmrCrouch = New System.Windows.Forms.Timer(Me.components)
        Me.p2tmrCrouch = New System.Windows.Forms.Timer(Me.components)
        Me.p1tmrStandUp = New System.Windows.Forms.Timer(Me.components)
        Me.p2tmrStandUp = New System.Windows.Forms.Timer(Me.components)
        Me.tmrBobPowerUps = New System.Windows.Forms.Timer(Me.components)
        Me.tmrMoveVictoryButtons = New System.Windows.Forms.Timer(Me.components)
        Me.tmrReturnToMenu = New System.Windows.Forms.Timer(Me.components)
        Me.tmrShootDelay = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSpeedUp = New System.Windows.Forms.Timer(Me.components)
        Me.picGameSpeed = New System.Windows.Forms.PictureBox()
        Me.tmrShowHTP = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picPlayer2ActivePUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlayer1ActivePUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLoadingStickfigure, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bkgdForLauncher, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picGameSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GameTimer
        '
        Me.GameTimer.Interval = 16
        '
        'p1HealthBar
        '
        Me.p1HealthBar.BackColor = System.Drawing.Color.Black
        Me.p1HealthBar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.p1HealthBar.Location = New System.Drawing.Point(17, 529)
        Me.p1HealthBar.Name = "p1HealthBar"
        Me.p1HealthBar.Size = New System.Drawing.Size(200, 20)
        Me.p1HealthBar.Step = 1
        Me.p1HealthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.p1HealthBar.TabIndex = 1
        Me.p1HealthBar.Value = 100
        Me.p1HealthBar.Visible = False
        '
        'p2HealthBar
        '
        Me.p2HealthBar.BackColor = System.Drawing.Color.Black
        Me.p2HealthBar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.p2HealthBar.Location = New System.Drawing.Point(552, 529)
        Me.p2HealthBar.Name = "p2HealthBar"
        Me.p2HealthBar.Size = New System.Drawing.Size(200, 20)
        Me.p2HealthBar.Step = 1
        Me.p2HealthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.p2HealthBar.TabIndex = 2
        Me.p2HealthBar.Value = 100
        Me.p2HealthBar.Visible = False
        '
        'p1HealthIs
        '
        Me.p1HealthIs.BackColor = System.Drawing.Color.Transparent
        Me.p1HealthIs.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.p1HealthIs.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.p1HealthIs.Location = New System.Drawing.Point(17, 500)
        Me.p1HealthIs.Name = "p1HealthIs"
        Me.p1HealthIs.Size = New System.Drawing.Size(200, 26)
        Me.p1HealthIs.TabIndex = 3
        Me.p1HealthIs.Text = "HP"
        Me.p1HealthIs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.p1HealthIs.Visible = False
        '
        'p2HealthIs
        '
        Me.p2HealthIs.BackColor = System.Drawing.Color.Transparent
        Me.p2HealthIs.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.p2HealthIs.ForeColor = System.Drawing.Color.DodgerBlue
        Me.p2HealthIs.Location = New System.Drawing.Point(554, 500)
        Me.p2HealthIs.Name = "p2HealthIs"
        Me.p2HealthIs.Size = New System.Drawing.Size(200, 26)
        Me.p2HealthIs.TabIndex = 4
        Me.p2HealthIs.Text = "HP"
        Me.p2HealthIs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.p2HealthIs.Visible = False
        '
        'p1tmrJump
        '
        Me.p1tmrJump.Interval = 5
        '
        'p2tmrJump
        '
        Me.p2tmrJump.Interval = 5
        '
        'p1tmrFall
        '
        Me.p1tmrFall.Interval = 5
        '
        'lblPlayer1Ammo
        '
        Me.lblPlayer1Ammo.BackColor = System.Drawing.Color.Transparent
        Me.lblPlayer1Ammo.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblPlayer1Ammo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblPlayer1Ammo.Location = New System.Drawing.Point(17, 552)
        Me.lblPlayer1Ammo.Name = "lblPlayer1Ammo"
        Me.lblPlayer1Ammo.Size = New System.Drawing.Size(200, 24)
        Me.lblPlayer1Ammo.TabIndex = 8
        Me.lblPlayer1Ammo.Text = "AMMO: 50"
        Me.lblPlayer1Ammo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayer1Ammo.Visible = False
        '
        'lblPlayer2Ammo
        '
        Me.lblPlayer2Ammo.BackColor = System.Drawing.Color.Transparent
        Me.lblPlayer2Ammo.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblPlayer2Ammo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblPlayer2Ammo.Location = New System.Drawing.Point(554, 552)
        Me.lblPlayer2Ammo.Name = "lblPlayer2Ammo"
        Me.lblPlayer2Ammo.Size = New System.Drawing.Size(200, 22)
        Me.lblPlayer2Ammo.TabIndex = 9
        Me.lblPlayer2Ammo.Text = "AMMO: 50"
        Me.lblPlayer2Ammo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPlayer2Ammo.Visible = False
        '
        'tmrRandomizePowerUps
        '
        Me.tmrRandomizePowerUps.Interval = 7000
        '
        'p1tmrRightIdle
        '
        Me.p1tmrRightIdle.Interval = 85
        '
        'p1tmrLeftIdle
        '
        Me.p1tmrLeftIdle.Interval = 85
        '
        'p2tmrRightIdle
        '
        Me.p2tmrRightIdle.Interval = 85
        '
        'p2tmrLeftIdle
        '
        Me.p2tmrLeftIdle.Interval = 85
        '
        'p1tmrRightRun
        '
        Me.p1tmrRightRun.Interval = 35
        '
        'p1tmrLeftRun
        '
        Me.p1tmrLeftRun.Interval = 35
        '
        'p2tmrRightRun
        '
        Me.p2tmrRightRun.Interval = 35
        '
        'p2tmrLeftRun
        '
        Me.p2tmrLeftRun.Interval = 35
        '
        'p1TripleShot
        '
        Me.p1TripleShot.Interval = 5000
        '
        'p2TripleShot
        '
        Me.p2TripleShot.Interval = 5000
        '
        'p2tmrFall
        '
        Me.p2tmrFall.Interval = 5
        '
        'tmrSlowDown
        '
        Me.tmrSlowDown.Interval = 5000
        '
        'p1Shield
        '
        Me.p1Shield.Interval = 5000
        '
        'p2Shield
        '
        Me.p2Shield.Interval = 5000
        '
        'picPlayer2ActivePUP
        '
        Me.picPlayer2ActivePUP.BackColor = System.Drawing.Color.Transparent
        Me.picPlayer2ActivePUP.Location = New System.Drawing.Point(758, 526)
        Me.picPlayer2ActivePUP.Name = "picPlayer2ActivePUP"
        Me.picPlayer2ActivePUP.Size = New System.Drawing.Size(25, 25)
        Me.picPlayer2ActivePUP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPlayer2ActivePUP.TabIndex = 13
        Me.picPlayer2ActivePUP.TabStop = False
        Me.picPlayer2ActivePUP.Visible = False
        '
        'picPlayer1ActivePUP
        '
        Me.picPlayer1ActivePUP.BackColor = System.Drawing.Color.Transparent
        Me.picPlayer1ActivePUP.Location = New System.Drawing.Point(223, 526)
        Me.picPlayer1ActivePUP.Name = "picPlayer1ActivePUP"
        Me.picPlayer1ActivePUP.Size = New System.Drawing.Size(25, 25)
        Me.picPlayer1ActivePUP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPlayer1ActivePUP.TabIndex = 10
        Me.picPlayer1ActivePUP.TabStop = False
        Me.picPlayer1ActivePUP.Visible = False
        '
        'picLoadingStickfigure
        '
        Me.picLoadingStickfigure.BackColor = System.Drawing.Color.Transparent
        Me.picLoadingStickfigure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picLoadingStickfigure.Location = New System.Drawing.Point(254, 33)
        Me.picLoadingStickfigure.Name = "picLoadingStickfigure"
        Me.picLoadingStickfigure.Size = New System.Drawing.Size(285, 445)
        Me.picLoadingStickfigure.TabIndex = 16
        Me.picLoadingStickfigure.TabStop = False
        '
        'pbLoading
        '
        Me.pbLoading.BackColor = System.Drawing.Color.Black
        Me.pbLoading.ForeColor = System.Drawing.Color.Green
        Me.pbLoading.Location = New System.Drawing.Point(43, 500)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(711, 26)
        Me.pbLoading.Step = 1
        Me.pbLoading.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.pbLoading.TabIndex = 17
        '
        'tmrLoadGame
        '
        Me.tmrLoadGame.Interval = 800
        '
        'tmrSplashPulse
        '
        Me.tmrSplashPulse.Enabled = True
        Me.tmrSplashPulse.Interval = 62
        '
        'pbLogo
        '
        Me.pbLogo.BackColor = System.Drawing.Color.Transparent
        Me.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbLogo.Image = Global.Paintball.My.Resources.Resources.newPBLogo
        Me.pbLogo.Location = New System.Drawing.Point(0, 0)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(800, 200)
        Me.pbLogo.TabIndex = 18
        Me.pbLogo.TabStop = False
        Me.pbLogo.Visible = False
        '
        'bkgdForLauncher
        '
        Me.bkgdForLauncher.BackColor = System.Drawing.Color.Transparent
        Me.bkgdForLauncher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.bkgdForLauncher.Location = New System.Drawing.Point(0, 0)
        Me.bkgdForLauncher.Name = "bkgdForLauncher"
        Me.bkgdForLauncher.Size = New System.Drawing.Size(800, 600)
        Me.bkgdForLauncher.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.bkgdForLauncher.TabIndex = 19
        Me.bkgdForLauncher.TabStop = False
        Me.bkgdForLauncher.Visible = False
        '
        'tmrCursorIdleRight
        '
        Me.tmrCursorIdleRight.Interval = 85
        '
        'LauncherTimer
        '
        Me.LauncherTimer.Interval = 16
        '
        'tmrMoveMMButtonsLeft
        '
        Me.tmrMoveMMButtonsLeft.Interval = 300
        '
        'tmrMoveMMButtonsRight
        '
        Me.tmrMoveMMButtonsRight.Interval = 300
        '
        'tmrGetReady
        '
        Me.tmrGetReady.Interval = 1000
        '
        'tmrFadeToArcade
        '
        Me.tmrFadeToArcade.Interval = 1350
        '
        'tmrMoveOptionsButtonsLeft
        '
        Me.tmrMoveOptionsButtonsLeft.Interval = 300
        '
        'tmrCursorIdleLeft
        '
        Me.tmrCursorIdleLeft.Interval = 85
        '
        'tmrMoveOptionsButtonsRight
        '
        Me.tmrMoveOptionsButtonsRight.Interval = 300
        '
        'tmrHideOptionsText
        '
        Me.tmrHideOptionsText.Interval = 3000
        '
        'tmrGameTimeLeft
        '
        Me.tmrGameTimeLeft.Interval = 1000
        '
        'p1tmrCrouch
        '
        Me.p1tmrCrouch.Interval = 35
        '
        'p2tmrCrouch
        '
        Me.p2tmrCrouch.Interval = 35
        '
        'p1tmrStandUp
        '
        Me.p1tmrStandUp.Interval = 35
        '
        'p2tmrStandUp
        '
        Me.p2tmrStandUp.Interval = 35
        '
        'tmrBobPowerUps
        '
        Me.tmrBobPowerUps.Interval = 90
        '
        'tmrMoveVictoryButtons
        '
        Me.tmrMoveVictoryButtons.Interval = 300
        '
        'tmrReturnToMenu
        '
        Me.tmrReturnToMenu.Interval = 1000
        '
        'tmrShootDelay
        '
        Me.tmrShootDelay.Interval = 500
        '
        'tmrSpeedUp
        '
        Me.tmrSpeedUp.Interval = 5000
        '
        'picGameSpeed
        '
        Me.picGameSpeed.BackColor = System.Drawing.Color.Transparent
        Me.picGameSpeed.Location = New System.Drawing.Point(370, 566)
        Me.picGameSpeed.Name = "picGameSpeed"
        Me.picGameSpeed.Size = New System.Drawing.Size(25, 25)
        Me.picGameSpeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picGameSpeed.TabIndex = 20
        Me.picGameSpeed.TabStop = False
        Me.picGameSpeed.Visible = False
        '
        'tmrShowHTP
        '
        Me.tmrShowHTP.Interval = 750
        '
        'frmGameScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 600)
        Me.Controls.Add(Me.picGameSpeed)
        Me.Controls.Add(Me.p2HealthIs)
        Me.Controls.Add(Me.p1HealthIs)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.pbLoading)
        Me.Controls.Add(Me.picPlayer2ActivePUP)
        Me.Controls.Add(Me.picPlayer1ActivePUP)
        Me.Controls.Add(Me.lblPlayer2Ammo)
        Me.Controls.Add(Me.lblPlayer1Ammo)
        Me.Controls.Add(Me.p1HealthBar)
        Me.Controls.Add(Me.p2HealthBar)
        Me.Controls.Add(Me.bkgdForLauncher)
        Me.Controls.Add(Me.picLoadingStickfigure)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmGameScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paintball!"
        Me.TopMost = True
        CType(Me.picPlayer2ActivePUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlayer1ActivePUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLoadingStickfigure, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bkgdForLauncher, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picGameSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GameTimer As System.Windows.Forms.Timer
    Friend WithEvents p1HealthBar As ProgressBar
    Friend WithEvents p2HealthBar As ProgressBar
    Friend WithEvents p1HealthIs As Label
    Friend WithEvents p2HealthIs As Label
    Friend WithEvents p1tmrJump As Timer
    Friend WithEvents p2tmrJump As Timer
    Friend WithEvents p1tmrFall As Timer
    Friend WithEvents lblPlayer1Ammo As Label
    Friend WithEvents lblPlayer2Ammo As Label
    Friend WithEvents tmrRandomizePowerUps As Timer
    Friend WithEvents p1tmrRightIdle As Timer
    Friend WithEvents p1tmrLeftIdle As Timer
    Friend WithEvents p2tmrRightIdle As Timer
    Friend WithEvents p2tmrLeftIdle As Timer
    Friend WithEvents p1tmrRightRun As Timer
    Friend WithEvents p1tmrLeftRun As Timer
    Friend WithEvents p2tmrRightRun As Timer
    Friend WithEvents p2tmrLeftRun As Timer
    Friend WithEvents p1TripleShot As Timer
    Friend WithEvents picPlayer1ActivePUP As PictureBox
    Friend WithEvents picPlayer2ActivePUP As PictureBox
    Friend WithEvents p2TripleShot As Timer
    Friend WithEvents p2tmrFall As Timer
    Friend WithEvents SpeedUp As Timer
    Friend WithEvents tmrSlowDown As Timer
    Friend WithEvents p1Shield As Timer
    Friend WithEvents p2Shield As Timer
    Friend WithEvents picLoadingStickfigure As PictureBox
    Friend WithEvents pbLoading As ProgressBar
    Friend WithEvents tmrLoadGame As Timer
    Friend WithEvents tmrSplashPulse As Timer
    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents bkgdForLauncher As PictureBox
    Friend WithEvents tmrCursorIdleRight As Timer
    Friend WithEvents LauncherTimer As Timer
    Friend WithEvents tmrMoveMMButtonsLeft As Timer
    Friend WithEvents tmrMoveMMButtonsRight As Timer
    Friend WithEvents tmrGetReady As Timer
    Friend WithEvents tmrFadeToArcade As Timer
    Friend WithEvents tmrMoveOptionsButtonsLeft As Timer
    Friend WithEvents tmrCursorIdleLeft As Timer
    Friend WithEvents tmrMoveOptionsButtonsRight As Timer
    Friend WithEvents tmrHideOptionsText As Timer
    Friend WithEvents tmrGameTimeLeft As Timer
    Friend WithEvents p1tmrCrouch As Timer
    Friend WithEvents p2tmrCrouch As Timer
    Friend WithEvents p1tmrStandUp As Timer
    Friend WithEvents p2tmrStandUp As Timer
    Friend WithEvents tmrBobPowerUps As Timer
    Friend WithEvents tmrMoveVictoryButtons As Timer
    Friend WithEvents tmrReturnToMenu As Timer
    Friend WithEvents tmrShootDelay As Timer
    Friend WithEvents tmrSpeedUp As Timer
    Friend WithEvents picGameSpeed As PictureBox
    Friend WithEvents tmrShowHTP As Timer
End Class
