﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using DAL;

namespace BLL
{
    public class TelefonosController
    {
        #region Singelton
        private static TelefonosController instance;
        public static TelefonosController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TelefonosController();
                }
                return instance;
            }
        }
        #endregion

        TelefonosService telefonosService = TelefonosService.Instance;
        public Contacto Contacto { get; set; }

        // Crea un Telefono para un Contacto
        public void Crear(Telefonos telefono)
        {

        }

        // Modifica el Telefono de un Contacto en la Base de Datos
        public void Modificar(String tipoTelefono, String telefono, Contacto contacto)
        {
            
        }

        // Elimina el Telefono de un Contacto
        public void Borrar(Telefonos telefono)
        {
           
        }

        // Muestra los telefonos de un Contacto
        //public List<Telefonos> Mostrar(Contacto contacto)


        // Selecciona un Contacto
        public void SeleccionarContacto(Contacto contacto)
        {
           
        }
    }
}
