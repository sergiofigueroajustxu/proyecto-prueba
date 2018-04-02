<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Partida_Detalle
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Partida_Detalle))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Nombre_Cuenta = New System.Windows.Forms.TextBox()
        Me.Cuenta = New System.Windows.Forms.TextBox()
        Me.debe = New System.Windows.Forms.NumericUpDown()
        Me.haber = New System.Windows.Forms.NumericUpDown()
        Me.idsucursal = New System.Windows.Forms.ComboBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.debe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.haber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cuenta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Centro Costo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 24)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Debe"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 24)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Haber"
        '
        'Nombre_Cuenta
        '
        Me.Nombre_Cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nombre_Cuenta.Location = New System.Drawing.Point(166, 67)
        Me.Nombre_Cuenta.Name = "Nombre_Cuenta"
        Me.Nombre_Cuenta.ReadOnly = True
        Me.Nombre_Cuenta.Size = New System.Drawing.Size(345, 29)
        Me.Nombre_Cuenta.TabIndex = 5
        '
        'Cuenta
        '
        Me.Cuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuenta.Location = New System.Drawing.Point(166, 25)
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        Me.Cuenta.Size = New System.Drawing.Size(162, 29)
        Me.Cuenta.TabIndex = 6
        '
        'debe
        '
        Me.debe.DecimalPlaces = 2
        Me.debe.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.debe.Location = New System.Drawing.Point(166, 154)
        Me.debe.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.debe.Name = "debe"
        Me.debe.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.debe.Size = New System.Drawing.Size(162, 32)
        Me.debe.TabIndex = 7
        Me.debe.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
        '
        'haber
        '
        Me.haber.DecimalPlaces = 2
        Me.haber.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.haber.Location = New System.Drawing.Point(166, 194)
        Me.haber.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.haber.Name = "haber"
        Me.haber.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.haber.Size = New System.Drawing.Size(162, 32)
        Me.haber.TabIndex = 8
        Me.haber.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
        '
        'idsucursal
        '
        Me.idsucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.idsucursal.FormattingEnabled = True
        Me.idsucursal.Location = New System.Drawing.Point(166, 110)
        Me.idsucursal.Name = "idsucursal"
        Me.idsucursal.Size = New System.Drawing.Size(345, 33)
        Me.idsucursal.TabIndex = 9
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(432, 256)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(79, 59)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 11
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(289, 256)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(79, 59)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'Partida_Detalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 345)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.idsucursal)
        Me.Controls.Add(Me.haber)
        Me.Controls.Add(Me.debe)
        Me.Controls.Add(Me.Cuenta)
        Me.Controls.Add(Me.Nombre_Cuenta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Partida_Detalle"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Partida_Detalle"
        CType(Me.debe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.haber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Nombre_Cuenta As TextBox
    Friend WithEvents Cuenta As TextBox
    Friend WithEvents debe As NumericUpDown
    Friend WithEvents haber As NumericUpDown
    Friend WithEvents idsucursal As ComboBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
End Class
