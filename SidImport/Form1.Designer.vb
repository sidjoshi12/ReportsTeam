<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.label7 = New System.Windows.Forms.Label()
        Me.cmbAction = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cmbDB = New System.Windows.Forms.ComboBox()
        Me.cmbPass = New System.Windows.Forms.ComboBox()
        Me.cmbUID = New System.Windows.Forms.ComboBox()
        Me.cmbServer = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label7.Location = New System.Drawing.Point(29, 174)
        Me.label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(45, 16)
        Me.label7.TabIndex = 27
        Me.label7.Text = "Action"
        '
        'cmbAction
        '
        Me.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAction.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbAction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAction.FormattingEnabled = True
        Me.cmbAction.Items.AddRange(New Object() {"Export", "Import"})
        Me.cmbAction.Location = New System.Drawing.Point(113, 166)
        Me.cmbAction.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbAction.Name = "cmbAction"
        Me.cmbAction.Size = New System.Drawing.Size(203, 24)
        Me.cmbAction.TabIndex = 26
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(241, 210)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 28)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "Test"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(113, 210)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 28)
        Me.btnOK.TabIndex = 24
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(33, 141)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(27, 16)
        Me.label4.TabIndex = 23
        Me.label4.Text = "DB"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(29, 107)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(39, 16)
        Me.label3.TabIndex = 22
        Me.label3.Text = "Pass"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(29, 74)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(31, 16)
        Me.label2.TabIndex = 21
        Me.label2.Text = "UID"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(29, 41)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(83, 16)
        Me.label1.TabIndex = 20
        Me.label1.Text = "Data Source"
        '
        'cmbDB
        '
        Me.cmbDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDB.FormattingEnabled = True
        Me.cmbDB.Items.AddRange(New Object() {"OVSepPOST", "UCO_LEGAL_PLUS"})
        Me.cmbDB.Location = New System.Drawing.Point(113, 133)
        Me.cmbDB.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbDB.Name = "cmbDB"
        Me.cmbDB.Size = New System.Drawing.Size(203, 24)
        Me.cmbDB.TabIndex = 19
        '
        'cmbPass
        '
        Me.cmbPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPass.FormattingEnabled = True
        Me.cmbPass.Items.AddRange(New Object() {"sa123", "1808"})
        Me.cmbPass.Location = New System.Drawing.Point(113, 99)
        Me.cmbPass.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPass.Name = "cmbPass"
        Me.cmbPass.Size = New System.Drawing.Size(203, 24)
        Me.cmbPass.TabIndex = 18
        '
        'cmbUID
        '
        Me.cmbUID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUID.FormattingEnabled = True
        Me.cmbUID.Items.AddRange(New Object() {"sa", "dm085"})
        Me.cmbUID.Location = New System.Drawing.Point(113, 66)
        Me.cmbUID.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbUID.Name = "cmbUID"
        Me.cmbUID.Size = New System.Drawing.Size(203, 24)
        Me.cmbUID.TabIndex = 17
        '
        'cmbServer
        '
        Me.cmbServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbServer.FormattingEnabled = True
        Me.cmbServer.Items.AddRange(New Object() {"D2K62\SQLEXPRESS", "DBSERVER2\DBSERVER2"})
        Me.cmbServer.Location = New System.Drawing.Point(113, 33)
        Me.cmbServer.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbServer.Name = "cmbServer"
        Me.cmbServer.Size = New System.Drawing.Size(203, 24)
        Me.cmbServer.TabIndex = 16
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 271)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.cmbAction)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.cmbDB)
        Me.Controls.Add(Me.cmbPass)
        Me.Controls.Add(Me.cmbUID)
        Me.Controls.Add(Me.cmbServer)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents cmbAction As System.Windows.Forms.ComboBox
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents cmbDB As System.Windows.Forms.ComboBox
    Private WithEvents cmbPass As System.Windows.Forms.ComboBox
    Private WithEvents cmbUID As System.Windows.Forms.ComboBox
    Private WithEvents cmbServer As System.Windows.Forms.ComboBox
End Class
