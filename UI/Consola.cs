﻿using System;
using System.Collections.Generic;
using Domain;
using BLL;

namespace UI
{
    class Consola
    {
        static void Main(string[] args)
        {
            AgendaController agendaController = AgendaController.Instance;
            ContactoController contactoController = ContactoController.Instance;
            EmailsController emailsController = EmailsController.Instance;
            TelefonosController telefonosController = TelefonosController.Instance;

            #region Menu Principal
            Console.WriteLine("Seleccione su opcion");
            Console.WriteLine("");
            Console.WriteLine("1 - Crear Agenda");
            Console.WriteLine("2 - Ingresar Agenda");
            Console.WriteLine("");

            Int32 opcion;
            do
            {
                bool isNum = int.TryParse(Console.ReadLine(), out opcion);

                if (opcion != 1 && opcion != 2)
                {
                    Console.WriteLine("Ingrese una opcion valida");
                }

            } while (opcion != 1 && opcion != 2);

            switch (opcion)
            {
                case 1:
                    IrAgenda(CrearAgenda());
                    break;
                case 2:
                    MostrarAgendas();
                    IrAgenda(SeleccionarAgenda(agendaController.Mostrar()));
                    break;
            }
            #endregion

            // Crear Agenda
            Agenda CrearAgenda()
            {
                Agenda agenda = new Agenda();

                DateTime fechaHoy = DateTime.Now.Date;
                string sqlFormattedDate = fechaHoy.ToString("yyyy-MM-dd");
                Console.WriteLine("Ingrese el nombre de su Agenda");
                String nombre;
                do
                {
                    nombre = Console.ReadLine();
                } while (nombre != "");

                agenda.FechaCreacion = fechaHoy;
                agenda.Nombre = nombre;
                agenda.Activo = true;
                agendaController.Crear(agenda);

                Console.Clear();
                return agenda;
            }

            // Mostrar Agendas
            void MostrarAgendas()
            {
                Console.Clear();
                List<Agenda> agendas = agendaController.Mostrar();
                for (int i = 0; i < agendas.Count; i++)
                {
                    Console.WriteLine(i + " --- " + agendas[i].Nombre);
                }
            }

            // Seleccionar Agenda
            Agenda SeleccionarAgenda(List<Agenda> agendas)
            {
                Console.WriteLine("");
                int seleccionAgenda;
                bool isNum;
                Agenda agenda = new Agenda();

                do
                {
                    isNum = int.TryParse(Console.ReadLine(), out seleccionAgenda);

                    if (isNum)
                    {
                        if (agendas[seleccionAgenda] == null)
                        {
                            Console.WriteLine("Ingrese una opcion valida");
                        }
                        else
                        {
                            agenda = agendas[seleccionAgenda];
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ingrese una opcion valida");
                    }


                } while (agendas[seleccionAgenda] == null || !isNum);

                return agenda;
            }

            #region Menu Dentro de Agenda
            // Ir a Agenda
            void IrAgenda(Agenda agenda)
            {
                contactoController.SeleccionarAgenda(agenda);
                Console.Clear();

                Boolean salir = false;
                do
                {
                    Console.WriteLine("Seleccione su opcion");
                    Console.WriteLine("");
                    Console.WriteLine("1 - Agregar Contacto");
                    Console.WriteLine("2 - Ver/Modificar Contacto");
                    Console.WriteLine("3 - Borrar Contacto");
                    Console.WriteLine("4 - Buscar Contacto");
                    Console.WriteLine("5 - Buscar Contacto por Pais");
                    Console.WriteLine("0 - Salir");
                    Console.WriteLine("");

                    Int32 opcionAgenda;
                    do
                    {
                        bool isNum = int.TryParse(Console.ReadLine(), out opcionAgenda);

                        if (opcion < 0 && opcion > 5)
                        {
                            Console.WriteLine("Ingrese una opcion valida");
                        }

                    } while (opcion < 0 && opcion > 5);

                    switch (opcionAgenda)
                    {
                        case 1:
                            CrearContacto();
                            break;
                        case 2:
                            // Ver/Modificar Contacto
                            break;
                        case 3:
                            // Borrar Contacto
                            break;
                        case 4:
                            // Buscar Contacto
                            break;
                        case 5:
                            // Buscar Contacto por Pais
                            break;
                        case 0:
                            salir = true;
                            break;
                    }
                } while (!salir);
            }

            // Crear Contacto
            Contacto CrearContacto()
            {
                Contacto contacto = new Contacto();
                Console.WriteLine("Ingrese el nombre de su Contacto");
                String nombre;
                do
                {
                    nombre = Console.ReadLine();
                } while (nombre != "");

                Console.WriteLine("");
                Boolean fechaNacimientoValida = false;
                DateTime fechaNacimiento;
                do
                {
                    Console.WriteLine("Ingrese su nacimiento(AAAA-MM-DD)");
                    fechaNacimientoValida = DateTime.TryParse(Console.ReadLine(), out fechaNacimiento);
                    Console.WriteLine("");
                } while (!fechaNacimientoValida);
                Console.WriteLine("Ingrese el pais de su Contacto");
                String pais;
                do
                {
                    pais = Console.ReadLine();
                } while (pais != "");
                Console.WriteLine("");

                contacto.Nombre = nombre;
                contacto.FecNac = fechaNacimiento;
                contacto.Pais = pais;
                contacto.Activo = true;
                contactoController.Crear(contacto);

                Emails email = new Emails();
                Telefonos telefono = new Telefonos();



                Console.Clear();
                return contacto;
            }

            // Modificar Contacto
            void ModificarContacto()
            {

            }

            // Borrar Contacto
            void BorrarContacto()
            {

            }

            
            // Listar Contactos
            void MostrarContactos(Agenda agenda)
            {
                Console.Clear();
                List<Contacto> contactos = contactoController.Mostrar(agenda);
                for (int i = 0; i < contactos.Count; i++)
                {
                    Console.WriteLine(i + " --- " + contactos[i].Nombre);
                }
            }

            // Buscar Contacto
            List<Contacto> BuscarContacto()
            {

            }

            // Buscar Contacto por Pais
            List<Contacto> ListarContactoPais()
            {

            }
            #endregion

        }
    }
}
