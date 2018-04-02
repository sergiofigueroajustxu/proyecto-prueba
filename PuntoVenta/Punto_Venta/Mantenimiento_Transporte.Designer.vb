<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mantenimiento_Transporte
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.idtransporte = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numero_placa = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.nombre = New System.Windows.Forms.TextBox()
        Me.telefono = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.direccion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.km_vehiculo = New System.Windows.Forms.NumericUpDown()
        Me.valor_km = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.fecha_inicio = New System.Windows.Forms.DateTimePicker()
        Me.codigo_empleado = New System.Windows.Forms.ComboBox()
        Me.cuenta_contable = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.km_vehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.valor_km, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 7)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(645, 309)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transporte"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(96, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(523, 23)
        Me.TextBox1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Buscar"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10})
        Me.DataGridView1.Location = New System.Drawing.Point(38, 60)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(581, 236)
        Me.DataGridView1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 326)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ID"
        '
        'idtransporte
        '
        Me.idtransporte.AutoSize = True
        Me.idtransporte.Location = New System.Drawing.Point(127, 329)
        Me.idtransporte.Name = "idtransporte"
        Me.idtransporte.Size = New System.Drawing.Size(19, 17)
        Me.idtransporte.TabIndex = 2
        Me.idtransporte.Text = "id"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 360)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Placa Vh."
        '
        'numero_placa
        '
        Me.numero_placa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.numero_placa.Location = New System.Drawing.Point(130, 357)
        Me.numero_placa.Name = "numero_placa"
        Me.numero_placa.Size = New System.Drawing.Size(432, 23)
        Me.numero_placa.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 389)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Nombre"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(583, 334)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Nuevo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(583, 363)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Modificar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(582, 392)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Eliminar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(583, 422)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "XML"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'nombre
        '
        Me.nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nombre.Location = New System.Drawing.Point(130, 386)
        Me.nombre.Name = "nombre"
        Me.nombre.Size = New System.Drawing.Size(432, 23)
        Me.nombre.TabIndex = 11
        '
        'telefono
        '
        Me.telefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.telefono.Location = New System.Drawing.Point(130, 415)
        Me.telefono.Name = "telefono"
        Me.telefono.Size = New System.Drawing.Size(158, 23)
        Me.telefono.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 418)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Telefonos"
        '
        'direccion
        '
        Me.direccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.direccion.Location = New System.Drawing.Point(130, 444)
        Me.direccion.Name = "direccion"
        Me.direccion.Size = New System.Drawing.Size(432, 23)
        Me.direccion.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 447)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Direccion"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 473)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 17)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Kilometraje"
        '
        'km_vehiculo
        '
        Me.km_vehiculo.DecimalPlaces = 2
        Me.km_vehiculo.Location = New System.Drawing.Point(130, 473)
        Me.km_vehiculo.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.km_vehiculo.Name = "km_vehiculo"
        Me.km_vehiculo.Size = New System.Drawing.Size(158, 23)
        Me.km_vehiculo.TabIndex = 17
        '
        'valor_km
        '
        Me.valor_km.DecimalPlaces = 2
        Me.valor_km.Location = New System.Drawing.Point(416, 473)
        Me.valor_km.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.valor_km.Name = "valor_km"
        Me.valor_km.Size = New System.Drawing.Size(146, 23)
        Me.valor_km.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(335, 475)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 17)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Valor x Km"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 505)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 17)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Empleado"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(336, 418)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 17)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Inscrito"
        '
        'fecha_inicio
        '
        Me.fecha_inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha_inicio.Location = New System.Drawing.Point(416, 415)
        Me.fecha_inicio.Name = "fecha_inicio"
        Me.fecha_inicio.Size = New System.Drawing.Size(145, 23)
        Me.fecha_inicio.TabIndex = 22
        '
        'codigo_empleado
        '
        Me.codigo_empleado.FormattingEnabled = True
        Me.codigo_empleado.Location = New System.Drawing.Point(131, 502)
        Me.codigo_empleado.Name = "codigo_empleado"
        Me.codigo_empleado.Size = New System.Drawing.Size(431, 24)
        Me.codigo_empleado.TabIndex = 23
        '
        'cuenta_contable
        '
        Me.cuenta_contable.FormattingEnabled = True
        Me.cuenta_contable.Location = New System.Drawing.Point(130, 532)
        Me.cuenta_contable.Name = "cuenta_contable"
        Me.cuenta_contable.Size = New System.Drawing.Size(431, 24)
        Me.cuenta_contable.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 536)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(113, 17)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Cuenta Contable"
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "idtransporte"
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "numero_placa"
        Me.Column2.HeaderText = "Placa"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "nombre"
        Me.Column3.HeaderText = "Nombre"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 250
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "telefono"
        Me.Column4.HeaderText = "telefono"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "direccion"
        Me.Column5.HeaderText = "direccion"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 250
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "km_vehiculo"
        Me.Column6.HeaderText = "Kilometraje"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "valor_km"
        Me.Column7.HeaderText = "Valor x Km"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "fecha_inicio"
        Me.Column8.HeaderText = "Inicio"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "codigo_empleado"
        Me.Column9.HeaderText = "Empleado"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.DataPropertyName = "cuenta_contable"
        Me.Column10.HeaderText = "Cuenta"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Mantenimiento_Transporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 569)
        Me.Controls.Add(Me.cuenta_contable)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.codigo_empleado)
        Me.Controls.Add(Me.fecha_inicio)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.valor_km)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.km_vehiculo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.direccion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.telefono)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.nombre)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.numero_placa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.idtransporte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Mantenimiento_Transporte"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento Transporte"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.km_vehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.valor_km, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents idtransporte As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numero_placa As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As Button
    Friend WithEvents nombre As TextBox
    Friend WithEvents telefono As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents direccion As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents km_vehiculo As NumericUpDown
    Friend WithEvents valor_km As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents fecha_inicio As DateTimePicker
    Friend WithEvents codigo_empleado As ComboBox
    Friend WithEvents cuenta_contable As ComboBox
    Friend WithEvents Label12 As Label
End Class
