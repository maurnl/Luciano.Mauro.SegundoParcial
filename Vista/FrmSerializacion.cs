using Biblioteca.Modelos;
using Biblioteca.Serializacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Properties;

namespace Vista
{
    public partial class FrmSerializacion : Form
    {
        private List<PartidaTerminada> partidasTerminadas;
        private bool serializando;
        private SerializadorJson<List<PartidaTerminada>> serializadorJson;
        private SerializadorXML<List<PartidaTerminada>> serializadorXml;

        public List<PartidaTerminada> PartidasDeserializadas
        {
            get
            {
                return this.partidasTerminadas;
            }
        }

        public FrmSerializacion()
        {
            InitializeComponent();
            this.serializadorJson = new SerializadorJson<List<PartidaTerminada>>("historial_partidas.json");
            this.serializadorXml = new SerializadorXML<List<PartidaTerminada>>("historial_partidas.xml");
        }

        public FrmSerializacion(List<PartidaTerminada> lista, bool serializando) : this()
        {
            this.btnAceptar.Text = serializando ? "Guardar archivo" : "Leer archivo";
            this.serializando = serializando;
            this.partidasTerminadas = lista;
        }

        private void FrmSerializacion_Load(object sender, EventArgs e)
        {
            this.cboTipoSerializacion.DropDownStyle = ComboBoxStyle.DropDownList;
            this.BackgroundImage = (Image)Resources.ResourceManager.GetObject("fondo_menu")!;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.cboTipoSerializacion.DataSource = Enum.GetValues(typeof(FormatoSerializacion));
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (serializando)
            {
                if((FormatoSerializacion)cboTipoSerializacion.SelectedItem == FormatoSerializacion.Json)
                {
                    this.serializadorJson.Serializar(partidasTerminadas);
                } 
                else
                {
                    this.serializadorXml.Serializar(partidasTerminadas);
                }
            }
            else
            {
                if ((FormatoSerializacion)cboTipoSerializacion.SelectedItem == FormatoSerializacion.Json)
                {
                    this.partidasTerminadas = this.serializadorJson.Deserializar();
                }
                else
                {
                    this.partidasTerminadas = this.serializadorXml.Deserializar();
                }
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
