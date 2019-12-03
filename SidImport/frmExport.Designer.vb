<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBranchName = New System.Windows.Forms.Label()
        Me.lblBranchCode = New System.Windows.Forms.Label()
        Me.txtBranchName = New SidControls.AutoSuggest()
        Me.txtBranchCode = New SidControls.AutoSuggest()
        Me.optBranch = New System.Windows.Forms.RadioButton()
        Me.optRegion = New System.Windows.Forms.RadioButton()
        Me.optZone = New System.Windows.Forms.RadioButton()
        Me.optBank = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AutoSuggest1 = New SidControls.AutoSuggest()
        Me.AutoSuggest2 = New SidControls.AutoSuggest()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(119, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Export"
        '
        'lblBranchName
        '
        Me.lblBranchName.AutoSize = True
        Me.lblBranchName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranchName.Location = New System.Drawing.Point(136, 100)
        Me.lblBranchName.Name = "lblBranchName"
        Me.lblBranchName.Size = New System.Drawing.Size(84, 16)
        Me.lblBranchName.TabIndex = 25
        Me.lblBranchName.Text = "Branch Name"
        '
        'lblBranchCode
        '
        Me.lblBranchCode.AutoSize = True
        Me.lblBranchCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranchCode.Location = New System.Drawing.Point(17, 100)
        Me.lblBranchCode.Name = "lblBranchCode"
        Me.lblBranchCode.Size = New System.Drawing.Size(80, 16)
        Me.lblBranchCode.TabIndex = 24
        Me.lblBranchCode.Text = "Branch Code"
        '
        'txtBranchName
        '
        Me.txtBranchName.BackColorDisabled = System.Drawing.SystemColors.Window
        Me.txtBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchName.Caption = Me.lblBranchName
        Me.txtBranchName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBranchName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchName.ForeColorDisabled = System.Drawing.SystemColors.WindowText
        Me.txtBranchName.gotFocusColor = System.Drawing.Color.Yellow
        Me.txtBranchName.HintText = ""
        Me.txtBranchName.HintTextColor = System.Drawing.Color.Gray
        Me.txtBranchName.IsValid = False
        Me.txtBranchName.Location = New System.Drawing.Point(139, 126)
        Me.txtBranchName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBranchName.MoveOnEnter = True
        Me.txtBranchName.Name = "txtBranchName"
        Me.txtBranchName.Size = New System.Drawing.Size(327, 23)
        Me.txtBranchName.TabIndex = 23
        '
        'txtBranchCode
        '
        Me.txtBranchCode.BackColorDisabled = System.Drawing.SystemColors.Window
        Me.txtBranchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBranchCode.Caption = Me.lblBranchCode
        Me.txtBranchCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBranchCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchCode.ForeColorDisabled = System.Drawing.SystemColors.WindowText
        Me.txtBranchCode.gotFocusColor = System.Drawing.Color.Yellow
        Me.txtBranchCode.HintText = ""
        Me.txtBranchCode.HintTextColor = System.Drawing.Color.Gray
        Me.txtBranchCode.IsValid = False
        Me.txtBranchCode.Location = New System.Drawing.Point(20, 126)
        Me.txtBranchCode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBranchCode.MaxLength = 6
        Me.txtBranchCode.MoveOnEnter = True
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.Size = New System.Drawing.Size(98, 23)
        Me.txtBranchCode.TabIndex = 22
        '
        'optBranch
        '
        Me.optBranch.AutoSize = True
        Me.optBranch.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optBranch.Location = New System.Drawing.Point(19, 53)
        Me.optBranch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.optBranch.Name = "optBranch"
        Me.optBranch.Size = New System.Drawing.Size(65, 20)
        Me.optBranch.TabIndex = 21
        Me.optBranch.Tag = "Branch"
        Me.optBranch.Text = "Branch"
        '
        'optRegion
        '
        Me.optRegion.AutoSize = True
        Me.optRegion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRegion.Location = New System.Drawing.Point(93, 53)
        Me.optRegion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.optRegion.Name = "optRegion"
        Me.optRegion.Size = New System.Drawing.Size(65, 20)
        Me.optRegion.TabIndex = 20
        Me.optRegion.Tag = "1"
        Me.optRegion.Text = "Region"
        '
        'optZone
        '
        Me.optZone.AutoSize = True
        Me.optZone.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optZone.Location = New System.Drawing.Point(186, 53)
        Me.optZone.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.optZone.Name = "optZone"
        Me.optZone.Size = New System.Drawing.Size(54, 20)
        Me.optZone.TabIndex = 19
        Me.optZone.Tag = "2"
        Me.optZone.Text = "Zone"
        '
        'optBank
        '
        Me.optBank.AutoSize = True
        Me.optBank.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optBank.Location = New System.Drawing.Point(279, 53)
        Me.optBank.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.optBank.Name = "optBank"
        Me.optBank.Size = New System.Drawing.Size(53, 20)
        Me.optBank.TabIndex = 18
        Me.optBank.Tag = "3"
        Me.optBank.Text = "Bank"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 187)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "From TimeKey"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(170, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "To TimeKey"
        '
        'AutoSuggest1
        '
        Me.AutoSuggest1.BackColorDisabled = System.Drawing.SystemColors.Window
        Me.AutoSuggest1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AutoSuggest1.Caption = Me.lblBranchCode
        Me.AutoSuggest1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AutoSuggest1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoSuggest1.ForeColorDisabled = System.Drawing.SystemColors.WindowText
        Me.AutoSuggest1.gotFocusColor = System.Drawing.Color.Yellow
        Me.AutoSuggest1.HintText = "dd/MM/yyyy"
        Me.AutoSuggest1.HintTextColor = System.Drawing.Color.Gray
        Me.AutoSuggest1.IsValid = False
        Me.AutoSuggest1.Location = New System.Drawing.Point(48, 214)
        Me.AutoSuggest1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AutoSuggest1.MaxLength = 6
        Me.AutoSuggest1.MoveOnEnter = True
        Me.AutoSuggest1.Name = "AutoSuggest1"
        Me.AutoSuggest1.Size = New System.Drawing.Size(98, 23)
        Me.AutoSuggest1.TabIndex = 30
        '
        'AutoSuggest2
        '
        Me.AutoSuggest2.BackColorDisabled = System.Drawing.SystemColors.Window
        Me.AutoSuggest2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AutoSuggest2.Caption = Me.lblBranchCode
        Me.AutoSuggest2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AutoSuggest2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoSuggest2.ForeColorDisabled = System.Drawing.SystemColors.WindowText
        Me.AutoSuggest2.gotFocusColor = System.Drawing.Color.Yellow
        Me.AutoSuggest2.HintText = "dd/MM/yyyy"
        Me.AutoSuggest2.HintTextColor = System.Drawing.Color.Gray
        Me.AutoSuggest2.IsValid = False
        Me.AutoSuggest2.Location = New System.Drawing.Point(173, 214)
        Me.AutoSuggest2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.AutoSuggest2.MaxLength = 6
        Me.AutoSuggest2.MoveOnEnter = True
        Me.AutoSuggest2.Name = "AutoSuggest2"
        Me.AutoSuggest2.Size = New System.Drawing.Size(98, 23)
        Me.AutoSuggest2.TabIndex = 31
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(44, 264)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 27)
        Me.btnExport.TabIndex = 32
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'frmExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 331)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.AutoSuggest2)
        Me.Controls.Add(Me.AutoSuggest1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblBranchName)
        Me.Controls.Add(Me.lblBranchCode)
        Me.Controls.Add(Me.txtBranchName)
        Me.Controls.Add(Me.txtBranchCode)
        Me.Controls.Add(Me.optBranch)
        Me.Controls.Add(Me.optRegion)
        Me.Controls.Add(Me.optZone)
        Me.Controls.Add(Me.optBank)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmExport"
        Me.Text = "frmExport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBranchName As System.Windows.Forms.Label
    Friend WithEvents lblBranchCode As System.Windows.Forms.Label
    Friend WithEvents txtBranchName As SidControls.AutoSuggest
    Friend WithEvents txtBranchCode As SidControls.AutoSuggest
    Friend WithEvents optBranch As System.Windows.Forms.RadioButton
    Friend WithEvents optRegion As System.Windows.Forms.RadioButton
    Friend WithEvents optZone As System.Windows.Forms.RadioButton
    Friend WithEvents optBank As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AutoSuggest1 As SidControls.AutoSuggest
    Friend WithEvents AutoSuggest2 As SidControls.AutoSuggest
    Friend WithEvents btnExport As System.Windows.Forms.Button
End Class
