using System;
using System.Collections.Generic;
using System.Text;
using AppXamarinForms.Interface.Navegacion;
using AppXamarinForms.Interface.AlumnoCarrera;
using AppXamarinForms.Services.AlumnoCarrera;
using AppXamarinForms.Services;
using Autofac;
using AppXamarinForms.ViewModels.AlumnoCarrera;

namespace AppXamarinForms.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicIContainer;

        public FicViewModelLocator()
        {
            //FIC: ContainerBuilder es una clase de la libreria de Autofac para poder ejecutar la interfaz en las diferentes plataformas 
            var FicContainerBuilder = new ContainerBuilder();

            //-------------------------------- VIEW MODELS ------------------------------------------------------           
            FicContainerBuilder.RegisterType<FicVmAlumnoCarreraList>();
            FicContainerBuilder.RegisterType<FicVmAlumnoCarreraAdd>();
            FicContainerBuilder.RegisterType<FicVmAlumnoCarreraUpdate>();
            FicContainerBuilder.RegisterType<FicVmAlumnoCarreraView>();
            //FicContainerBuilder.RegisterType<FicVmExportarWebApi>();
            FicContainerBuilder.RegisterType<FicVmCatEdificiosImportarExportar>();
            

            //------------------------- INTERFACE SERVICES OF THE VIEW MODELS -----------------------------------

            FicContainerBuilder.RegisterType<FicSrvNavigationCatEdificios>().As<IFicSrvNavegationCatEdificiosList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvAlumnoCarreraList>().As<IFicSvrAlumnoCarreraList>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvAlumnoCarreraAdd>().As<IFicSrvAlumnoCarreraAdd>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvAlumnoCarreraUpdate>().As<IFicSrvAlumnoCarreraUpdate>().SingleInstance();
            //FicContainerBuilder.RegisterType<FicSrvExportarWebApi>().As<IFicSrvExportarWebApi>().SingleInstance();
            FicContainerBuilder.RegisterType<FicSrvCatEdificiosImportarExportar>().As<IFicSrvCatEdificiosImportarExportar>().SingleInstance();
            

            //FIC: se asigna o se libera el contenedor
            //-------------------------------------------
            if (FicIContainer != null) FicIContainer.Dispose();

            FicIContainer = FicContainerBuilder.Build();
        }//CONSTRUCTOR

        //-------------------- CONTROL DE INVENTARIOS ------------------------
        //FIC: se manda llamar desde el backend de la View de List
       
        public FicVmAlumnoCarreraList FicVmAlumnoCarreraList
        {
            get { return FicIContainer.Resolve<FicVmAlumnoCarreraList>(); }
        }

        public FicVmAlumnoCarreraAdd FicVmAlumnoCarreraAdd
        {
            get { return FicIContainer.Resolve<FicVmAlumnoCarreraAdd>();  }
        }

        public FicVmAlumnoCarreraUpdate FicVmAlumnoCarreraUpdate
        {
            get { return FicIContainer.Resolve<FicVmAlumnoCarreraUpdate>(); }
        }

        public FicVmAlumnoCarreraView FicVmAlumnoCarreraView
        {
            get { return FicIContainer.Resolve<FicVmAlumnoCarreraView>(); }
        }

       /* public FicVmExportarWebApi FicVmExportarWebApi
        {
            get { return FicIContainer.Resolve<FicVmExportarWebApi>(); }
        }
        */
        public FicVmCatEdificiosImportarExportar FicVmCatEdificiosImportarExportar
        {
            get { return FicIContainer.Resolve<FicVmCatEdificiosImportarExportar>(); }
        }
        
    }
}
