<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
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
        Me.btnPegawai = New System.Windows.Forms.Button()
        Me.btnProvider = New System.Windows.Forms.Button()
        Me.btnPulsa = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPesanan = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnPegawai
        '
        Me.btnPegawai.Location = New System.Drawing.Point(12, 34)
        Me.btnPegawai.Name = "btnPegawai"
        Me.btnPegawai.Size = New System.Drawing.Size(115, 41)
        Me.btnPegawai.TabIndex = 0
        Me.btnPegawai.Text = "Form Pegawai"
        Me.btnPegawai.UseVisualStyleBackColor = True
        '
        'btnProvider
        '
        Me.btnProvider.Location = New System.Drawing.Point(12, 103)
        Me.btnProvider.Name = "btnProvider"
        Me.btnProvider.Size = New System.Drawing.Size(115, 40)
        Me.btnProvider.TabIndex = 1
        Me.btnProvider.Text = "Form Provider"
        Me.btnProvider.UseVisualStyleBackColor = True
        '
        'btnPulsa
        '
        Me.btnPulsa.Location = New System.Drawing.Point(12, 173)
        Me.btnPulsa.Name = "btnPulsa"
        Me.btnPulsa.Size = New System.Drawing.Size(115, 40)
        Me.btnPulsa.TabIndex = 2
        Me.btnPulsa.Text = "Form Pulsa"
        Me.btnPulsa.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(150, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Untuk Masuk Kedalam Form Pegawai"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(150, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(242, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Untuk Masuk Kedalam Form Provider"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(150, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(224, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Untuk Masuk Kedalam Form Pulsa"
        '
        'btnPesanan
        '
        Me.btnPesanan.Location = New System.Drawing.Point(12, 234)
        Me.btnPesanan.Name = "btnPesanan"
        Me.btnPesanan.Size = New System.Drawing.Size(115, 40)
        Me.btnPesanan.TabIndex = 6
        Me.btnPesanan.Text = "Form Pesanan"
        Me.btnPesanan.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(150, 246)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(245, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Untuk Masuk Kedalam Form Pesanan"
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 286)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnPesanan)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPulsa)
        Me.Controls.Add(Me.btnProvider)
        Me.Controls.Add(Me.btnPegawai)
        Me.Name = "frmDashboard"
        Me.Text = "==Dashboard Admin=="
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPegawai As System.Windows.Forms.Button
    Friend WithEvents btnProvider As System.Windows.Forms.Button
    Friend WithEvents btnPulsa As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnPesanan As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
