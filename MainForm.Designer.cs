/*
 * Created by SharpDevelop.
 * User: cesar
 * Date: 12/03/2022
 * Time: 04:39 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace RamirezRodriguezCesarOswaldoCF
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button buttonSeleccion;
		private System.Windows.Forms.PictureBox pictureBoxImage;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ListView listViewGrafo;
		private System.Windows.Forms.ColumnHeader columnHeaderID;
		private System.Windows.Forms.ColumnHeader columnHeaderX;
		private System.Windows.Forms.ColumnHeader columnHeaderY;
		private System.Windows.Forms.ColumnHeader columnHeaderConecta;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonSeleccion = new System.Windows.Forms.Button();
			this.pictureBoxImage = new System.Windows.Forms.PictureBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.listViewGrafo = new System.Windows.Forms.ListView();
			this.columnHeaderID = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderX = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderY = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderConecta = new System.Windows.Forms.ColumnHeader();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonSeleccion
			// 
			this.buttonSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonSeleccion.Location = new System.Drawing.Point(1001, 12);
			this.buttonSeleccion.Name = "buttonSeleccion";
			this.buttonSeleccion.Size = new System.Drawing.Size(317, 38);
			this.buttonSeleccion.TabIndex = 0;
			this.buttonSeleccion.Text = "Seleccionar Imagen";
			this.buttonSeleccion.UseVisualStyleBackColor = true;
			this.buttonSeleccion.Click += new System.EventHandler(this.ButtonSeleccionClick);
			// 
			// pictureBoxImage
			// 
			this.pictureBoxImage.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxImage.Name = "pictureBoxImage";
			this.pictureBoxImage.Size = new System.Drawing.Size(983, 624);
			this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxImage.TabIndex = 1;
			this.pictureBoxImage.TabStop = false;
			this.pictureBoxImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImageMouseClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// listViewGrafo
			// 
			this.listViewGrafo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeaderID,
			this.columnHeaderX,
			this.columnHeaderY,
			this.columnHeaderConecta});
			this.listViewGrafo.Location = new System.Drawing.Point(1001, 198);
			this.listViewGrafo.Name = "listViewGrafo";
			this.listViewGrafo.Size = new System.Drawing.Size(317, 438);
			this.listViewGrafo.TabIndex = 2;
			this.listViewGrafo.UseCompatibleStateImageBehavior = false;
			this.listViewGrafo.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderID
			// 
			this.columnHeaderID.Text = "ID";
			// 
			// columnHeaderX
			// 
			this.columnHeaderX.Text = "X";
			// 
			// columnHeaderY
			// 
			this.columnHeaderY.Text = "Y";
			// 
			// columnHeaderConecta
			// 
			this.columnHeaderConecta.Text = "Conectado Con";
			this.columnHeaderConecta.Width = 107;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1330, 648);
			this.Controls.Add(this.listViewGrafo);
			this.Controls.Add(this.pictureBoxImage);
			this.Controls.Add(this.buttonSeleccion);
			this.Name = "MainForm";
			this.Text = "RamirezRodriguezCesarOswaldoCF";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
