<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Carregar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Carregar))
        Me.DGV_Carga = New System.Windows.Forms.DataGridView()
        Me.BtnCarga = New System.Windows.Forms.Button()
        Me.BtnCarregar = New System.Windows.Forms.Button()
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.PB = New System.Windows.Forms.ProgressBar()
        CType(Me.DGV_Carga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_Carga
        '
        Me.DGV_Carga.AllowUserToAddRows = False
        Me.DGV_Carga.AllowUserToDeleteRows = False
        Me.DGV_Carga.AllowUserToOrderColumns = True
        Me.DGV_Carga.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Carga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Carga.Location = New System.Drawing.Point(12, 70)
        Me.DGV_Carga.Name = "DGV_Carga"
        Me.DGV_Carga.Size = New System.Drawing.Size(900, 362)
        Me.DGV_Carga.TabIndex = 0
        '
        'BtnCarga
        '
        Me.BtnCarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCarga.Location = New System.Drawing.Point(12, 12)
        Me.BtnCarga.Name = "BtnCarga"
        Me.BtnCarga.Size = New System.Drawing.Size(900, 23)
        Me.BtnCarga.TabIndex = 1
        Me.BtnCarga.Text = "Selecione a Carga"
        Me.BtnCarga.UseVisualStyleBackColor = True
        '
        'BtnCarregar
        '
        Me.BtnCarregar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCarregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCarregar.Location = New System.Drawing.Point(12, 41)
        Me.BtnCarregar.Name = "BtnCarregar"
        Me.BtnCarregar.Size = New System.Drawing.Size(900, 23)
        Me.BtnCarregar.TabIndex = 2
        Me.BtnCarregar.Text = "Carregar"
        Me.BtnCarregar.UseVisualStyleBackColor = True
        '
        'OFD
        '
        Me.OFD.FileName = "OpenFileDialog1"
        '
        'PB
        '
        Me.PB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PB.Location = New System.Drawing.Point(12, 41)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(900, 23)
        Me.PB.TabIndex = 3
        '
        'Frm_Carregar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 444)
        Me.Controls.Add(Me.PB)
        Me.Controls.Add(Me.BtnCarregar)
        Me.Controls.Add(Me.BtnCarga)
        Me.Controls.Add(Me.DGV_Carga)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Carregar"
        Me.Text = "Carregar Arquivo"
        CType(Me.DGV_Carga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGV_Carga As System.Windows.Forms.DataGridView
    Friend WithEvents BtnCarga As System.Windows.Forms.Button
    Friend WithEvents BtnCarregar As System.Windows.Forms.Button
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PB As System.Windows.Forms.ProgressBar
End Class
