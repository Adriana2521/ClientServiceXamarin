using ClientServiceXamarin.Models;
using ClientServiceXamarin.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ClientServiceXamarin.ViewModels
{
    public class VotacionViewModel : INotifyPropertyChanged
    {

        ClienteService clienteService= new ClienteService();
        public Preguntas preguntas { get; set; }
        public Command VotacionCommand { get; set; }
        public string error { get; set; }
        public bool Votacion { get; set; }

        public VotacionViewModel()
        {
            VotacionCommand = new Command<int>(Votaciones);
            CargarEncuesta();
           
        }
        public async  void CargarEncuesta()
        {
            preguntas = await clienteService.GetPreguntas();

            if (preguntas == null) error = "No se encontro el servidor";

            Enviar();


        }
        private async void Votaciones(int VotacionVotos)
        {
            try
            {
                if (preguntas!=null)
                {
                    VotacionClientes votos = new VotacionClientes();
                    votos.votacion = VotacionVotos;
                    await clienteService.ContestarPOST(votos);
                    Votacion = false;
                    Enviar();
                }
            }
            catch (Exception ex)
            {
                error=ex.Message;
                Enviar(nameof(error));
            }
        }

        public void Enviar(string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));  
        }


















        public event PropertyChangedEventHandler PropertyChanged;
    }
}
