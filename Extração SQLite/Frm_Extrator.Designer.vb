<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Extrator
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Extrator))
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.CmbColaborador = New System.Windows.Forms.ComboBox()
        Me.LblTabelas = New System.Windows.Forms.Label()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ARQUIVOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXTRAIRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CARREGARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MODELOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CRIARToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CmbColaborador
        '
        Me.CmbColaborador.FormattingEnabled = True
        Me.CmbColaborador.Items.AddRange(New Object() {"DGA ELETRIC"})
        Me.CmbColaborador.Location = New System.Drawing.Point(70, 27)
        Me.CmbColaborador.Name = "CmbColaborador"
        Me.CmbColaborador.Size = New System.Drawing.Size(220, 21)
        Me.CmbColaborador.TabIndex = 0
        '
        'LblTabelas
        '
        Me.LblTabelas.AutoSize = True
        Me.LblTabelas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTabelas.Location = New System.Drawing.Point(12, 30)
        Me.LblTabelas.Name = "LblTabelas"
        Me.LblTabelas.Size = New System.Drawing.Size(52, 13)
        Me.LblTabelas.TabIndex = 1
        Me.LblTabelas.Text = "Tabelas"
        '
        'DGV
        '
        Me.DGV.AllowUserToOrderColumns = True
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.Location = New System.Drawing.Point(13, 54)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(667, 328)
        Me.DGV.TabIndex = 2
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ARQUIVOToolStripMenuItem, Me.MODELOToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(692, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ARQUIVOToolStripMenuItem
        '
        Me.ARQUIVOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXTRAIRToolStripMenuItem, Me.CARREGARToolStripMenuItem})
        Me.ARQUIVOToolStripMenuItem.Name = "ARQUIVOToolStripMenuItem"
        Me.ARQUIVOToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.ARQUIVOToolStripMenuItem.Text = "ARQUIVO"
        '
        'EXTRAIRToolStripMenuItem
        '
        Me.EXTRAIRToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXCELToolStripMenuItem})
        Me.EXTRAIRToolStripMenuItem.Name = "EXTRAIRToolStripMenuItem"
        Me.EXTRAIRToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.EXTRAIRToolStripMenuItem.Text = "EXTRAIR"
        '
        'EXCELToolStripMenuItem
        '
        Me.EXCELToolStripMenuItem.Name = "EXCELToolStripMenuItem"
        Me.EXCELToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EXCELToolStripMenuItem.Text = "EXCEL"
        '
        'CARREGARToolStripMenuItem
        '
        Me.CARREGARToolStripMenuItem.Name = "CARREGARToolStripMenuItem"
        Me.CARREGARToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.CARREGARToolStripMenuItem.Text = "CARREGAR"
        '
        'MODELOToolStripMenuItem
        '
        Me.MODELOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CRIARToolStripMenuItem})
        Me.MODELOToolStripMenuItem.Name = "MODELOToolStripMenuItem"
        Me.MODELOToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.MODELOToolStripMenuItem.Text = "MODELO"
        '
        'CRIARToolStripMenuItem
        '
        Me.CRIARToolStripMenuItem.Name = "CRIARToolStripMenuItem"
        Me.CRIARToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.CRIARToolStripMenuItem.Text = "CRIAR"
        '
        'Frm_Extrator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 394)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.LblTabelas)
        Me.Controls.Add(Me.CmbColaborador)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Frm_Extrator"
        Me.Text = "Extrator SQLite"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CmbColaborador As System.Windows.Forms.ComboBox
    Friend WithEvents LblTabelas As System.Windows.Forms.Label
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ARQUIVOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EXTRAIRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EXCELToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CARREGARToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MODELOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CRIARToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SFD As System.Windows.Forms.SaveFileDialog

End Class
